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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class tregistropedidogeneral : GXWebComponent
   {
      public tregistropedidogeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("ProjetoFrotas", true);
         }
      }

      public tregistropedidogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmpresaId ,
                           long aP1_RegistroPedidoId )
      {
         this.A1EmpresaId = aP0_EmpresaId;
         this.A16RegistroPedidoId = aP1_RegistroPedidoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "EmpresaId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
                  A16RegistroPedidoId = (long)(Math.Round(NumberUtil.Val( GetPar( "RegistroPedidoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A1EmpresaId,(long)A16RegistroPedidoId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "EmpresaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "EmpresaId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0M2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV12Pgmname = "TRegistroPedidoGeneral";
               /* Using cursor H000M2 */
               pr_default.execute(0, new Object[] {A1EmpresaId});
               A2EmpresaNome = H000M2_A2EmpresaNome[0];
               AssignAttri(sPrefix, false, "A2EmpresaNome", A2EmpresaNome);
               pr_default.close(0);
               WS0M2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "TRegistro Pedido General") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tregistropedidogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(A16RegistroPedidoId,12,0))}, new string[] {"EmpresaId","RegistroPedidoId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"TRegistroPedidoGeneral");
         forbiddenHiddens.Add("VeiculoId", context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tregistropedidogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA1EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA1EmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA16RegistroPedidoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA16RegistroPedidoId), 12, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0M2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "TRegistroPedidoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "TRegistro Pedido General" ;
      }

      protected void WB0M0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "tregistropedidogeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110m1_client"+"'", TempTags, "", 2, "HLP_TRegistroPedidoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120m1_client"+"'", TempTags, "", 2, "HLP_TRegistroPedidoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpresaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmpresaId_Internalname, "Empresa Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEmpresaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")), StringUtil.LTrim( ((edtEmpresaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpresaId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdAuto", "end", false, "", "HLP_TRegistroPedidoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtRegistroPedidoId_Internalname, "Pedido Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtRegistroPedidoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")), StringUtil.LTrim( ((edtRegistroPedidoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A16RegistroPedidoId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A16RegistroPedidoId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRegistroPedidoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtRegistroPedidoId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdManual", "end", false, "", "HLP_TRegistroPedidoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVeiculoId_Internalname, "Veiculo Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVeiculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")), StringUtil.LTrim( ((edtVeiculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVeiculoId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdManual", "end", false, "", "HLP_TRegistroPedidoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")), StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A5ClienteId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A5ClienteId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdManual", "end", false, "", "HLP_TRegistroPedidoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtDestino_Internalname, "Destino", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDestino_Internalname, StringUtil.RTrim( A17Destino), StringUtil.RTrim( context.localUtil.Format( A17Destino, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDestino_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtDestino_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TRegistroPedidoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtDataRetirada_Internalname, "Retirada", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtDataRetirada_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtDataRetirada_Internalname, context.localUtil.Format(A24DataRetirada, "99/99/9999"), context.localUtil.Format( A24DataRetirada, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataRetirada_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtDataRetirada_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TRegistroPedidoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtDataRetirada_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataRetirada_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TRegistroPedidoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtDataRetorno_Internalname, "Retorno", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtDataRetorno_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtDataRetorno_Internalname, context.localUtil.Format(A25DataRetorno, "99/99/9999"), context.localUtil.Format( A25DataRetorno, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataRetorno_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtDataRetorno_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TRegistroPedidoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtDataRetorno_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataRetorno_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TRegistroPedidoGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmpresaNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmpresaNome_Internalname, "Empresa Nome", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEmpresaNome_Internalname, A2EmpresaNome, StringUtil.RTrim( context.localUtil.Format( A2EmpresaNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtEmpresaNome_Link, "", "", "", edtEmpresaNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpresaNome_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TRegistroPedidoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVeiculoMarca_Internalname, "Veiculo Marca", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVeiculoMarca_Internalname, A11VeiculoMarca, StringUtil.RTrim( context.localUtil.Format( A11VeiculoMarca, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtVeiculoMarca_Link, "", "", "", edtVeiculoMarca_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVeiculoMarca_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TRegistroPedidoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0M2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_9-182098", 0) ;
               }
            }
            Form.Meta.addItem("description", "TRegistro Pedido General", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0M0( ) ;
            }
         }
      }

      protected void WS0M2( )
      {
         START0M2( ) ;
         EVT0M2( ) ;
      }

      protected void EVT0M2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
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
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
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
      }

      protected void WE0M2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0M2( ) ;
            }
         }
      }

      protected void PA0M2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV12Pgmname = "TRegistroPedidoGeneral";
      }

      protected void RF0M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000M3 */
            pr_default.execute(1, new Object[] {A1EmpresaId, A16RegistroPedidoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A11VeiculoMarca = H000M3_A11VeiculoMarca[0];
               AssignAttri(sPrefix, false, "A11VeiculoMarca", A11VeiculoMarca);
               A25DataRetorno = H000M3_A25DataRetorno[0];
               n25DataRetorno = H000M3_n25DataRetorno[0];
               AssignAttri(sPrefix, false, "A25DataRetorno", context.localUtil.Format(A25DataRetorno, "99/99/9999"));
               A24DataRetirada = H000M3_A24DataRetirada[0];
               AssignAttri(sPrefix, false, "A24DataRetirada", context.localUtil.Format(A24DataRetirada, "99/99/9999"));
               A17Destino = H000M3_A17Destino[0];
               AssignAttri(sPrefix, false, "A17Destino", A17Destino);
               A5ClienteId = H000M3_A5ClienteId[0];
               AssignAttri(sPrefix, false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
               A10VeiculoId = H000M3_A10VeiculoId[0];
               AssignAttri(sPrefix, false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
               A11VeiculoMarca = H000M3_A11VeiculoMarca[0];
               AssignAttri(sPrefix, false, "A11VeiculoMarca", A11VeiculoMarca);
               /* Execute user event: Load */
               E140M2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB0M0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0M2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV12Pgmname = "TRegistroPedidoGeneral";
         /* Using cursor H000M4 */
         pr_default.execute(2, new Object[] {A1EmpresaId});
         A2EmpresaNome = H000M4_A2EmpresaNome[0];
         AssignAttri(sPrefix, false, "A2EmpresaNome", A2EmpresaNome);
         pr_default.close(2);
         edtEmpresaId_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         edtRegistroPedidoId_Enabled = 0;
         AssignProp(sPrefix, false, edtRegistroPedidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroPedidoId_Enabled), 5, 0), true);
         edtVeiculoId_Enabled = 0;
         AssignProp(sPrefix, false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp(sPrefix, false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtDestino_Enabled = 0;
         AssignProp(sPrefix, false, edtDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDestino_Enabled), 5, 0), true);
         edtDataRetirada_Enabled = 0;
         AssignProp(sPrefix, false, edtDataRetirada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataRetirada_Enabled), 5, 0), true);
         edtDataRetorno_Enabled = 0;
         AssignProp(sPrefix, false, edtDataRetorno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataRetorno_Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         edtVeiculoMarca_Enabled = 0;
         AssignProp(sPrefix, false, edtVeiculoMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoMarca_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130M2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1EmpresaId"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOA16RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA16RegistroPedidoId"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVeiculoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
            A5ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A5ClienteId", StringUtil.LTrimStr( (decimal)(A5ClienteId), 12, 0));
            A17Destino = cgiGet( edtDestino_Internalname);
            AssignAttri(sPrefix, false, "A17Destino", A17Destino);
            A24DataRetirada = context.localUtil.CToD( cgiGet( edtDataRetirada_Internalname), 1);
            AssignAttri(sPrefix, false, "A24DataRetirada", context.localUtil.Format(A24DataRetirada, "99/99/9999"));
            A25DataRetorno = context.localUtil.CToD( cgiGet( edtDataRetorno_Internalname), 1);
            n25DataRetorno = false;
            AssignAttri(sPrefix, false, "A25DataRetorno", context.localUtil.Format(A25DataRetorno, "99/99/9999"));
            A2EmpresaNome = cgiGet( edtEmpresaNome_Internalname);
            AssignAttri(sPrefix, false, "A2EmpresaNome", A2EmpresaNome);
            A11VeiculoMarca = cgiGet( edtVeiculoMarca_Internalname);
            AssignAttri(sPrefix, false, "A11VeiculoMarca", A11VeiculoMarca);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"TRegistroPedidoGeneral");
            A10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVeiculoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
            forbiddenHiddens.Add("VeiculoId", context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9"));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("tregistropedidogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E130M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130M2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140M2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtEmpresaNome_Link = formatLink("viewtempresa.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EmpresaId","TabCode"}) ;
         AssignProp(sPrefix, false, edtEmpresaNome_Internalname, "Link", edtEmpresaNome_Link, true);
         edtVeiculoMarca_Link = formatLink("viewtveiculo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(A10VeiculoId,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EmpresaId","VeiculoId","TabCode"}) ;
         AssignProp(sPrefix, false, edtVeiculoMarca_Internalname, "Link", edtVeiculoMarca_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV12Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "TRegistroPedido";
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "EmpresaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6EmpresaId), 12, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "RegistroPedidoId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7RegistroPedidoId), 12, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A1EmpresaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         A16RegistroPedidoId = Convert.ToInt64(getParm(obj,1));
         AssignAttri(sPrefix, false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
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
         PA0M2( ) ;
         WS0M2( ) ;
         WE0M2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA1EmpresaId = (string)((string)getParm(obj,0));
         sCtrlA16RegistroPedidoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0M2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "tregistropedidogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0M2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A1EmpresaId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A16RegistroPedidoId = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
         }
         wcpOA1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1EmpresaId"), ".", ","), 18, MidpointRounding.ToEven));
         wcpOA16RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA16RegistroPedidoId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A1EmpresaId != wcpOA1EmpresaId ) || ( A16RegistroPedidoId != wcpOA16RegistroPedidoId ) ) )
         {
            setjustcreated();
         }
         wcpOA1EmpresaId = A1EmpresaId;
         wcpOA16RegistroPedidoId = A16RegistroPedidoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA1EmpresaId = cgiGet( sPrefix+"A1EmpresaId_CTRL");
         if ( StringUtil.Len( sCtrlA1EmpresaId) > 0 )
         {
            A1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA1EmpresaId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         }
         else
         {
            A1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A1EmpresaId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
         sCtrlA16RegistroPedidoId = cgiGet( sPrefix+"A16RegistroPedidoId_CTRL");
         if ( StringUtil.Len( sCtrlA16RegistroPedidoId) > 0 )
         {
            A16RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA16RegistroPedidoId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A16RegistroPedidoId", StringUtil.LTrimStr( (decimal)(A16RegistroPedidoId), 12, 0));
         }
         else
         {
            A16RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A16RegistroPedidoId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0M2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0M2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A1EmpresaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA1EmpresaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A1EmpresaId_CTRL", StringUtil.RTrim( sCtrlA1EmpresaId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A16RegistroPedidoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA16RegistroPedidoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A16RegistroPedidoId_CTRL", StringUtil.RTrim( sCtrlA16RegistroPedidoId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0M2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202442617141030", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("tregistropedidogeneral.js", "?202442617141030", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtEmpresaId_Internalname = sPrefix+"EMPRESAID";
         edtRegistroPedidoId_Internalname = sPrefix+"REGISTROPEDIDOID";
         edtVeiculoId_Internalname = sPrefix+"VEICULOID";
         edtClienteId_Internalname = sPrefix+"CLIENTEID";
         edtDestino_Internalname = sPrefix+"DESTINO";
         edtDataRetirada_Internalname = sPrefix+"DATARETIRADA";
         edtDataRetorno_Internalname = sPrefix+"DATARETORNO";
         edtEmpresaNome_Internalname = sPrefix+"EMPRESANOME";
         edtVeiculoMarca_Internalname = sPrefix+"VEICULOMARCA";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("ProjetoFrotas", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtVeiculoMarca_Jsonclick = "";
         edtVeiculoMarca_Link = "";
         edtVeiculoMarca_Enabled = 0;
         edtEmpresaNome_Jsonclick = "";
         edtEmpresaNome_Link = "";
         edtEmpresaNome_Enabled = 0;
         edtDataRetorno_Jsonclick = "";
         edtDataRetorno_Enabled = 0;
         edtDataRetirada_Jsonclick = "";
         edtDataRetirada_Enabled = 0;
         edtDestino_Jsonclick = "";
         edtDestino_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 0;
         edtVeiculoId_Jsonclick = "";
         edtVeiculoId_Enabled = 0;
         edtRegistroPedidoId_Jsonclick = "";
         edtRegistroPedidoId_Enabled = 0;
         edtEmpresaId_Jsonclick = "";
         edtEmpresaId_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A16RegistroPedidoId","fld":"REGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E110M1","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A16RegistroPedidoId","fld":"REGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E120M1","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A16RegistroPedidoId","fld":"REGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_EMPRESAID","""{"handler":"Valid_Empresaid","iparms":[]}""");
         setEventMetadata("VALID_REGISTROPEDIDOID","""{"handler":"Valid_Registropedidoid","iparms":[]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV12Pgmname = "";
         H000M2_A2EmpresaNome = new string[] {""} ;
         A2EmpresaNome = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A17Destino = "";
         A24DataRetirada = DateTime.MinValue;
         A25DataRetorno = DateTime.MinValue;
         A11VeiculoMarca = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H000M3_A1EmpresaId = new long[1] ;
         H000M3_A16RegistroPedidoId = new long[1] ;
         H000M3_A11VeiculoMarca = new string[] {""} ;
         H000M3_A2EmpresaNome = new string[] {""} ;
         H000M3_A25DataRetorno = new DateTime[] {DateTime.MinValue} ;
         H000M3_n25DataRetorno = new bool[] {false} ;
         H000M3_A24DataRetirada = new DateTime[] {DateTime.MinValue} ;
         H000M3_A17Destino = new string[] {""} ;
         H000M3_A5ClienteId = new long[1] ;
         H000M3_A10VeiculoId = new long[1] ;
         H000M4_A2EmpresaNome = new string[] {""} ;
         hsh = "";
         AV8TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA1EmpresaId = "";
         sCtrlA16RegistroPedidoId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tregistropedidogeneral__default(),
            new Object[][] {
                new Object[] {
               H000M2_A2EmpresaNome
               }
               , new Object[] {
               H000M3_A1EmpresaId, H000M3_A16RegistroPedidoId, H000M3_A11VeiculoMarca, H000M3_A2EmpresaNome, H000M3_A25DataRetorno, H000M3_n25DataRetorno, H000M3_A24DataRetirada, H000M3_A17Destino, H000M3_A5ClienteId, H000M3_A10VeiculoId
               }
               , new Object[] {
               H000M4_A2EmpresaNome
               }
            }
         );
         AV12Pgmname = "TRegistroPedidoGeneral";
         /* GeneXus formulas. */
         AV12Pgmname = "TRegistroPedidoGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtEmpresaId_Enabled ;
      private int edtRegistroPedidoId_Enabled ;
      private int edtVeiculoId_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtDestino_Enabled ;
      private int edtDataRetirada_Enabled ;
      private int edtDataRetorno_Enabled ;
      private int edtEmpresaNome_Enabled ;
      private int edtVeiculoMarca_Enabled ;
      private int idxLst ;
      private long A1EmpresaId ;
      private long A16RegistroPedidoId ;
      private long wcpOA1EmpresaId ;
      private long wcpOA16RegistroPedidoId ;
      private long A10VeiculoId ;
      private long A5ClienteId ;
      private long AV6EmpresaId ;
      private long AV7RegistroPedidoId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV12Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtEmpresaId_Internalname ;
      private string edtEmpresaId_Jsonclick ;
      private string edtRegistroPedidoId_Internalname ;
      private string edtRegistroPedidoId_Jsonclick ;
      private string edtVeiculoId_Internalname ;
      private string edtVeiculoId_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtDestino_Internalname ;
      private string A17Destino ;
      private string edtDestino_Jsonclick ;
      private string edtDataRetirada_Internalname ;
      private string edtDataRetirada_Jsonclick ;
      private string edtDataRetorno_Internalname ;
      private string edtDataRetorno_Jsonclick ;
      private string edtEmpresaNome_Internalname ;
      private string edtEmpresaNome_Link ;
      private string edtEmpresaNome_Jsonclick ;
      private string edtVeiculoMarca_Internalname ;
      private string edtVeiculoMarca_Link ;
      private string edtVeiculoMarca_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string hsh ;
      private string sCtrlA1EmpresaId ;
      private string sCtrlA16RegistroPedidoId ;
      private DateTime A24DataRetirada ;
      private DateTime A25DataRetorno ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n25DataRetorno ;
      private bool returnInSub ;
      private string A2EmpresaNome ;
      private string A11VeiculoMarca ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000M2_A2EmpresaNome ;
      private long[] H000M3_A1EmpresaId ;
      private long[] H000M3_A16RegistroPedidoId ;
      private string[] H000M3_A11VeiculoMarca ;
      private string[] H000M3_A2EmpresaNome ;
      private DateTime[] H000M3_A25DataRetorno ;
      private bool[] H000M3_n25DataRetorno ;
      private DateTime[] H000M3_A24DataRetirada ;
      private string[] H000M3_A17Destino ;
      private long[] H000M3_A5ClienteId ;
      private long[] H000M3_A10VeiculoId ;
      private string[] H000M4_A2EmpresaNome ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV8TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tregistropedidogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000M2;
          prmH000M2 = new Object[] {
          new ParDef("@EmpresaId",GXType.Decimal,12,0)
          };
          Object[] prmH000M3;
          prmH000M3 = new Object[] {
          new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@RegistroPedidoId",GXType.Decimal,12,0)
          };
          Object[] prmH000M4;
          prmH000M4 = new Object[] {
          new ParDef("@EmpresaId",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000M2", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000M3", "SELECT T1.[EmpresaId], T1.[RegistroPedidoId], T3.[VeiculoMarca], T2.[EmpresaNome], T1.[DataRetorno], T1.[DataRetirada], T1.[Destino], T1.[ClienteId], T1.[VeiculoId] FROM (([TRegistroPedido] T1 INNER JOIN [TEmpresa] T2 ON T2.[EmpresaId] = T1.[EmpresaId]) INNER JOIN [TVeiculo] T3 ON T3.[EmpresaId] = T1.[EmpresaId] AND T3.[VeiculoId] = T1.[VeiculoId]) WHERE T1.[EmpresaId] = @EmpresaId and T1.[RegistroPedidoId] = @RegistroPedidoId ORDER BY T1.[EmpresaId], T1.[RegistroPedidoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000M4", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000M4,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
