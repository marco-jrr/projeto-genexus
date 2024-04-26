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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class tusuario : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"USUARIOID") == 0 )
         {
            AV8UsuarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "UsuarioId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8UsuarioId", StringUtil.LTrimStr( (decimal)(AV8UsuarioId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuarioId), "ZZZZZZZZZZZ9"), context));
            AV7EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EmpresaId", StringUtil.LTrimStr( (decimal)(AV7EmpresaId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vEMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpresaId), "ZZZZZZZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASAUSUARIOID055( AV8UsuarioId, AV7EmpresaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A1EmpresaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7EmpresaId", StringUtil.LTrimStr( (decimal)(AV7EmpresaId), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vEMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpresaId), "ZZZZZZZZZZZ9"), context));
               AV8UsuarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "UsuarioId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8UsuarioId", StringUtil.LTrimStr( (decimal)(AV8UsuarioId), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuarioId), "ZZZZZZZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_9-182098", 0) ;
            }
         }
         Form.Meta.addItem("description", "Usuários", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ProjetoFrotas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public tusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_EmpresaId ,
                           long aP2_UsuarioId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmpresaId = aP1_EmpresaId;
         this.AV8UsuarioId = aP2_UsuarioId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "tusuario_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Usuários", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"USUARIOID"+"'), id:'"+"USUARIOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtEmpresaId_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpresaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpresaId_Internalname, "Empresa Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpresaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmpresaId_Visible, edtEmpresaId_Enabled, 1, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdAuto", "end", false, "", "HLP_TUsuario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpresaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmpresaNome_Internalname, "Empresa:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEmpresaNome_Internalname, A2EmpresaNome, StringUtil.RTrim( context.localUtil.Format( A2EmpresaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpresaNome_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioId_Internalname, "Id:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20UsuarioId), 12, 0, ".", "")), StringUtil.LTrim( ((edtUsuarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A20UsuarioId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A20UsuarioId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdManual", "end", false, "", "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNome_Internalname, "Nome:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNome_Internalname, A21UsuarioNome, StringUtil.RTrim( context.localUtil.Format( A21UsuarioNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioEmail_Internalname, "E-mail:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioEmail_Internalname, A22UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( A22UsuarioEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A22UsuarioEmail, "", "", "", edtUsuarioEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioSenha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSenha_Internalname, "Senha:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSenha_Internalname, StringUtil.RTrim( A23UsuarioSenha), StringUtil.RTrim( context.localUtil.Format( A23UsuarioSenha, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSenha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioSenha_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EmpresaId"), ".", ","), 18, MidpointRounding.ToEven));
               Z20UsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z20UsuarioId"), ".", ","), 18, MidpointRounding.ToEven));
               Z21UsuarioNome = cgiGet( "Z21UsuarioNome");
               Z22UsuarioEmail = cgiGet( "Z22UsuarioEmail");
               Z23UsuarioSenha = cgiGet( "Z23UsuarioSenha");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPRESAID"), ".", ","), 18, MidpointRounding.ToEven));
               AV8UsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vUSUARIOID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESAID");
                  AnyError = 1;
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1EmpresaId = 0;
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               }
               else
               {
                  A1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               }
               A2EmpresaNome = cgiGet( edtEmpresaNome_Internalname);
               AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
               A20UsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
               A21UsuarioNome = cgiGet( edtUsuarioNome_Internalname);
               AssignAttri("", false, "A21UsuarioNome", A21UsuarioNome);
               A22UsuarioEmail = cgiGet( edtUsuarioEmail_Internalname);
               AssignAttri("", false, "A22UsuarioEmail", A22UsuarioEmail);
               A23UsuarioSenha = cgiGet( edtUsuarioSenha_Internalname);
               AssignAttri("", false, "A23UsuarioSenha", A23UsuarioSenha);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TUsuario");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1EmpresaId != Z1EmpresaId ) || ( A20UsuarioId != Z20UsuarioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tusuario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
                  A20UsuarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "UsuarioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "EMPRESAID");
                        AnyError = 1;
                        GX_FocusControl = edtEmpresaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes055( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         edtEmpresaId_Visible = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Visible), 5, 0), true);
      }

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwtusuario.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z21UsuarioNome = T00053_A21UsuarioNome[0];
               Z22UsuarioEmail = T00053_A22UsuarioEmail[0];
               Z23UsuarioSenha = T00053_A23UsuarioSenha[0];
            }
            else
            {
               Z21UsuarioNome = A21UsuarioNome;
               Z22UsuarioEmail = A22UsuarioEmail;
               Z23UsuarioSenha = A23UsuarioSenha;
            }
         }
         if ( GX_JID == -8 )
         {
            Z20UsuarioId = A20UsuarioId;
            Z21UsuarioNome = A21UsuarioNome;
            Z22UsuarioEmail = A22UsuarioEmail;
            Z23UsuarioSenha = A23UsuarioSenha;
            Z1EmpresaId = A1EmpresaId;
            Z2EmpresaNome = A2EmpresaNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtUsuarioId_Enabled = 0;
         AssignProp("", false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtUsuarioId_Enabled = 0;
         AssignProp("", false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EmpresaId) )
         {
            A1EmpresaId = AV7EmpresaId;
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         }
         if ( ! (0==AV7EmpresaId) )
         {
            edtEmpresaId_Enabled = 0;
            AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         }
         else
         {
            edtEmpresaId_Enabled = 1;
            AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7EmpresaId) )
         {
            edtEmpresaId_Enabled = 0;
            AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8UsuarioId) )
         {
            A20UsuarioId = AV8UsuarioId;
            AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
         }
         else
         {
            if ( (0==AV8UsuarioId) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               GXt_int1 = A20UsuarioId;
               new psequsuario(context ).execute(  AV7EmpresaId, out  GXt_int1) ;
               A20UsuarioId = GXt_int1;
               AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
            }
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A1EmpresaId});
            A2EmpresaNome = T00054_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(2);
            AV12Pgmname = "TUsuario";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A1EmpresaId, A20UsuarioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A21UsuarioNome = T00055_A21UsuarioNome[0];
            AssignAttri("", false, "A21UsuarioNome", A21UsuarioNome);
            A22UsuarioEmail = T00055_A22UsuarioEmail[0];
            AssignAttri("", false, "A22UsuarioEmail", A22UsuarioEmail);
            A23UsuarioSenha = T00055_A23UsuarioSenha[0];
            AssignAttri("", false, "A23UsuarioSenha", A23UsuarioSenha);
            A2EmpresaNome = T00055_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            ZM055( -8) ;
         }
         pr_default.close(3);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         AV12Pgmname = "TUsuario";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable055( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV12Pgmname = "TUsuario";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T00054_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A22UsuarioEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Usuario Email does not match the specified pattern", "OutOfRange", 1, "USUARIOEMAIL");
            AnyError = 1;
            GX_FocusControl = edtUsuarioEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A1EmpresaId )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T00056_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2EmpresaNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey055( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A1EmpresaId, A20UsuarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A1EmpresaId, A20UsuarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 8) ;
            RcdFound5 = 1;
            A20UsuarioId = T00053_A20UsuarioId[0];
            AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
            A21UsuarioNome = T00053_A21UsuarioNome[0];
            AssignAttri("", false, "A21UsuarioNome", A21UsuarioNome);
            A22UsuarioEmail = T00053_A22UsuarioEmail[0];
            AssignAttri("", false, "A22UsuarioEmail", A22UsuarioEmail);
            A23UsuarioSenha = T00053_A23UsuarioSenha[0];
            AssignAttri("", false, "A23UsuarioSenha", A23UsuarioSenha);
            A1EmpresaId = T00053_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            Z1EmpresaId = A1EmpresaId;
            Z20UsuarioId = A20UsuarioId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A1EmpresaId, A20UsuarioId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00058_A1EmpresaId[0] < A1EmpresaId ) || ( T00058_A1EmpresaId[0] == A1EmpresaId ) && ( T00058_A20UsuarioId[0] < A20UsuarioId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00058_A1EmpresaId[0] > A1EmpresaId ) || ( T00058_A1EmpresaId[0] == A1EmpresaId ) && ( T00058_A20UsuarioId[0] > A20UsuarioId ) ) )
            {
               A1EmpresaId = T00058_A1EmpresaId[0];
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A20UsuarioId = T00058_A20UsuarioId[0];
               AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A1EmpresaId, A20UsuarioId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00059_A1EmpresaId[0] > A1EmpresaId ) || ( T00059_A1EmpresaId[0] == A1EmpresaId ) && ( T00059_A20UsuarioId[0] > A20UsuarioId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00059_A1EmpresaId[0] < A1EmpresaId ) || ( T00059_A1EmpresaId[0] == A1EmpresaId ) && ( T00059_A20UsuarioId[0] < A20UsuarioId ) ) )
            {
               A1EmpresaId = T00059_A1EmpresaId[0];
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A20UsuarioId = T00059_A20UsuarioId[0];
               AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( ( A1EmpresaId != Z1EmpresaId ) || ( A20UsuarioId != Z20UsuarioId ) )
               {
                  A1EmpresaId = Z1EmpresaId;
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
                  A20UsuarioId = Z20UsuarioId;
                  AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPRESAID");
                  AnyError = 1;
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A1EmpresaId != Z1EmpresaId ) || ( A20UsuarioId != Z20UsuarioId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "EMPRESAID");
                     AnyError = 1;
                     GX_FocusControl = edtEmpresaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEmpresaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( A1EmpresaId != Z1EmpresaId ) || ( A20UsuarioId != Z20UsuarioId ) )
         {
            A1EmpresaId = Z1EmpresaId;
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A20UsuarioId = Z20UsuarioId;
            AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A1EmpresaId, A20UsuarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TUsuario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z21UsuarioNome, T00052_A21UsuarioNome[0]) != 0 ) || ( StringUtil.StrCmp(Z22UsuarioEmail, T00052_A22UsuarioEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z23UsuarioSenha, T00052_A23UsuarioSenha[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z21UsuarioNome, T00052_A21UsuarioNome[0]) != 0 )
               {
                  GXUtil.WriteLog("tusuario:[seudo value changed for attri]"+"UsuarioNome");
                  GXUtil.WriteLogRaw("Old: ",Z21UsuarioNome);
                  GXUtil.WriteLogRaw("Current: ",T00052_A21UsuarioNome[0]);
               }
               if ( StringUtil.StrCmp(Z22UsuarioEmail, T00052_A22UsuarioEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("tusuario:[seudo value changed for attri]"+"UsuarioEmail");
                  GXUtil.WriteLogRaw("Old: ",Z22UsuarioEmail);
                  GXUtil.WriteLogRaw("Current: ",T00052_A22UsuarioEmail[0]);
               }
               if ( StringUtil.StrCmp(Z23UsuarioSenha, T00052_A23UsuarioSenha[0]) != 0 )
               {
                  GXUtil.WriteLog("tusuario:[seudo value changed for attri]"+"UsuarioSenha");
                  GXUtil.WriteLogRaw("Old: ",Z23UsuarioSenha);
                  GXUtil.WriteLogRaw("Current: ",T00052_A23UsuarioSenha[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TUsuario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         if ( ! IsAuthorized("tusuario_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000510 */
                     pr_default.execute(8, new Object[] {A20UsuarioId, A21UsuarioNome, A22UsuarioEmail, A23UsuarioSenha, A1EmpresaId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("TUsuario");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         if ( ! IsAuthorized("tusuario_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000511 */
                     pr_default.execute(9, new Object[] {A21UsuarioNome, A22UsuarioEmail, A23UsuarioSenha, A1EmpresaId, A20UsuarioId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("TUsuario");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TUsuario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("tusuario_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000512 */
                  pr_default.execute(10, new Object[] {A1EmpresaId, A20UsuarioId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("TUsuario");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "TUsuario";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
            /* Using cursor T000513 */
            pr_default.execute(11, new Object[] {A1EmpresaId});
            A2EmpresaNome = T000513_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(11);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("tusuario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("tusuario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Scan By routine */
         /* Using cursor T000514 */
         pr_default.execute(12);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
            A1EmpresaId = T000514_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A20UsuarioId = T000514_A20UsuarioId[0];
            AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound5 = 1;
            A1EmpresaId = T000514_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A20UsuarioId = T000514_A20UsuarioId[0];
            AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtUsuarioId_Enabled = 0;
         AssignProp("", false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioNome_Enabled = 0;
         AssignProp("", false, edtUsuarioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNome_Enabled), 5, 0), true);
         edtUsuarioEmail_Enabled = 0;
         AssignProp("", false, edtUsuarioEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioEmail_Enabled), 5, 0), true);
         edtUsuarioSenha_Enabled = 0;
         AssignProp("", false, edtUsuarioSenha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSenha_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1638560), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1638560), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1638560), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV8UsuarioId,12,0))}, new string[] {"Gx_mode","EmpresaId","UsuarioId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"TUsuario");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tusuario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z20UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20UsuarioId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z21UsuarioNome", Z21UsuarioNome);
         GxWebStd.gx_hidden_field( context, "Z22UsuarioEmail", Z22UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "Z23UsuarioSenha", StringUtil.RTrim( Z23UsuarioSenha));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vEMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpresaId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8UsuarioId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8UsuarioId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("tusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV8UsuarioId,12,0))}, new string[] {"Gx_mode","EmpresaId","UsuarioId"})  ;
      }

      public override string GetPgmname( )
      {
         return "TUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuários" ;
      }

      protected void InitializeNonKey055( )
      {
         A21UsuarioNome = "";
         AssignAttri("", false, "A21UsuarioNome", A21UsuarioNome);
         A22UsuarioEmail = "";
         AssignAttri("", false, "A22UsuarioEmail", A22UsuarioEmail);
         A23UsuarioSenha = "";
         AssignAttri("", false, "A23UsuarioSenha", A23UsuarioSenha);
         A2EmpresaNome = "";
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         Z21UsuarioNome = "";
         Z22UsuarioEmail = "";
         Z23UsuarioSenha = "";
      }

      protected void InitAll055( )
      {
         A1EmpresaId = 0;
         AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         A20UsuarioId = 0;
         AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20244261714953", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("tusuario.js", "?20244261714953", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtEmpresaId_Internalname = "EMPRESAID";
         edtEmpresaNome_Internalname = "EMPRESANOME";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNome_Internalname = "USUARIONOME";
         edtUsuarioEmail_Internalname = "USUARIOEMAIL";
         edtUsuarioSenha_Internalname = "USUARIOSENHA";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ProjetoFrotas", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Usuários";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtUsuarioSenha_Jsonclick = "";
         edtUsuarioSenha_Enabled = 1;
         edtUsuarioEmail_Jsonclick = "";
         edtUsuarioEmail_Enabled = 1;
         edtUsuarioNome_Jsonclick = "";
         edtUsuarioNome_Enabled = 1;
         edtUsuarioId_Jsonclick = "";
         edtUsuarioId_Enabled = 0;
         edtEmpresaNome_Jsonclick = "";
         edtEmpresaNome_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtEmpresaId_Jsonclick = "";
         edtEmpresaId_Enabled = 1;
         edtEmpresaId_Visible = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX4ASAUSUARIOID055( long AV8UsuarioId ,
                                         long AV7EmpresaId )
      {
         if ( ! (0==AV8UsuarioId) )
         {
            A20UsuarioId = AV8UsuarioId;
            AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
         }
         else
         {
            if ( (0==AV8UsuarioId) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               GXt_int1 = A20UsuarioId;
               new psequsuario(context ).execute(  AV7EmpresaId, out  GXt_int1) ;
               A20UsuarioId = GXt_int1;
               AssignAttri("", false, "A20UsuarioId", StringUtil.LTrimStr( (decimal)(A20UsuarioId), 12, 0));
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20UsuarioId), 12, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Empresaid( )
      {
         /* Using cursor T000513 */
         pr_default.execute(11, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
         }
         A2EmpresaNome = T000513_A2EmpresaNome[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV8UsuarioId","fld":"vUSUARIOID","pic":"ZZZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV8UsuarioId","fld":"vUSUARIOID","pic":"ZZZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12052","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_EMPRESAID","""{"handler":"Valid_Empresaid","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A2EmpresaNome","fld":"EMPRESANOME"}]""");
         setEventMetadata("VALID_EMPRESAID",""","oparms":[{"av":"A2EmpresaNome","fld":"EMPRESANOME"}]}""");
         setEventMetadata("VALID_USUARIOID","""{"handler":"Valid_Usuarioid","iparms":[]}""");
         setEventMetadata("VALID_USUARIOEMAIL","""{"handler":"Valid_Usuarioemail","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z21UsuarioNome = "";
         Z22UsuarioEmail = "";
         Z23UsuarioSenha = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         imgprompt_1_gximage = "";
         sImgUrl = "";
         A2EmpresaNome = "";
         A21UsuarioNome = "";
         A22UsuarioEmail = "";
         A23UsuarioSenha = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z2EmpresaNome = "";
         T00054_A2EmpresaNome = new string[] {""} ;
         T00055_A20UsuarioId = new long[1] ;
         T00055_A21UsuarioNome = new string[] {""} ;
         T00055_A22UsuarioEmail = new string[] {""} ;
         T00055_A23UsuarioSenha = new string[] {""} ;
         T00055_A2EmpresaNome = new string[] {""} ;
         T00055_A1EmpresaId = new long[1] ;
         T00056_A2EmpresaNome = new string[] {""} ;
         T00057_A1EmpresaId = new long[1] ;
         T00057_A20UsuarioId = new long[1] ;
         T00053_A20UsuarioId = new long[1] ;
         T00053_A21UsuarioNome = new string[] {""} ;
         T00053_A22UsuarioEmail = new string[] {""} ;
         T00053_A23UsuarioSenha = new string[] {""} ;
         T00053_A1EmpresaId = new long[1] ;
         T00058_A1EmpresaId = new long[1] ;
         T00058_A20UsuarioId = new long[1] ;
         T00059_A1EmpresaId = new long[1] ;
         T00059_A20UsuarioId = new long[1] ;
         T00052_A20UsuarioId = new long[1] ;
         T00052_A21UsuarioNome = new string[] {""} ;
         T00052_A22UsuarioEmail = new string[] {""} ;
         T00052_A23UsuarioSenha = new string[] {""} ;
         T00052_A1EmpresaId = new long[1] ;
         T000513_A2EmpresaNome = new string[] {""} ;
         T000514_A1EmpresaId = new long[1] ;
         T000514_A20UsuarioId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tusuario__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tusuario__default(),
            new Object[][] {
                new Object[] {
               T00052_A20UsuarioId, T00052_A21UsuarioNome, T00052_A22UsuarioEmail, T00052_A23UsuarioSenha, T00052_A1EmpresaId
               }
               , new Object[] {
               T00053_A20UsuarioId, T00053_A21UsuarioNome, T00053_A22UsuarioEmail, T00053_A23UsuarioSenha, T00053_A1EmpresaId
               }
               , new Object[] {
               T00054_A2EmpresaNome
               }
               , new Object[] {
               T00055_A20UsuarioId, T00055_A21UsuarioNome, T00055_A22UsuarioEmail, T00055_A23UsuarioSenha, T00055_A2EmpresaNome, T00055_A1EmpresaId
               }
               , new Object[] {
               T00056_A2EmpresaNome
               }
               , new Object[] {
               T00057_A1EmpresaId, T00057_A20UsuarioId
               }
               , new Object[] {
               T00058_A1EmpresaId, T00058_A20UsuarioId
               }
               , new Object[] {
               T00059_A1EmpresaId, T00059_A20UsuarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000513_A2EmpresaNome
               }
               , new Object[] {
               T000514_A1EmpresaId, T000514_A20UsuarioId
               }
            }
         );
         AV12Pgmname = "TUsuario";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound5 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEmpresaId_Visible ;
      private int edtEmpresaId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtEmpresaNome_Enabled ;
      private int edtUsuarioId_Enabled ;
      private int edtUsuarioNome_Enabled ;
      private int edtUsuarioEmail_Enabled ;
      private int edtUsuarioSenha_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long wcpOAV7EmpresaId ;
      private long wcpOAV8UsuarioId ;
      private long Z1EmpresaId ;
      private long Z20UsuarioId ;
      private long AV8UsuarioId ;
      private long AV7EmpresaId ;
      private long A1EmpresaId ;
      private long A20UsuarioId ;
      private long GXt_int1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z23UsuarioSenha ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmpresaId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtEmpresaId_Jsonclick ;
      private string imgprompt_1_gximage ;
      private string sImgUrl ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtEmpresaNome_Internalname ;
      private string edtEmpresaNome_Jsonclick ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNome_Internalname ;
      private string edtUsuarioNome_Jsonclick ;
      private string edtUsuarioEmail_Internalname ;
      private string edtUsuarioEmail_Jsonclick ;
      private string edtUsuarioSenha_Internalname ;
      private string A23UsuarioSenha ;
      private string edtUsuarioSenha_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV12Pgmname ;
      private string hsh ;
      private string sMode5 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string Z21UsuarioNome ;
      private string Z22UsuarioEmail ;
      private string A2EmpresaNome ;
      private string A21UsuarioNome ;
      private string A22UsuarioEmail ;
      private string Z2EmpresaNome ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T00054_A2EmpresaNome ;
      private long[] T00055_A20UsuarioId ;
      private string[] T00055_A21UsuarioNome ;
      private string[] T00055_A22UsuarioEmail ;
      private string[] T00055_A23UsuarioSenha ;
      private string[] T00055_A2EmpresaNome ;
      private long[] T00055_A1EmpresaId ;
      private string[] T00056_A2EmpresaNome ;
      private long[] T00057_A1EmpresaId ;
      private long[] T00057_A20UsuarioId ;
      private long[] T00053_A20UsuarioId ;
      private string[] T00053_A21UsuarioNome ;
      private string[] T00053_A22UsuarioEmail ;
      private string[] T00053_A23UsuarioSenha ;
      private long[] T00053_A1EmpresaId ;
      private long[] T00058_A1EmpresaId ;
      private long[] T00058_A20UsuarioId ;
      private long[] T00059_A1EmpresaId ;
      private long[] T00059_A20UsuarioId ;
      private long[] T00052_A20UsuarioId ;
      private string[] T00052_A21UsuarioNome ;
      private string[] T00052_A22UsuarioEmail ;
      private string[] T00052_A23UsuarioSenha ;
      private long[] T00052_A1EmpresaId ;
      private string[] T000513_A2EmpresaNome ;
      private long[] T000514_A1EmpresaId ;
      private long[] T000514_A20UsuarioId ;
      private IDataStoreProvider pr_gam ;
   }

   public class tusuario__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class tusuario__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00052;
        prmT00052 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,12,0)
        };
        Object[] prmT00053;
        prmT00053 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,12,0)
        };
        Object[] prmT00054;
        prmT00054 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT00055;
        prmT00055 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,12,0)
        };
        Object[] prmT00056;
        prmT00056 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT00057;
        prmT00057 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,12,0)
        };
        Object[] prmT00058;
        prmT00058 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,12,0)
        };
        Object[] prmT00059;
        prmT00059 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,12,0)
        };
        Object[] prmT000510;
        prmT000510 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioNome",GXType.NVarChar,100,0) ,
        new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
        new ParDef("@UsuarioSenha",GXType.NChar,50,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000511;
        prmT000511 = new Object[] {
        new ParDef("@UsuarioNome",GXType.NVarChar,100,0) ,
        new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
        new ParDef("@UsuarioSenha",GXType.NChar,50,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,12,0)
        };
        Object[] prmT000512;
        prmT000512 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,12,0)
        };
        Object[] prmT000513;
        prmT000513 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000514;
        prmT000514 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00052", "SELECT [UsuarioId], [UsuarioNome], [UsuarioEmail], [UsuarioSenha], [EmpresaId] FROM [TUsuario] WITH (UPDLOCK) WHERE [EmpresaId] = @EmpresaId AND [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00053", "SELECT [UsuarioId], [UsuarioNome], [UsuarioEmail], [UsuarioSenha], [EmpresaId] FROM [TUsuario] WHERE [EmpresaId] = @EmpresaId AND [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00054", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00055", "SELECT TM1.[UsuarioId], TM1.[UsuarioNome], TM1.[UsuarioEmail], TM1.[UsuarioSenha], T2.[EmpresaNome], TM1.[EmpresaId] FROM ([TUsuario] TM1 INNER JOIN [TEmpresa] T2 ON T2.[EmpresaId] = TM1.[EmpresaId]) WHERE TM1.[EmpresaId] = @EmpresaId and TM1.[UsuarioId] = @UsuarioId ORDER BY TM1.[EmpresaId], TM1.[UsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00056", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00057", "SELECT [EmpresaId], [UsuarioId] FROM [TUsuario] WHERE [EmpresaId] = @EmpresaId AND [UsuarioId] = @UsuarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00058", "SELECT TOP 1 [EmpresaId], [UsuarioId] FROM [TUsuario] WHERE ( [EmpresaId] > @EmpresaId or [EmpresaId] = @EmpresaId and [UsuarioId] > @UsuarioId) ORDER BY [EmpresaId], [UsuarioId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00059", "SELECT TOP 1 [EmpresaId], [UsuarioId] FROM [TUsuario] WHERE ( [EmpresaId] < @EmpresaId or [EmpresaId] = @EmpresaId and [UsuarioId] < @UsuarioId) ORDER BY [EmpresaId] DESC, [UsuarioId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000510", "INSERT INTO [TUsuario]([UsuarioId], [UsuarioNome], [UsuarioEmail], [UsuarioSenha], [EmpresaId]) VALUES(@UsuarioId, @UsuarioNome, @UsuarioEmail, @UsuarioSenha, @EmpresaId)", GxErrorMask.GX_NOMASK,prmT000510)
           ,new CursorDef("T000511", "UPDATE [TUsuario] SET [UsuarioNome]=@UsuarioNome, [UsuarioEmail]=@UsuarioEmail, [UsuarioSenha]=@UsuarioSenha  WHERE [EmpresaId] = @EmpresaId AND [UsuarioId] = @UsuarioId", GxErrorMask.GX_NOMASK,prmT000511)
           ,new CursorDef("T000512", "DELETE FROM [TUsuario]  WHERE [EmpresaId] = @EmpresaId AND [UsuarioId] = @UsuarioId", GxErrorMask.GX_NOMASK,prmT000512)
           ,new CursorDef("T000513", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000514", "SELECT [EmpresaId], [UsuarioId] FROM [TUsuario] ORDER BY [EmpresaId], [UsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
