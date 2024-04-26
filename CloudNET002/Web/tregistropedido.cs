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
   public class tregistropedido : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"VEICULOID") == 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAVEICULOID044( A1EmpresaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"CLIENTEID") == 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLACLIENTEID044( A1EmpresaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"REGISTROPEDIDOID") == 0 )
         {
            AV8RegistroPedidoId = (long)(Math.Round(NumberUtil.Val( GetPar( "RegistroPedidoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8RegistroPedidoId", StringUtil.LTrimStr( (decimal)(AV8RegistroPedidoId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vREGISTROPEDIDOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8RegistroPedidoId), "ZZZZZZZZZZZ9"), context));
            AV7EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EmpresaId", StringUtil.LTrimStr( (decimal)(AV7EmpresaId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vEMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpresaId), "ZZZZZZZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASAREGISTROPEDIDOID044( AV8RegistroPedidoId, AV7EmpresaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A1EmpresaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A5ClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A1EmpresaId, A5ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A10VeiculoId = (long)(Math.Round(NumberUtil.Val( GetPar( "VeiculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A1EmpresaId, A10VeiculoId) ;
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
               AV8RegistroPedidoId = (long)(Math.Round(NumberUtil.Val( GetPar( "RegistroPedidoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8RegistroPedidoId", StringUtil.LTrimStr( (decimal)(AV8RegistroPedidoId), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vREGISTROPEDIDOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8RegistroPedidoId), "ZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Registros de Locação de Veículos", 0) ;
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

      public tregistropedido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public tregistropedido( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_EmpresaId ,
                           long aP2_RegistroPedidoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmpresaId = aP1_EmpresaId;
         this.AV8RegistroPedidoId = aP2_RegistroPedidoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynVeiculoId = new GXCombobox();
         dynClienteId = new GXCombobox();
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
            return "tregistropedido_Execute" ;
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
         if ( dynVeiculoId.ItemCount > 0 )
         {
            A10VeiculoId = (long)(Math.Round(NumberUtil.Val( dynVeiculoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A10VeiculoId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynVeiculoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10VeiculoId), 12, 0));
            AssignProp("", false, dynVeiculoId_Internalname, "Values", dynVeiculoId.ToJavascriptSource(), true);
         }
         if ( dynClienteId.ItemCount > 0 )
         {
            A5ClienteId = (long)(Math.Round(NumberUtil.Val( dynClienteId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynClienteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0));
            AssignProp("", false, dynClienteId_Internalname, "Values", dynClienteId.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Registros de Locação de Veículos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TRegistroPedido.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"REGISTROPEDIDOID"+"'), id:'"+"REGISTROPEDIDOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TRegistroPedido.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEmpresaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmpresaId_Visible, edtEmpresaId_Enabled, 1, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdAuto", "end", false, "", "HLP_TRegistroPedido.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TRegistroPedido.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEmpresaNome_Internalname, A2EmpresaNome, StringUtil.RTrim( context.localUtil.Format( A2EmpresaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpresaNome_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRegistroPedidoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRegistroPedidoId_Internalname, "Pedido:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRegistroPedidoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A16RegistroPedidoId), "ZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRegistroPedidoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRegistroPedidoId_Enabled, 1, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdManual", "end", false, "", "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynVeiculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynVeiculoId_Internalname, "Veículo:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynVeiculoId, dynVeiculoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A10VeiculoId), 12, 0)), 1, dynVeiculoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynVeiculoId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_TRegistroPedido.htm");
         dynVeiculoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10VeiculoId), 12, 0));
         AssignProp("", false, dynVeiculoId_Internalname, "Values", (string)(dynVeiculoId.ToJavascriptSource()), true);
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_10_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_10_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_10_Internalname, sImgUrl, imgprompt_10_Link, "", "", context.GetTheme( ), imgprompt_10_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynClienteId_Internalname, "Cliente:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynClienteId, dynClienteId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0)), 1, dynClienteId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynClienteId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_TRegistroPedido.htm");
         dynClienteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0));
         AssignProp("", false, dynClienteId_Internalname, "Values", (string)(dynClienteId.ToJavascriptSource()), true);
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDestino_Internalname, "Destino:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDestino_Internalname, StringUtil.RTrim( A17Destino), StringUtil.RTrim( context.localUtil.Format( A17Destino, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDestino_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDataRetirada_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDataRetirada_Internalname, "Data da Retirada:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDataRetirada_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDataRetirada_Internalname, context.localUtil.Format(A24DataRetirada, "99/99/9999"), context.localUtil.Format( A24DataRetirada, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataRetirada_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDataRetirada_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TRegistroPedido.htm");
         GxWebStd.gx_bitmap( context, edtDataRetirada_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataRetirada_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TRegistroPedido.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDataRetorno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDataRetorno_Internalname, "Data do Retorno:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDataRetorno_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDataRetorno_Internalname, context.localUtil.Format(A25DataRetorno, "99/99/9999"), context.localUtil.Format( A25DataRetorno, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataRetorno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDataRetorno_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TRegistroPedido.htm");
         GxWebStd.gx_bitmap( context, edtDataRetorno_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataRetorno_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TRegistroPedido.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRegistroPedido.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TRegistroPedido.htm");
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EmpresaId"), ".", ","), 18, MidpointRounding.ToEven));
               Z16RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z16RegistroPedidoId"), ".", ","), 18, MidpointRounding.ToEven));
               Z17Destino = cgiGet( "Z17Destino");
               Z24DataRetirada = context.localUtil.CToD( cgiGet( "Z24DataRetirada"), 0);
               Z25DataRetorno = context.localUtil.CToD( cgiGet( "Z25DataRetorno"), 0);
               n25DataRetorno = ((DateTime.MinValue==A25DataRetorno) ? true : false);
               Z5ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z5ClienteId"), ".", ","), 18, MidpointRounding.ToEven));
               Z10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z10VeiculoId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N10VeiculoId"), ".", ","), 18, MidpointRounding.ToEven));
               N5ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N5ClienteId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPRESAID"), ".", ","), 18, MidpointRounding.ToEven));
               AV8RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vREGISTROPEDIDOID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_VEICULOID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ".", ","), 18, MidpointRounding.ToEven));
               A11VeiculoMarca = cgiGet( "VEICULOMARCA");
               AV15Pgmname = cgiGet( "vPGMNAME");
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtRegistroPedidoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRegistroPedidoId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REGISTROPEDIDOID");
                  AnyError = 1;
                  GX_FocusControl = edtRegistroPedidoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A16RegistroPedidoId = 0;
                  AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
               }
               else
               {
                  A16RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRegistroPedidoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
               }
               dynVeiculoId.CurrentValue = cgiGet( dynVeiculoId_Internalname);
               A10VeiculoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynVeiculoId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
               dynClienteId.CurrentValue = cgiGet( dynClienteId_Internalname);
               A5ClienteId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynClienteId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
               A17Destino = cgiGet( edtDestino_Internalname);
               AssignAttri("", false, "A17Destino", A17Destino);
               if ( context.localUtil.VCDate( cgiGet( edtDataRetirada_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data Retirada"}), 1, "DATARETIRADA");
                  AnyError = 1;
                  GX_FocusControl = edtDataRetirada_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A24DataRetirada = DateTime.MinValue;
                  AssignAttri("", false, "A24DataRetirada", context.localUtil.Format(A24DataRetirada, "99/99/9999"));
               }
               else
               {
                  A24DataRetirada = context.localUtil.CToD( cgiGet( edtDataRetirada_Internalname), 1);
                  AssignAttri("", false, "A24DataRetirada", context.localUtil.Format(A24DataRetirada, "99/99/9999"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtDataRetorno_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data Retorno"}), 1, "DATARETORNO");
                  AnyError = 1;
                  GX_FocusControl = edtDataRetorno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A25DataRetorno = DateTime.MinValue;
                  n25DataRetorno = false;
                  AssignAttri("", false, "A25DataRetorno", context.localUtil.Format(A25DataRetorno, "99/99/9999"));
               }
               else
               {
                  A25DataRetorno = context.localUtil.CToD( cgiGet( edtDataRetorno_Internalname), 1);
                  n25DataRetorno = false;
                  AssignAttri("", false, "A25DataRetorno", context.localUtil.Format(A25DataRetorno, "99/99/9999"));
               }
               n25DataRetorno = ((DateTime.MinValue==A25DataRetorno) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TRegistroPedido");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1EmpresaId != Z1EmpresaId ) || ( A16RegistroPedidoId != Z16RegistroPedidoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tregistropedido:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A16RegistroPedidoId = (long)(Math.Round(NumberUtil.Val( GetPar( "RegistroPedidoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
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
                     sMode4 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode4;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound4 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
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
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll044( ) ;
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
            DisableAttributes044( ) ;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         AV12Insert_VeiculoId = 0;
         AssignAttri("", false, "AV12Insert_VeiculoId", StringUtil.LTrimStr( (decimal)(AV12Insert_VeiculoId), 12, 0));
         AV13Insert_ClienteId = 0;
         AssignAttri("", false, "AV13Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV13Insert_ClienteId), 12, 0));
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "VeiculoId") == 0 )
               {
                  AV12Insert_VeiculoId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_VeiculoId", StringUtil.LTrimStr( (decimal)(AV12Insert_VeiculoId), 12, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV13Insert_ClienteId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV13Insert_ClienteId), 12, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
         edtEmpresaId_Visible = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Visible), 5, 0), true);
      }

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwtregistropedido.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z17Destino = T00043_A17Destino[0];
               Z24DataRetirada = T00043_A24DataRetirada[0];
               Z25DataRetorno = T00043_A25DataRetorno[0];
               Z5ClienteId = T00043_A5ClienteId[0];
               Z10VeiculoId = T00043_A10VeiculoId[0];
            }
            else
            {
               Z17Destino = A17Destino;
               Z24DataRetirada = A24DataRetirada;
               Z25DataRetorno = A25DataRetorno;
               Z5ClienteId = A5ClienteId;
               Z10VeiculoId = A10VeiculoId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z16RegistroPedidoId = A16RegistroPedidoId;
            Z17Destino = A17Destino;
            Z24DataRetirada = A24DataRetirada;
            Z25DataRetorno = A25DataRetorno;
            Z1EmpresaId = A1EmpresaId;
            Z5ClienteId = A5ClienteId;
            Z10VeiculoId = A10VeiculoId;
            Z2EmpresaNome = A2EmpresaNome;
            Z11VeiculoMarca = A11VeiculoMarca;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         imgprompt_10_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0031.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"VEICULOID"+"'), id:'"+"VEICULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0021.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
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
         if ( ! (0==AV8RegistroPedidoId) )
         {
            A16RegistroPedidoId = AV8RegistroPedidoId;
            AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
         }
         else
         {
            if ( (0==AV8RegistroPedidoId) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               GXt_int1 = A16RegistroPedidoId;
               new pseqregistropedido(context ).execute(  AV7EmpresaId, out  GXt_int1) ;
               A16RegistroPedidoId = GXt_int1;
               AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
            }
         }
         if ( ! (0==AV8RegistroPedidoId) )
         {
            edtRegistroPedidoId_Enabled = 0;
            AssignProp("", false, edtRegistroPedidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroPedidoId_Enabled), 5, 0), true);
         }
         else
         {
            edtRegistroPedidoId_Enabled = 1;
            AssignProp("", false, edtRegistroPedidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroPedidoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8RegistroPedidoId) )
         {
            edtRegistroPedidoId_Enabled = 0;
            AssignProp("", false, edtRegistroPedidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroPedidoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_VeiculoId) )
         {
            dynVeiculoId.Enabled = 0;
            AssignProp("", false, dynVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynVeiculoId.Enabled), 5, 0), true);
         }
         else
         {
            dynVeiculoId.Enabled = 1;
            AssignProp("", false, dynVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynVeiculoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ClienteId) )
         {
            dynClienteId.Enabled = 0;
            AssignProp("", false, dynClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynClienteId.Enabled), 5, 0), true);
         }
         else
         {
            dynClienteId.Enabled = 1;
            AssignProp("", false, dynClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynClienteId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ClienteId) )
         {
            A5ClienteId = AV13Insert_ClienteId;
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_VeiculoId) )
         {
            A10VeiculoId = AV12Insert_VeiculoId;
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         }
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
            /* Using cursor T00044 */
            pr_default.execute(2, new Object[] {A1EmpresaId});
            A2EmpresaNome = T00044_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(2);
            GXAVEICULOID_html044( A1EmpresaId) ;
            GXACLIENTEID_html044( A1EmpresaId) ;
            AV15Pgmname = "TRegistroPedido";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00046 */
            pr_default.execute(4, new Object[] {A1EmpresaId, A10VeiculoId});
            A11VeiculoMarca = T00046_A11VeiculoMarca[0];
            pr_default.close(4);
         }
      }

      protected void Load044( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A1EmpresaId, A16RegistroPedidoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
            A17Destino = T00047_A17Destino[0];
            AssignAttri("", false, "A17Destino", A17Destino);
            A24DataRetirada = T00047_A24DataRetirada[0];
            AssignAttri("", false, "A24DataRetirada", context.localUtil.Format(A24DataRetirada, "99/99/9999"));
            A25DataRetorno = T00047_A25DataRetorno[0];
            n25DataRetorno = T00047_n25DataRetorno[0];
            AssignAttri("", false, "A25DataRetorno", context.localUtil.Format(A25DataRetorno, "99/99/9999"));
            A2EmpresaNome = T00047_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            A11VeiculoMarca = T00047_A11VeiculoMarca[0];
            A5ClienteId = T00047_A5ClienteId[0];
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
            A10VeiculoId = T00047_A10VeiculoId[0];
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
            ZM044( -20) ;
         }
         pr_default.close(5);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
         AV15Pgmname = "TRegistroPedido";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         GXAVEICULOID_html044( A1EmpresaId) ;
         GXACLIENTEID_html044( A1EmpresaId) ;
      }

      protected void CheckExtendedTable044( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV15Pgmname = "TRegistroPedido";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T00044_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         pr_default.close(2);
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'TCliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A1EmpresaId, A10VeiculoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'TVeiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11VeiculoMarca = T00046_A11VeiculoMarca[0];
         pr_default.close(4);
         GXAVEICULOID_html044( A1EmpresaId) ;
         GXACLIENTEID_html044( A1EmpresaId) ;
         if ( ! ( (DateTime.MinValue==A24DataRetirada) || ( DateTimeUtil.ResetTime ( A24DataRetirada ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Data Retirada is out of range", "OutOfRange", 1, "DATARETIRADA");
            AnyError = 1;
            GX_FocusControl = edtDataRetirada_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A25DataRetorno) || ( DateTimeUtil.ResetTime ( A25DataRetorno ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Data Retorno is out of range", "OutOfRange", 1, "DATARETORNO");
            AnyError = 1;
            GX_FocusControl = edtDataRetorno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( long A1EmpresaId )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T00048_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2EmpresaNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_22( long A1EmpresaId ,
                                long A5ClienteId )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'TCliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_23( long A1EmpresaId ,
                                long A10VeiculoId )
      {
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A1EmpresaId, A10VeiculoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'TVeiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11VeiculoMarca = T000410_A11VeiculoMarca[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11VeiculoMarca)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey044( )
      {
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A1EmpresaId, A16RegistroPedidoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A1EmpresaId, A16RegistroPedidoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 20) ;
            RcdFound4 = 1;
            A16RegistroPedidoId = T00043_A16RegistroPedidoId[0];
            AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
            A17Destino = T00043_A17Destino[0];
            AssignAttri("", false, "A17Destino", A17Destino);
            A24DataRetirada = T00043_A24DataRetirada[0];
            AssignAttri("", false, "A24DataRetirada", context.localUtil.Format(A24DataRetirada, "99/99/9999"));
            A25DataRetorno = T00043_A25DataRetorno[0];
            n25DataRetorno = T00043_n25DataRetorno[0];
            AssignAttri("", false, "A25DataRetorno", context.localUtil.Format(A25DataRetorno, "99/99/9999"));
            A1EmpresaId = T00043_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A5ClienteId = T00043_A5ClienteId[0];
            AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
            A10VeiculoId = T00043_A10VeiculoId[0];
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
            Z1EmpresaId = A1EmpresaId;
            Z16RegistroPedidoId = A16RegistroPedidoId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound4 = 0;
         /* Using cursor T000412 */
         pr_default.execute(10, new Object[] {A1EmpresaId, A16RegistroPedidoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000412_A1EmpresaId[0] < A1EmpresaId ) || ( T000412_A1EmpresaId[0] == A1EmpresaId ) && ( T000412_A16RegistroPedidoId[0] < A16RegistroPedidoId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000412_A1EmpresaId[0] > A1EmpresaId ) || ( T000412_A1EmpresaId[0] == A1EmpresaId ) && ( T000412_A16RegistroPedidoId[0] > A16RegistroPedidoId ) ) )
            {
               A1EmpresaId = T000412_A1EmpresaId[0];
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A16RegistroPedidoId = T000412_A16RegistroPedidoId[0];
               AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000413 */
         pr_default.execute(11, new Object[] {A1EmpresaId, A16RegistroPedidoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000413_A1EmpresaId[0] > A1EmpresaId ) || ( T000413_A1EmpresaId[0] == A1EmpresaId ) && ( T000413_A16RegistroPedidoId[0] > A16RegistroPedidoId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000413_A1EmpresaId[0] < A1EmpresaId ) || ( T000413_A1EmpresaId[0] == A1EmpresaId ) && ( T000413_A16RegistroPedidoId[0] < A16RegistroPedidoId ) ) )
            {
               A1EmpresaId = T000413_A1EmpresaId[0];
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A16RegistroPedidoId = T000413_A16RegistroPedidoId[0];
               AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( ( A1EmpresaId != Z1EmpresaId ) || ( A16RegistroPedidoId != Z16RegistroPedidoId ) )
               {
                  A1EmpresaId = Z1EmpresaId;
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
                  A16RegistroPedidoId = Z16RegistroPedidoId;
                  AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
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
                  Update044( ) ;
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A1EmpresaId != Z1EmpresaId ) || ( A16RegistroPedidoId != Z16RegistroPedidoId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     Insert044( ) ;
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
         if ( ( A1EmpresaId != Z1EmpresaId ) || ( A16RegistroPedidoId != Z16RegistroPedidoId ) )
         {
            A1EmpresaId = Z1EmpresaId;
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A16RegistroPedidoId = Z16RegistroPedidoId;
            AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
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

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A1EmpresaId, A16RegistroPedidoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TRegistroPedido"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z17Destino, T00042_A17Destino[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z24DataRetirada ) != DateTimeUtil.ResetTime ( T00042_A24DataRetirada[0] ) ) || ( DateTimeUtil.ResetTime ( Z25DataRetorno ) != DateTimeUtil.ResetTime ( T00042_A25DataRetorno[0] ) ) || ( Z5ClienteId != T00042_A5ClienteId[0] ) || ( Z10VeiculoId != T00042_A10VeiculoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z17Destino, T00042_A17Destino[0]) != 0 )
               {
                  GXUtil.WriteLog("tregistropedido:[seudo value changed for attri]"+"Destino");
                  GXUtil.WriteLogRaw("Old: ",Z17Destino);
                  GXUtil.WriteLogRaw("Current: ",T00042_A17Destino[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z24DataRetirada ) != DateTimeUtil.ResetTime ( T00042_A24DataRetirada[0] ) )
               {
                  GXUtil.WriteLog("tregistropedido:[seudo value changed for attri]"+"DataRetirada");
                  GXUtil.WriteLogRaw("Old: ",Z24DataRetirada);
                  GXUtil.WriteLogRaw("Current: ",T00042_A24DataRetirada[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z25DataRetorno ) != DateTimeUtil.ResetTime ( T00042_A25DataRetorno[0] ) )
               {
                  GXUtil.WriteLog("tregistropedido:[seudo value changed for attri]"+"DataRetorno");
                  GXUtil.WriteLogRaw("Old: ",Z25DataRetorno);
                  GXUtil.WriteLogRaw("Current: ",T00042_A25DataRetorno[0]);
               }
               if ( Z5ClienteId != T00042_A5ClienteId[0] )
               {
                  GXUtil.WriteLog("tregistropedido:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z5ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A5ClienteId[0]);
               }
               if ( Z10VeiculoId != T00042_A10VeiculoId[0] )
               {
                  GXUtil.WriteLog("tregistropedido:[seudo value changed for attri]"+"VeiculoId");
                  GXUtil.WriteLogRaw("Old: ",Z10VeiculoId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A10VeiculoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TRegistroPedido"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         if ( ! IsAuthorized("tregistropedido_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000414 */
                     pr_default.execute(12, new Object[] {A16RegistroPedidoId, A17Destino, A24DataRetirada, n25DataRetorno, A25DataRetorno, A1EmpresaId, A5ClienteId, A10VeiculoId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("TRegistroPedido");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         if ( ! IsAuthorized("tregistropedido_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000415 */
                     pr_default.execute(13, new Object[] {A17Destino, A24DataRetirada, n25DataRetorno, A25DataRetorno, A5ClienteId, A10VeiculoId, A1EmpresaId, A16RegistroPedidoId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("TRegistroPedido");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TRegistroPedido"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("tregistropedido_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000416 */
                  pr_default.execute(14, new Object[] {A1EmpresaId, A16RegistroPedidoId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("TRegistroPedido");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "TRegistroPedido";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000417 */
            pr_default.execute(15, new Object[] {A1EmpresaId});
            A2EmpresaNome = T000417_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(15);
            GXAVEICULOID_html044( A1EmpresaId) ;
            GXACLIENTEID_html044( A1EmpresaId) ;
            /* Using cursor T000418 */
            pr_default.execute(16, new Object[] {A1EmpresaId, A10VeiculoId});
            A11VeiculoMarca = T000418_A11VeiculoMarca[0];
            pr_default.close(16);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("tregistropedido",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("tregistropedido",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Scan By routine */
         /* Using cursor T000419 */
         pr_default.execute(17);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound4 = 1;
            A1EmpresaId = T000419_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A16RegistroPedidoId = T000419_A16RegistroPedidoId[0];
            AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound4 = 1;
            A1EmpresaId = T000419_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A16RegistroPedidoId = T000419_A16RegistroPedidoId[0];
            AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtRegistroPedidoId_Enabled = 0;
         AssignProp("", false, edtRegistroPedidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroPedidoId_Enabled), 5, 0), true);
         dynVeiculoId.Enabled = 0;
         AssignProp("", false, dynVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynVeiculoId.Enabled), 5, 0), true);
         dynClienteId.Enabled = 0;
         AssignProp("", false, dynClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynClienteId.Enabled), 5, 0), true);
         edtDestino_Enabled = 0;
         AssignProp("", false, edtDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDestino_Enabled), 5, 0), true);
         edtDataRetirada_Enabled = 0;
         AssignProp("", false, edtDataRetirada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataRetirada_Enabled), 5, 0), true);
         edtDataRetorno_Enabled = 0;
         AssignProp("", false, edtDataRetorno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataRetorno_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1638560), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1638560), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1638560), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tregistropedido.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV8RegistroPedidoId,12,0))}, new string[] {"Gx_mode","EmpresaId","RegistroPedidoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TRegistroPedido");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tregistropedido:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z16RegistroPedidoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16RegistroPedidoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17Destino", StringUtil.RTrim( Z17Destino));
         GxWebStd.gx_hidden_field( context, "Z24DataRetirada", context.localUtil.DToC( Z24DataRetirada, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z25DataRetorno", context.localUtil.DToC( Z25DataRetorno, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z5ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5ClienteId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10VeiculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10VeiculoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N10VeiculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N5ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vREGISTROPEDIDOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8RegistroPedidoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGISTROPEDIDOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8RegistroPedidoId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_VEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_VeiculoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ClienteId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VEICULOMARCA", A11VeiculoMarca);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         return formatLink("tregistropedido.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV8RegistroPedidoId,12,0))}, new string[] {"Gx_mode","EmpresaId","RegistroPedidoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "TRegistroPedido" ;
      }

      public override string GetPgmdesc( )
      {
         return "Registros de Locação de Veículos" ;
      }

      protected void InitializeNonKey044( )
      {
         A10VeiculoId = 0;
         AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         A5ClienteId = 0;
         AssignAttri("", false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
         A17Destino = "";
         AssignAttri("", false, "A17Destino", A17Destino);
         A24DataRetirada = DateTime.MinValue;
         AssignAttri("", false, "A24DataRetirada", context.localUtil.Format(A24DataRetirada, "99/99/9999"));
         A25DataRetorno = DateTime.MinValue;
         n25DataRetorno = false;
         AssignAttri("", false, "A25DataRetorno", context.localUtil.Format(A25DataRetorno, "99/99/9999"));
         n25DataRetorno = ((DateTime.MinValue==A25DataRetorno) ? true : false);
         A2EmpresaNome = "";
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         A11VeiculoMarca = "";
         AssignAttri("", false, "A11VeiculoMarca", A11VeiculoMarca);
         Z17Destino = "";
         Z24DataRetirada = DateTime.MinValue;
         Z25DataRetorno = DateTime.MinValue;
         Z5ClienteId = 0;
         Z10VeiculoId = 0;
      }

      protected void InitAll044( )
      {
         A1EmpresaId = 0;
         AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         A16RegistroPedidoId = 0;
         AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
         InitializeNonKey044( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202442617141453", true, true);
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
         context.AddJavascriptSource("tregistropedido.js", "?202442617141454", false, true);
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
         edtRegistroPedidoId_Internalname = "REGISTROPEDIDOID";
         dynVeiculoId_Internalname = "VEICULOID";
         dynClienteId_Internalname = "CLIENTEID";
         edtDestino_Internalname = "DESTINO";
         edtDataRetirada_Internalname = "DATARETIRADA";
         edtDataRetorno_Internalname = "DATARETORNO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
         imgprompt_10_Internalname = "PROMPT_10";
         imgprompt_5_Internalname = "PROMPT_5";
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
         Form.Caption = "Registros de Locação de Veículos";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtDataRetorno_Jsonclick = "";
         edtDataRetorno_Enabled = 1;
         edtDataRetirada_Jsonclick = "";
         edtDataRetirada_Enabled = 1;
         edtDestino_Jsonclick = "";
         edtDestino_Enabled = 1;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         dynClienteId_Jsonclick = "";
         dynClienteId.Enabled = 1;
         imgprompt_10_Visible = 1;
         imgprompt_10_Link = "";
         dynVeiculoId_Jsonclick = "";
         dynVeiculoId.Enabled = 1;
         edtRegistroPedidoId_Jsonclick = "";
         edtRegistroPedidoId_Enabled = 1;
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
         GXAVEICULOID_html044( A1EmpresaId) ;
         GXACLIENTEID_html044( A1EmpresaId) ;
         /* End function dynload_actions */
      }

      protected void GXDLAVEICULOID044( long A1EmpresaId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAVEICULOID_data044( A1EmpresaId) ;
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

      protected void GXAVEICULOID_html044( long A1EmpresaId )
      {
         long gxdynajaxvalue;
         GXDLAVEICULOID_data044( A1EmpresaId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynVeiculoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynVeiculoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 12, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAVEICULOID_data044( long A1EmpresaId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Selecione");
         /* Using cursor T000420 */
         pr_default.execute(18, new Object[] {A1EmpresaId});
         while ( (pr_default.getStatus(18) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000420_A10VeiculoId[0]), 12, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000420_A11VeiculoMarca[0]);
            pr_default.readNext(18);
         }
         pr_default.close(18);
      }

      protected void GXDLACLIENTEID044( long A1EmpresaId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLACLIENTEID_data044( A1EmpresaId) ;
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

      protected void GXACLIENTEID_html044( long A1EmpresaId )
      {
         long gxdynajaxvalue;
         GXDLACLIENTEID_data044( A1EmpresaId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynClienteId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynClienteId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 12, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLACLIENTEID_data044( long A1EmpresaId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Selecione");
         /* Using cursor T000421 */
         pr_default.execute(19, new Object[] {A1EmpresaId});
         while ( (pr_default.getStatus(19) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000421_A5ClienteId[0]), 12, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000421_A6ClienteNome[0]);
            pr_default.readNext(19);
         }
         pr_default.close(19);
      }

      protected void GX7ASAREGISTROPEDIDOID044( long AV8RegistroPedidoId ,
                                                long AV7EmpresaId )
      {
         if ( ! (0==AV8RegistroPedidoId) )
         {
            A16RegistroPedidoId = AV8RegistroPedidoId;
            AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
         }
         else
         {
            if ( (0==AV8RegistroPedidoId) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               GXt_int1 = A16RegistroPedidoId;
               new pseqregistropedido(context ).execute(  AV7EmpresaId, out  GXt_int1) ;
               A16RegistroPedidoId = GXt_int1;
               AssignAttri("", false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")))+"\"") ;
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
         dynVeiculoId.Name = "VEICULOID";
         dynVeiculoId.WebTags = "";
         dynClienteId.Name = "CLIENTEID";
         dynClienteId.WebTags = "";
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
         A10VeiculoId = (long)(Math.Round(NumberUtil.Val( dynVeiculoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A5ClienteId = (long)(Math.Round(NumberUtil.Val( dynClienteId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000422 */
         pr_default.execute(20, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
         }
         A2EmpresaNome = T000422_A2EmpresaNome[0];
         pr_default.close(20);
         GXAVEICULOID_html044( A1EmpresaId) ;
         GXACLIENTEID_html044( A1EmpresaId) ;
         dynload_actions( ) ;
         if ( dynVeiculoId.ItemCount > 0 )
         {
            A10VeiculoId = (long)(Math.Round(NumberUtil.Val( dynVeiculoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A10VeiculoId), 12, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynVeiculoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10VeiculoId), 12, 0));
         }
         if ( dynClienteId.ItemCount > 0 )
         {
            A5ClienteId = (long)(Math.Round(NumberUtil.Val( dynClienteId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynClienteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         AssignAttri("", false, "A10VeiculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")));
         dynVeiculoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A10VeiculoId), 12, 0));
         AssignProp("", false, dynVeiculoId_Internalname, "Values", dynVeiculoId.ToJavascriptSource(), true);
         AssignAttri("", false, "A5ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")));
         dynClienteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0));
         AssignProp("", false, dynClienteId_Internalname, "Values", dynClienteId.ToJavascriptSource(), true);
      }

      public void Valid_Veiculoid( )
      {
         A10VeiculoId = (long)(Math.Round(NumberUtil.Val( dynVeiculoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A5ClienteId = (long)(Math.Round(NumberUtil.Val( dynClienteId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000423 */
         pr_default.execute(21, new Object[] {A1EmpresaId, A10VeiculoId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No matching 'TVeiculo'.", "ForeignKeyNotFound", 1, "VEICULOID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
         }
         A11VeiculoMarca = T000423_A11VeiculoMarca[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A11VeiculoMarca", A11VeiculoMarca);
      }

      public void Valid_Clienteid( )
      {
         A10VeiculoId = (long)(Math.Round(NumberUtil.Val( dynVeiculoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A5ClienteId = (long)(Math.Round(NumberUtil.Val( dynClienteId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000424 */
         pr_default.execute(22, new Object[] {A1EmpresaId, A5ClienteId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No matching 'TCliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV8RegistroPedidoId","fld":"vREGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV8RegistroPedidoId","fld":"vREGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12042","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_EMPRESAID","""{"handler":"Valid_Empresaid","iparms":[{"av":"A2EmpresaNome","fld":"EMPRESANOME"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_EMPRESAID",""","oparms":[{"av":"A2EmpresaNome","fld":"EMPRESANOME"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_REGISTROPEDIDOID","""{"handler":"Valid_Registropedidoid","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_REGISTROPEDIDOID",""","oparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_VEICULOID","""{"handler":"Valid_Veiculoid","iparms":[{"av":"A11VeiculoMarca","fld":"VEICULOMARCA"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_VEICULOID",""","oparms":[{"av":"A11VeiculoMarca","fld":"VEICULOMARCA"},{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_DATARETIRADA","""{"handler":"Valid_Dataretirada","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_DATARETIRADA",""","oparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_DATARETORNO","""{"handler":"Valid_Dataretorno","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]""");
         setEventMetadata("VALID_DATARETORNO",""","oparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"dynVeiculoId"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"dynClienteId"},{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
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
         pr_default.close(20);
         pr_default.close(15);
         pr_default.close(22);
         pr_default.close(21);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z17Destino = "";
         Z24DataRetirada = DateTime.MinValue;
         Z25DataRetorno = DateTime.MinValue;
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
         imgprompt_10_gximage = "";
         imgprompt_5_gximage = "";
         A17Destino = "";
         A24DataRetirada = DateTime.MinValue;
         A25DataRetorno = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         A11VeiculoMarca = "";
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode4 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV11WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z2EmpresaNome = "";
         Z11VeiculoMarca = "";
         T00044_A2EmpresaNome = new string[] {""} ;
         T00046_A11VeiculoMarca = new string[] {""} ;
         T00047_A16RegistroPedidoId = new long[1] ;
         T00047_A17Destino = new string[] {""} ;
         T00047_A24DataRetirada = new DateTime[] {DateTime.MinValue} ;
         T00047_A25DataRetorno = new DateTime[] {DateTime.MinValue} ;
         T00047_n25DataRetorno = new bool[] {false} ;
         T00047_A2EmpresaNome = new string[] {""} ;
         T00047_A11VeiculoMarca = new string[] {""} ;
         T00047_A1EmpresaId = new long[1] ;
         T00047_A5ClienteId = new long[1] ;
         T00047_A10VeiculoId = new long[1] ;
         T00045_A1EmpresaId = new long[1] ;
         T00048_A2EmpresaNome = new string[] {""} ;
         T00049_A1EmpresaId = new long[1] ;
         T000410_A11VeiculoMarca = new string[] {""} ;
         T000411_A1EmpresaId = new long[1] ;
         T000411_A16RegistroPedidoId = new long[1] ;
         T00043_A16RegistroPedidoId = new long[1] ;
         T00043_A17Destino = new string[] {""} ;
         T00043_A24DataRetirada = new DateTime[] {DateTime.MinValue} ;
         T00043_A25DataRetorno = new DateTime[] {DateTime.MinValue} ;
         T00043_n25DataRetorno = new bool[] {false} ;
         T00043_A1EmpresaId = new long[1] ;
         T00043_A5ClienteId = new long[1] ;
         T00043_A10VeiculoId = new long[1] ;
         T000412_A1EmpresaId = new long[1] ;
         T000412_A16RegistroPedidoId = new long[1] ;
         T000413_A1EmpresaId = new long[1] ;
         T000413_A16RegistroPedidoId = new long[1] ;
         T00042_A16RegistroPedidoId = new long[1] ;
         T00042_A17Destino = new string[] {""} ;
         T00042_A24DataRetirada = new DateTime[] {DateTime.MinValue} ;
         T00042_A25DataRetorno = new DateTime[] {DateTime.MinValue} ;
         T00042_n25DataRetorno = new bool[] {false} ;
         T00042_A1EmpresaId = new long[1] ;
         T00042_A5ClienteId = new long[1] ;
         T00042_A10VeiculoId = new long[1] ;
         T000417_A2EmpresaNome = new string[] {""} ;
         T000418_A11VeiculoMarca = new string[] {""} ;
         T000419_A1EmpresaId = new long[1] ;
         T000419_A16RegistroPedidoId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000420_A1EmpresaId = new long[1] ;
         T000420_A10VeiculoId = new long[1] ;
         T000420_A11VeiculoMarca = new string[] {""} ;
         T000421_A1EmpresaId = new long[1] ;
         T000421_A5ClienteId = new long[1] ;
         T000421_A6ClienteNome = new string[] {""} ;
         T000422_A2EmpresaNome = new string[] {""} ;
         T000423_A11VeiculoMarca = new string[] {""} ;
         T000424_A1EmpresaId = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tregistropedido__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tregistropedido__default(),
            new Object[][] {
                new Object[] {
               T00042_A16RegistroPedidoId, T00042_A17Destino, T00042_A24DataRetirada, T00042_A25DataRetorno, T00042_n25DataRetorno, T00042_A1EmpresaId, T00042_A5ClienteId, T00042_A10VeiculoId
               }
               , new Object[] {
               T00043_A16RegistroPedidoId, T00043_A17Destino, T00043_A24DataRetirada, T00043_A25DataRetorno, T00043_n25DataRetorno, T00043_A1EmpresaId, T00043_A5ClienteId, T00043_A10VeiculoId
               }
               , new Object[] {
               T00044_A2EmpresaNome
               }
               , new Object[] {
               T00045_A1EmpresaId
               }
               , new Object[] {
               T00046_A11VeiculoMarca
               }
               , new Object[] {
               T00047_A16RegistroPedidoId, T00047_A17Destino, T00047_A24DataRetirada, T00047_A25DataRetorno, T00047_n25DataRetorno, T00047_A2EmpresaNome, T00047_A11VeiculoMarca, T00047_A1EmpresaId, T00047_A5ClienteId, T00047_A10VeiculoId
               }
               , new Object[] {
               T00048_A2EmpresaNome
               }
               , new Object[] {
               T00049_A1EmpresaId
               }
               , new Object[] {
               T000410_A11VeiculoMarca
               }
               , new Object[] {
               T000411_A1EmpresaId, T000411_A16RegistroPedidoId
               }
               , new Object[] {
               T000412_A1EmpresaId, T000412_A16RegistroPedidoId
               }
               , new Object[] {
               T000413_A1EmpresaId, T000413_A16RegistroPedidoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000417_A2EmpresaNome
               }
               , new Object[] {
               T000418_A11VeiculoMarca
               }
               , new Object[] {
               T000419_A1EmpresaId, T000419_A16RegistroPedidoId
               }
               , new Object[] {
               T000420_A1EmpresaId, T000420_A10VeiculoId, T000420_A11VeiculoMarca
               }
               , new Object[] {
               T000421_A1EmpresaId, T000421_A5ClienteId, T000421_A6ClienteNome
               }
               , new Object[] {
               T000422_A2EmpresaNome
               }
               , new Object[] {
               T000423_A11VeiculoMarca
               }
               , new Object[] {
               T000424_A1EmpresaId
               }
            }
         );
         AV15Pgmname = "TRegistroPedido";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound4 ;
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
      private int edtRegistroPedidoId_Enabled ;
      private int imgprompt_10_Visible ;
      private int imgprompt_5_Visible ;
      private int edtDestino_Enabled ;
      private int edtDataRetirada_Enabled ;
      private int edtDataRetorno_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV16GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private long wcpOAV7EmpresaId ;
      private long wcpOAV8RegistroPedidoId ;
      private long Z1EmpresaId ;
      private long Z16RegistroPedidoId ;
      private long Z5ClienteId ;
      private long Z10VeiculoId ;
      private long N10VeiculoId ;
      private long N5ClienteId ;
      private long A1EmpresaId ;
      private long AV8RegistroPedidoId ;
      private long AV7EmpresaId ;
      private long A5ClienteId ;
      private long A10VeiculoId ;
      private long A16RegistroPedidoId ;
      private long AV12Insert_VeiculoId ;
      private long AV13Insert_ClienteId ;
      private long GXt_int1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z17Destino ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEmpresaId_Internalname ;
      private string dynVeiculoId_Internalname ;
      private string dynClienteId_Internalname ;
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
      private string edtRegistroPedidoId_Internalname ;
      private string edtRegistroPedidoId_Jsonclick ;
      private string dynVeiculoId_Jsonclick ;
      private string imgprompt_10_gximage ;
      private string imgprompt_10_Internalname ;
      private string imgprompt_10_Link ;
      private string dynClienteId_Jsonclick ;
      private string imgprompt_5_gximage ;
      private string imgprompt_5_Internalname ;
      private string imgprompt_5_Link ;
      private string edtDestino_Internalname ;
      private string A17Destino ;
      private string edtDestino_Jsonclick ;
      private string edtDataRetirada_Internalname ;
      private string edtDataRetirada_Jsonclick ;
      private string edtDataRetorno_Internalname ;
      private string edtDataRetorno_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode4 ;
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
      private DateTime Z24DataRetirada ;
      private DateTime Z25DataRetorno ;
      private DateTime A24DataRetirada ;
      private DateTime A25DataRetorno ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n25DataRetorno ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string A2EmpresaNome ;
      private string A11VeiculoMarca ;
      private string Z2EmpresaNome ;
      private string Z11VeiculoMarca ;
      private IGxSession AV11WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynVeiculoId ;
      private GXCombobox dynClienteId ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00044_A2EmpresaNome ;
      private string[] T00046_A11VeiculoMarca ;
      private long[] T00047_A16RegistroPedidoId ;
      private string[] T00047_A17Destino ;
      private DateTime[] T00047_A24DataRetirada ;
      private DateTime[] T00047_A25DataRetorno ;
      private bool[] T00047_n25DataRetorno ;
      private string[] T00047_A2EmpresaNome ;
      private string[] T00047_A11VeiculoMarca ;
      private long[] T00047_A1EmpresaId ;
      private long[] T00047_A5ClienteId ;
      private long[] T00047_A10VeiculoId ;
      private long[] T00045_A1EmpresaId ;
      private string[] T00048_A2EmpresaNome ;
      private long[] T00049_A1EmpresaId ;
      private string[] T000410_A11VeiculoMarca ;
      private long[] T000411_A1EmpresaId ;
      private long[] T000411_A16RegistroPedidoId ;
      private long[] T00043_A16RegistroPedidoId ;
      private string[] T00043_A17Destino ;
      private DateTime[] T00043_A24DataRetirada ;
      private DateTime[] T00043_A25DataRetorno ;
      private bool[] T00043_n25DataRetorno ;
      private long[] T00043_A1EmpresaId ;
      private long[] T00043_A5ClienteId ;
      private long[] T00043_A10VeiculoId ;
      private long[] T000412_A1EmpresaId ;
      private long[] T000412_A16RegistroPedidoId ;
      private long[] T000413_A1EmpresaId ;
      private long[] T000413_A16RegistroPedidoId ;
      private long[] T00042_A16RegistroPedidoId ;
      private string[] T00042_A17Destino ;
      private DateTime[] T00042_A24DataRetirada ;
      private DateTime[] T00042_A25DataRetorno ;
      private bool[] T00042_n25DataRetorno ;
      private long[] T00042_A1EmpresaId ;
      private long[] T00042_A5ClienteId ;
      private long[] T00042_A10VeiculoId ;
      private string[] T000417_A2EmpresaNome ;
      private string[] T000418_A11VeiculoMarca ;
      private long[] T000419_A1EmpresaId ;
      private long[] T000419_A16RegistroPedidoId ;
      private long[] T000420_A1EmpresaId ;
      private long[] T000420_A10VeiculoId ;
      private string[] T000420_A11VeiculoMarca ;
      private long[] T000421_A1EmpresaId ;
      private long[] T000421_A5ClienteId ;
      private string[] T000421_A6ClienteNome ;
      private string[] T000422_A2EmpresaNome ;
      private string[] T000423_A11VeiculoMarca ;
      private long[] T000424_A1EmpresaId ;
      private IDataStoreProvider pr_gam ;
   }

   public class tregistropedido__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tregistropedido__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00042;
        prmT00042 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
        };
        Object[] prmT00043;
        prmT00043 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
        };
        Object[] prmT00044;
        prmT00044 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT00045;
        prmT00045 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT00046;
        prmT00046 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT00047;
        prmT00047 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
        };
        Object[] prmT00048;
        prmT00048 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT00049;
        prmT00049 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        Object[] prmT000410;
        prmT000410 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT000411;
        prmT000411 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
        };
        Object[] prmT000412;
        prmT000412 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
        };
        Object[] prmT000413;
        prmT000413 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
        };
        Object[] prmT000414;
        prmT000414 = new Object[] {
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0) ,
        new ParDef("@Destino",GXType.NChar,20,0) ,
        new ParDef("@DataRetirada",GXType.Date,8,0) ,
        new ParDef("@DataRetorno",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT000415;
        prmT000415 = new Object[] {
        new ParDef("@Destino",GXType.NChar,20,0) ,
        new ParDef("@DataRetirada",GXType.Date,8,0) ,
        new ParDef("@DataRetorno",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@ClienteId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
        };
        Object[] prmT000416;
        prmT000416 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
        };
        Object[] prmT000417;
        prmT000417 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000418;
        prmT000418 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT000419;
        prmT000419 = new Object[] {
        };
        Object[] prmT000420;
        prmT000420 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000421;
        prmT000421 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000422;
        prmT000422 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000423;
        prmT000423 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT000424;
        prmT000424 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@ClienteId",GXType.Decimal,12,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00042", "SELECT [RegistroPedidoId], [Destino], [DataRetirada], [DataRetorno], [EmpresaId], [ClienteId], [VeiculoId] FROM [TRegistroPedido] WITH (UPDLOCK) WHERE [EmpresaId] = @EmpresaId AND [RegistroPedidoId] = @RegistroPedidoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00043", "SELECT [RegistroPedidoId], [Destino], [DataRetirada], [DataRetorno], [EmpresaId], [ClienteId], [VeiculoId] FROM [TRegistroPedido] WHERE [EmpresaId] = @EmpresaId AND [RegistroPedidoId] = @RegistroPedidoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00044", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00045", "SELECT [EmpresaId] FROM [TCliente] WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00046", "SELECT [VeiculoMarca] FROM [TVeiculo] WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00047", "SELECT TM1.[RegistroPedidoId], TM1.[Destino], TM1.[DataRetirada], TM1.[DataRetorno], T2.[EmpresaNome], T3.[VeiculoMarca], TM1.[EmpresaId], TM1.[ClienteId], TM1.[VeiculoId] FROM (([TRegistroPedido] TM1 INNER JOIN [TEmpresa] T2 ON T2.[EmpresaId] = TM1.[EmpresaId]) INNER JOIN [TVeiculo] T3 ON T3.[EmpresaId] = TM1.[EmpresaId] AND T3.[VeiculoId] = TM1.[VeiculoId]) WHERE TM1.[EmpresaId] = @EmpresaId and TM1.[RegistroPedidoId] = @RegistroPedidoId ORDER BY TM1.[EmpresaId], TM1.[RegistroPedidoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00048", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00049", "SELECT [EmpresaId] FROM [TCliente] WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000410", "SELECT [VeiculoMarca] FROM [TVeiculo] WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000411", "SELECT [EmpresaId], [RegistroPedidoId] FROM [TRegistroPedido] WHERE [EmpresaId] = @EmpresaId AND [RegistroPedidoId] = @RegistroPedidoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000412", "SELECT TOP 1 [EmpresaId], [RegistroPedidoId] FROM [TRegistroPedido] WHERE ( [EmpresaId] > @EmpresaId or [EmpresaId] = @EmpresaId and [RegistroPedidoId] > @RegistroPedidoId) ORDER BY [EmpresaId], [RegistroPedidoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000413", "SELECT TOP 1 [EmpresaId], [RegistroPedidoId] FROM [TRegistroPedido] WHERE ( [EmpresaId] < @EmpresaId or [EmpresaId] = @EmpresaId and [RegistroPedidoId] < @RegistroPedidoId) ORDER BY [EmpresaId] DESC, [RegistroPedidoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000414", "INSERT INTO [TRegistroPedido]([RegistroPedidoId], [Destino], [DataRetirada], [DataRetorno], [EmpresaId], [ClienteId], [VeiculoId]) VALUES(@RegistroPedidoId, @Destino, @DataRetirada, @DataRetorno, @EmpresaId, @ClienteId, @VeiculoId)", GxErrorMask.GX_NOMASK,prmT000414)
           ,new CursorDef("T000415", "UPDATE [TRegistroPedido] SET [Destino]=@Destino, [DataRetirada]=@DataRetirada, [DataRetorno]=@DataRetorno, [ClienteId]=@ClienteId, [VeiculoId]=@VeiculoId  WHERE [EmpresaId] = @EmpresaId AND [RegistroPedidoId] = @RegistroPedidoId", GxErrorMask.GX_NOMASK,prmT000415)
           ,new CursorDef("T000416", "DELETE FROM [TRegistroPedido]  WHERE [EmpresaId] = @EmpresaId AND [RegistroPedidoId] = @RegistroPedidoId", GxErrorMask.GX_NOMASK,prmT000416)
           ,new CursorDef("T000417", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000418", "SELECT [VeiculoMarca] FROM [TVeiculo] WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000419", "SELECT [EmpresaId], [RegistroPedidoId] FROM [TRegistroPedido] ORDER BY [EmpresaId], [RegistroPedidoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000420", "SELECT [EmpresaId], [VeiculoId], [VeiculoMarca] FROM [TVeiculo] WHERE [EmpresaId] = @EmpresaId ORDER BY [VeiculoMarca] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000421", "SELECT [EmpresaId], [ClienteId], [ClienteNome] FROM [TCliente] WHERE [EmpresaId] = @EmpresaId ORDER BY [ClienteNome] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000422", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000422,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000423", "SELECT [VeiculoMarca] FROM [TVeiculo] WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000423,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000424", "SELECT [EmpresaId] FROM [TCliente] WHERE [EmpresaId] = @EmpresaId AND [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000424,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
