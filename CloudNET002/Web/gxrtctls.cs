using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxrtctls : GXProcedure
   {
      public gxrtctls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", false);
      }

      public gxrtctls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         initialize();
         ExecuteImpl();
         aP0_Status=this.AV2Status;
      }

      public short executeUdp( )
      {
         execute(out aP0_Status);
         return AV2Status ;
      }

      public void executeSubmit( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         SubmitImpl();
         aP0_Status=this.AV2Status;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV2Status = 0;
         Console.WriteLine( "=== Starting run time controls" );
         Console.WriteLine( "Searching TCliente for duplicate values on new unique index on ClienteCPF" );
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKR012 = false;
            A7ClienteCPF = LTCTLS2_A7ClienteCPF[0];
            A1EmpresaId = LTCTLS2_A1EmpresaId[0];
            A5ClienteId = LTCTLS2_A5ClienteId[0];
            AV3Count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( LTCTLS2_A7ClienteCPF[0] == A7ClienteCPF ) )
            {
               BRKR012 = false;
               A1EmpresaId = LTCTLS2_A1EmpresaId[0];
               A5ClienteId = LTCTLS2_A5ClienteId[0];
               if ( AV3Count != 0 )
               {
                  AV2Status = 1;
                  Console.WriteLine( "Fail: Duplicates found. The first non unique value found follows." );
                  Console.WriteLine( "ClienteCPF: "+StringUtil.Str( (decimal)(A7ClienteCPF), 10, 0) );
                  Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0020." );
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               AV3Count = (int)(AV3Count+1);
               BRKR012 = true;
               pr_default.readNext(0);
            }
            if ( AV2Status != 0 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKR012 )
            {
               BRKR012 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         if ( AV2Status == 0 )
         {
            Console.WriteLine( "Success: No duplicates found for ClienteCPF" );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "=== End of run time controls" );
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         LTCTLS2_A7ClienteCPF = new long[1] ;
         LTCTLS2_A1EmpresaId = new long[1] ;
         LTCTLS2_A5ClienteId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A7ClienteCPF, LTCTLS2_A1EmpresaId, LTCTLS2_A5ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV2Status ;
      private int AV3Count ;
      private long A7ClienteCPF ;
      private long A1EmpresaId ;
      private long A5ClienteId ;
      private bool BRKR012 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] LTCTLS2_A7ClienteCPF ;
      private long[] LTCTLS2_A1EmpresaId ;
      private long[] LTCTLS2_A5ClienteId ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmLTCTLS2;
          prmLTCTLS2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT [ClienteCPF], [EmpresaId], [ClienteId] FROM [TCliente] ORDER BY [ClienteCPF] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
