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
   public class tveiculogeneral : GXWebComponent
   {
      public tveiculogeneral( )
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

      public tveiculogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_EmpresaId ,
                           long aP1_VeiculoId )
      {
         this.A1EmpresaId = aP0_EmpresaId;
         this.A10VeiculoId = aP1_VeiculoId;
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
                  A10VeiculoId = (long)(Math.Round(NumberUtil.Val( GetPar( "VeiculoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A1EmpresaId,(long)A10VeiculoId});
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
            PA0P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV12Pgmname = "TVeiculoGeneral";
               /* Using cursor H000P2 */
               pr_default.execute(0, new Object[] {A1EmpresaId});
               A2EmpresaNome = H000P2_A2EmpresaNome[0];
               AssignAttri(sPrefix, false, "A2EmpresaNome", A2EmpresaNome);
               pr_default.close(0);
               WS0P2( ) ;
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
            context.SendWebValue( "TVeiculo General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tveiculogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(A10VeiculoId,12,0))}, new string[] {"EmpresaId","VeiculoId"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA1EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA1EmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA10VeiculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA10VeiculoId), 12, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0P2( )
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
         return "TVeiculoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "TVeiculo General" ;
      }

      protected void WB0P0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "tveiculogeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110p1_client"+"'", TempTags, "", 2, "HLP_TVeiculoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120p1_client"+"'", TempTags, "", 2, "HLP_TVeiculoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtEmpresaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")), StringUtil.LTrim( ((edtEmpresaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpresaId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdAuto", "end", false, "", "HLP_TVeiculoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVeiculoId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVeiculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")), StringUtil.LTrim( ((edtVeiculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVeiculoId_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "DIdManual", "end", false, "", "HLP_TVeiculoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVeiculoMarca_Internalname, "Marca", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVeiculoMarca_Internalname, A11VeiculoMarca, StringUtil.RTrim( context.localUtil.Format( A11VeiculoMarca, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoMarca_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVeiculoMarca_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVeiculoModelo_Internalname, "Modelo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVeiculoModelo_Internalname, A12VeiculoModelo, StringUtil.RTrim( context.localUtil.Format( A12VeiculoModelo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoModelo_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVeiculoModelo_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVeiculoPlaca_Internalname, "Placa", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVeiculoPlaca_Internalname, StringUtil.RTrim( A13VeiculoPlaca), StringUtil.RTrim( context.localUtil.Format( A13VeiculoPlaca, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoPlaca_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVeiculoPlaca_Enabled, 0, "text", "", 7, "chr", 1, "row", 7, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVeiculoCor_Internalname, "Cor", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVeiculoCor_Internalname, StringUtil.RTrim( A14VeiculoCor), StringUtil.RTrim( context.localUtil.Format( A14VeiculoCor, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoCor_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVeiculoCor_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtVeiculoAno_Internalname, "Ano", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVeiculoAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15VeiculoAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtVeiculoAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A15VeiculoAno), "ZZZ9") : context.localUtil.Format( (decimal)(A15VeiculoAno), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVeiculoAno_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVeiculoAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TVeiculoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtEmpresaNome_Internalname, A2EmpresaNome, StringUtil.RTrim( context.localUtil.Format( A2EmpresaNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtEmpresaNome_Link, "", "", "", edtEmpresaNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmpresaNome_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TVeiculoGeneral.htm");
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

      protected void START0P2( )
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
            Form.Meta.addItem("description", "TVeiculo General", 0) ;
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
               STRUP0P0( ) ;
            }
         }
      }

      protected void WS0P2( )
      {
         START0P2( ) ;
         EVT0P2( ) ;
      }

      protected void EVT0P2( )
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
                                 STRUP0P0( ) ;
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
                                 STRUP0P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0P0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140P2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0P0( ) ;
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
                                 STRUP0P0( ) ;
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

      protected void WE0P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0P2( ) ;
            }
         }
      }

      protected void PA0P2( )
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
         RF0P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV12Pgmname = "TVeiculoGeneral";
      }

      protected void RF0P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000P3 */
            pr_default.execute(1, new Object[] {A1EmpresaId, A10VeiculoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A15VeiculoAno = H000P3_A15VeiculoAno[0];
               AssignAttri(sPrefix, false, "A15VeiculoAno", StringUtil.LTrimStr( (decimal)(A15VeiculoAno), 4, 0));
               A14VeiculoCor = H000P3_A14VeiculoCor[0];
               AssignAttri(sPrefix, false, "A14VeiculoCor", A14VeiculoCor);
               A13VeiculoPlaca = H000P3_A13VeiculoPlaca[0];
               AssignAttri(sPrefix, false, "A13VeiculoPlaca", A13VeiculoPlaca);
               A12VeiculoModelo = H000P3_A12VeiculoModelo[0];
               AssignAttri(sPrefix, false, "A12VeiculoModelo", A12VeiculoModelo);
               A11VeiculoMarca = H000P3_A11VeiculoMarca[0];
               AssignAttri(sPrefix, false, "A11VeiculoMarca", A11VeiculoMarca);
               /* Execute user event: Load */
               E140P2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB0P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0P2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV12Pgmname = "TVeiculoGeneral";
         /* Using cursor H000P4 */
         pr_default.execute(2, new Object[] {A1EmpresaId});
         A2EmpresaNome = H000P4_A2EmpresaNome[0];
         AssignAttri(sPrefix, false, "A2EmpresaNome", A2EmpresaNome);
         pr_default.close(2);
         edtEmpresaId_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         edtVeiculoId_Enabled = 0;
         AssignProp(sPrefix, false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), true);
         edtVeiculoMarca_Enabled = 0;
         AssignProp(sPrefix, false, edtVeiculoMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoMarca_Enabled), 5, 0), true);
         edtVeiculoModelo_Enabled = 0;
         AssignProp(sPrefix, false, edtVeiculoModelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoModelo_Enabled), 5, 0), true);
         edtVeiculoPlaca_Enabled = 0;
         AssignProp(sPrefix, false, edtVeiculoPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoPlaca_Enabled), 5, 0), true);
         edtVeiculoCor_Enabled = 0;
         AssignProp(sPrefix, false, edtVeiculoCor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoCor_Enabled), 5, 0), true);
         edtVeiculoAno_Enabled = 0;
         AssignProp(sPrefix, false, edtVeiculoAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoAno_Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp(sPrefix, false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130P2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1EmpresaId"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOA10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA10VeiculoId"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A11VeiculoMarca = cgiGet( edtVeiculoMarca_Internalname);
            AssignAttri(sPrefix, false, "A11VeiculoMarca", A11VeiculoMarca);
            A12VeiculoModelo = cgiGet( edtVeiculoModelo_Internalname);
            AssignAttri(sPrefix, false, "A12VeiculoModelo", A12VeiculoModelo);
            A13VeiculoPlaca = cgiGet( edtVeiculoPlaca_Internalname);
            AssignAttri(sPrefix, false, "A13VeiculoPlaca", A13VeiculoPlaca);
            A14VeiculoCor = cgiGet( edtVeiculoCor_Internalname);
            AssignAttri(sPrefix, false, "A14VeiculoCor", A14VeiculoCor);
            A15VeiculoAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtVeiculoAno_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A15VeiculoAno", StringUtil.LTrimStr( (decimal)(A15VeiculoAno), 4, 0));
            A2EmpresaNome = cgiGet( edtEmpresaNome_Internalname);
            AssignAttri(sPrefix, false, "A2EmpresaNome", A2EmpresaNome);
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
         E130P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130P2( )
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

      protected void E140P2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtEmpresaNome_Link = formatLink("viewtempresa.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EmpresaId","TabCode"}) ;
         AssignProp(sPrefix, false, edtEmpresaNome_Internalname, "Link", edtEmpresaNome_Link, true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV12Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "TVeiculo";
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "EmpresaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6EmpresaId), 12, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "VeiculoId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7VeiculoId), 12, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A1EmpresaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
         A10VeiculoId = Convert.ToInt64(getParm(obj,1));
         AssignAttri(sPrefix, false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
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
         PA0P2( ) ;
         WS0P2( ) ;
         WE0P2( ) ;
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
         sCtrlA10VeiculoId = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0P2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "tveiculogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0P2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A1EmpresaId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 12, 0));
            A10VeiculoId = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         }
         wcpOA1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA1EmpresaId"), ".", ","), 18, MidpointRounding.ToEven));
         wcpOA10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA10VeiculoId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A1EmpresaId != wcpOA1EmpresaId ) || ( A10VeiculoId != wcpOA10VeiculoId ) ) )
         {
            setjustcreated();
         }
         wcpOA1EmpresaId = A1EmpresaId;
         wcpOA10VeiculoId = A10VeiculoId;
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
         sCtrlA10VeiculoId = cgiGet( sPrefix+"A10VeiculoId_CTRL");
         if ( StringUtil.Len( sCtrlA10VeiculoId) > 0 )
         {
            A10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA10VeiculoId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A10VeiculoId", StringUtil.LTrimStr( (decimal)(A10VeiculoId), 12, 0));
         }
         else
         {
            A10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A10VeiculoId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA0P2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0P2( ) ;
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
         WS0P2( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"A10VeiculoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA10VeiculoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A10VeiculoId_CTRL", StringUtil.RTrim( sCtrlA10VeiculoId));
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
         WE0P2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20244261714335", true, true);
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
         context.AddJavascriptSource("tveiculogeneral.js", "?20244261714335", false, true);
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
         edtVeiculoId_Internalname = sPrefix+"VEICULOID";
         edtVeiculoMarca_Internalname = sPrefix+"VEICULOMARCA";
         edtVeiculoModelo_Internalname = sPrefix+"VEICULOMODELO";
         edtVeiculoPlaca_Internalname = sPrefix+"VEICULOPLACA";
         edtVeiculoCor_Internalname = sPrefix+"VEICULOCOR";
         edtVeiculoAno_Internalname = sPrefix+"VEICULOANO";
         edtEmpresaNome_Internalname = sPrefix+"EMPRESANOME";
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
         edtEmpresaNome_Jsonclick = "";
         edtEmpresaNome_Link = "";
         edtEmpresaNome_Enabled = 0;
         edtVeiculoAno_Jsonclick = "";
         edtVeiculoAno_Enabled = 0;
         edtVeiculoCor_Jsonclick = "";
         edtVeiculoCor_Enabled = 0;
         edtVeiculoPlaca_Jsonclick = "";
         edtVeiculoPlaca_Enabled = 0;
         edtVeiculoModelo_Jsonclick = "";
         edtVeiculoModelo_Enabled = 0;
         edtVeiculoMarca_Jsonclick = "";
         edtVeiculoMarca_Enabled = 0;
         edtVeiculoId_Jsonclick = "";
         edtVeiculoId_Enabled = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E110P1","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E120P1","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALID_EMPRESAID","""{"handler":"Valid_Empresaid","iparms":[]}""");
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
         H000P2_A2EmpresaNome = new string[] {""} ;
         A2EmpresaNome = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A11VeiculoMarca = "";
         A12VeiculoModelo = "";
         A13VeiculoPlaca = "";
         A14VeiculoCor = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H000P3_A1EmpresaId = new long[1] ;
         H000P3_A10VeiculoId = new long[1] ;
         H000P3_A2EmpresaNome = new string[] {""} ;
         H000P3_A15VeiculoAno = new short[1] ;
         H000P3_A14VeiculoCor = new string[] {""} ;
         H000P3_A13VeiculoPlaca = new string[] {""} ;
         H000P3_A12VeiculoModelo = new string[] {""} ;
         H000P3_A11VeiculoMarca = new string[] {""} ;
         H000P4_A2EmpresaNome = new string[] {""} ;
         AV8TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA1EmpresaId = "";
         sCtrlA10VeiculoId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tveiculogeneral__default(),
            new Object[][] {
                new Object[] {
               H000P2_A2EmpresaNome
               }
               , new Object[] {
               H000P3_A1EmpresaId, H000P3_A10VeiculoId, H000P3_A2EmpresaNome, H000P3_A15VeiculoAno, H000P3_A14VeiculoCor, H000P3_A13VeiculoPlaca, H000P3_A12VeiculoModelo, H000P3_A11VeiculoMarca
               }
               , new Object[] {
               H000P4_A2EmpresaNome
               }
            }
         );
         AV12Pgmname = "TVeiculoGeneral";
         /* GeneXus formulas. */
         AV12Pgmname = "TVeiculoGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A15VeiculoAno ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtEmpresaId_Enabled ;
      private int edtVeiculoId_Enabled ;
      private int edtVeiculoMarca_Enabled ;
      private int edtVeiculoModelo_Enabled ;
      private int edtVeiculoPlaca_Enabled ;
      private int edtVeiculoCor_Enabled ;
      private int edtVeiculoAno_Enabled ;
      private int edtEmpresaNome_Enabled ;
      private int idxLst ;
      private long A1EmpresaId ;
      private long A10VeiculoId ;
      private long wcpOA1EmpresaId ;
      private long wcpOA10VeiculoId ;
      private long AV6EmpresaId ;
      private long AV7VeiculoId ;
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
      private string edtEmpresaNome_Internalname ;
      private string edtEmpresaNome_Link ;
      private string edtEmpresaNome_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA1EmpresaId ;
      private string sCtrlA10VeiculoId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A2EmpresaNome ;
      private string A11VeiculoMarca ;
      private string A12VeiculoModelo ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000P2_A2EmpresaNome ;
      private long[] H000P3_A1EmpresaId ;
      private long[] H000P3_A10VeiculoId ;
      private string[] H000P3_A2EmpresaNome ;
      private short[] H000P3_A15VeiculoAno ;
      private string[] H000P3_A14VeiculoCor ;
      private string[] H000P3_A13VeiculoPlaca ;
      private string[] H000P3_A12VeiculoModelo ;
      private string[] H000P3_A11VeiculoMarca ;
      private string[] H000P4_A2EmpresaNome ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV8TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tveiculogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000P2;
          prmH000P2 = new Object[] {
          new ParDef("@EmpresaId",GXType.Decimal,12,0)
          };
          Object[] prmH000P3;
          prmH000P3 = new Object[] {
          new ParDef("@EmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@VeiculoId",GXType.Decimal,12,0)
          };
          Object[] prmH000P4;
          prmH000P4 = new Object[] {
          new ParDef("@EmpresaId",GXType.Decimal,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000P2", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000P2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000P3", "SELECT T1.[EmpresaId], T1.[VeiculoId], T2.[EmpresaNome], T1.[VeiculoAno], T1.[VeiculoCor], T1.[VeiculoPlaca], T1.[VeiculoModelo], T1.[VeiculoMarca] FROM ([TVeiculo] T1 INNER JOIN [TEmpresa] T2 ON T2.[EmpresaId] = T1.[EmpresaId]) WHERE T1.[EmpresaId] = @EmpresaId and T1.[VeiculoId] = @VeiculoId ORDER BY T1.[EmpresaId], T1.[VeiculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000P3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000P4", "SELECT [EmpresaNome] FROM [TEmpresa] WHERE [EmpresaId] = @EmpresaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000P4,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((string[]) buf[5])[0] = rslt.getString(6, 7);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
