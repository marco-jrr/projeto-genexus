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
   public class pcadastrausuario : GXProcedure
   {
      public pcadastrausuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public pcadastrausuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmpresaId ,
                           string aP1_UsuarioNome ,
                           string aP2_UsuarioEmail ,
                           string aP3_UsuarioSenha )
      {
         this.AV8EmpresaId = aP0_EmpresaId;
         this.AV9UsuarioNome = aP1_UsuarioNome;
         this.AV10UsuarioEmail = aP2_UsuarioEmail;
         this.AV11UsuarioSenha = aP3_UsuarioSenha;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( long aP0_EmpresaId ,
                                 string aP1_UsuarioNome ,
                                 string aP2_UsuarioEmail ,
                                 string aP3_UsuarioSenha )
      {
         this.AV8EmpresaId = aP0_EmpresaId;
         this.AV9UsuarioNome = aP1_UsuarioNome;
         this.AV10UsuarioEmail = aP2_UsuarioEmail;
         this.AV11UsuarioSenha = aP3_UsuarioSenha;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /*
            INSERT RECORD ON TABLE TUsuario

         */
         A1EmpresaId = AV8EmpresaId;
         GXt_int1 = A20UsuarioId;
         new psequsuario(context ).execute(  AV8EmpresaId, out  GXt_int1) ;
         A20UsuarioId = GXt_int1;
         A21UsuarioNome = AV9UsuarioNome;
         A22UsuarioEmail = AV10UsuarioEmail;
         A23UsuarioSenha = AV11UsuarioSenha;
         /* Using cursor P000N2 */
         pr_default.execute(0, new Object[] {A1EmpresaId, A20UsuarioId, A21UsuarioNome, A22UsuarioEmail, A23UsuarioSenha});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("TUsuario");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
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
         A21UsuarioNome = "";
         A22UsuarioEmail = "";
         A23UsuarioSenha = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcadastrausuario__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS5 ;
      private long AV8EmpresaId ;
      private long A1EmpresaId ;
      private long A20UsuarioId ;
      private long GXt_int1 ;
      private string AV11UsuarioSenha ;
      private string A23UsuarioSenha ;
      private string Gx_emsg ;
      private string AV9UsuarioNome ;
      private string AV10UsuarioEmail ;
      private string A21UsuarioNome ;
      private string A22UsuarioEmail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class pcadastrausuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000N2;
          prmP000N2 = new Object[] {
          new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@UsuarioId",GXType.Decimal,12,0) ,
          new ParDef("@UsuarioNome",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioSenha",GXType.NChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000N2", "INSERT INTO [TUsuario]([EmpresaId], [UsuarioId], [UsuarioNome], [UsuarioEmail], [UsuarioSenha]) VALUES(@EmpresaId, @UsuarioId, @UsuarioNome, @UsuarioEmail, @UsuarioSenha)", GxErrorMask.GX_NOMASK,prmP000N2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
