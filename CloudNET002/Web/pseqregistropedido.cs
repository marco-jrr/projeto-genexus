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
   public class pseqregistropedido : GXProcedure
   {
      public pseqregistropedido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public pseqregistropedido( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmpresaId ,
                           out long aP1_RegistroPedidoId )
      {
         this.AV8EmpresaId = aP0_EmpresaId;
         this.AV9RegistroPedidoId = 0 ;
         initialize();
         ExecuteImpl();
         aP1_RegistroPedidoId=this.AV9RegistroPedidoId;
      }

      public long executeUdp( long aP0_EmpresaId )
      {
         execute(aP0_EmpresaId, out aP1_RegistroPedidoId);
         return AV9RegistroPedidoId ;
      }

      public void executeSubmit( long aP0_EmpresaId ,
                                 out long aP1_RegistroPedidoId )
      {
         this.AV8EmpresaId = aP0_EmpresaId;
         this.AV9RegistroPedidoId = 0 ;
         SubmitImpl();
         aP1_RegistroPedidoId=this.AV9RegistroPedidoId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9RegistroPedidoId = 1;
         /* Using cursor P000L2 */
         pr_default.execute(0, new Object[] {AV8EmpresaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1EmpresaId = P000L2_A1EmpresaId[0];
            A16RegistroPedidoId = P000L2_A16RegistroPedidoId[0];
            AV9RegistroPedidoId = (long)(A16RegistroPedidoId+1);
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
         P000L2_A1EmpresaId = new long[1] ;
         P000L2_A16RegistroPedidoId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pseqregistropedido__default(),
            new Object[][] {
                new Object[] {
               P000L2_A1EmpresaId, P000L2_A16RegistroPedidoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8EmpresaId ;
      private long AV9RegistroPedidoId ;
      private long A1EmpresaId ;
      private long A16RegistroPedidoId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P000L2_A1EmpresaId ;
      private long[] P000L2_A16RegistroPedidoId ;
      private long aP1_RegistroPedidoId ;
   }

   public class pseqregistropedido__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000L2;
          prmP000L2 = new Object[] {
          new ParDef("@AV8EmpresaId",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000L2", "SELECT TOP 1 [EmpresaId], [RegistroPedidoId] FROM [TRegistroPedido] WHERE [EmpresaId] = @AV8EmpresaId ORDER BY [EmpresaId], [RegistroPedidoId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000L2,1, GxCacheFrequency.OFF ,false,true )
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
