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
   public class gx0021 : GXDataArea
   {
      public gx0021( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public gx0021( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pEmpresaId ,
                           out long aP1_pClienteId )
      {
         this.AV11pEmpresaId = aP0_pEmpresaId;
         this.AV12pClienteId = 0 ;
         ExecuteImpl();
         aP1_pClienteId=this.AV12pClienteId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pEmpresaId");
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
               gxfirstwebparm = GetFirstPar( "pEmpresaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pEmpresaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV11pEmpresaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pEmpresaId", StringUtil.LTrimStr( (decimal)(AV11pEmpresaId), 12, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "pClienteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12pClienteId", StringUtil.LTrimStr( (decimal)(AV12pClienteId), 12, 0));
               }
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "cClienteId"), "."), 18, MidpointRounding.ToEven));
         AV7cClienteNome = GetPar( "cClienteNome");
         AV8cClienteCPF = (long)(Math.Round(NumberUtil.Val( GetPar( "cClienteCPF"), "."), 18, MidpointRounding.ToEven));
         AV9cClienteEmail = GetPar( "cClienteEmail");
         AV10cClienteTelefone = GetPar( "cClienteTelefone");
         AV11pEmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "pEmpresaId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteCPF, AV9cClienteEmail, AV10cClienteTelefone, AV11pEmpresaId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA062( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START062( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0021.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pEmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV12pClienteId,12,0))}, new string[] {"pEmpresaId","pClienteId"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cClienteId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTENOME", AV7cClienteNome);
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTECPF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cClienteCPF), 11, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTEEMAIL", AV9cClienteEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTETELEFONE", StringUtil.RTrim( AV10cClienteTelefone));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPEMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pEmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pClienteId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTEIDFILTERCONTAINER_Class", StringUtil.RTrim( divClienteidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTENOMEFILTERCONTAINER_Class", StringUtil.RTrim( divClientenomefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTECPFFILTERCONTAINER_Class", StringUtil.RTrim( divClientecpffiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTEEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divClienteemailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTETELEFONEFILTERCONTAINER_Class", StringUtil.RTrim( divClientetelefonefiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE062( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT062( ) ;
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
         return formatLink("gx0021.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pEmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV12pClienteId,12,0))}, new string[] {"pEmpresaId","pClienteId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0021" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List TCliente" ;
      }

      protected void WB060( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClienteidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divClienteidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclienteidfilter_Internalname, "Cliente Id", "", "", lblLblclienteidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclienteid_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cClienteId), 12, 0, ".", "")), StringUtil.LTrim( ((edtavCclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cClienteId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cClienteId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclienteid_Visible, edtavCclienteid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divClientenomefiltercontainer_Internalname, 1, 0, "px", 0, "px", divClientenomefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientenomefilter_Internalname, "Cliente Nome", "", "", lblLblclientenomefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclientenome_Internalname, "Cliente Nome", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclientenome_Internalname, AV7cClienteNome, StringUtil.RTrim( context.localUtil.Format( AV7cClienteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclientenome_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclientenome_Visible, edtavCclientenome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divClientecpffiltercontainer_Internalname, 1, 0, "px", 0, "px", divClientecpffiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientecpffilter_Internalname, "Cliente CPF", "", "", lblLblclientecpffilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclientecpf_Internalname, "Cliente CPF", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclientecpf_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cClienteCPF), 11, 0, ".", "")), StringUtil.LTrim( ((edtavCclientecpf_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cClienteCPF), "ZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cClienteCPF), "ZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclientecpf_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclientecpf_Visible, edtavCclientecpf_Enabled, 0, "text", "1", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divClienteemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divClienteemailfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclienteemailfilter_Internalname, "Cliente Email", "", "", lblLblclienteemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclienteemail_Internalname, "Cliente Email", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclienteemail_Internalname, AV9cClienteEmail, StringUtil.RTrim( context.localUtil.Format( AV9cClienteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclienteemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclienteemail_Visible, edtavCclienteemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divClientetelefonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divClientetelefonefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientetelefonefilter_Internalname, "Cliente Telefone", "", "", lblLblclientetelefonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15061_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclientetelefone_Internalname, "Cliente Telefone", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclientetelefone_Internalname, StringUtil.RTrim( AV10cClienteTelefone), StringUtil.RTrim( context.localUtil.Format( AV10cClienteTelefone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclientetelefone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclientetelefone_Visible, edtavCclientetelefone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16061_client"+"'", TempTags, "", 2, "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0021.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START062( )
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
         Form.Meta.addItem("description", "Selection List TCliente", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP060( ) ;
      }

      protected void WS062( )
      {
         START062( ) ;
         EVT062( ) ;
      }

      protected void EVT062( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A5ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A6ClienteNome = cgiGet( edtClienteNome_Internalname);
                              A7ClienteCPF = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteCPF_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A9ClienteTelefone = cgiGet( edtClienteTelefone_Internalname);
                              A1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17062 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18062 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cclienteid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTEID"), ".", ",") != Convert.ToDecimal( AV6cClienteId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclientenome Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTENOME"), AV7cClienteNome) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclientecpf Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTECPF"), ".", ",") != Convert.ToDecimal( AV8cClienteCPF )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclienteemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTEEMAIL"), AV9cClienteEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclientetelefone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTETELEFONE"), AV10cClienteTelefone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19062 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE062( )
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

      protected void PA062( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cClienteId ,
                                        string AV7cClienteNome ,
                                        long AV8cClienteCPF ,
                                        string AV9cClienteEmail ,
                                        string AV10cClienteTelefone ,
                                        long AV11pEmpresaId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF062( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A5ClienteId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")));
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
         RF062( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF062( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cClienteNome ,
                                                 AV8cClienteCPF ,
                                                 AV9cClienteEmail ,
                                                 AV10cClienteTelefone ,
                                                 A6ClienteNome ,
                                                 A7ClienteCPF ,
                                                 A8ClienteEmail ,
                                                 A9ClienteTelefone ,
                                                 AV11pEmpresaId ,
                                                 AV6cClienteId ,
                                                 A1EmpresaId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV7cClienteNome = StringUtil.Concat( StringUtil.RTrim( AV7cClienteNome), "%", "");
            lV9cClienteEmail = StringUtil.Concat( StringUtil.RTrim( AV9cClienteEmail), "%", "");
            lV10cClienteTelefone = StringUtil.PadR( StringUtil.RTrim( AV10cClienteTelefone), 20, "%");
            /* Using cursor H00062 */
            pr_default.execute(0, new Object[] {AV11pEmpresaId, AV6cClienteId, lV7cClienteNome, AV8cClienteCPF, lV9cClienteEmail, lV10cClienteTelefone, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A8ClienteEmail = H00062_A8ClienteEmail[0];
               A1EmpresaId = H00062_A1EmpresaId[0];
               A9ClienteTelefone = H00062_A9ClienteTelefone[0];
               A7ClienteCPF = H00062_A7ClienteCPF[0];
               A6ClienteNome = H00062_A6ClienteNome[0];
               A5ClienteId = H00062_A5ClienteId[0];
               /* Execute user event: Load */
               E18062 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB060( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes062( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A5ClienteId), "ZZZZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cClienteNome ,
                                              AV8cClienteCPF ,
                                              AV9cClienteEmail ,
                                              AV10cClienteTelefone ,
                                              A6ClienteNome ,
                                              A7ClienteCPF ,
                                              A8ClienteEmail ,
                                              A9ClienteTelefone ,
                                              AV11pEmpresaId ,
                                              AV6cClienteId ,
                                              A1EmpresaId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV7cClienteNome = StringUtil.Concat( StringUtil.RTrim( AV7cClienteNome), "%", "");
         lV9cClienteEmail = StringUtil.Concat( StringUtil.RTrim( AV9cClienteEmail), "%", "");
         lV10cClienteTelefone = StringUtil.PadR( StringUtil.RTrim( AV10cClienteTelefone), 20, "%");
         /* Using cursor H00063 */
         pr_default.execute(1, new Object[] {AV11pEmpresaId, AV6cClienteId, lV7cClienteNome, AV8cClienteCPF, lV9cClienteEmail, lV10cClienteTelefone});
         GRID1_nRecordCount = H00063_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteCPF, AV9cClienteEmail, AV10cClienteTelefone, AV11pEmpresaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteCPF, AV9cClienteEmail, AV10cClienteTelefone, AV11pEmpresaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteCPF, AV9cClienteEmail, AV10cClienteTelefone, AV11pEmpresaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteCPF, AV9cClienteEmail, AV10cClienteTelefone, AV11pEmpresaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteCPF, AV9cClienteEmail, AV10cClienteTelefone, AV11pEmpresaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtClienteNome_Enabled = 0;
         AssignProp("", false, edtClienteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteNome_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtClienteCPF_Enabled = 0;
         AssignProp("", false, edtClienteCPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCPF_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtClienteTelefone_Enabled = 0;
         AssignProp("", false, edtClienteTelefone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTelefone_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP060( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17062 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCLIENTEID");
               GX_FocusControl = edtavCclienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cClienteId = 0;
               AssignAttri("", false, "AV6cClienteId", StringUtil.LTrimStr( (decimal)(AV6cClienteId), 12, 0));
            }
            else
            {
               AV6cClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cClienteId", StringUtil.LTrimStr( (decimal)(AV6cClienteId), 12, 0));
            }
            AV7cClienteNome = cgiGet( edtavCclientenome_Internalname);
            AssignAttri("", false, "AV7cClienteNome", AV7cClienteNome);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCclientecpf_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCclientecpf_Internalname), ".", ",") > Convert.ToDecimal( 99999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCLIENTECPF");
               GX_FocusControl = edtavCclientecpf_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cClienteCPF = 0;
               AssignAttri("", false, "AV8cClienteCPF", StringUtil.LTrimStr( (decimal)(AV8cClienteCPF), 11, 0));
            }
            else
            {
               AV8cClienteCPF = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCclientecpf_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cClienteCPF", StringUtil.LTrimStr( (decimal)(AV8cClienteCPF), 11, 0));
            }
            AV9cClienteEmail = cgiGet( edtavCclienteemail_Internalname);
            AssignAttri("", false, "AV9cClienteEmail", AV9cClienteEmail);
            AV10cClienteTelefone = cgiGet( edtavCclientetelefone_Internalname);
            AssignAttri("", false, "AV10cClienteTelefone", AV10cClienteTelefone);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTEID"), ".", ",") != Convert.ToDecimal( AV6cClienteId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTENOME"), AV7cClienteNome) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTECPF"), ".", ",") != Convert.ToDecimal( AV8cClienteCPF )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTEEMAIL"), AV9cClienteEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTETELEFONE"), AV10cClienteTelefone) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E17062 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17062( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "TCliente", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E18062( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19062 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19062( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pClienteId = A5ClienteId;
         AssignAttri("", false, "AV12pClienteId", StringUtil.LTrimStr( (decimal)(AV12pClienteId), 12, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pClienteId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pClienteId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11pEmpresaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV11pEmpresaId", StringUtil.LTrimStr( (decimal)(AV11pEmpresaId), 12, 0));
         AV12pClienteId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV12pClienteId", StringUtil.LTrimStr( (decimal)(AV12pClienteId), 12, 0));
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
         PA062( ) ;
         WS062( ) ;
         WE062( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202442617152548", true, true);
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
         context.AddJavascriptSource("gx0021.js", "?202442617152548", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_64_idx;
         edtClienteNome_Internalname = "CLIENTENOME_"+sGXsfl_64_idx;
         edtClienteCPF_Internalname = "CLIENTECPF_"+sGXsfl_64_idx;
         edtClienteTelefone_Internalname = "CLIENTETELEFONE_"+sGXsfl_64_idx;
         edtEmpresaId_Internalname = "EMPRESAID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_64_fel_idx;
         edtClienteNome_Internalname = "CLIENTENOME_"+sGXsfl_64_fel_idx;
         edtClienteCPF_Internalname = "CLIENTECPF_"+sGXsfl_64_fel_idx;
         edtClienteTelefone_Internalname = "CLIENTETELEFONE_"+sGXsfl_64_fel_idx;
         edtEmpresaId_Internalname = "EMPRESAID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB060( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5ClienteId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdManual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtClienteNome_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtClienteNome_Internalname, "Link", edtClienteNome_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteNome_Internalname,(string)A6ClienteNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtClienteNome_Link,(string)"",(string)"",(string)"",(string)edtClienteNome_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCPF_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ClienteCPF), 11, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7ClienteCPF), "ZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCPF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A9ClienteTelefone);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTelefone_Internalname,StringUtil.RTrim( A9ClienteTelefone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtClienteTelefone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpresaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpresaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdAuto",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes062( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Telefone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Empresa Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A6ClienteNome));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtClienteNome_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7ClienteCPF), 11, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A9ClienteTelefone)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblclienteidfilter_Internalname = "LBLCLIENTEIDFILTER";
         edtavCclienteid_Internalname = "vCCLIENTEID";
         divClienteidfiltercontainer_Internalname = "CLIENTEIDFILTERCONTAINER";
         lblLblclientenomefilter_Internalname = "LBLCLIENTENOMEFILTER";
         edtavCclientenome_Internalname = "vCCLIENTENOME";
         divClientenomefiltercontainer_Internalname = "CLIENTENOMEFILTERCONTAINER";
         lblLblclientecpffilter_Internalname = "LBLCLIENTECPFFILTER";
         edtavCclientecpf_Internalname = "vCCLIENTECPF";
         divClientecpffiltercontainer_Internalname = "CLIENTECPFFILTERCONTAINER";
         lblLblclienteemailfilter_Internalname = "LBLCLIENTEEMAILFILTER";
         edtavCclienteemail_Internalname = "vCCLIENTEEMAIL";
         divClienteemailfiltercontainer_Internalname = "CLIENTEEMAILFILTERCONTAINER";
         lblLblclientetelefonefilter_Internalname = "LBLCLIENTETELEFONEFILTER";
         edtavCclientetelefone_Internalname = "vCCLIENTETELEFONE";
         divClientetelefonefiltercontainer_Internalname = "CLIENTETELEFONEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteNome_Internalname = "CLIENTENOME";
         edtClienteCPF_Internalname = "CLIENTECPF";
         edtClienteTelefone_Internalname = "CLIENTETELEFONE";
         edtEmpresaId_Internalname = "EMPRESAID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("ProjetoFrotas", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtEmpresaId_Jsonclick = "";
         edtClienteTelefone_Jsonclick = "";
         edtClienteCPF_Jsonclick = "";
         edtClienteNome_Jsonclick = "";
         edtClienteNome_Link = "";
         edtClienteId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtEmpresaId_Enabled = 0;
         edtClienteTelefone_Enabled = 0;
         edtClienteCPF_Enabled = 0;
         edtClienteNome_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtavCclientetelefone_Jsonclick = "";
         edtavCclientetelefone_Enabled = 1;
         edtavCclientetelefone_Visible = 1;
         edtavCclienteemail_Jsonclick = "";
         edtavCclienteemail_Enabled = 1;
         edtavCclienteemail_Visible = 1;
         edtavCclientecpf_Jsonclick = "";
         edtavCclientecpf_Enabled = 1;
         edtavCclientecpf_Visible = 1;
         edtavCclientenome_Jsonclick = "";
         edtavCclientenome_Enabled = 1;
         edtavCclientenome_Visible = 1;
         edtavCclienteid_Jsonclick = "";
         edtavCclienteid_Enabled = 1;
         edtavCclienteid_Visible = 1;
         divClientetelefonefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divClienteemailfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divClientecpffiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divClientenomefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divClienteidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List TCliente";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cClienteNome","fld":"vCCLIENTENOME"},{"av":"AV8cClienteCPF","fld":"vCCLIENTECPF","pic":"ZZZZZZZZZZ9"},{"av":"AV9cClienteEmail","fld":"vCCLIENTEEMAIL"},{"av":"AV10cClienteTelefone","fld":"vCCLIENTETELEFONE"},{"av":"AV11pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E16061","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLCLIENTEIDFILTER.CLICK","""{"handler":"E11061","iparms":[{"av":"divClienteidfiltercontainer_Class","ctrl":"CLIENTEIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCLIENTEIDFILTER.CLICK",""","oparms":[{"av":"divClienteidfiltercontainer_Class","ctrl":"CLIENTEIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCclienteid_Visible","ctrl":"vCCLIENTEID","prop":"Visible"}]}""");
         setEventMetadata("LBLCLIENTENOMEFILTER.CLICK","""{"handler":"E12061","iparms":[{"av":"divClientenomefiltercontainer_Class","ctrl":"CLIENTENOMEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCLIENTENOMEFILTER.CLICK",""","oparms":[{"av":"divClientenomefiltercontainer_Class","ctrl":"CLIENTENOMEFILTERCONTAINER","prop":"Class"},{"av":"edtavCclientenome_Visible","ctrl":"vCCLIENTENOME","prop":"Visible"}]}""");
         setEventMetadata("LBLCLIENTECPFFILTER.CLICK","""{"handler":"E13061","iparms":[{"av":"divClientecpffiltercontainer_Class","ctrl":"CLIENTECPFFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCLIENTECPFFILTER.CLICK",""","oparms":[{"av":"divClientecpffiltercontainer_Class","ctrl":"CLIENTECPFFILTERCONTAINER","prop":"Class"},{"av":"edtavCclientecpf_Visible","ctrl":"vCCLIENTECPF","prop":"Visible"}]}""");
         setEventMetadata("LBLCLIENTEEMAILFILTER.CLICK","""{"handler":"E14061","iparms":[{"av":"divClienteemailfiltercontainer_Class","ctrl":"CLIENTEEMAILFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCLIENTEEMAILFILTER.CLICK",""","oparms":[{"av":"divClienteemailfiltercontainer_Class","ctrl":"CLIENTEEMAILFILTERCONTAINER","prop":"Class"},{"av":"edtavCclienteemail_Visible","ctrl":"vCCLIENTEEMAIL","prop":"Visible"}]}""");
         setEventMetadata("LBLCLIENTETELEFONEFILTER.CLICK","""{"handler":"E15061","iparms":[{"av":"divClientetelefonefiltercontainer_Class","ctrl":"CLIENTETELEFONEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCLIENTETELEFONEFILTER.CLICK",""","oparms":[{"av":"divClientetelefonefiltercontainer_Class","ctrl":"CLIENTETELEFONEFILTERCONTAINER","prop":"Class"},{"av":"edtavCclientetelefone_Visible","ctrl":"vCCLIENTETELEFONE","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E19062","iparms":[{"av":"A5ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV12pClienteId","fld":"vPCLIENTEID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cClienteNome","fld":"vCCLIENTENOME"},{"av":"AV8cClienteCPF","fld":"vCCLIENTECPF","pic":"ZZZZZZZZZZ9"},{"av":"AV9cClienteEmail","fld":"vCCLIENTEEMAIL"},{"av":"AV10cClienteTelefone","fld":"vCCLIENTETELEFONE"},{"av":"AV11pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cClienteNome","fld":"vCCLIENTENOME"},{"av":"AV8cClienteCPF","fld":"vCCLIENTECPF","pic":"ZZZZZZZZZZ9"},{"av":"AV9cClienteEmail","fld":"vCCLIENTEEMAIL"},{"av":"AV10cClienteTelefone","fld":"vCCLIENTETELEFONE"},{"av":"AV11pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cClienteNome","fld":"vCCLIENTENOME"},{"av":"AV8cClienteCPF","fld":"vCCLIENTECPF","pic":"ZZZZZZZZZZ9"},{"av":"AV9cClienteEmail","fld":"vCCLIENTEEMAIL"},{"av":"AV10cClienteTelefone","fld":"vCCLIENTETELEFONE"},{"av":"AV11pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cClienteNome","fld":"vCCLIENTENOME"},{"av":"AV8cClienteCPF","fld":"vCCLIENTECPF","pic":"ZZZZZZZZZZ9"},{"av":"AV9cClienteEmail","fld":"vCCLIENTEEMAIL"},{"av":"AV10cClienteTelefone","fld":"vCCLIENTETELEFONE"},{"av":"AV11pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("VALIDV_CCLIENTEEMAIL","""{"handler":"Validv_Cclienteemail","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Empresaid","iparms":[]}""");
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
         AV7cClienteNome = "";
         AV9cClienteEmail = "";
         AV10cClienteTelefone = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblclienteidfilter_Jsonclick = "";
         TempTags = "";
         lblLblclientenomefilter_Jsonclick = "";
         lblLblclientecpffilter_Jsonclick = "";
         lblLblclienteemailfilter_Jsonclick = "";
         lblLblclientetelefonefilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV14Linkselection_GXI = "";
         A6ClienteNome = "";
         A9ClienteTelefone = "";
         lV7cClienteNome = "";
         lV9cClienteEmail = "";
         lV10cClienteTelefone = "";
         A8ClienteEmail = "";
         H00062_A8ClienteEmail = new string[] {""} ;
         H00062_A1EmpresaId = new long[1] ;
         H00062_A9ClienteTelefone = new string[] {""} ;
         H00062_A7ClienteCPF = new long[1] ;
         H00062_A6ClienteNome = new string[] {""} ;
         H00062_A5ClienteId = new long[1] ;
         H00063_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0021__default(),
            new Object[][] {
                new Object[] {
               H00062_A8ClienteEmail, H00062_A1EmpresaId, H00062_A9ClienteTelefone, H00062_A7ClienteCPF, H00062_A6ClienteNome, H00062_A5ClienteId
               }
               , new Object[] {
               H00063_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCclienteid_Enabled ;
      private int edtavCclienteid_Visible ;
      private int edtavCclientenome_Visible ;
      private int edtavCclientenome_Enabled ;
      private int edtavCclientecpf_Enabled ;
      private int edtavCclientecpf_Visible ;
      private int edtavCclienteemail_Visible ;
      private int edtavCclienteemail_Enabled ;
      private int edtavCclientetelefone_Visible ;
      private int edtavCclientetelefone_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtClienteId_Enabled ;
      private int edtClienteNome_Enabled ;
      private int edtClienteCPF_Enabled ;
      private int edtClienteTelefone_Enabled ;
      private int edtEmpresaId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV11pEmpresaId ;
      private long AV12pClienteId ;
      private long wcpOAV11pEmpresaId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cClienteId ;
      private long AV8cClienteCPF ;
      private long A5ClienteId ;
      private long A7ClienteCPF ;
      private long A1EmpresaId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divClienteidfiltercontainer_Class ;
      private string divClientenomefiltercontainer_Class ;
      private string divClientecpffiltercontainer_Class ;
      private string divClienteemailfiltercontainer_Class ;
      private string divClientetelefonefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV10cClienteTelefone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divClienteidfiltercontainer_Internalname ;
      private string lblLblclienteidfilter_Internalname ;
      private string lblLblclienteidfilter_Jsonclick ;
      private string edtavCclienteid_Internalname ;
      private string TempTags ;
      private string edtavCclienteid_Jsonclick ;
      private string divClientenomefiltercontainer_Internalname ;
      private string lblLblclientenomefilter_Internalname ;
      private string lblLblclientenomefilter_Jsonclick ;
      private string edtavCclientenome_Internalname ;
      private string edtavCclientenome_Jsonclick ;
      private string divClientecpffiltercontainer_Internalname ;
      private string lblLblclientecpffilter_Internalname ;
      private string lblLblclientecpffilter_Jsonclick ;
      private string edtavCclientecpf_Internalname ;
      private string edtavCclientecpf_Jsonclick ;
      private string divClienteemailfiltercontainer_Internalname ;
      private string lblLblclienteemailfilter_Internalname ;
      private string lblLblclienteemailfilter_Jsonclick ;
      private string edtavCclienteemail_Internalname ;
      private string edtavCclienteemail_Jsonclick ;
      private string divClientetelefonefiltercontainer_Internalname ;
      private string lblLblclientetelefonefilter_Internalname ;
      private string lblLblclientetelefonefilter_Jsonclick ;
      private string edtavCclientetelefone_Internalname ;
      private string edtavCclientetelefone_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteNome_Internalname ;
      private string edtClienteCPF_Internalname ;
      private string A9ClienteTelefone ;
      private string edtClienteTelefone_Internalname ;
      private string edtEmpresaId_Internalname ;
      private string lV10cClienteTelefone ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteNome_Link ;
      private string edtClienteNome_Jsonclick ;
      private string edtClienteCPF_Jsonclick ;
      private string gxphoneLink ;
      private string edtClienteTelefone_Jsonclick ;
      private string edtEmpresaId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cClienteNome ;
      private string AV9cClienteEmail ;
      private string AV14Linkselection_GXI ;
      private string A6ClienteNome ;
      private string lV7cClienteNome ;
      private string lV9cClienteEmail ;
      private string A8ClienteEmail ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00062_A8ClienteEmail ;
      private long[] H00062_A1EmpresaId ;
      private string[] H00062_A9ClienteTelefone ;
      private long[] H00062_A7ClienteCPF ;
      private string[] H00062_A6ClienteNome ;
      private long[] H00062_A5ClienteId ;
      private long[] H00063_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pClienteId ;
   }

   public class gx0021__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00062( IGxContext context ,
                                             string AV7cClienteNome ,
                                             long AV8cClienteCPF ,
                                             string AV9cClienteEmail ,
                                             string AV10cClienteTelefone ,
                                             string A6ClienteNome ,
                                             long A7ClienteCPF ,
                                             string A8ClienteEmail ,
                                             string A9ClienteTelefone ,
                                             long AV11pEmpresaId ,
                                             long AV6cClienteId ,
                                             long A1EmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ClienteEmail], [EmpresaId], [ClienteTelefone], [ClienteCPF], [ClienteNome], [ClienteId]";
         sFromString = " FROM [TCliente]";
         sOrderString = "";
         AddWhere(sWhereString, "([EmpresaId] = @AV11pEmpresaId and [ClienteId] >= @AV6cClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cClienteNome)) )
         {
            AddWhere(sWhereString, "([ClienteNome] like @lV7cClienteNome)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8cClienteCPF) )
         {
            AddWhere(sWhereString, "([ClienteCPF] >= @AV8cClienteCPF)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cClienteEmail)) )
         {
            AddWhere(sWhereString, "([ClienteEmail] like @lV9cClienteEmail)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cClienteTelefone)) )
         {
            AddWhere(sWhereString, "([ClienteTelefone] like @lV10cClienteTelefone)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [EmpresaId], [ClienteId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00063( IGxContext context ,
                                             string AV7cClienteNome ,
                                             long AV8cClienteCPF ,
                                             string AV9cClienteEmail ,
                                             string AV10cClienteTelefone ,
                                             string A6ClienteNome ,
                                             long A7ClienteCPF ,
                                             string A8ClienteEmail ,
                                             string A9ClienteTelefone ,
                                             long AV11pEmpresaId ,
                                             long AV6cClienteId ,
                                             long A1EmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [TCliente]";
         AddWhere(sWhereString, "([EmpresaId] = @AV11pEmpresaId and [ClienteId] >= @AV6cClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cClienteNome)) )
         {
            AddWhere(sWhereString, "([ClienteNome] like @lV7cClienteNome)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV8cClienteCPF) )
         {
            AddWhere(sWhereString, "([ClienteCPF] >= @AV8cClienteCPF)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cClienteEmail)) )
         {
            AddWhere(sWhereString, "([ClienteEmail] like @lV9cClienteEmail)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cClienteTelefone)) )
         {
            AddWhere(sWhereString, "([ClienteTelefone] like @lV10cClienteTelefone)");
         }
         else
         {
            GXv_int3[5] = 1;
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
                     return conditional_H00062(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] );
               case 1 :
                     return conditional_H00063(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00062;
          prmH00062 = new Object[] {
          new ParDef("@AV11pEmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@AV6cClienteId",GXType.Decimal,12,0) ,
          new ParDef("@lV7cClienteNome",GXType.NVarChar,40,0) ,
          new ParDef("@AV8cClienteCPF",GXType.Decimal,11,0) ,
          new ParDef("@lV9cClienteEmail",GXType.NVarChar,100,0) ,
          new ParDef("@lV10cClienteTelefone",GXType.NChar,20,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00063;
          prmH00063 = new Object[] {
          new ParDef("@AV11pEmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@AV6cClienteId",GXType.Decimal,12,0) ,
          new ParDef("@lV7cClienteNome",GXType.NVarChar,40,0) ,
          new ParDef("@AV8cClienteCPF",GXType.Decimal,11,0) ,
          new ParDef("@lV9cClienteEmail",GXType.NVarChar,100,0) ,
          new ParDef("@lV10cClienteTelefone",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00062", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00062,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00063", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00063,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
