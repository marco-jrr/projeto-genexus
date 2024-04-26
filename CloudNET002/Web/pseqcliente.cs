using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pseqcliente : GXProcedure
   {
      public pseqcliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public pseqcliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmpresaId ,
                           out long aP1_ClienteId )
      {
         this.AV9EmpresaId = aP0_EmpresaId;
         this.AV8ClienteId = 0 ;
         initialize();
         ExecuteImpl();
         aP1_ClienteId=this.AV8ClienteId;
      }

      public long executeUdp( long aP0_EmpresaId )
      {
         execute(aP0_EmpresaId, out aP1_ClienteId);
         return AV8ClienteId ;
      }

      public void executeSubmit( long aP0_EmpresaId ,
                                 out long aP1_ClienteId )
      {
         this.AV9EmpresaId = aP0_EmpresaId;
         this.AV8ClienteId = 0 ;
         SubmitImpl();
         aP1_ClienteId=this.AV8ClienteId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8ClienteId = 1;
         /* Using cursor P000J2 */
         pr_default.execute(0, new Object[] {AV9EmpresaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1EmpresaId = P000J2_A1EmpresaId[0];
            A5ClienteId = P000J2_A5ClienteId[0];
            AV8ClienteId = (long)(A5ClienteId+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P000J2_A1EmpresaId = new long[1] ;
         P000J2_A5ClienteId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pseqcliente__default(),
            new Object[][] {
                new Object[] {
               P000J2_A1EmpresaId, P000J2_A5ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9EmpresaId ;
      private long AV8ClienteId ;
      private long A1EmpresaId ;
      private long A5ClienteId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P000J2_A1EmpresaId ;
      private long[] P000J2_A5ClienteId ;
      private long aP1_ClienteId ;
   }

   public class pseqcliente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000J2;
          prmP000J2 = new Object[] {
          new ParDef("@AV9EmpresaId",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000J2", "SELECT TOP 1 [EmpresaId], [ClienteId] FROM [TCliente] WHERE [EmpresaId] = @AV9EmpresaId ORDER BY [EmpresaId], [ClienteId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000J2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
