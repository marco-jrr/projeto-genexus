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
   public class tveiculo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel3"+"_"+"VEICULOID") == 0 )
         {
            AV8VeiculoId = (long)(Math.Round(NumberUtil.Val( GetPar( "VeiculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vVEICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8VeiculoId), "ZZZZZZZZZZZ9"), context));
            AV7EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7EmpresaId", StringUtil.LTrimStr( (decimal)(AV7EmpresaId), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vEMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EmpresaId), "ZZZZZZZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX3ASAVEICULOID033( AV8VeiculoId, AV7EmpresaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A1EmpresaId) ;
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
               AV8VeiculoId = (long)(Math.Round(NumberUtil.Val( GetPar( "VeiculoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8VeiculoId", StringUtil.LTrimStr( (decimal)(AV8VeiculoId), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vVEICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8VeiculoId), "ZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Veículos", 0) ;
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

      public tveiculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public tveiculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_EmpresaId ,
                           long aP2_VeiculoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EmpresaId = aP1_EmpresaId;
         this.AV8VeiculoId = aP2_VeiculoId;
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
            return "tveiculo_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Veículos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TVeiculo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"VEICULOID"+"'), id:'"+"VEICULOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TVeiculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEmpresaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmpresaId_Visible, edtEmpresaId_Enabled, 1, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdAuto", "end", false, "", "HLP_TVeiculo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TVeiculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEmpresaNome_Internalname, A2EmpresaNome, StringUtil.RTrim( context.localUtil.Format( A2EmpresaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpresaNome_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVeiculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoId_Internalname, "Id:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVeiculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")), StringUtil.LTrim( ((edtVeiculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdManual", "end", false, "", "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVeiculoMarca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoMarca_Internalname, "Marca:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoMarca_Internalname, A11VeiculoMarca, StringUtil.RTrim( context.localUtil.Format( A11VeiculoMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoMarca_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVeiculoModelo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoModelo_Internalname, "Modelo:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoModelo_Internalname, A12VeiculoModelo, StringUtil.RTrim( context.localUtil.Format( A12VeiculoModelo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoModelo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoModelo_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVeiculoPlaca_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoPlaca_Internalname, "Placa:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoPlaca_Internalname, StringUtil.RTrim( A13VeiculoPlaca), StringUtil.RTrim( context.localUtil.Format( A13VeiculoPlaca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoPlaca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoPlaca_Enabled, 0, "text", "", 7, "chr", 1, "row", 7, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVeiculoCor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoCor_Internalname, "Cor:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoCor_Internalname, StringUtil.RTrim( A14VeiculoCor), StringUtil.RTrim( context.localUtil.Format( A14VeiculoCor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoCor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoCor_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVeiculoAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVeiculoAno_Internalname, "Ano:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVeiculoAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15VeiculoAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtVeiculoAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A15VeiculoAno), "ZZZ9") : context.localUtil.Format( (decimal)(A15VeiculoAno), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVeiculoAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TVeiculo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TVeiculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TVeiculo.htm");
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
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EmpresaId"), ".", ","), 18, MidpointRounding.ToEven));
               Z10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z10VeiculoId"), ".", ","), 18, MidpointRounding.ToEven));
               Z11VeiculoMarca = cgiGet( "Z11VeiculoMarca");
               Z12VeiculoModelo = cgiGet( "Z12VeiculoModelo");
               Z13VeiculoPlaca = cgiGet( "Z13VeiculoPlaca");
               Z14VeiculoCor = cgiGet( "Z14VeiculoCor");
               Z15VeiculoAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z15VeiculoAno"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPRESAID"), ".", ","), 18, MidpointRounding.ToEven));
               AV8VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vVEICULOID"), ".", ","), 18, MidpointRounding.ToEven));
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
               A10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVeiculoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
               A11VeiculoMarca = cgiGet( edtVeiculoMarca_Internalname);
               AssignAttri("", false, "A11VeiculoMarca", A11VeiculoMarca);
               A12VeiculoModelo = cgiGet( edtVeiculoModelo_Internalname);
               AssignAttri("", false, "A12VeiculoModelo", A12VeiculoModelo);
               A13VeiculoPlaca = cgiGet( edtVeiculoPlaca_Internalname);
               AssignAttri("", false, "A13VeiculoPlaca", A13VeiculoPlaca);
               A14VeiculoCor = cgiGet( edtVeiculoCor_Internalname);
               AssignAttri("", false, "A14VeiculoCor", A14VeiculoCor);
               if ( ( ( context.localUtil.CToN( cgiGet( edtVeiculoAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVeiculoAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VEICULOANO");
                  AnyError = 1;
                  GX_FocusControl = edtVeiculoAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15VeiculoAno = 0;
                  AssignAttri("", false, "A15VeiculoAno", StringUtil.LTrimStr( (decimal)(A15VeiculoAno), 4, 0));
               }
               else
               {
                  A15VeiculoAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtVeiculoAno_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A15VeiculoAno", StringUtil.LTrimStr( (decimal)(A15VeiculoAno), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TVeiculo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1EmpresaId != Z1EmpresaId ) || ( A10VeiculoId != Z10VeiculoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tveiculo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A10VeiculoId = (long)(Math.Round(NumberUtil.Val( GetPar( "VeiculoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
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
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
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
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
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
            DisableAttributes033( ) ;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
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

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwtveiculo.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z11VeiculoMarca = T00033_A11VeiculoMarca[0];
               Z12VeiculoModelo = T00033_A12VeiculoModelo[0];
               Z13VeiculoPlaca = T00033_A13VeiculoPlaca[0];
               Z14VeiculoCor = T00033_A14VeiculoCor[0];
               Z15VeiculoAno = T00033_A15VeiculoAno[0];
            }
            else
            {
               Z11VeiculoMarca = A11VeiculoMarca;
               Z12VeiculoModelo = A12VeiculoModelo;
               Z13VeiculoPlaca = A13VeiculoPlaca;
               Z14VeiculoCor = A14VeiculoCor;
               Z15VeiculoAno = A15VeiculoAno;
            }
         }
         if ( GX_JID == -7 )
         {
            Z10VeiculoId = A10VeiculoId;
            Z11VeiculoMarca = A11VeiculoMarca;
            Z12VeiculoModelo = A12VeiculoModelo;
            Z13VeiculoPlaca = A13VeiculoPlaca;
            Z14VeiculoCor = A14VeiculoCor;
            Z15VeiculoAno = A15VeiculoAno;
            Z1EmpresaId = A1EmpresaId;
            Z2EmpresaNome = A2EmpresaNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtVeiculoId_Enabled = 0;
         AssignProp("", false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), true);
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPRESAID"+"'), id:'"+"EMPRESAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtVeiculoId_Enabled = 0;
         AssignProp("", false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), true);
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
         if ( ! (0==AV8VeiculoId) )
         {
            A10VeiculoId = AV8VeiculoId;
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         }
         else
         {
            if ( (0==AV8VeiculoId) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               GXt_int1 = A10VeiculoId;
               new pseqveiculo(context ).execute(  AV7EmpresaId, out  GXt_int1) ;
               A10VeiculoId = GXt_int1;
               AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
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
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A1EmpresaId});
            A2EmpresaNome = T00034_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(2);
            AV12Pgmname = "TVeiculo";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
      }

      protected void Load033( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A1EmpresaId, A10VeiculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A11VeiculoMarca = T00035_A11VeiculoMarca[0];
            AssignAttri("", false, "A11VeiculoMarca", A11VeiculoMarca);
            A12VeiculoModelo = T00035_A12VeiculoModelo[0];
            AssignAttri("", false, "A12VeiculoModelo", A12VeiculoModelo);
            A13VeiculoPlaca = T00035_A13VeiculoPlaca[0];
            AssignAttri("", false, "A13VeiculoPlaca", A13VeiculoPlaca);
            A14VeiculoCor = T00035_A14VeiculoCor[0];
            AssignAttri("", false, "A14VeiculoCor", A14VeiculoCor);
            A15VeiculoAno = T00035_A15VeiculoAno[0];
            AssignAttri("", false, "A15VeiculoAno", StringUtil.LTrimStr( (decimal)(A15VeiculoAno), 4, 0));
            A2EmpresaNome = T00035_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            ZM033( -7) ;
         }
         pr_default.close(3);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV12Pgmname = "TVeiculo";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV12Pgmname = "TVeiculo";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T00034_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( long A1EmpresaId )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T00036_A2EmpresaNome[0];
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

      protected void GetKey033( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A1EmpresaId, A10VeiculoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A1EmpresaId, A10VeiculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 7) ;
            RcdFound3 = 1;
            A10VeiculoId = T00033_A10VeiculoId[0];
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
            A11VeiculoMarca = T00033_A11VeiculoMarca[0];
            AssignAttri("", false, "A11VeiculoMarca", A11VeiculoMarca);
            A12VeiculoModelo = T00033_A12VeiculoModelo[0];
            AssignAttri("", false, "A12VeiculoModelo", A12VeiculoModelo);
            A13VeiculoPlaca = T00033_A13VeiculoPlaca[0];
            AssignAttri("", false, "A13VeiculoPlaca", A13VeiculoPlaca);
            A14VeiculoCor = T00033_A14VeiculoCor[0];
            AssignAttri("", false, "A14VeiculoCor", A14VeiculoCor);
            A15VeiculoAno = T00033_A15VeiculoAno[0];
            AssignAttri("", false, "A15VeiculoAno", StringUtil.LTrimStr( (decimal)(A15VeiculoAno), 4, 0));
            A1EmpresaId = T00033_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            Z1EmpresaId = A1EmpresaId;
            Z10VeiculoId = A10VeiculoId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A1EmpresaId, A10VeiculoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00038_A1EmpresaId[0] < A1EmpresaId ) || ( T00038_A1EmpresaId[0] == A1EmpresaId ) && ( T00038_A10VeiculoId[0] < A10VeiculoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00038_A1EmpresaId[0] > A1EmpresaId ) || ( T00038_A1EmpresaId[0] == A1EmpresaId ) && ( T00038_A10VeiculoId[0] > A10VeiculoId ) ) )
            {
               A1EmpresaId = T00038_A1EmpresaId[0];
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A10VeiculoId = T00038_A10VeiculoId[0];
               AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A1EmpresaId, A10VeiculoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A1EmpresaId[0] > A1EmpresaId ) || ( T00039_A1EmpresaId[0] == A1EmpresaId ) && ( T00039_A10VeiculoId[0] > A10VeiculoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A1EmpresaId[0] < A1EmpresaId ) || ( T00039_A1EmpresaId[0] == A1EmpresaId ) && ( T00039_A10VeiculoId[0] < A10VeiculoId ) ) )
            {
               A1EmpresaId = T00039_A1EmpresaId[0];
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
               A10VeiculoId = T00039_A10VeiculoId[0];
               AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( ( A1EmpresaId != Z1EmpresaId ) || ( A10VeiculoId != Z10VeiculoId ) )
               {
                  A1EmpresaId = Z1EmpresaId;
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
                  A10VeiculoId = Z10VeiculoId;
                  AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
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
                  Update033( ) ;
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A1EmpresaId != Z1EmpresaId ) || ( A10VeiculoId != Z10VeiculoId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     Insert033( ) ;
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
         if ( ( A1EmpresaId != Z1EmpresaId ) || ( A10VeiculoId != Z10VeiculoId ) )
         {
            A1EmpresaId = Z1EmpresaId;
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A10VeiculoId = Z10VeiculoId;
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
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

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A1EmpresaId, A10VeiculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TVeiculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z11VeiculoMarca, T00032_A11VeiculoMarca[0]) != 0 ) || ( StringUtil.StrCmp(Z12VeiculoModelo, T00032_A12VeiculoModelo[0]) != 0 ) || ( StringUtil.StrCmp(Z13VeiculoPlaca, T00032_A13VeiculoPlaca[0]) != 0 ) || ( StringUtil.StrCmp(Z14VeiculoCor, T00032_A14VeiculoCor[0]) != 0 ) || ( Z15VeiculoAno != T00032_A15VeiculoAno[0] ) )
            {
               if ( StringUtil.StrCmp(Z11VeiculoMarca, T00032_A11VeiculoMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("tveiculo:[seudo value changed for attri]"+"VeiculoMarca");
                  GXUtil.WriteLogRaw("Old: ",Z11VeiculoMarca);
                  GXUtil.WriteLogRaw("Current: ",T00032_A11VeiculoMarca[0]);
               }
               if ( StringUtil.StrCmp(Z12VeiculoModelo, T00032_A12VeiculoModelo[0]) != 0 )
               {
                  GXUtil.WriteLog("tveiculo:[seudo value changed for attri]"+"VeiculoModelo");
                  GXUtil.WriteLogRaw("Old: ",Z12VeiculoModelo);
                  GXUtil.WriteLogRaw("Current: ",T00032_A12VeiculoModelo[0]);
               }
               if ( StringUtil.StrCmp(Z13VeiculoPlaca, T00032_A13VeiculoPlaca[0]) != 0 )
               {
                  GXUtil.WriteLog("tveiculo:[seudo value changed for attri]"+"VeiculoPlaca");
                  GXUtil.WriteLogRaw("Old: ",Z13VeiculoPlaca);
                  GXUtil.WriteLogRaw("Current: ",T00032_A13VeiculoPlaca[0]);
               }
               if ( StringUtil.StrCmp(Z14VeiculoCor, T00032_A14VeiculoCor[0]) != 0 )
               {
                  GXUtil.WriteLog("tveiculo:[seudo value changed for attri]"+"VeiculoCor");
                  GXUtil.WriteLogRaw("Old: ",Z14VeiculoCor);
                  GXUtil.WriteLogRaw("Current: ",T00032_A14VeiculoCor[0]);
               }
               if ( Z15VeiculoAno != T00032_A15VeiculoAno[0] )
               {
                  GXUtil.WriteLog("tveiculo:[seudo value changed for attri]"+"VeiculoAno");
                  GXUtil.WriteLogRaw("Old: ",Z15VeiculoAno);
                  GXUtil.WriteLogRaw("Current: ",T00032_A15VeiculoAno[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TVeiculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         if ( ! IsAuthorized("tveiculo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A10VeiculoId, A11VeiculoMarca, A12VeiculoModelo, A13VeiculoPlaca, A14VeiculoCor, A15VeiculoAno, A1EmpresaId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("TVeiculo");
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
                           ResetCaption030( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         if ( ! IsAuthorized("tveiculo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A11VeiculoMarca, A12VeiculoModelo, A13VeiculoPlaca, A14VeiculoCor, A15VeiculoAno, A1EmpresaId, A10VeiculoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("TVeiculo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TVeiculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("tveiculo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000312 */
                  pr_default.execute(10, new Object[] {A1EmpresaId, A10VeiculoId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("TVeiculo");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "TVeiculo";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
            /* Using cursor T000313 */
            pr_default.execute(11, new Object[] {A1EmpresaId});
            A2EmpresaNome = T000313_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A1EmpresaId, A10VeiculoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TRegistro Pedido"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("tveiculo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("tveiculo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000315 */
         pr_default.execute(13);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A1EmpresaId = T000315_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A10VeiculoId = T000315_A10VeiculoId[0];
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A1EmpresaId = T000315_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A10VeiculoId = T000315_A10VeiculoId[0];
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtVeiculoId_Enabled = 0;
         AssignProp("", false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), true);
         edtVeiculoMarca_Enabled = 0;
         AssignProp("", false, edtVeiculoMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoMarca_Enabled), 5, 0), true);
         edtVeiculoModelo_Enabled = 0;
         AssignProp("", false, edtVeiculoModelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoModelo_Enabled), 5, 0), true);
         edtVeiculoPlaca_Enabled = 0;
         AssignProp("", false, edtVeiculoPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoPlaca_Enabled), 5, 0), true);
         edtVeiculoCor_Enabled = 0;
         AssignProp("", false, edtVeiculoCor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoCor_Enabled), 5, 0), true);
         edtVeiculoAno_Enabled = 0;
         AssignProp("", false, edtVeiculoAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoAno_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tveiculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV8VeiculoId,12,0))}, new string[] {"Gx_mode","EmpresaId","VeiculoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TVeiculo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tveiculo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10VeiculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10VeiculoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z11VeiculoMarca", Z11VeiculoMarca);
         GxWebStd.gx_hidden_field( context, "Z12VeiculoModelo", Z12VeiculoModelo);
         GxWebStd.gx_hidden_field( context, "Z13VeiculoPlaca", StringUtil.RTrim( Z13VeiculoPlaca));
         GxWebStd.gx_hidden_field( context, "Z14VeiculoCor", StringUtil.RTrim( Z14VeiculoCor));
         GxWebStd.gx_hidden_field( context, "Z15VeiculoAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15VeiculoAno), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vVEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8VeiculoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVEICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8VeiculoId), "ZZZZZZZZZZZ9"), context));
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
         return formatLink("tveiculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV8VeiculoId,12,0))}, new string[] {"Gx_mode","EmpresaId","VeiculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "TVeiculo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Veículos" ;
      }

      protected void InitializeNonKey033( )
      {
         A11VeiculoMarca = "";
         AssignAttri("", false, "A11VeiculoMarca", A11VeiculoMarca);
         A12VeiculoModelo = "";
         AssignAttri("", false, "A12VeiculoModelo", A12VeiculoModelo);
         A13VeiculoPlaca = "";
         AssignAttri("", false, "A13VeiculoPlaca", A13VeiculoPlaca);
         A14VeiculoCor = "";
         AssignAttri("", false, "A14VeiculoCor", A14VeiculoCor);
         A15VeiculoAno = 0;
         AssignAttri("", false, "A15VeiculoAno", StringUtil.LTrimStr( (decimal)(A15VeiculoAno), 4, 0));
         A2EmpresaNome = "";
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         Z11VeiculoMarca = "";
         Z12VeiculoModelo = "";
         Z13VeiculoPlaca = "";
         Z14VeiculoCor = "";
         Z15VeiculoAno = 0;
      }

      protected void InitAll033( )
      {
         A1EmpresaId = 0;
         AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         A10VeiculoId = 0;
         AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         InitializeNonKey033( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20244261714551", true, true);
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
         context.AddJavascriptSource("tveiculo.js", "?20244261714551", false, true);
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
         edtVeiculoId_Internalname = "VEICULOID";
         edtVeiculoMarca_Internalname = "VEICULOMARCA";
         edtVeiculoModelo_Internalname = "VEICULOMODELO";
         edtVeiculoPlaca_Internalname = "VEICULOPLACA";
         edtVeiculoCor_Internalname = "VEICULOCOR";
         edtVeiculoAno_Internalname = "VEICULOANO";
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
         Form.Caption = "Veículos";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtVeiculoAno_Jsonclick = "";
         edtVeiculoAno_Enabled = 1;
         edtVeiculoCor_Jsonclick = "";
         edtVeiculoCor_Enabled = 1;
         edtVeiculoPlaca_Jsonclick = "";
         edtVeiculoPlaca_Enabled = 1;
         edtVeiculoModelo_Jsonclick = "";
         edtVeiculoModelo_Enabled = 1;
         edtVeiculoMarca_Jsonclick = "";
         edtVeiculoMarca_Enabled = 1;
         edtVeiculoId_Jsonclick = "";
         edtVeiculoId_Enabled = 0;
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

      protected void GX3ASAVEICULOID033( long AV8VeiculoId ,
                                         long AV7EmpresaId )
      {
         if ( ! (0==AV8VeiculoId) )
         {
            A10VeiculoId = AV8VeiculoId;
            AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         }
         else
         {
            if ( (0==AV8VeiculoId) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               GXt_int1 = A10VeiculoId;
               new pseqveiculo(context ).execute(  AV7EmpresaId, out  GXt_int1) ;
               A10VeiculoId = GXt_int1;
               AssignAttri("", false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")))+"\"") ;
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
         /* Using cursor T000313 */
         pr_default.execute(11, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'TEmpresa'.", "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
         }
         A2EmpresaNome = T000313_A2EmpresaNome[0];
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV8VeiculoId","fld":"vVEICULOID","pic":"ZZZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV8VeiculoId","fld":"vVEICULOID","pic":"ZZZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12032","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_EMPRESAID","""{"handler":"Valid_Empresaid","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A2EmpresaNome","fld":"EMPRESANOME"}]""");
         setEventMetadata("VALID_EMPRESAID",""","oparms":[{"av":"A2EmpresaNome","fld":"EMPRESANOME"}]}""");
         setEventMetadata("VALID_VEICULOID","""{"handler":"Valid_Veiculoid","iparms":[]}""");
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
         Z11VeiculoMarca = "";
         Z12VeiculoModelo = "";
         Z13VeiculoPlaca = "";
         Z14VeiculoCor = "";
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
         A11VeiculoMarca = "";
         A12VeiculoModelo = "";
         A13VeiculoPlaca = "";
         A14VeiculoCor = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z2EmpresaNome = "";
         T00034_A2EmpresaNome = new string[] {""} ;
         T00035_A10VeiculoId = new long[1] ;
         T00035_A11VeiculoMarca = new string[] {""} ;
         T00035_A12VeiculoModelo = new string[] {""} ;
         T00035_A13VeiculoPlaca = new string[] {""} ;
         T00035_A14VeiculoCor = new string[] {""} ;
         T00035_A15VeiculoAno = new short[1] ;
         T00035_A2EmpresaNome = new string[] {""} ;
         T00035_A1EmpresaId = new long[1] ;
         T00036_A2EmpresaNome = new string[] {""} ;
         T00037_A1EmpresaId = new long[1] ;
         T00037_A10VeiculoId = new long[1] ;
         T00033_A10VeiculoId = new long[1] ;
         T00033_A11VeiculoMarca = new string[] {""} ;
         T00033_A12VeiculoModelo = new string[] {""} ;
         T00033_A13VeiculoPlaca = new string[] {""} ;
         T00033_A14VeiculoCor = new string[] {""} ;
         T00033_A15VeiculoAno = new short[1] ;
         T00033_A1EmpresaId = new long[1] ;
         T00038_A1EmpresaId = new long[1] ;
         T00038_A10VeiculoId = new long[1] ;
         T00039_A1EmpresaId = new long[1] ;
         T00039_A10VeiculoId = new long[1] ;
         T00032_A10VeiculoId = new long[1] ;
         T00032_A11VeiculoMarca = new string[] {""} ;
         T00032_A12VeiculoModelo = new string[] {""} ;
         T00032_A13VeiculoPlaca = new string[] {""} ;
         T00032_A14VeiculoCor = new string[] {""} ;
         T00032_A15VeiculoAno = new short[1] ;
         T00032_A1EmpresaId = new long[1] ;
         T000313_A2EmpresaNome = new string[] {""} ;
         T000314_A1EmpresaId = new long[1] ;
         T000314_A16RegistroPedidoId = new long[1] ;
         T000315_A1EmpresaId = new long[1] ;
         T000315_A10VeiculoId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tveiculo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tveiculo__default(),
            new Object[][] {
                new Object[] {
               T00032_A10VeiculoId, T00032_A11VeiculoMarca, T00032_A12VeiculoModelo, T00032_A13VeiculoPlaca, T00032_A14VeiculoCor, T00032_A15VeiculoAno, T00032_A1EmpresaId
               }
               , new Object[] {
               T00033_A10VeiculoId, T00033_A11VeiculoMarca, T00033_A12VeiculoModelo, T00033_A13VeiculoPlaca, T00033_A14VeiculoCor, T00033_A15VeiculoAno, T00033_A1EmpresaId
               }
               , new Object[] {
               T00034_A2EmpresaNome
               }
               , new Object[] {
               T00035_A10VeiculoId, T00035_A11VeiculoMarca, T00035_A12VeiculoModelo, T00035_A13VeiculoPlaca, T00035_A14VeiculoCor, T00035_A15VeiculoAno, T00035_A2EmpresaNome, T00035_A1EmpresaId
               }
               , new Object[] {
               T00036_A2EmpresaNome
               }
               , new Object[] {
               T00037_A1EmpresaId, T00037_A10VeiculoId
               }
               , new Object[] {
               T00038_A1EmpresaId, T00038_A10VeiculoId
               }
               , new Object[] {
               T00039_A1EmpresaId, T00039_A10VeiculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000313_A2EmpresaNome
               }
               , new Object[] {
               T000314_A1EmpresaId, T000314_A16RegistroPedidoId
               }
               , new Object[] {
               T000315_A1EmpresaId, T000315_A10VeiculoId
               }
            }
         );
         AV12Pgmname = "TVeiculo";
      }

      private short Z15VeiculoAno ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A15VeiculoAno ;
      private short RcdFound3 ;
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
      private int edtVeiculoId_Enabled ;
      private int edtVeiculoMarca_Enabled ;
      private int edtVeiculoModelo_Enabled ;
      private int edtVeiculoPlaca_Enabled ;
      private int edtVeiculoCor_Enabled ;
      private int edtVeiculoAno_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long wcpOAV7EmpresaId ;
      private long wcpOAV8VeiculoId ;
      private long Z1EmpresaId ;
      private long Z10VeiculoId ;
      private long AV8VeiculoId ;
      private long AV7EmpresaId ;
      private long A1EmpresaId ;
      private long A10VeiculoId ;
      private long GXt_int1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z13VeiculoPlaca ;
      private string Z14VeiculoCor ;
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
      private string edtVeiculoId_Internalname ;
      private string edtVeiculoId_Jsonclick ;
      private string edtVeiculoMarca_Internalname ;
      private string edtVeiculoMarca_Jsonclick ;
      private string edtVeiculoModelo_Internalname ;
      private string edtVeiculoModelo_Jsonclick ;
      private string edtVeiculoPlaca_Internalname ;
      private string A13VeiculoPlaca ;
      private string edtVeiculoPlaca_Jsonclick ;
      private string edtVeiculoCor_Internalname ;
      private string A14VeiculoCor ;
      private string edtVeiculoCor_Jsonclick ;
      private string edtVeiculoAno_Internalname ;
      private string edtVeiculoAno_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV12Pgmname ;
      private string hsh ;
      private string sMode3 ;
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
      private string Z11VeiculoMarca ;
      private string Z12VeiculoModelo ;
      private string A2EmpresaNome ;
      private string A11VeiculoMarca ;
      private string A12VeiculoModelo ;
      private string Z2EmpresaNome ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] T00034_A2EmpresaNome ;
      private long[] T00035_A10VeiculoId ;
      private string[] T00035_A11VeiculoMarca ;
      private string[] T00035_A12VeiculoModelo ;
      private string[] T00035_A13VeiculoPlaca ;
      private string[] T00035_A14VeiculoCor ;
      private short[] T00035_A15VeiculoAno ;
      private string[] T00035_A2EmpresaNome ;
      private long[] T00035_A1EmpresaId ;
      private string[] T00036_A2EmpresaNome ;
      private long[] T00037_A1EmpresaId ;
      private long[] T00037_A10VeiculoId ;
      private long[] T00033_A10VeiculoId ;
      private string[] T00033_A11VeiculoMarca ;
      private string[] T00033_A12VeiculoModelo ;
      private string[] T00033_A13VeiculoPlaca ;
      private string[] T00033_A14VeiculoCor ;
      private short[] T00033_A15VeiculoAno ;
      private long[] T00033_A1EmpresaId ;
      private long[] T00038_A1EmpresaId ;
      private long[] T00038_A10VeiculoId ;
      private long[] T00039_A1EmpresaId ;
      private long[] T00039_A10VeiculoId ;
      private long[] T00032_A10VeiculoId ;
      private string[] T00032_A11VeiculoMarca ;
      private string[] T00032_A12VeiculoModelo ;
      private string[] T00032_A13VeiculoPlaca ;
      private string[] T00032_A14VeiculoCor ;
      private short[] T00032_A15VeiculoAno ;
      private long[] T00032_A1EmpresaId ;
      private string[] T000313_A2EmpresaNome ;
      private long[] T000314_A1EmpresaId ;
      private long[] T000314_A16RegistroPedidoId ;
      private long[] T000315_A1EmpresaId ;
      private long[] T000315_A10VeiculoId ;
      private IDataStoreProvider pr_gam ;
   }

   public class tveiculo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tveiculo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00032;
        prmT00032 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT00033;
        prmT00033 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT00034;
        prmT00034 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT00035;
        prmT00035 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT00036;
        prmT00036 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT00037;
        prmT00037 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT00038;
        prmT00038 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT00039;
        prmT00039 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT000310;
        prmT000310 = new Object[] {
        new ParDef("@VeiculoId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoMarca",GXType.NVarChar,20,0) ,
        new ParDef("@VeiculoModelo",GXType.NVarChar,10,0) ,
        new ParDef("@VeiculoPlaca",GXType.NChar,7,0) ,
        new ParDef("@VeiculoCor",GXType.NChar,10,0) ,
        new ParDef("@VeiculoAno",GXType.Int16,4,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000311;
        prmT000311 = new Object[] {
        new ParDef("@VeiculoMarca",GXType.NVarChar,20,0) ,
        new ParDef("@VeiculoModelo",GXType.NVarChar,10,0) ,
        new ParDef("@VeiculoPlaca",GXType.NChar,7,0) ,
        new ParDef("@VeiculoCor",GXType.NChar,10,0) ,
        new ParDef("@VeiculoAno",GXType.Int16,4,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT000312;
        prmT000312 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT000313;
        prmT000313 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0)
        };
        Object[] prmT000314;
        prmT000314 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
        new ParDef("@VeiculoId",GXType.Decimal,12,0)
        };
        Object[] prmT000315;
        prmT000315 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00032", "SELECT [VeiculoId], [VeiculoMarca], [VeiculoModelo], [VeiculoPlaca], [VeiculoCor], [VeiculoAno], [EmpresaId] FROM [TVeiculo] WITH (UPDLOCK) WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00033", "SELECT [VeiculoId], [VeiculoMarca], [VeiculoModelo], [VeiculoPlaca], [VeiculoCor], [VeiculoAno], [EmpresaId] FROM [TVeiculo] WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00034", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00035", "SELECT TM1.[VeiculoId], TM1.[VeiculoMarca], TM1.[VeiculoModelo], TM1.[VeiculoPlaca], TM1.[VeiculoCor], TM1.[VeiculoAno], T2.[EmpresaNome], TM1.[EmpresaId] FROM ([TVeiculo] TM1 INNER JOIN [TEmpresa] T2 ON T2.[EmpresaId] = TM1.[EmpresaId]) WHERE TM1.[EmpresaId] = @EmpresaId and TM1.[VeiculoId] = @VeiculoId ORDER BY TM1.[EmpresaId], TM1.[VeiculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00036", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00037", "SELECT [EmpresaId], [VeiculoId] FROM [TVeiculo] WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00038", "SELECT TOP 1 [EmpresaId], [VeiculoId] FROM [TVeiculo] WHERE ( [EmpresaId] > @EmpresaId or [EmpresaId] = @EmpresaId and [VeiculoId] > @VeiculoId) ORDER BY [EmpresaId], [VeiculoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00039", "SELECT TOP 1 [EmpresaId], [VeiculoId] FROM [TVeiculo] WHERE ( [EmpresaId] < @EmpresaId or [EmpresaId] = @EmpresaId and [VeiculoId] < @VeiculoId) ORDER BY [EmpresaId] DESC, [VeiculoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000310", "INSERT INTO [TVeiculo]([VeiculoId], [VeiculoMarca], [VeiculoModelo], [VeiculoPlaca], [VeiculoCor], [VeiculoAno], [EmpresaId]) VALUES(@VeiculoId, @VeiculoMarca, @VeiculoModelo, @VeiculoPlaca, @VeiculoCor, @VeiculoAno, @EmpresaId)", GxErrorMask.GX_NOMASK,prmT000310)
           ,new CursorDef("T000311", "UPDATE [TVeiculo] SET [VeiculoMarca]=@VeiculoMarca, [VeiculoModelo]=@VeiculoModelo, [VeiculoPlaca]=@VeiculoPlaca, [VeiculoCor]=@VeiculoCor, [VeiculoAno]=@VeiculoAno  WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId", GxErrorMask.GX_NOMASK,prmT000311)
           ,new CursorDef("T000312", "DELETE FROM [TVeiculo]  WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId", GxErrorMask.GX_NOMASK,prmT000312)
           ,new CursorDef("T000313", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000314", "SELECT TOP 1 [EmpresaId], [RegistroPedidoId] FROM [TRegistroPedido] WHERE [EmpresaId] = @EmpresaId AND [VeiculoId] = @VeiculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000315", "SELECT [EmpresaId], [VeiculoId] FROM [TVeiculo] ORDER BY [EmpresaId], [VeiculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 7);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 7);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 7);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
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
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}
