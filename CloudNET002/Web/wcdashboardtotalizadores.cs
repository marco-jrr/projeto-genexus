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
   public class wcdashboardtotalizadores : GXWebComponent
   {
      public wcdashboardtotalizadores( )
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

      public wcdashboardtotalizadores( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_QtdUsuarios ,
                           ref short aP1_QtdRegistros )
      {
         this.AV10QtdUsuarios = aP0_QtdUsuarios;
         this.AV9QtdRegistros = aP1_QtdRegistros;
         ExecuteImpl();
         aP0_QtdUsuarios=this.AV10QtdUsuarios;
         aP1_QtdRegistros=this.AV9QtdRegistros;
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
               gxfirstwebparm = GetFirstPar( "QtdUsuarios");
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
                  AV10QtdUsuarios = (short)(Math.Round(NumberUtil.Val( GetPar( "QtdUsuarios"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV10QtdUsuarios", StringUtil.LTrimStr( (decimal)(AV10QtdUsuarios), 4, 0));
                  AV9QtdRegistros = (short)(Math.Round(NumberUtil.Val( GetPar( "QtdRegistros"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9QtdRegistros", StringUtil.LTrimStr( (decimal)(AV9QtdRegistros), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV10QtdUsuarios,(short)AV9QtdRegistros});
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
                  gxfirstwebparm = GetFirstPar( "QtdUsuarios");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "QtdUsuarios");
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
            PA172( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS172( ) ;
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
            context.SendWebValue( "WCDashboard Totalizadores") ;
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
         context.AddJavascriptSource("DashboardViewer/../QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DashboardViewer/../QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("DashboardViewer/BrowserLayoutRender.js", "", false, true);
         context.AddJavascriptSource("DashboardViewer/DashboardViewerRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcdashboardtotalizadores.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10QtdUsuarios,4,0)),UrlEncode(StringUtil.LTrimStr(AV9QtdRegistros,4,0))}, new string[] {"QtdUsuarios","QtdRegistros"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCLICKDATA", AV5ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCLICKDATA", AV5ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERSCHANGEDDATA", AV6FiltersChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERSCHANGEDDATA", AV6FiltersChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVALUESHIGHLIGHTEDDATA", AV7ValuesHighlightedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVALUESHIGHLIGHTEDDATA", AV7ValuesHighlightedData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV10QtdUsuarios", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV10QtdUsuarios), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9QtdRegistros", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9QtdRegistros), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vQTDUSUARIOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10QtdUsuarios), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vQTDREGISTROS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9QtdRegistros), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DASHBOARDVIEWER1_Objectcall", StringUtil.RTrim( Dashboardviewer1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"DASHBOARDVIEWER1_Objectcall", StringUtil.RTrim( Dashboardviewer1_Objectcall));
      }

      protected void RenderHtmlCloseForm172( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WCDashboardTotalizadores" ;
      }

      public override string GetPgmdesc( )
      {
         return "WCDashboard Totalizadores" ;
      }

      protected void WB170( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcdashboardtotalizadores.aspx");
               context.AddJavascriptSource("DashboardViewer/../QueryViewer/QueryViewerRender.js", "", false, true);
               context.AddJavascriptSource("DashboardViewer/../QueryViewer/QueryViewerCommon.js", "", false, true);
               context.AddJavascriptSource("DashboardViewer/BrowserLayoutRender.js", "", false, true);
               context.AddJavascriptSource("DashboardViewer/DashboardViewerRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDashboardviewer1.SetProperty("ItemClickData", AV5ItemClickData);
            ucDashboardviewer1.SetProperty("FiltersChangedData", AV6FiltersChangedData);
            ucDashboardviewer1.SetProperty("ValuesHighlightedData", AV7ValuesHighlightedData);
            ucDashboardviewer1.Render(context, "dashboardviewer", Dashboardviewer1_Internalname, sPrefix+"DASHBOARDVIEWER1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START172( )
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
            Form.Meta.addItem("description", "WCDashboard Totalizadores", 0) ;
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
               STRUP170( ) ;
            }
         }
      }

      protected void WS172( )
      {
         START172( ) ;
         EVT172( ) ;
      }

      protected void EVT172( )
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
                                 STRUP170( ) ;
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
                                 STRUP170( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11172 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP170( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12172 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP170( ) ;
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
                                 STRUP170( ) ;
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

      protected void WE172( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm172( ) ;
            }
         }
      }

      protected void PA172( )
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
         RF172( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF172( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E12172 ();
            WB170( ) ;
         }
      }

      protected void send_integrity_lvl_hashes172( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP170( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11172 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCLICKDATA"), AV5ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERSCHANGEDDATA"), AV6FiltersChangedData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vVALUESHIGHLIGHTEDDATA"), AV7ValuesHighlightedData);
            /* Read saved values. */
            wcpOAV10QtdUsuarios = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10QtdUsuarios"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV9QtdRegistros = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9QtdRegistros"), ".", ","), 18, MidpointRounding.ToEven));
            Dashboardviewer1_Objectcall = cgiGet( sPrefix+"DASHBOARDVIEWER1_Objectcall");
            Dashboardviewer1_Objectcall = cgiGet( sPrefix+"DASHBOARDVIEWER1_Objectcall");
            /* Read variables values. */
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
         E11172 ();
         if (returnInSub) return;
      }

      protected void E11172( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Object Property */
         GXt_webobj1 = new GXHttpHandler();
         new dashboardtotalizadores(context ).gxep_call( ref  AV10QtdUsuarios, ref  AV9QtdRegistros, ref  GXt_webobj1) ;
         AssignAttri(sPrefix, false, "AV10QtdUsuarios", StringUtil.LTrimStr( (decimal)(AV10QtdUsuarios), 4, 0));
         AssignAttri(sPrefix, false, "AV9QtdRegistros", StringUtil.LTrimStr( (decimal)(AV9QtdRegistros), 4, 0));
         Dashboardviewer1_Object = GXt_webobj1;
         ucDashboardviewer1.SendProperty(context, sPrefix, false, Dashboardviewer1_Internalname, "Object", (string)(Dashboardviewer1_Object));
      }

      protected void nextLoad( )
      {
      }

      protected void E12172( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10QtdUsuarios = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV10QtdUsuarios", StringUtil.LTrimStr( (decimal)(AV10QtdUsuarios), 4, 0));
         AV9QtdRegistros = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV9QtdRegistros", StringUtil.LTrimStr( (decimal)(AV9QtdRegistros), 4, 0));
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
         PA172( ) ;
         WS172( ) ;
         WE172( ) ;
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
         sCtrlAV10QtdUsuarios = (string)((string)getParm(obj,0));
         sCtrlAV9QtdRegistros = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA172( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcdashboardtotalizadores", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA172( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV10QtdUsuarios = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV10QtdUsuarios", StringUtil.LTrimStr( (decimal)(AV10QtdUsuarios), 4, 0));
            AV9QtdRegistros = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV9QtdRegistros", StringUtil.LTrimStr( (decimal)(AV9QtdRegistros), 4, 0));
         }
         wcpOAV10QtdUsuarios = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV10QtdUsuarios"), ".", ","), 18, MidpointRounding.ToEven));
         wcpOAV9QtdRegistros = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9QtdRegistros"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV10QtdUsuarios != wcpOAV10QtdUsuarios ) || ( AV9QtdRegistros != wcpOAV9QtdRegistros ) ) )
         {
            setjustcreated();
         }
         wcpOAV10QtdUsuarios = AV10QtdUsuarios;
         wcpOAV9QtdRegistros = AV9QtdRegistros;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV10QtdUsuarios = cgiGet( sPrefix+"AV10QtdUsuarios_CTRL");
         if ( StringUtil.Len( sCtrlAV10QtdUsuarios) > 0 )
         {
            AV10QtdUsuarios = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV10QtdUsuarios), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV10QtdUsuarios", StringUtil.LTrimStr( (decimal)(AV10QtdUsuarios), 4, 0));
         }
         else
         {
            AV10QtdUsuarios = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV10QtdUsuarios_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
         sCtrlAV9QtdRegistros = cgiGet( sPrefix+"AV9QtdRegistros_CTRL");
         if ( StringUtil.Len( sCtrlAV9QtdRegistros) > 0 )
         {
            AV9QtdRegistros = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9QtdRegistros), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9QtdRegistros", StringUtil.LTrimStr( (decimal)(AV9QtdRegistros), 4, 0));
         }
         else
         {
            AV9QtdRegistros = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9QtdRegistros_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA172( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS172( ) ;
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
         WS172( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10QtdUsuarios_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10QtdUsuarios), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10QtdUsuarios)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10QtdUsuarios_CTRL", StringUtil.RTrim( sCtrlAV10QtdUsuarios));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9QtdRegistros_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9QtdRegistros), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9QtdRegistros)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9QtdRegistros_CTRL", StringUtil.RTrim( sCtrlAV9QtdRegistros));
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
         WE172( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202442523473087", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wcdashboardtotalizadores.js", "?202442523473087", false, true);
            context.AddJavascriptSource("DashboardViewer/../QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DashboardViewer/../QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("DashboardViewer/BrowserLayoutRender.js", "", false, true);
            context.AddJavascriptSource("DashboardViewer/DashboardViewerRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Dashboardviewer1_Internalname = sPrefix+"DASHBOARDVIEWER1";
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
         Dashboardviewer1_Objectcall = "[\"qrydshb\", \"DashboardTotalizadores\", \"\"]";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV5ItemClickData = new GeneXus.Programs.genexusreporting.SdtDashboardViewerItemClickData(context);
         AV6FiltersChangedData = new GeneXus.Programs.genexusreporting.SdtDashboardViewerFiltersChangedData(context);
         AV7ValuesHighlightedData = new GeneXus.Programs.genexusreporting.SdtDashboardViewerValuesHighlightedData(context);
         GX_FocusControl = "";
         ucDashboardviewer1 = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Dashboardviewer1_Object = new GXHttpHandler();
         GXt_webobj1 = new GXHttpHandler();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV10QtdUsuarios = "";
         sCtrlAV9QtdRegistros = "";
         /* GeneXus formulas. */
      }

      private short AV10QtdUsuarios ;
      private short AV9QtdRegistros ;
      private short wcpOAV10QtdUsuarios ;
      private short wcpOAV9QtdRegistros ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Dashboardviewer1_Objectcall ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string Dashboardviewer1_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlAV10QtdUsuarios ;
      private string sCtrlAV9QtdRegistros ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXHttpHandler Dashboardviewer1_Object ;
      private GXHttpHandler GXt_webobj1 ;
      private GXUserControl ucDashboardviewer1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP0_QtdUsuarios ;
      private short aP1_QtdRegistros ;
      private GeneXus.Programs.genexusreporting.SdtDashboardViewerItemClickData AV5ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtDashboardViewerFiltersChangedData AV6FiltersChangedData ;
      private GeneXus.Programs.genexusreporting.SdtDashboardViewerValuesHighlightedData AV7ValuesHighlightedData ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
