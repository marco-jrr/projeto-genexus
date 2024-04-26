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
   public class tregistropedidoconversion : GXProcedure
   {
      public tregistropedidoconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", false);
      }

      public tregistropedidoconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor TREGISTROP2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A17Destino = TREGISTROP2_A17Destino[0];
            A5ClienteId = TREGISTROP2_A5ClienteId[0];
            A10VeiculoId = TREGISTROP2_A10VeiculoId[0];
            A16RegistroPedidoId = TREGISTROP2_A16RegistroPedidoId[0];
            A1EmpresaId = TREGISTROP2_A1EmpresaId[0];
            A18DataHoraRetirada = TREGISTROP2_A18DataHoraRetirada[0];
            A19DataHoraRetorno = TREGISTROP2_A19DataHoraRetorno[0];
            n19DataHoraRetorno = TREGISTROP2_n19DataHoraRetorno[0];
            A40001GXC2 = DateTimeUtil.ResetTime( A19DataHoraRetorno);
            A40000GXC1 = DateTimeUtil.ResetTime( A18DataHoraRetirada);
            /*
               INSERT RECORD ON TABLE GXA0004

            */
            AV2EmpresaId = A1EmpresaId;
            AV3RegistroPedidoId = A16RegistroPedidoId;
            AV4VeiculoId = A10VeiculoId;
            AV5ClienteId = A5ClienteId;
            AV6Destino = A17Destino;
            AV7DataHoraRetirada = A40000GXC1;
            if ( TREGISTROP2_n19DataHoraRetorno[0] )
            {
               AV8DataHoraRetorno = DateTime.MinValue;
               nV8DataHoraRetorno = false;
               nV8DataHoraRetorno = true;
            }
            else
            {
               AV8DataHoraRetorno = A40001GXC2;
               nV8DataHoraRetorno = false;
            }
            /* Using cursor TREGISTROP3 */
            pr_default.execute(1, new Object[] {AV2EmpresaId, AV3RegistroPedidoId, AV4VeiculoId, AV5ClienteId, AV6Destino, AV7DataHoraRetirada, nV8DataHoraRetorno, AV8DataHoraRetorno});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0004");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         TREGISTROP2_A17Destino = new string[] {""} ;
         TREGISTROP2_A5ClienteId = new long[1] ;
         TREGISTROP2_A10VeiculoId = new long[1] ;
         TREGISTROP2_A16RegistroPedidoId = new long[1] ;
         TREGISTROP2_A1EmpresaId = new long[1] ;
         TREGISTROP2_A18DataHoraRetirada = new DateTime[] {DateTime.MinValue} ;
         TREGISTROP2_A19DataHoraRetorno = new DateTime[] {DateTime.MinValue} ;
         TREGISTROP2_n19DataHoraRetorno = new bool[] {false} ;
         A17Destino = "";
         A18DataHoraRetirada = (DateTime)(DateTime.MinValue);
         A19DataHoraRetorno = (DateTime)(DateTime.MinValue);
         A40001GXC2 = DateTime.MinValue;
         A40000GXC1 = DateTime.MinValue;
         AV6Destino = "";
         AV7DataHoraRetirada = DateTime.MinValue;
         AV8DataHoraRetorno = DateTime.MinValue;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tregistropedidoconversion__default(),
            new Object[][] {
                new Object[] {
               TREGISTROP2_A17Destino, TREGISTROP2_A5ClienteId, TREGISTROP2_A10VeiculoId, TREGISTROP2_A16RegistroPedidoId, TREGISTROP2_A1EmpresaId, TREGISTROP2_A18DataHoraRetirada, TREGISTROP2_A19DataHoraRetorno, TREGISTROP2_n19DataHoraRetorno
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GIGXA0004 ;
      private long A5ClienteId ;
      private long A10VeiculoId ;
      private long A16RegistroPedidoId ;
      private long A1EmpresaId ;
      private long AV2EmpresaId ;
      private long AV3RegistroPedidoId ;
      private long AV4VeiculoId ;
      private long AV5ClienteId ;
      private string A17Destino ;
      private string AV6Destino ;
      private string Gx_emsg ;
      private DateTime A18DataHoraRetirada ;
      private DateTime A19DataHoraRetorno ;
      private DateTime A40001GXC2 ;
      private DateTime A40000GXC1 ;
      private DateTime AV7DataHoraRetirada ;
      private DateTime AV8DataHoraRetorno ;
      private bool n19DataHoraRetorno ;
      private bool nV8DataHoraRetorno ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TREGISTROP2_A17Destino ;
      private long[] TREGISTROP2_A5ClienteId ;
      private long[] TREGISTROP2_A10VeiculoId ;
      private long[] TREGISTROP2_A16RegistroPedidoId ;
      private long[] TREGISTROP2_A1EmpresaId ;
      private DateTime[] TREGISTROP2_A18DataHoraRetirada ;
      private DateTime[] TREGISTROP2_A19DataHoraRetorno ;
      private bool[] TREGISTROP2_n19DataHoraRetorno ;
   }

   public class tregistropedidoconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTREGISTROP2;
          prmTREGISTROP2 = new Object[] {
          };
          Object[] prmTREGISTROP3;
          prmTREGISTROP3 = new Object[] {
          new ParDef("@AV2EmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@AV3RegistroPedidoId",GXType.Decimal,12,0) ,
          new ParDef("@AV4VeiculoId",GXType.Decimal,12,0) ,
          new ParDef("@AV5ClienteId",GXType.Decimal,12,0) ,
          new ParDef("@AV6Destino",GXType.Char,20,0) ,
          new ParDef("@AV7DataHoraRetirada",GXType.Date,8,0) ,
          new ParDef("@AV8DataHoraRetorno",GXType.Date,8,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TREGISTROP2", "SELECT [Destino], [ClienteId], [VeiculoId], [RegistroPedidoId], [EmpresaId], [DataHoraRetirada], [DataHoraRetorno] FROM [TRegistroPedido] ORDER BY [EmpresaId], [RegistroPedidoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTREGISTROP2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TREGISTROP3", "INSERT INTO [GXA0004]([EmpresaId], [RegistroPedidoId], [VeiculoId], [ClienteId], [Destino], [DataHoraRetirada], [DataHoraRetorno]) VALUES(@AV2EmpresaId, @AV3RegistroPedidoId, @AV4VeiculoId, @AV5ClienteId, @AV6Destino, @AV7DataHoraRetirada, @AV8DataHoraRetorno)", GxErrorMask.GX_NOMASK,prmTREGISTROP3)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
