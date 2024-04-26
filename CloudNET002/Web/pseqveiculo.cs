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
   public class pseqveiculo : GXProcedure
   {
      public pseqveiculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public pseqveiculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmpresaId ,
                           out long aP1_VeiculoId )
      {
         this.AV8EmpresaId = aP0_EmpresaId;
         this.AV9VeiculoId = 0 ;
         initialize();
         ExecuteImpl();
         aP1_VeiculoId=this.AV9VeiculoId;
      }

      public long executeUdp( long aP0_EmpresaId )
      {
         execute(aP0_EmpresaId, out aP1_VeiculoId);
         return AV9VeiculoId ;
      }

      public void executeSubmit( long aP0_EmpresaId ,
                                 out long aP1_VeiculoId )
      {
         this.AV8EmpresaId = aP0_EmpresaId;
         this.AV9VeiculoId = 0 ;
         SubmitImpl();
         aP1_VeiculoId=this.AV9VeiculoId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9VeiculoId = 1;
         /* Using cursor P000K2 */
         pr_default.execute(0, new Object[] {AV8EmpresaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1EmpresaId = P000K2_A1EmpresaId[0];
            A10VeiculoId = P000K2_A10VeiculoId[0];
            AV9VeiculoId = (long)(A10VeiculoId+1);
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
         P000K2_A1EmpresaId = new long[1] ;
         P000K2_A10VeiculoId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pseqveiculo__default(),
            new Object[][] {
                new Object[] {
               P000K2_A1EmpresaId, P000K2_A10VeiculoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8EmpresaId ;
      private long AV9VeiculoId ;
      private long A1EmpresaId ;
      private long A10VeiculoId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P000K2_A1EmpresaId ;
      private long[] P000K2_A10VeiculoId ;
      private long aP1_VeiculoId ;
   }

   public class pseqveiculo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000K2;
          prmP000K2 = new Object[] {
          new ParDef("@AV8EmpresaId",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000K2", "SELECT TOP 1 [EmpresaId], [VeiculoId] FROM [TVeiculo] WHERE [EmpresaId] = @AV8EmpresaId ORDER BY [EmpresaId], [VeiculoId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000K2,1, GxCacheFrequency.OFF ,false,true )
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
