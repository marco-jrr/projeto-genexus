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
   public class psequsuario : GXProcedure
   {
      public psequsuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public psequsuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmpresaId ,
                           out long aP1_UsuarioId )
      {
         this.AV8EmpresaId = aP0_EmpresaId;
         this.AV9UsuarioId = 0 ;
         initialize();
         ExecuteImpl();
         aP1_UsuarioId=this.AV9UsuarioId;
      }

      public long executeUdp( long aP0_EmpresaId )
      {
         execute(aP0_EmpresaId, out aP1_UsuarioId);
         return AV9UsuarioId ;
      }

      public void executeSubmit( long aP0_EmpresaId ,
                                 out long aP1_UsuarioId )
      {
         this.AV8EmpresaId = aP0_EmpresaId;
         this.AV9UsuarioId = 0 ;
         SubmitImpl();
         aP1_UsuarioId=this.AV9UsuarioId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9UsuarioId = 1;
         /* Using cursor P000M2 */
         pr_default.execute(0, new Object[] {AV8EmpresaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1EmpresaId = P000M2_A1EmpresaId[0];
            A20UsuarioId = P000M2_A20UsuarioId[0];
            AV9UsuarioId = (long)(A20UsuarioId+1);
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
         P000M2_A1EmpresaId = new long[1] ;
         P000M2_A20UsuarioId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.psequsuario__default(),
            new Object[][] {
                new Object[] {
               P000M2_A1EmpresaId, P000M2_A20UsuarioId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8EmpresaId ;
      private long AV9UsuarioId ;
      private long A1EmpresaId ;
      private long A20UsuarioId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P000M2_A1EmpresaId ;
      private long[] P000M2_A20UsuarioId ;
      private long aP1_UsuarioId ;
   }

   public class psequsuario__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000M2;
          prmP000M2 = new Object[] {
          new ParDef("@AV8EmpresaId",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000M2", "SELECT TOP 1 [EmpresaId], [UsuarioId] FROM [TUsuario] WHERE [EmpresaId] = @AV8EmpresaId ORDER BY [EmpresaId], [UsuarioId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000M2,1, GxCacheFrequency.OFF ,false,true )
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
