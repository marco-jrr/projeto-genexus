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
   public class gamexampleregisteruser : GXHttpHandler
   {
      public gamexampleregisteruser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public gamexampleregisteruser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavEmpresaid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            ValidateSpaRequest();
            PA122( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS122( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE122( ) ;
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Register user ") ;
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
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamexampleregisteruser.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
         GxWebStd.gx_hidden_field( context, "vNOVOREGISTRO", StringUtil.RTrim( AV26NovoRegistro));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOVOREGISTRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26NovoRegistro, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
         GxWebStd.gx_hidden_field( context, "vNOVOREGISTRO", StringUtil.RTrim( AV26NovoRegistro));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOVOREGISTRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26NovoRegistro, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV16Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV16Messages);
         }
      }

      protected void RenderHtmlCloseForm122( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "GAMExampleRegisterUser" ;
      }

      public override string GetPgmdesc( )
      {
         return "Register user " ;
      }

      protected void WB120( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbpwd_Internalname, 1, 0, "px", 0, "px", "table-login stack-top-xxl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-xl", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbtitle_Internalname, "Register", "", "", lblTbtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbhaveaccount_Internalname, "Already have an account?", "", "", lblTbhaveaccount_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTblogin_Internalname, "Login", "", "", lblTblogin_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11121_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 0, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-xl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavName_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Username  *", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV17Name, StringUtil.RTrim( context.localUtil.Format( AV17Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", edtavName_Visible, edtavName_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, edtavEmail_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV7EMail, StringUtil.RTrim( context.localUtil.Format( AV7EMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmail_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPassword_Internalname, edtavPassword_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPassword_Internalname, StringUtil.RTrim( AV18Password), StringUtil.RTrim( context.localUtil.Format( AV18Password, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPassword_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPassword_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbpwdrequirements_Internalname, lblTbpwdrequirements_Caption, "", "", lblTbpwdrequirements_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "text-helper-gray", 0, "", 1, 1, 0, 1, "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPasswordconf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPasswordconf_Internalname, edtavPasswordconf_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPasswordconf_Internalname, StringUtil.RTrim( AV19PasswordConf), StringUtil.RTrim( context.localUtil.Format( AV19PasswordConf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPasswordconf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPasswordconf_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, edtavFirstname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, StringUtil.RTrim( AV9FirstName), StringUtil.RTrim( context.localUtil.Format( AV9FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFirstname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, edtavLastname_Caption, "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, StringUtil.RTrim( AV13LastName), StringUtil.RTrim( context.localUtil.Format( AV13LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLastname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynavEmpresaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEmpresaid_Internalname, "Empresa", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEmpresaid, dynavEmpresaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24EmpresaId), 12, 0)), 1, dynavEmpresaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEmpresaid.Enabled, 1, 0, 60, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_GAMExampleRegisterUser.htm");
            dynavEmpresaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24EmpresaId), 12, 0));
            AssignProp("", false, dynavEmpresaid_Internalname, "Values", (string)(dynavEmpresaid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-xl", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Button Primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "", "Criar Usuário", bttLogin_Jsonclick, 5, "Criar Usuário", "", StyleString, ClassString, bttLogin_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleRegisterUser.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START122( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_9-182098", 0) ;
            }
         }
         Form.Meta.addItem("description", "Register user ", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP120( ) ;
      }

      protected void WS122( )
      {
         START122( ) ;
         EVT122( ) ;
      }

      protected void EVT122( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E12122 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                                 /* Execute user event: Enter */
                                 E13122 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E14122 ();
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
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

      protected void WE122( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm122( ) ;
            }
         }
      }

      protected void PA122( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvEMPRESAID121( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvEMPRESAID_data121( ) ;
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

      protected void GXVvEMPRESAID_html121( )
      {
         long gxdynajaxvalue;
         GXDLVvEMPRESAID_data121( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEmpresaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavEmpresaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 12, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavEmpresaid.ItemCount > 0 )
         {
            AV24EmpresaId = (long)(Math.Round(NumberUtil.Val( dynavEmpresaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24EmpresaId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24EmpresaId", StringUtil.LTrimStr( (decimal)(AV24EmpresaId), 12, 0));
         }
      }

      protected void GXDLVvEMPRESAID_data121( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00122 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00122_A1EmpresaId[0]), 12, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00122_A2EmpresaNome[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavEmpresaid.Name = "vEMPRESAID";
            dynavEmpresaid.WebTags = "";
            dynavEmpresaid.removeAllItems();
            /* Using cursor H00123 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               dynavEmpresaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00123_A1EmpresaId[0]), 12, 0)), H00123_A2EmpresaNome[0], 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( dynavEmpresaid.ItemCount > 0 )
            {
               AV24EmpresaId = (long)(Math.Round(NumberUtil.Val( dynavEmpresaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24EmpresaId), 12, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24EmpresaId", StringUtil.LTrimStr( (decimal)(AV24EmpresaId), 12, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEmpresaid.ItemCount > 0 )
         {
            AV24EmpresaId = (long)(Math.Round(NumberUtil.Val( dynavEmpresaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24EmpresaId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24EmpresaId", StringUtil.LTrimStr( (decimal)(AV24EmpresaId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEmpresaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24EmpresaId), 12, 0));
            AssignProp("", false, dynavEmpresaid_Internalname, "Values", dynavEmpresaid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF122( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF122( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14122 ();
            WB120( ) ;
         }
      }

      protected void send_integrity_lvl_hashes122( )
      {
         GxWebStd.gx_hidden_field( context, "vBIRTHDAY", context.localUtil.DToC( AV6Birthday, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vBIRTHDAY", GetSecureSignedToken( "", AV6Birthday, context));
         GxWebStd.gx_hidden_field( context, "vGENDER", StringUtil.RTrim( AV12Gender));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENDER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12Gender, "")), context));
         GxWebStd.gx_hidden_field( context, "vNOVOREGISTRO", StringUtil.RTrim( AV26NovoRegistro));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOVOREGISTRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26NovoRegistro, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP120( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12122 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV17Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV17Name", AV17Name);
            AV7EMail = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV7EMail", AV7EMail);
            AV18Password = cgiGet( edtavPassword_Internalname);
            AssignAttri("", false, "AV18Password", AV18Password);
            AV19PasswordConf = cgiGet( edtavPasswordconf_Internalname);
            AssignAttri("", false, "AV19PasswordConf", AV19PasswordConf);
            AV9FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV9FirstName", AV9FirstName);
            AV13LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV13LastName", AV13LastName);
            dynavEmpresaid.CurrentValue = cgiGet( dynavEmpresaid_Internalname);
            AV24EmpresaId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynavEmpresaid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24EmpresaId", StringUtil.LTrimStr( (decimal)(AV24EmpresaId), 12, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12122 ();
         if (returnInSub) return;
      }

      protected void E12122( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_char1 = "";
         new gam_gettextpasswordrequirement(context ).execute( out  GXt_char1) ;
         lblTbpwdrequirements_Caption = GXt_char1;
         AssignProp("", false, lblTbpwdrequirements_Internalname, "Caption", lblTbpwdrequirements_Caption, true);
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV10GAMRepository.gxTpr_Useridentification, "email") == 0 )
         {
            edtavName_Visible = 0;
            AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'MARKREQUIEREDUSERDATA' */
         S112 ();
         if (returnInSub) return;
         AV26NovoRegistro = AV25WebSession.Get("NovoRegistro");
         AssignAttri("", false, "AV26NovoRegistro", AV26NovoRegistro);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOVOREGISTRO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26NovoRegistro, "")), context));
         if ( ( NumberUtil.Val( AV25WebSession.Get("EmpresaId"), ".") > Convert.ToDecimal( 0 )) )
         {
            AV24EmpresaId = (long)(Math.Round(NumberUtil.Val( AV25WebSession.Get("EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24EmpresaId", StringUtil.LTrimStr( (decimal)(AV24EmpresaId), 12, 0));
            dynavEmpresaid.Enabled = 0;
            AssignProp("", false, dynavEmpresaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavEmpresaid.Enabled), 5, 0), true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E13122 ();
         if (returnInSub) return;
      }

      protected void E13122( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV18Password, AV19PasswordConf) == 0 )
         {
            AV11GAMUser.gxTpr_Name = AV17Name;
            AV11GAMUser.gxTpr_Email = AV7EMail;
            AV11GAMUser.gxTpr_Firstname = AV9FirstName;
            AV11GAMUser.gxTpr_Lastname = AV13LastName;
            AV11GAMUser.gxTpr_Birthday = AV6Birthday;
            AV11GAMUser.gxTpr_Gender = AV12Gender;
            AV11GAMUser.gxTpr_Password = AV18Password;
            AV11GAMUser.save();
            if ( AV11GAMUser.success() )
            {
               new pcadastrausuario(context ).execute(  AV24EmpresaId,  AV17Name,  AV7EMail,  AV18Password) ;
               context.CommitDataStores("gamexampleregisteruser",pr_default);
               if ( StringUtil.StrCmp(AV10GAMRepository.gxTpr_Useractivationmethod, "A") == 0 )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17Name)) )
                  {
                     AV17Name = AV7EMail;
                     AssignAttri("", false, "AV17Name", AV17Name);
                  }
                  AV15LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV17Name, AV18Password, AV5GAMLoginAdditionalParameters, out  AV22GAMErrorCollection);
                  if ( AV15LoginOK )
                  {
                     if ( StringUtil.StrCmp(AV26NovoRegistro, "S") == 0 )
                     {
                        CallWebObject(formatLink("wwtcliente.aspx") );
                        context.wjLocDisableFrm = 1;
                     }
                     else
                     {
                        CallWebObject(formatLink("developermenu.html") );
                        context.wjLocDisableFrm = 0;
                     }
                  }
                  else
                  {
                     /* Execute user subroutine: 'DISPLAYMESSAGES' */
                     S122 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  AV14LinkURL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).applicationgetaccountactivationurl("");
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14LinkURL)) )
                  {
                     GXt_char1 = AV14LinkURL;
                     new gam_buildappurl(context ).execute(  "gam_activateuseraccount", out  GXt_char1) ;
                     AV14LinkURL = GXt_char1;
                     AV14LinkURL += "%1";
                  }
                  new gam_checkuseractivationmethod(context ).execute(  AV11GAMUser.gxTpr_Guid,  AV14LinkURL, out  AV16Messages) ;
                  AV21isRegisterError = false;
                  AV27GXV1 = 1;
                  while ( AV27GXV1 <= AV16Messages.Count )
                  {
                     AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV16Messages.Item(AV27GXV1));
                     if ( AV20Message.gxTpr_Type == 1 )
                     {
                        AV21isRegisterError = true;
                        if (true) break;
                     }
                     AV27GXV1 = (int)(AV27GXV1+1);
                  }
                  if ( ! AV21isRegisterError )
                  {
                     edtavName_Enabled = 0;
                     AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
                     edtavEmail_Enabled = 0;
                     AssignProp("", false, edtavEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEmail_Enabled), 5, 0), true);
                     edtavPassword_Enabled = 0;
                     AssignProp("", false, edtavPassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPassword_Enabled), 5, 0), true);
                     edtavPasswordconf_Enabled = 0;
                     AssignProp("", false, edtavPasswordconf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPasswordconf_Enabled), 5, 0), true);
                     edtavFirstname_Enabled = 0;
                     AssignProp("", false, edtavFirstname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFirstname_Enabled), 5, 0), true);
                     edtavLastname_Enabled = 0;
                     AssignProp("", false, edtavLastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLastname_Enabled), 5, 0), true);
                     bttLogin_Visible = 0;
                     AssignProp("", false, bttLogin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttLogin_Visible), 5, 0), true);
                  }
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               AV22GAMErrorCollection = AV11GAMUser.geterrors();
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
         }
         else
         {
            GX_msglist.addItem("The password and confirmation password do not match.");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GAMRepository", AV10GAMRepository);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GAMUser", AV11GAMUser);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16Messages", AV16Messages);
      }

      protected void S112( )
      {
         /* 'MARKREQUIEREDUSERDATA' Routine */
         returnInSub = false;
         if ( AV10GAMRepository.gxTpr_Requiredemail )
         {
            edtavEmail_Caption = edtavEmail_Caption+"  *";
            AssignProp("", false, edtavEmail_Internalname, "Caption", edtavEmail_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredfirstname )
         {
            edtavFirstname_Caption = edtavFirstname_Caption+"  *";
            AssignProp("", false, edtavFirstname_Internalname, "Caption", edtavFirstname_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredlastname )
         {
            edtavLastname_Caption = edtavLastname_Caption+" *";
            AssignProp("", false, edtavLastname_Internalname, "Caption", edtavLastname_Caption, true);
         }
         if ( AV10GAMRepository.gxTpr_Requiredpassword )
         {
            edtavPassword_Caption = edtavPassword_Caption+"  *";
            AssignProp("", false, edtavPassword_Internalname, "Caption", edtavPassword_Caption, true);
            edtavPasswordconf_Caption = edtavPasswordconf_Caption+"  *";
            AssignProp("", false, edtavPasswordconf_Internalname, "Caption", edtavPasswordconf_Caption, true);
         }
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV28GXV2 = 1;
         while ( AV28GXV2 <= AV16Messages.Count )
         {
            AV20Message = ((GeneXus.Utils.SdtMessages_Message)AV16Messages.Item(AV28GXV2));
            GX_msglist.addItem(AV20Message.gxTpr_Description);
            AV28GXV2 = (int)(AV28GXV2+1);
         }
         AV29GXV3 = 1;
         while ( AV29GXV3 <= AV22GAMErrorCollection.Count )
         {
            AV23GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV22GAMErrorCollection.Item(AV29GXV3));
            GX_msglist.addItem(AV23GAMError.gxTpr_Message);
            AV29GXV3 = (int)(AV29GXV3+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14122( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA122( ) ;
         WS122( ) ;
         WE122( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202442617152126", true, true);
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
         context.AddJavascriptSource("gamexampleregisteruser.js", "?202442617152129", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavEmpresaid.Name = "vEMPRESAID";
         dynavEmpresaid.WebTags = "";
         dynavEmpresaid.removeAllItems();
         /* Using cursor H00124 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            dynavEmpresaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00124_A1EmpresaId[0]), 12, 0)), H00124_A2EmpresaNome[0], 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( dynavEmpresaid.ItemCount > 0 )
         {
            AV24EmpresaId = (long)(Math.Round(NumberUtil.Val( dynavEmpresaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24EmpresaId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24EmpresaId", StringUtil.LTrimStr( (decimal)(AV24EmpresaId), 12, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTbtitle_Internalname = "TBTITLE";
         lblTbhaveaccount_Internalname = "TBHAVEACCOUNT";
         lblTblogin_Internalname = "TBLOGIN";
         edtavName_Internalname = "vNAME";
         edtavEmail_Internalname = "vEMAIL";
         edtavPassword_Internalname = "vPASSWORD";
         lblTbpwdrequirements_Internalname = "TBPWDREQUIREMENTS";
         edtavPasswordconf_Internalname = "vPASSWORDCONF";
         edtavFirstname_Internalname = "vFIRSTNAME";
         edtavLastname_Internalname = "vLASTNAME";
         dynavEmpresaid_Internalname = "vEMPRESAID";
         bttLogin_Internalname = "LOGIN";
         divTbpwd_Internalname = "TBPWD";
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
         bttLogin_Jsonclick = "";
         bttLogin_Visible = 1;
         dynavEmpresaid_Jsonclick = "";
         dynavEmpresaid.Enabled = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         edtavLastname_Caption = "Last Name";
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         edtavFirstname_Caption = "First Name";
         edtavPasswordconf_Jsonclick = "";
         edtavPasswordconf_Enabled = 1;
         edtavPasswordconf_Caption = "Confirm Password";
         lblTbpwdrequirements_Caption = "";
         edtavPassword_Jsonclick = "";
         edtavPassword_Enabled = 1;
         edtavPassword_Caption = "Password";
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavEmail_Caption = "Email";
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavName_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"dynavEmpresaid"},{"av":"AV24EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"AV6Birthday","fld":"vBIRTHDAY","hsh":true},{"av":"AV12Gender","fld":"vGENDER","hsh":true},{"av":"AV26NovoRegistro","fld":"vNOVOREGISTRO","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E13122","iparms":[{"av":"AV18Password","fld":"vPASSWORD"},{"av":"AV19PasswordConf","fld":"vPASSWORDCONF"},{"av":"AV17Name","fld":"vNAME"},{"av":"AV7EMail","fld":"vEMAIL"},{"av":"AV9FirstName","fld":"vFIRSTNAME"},{"av":"AV13LastName","fld":"vLASTNAME"},{"av":"AV6Birthday","fld":"vBIRTHDAY","hsh":true},{"av":"AV12Gender","fld":"vGENDER","hsh":true},{"av":"dynavEmpresaid"},{"av":"AV24EmpresaId","fld":"vEMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"AV26NovoRegistro","fld":"vNOVOREGISTRO","hsh":true},{"av":"AV16Messages","fld":"vMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV17Name","fld":"vNAME"},{"av":"AV16Messages","fld":"vMESSAGES"},{"av":"edtavName_Enabled","ctrl":"vNAME","prop":"Enabled"},{"av":"edtavEmail_Enabled","ctrl":"vEMAIL","prop":"Enabled"},{"av":"edtavPassword_Enabled","ctrl":"vPASSWORD","prop":"Enabled"},{"av":"edtavPasswordconf_Enabled","ctrl":"vPASSWORDCONF","prop":"Enabled"},{"av":"edtavFirstname_Enabled","ctrl":"vFIRSTNAME","prop":"Enabled"},{"av":"edtavLastname_Enabled","ctrl":"vLASTNAME","prop":"Enabled"},{"ctrl":"TBLOGIN","prop":"Visible"}]}""");
         setEventMetadata("'LOGIN'","""{"handler":"E11121","iparms":[]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV6Birthday = DateTime.MinValue;
         AV12Gender = "";
         AV26NovoRegistro = "";
         GXKey = "";
         AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         sPrefix = "";
         lblTbtitle_Jsonclick = "";
         lblTbhaveaccount_Jsonclick = "";
         lblTblogin_Jsonclick = "";
         TempTags = "";
         AV17Name = "";
         AV7EMail = "";
         AV18Password = "";
         lblTbpwdrequirements_Jsonclick = "";
         AV19PasswordConf = "";
         AV9FirstName = "";
         AV13LastName = "";
         ClassString = "";
         StyleString = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00122_A1EmpresaId = new long[1] ;
         H00122_A2EmpresaNome = new string[] {""} ;
         H00123_A1EmpresaId = new long[1] ;
         H00123_A2EmpresaNome = new string[] {""} ;
         AV10GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV25WebSession = context.GetSession();
         AV11GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV5GAMLoginAdditionalParameters = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV22GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV14LinkURL = "";
         GXt_char1 = "";
         AV20Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV23GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H00124_A1EmpresaId = new long[1] ;
         H00124_A2EmpresaNome = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamexampleregisteruser__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamexampleregisteruser__default(),
            new Object[][] {
                new Object[] {
               H00122_A1EmpresaId, H00122_A2EmpresaNome
               }
               , new Object[] {
               H00123_A1EmpresaId, H00123_A2EmpresaNome
               }
               , new Object[] {
               H00124_A1EmpresaId, H00124_A2EmpresaNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavName_Visible ;
      private int edtavName_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavPassword_Enabled ;
      private int edtavPasswordconf_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavLastname_Enabled ;
      private int bttLogin_Visible ;
      private int gxdynajaxindex ;
      private int AV27GXV1 ;
      private int AV28GXV2 ;
      private int AV29GXV3 ;
      private int idxLst ;
      private long AV24EmpresaId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV12Gender ;
      private string AV26NovoRegistro ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divTbpwd_Internalname ;
      private string lblTbtitle_Internalname ;
      private string lblTbtitle_Jsonclick ;
      private string lblTbhaveaccount_Internalname ;
      private string lblTbhaveaccount_Jsonclick ;
      private string lblTblogin_Internalname ;
      private string lblTblogin_Jsonclick ;
      private string edtavName_Internalname ;
      private string TempTags ;
      private string edtavName_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Caption ;
      private string edtavEmail_Jsonclick ;
      private string edtavPassword_Internalname ;
      private string edtavPassword_Caption ;
      private string AV18Password ;
      private string edtavPassword_Jsonclick ;
      private string lblTbpwdrequirements_Internalname ;
      private string lblTbpwdrequirements_Caption ;
      private string lblTbpwdrequirements_Jsonclick ;
      private string edtavPasswordconf_Internalname ;
      private string edtavPasswordconf_Caption ;
      private string AV19PasswordConf ;
      private string edtavPasswordconf_Jsonclick ;
      private string edtavFirstname_Internalname ;
      private string edtavFirstname_Caption ;
      private string AV9FirstName ;
      private string edtavFirstname_Jsonclick ;
      private string edtavLastname_Internalname ;
      private string edtavLastname_Caption ;
      private string AV13LastName ;
      private string edtavLastname_Jsonclick ;
      private string dynavEmpresaid_Internalname ;
      private string dynavEmpresaid_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttLogin_Internalname ;
      private string bttLogin_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string GXt_char1 ;
      private DateTime AV6Birthday ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15LoginOK ;
      private bool AV21isRegisterError ;
      private string AV17Name ;
      private string AV7EMail ;
      private string AV14LinkURL ;
      private IGxSession AV25WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavEmpresaid ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16Messages ;
      private IDataStoreProvider pr_default ;
      private long[] H00122_A1EmpresaId ;
      private string[] H00122_A2EmpresaNome ;
      private long[] H00123_A1EmpresaId ;
      private string[] H00123_A2EmpresaNome ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV10GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV11GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5GAMLoginAdditionalParameters ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrorCollection ;
      private GeneXus.Utils.SdtMessages_Message AV20Message ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV23GAMError ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H00124_A1EmpresaId ;
      private string[] H00124_A2EmpresaNome ;
      private IDataStoreProvider pr_gam ;
   }

   public class gamexampleregisteruser__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamexampleregisteruser__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH00122;
        prmH00122 = new Object[] {
        };
        Object[] prmH00123;
        prmH00123 = new Object[] {
        };
        Object[] prmH00124;
        prmH00124 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H00122", "SELECT [EmpresaId], [EmpresaNome] FROM [TEmpresa] ORDER BY [EmpresaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00122,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00123", "SELECT [EmpresaId], [EmpresaNome] FROM [TEmpresa] ORDER BY [EmpresaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00123,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00124", "SELECT [EmpresaId], [EmpresaNome] FROM [TEmpresa] ORDER BY [EmpresaNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00124,0, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
