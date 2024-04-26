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
   public class wwtregistropedido : GXDataArea
   {
      public wwtregistropedido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public wwtregistropedido( IGxContext context )
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
         dynClienteId = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_27 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_27"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_27_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_27_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_27_idx = GetPar( "sGXsfl_27_idx");
         AV12Update = GetPar( "Update");
         AV13Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV11Destino = GetPar( "Destino");
         AV15IdEmpresa = (long)(Math.Round(NumberUtil.Val( GetPar( "IdEmpresa"), "."), 18, MidpointRounding.ToEven));
         AV12Update = GetPar( "Update");
         AV13Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV11Destino, AV15IdEmpresa, AV12Update, AV13Delete) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA0L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0L2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwtregistropedido.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vIDEMPRESA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15IdEmpresa), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDEMPRESA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15IdEmpresa), "ZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDESTINO", StringUtil.RTrim( AV11Destino));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_27", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_27), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vIDEMPRESA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15IdEmpresa), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDEMPRESA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15IdEmpresa), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
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
         if ( ! ( WebComp_Component1 == null ) )
         {
            WebComp_Component1.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0L2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwtregistropedido.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWTRegistroPedido" ;
      }

      public override string GetPgmdesc( )
      {
         return "Work With Registros de Locação de Veículos" ;
      }

      protected void WB0L0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "body-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 ww__grid-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "container-fluid container-advanced", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__title-cell", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Registros de Locação de Veículos", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWTRegistroPedido.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__actions-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(27), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWTRegistroPedido.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__filter-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDestino_Internalname, "Destino", "gx-form-item attribute-searchLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDestino_Internalname, StringUtil.RTrim( AV11Destino), StringUtil.RTrim( context.localUtil.Format( AV11Destino, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Destino", edtavDestino_Jsonclick, 0, "attribute-search", "", "", "", "", 1, edtavDestino_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWTRegistroPedido.htm");
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
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl27( ) ;
         }
         if ( wbEnd == 27 )
         {
            wbEnd = 0;
            nRC_GXsfl_27 = (int)(nGXsfl_27_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0040"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_27_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
                  {
                     if ( ! context.isAjaxRequest( ) )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
                     }
                     WebComp_Component1.componentdraw();
                     if ( ! context.isAjaxRequest( ) )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 27 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0L2( )
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
         Form.Meta.addItem("description", "Work With Registros de Locação de Veículos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0L0( ) ;
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E110L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_27_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
                              SubsflControlProps_272( ) ;
                              A1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A16RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRegistroPedidoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A2EmpresaNome = cgiGet( edtEmpresaNome_Internalname);
                              A11VeiculoMarca = cgiGet( edtVeiculoMarca_Internalname);
                              dynClienteId.Name = dynClienteId_Internalname;
                              dynClienteId.CurrentValue = cgiGet( dynClienteId_Internalname);
                              A5ClienteId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynClienteId_Internalname), "."), 18, MidpointRounding.ToEven));
                              A17Destino = cgiGet( edtDestino_Internalname);
                              A24DataRetirada = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtDataRetirada_Internalname), 0));
                              A25DataRetorno = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtDataRetorno_Internalname), 0));
                              n25DataRetorno = false;
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E120L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E130L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E140L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Destino Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDESTINO"), AV11Destino) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 40 )
                        {
                           WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wpdashboard", new Object[] {context} );
                           WebComp_Component1.ComponentInit();
                           WebComp_Component1.Name = "WPDashboard";
                           WebComp_Component1_Component = "WPDashboard";
                           WebComp_Component1.componentprocess("W0040", "", sEvt);
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0L2( )
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
               GX_FocusControl = edtavDestino_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_272( ) ;
         while ( nGXsfl_27_idx <= nRC_GXsfl_27 )
         {
            sendrow_272( ) ;
            nGXsfl_27_idx = ((subGrid_Islastpage==1)&&(nGXsfl_27_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV11Destino ,
                                       long AV15IdEmpresa ,
                                       string AV12Update ,
                                       string AV13Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_REGISTROPEDIDOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A16RegistroPedidoId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "REGISTROPEDIDOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")));
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
         RF0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV19Pgmname = "WWTRegistroPedido";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_27_Refreshing);
      }

      protected void RF0L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 27;
         /* Execute user event: Refresh */
         E130L2 ();
         nGXsfl_27_idx = 1;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         bGXsfl_27_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ww__grid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component1_Component, "") == 0 )
            {
               WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wpdashboard", new Object[] {context} );
               WebComp_Component1.ComponentInit();
               WebComp_Component1.Name = "WPDashboard";
               WebComp_Component1_Component = "WPDashboard";
            }
            if ( ( StringUtil.Len( WebComp_Component1_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Component1_Component, "WPDashboard") == 0 ) )
            {
               WebComp_Component1.setjustcreated();
               WebComp_Component1.componentprepare(new Object[] {(string)"W0040",(string)""});
               WebComp_Component1.componentbind(new Object[] {});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Component1 )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
               WebComp_Component1.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
               {
                  WebComp_Component1.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_272( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11Destino ,
                                                 A17Destino ,
                                                 A1EmpresaId ,
                                                 AV15IdEmpresa } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV11Destino = StringUtil.PadR( StringUtil.RTrim( AV11Destino), 20, "%");
            /* Using cursor H000L2 */
            pr_default.execute(0, new Object[] {AV15IdEmpresa, lV11Destino, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_27_idx = 1;
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A10VeiculoId = H000L2_A10VeiculoId[0];
               A1EmpresaId = H000L2_A1EmpresaId[0];
               A25DataRetorno = H000L2_A25DataRetorno[0];
               n25DataRetorno = H000L2_n25DataRetorno[0];
               A24DataRetirada = H000L2_A24DataRetirada[0];
               A17Destino = H000L2_A17Destino[0];
               A5ClienteId = H000L2_A5ClienteId[0];
               A11VeiculoMarca = H000L2_A11VeiculoMarca[0];
               A2EmpresaNome = H000L2_A2EmpresaNome[0];
               A16RegistroPedidoId = H000L2_A16RegistroPedidoId[0];
               A2EmpresaNome = H000L2_A2EmpresaNome[0];
               A11VeiculoMarca = H000L2_A11VeiculoMarca[0];
               /* Execute user event: Grid.Load */
               E140L2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 27;
            WB0L0( ) ;
         }
         bGXsfl_27_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
         GxWebStd.gx_hidden_field( context, "vIDEMPRESA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15IdEmpresa), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDEMPRESA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15IdEmpresa), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_REGISTROPEDIDOID"+"_"+sGXsfl_27_idx, GetSecureSignedToken( sGXsfl_27_idx, context.localUtil.Format( (decimal)(A16RegistroPedidoId), "ZZZZZZZZZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11Destino ,
                                              A17Destino ,
                                              A1EmpresaId ,
                                              AV15IdEmpresa } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV11Destino = StringUtil.PadR( StringUtil.RTrim( AV11Destino), 20, "%");
         /* Using cursor H000L3 */
         pr_default.execute(1, new Object[] {AV15IdEmpresa, lV11Destino});
         GRID_nRecordCount = H000L3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11Destino, AV15IdEmpresa, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11Destino, AV15IdEmpresa, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11Destino, AV15IdEmpresa, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11Destino, AV15IdEmpresa, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11Destino, AV15IdEmpresa, AV12Update, AV13Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV11Destino = GridState.FilterValues("Destino");
            AssignAttri("", false, "AV11Destino", AV11Destino);
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.ClearFilterValues();
         GridState.AddFilterValue("Destino", AV11Destino);
      }

      protected void before_start_formulas( )
      {
         AV19Pgmname = "WWTRegistroPedido";
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtRegistroPedidoId_Enabled = 0;
         AssignProp("", false, edtRegistroPedidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroPedidoId_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtVeiculoMarca_Enabled = 0;
         AssignProp("", false, edtVeiculoMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoMarca_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         dynClienteId.Enabled = 0;
         AssignProp("", false, dynClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynClienteId.Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtDestino_Enabled = 0;
         AssignProp("", false, edtDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDestino_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtDataRetirada_Enabled = 0;
         AssignProp("", false, edtDataRetirada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataRetirada_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtDataRetorno_Enabled = 0;
         AssignProp("", false, edtDataRetorno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataRetorno_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_27 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_27"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV11Destino = cgiGet( edtavDestino_Internalname);
            AssignAttri("", false, "AV11Destino", AV11Destino);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDESTINO"), AV11Destino) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E120L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120L2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            AV15IdEmpresa = (long)(Math.Round(NumberUtil.Val( AV16WebSession.Get("EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV15IdEmpresa", StringUtil.LTrimStr( (decimal)(AV15IdEmpresa), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vIDEMPRESA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15IdEmpresa), "ZZZZZZZZZZZ9"), context));
         }
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV19Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV19Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV12Update = "Editar";
         AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
         AV13Delete = "Excluir";
         AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
         Form.Caption = "Registros de Locação de Veículos";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
      }

      protected void E130L2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
      }

      private void E140L2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("tregistropedido.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(A16RegistroPedidoId,12,0))}, new string[] {"Mode","EmpresaId","RegistroPedidoId"}) ;
         edtavDelete_Link = formatLink("tregistropedido.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(A16RegistroPedidoId,12,0))}, new string[] {"Mode","EmpresaId","RegistroPedidoId"}) ;
         edtEmpresaNome_Link = formatLink("viewtempresa.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EmpresaId","TabCode"}) ;
         edtDestino_Link = formatLink("viewtregistropedido.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1EmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(A16RegistroPedidoId,12,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"EmpresaId","RegistroPedidoId","TabCode"}) ;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Component1 = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Component1_Component), StringUtil.Lower( "WPDashboard")) != 0 )
         {
            WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wpdashboard", new Object[] {context} );
            WebComp_Component1.ComponentInit();
            WebComp_Component1.Name = "WPDashboard";
            WebComp_Component1_Component = "WPDashboard";
         }
         if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
         {
            WebComp_Component1.setjustcreated();
            WebComp_Component1.componentprepare(new Object[] {(string)"W0040",(string)""});
            WebComp_Component1.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Component1 )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0040"+"");
            WebComp_Component1.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 27;
         }
         sendrow_272( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_27_Refreshing )
         {
            DoAjaxLoad(27, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E110L2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("tregistropedido.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(AV15IdEmpresa,12,0)),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","EmpresaId","RegistroPedidoId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV19Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "TRegistroPedido";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( StringUtil.StrCmp(WebComp_Component1_Component, "") == 0 )
         {
            WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wpdashboard", new Object[] {context} );
            WebComp_Component1.ComponentInit();
            WebComp_Component1.Name = "WPDashboard";
            WebComp_Component1_Component = "WPDashboard";
         }
         if ( ! ( WebComp_Component1 == null ) )
         {
            if ( StringUtil.Len( WebComp_Component1_Component) != 0 )
            {
               WebComp_Component1.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202442617142061", true, true);
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
         context.AddJavascriptSource("wwtregistropedido.js", "?202442617142061", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_272( )
      {
         edtEmpresaId_Internalname = "EMPRESAID_"+sGXsfl_27_idx;
         edtRegistroPedidoId_Internalname = "REGISTROPEDIDOID_"+sGXsfl_27_idx;
         edtEmpresaNome_Internalname = "EMPRESANOME_"+sGXsfl_27_idx;
         edtVeiculoMarca_Internalname = "VEICULOMARCA_"+sGXsfl_27_idx;
         dynClienteId_Internalname = "CLIENTEID_"+sGXsfl_27_idx;
         edtDestino_Internalname = "DESTINO_"+sGXsfl_27_idx;
         edtDataRetirada_Internalname = "DATARETIRADA_"+sGXsfl_27_idx;
         edtDataRetorno_Internalname = "DATARETORNO_"+sGXsfl_27_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_27_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_27_idx;
      }

      protected void SubsflControlProps_fel_272( )
      {
         edtEmpresaId_Internalname = "EMPRESAID_"+sGXsfl_27_fel_idx;
         edtRegistroPedidoId_Internalname = "REGISTROPEDIDOID_"+sGXsfl_27_fel_idx;
         edtEmpresaNome_Internalname = "EMPRESANOME_"+sGXsfl_27_fel_idx;
         edtVeiculoMarca_Internalname = "VEICULOMARCA_"+sGXsfl_27_fel_idx;
         dynClienteId_Internalname = "CLIENTEID_"+sGXsfl_27_fel_idx;
         edtDestino_Internalname = "DESTINO_"+sGXsfl_27_fel_idx;
         edtDataRetirada_Internalname = "DATARETIRADA_"+sGXsfl_27_fel_idx;
         edtDataRetorno_Internalname = "DATARETORNO_"+sGXsfl_27_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_27_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_27_fel_idx;
      }

      protected void sendrow_272( )
      {
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         WB0L0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_27_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_27_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ww__grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_27_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpresaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpresaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdAuto",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroPedidoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16RegistroPedidoId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroPedidoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdManual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpresaNome_Internalname,(string)A2EmpresaNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEmpresaNome_Link,(string)"",(string)"",(string)"",(string)edtEmpresaNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVeiculoMarca_Internalname,(string)A11VeiculoMarca,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVeiculoMarca_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynClienteId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTEID_" + sGXsfl_27_idx;
               dynClienteId.Name = GXCCtl;
               dynClienteId.WebTags = "";
               dynClienteId.removeAllItems();
               /* Using cursor H000L4 */
               pr_default.execute(2);
               while ( (pr_default.getStatus(2) != 101) )
               {
                  dynClienteId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000L4_A5ClienteId[0]), 12, 0)), H000L4_A6ClienteNome[0], 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( dynClienteId.ItemCount > 0 )
               {
                  A5ClienteId = (long)(Math.Round(NumberUtil.Val( dynClienteId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynClienteId,(string)dynClienteId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0)),(short)1,(string)dynClienteId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"column column-optional",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynClienteId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0));
            AssignProp("", false, dynClienteId_Internalname, "Values", (string)(dynClienteId.ToJavascriptSource()), !bGXsfl_27_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDestino_Internalname,StringUtil.RTrim( A17Destino),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtDestino_Link,(string)"",(string)"",(string)"",(string)edtDestino_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDataRetirada_Internalname,context.localUtil.Format(A24DataRetirada, "99/99/9999"),context.localUtil.Format( A24DataRetirada, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDataRetirada_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDataRetorno_Internalname,context.localUtil.Format(A25DataRetorno, "99/99/9999"),context.localUtil.Format( A25DataRetorno, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDataRetorno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes0L2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_27_idx = ((subGrid_Islastpage==1)&&(nGXsfl_27_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         /* End function sendrow_272 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "CLIENTEID_" + sGXsfl_27_idx;
         dynClienteId.Name = GXCCtl;
         dynClienteId.WebTags = "";
         dynClienteId.removeAllItems();
         /* Using cursor H000L5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynClienteId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000L5_A5ClienteId[0]), 12, 0)), H000L5_A6ClienteNome[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynClienteId.ItemCount > 0 )
         {
            A5ClienteId = (long)(Math.Round(NumberUtil.Val( dynClienteId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5ClienteId), 12, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl27( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"27\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ww__grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Empresa Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Empresa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Veículo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Destino") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data da Retirada") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data do Retorno") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "ww__grid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2EmpresaNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtEmpresaNome_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11VeiculoMarca));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A17Destino)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtDestino_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A24DataRetirada, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A25DataRetorno, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         bttBtninsert_Internalname = "BTNINSERT";
         edtavDestino_Internalname = "vDESTINO";
         divTabletop_Internalname = "TABLETOP";
         edtEmpresaId_Internalname = "EMPRESAID";
         edtRegistroPedidoId_Internalname = "REGISTROPEDIDOID";
         edtEmpresaNome_Internalname = "EMPRESANOME";
         edtVeiculoMarca_Internalname = "VEICULOMARCA";
         dynClienteId_Internalname = "CLIENTEID";
         edtDestino_Internalname = "DESTINO";
         edtDataRetirada_Internalname = "DATARETIRADA";
         edtDataRetorno_Internalname = "DATARETORNO";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ProjetoFrotas", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtDataRetorno_Jsonclick = "";
         edtDataRetirada_Jsonclick = "";
         edtDestino_Jsonclick = "";
         edtDestino_Link = "";
         dynClienteId_Jsonclick = "";
         edtVeiculoMarca_Jsonclick = "";
         edtEmpresaNome_Jsonclick = "";
         edtEmpresaNome_Link = "";
         edtRegistroPedidoId_Jsonclick = "";
         edtEmpresaId_Jsonclick = "";
         subGrid_Class = "ww__grid";
         subGrid_Backcolorstyle = 0;
         edtDataRetorno_Enabled = 0;
         edtDataRetirada_Enabled = 0;
         edtDestino_Enabled = 0;
         dynClienteId.Enabled = 0;
         edtVeiculoMarca_Enabled = 0;
         edtEmpresaNome_Enabled = 0;
         edtRegistroPedidoId_Enabled = 0;
         edtEmpresaId_Enabled = 0;
         edtavDestino_Jsonclick = "";
         edtavDestino_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Work With Registros de Locação de Veículos";
         subGrid_Rows = 10;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11Destino","fld":"vDESTINO"},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"},{"av":"AV15IdEmpresa","fld":"vIDEMPRESA","pic":"ZZZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E140L2","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"A16RegistroPedidoId","fld":"REGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtEmpresaNome_Link","ctrl":"EMPRESANOME","prop":"Link"},{"av":"edtDestino_Link","ctrl":"DESTINO","prop":"Link"},{"ctrl":"COMPONENT1"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E110L2","iparms":[{"av":"AV15IdEmpresa","fld":"vIDEMPRESA","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"A16RegistroPedidoId","fld":"REGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9","hsh":true}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11Destino","fld":"vDESTINO"},{"av":"AV15IdEmpresa","fld":"vIDEMPRESA","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11Destino","fld":"vDESTINO"},{"av":"AV15IdEmpresa","fld":"vIDEMPRESA","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11Destino","fld":"vDESTINO"},{"av":"AV15IdEmpresa","fld":"vIDEMPRESA","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11Destino","fld":"vDESTINO"},{"av":"AV15IdEmpresa","fld":"vIDEMPRESA","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"AV12Update","fld":"vUPDATE"},{"av":"AV13Delete","fld":"vDELETE"}]}""");
         setEventMetadata("VALID_EMPRESAID","""{"handler":"Valid_Empresaid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
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
         AV12Update = "";
         AV13Delete = "";
         AV11Destino = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         WebComp_Component1_Component = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A2EmpresaNome = "";
         A11VeiculoMarca = "";
         A17Destino = "";
         A24DataRetirada = DateTime.MinValue;
         A25DataRetorno = DateTime.MinValue;
         AV19Pgmname = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         lV11Destino = "";
         H000L2_A10VeiculoId = new long[1] ;
         H000L2_A1EmpresaId = new long[1] ;
         H000L2_A25DataRetorno = new DateTime[] {DateTime.MinValue} ;
         H000L2_n25DataRetorno = new bool[] {false} ;
         H000L2_A24DataRetirada = new DateTime[] {DateTime.MinValue} ;
         H000L2_A17Destino = new string[] {""} ;
         H000L2_A5ClienteId = new long[1] ;
         H000L2_A11VeiculoMarca = new string[] {""} ;
         H000L2_A2EmpresaNome = new string[] {""} ;
         H000L2_A16RegistroPedidoId = new long[1] ;
         H000L3_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         AV16WebSession = context.GetSession();
         GridRow = new GXWebRow();
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV6Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         H000L4_A1EmpresaId = new long[1] ;
         H000L4_A5ClienteId = new long[1] ;
         H000L4_A6ClienteNome = new string[] {""} ;
         H000L5_A1EmpresaId = new long[1] ;
         H000L5_A5ClienteId = new long[1] ;
         H000L5_A6ClienteNome = new string[] {""} ;
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwtregistropedido__default(),
            new Object[][] {
                new Object[] {
               H000L2_A10VeiculoId, H000L2_A1EmpresaId, H000L2_A25DataRetorno, H000L2_n25DataRetorno, H000L2_A24DataRetirada, H000L2_A17Destino, H000L2_A5ClienteId, H000L2_A11VeiculoMarca, H000L2_A2EmpresaNome, H000L2_A16RegistroPedidoId
               }
               , new Object[] {
               H000L3_AGRID_nRecordCount
               }
               , new Object[] {
               H000L4_A1EmpresaId, H000L4_A5ClienteId, H000L4_A6ClienteNome
               }
               , new Object[] {
               H000L5_A1EmpresaId, H000L5_A5ClienteId, H000L5_A6ClienteNome
               }
            }
         );
         WebComp_Component1 = new GeneXus.Http.GXNullWebComponent();
         AV19Pgmname = "WWTRegistroPedido";
         /* GeneXus formulas. */
         AV19Pgmname = "WWTRegistroPedido";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_27 ;
      private int subGrid_Rows ;
      private int nGXsfl_27_idx=1 ;
      private int edtavDestino_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GridPageCount ;
      private int edtEmpresaId_Enabled ;
      private int edtRegistroPedidoId_Enabled ;
      private int edtEmpresaNome_Enabled ;
      private int edtVeiculoMarca_Enabled ;
      private int edtDestino_Enabled ;
      private int edtDataRetirada_Enabled ;
      private int edtDataRetorno_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV15IdEmpresa ;
      private long A1EmpresaId ;
      private long A16RegistroPedidoId ;
      private long A5ClienteId ;
      private long GRID_nCurrentRecord ;
      private long A10VeiculoId ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_27_idx="0001" ;
      private string AV12Update ;
      private string AV13Delete ;
      private string AV11Destino ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string edtavDestino_Internalname ;
      private string edtavDestino_Jsonclick ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string WebComp_Component1_Component ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtEmpresaId_Internalname ;
      private string edtRegistroPedidoId_Internalname ;
      private string edtEmpresaNome_Internalname ;
      private string edtVeiculoMarca_Internalname ;
      private string dynClienteId_Internalname ;
      private string A17Destino ;
      private string edtDestino_Internalname ;
      private string edtDataRetirada_Internalname ;
      private string edtDataRetorno_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string AV19Pgmname ;
      private string lV11Destino ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtEmpresaNome_Link ;
      private string edtDestino_Link ;
      private string sGXsfl_27_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtEmpresaId_Jsonclick ;
      private string edtRegistroPedidoId_Jsonclick ;
      private string edtEmpresaNome_Jsonclick ;
      private string edtVeiculoMarca_Jsonclick ;
      private string GXCCtl ;
      private string dynClienteId_Jsonclick ;
      private string edtDestino_Jsonclick ;
      private string edtDataRetirada_Jsonclick ;
      private string edtDataRetorno_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A24DataRetirada ;
      private DateTime A25DataRetorno ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool bGXsfl_27_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n25DataRetorno ;
      private bool bDynCreated_Component1 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A2EmpresaNome ;
      private string A11VeiculoMarca ;
      private IGxSession AV16WebSession ;
      private GXWebComponent WebComp_Component1 ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynClienteId ;
      private IDataStoreProvider pr_default ;
      private long[] H000L2_A10VeiculoId ;
      private long[] H000L2_A1EmpresaId ;
      private DateTime[] H000L2_A25DataRetorno ;
      private bool[] H000L2_n25DataRetorno ;
      private DateTime[] H000L2_A24DataRetirada ;
      private string[] H000L2_A17Destino ;
      private long[] H000L2_A5ClienteId ;
      private string[] H000L2_A11VeiculoMarca ;
      private string[] H000L2_A2EmpresaNome ;
      private long[] H000L2_A16RegistroPedidoId ;
      private long[] H000L3_AGRID_nRecordCount ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] H000L4_A1EmpresaId ;
      private long[] H000L4_A5ClienteId ;
      private string[] H000L4_A6ClienteNome ;
      private long[] H000L5_A1EmpresaId ;
      private long[] H000L5_A5ClienteId ;
      private string[] H000L5_A6ClienteNome ;
   }

   public class wwtregistropedido__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000L2( IGxContext context ,
                                             string AV11Destino ,
                                             string A17Destino ,
                                             long A1EmpresaId ,
                                             long AV15IdEmpresa )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[VeiculoId], T1.[EmpresaId], T1.[DataRetorno], T1.[DataRetirada], T1.[Destino], T1.[ClienteId], T3.[VeiculoMarca], T2.[EmpresaNome], T1.[RegistroPedidoId]";
         sFromString = " FROM (([TRegistroPedido] T1 INNER JOIN [TEmpresa] T2 ON T2.[EmpresaId] = T1.[EmpresaId]) INNER JOIN [TVeiculo] T3 ON T3.[EmpresaId] = T1.[EmpresaId] AND T3.[VeiculoId] = T1.[VeiculoId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[EmpresaId] = @AV15IdEmpresa)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Destino)) )
         {
            AddWhere(sWhereString, "(T1.[Destino] like @lV11Destino)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY T1.[Destino]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000L3( IGxContext context ,
                                             string AV11Destino ,
                                             string A17Destino ,
                                             long A1EmpresaId ,
                                             long AV15IdEmpresa )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([TRegistroPedido] T1 INNER JOIN [TEmpresa] T2 ON T2.[EmpresaId] = T1.[EmpresaId]) INNER JOIN [TVeiculo] T3 ON T3.[EmpresaId] = T1.[EmpresaId] AND T3.[VeiculoId] = T1.[VeiculoId])";
         AddWhere(sWhereString, "(T1.[EmpresaId] = @AV15IdEmpresa)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Destino)) )
         {
            AddWhere(sWhereString, "(T1.[Destino] like @lV11Destino)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
               case 1 :
                     return conditional_H000L3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000L4;
          prmH000L4 = new Object[] {
          };
          Object[] prmH000L5;
          prmH000L5 = new Object[] {
          };
          Object[] prmH000L2;
          prmH000L2 = new Object[] {
          new ParDef("@AV15IdEmpresa",GXType.Decimal,12,0) ,
          new ParDef("@lV11Destino",GXType.NChar,20,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000L3;
          prmH000L3 = new Object[] {
          new ParDef("@AV15IdEmpresa",GXType.Decimal,12,0) ,
          new ParDef("@lV11Destino",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L4", "SELECT [EmpresaId], [ClienteId], [ClienteNome] FROM [TCliente] ORDER BY [ClienteNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L5", "SELECT [EmpresaId], [ClienteId], [ClienteNome] FROM [TCliente] ORDER BY [ClienteNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L5,0, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
