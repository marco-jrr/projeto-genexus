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
   public class tcliente : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"CLIENTEID") == 0 )
         {
            AV8ClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8ClienteId", StringUtil.LTrimStr( (decimal)(AV8ClienteId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8ClienteId), "ZZZZZZZZZZZ9"), context));
            AV7EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EmpresaId", StringUtil.LTrimStr( (decimal)(AV7EmpresaId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vEMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpresaId), "ZZZZZZZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASACLIENTEID022( AV8ClienteId, AV7EmpresaId) ;
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
               AV8ClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8ClienteId", StringUtil.LTrimStr( (decimal)(AV8ClienteId), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8ClienteId), "ZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Clientes", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("ProjetoFrotas", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tcliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public tcliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_EmpresaId ,
                           long aP2_ClienteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmpresaId = aP1_EmpresaId;
         this.AV8ClienteId = aP2_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynEmpresaId = new GXCombobox();
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
            return "tcliente_Execute" ;
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
         if ( dynEmpresaId.ItemCount > 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( dynEmpresaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEmpresaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0));
            AssignProp("", false, dynEmpresaId_Internalname, "Values", dynEmpresaId.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Clientes", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TCliente.htm");
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
         GxWebStd.gx_div_start( context, "", dynEmpresaId.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynEmpresaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynEmpresaId_Internalname, "Empresa Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynEmpresaId, dynEmpresaId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0)), 1, dynEmpresaId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynEmpresaId.Visible, dynEmpresaId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_TCliente.htm");
         dynEmpresaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0));
         AssignProp("", false, dynEmpresaId_Internalname, "Values", (string)(dynEmpresaId.ToJavascriptSource()), true);
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
         GxWebStd.gx_single_line_edit( context, edtEmpresaNome_Internalname, A2EmpresaNome, StringUtil.RTrim( context.localUtil.Format( A2EmpresaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpresaNome_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Id:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")), StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A5ClienteId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A5ClienteId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdManual", "end", false, "", "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteNome_Internalname, "Nome:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteNome_Internalname, A6ClienteNome, StringUtil.RTrim( context.localUtil.Format( A6ClienteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteCPF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteCPF_Internalname, "CPF:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteCPF_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ClienteCPF), 11, 0, ".", "")), StringUtil.LTrim( ((edtClienteCPF_Enabled!=0) ? context.localUtil.Format( (decimal)(A7ClienteCPF), "ZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A7ClienteCPF), "ZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCPF_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteCPF_Enabled, 0, "text", "1", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteEmail_Internalname, "E-mail:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteEmail_Internalname, A8ClienteEmail, StringUtil.RTrim( context.localUtil.Format( A8ClienteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A8ClienteEmail, "", "", "", edtClienteEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteEmail_Enabled, 0, "email", "", 40, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteTelefone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteTelefone_Internalname, "Telefone:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A9ClienteTelefone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteTelefone_Internalname, StringUtil.RTrim( A9ClienteTelefone), StringUtil.RTrim( context.localUtil.Format( A9ClienteTelefone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtClienteTelefone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteTelefone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_TCliente.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TCliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TCliente.htm");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EmpresaId"), ".", ","), 18, MidpointRounding.ToEven));
               Z5ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z5ClienteId"), ".", ","), 18, MidpointRounding.ToEven));
               Z6ClienteNome = cgiGet( "Z6ClienteNome");
               Z7ClienteCPF = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z7ClienteCPF"), ".", ","), 18, MidpointRounding.ToEven));
               Z8ClienteEmail = cgiGet( "Z8ClienteEmail");
               Z9ClienteTelefone = cgiGet( "Z9ClienteTelefone");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPRESAID"), ".", ","), 18, MidpointRounding.ToEven));
               AV8ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCLIENTEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               dynEmpresaId.CurrentValue = cgiGet( dynEmpresaId_Internalname);
               A1EmpresaId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynEmpresaId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A2EmpresaNome = cgiGet( edtEmpresaNome_Internalname);
               AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
               A5ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
               A6ClienteNome = cgiGet( edtClienteNome_Internalname);
               AssignAttri("", false, "A6ClienteNome", A6ClienteNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteCPF_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteCPF_Internalname), ".", ",") > Convert.ToDecimal( 99999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTECPF");
                  AnyError = 1;
                  GX_FocusControl = edtClienteCPF_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7ClienteCPF = 0;
                  AssignAttri("", false, "A7ClienteCPF", StringUtil.LTrimStr( (decimal)(A7ClienteCPF), 11, 0));
               }
               else
               {
                  A7ClienteCPF = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteCPF_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A7ClienteCPF", StringUtil.LTrimStr( (decimal)(A7ClienteCPF), 11, 0));
               }
               A8ClienteEmail = cgiGet( edtClienteEmail_Internalname);
               AssignAttri("", false, "A8ClienteEmail", A8ClienteEmail);
               A9ClienteTelefone = cgiGet( edtClienteTelefone_Internalname);
               AssignAttri("", false, "A9ClienteTelefone", A9ClienteTelefone);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TCliente");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1EmpresaId != Z1EmpresaId ) || ( A5ClienteId != Z5ClienteId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tcliente:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A5ClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
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
                        GX_FocusControl = dynEmpresaId_Internalname;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         dynEmpresaId.Visible = 0;
         AssignProp("", false, dynEmpresaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynEmpresaId.Visible), 5, 0), true);
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwtcliente.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z6ClienteNome = T00023_A6ClienteNome[0];
               Z7ClienteCPF = T00023_A7ClienteCPF[0];
               Z8ClienteEmail = T00023_A8ClienteEmail[0];
               Z9ClienteTelefone = T00023_A9ClienteTelefone[0];
            }
            else
            {
               Z6ClienteNome = A6ClienteNome;
               Z7ClienteCPF = A7ClienteCPF;
               Z8ClienteEmail = A8ClienteEmail;
               Z9ClienteTelefone = A9ClienteTelefone;
            }
         }
         if ( GX_JID == -7 )
         {
            Z5ClienteId = A5ClienteId;
            Z6ClienteNome = A6ClienteNome;
            Z7ClienteCPF = A7ClienteCPF;
            Z8ClienteEmail = A8ClienteEmail;
            Z9ClienteTelefone = A9ClienteTelefone;
            Z1EmpresaId = A1EmpresaId;
            Z2EmpresaNome = A2EmpresaNome;
         }
      }

      protected void standaloneNotModal( )
      {
         dynEmpresaId.Enabled = 0;
         AssignProp("", false, dynEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmpresaId.Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         dynEmpresaId.Enabled = 0;
         AssignProp("", false, dynEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmpresaId.Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EmpresaId) )
         {
            A1EmpresaId = AV7EmpresaId;
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         }
         if ( ! (0==AV8ClienteId) )
         {
            A5ClienteId = AV8ClienteId;
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
         }
         else
         {
            if ( (0==AV8ClienteId) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               GXt_int1 = A5ClienteId;
               new pseqcliente(context ).execute(  AV7EmpresaId, out  GXt_int1) ;
               A5ClienteId = GXt_int1;
               AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
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
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A1EmpresaId});
            A2EmpresaNome = T00024_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(2);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A6ClienteNome = T00025_A6ClienteNome[0];
            AssignAttri("", false, "A6ClienteNome", A6ClienteNome);
            A2EmpresaNome = T00025_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            A7ClienteCPF = T00025_A7ClienteCPF[0];
            AssignAttri("", false, "A7ClienteCPF", StringUtil.LTrimStr( (decimal)(A7ClienteCPF), 11, 0));
            A8ClienteEmail = T00025_A8ClienteEmail[0];
            AssignAttri("", false, "A8ClienteEmail", A8ClienteEmail);
            A9ClienteTelefone = T00025_A9ClienteTelefone[0];
            AssignAttri("", false, "A9ClienteTelefone", A9ClienteTelefone);
            ZM022( -7) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV12Pgmname = "TCliente";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV12Pgmname = "TCliente";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = dynEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T00024_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         pr_default.close(2);
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A7ClienteCPF, A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Cliente CPF"}), 1, "CLIENTECPF");
            AnyError = 1;
            GX_FocusControl = edtClienteCPF_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( ! ( GxRegex.IsMatch(A8ClienteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Cliente Email does not match the specified pattern", "OutOfRange", 1, "CLIENTEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtClienteEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( long A1EmpresaId )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = dynEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T00027_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2EmpresaNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey022( )
      {
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 7) ;
            RcdFound2 = 1;
            A5ClienteId = T00023_A5ClienteId[0];
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
            A6ClienteNome = T00023_A6ClienteNome[0];
            AssignAttri("", false, "A6ClienteNome", A6ClienteNome);
            A7ClienteCPF = T00023_A7ClienteCPF[0];
            AssignAttri("", false, "A7ClienteCPF", StringUtil.LTrimStr( (decimal)(A7ClienteCPF), 11, 0));
            A8ClienteEmail = T00023_A8ClienteEmail[0];
            AssignAttri("", false, "A8ClienteEmail", A8ClienteEmail);
            A9ClienteTelefone = T00023_A9ClienteTelefone[0];
            AssignAttri("", false, "A9ClienteTelefone", A9ClienteTelefone);
            A1EmpresaId = T00023_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            Z1EmpresaId = A1EmpresaId;
            Z5ClienteId = A5ClienteId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00029_A1EmpresaId[0] < A1EmpresaId ) || ( T00029_A1EmpresaId[0] == A1EmpresaId ) && ( T00029_A5ClienteId[0] < A5ClienteId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00029_A1EmpresaId[0] > A1EmpresaId ) || ( T00029_A1EmpresaId[0] == A1EmpresaId ) && ( T00029_A5ClienteId[0] > A5ClienteId ) ) )
            {
               A1EmpresaId = T00029_A1EmpresaId[0];
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A5ClienteId = T00029_A5ClienteId[0];
               AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000210_A1EmpresaId[0] > A1EmpresaId ) || ( T000210_A1EmpresaId[0] == A1EmpresaId ) && ( T000210_A5ClienteId[0] > A5ClienteId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000210_A1EmpresaId[0] < A1EmpresaId ) || ( T000210_A1EmpresaId[0] == A1EmpresaId ) && ( T000210_A5ClienteId[0] < A5ClienteId ) ) )
            {
               A1EmpresaId = T000210_A1EmpresaId[0];
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A5ClienteId = T000210_A5ClienteId[0];
               AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( ( A1EmpresaId != Z1EmpresaId ) || ( A5ClienteId != Z5ClienteId ) )
               {
                  A1EmpresaId = Z1EmpresaId;
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
                  A5ClienteId = Z5ClienteId;
                  AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "EMPRESAID");
                  AnyError = 1;
                  GX_FocusControl = dynEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtClienteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A1EmpresaId != Z1EmpresaId ) || ( A5ClienteId != Z5ClienteId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtClienteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_FocusControl = dynEmpresaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtClienteNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( ( A1EmpresaId != Z1EmpresaId ) || ( A5ClienteId != Z5ClienteId ) )
         {
            A1EmpresaId = Z1EmpresaId;
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A5ClienteId = Z5ClienteId;
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = dynEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A1EmpresaId, A5ClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TCliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z6ClienteNome, T00022_A6ClienteNome[0]) != 0 ) || ( Z7ClienteCPF != T00022_A7ClienteCPF[0] ) || ( StringUtil.StrCmp(Z8ClienteEmail, T00022_A8ClienteEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z9ClienteTelefone, T00022_A9ClienteTelefone[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z6ClienteNome, T00022_A6ClienteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("tcliente:[seudo value changed for attri]"+"ClienteNome");
                  GXUtil.WriteLogRaw("Old: ",Z6ClienteNome);
                  GXUtil.WriteLogRaw("Current: ",T00022_A6ClienteNome[0]);
               }
               if ( Z7ClienteCPF != T00022_A7ClienteCPF[0] )
               {
                  GXUtil.WriteLog("tcliente:[seudo value changed for attri]"+"ClienteCPF");
                  GXUtil.WriteLogRaw("Old: ",Z7ClienteCPF);
                  GXUtil.WriteLogRaw("Current: ",T00022_A7ClienteCPF[0]);
               }
               if ( StringUtil.StrCmp(Z8ClienteEmail, T00022_A8ClienteEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("tcliente:[seudo value changed for attri]"+"ClienteEmail");
                  GXUtil.WriteLogRaw("Old: ",Z8ClienteEmail);
                  GXUtil.WriteLogRaw("Current: ",T00022_A8ClienteEmail[0]);
               }
               if ( StringUtil.StrCmp(Z9ClienteTelefone, T00022_A9ClienteTelefone[0]) != 0 )
               {
                  GXUtil.WriteLog("tcliente:[seudo value changed for attri]"+"ClienteTelefone");
                  GXUtil.WriteLogRaw("Old: ",Z9ClienteTelefone);
                  GXUtil.WriteLogRaw("Current: ",T00022_A9ClienteTelefone[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TCliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         if ( ! IsAuthorized("tcliente_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000211 */
                     pr_default.execute(9, new Object[] {A5ClienteId, A6ClienteNome, A7ClienteCPF, A8ClienteEmail, A9ClienteTelefone, A1EmpresaId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("TCliente");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         if ( ! IsAuthorized("tcliente_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000212 */
                     pr_default.execute(10, new Object[] {A6ClienteNome, A7ClienteCPF, A8ClienteEmail, A9ClienteTelefone, A1EmpresaId, A5ClienteId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("TCliente");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TCliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("tcliente_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000213 */
                  pr_default.execute(11, new Object[] {A1EmpresaId, A5ClienteId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("TCliente");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "TCliente";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
            /* Using cursor T000214 */
            pr_default.execute(12, new Object[] {A1EmpresaId});
            A2EmpresaNome = T000214_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000215 */
            pr_default.execute(13, new Object[] {A1EmpresaId, A5ClienteId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TRegistro Pedido"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("tcliente",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("tcliente",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000216 */
         pr_default.execute(14);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound2 = 1;
            A1EmpresaId = T000216_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A5ClienteId = T000216_A5ClienteId[0];
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound2 = 1;
            A1EmpresaId = T000216_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A5ClienteId = T000216_A5ClienteId[0];
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         dynEmpresaId.Enabled = 0;
         AssignProp("", false, dynEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEmpresaId.Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteNome_Enabled = 0;
         AssignProp("", false, edtClienteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteNome_Enabled), 5, 0), true);
         edtClienteCPF_Enabled = 0;
         AssignProp("", false, edtClienteCPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCPF_Enabled), 5, 0), true);
         edtClienteEmail_Enabled = 0;
         AssignProp("", false, edtClienteEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEmail_Enabled), 5, 0), true);
         edtClienteTelefone_Enabled = 0;
         AssignProp("", false, edtClienteTelefone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTelefone_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tcliente.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV8ClienteId,12,0))}, new string[] {"Gx_mode","EmpresaId","ClienteId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TCliente");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tcliente:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5ClienteId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z6ClienteNome", Z6ClienteNome);
         GxWebStd.gx_hidden_field( context, "Z7ClienteCPF", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7ClienteCPF), 11, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z8ClienteEmail", Z8ClienteEmail);
         GxWebStd.gx_hidden_field( context, "Z9ClienteTelefone", StringUtil.RTrim( Z9ClienteTelefone));
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
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ClienteId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8ClienteId), "ZZZZZZZZZZZ9"), context));
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
         return formatLink("tcliente.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV8ClienteId,12,0))}, new string[] {"Gx_mode","EmpresaId","ClienteId"})  ;
      }

      public override string GetPgmname( )
      {
         return "TCliente" ;
      }

      public override string GetPgmdesc( )
      {
         return "Clientes" ;
      }

      protected void InitializeNonKey022( )
      {
         A6ClienteNome = "";
         AssignAttri("", false, "A6ClienteNome", A6ClienteNome);
         A2EmpresaNome = "";
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         A7ClienteCPF = 0;
         AssignAttri("", false, "A7ClienteCPF", StringUtil.LTrimStr( (decimal)(A7ClienteCPF), 11, 0));
         A8ClienteEmail = "";
         AssignAttri("", false, "A8ClienteEmail", A8ClienteEmail);
         A9ClienteTelefone = "";
         AssignAttri("", false, "A9ClienteTelefone", A9ClienteTelefone);
         Z6ClienteNome = "";
         Z7ClienteCPF = 0;
         Z8ClienteEmail = "";
         Z9ClienteTelefone = "";
      }

      protected void InitAll022( )
      {
         A1EmpresaId = 0;
         AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         A5ClienteId = 0;
         AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024426171461", true, true);
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
         context.AddJavascriptSource("tcliente.js", "?2024426171461", false, true);
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
         dynEmpresaId_Internalname = "EMPRESAID";
         edtEmpresaNome_Internalname = "EMPRESANOME";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteNome_Internalname = "CLIENTENOME";
         edtClienteCPF_Internalname = "CLIENTECPF";
         edtClienteEmail_Internalname = "CLIENTEEMAIL";
         edtClienteTelefone_Internalname = "CLIENTETELEFONE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Clientes";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClienteTelefone_Jsonclick = "";
         edtClienteTelefone_Enabled = 1;
         edtClienteEmail_Jsonclick = "";
         edtClienteEmail_Enabled = 1;
         edtClienteCPF_Jsonclick = "";
         edtClienteCPF_Enabled = 1;
         edtClienteNome_Jsonclick = "";
         edtClienteNome_Enabled = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 0;
         edtEmpresaNome_Jsonclick = "";
         edtEmpresaNome_Enabled = 0;
         dynEmpresaId_Jsonclick = "";
         dynEmpresaId.Enabled = 0;
         dynEmpresaId.Visible = 1;
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

      protected void GXDLAEMPRESAID021( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAEMPRESAID_data021( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXAEMPRESAID_html021( )
      {
         long gxdynajaxvalue;
         GXDLAEMPRESAID_data021( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEmpresaId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEmpresaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 12, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAEMPRESAID_data021( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000217 */
         pr_default.execute(15);
         while ( (pr_default.getStatus(15) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000217_A1EmpresaId[0]), 12, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000217_A2EmpresaNome[0]);
            pr_default.readNext(15);
         }
         pr_default.close(15);
      }

      protected void GX3ASACLIENTEID022( long AV8ClienteId ,
                                         long AV7EmpresaId )
      {
         if ( ! (0==AV8ClienteId) )
         {
            A5ClienteId = AV8ClienteId;
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
         }
         else
         {
            if ( (0==AV8ClienteId) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               GXt_int1 = A5ClienteId;
               new pseqcliente(context ).execute(  AV7EmpresaId, out  GXt_int1) ;
               A5ClienteId = GXt_int1;
               AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")))+"\"") ;
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
         dynEmpresaId.Name = "EMPRESAID";
         dynEmpresaId.WebTags = "";
         dynEmpresaId.removeAllItems();
         /* Using cursor T000218 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            dynEmpresaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000218_A1EmpresaId[0]), 12, 0)), T000218_A2EmpresaNome[0], 0);
            pr_default.readNext(16);
         }
         pr_default.close(16);
         if ( dynEmpresaId.ItemCount > 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( dynEmpresaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         }
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
         A1EmpresaId = (long)(Math.Round(NumberUtil.Val( dynEmpresaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = dynEmpresaId_Internalname;
         }
         A2EmpresaNome = T000214_A2EmpresaNome[0];
         pr_default.close(12);
         dynload_actions( ) ;
         if ( dynEmpresaId.ItemCount > 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( dynEmpresaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEmpresaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
      }

      public void Valid_Clientecpf( )
      {
         A1EmpresaId = (long)(Math.Round(NumberUtil.Val( dynEmpresaId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000219 */
         pr_default.execute(17, new Object[] {A7ClienteCPF, A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Cliente CPF"}), 1, "CLIENTECPF");
            AnyError = 1;
            GX_FocusControl = edtClienteCPF_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         if ( dynEmpresaId.ItemCount > 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( dynEmpresaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEmpresaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1EmpresaId), 12, 0));
         }
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV8ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV8ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12022","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_EMPRESAID","""{"handler":"Valid_Empresaid","iparms":[{"av":"A2EmpresaNome","fld":"EMPRESANOME"},{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_EMPRESAID",""","oparms":[{"av":"A2EmpresaNome","fld":"EMPRESANOME"},{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_CLIENTECPF","""{"handler":"Valid_Clientecpf","iparms":[{"av":"A7ClienteCPF","fld":"CLIENTECPF","pic":"ZZZZZZZZZZ9"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_CLIENTECPF",""","oparms":[{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_CLIENTEEMAIL","""{"handler":"Valid_Clienteemail","iparms":[{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_CLIENTEEMAIL",""","oparms":[{"av":"dynEmpresaId"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z6ClienteNome = "";
         Z8ClienteEmail = "";
         Z9ClienteTelefone = "";
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
         A2EmpresaNome = "";
         A6ClienteNome = "";
         A8ClienteEmail = "";
         gxphoneLink = "";
         A9ClienteTelefone = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z2EmpresaNome = "";
         T00024_A2EmpresaNome = new string[] {""} ;
         T00025_A5ClienteId = new long[1] ;
         T00025_A6ClienteNome = new string[] {""} ;
         T00025_A2EmpresaNome = new string[] {""} ;
         T00025_A7ClienteCPF = new long[1] ;
         T00025_A8ClienteEmail = new string[] {""} ;
         T00025_A9ClienteTelefone = new string[] {""} ;
         T00025_A1EmpresaId = new long[1] ;
         T00026_A7ClienteCPF = new long[1] ;
         T00027_A2EmpresaNome = new string[] {""} ;
         T00028_A1EmpresaId = new long[1] ;
         T00028_A5ClienteId = new long[1] ;
         T00023_A5ClienteId = new long[1] ;
         T00023_A6ClienteNome = new string[] {""} ;
         T00023_A7ClienteCPF = new long[1] ;
         T00023_A8ClienteEmail = new string[] {""} ;
         T00023_A9ClienteTelefone = new string[] {""} ;
         T00023_A1EmpresaId = new long[1] ;
         T00029_A1EmpresaId = new long[1] ;
         T00029_A5ClienteId = new long[1] ;
         T000210_A1EmpresaId = new long[1] ;
         T000210_A5ClienteId = new long[1] ;
         T00022_A5ClienteId = new long[1] ;
         T00022_A6ClienteNome = new string[] {""} ;
         T00022_A7ClienteCPF = new long[1] ;
         T00022_A8ClienteEmail = new string[] {""} ;
         T00022_A9ClienteTelefone = new string[] {""} ;
         T00022_A1EmpresaId = new long[1] ;
         T000214_A2EmpresaNome = new string[] {""} ;
         T000215_A1EmpresaId = new long[1] ;
         T000215_A16RegistroPedidoId = new long[1] ;
         T000216_A1EmpresaId = new long[1] ;
         T000216_A5ClienteId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000217_A1EmpresaId = new long[1] ;
         T000217_A2EmpresaNome = new string[] {""} ;
         T000218_A1EmpresaId = new long[1] ;
         T000218_A2EmpresaNome = new string[] {""} ;
         T000219_A7ClienteCPF = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tcliente__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tcliente__default(),
            new Object[][] {
                new Object[] {
               T00022_A5ClienteId, T00022_A6ClienteNome, T00022_A7ClienteCPF, T00022_A8ClienteEmail, T00022_A9ClienteTelefone, T00022_A1EmpresaId
               }
               , new Object[] {
               T00023_A5ClienteId, T00023_A6ClienteNome, T00023_A7ClienteCPF, T00023_A8ClienteEmail, T00023_A9ClienteTelefone, T00023_A1EmpresaId
               }
               , new Object[] {
               T00024_A2EmpresaNome
               }
               , new Object[] {
               T00025_A5ClienteId, T00025_A6ClienteNome, T00025_A2EmpresaNome, T00025_A7ClienteCPF, T00025_A8ClienteEmail, T00025_A9ClienteTelefone, T00025_A1EmpresaId
               }
               , new Object[] {
               T00026_A7ClienteCPF
               }
               , new Object[] {
               T00027_A2EmpresaNome
               }
               , new Object[] {
               T00028_A1EmpresaId, T00028_A5ClienteId
               }
               , new Object[] {
               T00029_A1EmpresaId, T00029_A5ClienteId
               }
               , new Object[] {
               T000210_A1EmpresaId, T000210_A5ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000214_A2EmpresaNome
               }
               , new Object[] {
               T000215_A1EmpresaId, T000215_A16RegistroPedidoId
               }
               , new Object[] {
               T000216_A1EmpresaId, T000216_A5ClienteId
               }
               , new Object[] {
               T000217_A1EmpresaId, T000217_A2EmpresaNome
               }
               , new Object[] {
               T000218_A1EmpresaId, T000218_A2EmpresaNome
               }
               , new Object[] {
               T000219_A7ClienteCPF
               }
            }
         );
         AV12Pgmname = "TCliente";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEmpresaNome_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteNome_Enabled ;
      private int edtClienteCPF_Enabled ;
      private int edtClienteEmail_Enabled ;
      private int edtClienteTelefone_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private long wcpOAV7EmpresaId ;
      private long wcpOAV8ClienteId ;
      private long Z1EmpresaId ;
      private long Z5ClienteId ;
      private long Z7ClienteCPF ;
      private long AV8ClienteId ;
      private long AV7EmpresaId ;
      private long A1EmpresaId ;
      private long A5ClienteId ;
      private long A7ClienteCPF ;
      private long GXt_int1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z9ClienteTelefone ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClienteNome_Internalname ;
      private string dynEmpresaId_Internalname ;
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
      private string dynEmpresaId_Jsonclick ;
      private string edtEmpresaNome_Internalname ;
      private string edtEmpresaNome_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteNome_Jsonclick ;
      private string edtClienteCPF_Internalname ;
      private string edtClienteCPF_Jsonclick ;
      private string edtClienteEmail_Internalname ;
      private string edtClienteEmail_Jsonclick ;
      private string edtClienteTelefone_Internalname ;
      private string gxphoneLink ;
      private string A9ClienteTelefone ;
      private string edtClienteTelefone_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV12Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string Z6ClienteNome ;
      private string Z8ClienteEmail ;
      private string A2EmpresaNome ;
      private string A6ClienteNome ;
      private string A8ClienteEmail ;
      private string Z2EmpresaNome ;
      private IGxSession AV11WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynEmpresaId ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T00024_A2EmpresaNome ;
      private long[] T00025_A5ClienteId ;
      private string[] T00025_A6ClienteNome ;
      private string[] T00025_A2EmpresaNome ;
      private long[] T00025_A7ClienteCPF ;
      private string[] T00025_A8ClienteEmail ;
      private string[] T00025_A9ClienteTelefone ;
      private long[] T00025_A1EmpresaId ;
      private long[] T00026_A7ClienteCPF ;
      private string[] T00027_A2EmpresaNome ;
      private long[] T00028_A1EmpresaId ;
      private long[] T00028_A5ClienteId ;
      private long[] T00023_A5ClienteId ;
      private string[] T00023_A6ClienteNome ;
      private long[] T00023_A7ClienteCPF ;
      private string[] T00023_A8ClienteEmail ;
      private string[] T00023_A9ClienteTelefone ;
      private long[] T00023_A1EmpresaId ;
      private long[] T00029_A1EmpresaId ;
      private long[] T00029_A5ClienteId ;
      private long[] T000210_A1EmpresaId ;
      private long[] T000210_A5ClienteId ;
      private long[] T00022_A5ClienteId ;
      private string[] T00022_A6ClienteNome ;
      private long[] T00022_A7ClienteCPF ;
      private string[] T00022_A8ClienteEmail ;
      private string[] T00022_A9ClienteTelefone ;
      private long[] T00022_A1EmpresaId ;
      private string[] T000214_A2EmpresaNome ;
      private long[] T000215_A1EmpresaId ;
      private long[] T000215_A16RegistroPedidoId ;
      private long[] T000216_A1EmpresaId ;
      private long[] T000216_A5ClienteId ;
      private long[] T000217_A1EmpresaId ;
      private string[] T000217_A2EmpresaNome ;
      private long[] T000218_A1EmpresaId ;
      private string[] T000218_A2EmpresaNome ;
      private long[] T000219_A7ClienteCPF ;
      private IDataStoreProvider pr_gam ;
   }

   public class tcliente__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tcliente__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00022;
        prmT00022 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT00023;
        prmT00023 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT00024;
        prmT00024 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT00025;
        prmT00025 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT00026;
        prmT00026 = new Object[] {
        new ParDef("@ClienteCPF",GXType.Decimal,11,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT00027;
        prmT00027 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT00028;
        prmT00028 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT00029;
        prmT00029 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT000210;
        prmT000210 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT000211;
        prmT000211 = new Object[] {
        new ParDef("@ClienteId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteNome",GXType.NVarChar,40,0) ,
        new ParDef("@ClienteCPF",GXType.Decimal,11,0) ,
        new ParDef("@ClienteEmail",GXType.NVarChar,100,0) ,
        new ParDef("@ClienteTelefone",GXType.NChar,20,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000212;
        prmT000212 = new Object[] {
        new ParDef("@ClienteNome",GXType.NVarChar,40,0) ,
        new ParDef("@ClienteCPF",GXType.Decimal,11,0) ,
        new ParDef("@ClienteEmail",GXType.NVarChar,100,0) ,
        new ParDef("@ClienteTelefone",GXType.NChar,20,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT000213;
        prmT000213 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT000214;
        prmT000214 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000215;
        prmT000215 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT000216;
        prmT000216 = new Object[] {
        };
        Object[] prmT000217;
        prmT000217 = new Object[] {
        };
        Object[] prmT000218;
        prmT000218 = new Object[] {
        };
        Object[] prmT000219;
        prmT000219 = new Object[] {
        new ParDef("@ClienteCPF",GXType.Decimal,11,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00022", "SELECT [ClienteId], [ClienteNome], [ClienteCPF], [ClienteEmail], [ClienteTelefone], [EmpresaId] FROM [TCliente] WITH (UPDLOCK) WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00023", "SELECT [ClienteId], [ClienteNome], [ClienteCPF], [ClienteEmail], [ClienteTelefone], [EmpresaId] FROM [TCliente] WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00024", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00025", "SELECT TM1.[ClienteId], TM1.[ClienteNome], T2.[EmpresaNome], TM1.[ClienteCPF], TM1.[ClienteEmail], TM1.[ClienteTelefone], TM1.[EmpresaId] FROM ([TCliente] TM1 INNER JOIN [TEmpresa] T2 ON T2.[EmpresaId] = TM1.[EmpresaId]) WHERE TM1.[EmpresaId] = @EmpresaId and TM1.[ClienteId] = @ClienteId ORDER BY TM1.[EmpresaId], TM1.[ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00026", "SELECT [ClienteCPF] FROM [TCliente] WHERE ([ClienteCPF] = @ClienteCPF) AND (Not ( [EmpresaId] = @EmpresaId and [ClienteId] = @ClienteId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00027", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00028", "SELECT [EmpresaId], [ClienteId] FROM [TCliente] WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00029", "SELECT TOP 1 [EmpresaId], [ClienteId] FROM [TCliente] WHERE ( [EmpresaId] > @EmpresaId or [EmpresaId] = @EmpresaId and [ClienteId] > @ClienteId) ORDER BY [EmpresaId], [ClienteId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000210", "SELECT TOP 1 [EmpresaId], [ClienteId] FROM [TCliente] WHERE ( [EmpresaId] < @EmpresaId or [EmpresaId] = @EmpresaId and [ClienteId] < @ClienteId) ORDER BY [EmpresaId] DESC, [ClienteId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000211", "INSERT INTO [TCliente]([ClienteId], [ClienteNome], [ClienteCPF], [ClienteEmail], [ClienteTelefone], [EmpresaId]) VALUES(@ClienteId, @ClienteNome, @ClienteCPF, @ClienteEmail, @ClienteTelefone, @EmpresaId)", GxErrorMask.GX_NOMASK,prmT000211)
           ,new CursorDef("T000212", "UPDATE [TCliente] SET [ClienteNome]=@ClienteNome, [ClienteCPF]=@ClienteCPF, [ClienteEmail]=@ClienteEmail, [ClienteTelefone]=@ClienteTelefone  WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmT000212)
           ,new CursorDef("T000213", "DELETE FROM [TCliente]  WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmT000213)
           ,new CursorDef("T000214", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000215", "SELECT TOP 1 [EmpresaId], [RegistroPedidoId] FROM [TRegistroPedido] WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000216", "SELECT [EmpresaId], [ClienteId] FROM [TCliente] ORDER BY [EmpresaId], [ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000217", "SELECT [EmpresaId], [EmpresaNome] FROM [TEmpresa] ORDER BY [EmpresaNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000218", "SELECT [EmpresaId], [EmpresaNome] FROM [TEmpresa] ORDER BY [EmpresaNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000219", "SELECT [ClienteCPF] FROM [TCliente] WHERE ([ClienteCPF] = @ClienteCPF) AND (Not ( [EmpresaId] = @EmpresaId and [ClienteId] = @ClienteId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
