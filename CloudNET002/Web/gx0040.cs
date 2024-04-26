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
   public class gx0040 : GXDataArea
   {
      public gx0040( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public gx0040( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pEmpresaId ,
                           out long aP1_pRegistroPedidoId )
      {
         this.AV13pEmpresaId = 0 ;
         this.AV14pRegistroPedidoId = 0 ;
         ExecuteImpl();
         aP0_pEmpresaId=this.AV13pEmpresaId;
         aP1_pRegistroPedidoId=this.AV14pRegistroPedidoId;
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
               AV13pEmpresaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pEmpresaId", StringUtil.LTrimStr( (decimal)(AV13pEmpresaId), 12, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pRegistroPedidoId = (long)(Math.Round(NumberUtil.Val( GetPar( "pRegistroPedidoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pRegistroPedidoId", StringUtil.LTrimStr( (decimal)(AV14pRegistroPedidoId), 12, 0));
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
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
         AV6cEmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "cEmpresaId"), "."), 18, MidpointRounding.ToEven));
         AV7cRegistroPedidoId = (long)(Math.Round(NumberUtil.Val( GetPar( "cRegistroPedidoId"), "."), 18, MidpointRounding.ToEven));
         AV8cVeiculoId = (long)(Math.Round(NumberUtil.Val( GetPar( "cVeiculoId"), "."), 18, MidpointRounding.ToEven));
         AV9cClienteId = (long)(Math.Round(NumberUtil.Val( GetPar( "cClienteId"), "."), 18, MidpointRounding.ToEven));
         AV10cDestino = GetPar( "cDestino");
         AV16cDataRetirada = context.localUtil.ParseDateParm( GetPar( "cDataRetirada"));
         AV17cDataRetorno = context.localUtil.ParseDateParm( GetPar( "cDataRetorno"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cEmpresaId, AV7cRegistroPedidoId, AV8cVeiculoId, AV9cClienteId, AV10cDestino, AV16cDataRetirada, AV17cDataRetorno) ;
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
         PA092( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START092( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0040.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pEmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV14pRegistroPedidoId,12,0))}, new string[] {"pEmpresaId","pRegistroPedidoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCEMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cEmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCREGISTROPEDIDOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cRegistroPedidoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCVEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cVeiculoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cClienteId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCDESTINO", StringUtil.RTrim( AV10cDestino));
         GxWebStd.gx_hidden_field( context, "GXH_vCDATARETIRADA", context.localUtil.Format(AV16cDataRetirada, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCDATARETORNO", context.localUtil.Format(AV17cDataRetorno, "99/99/9999"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPEMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pEmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPREGISTROPEDIDOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pRegistroPedidoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "EMPRESAIDFILTERCONTAINER_Class", StringUtil.RTrim( divEmpresaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "REGISTROPEDIDOIDFILTERCONTAINER_Class", StringUtil.RTrim( divRegistropedidoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VEICULOIDFILTERCONTAINER_Class", StringUtil.RTrim( divVeiculoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTEIDFILTERCONTAINER_Class", StringUtil.RTrim( divClienteidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DESTINOFILTERCONTAINER_Class", StringUtil.RTrim( divDestinofiltercontainer_Class));
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
            WE092( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT092( ) ;
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
         return formatLink("gx0040.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pEmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV14pRegistroPedidoId,12,0))}, new string[] {"pEmpresaId","pRegistroPedidoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0040" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List TRegistro Pedido" ;
      }

      protected void WB090( )
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
            GxWebStd.gx_div_start( context, divEmpresaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEmpresaidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblempresaidfilter_Internalname, "Empresa Id", "", "", lblLblempresaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11091_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCempresaid_Internalname, "Empresa Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCempresaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cEmpresaId), 12, 0, ".", "")), StringUtil.LTrim( ((edtavCempresaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cEmpresaId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cEmpresaId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCempresaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCempresaid_Visible, edtavCempresaid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0040.htm");
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
            GxWebStd.gx_div_start( context, divRegistropedidoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRegistropedidoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblregistropedidoidfilter_Internalname, "Registro Pedido Id", "", "", lblLblregistropedidoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12091_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCregistropedidoid_Internalname, "Registro Pedido Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCregistropedidoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cRegistroPedidoId), 12, 0, ".", "")), StringUtil.LTrim( ((edtavCregistropedidoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cRegistroPedidoId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cRegistroPedidoId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCregistropedidoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCregistropedidoid_Visible, edtavCregistropedidoid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0040.htm");
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
            GxWebStd.gx_div_start( context, divVeiculoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVeiculoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblveiculoidfilter_Internalname, "Veiculo Id", "", "", lblLblveiculoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13091_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCveiculoid_Internalname, "Veiculo Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCveiculoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cVeiculoId), 12, 0, ".", "")), StringUtil.LTrim( ((edtavCveiculoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cVeiculoId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cVeiculoId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCveiculoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCveiculoid_Visible, edtavCveiculoid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0040.htm");
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
            GxWebStd.gx_div_start( context, divClienteidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divClienteidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclienteidfilter_Internalname, "Cliente Id", "", "", lblLblclienteidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14091_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cClienteId), 12, 0, ".", "")), StringUtil.LTrim( ((edtavCclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cClienteId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV9cClienteId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclienteid_Visible, edtavCclienteid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0040.htm");
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
            GxWebStd.gx_div_start( context, divDestinofiltercontainer_Internalname, 1, 0, "px", 0, "px", divDestinofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldestinofilter_Internalname, "Destino", "", "", lblLbldestinofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15091_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdestino_Internalname, "Destino", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdestino_Internalname, StringUtil.RTrim( AV10cDestino), StringUtil.RTrim( context.localUtil.Format( AV10cDestino, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdestino_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdestino_Visible, edtavCdestino_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0040.htm");
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
            GxWebStd.gx_div_start( context, divDataretiradafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldataretiradafilter_Internalname, "Data Retirada", "", "", lblLbldataretiradafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdataretirada_Internalname, "Data Retirada", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCdataretirada_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCdataretirada_Internalname, context.localUtil.Format(AV16cDataRetirada, "99/99/9999"), context.localUtil.Format( AV16cDataRetirada, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdataretirada_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCdataretirada_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0040.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divDataretornofiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldataretornofilter_Internalname, "Data Retorno", "", "", lblLbldataretornofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdataretorno_Internalname, "Data Retorno", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCdataretorno_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCdataretorno_Internalname, context.localUtil.Format(AV17cDataRetorno, "99/99/9999"), context.localUtil.Format( AV17cDataRetorno, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdataretorno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCdataretorno_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0040.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16091_client"+"'", TempTags, "", 2, "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0040.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
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

      protected void START092( )
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
         Form.Meta.addItem("description", "Selection List TRegistro Pedido", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP090( ) ;
      }

      protected void WS092( )
      {
         START092( ) ;
         EVT092( ) ;
      }

      protected void EVT092( )
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
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A16RegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRegistroPedidoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVeiculoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A5ClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A17Destino = cgiGet( edtDestino_Internalname);
                              A24DataRetirada = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtDataRetirada_Internalname), 0));
                              A25DataRetorno = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtDataRetorno_Internalname), 0));
                              n25DataRetorno = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17092 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18092 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cempresaid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCEMPRESAID"), ".", ",") != Convert.ToDecimal( AV6cEmpresaId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cregistropedidoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREGISTROPEDIDOID"), ".", ",") != Convert.ToDecimal( AV7cRegistroPedidoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cveiculoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVEICULOID"), ".", ",") != Convert.ToDecimal( AV8cVeiculoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclienteid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTEID"), ".", ",") != Convert.ToDecimal( AV9cClienteId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdestino Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCDESTINO"), AV10cDestino) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdataretirada Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCDATARETIRADA"), 0) != AV16cDataRetirada )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdataretorno Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCDATARETORNO"), 0) != AV17cDataRetorno )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19092 ();
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

      protected void WE092( )
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

      protected void PA092( )
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
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cEmpresaId ,
                                        long AV7cRegistroPedidoId ,
                                        long AV8cVeiculoId ,
                                        long AV9cClienteId ,
                                        string AV10cDestino ,
                                        DateTime AV16cDataRetirada ,
                                        DateTime AV17cDataRetorno )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF092( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_EMPRESAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "EMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")));
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
         RF092( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF092( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
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
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8cVeiculoId ,
                                                 AV9cClienteId ,
                                                 AV10cDestino ,
                                                 AV16cDataRetirada ,
                                                 AV17cDataRetorno ,
                                                 A10VeiculoId ,
                                                 A5ClienteId ,
                                                 A17Destino ,
                                                 A24DataRetirada ,
                                                 A25DataRetorno ,
                                                 AV6cEmpresaId ,
                                                 AV7cRegistroPedidoId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                                 TypeConstants.LONG
                                                 }
            });
            lV10cDestino = StringUtil.PadR( StringUtil.RTrim( AV10cDestino), 20, "%");
            /* Using cursor H00092 */
            pr_default.execute(0, new Object[] {AV6cEmpresaId, AV7cRegistroPedidoId, AV8cVeiculoId, AV9cClienteId, lV10cDestino, AV16cDataRetirada, AV17cDataRetorno, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A25DataRetorno = H00092_A25DataRetorno[0];
               n25DataRetorno = H00092_n25DataRetorno[0];
               A24DataRetirada = H00092_A24DataRetirada[0];
               A17Destino = H00092_A17Destino[0];
               A5ClienteId = H00092_A5ClienteId[0];
               A10VeiculoId = H00092_A10VeiculoId[0];
               A16RegistroPedidoId = H00092_A16RegistroPedidoId[0];
               A1EmpresaId = H00092_A1EmpresaId[0];
               /* Execute user event: Load */
               E18092 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB090( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes092( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_EMPRESAID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_REGISTROPEDIDOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A16RegistroPedidoId), "ZZZZZZZZZZZ9"), context));
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
                                              AV8cVeiculoId ,
                                              AV9cClienteId ,
                                              AV10cDestino ,
                                              AV16cDataRetirada ,
                                              AV17cDataRetorno ,
                                              A10VeiculoId ,
                                              A5ClienteId ,
                                              A17Destino ,
                                              A24DataRetirada ,
                                              A25DataRetorno ,
                                              AV6cEmpresaId ,
                                              AV7cRegistroPedidoId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV10cDestino = StringUtil.PadR( StringUtil.RTrim( AV10cDestino), 20, "%");
         /* Using cursor H00093 */
         pr_default.execute(1, new Object[] {AV6cEmpresaId, AV7cRegistroPedidoId, AV8cVeiculoId, AV9cClienteId, lV10cDestino, AV16cDataRetirada, AV17cDataRetorno});
         GRID1_nRecordCount = H00093_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEmpresaId, AV7cRegistroPedidoId, AV8cVeiculoId, AV9cClienteId, AV10cDestino, AV16cDataRetirada, AV17cDataRetorno) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEmpresaId, AV7cRegistroPedidoId, AV8cVeiculoId, AV9cClienteId, AV10cDestino, AV16cDataRetirada, AV17cDataRetorno) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEmpresaId, AV7cRegistroPedidoId, AV8cVeiculoId, AV9cClienteId, AV10cDestino, AV16cDataRetirada, AV17cDataRetorno) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEmpresaId, AV7cRegistroPedidoId, AV8cVeiculoId, AV9cClienteId, AV10cDestino, AV16cDataRetirada, AV17cDataRetorno) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEmpresaId, AV7cRegistroPedidoId, AV8cVeiculoId, AV9cClienteId, AV10cDestino, AV16cDataRetirada, AV17cDataRetorno) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtRegistroPedidoId_Enabled = 0;
         AssignProp("", false, edtRegistroPedidoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroPedidoId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtVeiculoId_Enabled = 0;
         AssignProp("", false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtDestino_Enabled = 0;
         AssignProp("", false, edtDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDestino_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtDataRetirada_Enabled = 0;
         AssignProp("", false, edtDataRetirada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataRetirada_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         edtDataRetorno_Enabled = 0;
         AssignProp("", false, edtDataRetorno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataRetorno_Enabled), 5, 0), !bGXsfl_84_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP090( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17092 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCempresaid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCempresaid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCEMPRESAID");
               GX_FocusControl = edtavCempresaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cEmpresaId = 0;
               AssignAttri("", false, "AV6cEmpresaId", StringUtil.LTrimStr( (decimal)(AV6cEmpresaId), 12, 0));
            }
            else
            {
               AV6cEmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCempresaid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cEmpresaId", StringUtil.LTrimStr( (decimal)(AV6cEmpresaId), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCregistropedidoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCregistropedidoid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCREGISTROPEDIDOID");
               GX_FocusControl = edtavCregistropedidoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cRegistroPedidoId = 0;
               AssignAttri("", false, "AV7cRegistroPedidoId", StringUtil.LTrimStr( (decimal)(AV7cRegistroPedidoId), 12, 0));
            }
            else
            {
               AV7cRegistroPedidoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCregistropedidoid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cRegistroPedidoId", StringUtil.LTrimStr( (decimal)(AV7cRegistroPedidoId), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCveiculoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCveiculoid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVEICULOID");
               GX_FocusControl = edtavCveiculoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cVeiculoId = 0;
               AssignAttri("", false, "AV8cVeiculoId", StringUtil.LTrimStr( (decimal)(AV8cVeiculoId), 12, 0));
            }
            else
            {
               AV8cVeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCveiculoid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cVeiculoId", StringUtil.LTrimStr( (decimal)(AV8cVeiculoId), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCLIENTEID");
               GX_FocusControl = edtavCclienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cClienteId = 0;
               AssignAttri("", false, "AV9cClienteId", StringUtil.LTrimStr( (decimal)(AV9cClienteId), 12, 0));
            }
            else
            {
               AV9cClienteId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cClienteId", StringUtil.LTrimStr( (decimal)(AV9cClienteId), 12, 0));
            }
            AV10cDestino = cgiGet( edtavCdestino_Internalname);
            AssignAttri("", false, "AV10cDestino", AV10cDestino);
            if ( context.localUtil.VCDate( cgiGet( edtavCdataretirada_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data Retirada"}), 1, "vCDATARETIRADA");
               GX_FocusControl = edtavCdataretirada_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16cDataRetirada = DateTime.MinValue;
               AssignAttri("", false, "AV16cDataRetirada", context.localUtil.Format(AV16cDataRetirada, "99/99/9999"));
            }
            else
            {
               AV16cDataRetirada = context.localUtil.CToD( cgiGet( edtavCdataretirada_Internalname), 1);
               AssignAttri("", false, "AV16cDataRetirada", context.localUtil.Format(AV16cDataRetirada, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCdataretorno_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data Retorno"}), 1, "vCDATARETORNO");
               GX_FocusControl = edtavCdataretorno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17cDataRetorno = DateTime.MinValue;
               AssignAttri("", false, "AV17cDataRetorno", context.localUtil.Format(AV17cDataRetorno, "99/99/9999"));
            }
            else
            {
               AV17cDataRetorno = context.localUtil.CToD( cgiGet( edtavCdataretorno_Internalname), 1);
               AssignAttri("", false, "AV17cDataRetorno", context.localUtil.Format(AV17cDataRetorno, "99/99/9999"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCEMPRESAID"), ".", ",") != Convert.ToDecimal( AV6cEmpresaId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCREGISTROPEDIDOID"), ".", ",") != Convert.ToDecimal( AV7cRegistroPedidoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVEICULOID"), ".", ",") != Convert.ToDecimal( AV8cVeiculoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTEID"), ".", ",") != Convert.ToDecimal( AV9cClienteId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCDESTINO"), AV10cDestino) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCDATARETIRADA"), 1) ) != DateTimeUtil.ResetTime ( AV16cDataRetirada ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCDATARETORNO"), 1) ) != DateTimeUtil.ResetTime ( AV17cDataRetorno ) )
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
         E17092 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17092( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "TRegistro Pedido", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV15ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E18092( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19092 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19092( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pEmpresaId = A1EmpresaId;
         AssignAttri("", false, "AV13pEmpresaId", StringUtil.LTrimStr( (decimal)(AV13pEmpresaId), 12, 0));
         AV14pRegistroPedidoId = A16RegistroPedidoId;
         AssignAttri("", false, "AV14pRegistroPedidoId", StringUtil.LTrimStr( (decimal)(AV14pRegistroPedidoId), 12, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pEmpresaId,(long)AV14pRegistroPedidoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pEmpresaId","AV14pRegistroPedidoId"});
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
         AV13pEmpresaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pEmpresaId", StringUtil.LTrimStr( (decimal)(AV13pEmpresaId), 12, 0));
         AV14pRegistroPedidoId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV14pRegistroPedidoId", StringUtil.LTrimStr( (decimal)(AV14pRegistroPedidoId), 12, 0));
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
         PA092( ) ;
         WS092( ) ;
         WE092( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20244261716166", true, true);
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
         context.AddJavascriptSource("gx0040.js", "?20244261716167", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtEmpresaId_Internalname = "EMPRESAID_"+sGXsfl_84_idx;
         edtRegistroPedidoId_Internalname = "REGISTROPEDIDOID_"+sGXsfl_84_idx;
         edtVeiculoId_Internalname = "VEICULOID_"+sGXsfl_84_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_84_idx;
         edtDestino_Internalname = "DESTINO_"+sGXsfl_84_idx;
         edtDataRetirada_Internalname = "DATARETIRADA_"+sGXsfl_84_idx;
         edtDataRetorno_Internalname = "DATARETORNO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtEmpresaId_Internalname = "EMPRESAID_"+sGXsfl_84_fel_idx;
         edtRegistroPedidoId_Internalname = "REGISTROPEDIDOID_"+sGXsfl_84_fel_idx;
         edtVeiculoId_Internalname = "VEICULOID_"+sGXsfl_84_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_84_fel_idx;
         edtDestino_Internalname = "DESTINO_"+sGXsfl_84_fel_idx;
         edtDataRetirada_Internalname = "DATARETIRADA_"+sGXsfl_84_fel_idx;
         edtDataRetorno_Internalname = "DATARETORNO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WB090( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpresaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpresaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdAuto",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRegistroPedidoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16RegistroPedidoId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRegistroPedidoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdManual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVeiculoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVeiculoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdManual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A5ClienteId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdManual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtDestino_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtDestino_Internalname, "Link", edtDestino_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDestino_Internalname,StringUtil.RTrim( A17Destino),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtDestino_Link,(string)"",(string)"",(string)"",(string)edtDestino_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDataRetirada_Internalname,context.localUtil.Format(A24DataRetirada, "99/99/9999"),context.localUtil.Format( A24DataRetirada, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDataRetirada_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDataRetorno_Internalname,context.localUtil.Format(A25DataRetorno, "99/99/9999"),context.localUtil.Format( A25DataRetorno, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDataRetorno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes092( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
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
            context.SendWebValue( "Empresa Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Pedido Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Veiculo Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Destino") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Retirada") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Retorno") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16RegistroPedidoId), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ClienteId), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A17Destino)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtDestino_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A24DataRetirada, "99/99/9999")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A25DataRetorno, "99/99/9999")));
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
         lblLblempresaidfilter_Internalname = "LBLEMPRESAIDFILTER";
         edtavCempresaid_Internalname = "vCEMPRESAID";
         divEmpresaidfiltercontainer_Internalname = "EMPRESAIDFILTERCONTAINER";
         lblLblregistropedidoidfilter_Internalname = "LBLREGISTROPEDIDOIDFILTER";
         edtavCregistropedidoid_Internalname = "vCREGISTROPEDIDOID";
         divRegistropedidoidfiltercontainer_Internalname = "REGISTROPEDIDOIDFILTERCONTAINER";
         lblLblveiculoidfilter_Internalname = "LBLVEICULOIDFILTER";
         edtavCveiculoid_Internalname = "vCVEICULOID";
         divVeiculoidfiltercontainer_Internalname = "VEICULOIDFILTERCONTAINER";
         lblLblclienteidfilter_Internalname = "LBLCLIENTEIDFILTER";
         edtavCclienteid_Internalname = "vCCLIENTEID";
         divClienteidfiltercontainer_Internalname = "CLIENTEIDFILTERCONTAINER";
         lblLbldestinofilter_Internalname = "LBLDESTINOFILTER";
         edtavCdestino_Internalname = "vCDESTINO";
         divDestinofiltercontainer_Internalname = "DESTINOFILTERCONTAINER";
         lblLbldataretiradafilter_Internalname = "LBLDATARETIRADAFILTER";
         edtavCdataretirada_Internalname = "vCDATARETIRADA";
         divDataretiradafiltercontainer_Internalname = "DATARETIRADAFILTERCONTAINER";
         lblLbldataretornofilter_Internalname = "LBLDATARETORNOFILTER";
         edtavCdataretorno_Internalname = "vCDATARETORNO";
         divDataretornofiltercontainer_Internalname = "DATARETORNOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtEmpresaId_Internalname = "EMPRESAID";
         edtRegistroPedidoId_Internalname = "REGISTROPEDIDOID";
         edtVeiculoId_Internalname = "VEICULOID";
         edtClienteId_Internalname = "CLIENTEID";
         edtDestino_Internalname = "DESTINO";
         edtDataRetirada_Internalname = "DATARETIRADA";
         edtDataRetorno_Internalname = "DATARETORNO";
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
         edtDataRetorno_Jsonclick = "";
         edtDataRetirada_Jsonclick = "";
         edtDestino_Jsonclick = "";
         edtDestino_Link = "";
         edtClienteId_Jsonclick = "";
         edtVeiculoId_Jsonclick = "";
         edtRegistroPedidoId_Jsonclick = "";
         edtEmpresaId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtDataRetorno_Enabled = 0;
         edtDataRetirada_Enabled = 0;
         edtDestino_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtVeiculoId_Enabled = 0;
         edtRegistroPedidoId_Enabled = 0;
         edtEmpresaId_Enabled = 0;
         edtavCdataretorno_Jsonclick = "";
         edtavCdataretorno_Enabled = 1;
         edtavCdataretirada_Jsonclick = "";
         edtavCdataretirada_Enabled = 1;
         edtavCdestino_Jsonclick = "";
         edtavCdestino_Enabled = 1;
         edtavCdestino_Visible = 1;
         edtavCclienteid_Jsonclick = "";
         edtavCclienteid_Enabled = 1;
         edtavCclienteid_Visible = 1;
         edtavCveiculoid_Jsonclick = "";
         edtavCveiculoid_Enabled = 1;
         edtavCveiculoid_Visible = 1;
         edtavCregistropedidoid_Jsonclick = "";
         edtavCregistropedidoid_Enabled = 1;
         edtavCregistropedidoid_Visible = 1;
         edtavCempresaid_Jsonclick = "";
         edtavCempresaid_Enabled = 1;
         edtavCempresaid_Visible = 1;
         divDestinofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divClienteidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVeiculoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divRegistropedidoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEmpresaidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List TRegistro Pedido";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cEmpresaId","fld":"vCEMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cRegistroPedidoId","fld":"vCREGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV8cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV9cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV10cDestino","fld":"vCDESTINO"},{"av":"AV16cDataRetirada","fld":"vCDATARETIRADA"},{"av":"AV17cDataRetorno","fld":"vCDATARETORNO"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E16091","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLEMPRESAIDFILTER.CLICK","""{"handler":"E11091","iparms":[{"av":"divEmpresaidfiltercontainer_Class","ctrl":"EMPRESAIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLEMPRESAIDFILTER.CLICK",""","oparms":[{"av":"divEmpresaidfiltercontainer_Class","ctrl":"EMPRESAIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCempresaid_Visible","ctrl":"vCEMPRESAID","prop":"Visible"}]}""");
         setEventMetadata("LBLREGISTROPEDIDOIDFILTER.CLICK","""{"handler":"E12091","iparms":[{"av":"divRegistropedidoidfiltercontainer_Class","ctrl":"REGISTROPEDIDOIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLREGISTROPEDIDOIDFILTER.CLICK",""","oparms":[{"av":"divRegistropedidoidfiltercontainer_Class","ctrl":"REGISTROPEDIDOIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCregistropedidoid_Visible","ctrl":"vCREGISTROPEDIDOID","prop":"Visible"}]}""");
         setEventMetadata("LBLVEICULOIDFILTER.CLICK","""{"handler":"E13091","iparms":[{"av":"divVeiculoidfiltercontainer_Class","ctrl":"VEICULOIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLVEICULOIDFILTER.CLICK",""","oparms":[{"av":"divVeiculoidfiltercontainer_Class","ctrl":"VEICULOIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCveiculoid_Visible","ctrl":"vCVEICULOID","prop":"Visible"}]}""");
         setEventMetadata("LBLCLIENTEIDFILTER.CLICK","""{"handler":"E14091","iparms":[{"av":"divClienteidfiltercontainer_Class","ctrl":"CLIENTEIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLCLIENTEIDFILTER.CLICK",""","oparms":[{"av":"divClienteidfiltercontainer_Class","ctrl":"CLIENTEIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCclienteid_Visible","ctrl":"vCCLIENTEID","prop":"Visible"}]}""");
         setEventMetadata("LBLDESTINOFILTER.CLICK","""{"handler":"E15091","iparms":[{"av":"divDestinofiltercontainer_Class","ctrl":"DESTINOFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLDESTINOFILTER.CLICK",""","oparms":[{"av":"divDestinofiltercontainer_Class","ctrl":"DESTINOFILTERCONTAINER","prop":"Class"},{"av":"edtavCdestino_Visible","ctrl":"vCDESTINO","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E19092","iparms":[{"av":"A1EmpresaId","fld":"EMPRESAID","pic":"ZZZZZZZZZZZ9","hsh":true},{"av":"A16RegistroPedidoId","fld":"REGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"AV14pRegistroPedidoId","fld":"vPREGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cEmpresaId","fld":"vCEMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cRegistroPedidoId","fld":"vCREGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV8cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV9cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV10cDestino","fld":"vCDESTINO"},{"av":"AV16cDataRetirada","fld":"vCDATARETIRADA"},{"av":"AV17cDataRetorno","fld":"vCDATARETORNO"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cEmpresaId","fld":"vCEMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cRegistroPedidoId","fld":"vCREGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV8cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV9cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV10cDestino","fld":"vCDESTINO"},{"av":"AV16cDataRetirada","fld":"vCDATARETIRADA"},{"av":"AV17cDataRetorno","fld":"vCDATARETORNO"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cEmpresaId","fld":"vCEMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cRegistroPedidoId","fld":"vCREGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV8cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV9cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV10cDestino","fld":"vCDESTINO"},{"av":"AV16cDataRetirada","fld":"vCDATARETIRADA"},{"av":"AV17cDataRetorno","fld":"vCDATARETORNO"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cEmpresaId","fld":"vCEMPRESAID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cRegistroPedidoId","fld":"vCREGISTROPEDIDOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV8cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV9cClienteId","fld":"vCCLIENTEID","pic":"ZZZZZZZZZZZ9"},{"av":"AV10cDestino","fld":"vCDESTINO"},{"av":"AV16cDataRetirada","fld":"vCDATARETIRADA"},{"av":"AV17cDataRetorno","fld":"vCDATARETORNO"}]}""");
         setEventMetadata("VALIDV_CDATARETIRADA","""{"handler":"Validv_Cdataretirada","iparms":[]}""");
         setEventMetadata("VALIDV_CDATARETORNO","""{"handler":"Validv_Cdataretorno","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Dataretorno","iparms":[]}""");
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
         AV10cDestino = "";
         AV16cDataRetirada = DateTime.MinValue;
         AV17cDataRetorno = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblempresaidfilter_Jsonclick = "";
         TempTags = "";
         lblLblregistropedidoidfilter_Jsonclick = "";
         lblLblveiculoidfilter_Jsonclick = "";
         lblLblclienteidfilter_Jsonclick = "";
         lblLbldestinofilter_Jsonclick = "";
         lblLbldataretiradafilter_Jsonclick = "";
         lblLbldataretornofilter_Jsonclick = "";
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
         AV18Linkselection_GXI = "";
         A17Destino = "";
         A24DataRetirada = DateTime.MinValue;
         A25DataRetorno = DateTime.MinValue;
         lV10cDestino = "";
         H00092_A25DataRetorno = new DateTime[] {DateTime.MinValue} ;
         H00092_n25DataRetorno = new bool[] {false} ;
         H00092_A24DataRetirada = new DateTime[] {DateTime.MinValue} ;
         H00092_A17Destino = new string[] {""} ;
         H00092_A5ClienteId = new long[1] ;
         H00092_A10VeiculoId = new long[1] ;
         H00092_A16RegistroPedidoId = new long[1] ;
         H00092_A1EmpresaId = new long[1] ;
         H00093_AGRID1_nRecordCount = new long[1] ;
         AV15ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0040__default(),
            new Object[][] {
                new Object[] {
               H00092_A25DataRetorno, H00092_n25DataRetorno, H00092_A24DataRetirada, H00092_A17Destino, H00092_A5ClienteId, H00092_A10VeiculoId, H00092_A16RegistroPedidoId, H00092_A1EmpresaId
               }
               , new Object[] {
               H00093_AGRID1_nRecordCount
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
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCempresaid_Enabled ;
      private int edtavCempresaid_Visible ;
      private int edtavCregistropedidoid_Enabled ;
      private int edtavCregistropedidoid_Visible ;
      private int edtavCveiculoid_Enabled ;
      private int edtavCveiculoid_Visible ;
      private int edtavCclienteid_Enabled ;
      private int edtavCclienteid_Visible ;
      private int edtavCdestino_Visible ;
      private int edtavCdestino_Enabled ;
      private int edtavCdataretirada_Enabled ;
      private int edtavCdataretorno_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtEmpresaId_Enabled ;
      private int edtRegistroPedidoId_Enabled ;
      private int edtVeiculoId_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtDestino_Enabled ;
      private int edtDataRetirada_Enabled ;
      private int edtDataRetorno_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pEmpresaId ;
      private long AV14pRegistroPedidoId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cEmpresaId ;
      private long AV7cRegistroPedidoId ;
      private long AV8cVeiculoId ;
      private long AV9cClienteId ;
      private long A1EmpresaId ;
      private long A16RegistroPedidoId ;
      private long A10VeiculoId ;
      private long A5ClienteId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divEmpresaidfiltercontainer_Class ;
      private string divRegistropedidoidfiltercontainer_Class ;
      private string divVeiculoidfiltercontainer_Class ;
      private string divClienteidfiltercontainer_Class ;
      private string divDestinofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV10cDestino ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divEmpresaidfiltercontainer_Internalname ;
      private string lblLblempresaidfilter_Internalname ;
      private string lblLblempresaidfilter_Jsonclick ;
      private string edtavCempresaid_Internalname ;
      private string TempTags ;
      private string edtavCempresaid_Jsonclick ;
      private string divRegistropedidoidfiltercontainer_Internalname ;
      private string lblLblregistropedidoidfilter_Internalname ;
      private string lblLblregistropedidoidfilter_Jsonclick ;
      private string edtavCregistropedidoid_Internalname ;
      private string edtavCregistropedidoid_Jsonclick ;
      private string divVeiculoidfiltercontainer_Internalname ;
      private string lblLblveiculoidfilter_Internalname ;
      private string lblLblveiculoidfilter_Jsonclick ;
      private string edtavCveiculoid_Internalname ;
      private string edtavCveiculoid_Jsonclick ;
      private string divClienteidfiltercontainer_Internalname ;
      private string lblLblclienteidfilter_Internalname ;
      private string lblLblclienteidfilter_Jsonclick ;
      private string edtavCclienteid_Internalname ;
      private string edtavCclienteid_Jsonclick ;
      private string divDestinofiltercontainer_Internalname ;
      private string lblLbldestinofilter_Internalname ;
      private string lblLbldestinofilter_Jsonclick ;
      private string edtavCdestino_Internalname ;
      private string edtavCdestino_Jsonclick ;
      private string divDataretiradafiltercontainer_Internalname ;
      private string lblLbldataretiradafilter_Internalname ;
      private string lblLbldataretiradafilter_Jsonclick ;
      private string edtavCdataretirada_Internalname ;
      private string edtavCdataretirada_Jsonclick ;
      private string divDataretornofiltercontainer_Internalname ;
      private string lblLbldataretornofilter_Internalname ;
      private string lblLbldataretornofilter_Jsonclick ;
      private string edtavCdataretorno_Internalname ;
      private string edtavCdataretorno_Jsonclick ;
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
      private string edtEmpresaId_Internalname ;
      private string edtRegistroPedidoId_Internalname ;
      private string edtVeiculoId_Internalname ;
      private string edtClienteId_Internalname ;
      private string A17Destino ;
      private string edtDestino_Internalname ;
      private string edtDataRetirada_Internalname ;
      private string edtDataRetorno_Internalname ;
      private string lV10cDestino ;
      private string AV15ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtEmpresaId_Jsonclick ;
      private string edtRegistroPedidoId_Jsonclick ;
      private string edtVeiculoId_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtDestino_Link ;
      private string edtDestino_Jsonclick ;
      private string edtDataRetirada_Jsonclick ;
      private string edtDataRetorno_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV16cDataRetirada ;
      private DateTime AV17cDataRetorno ;
      private DateTime A24DataRetirada ;
      private DateTime A25DataRetorno ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n25DataRetorno ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV18Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00092_A25DataRetorno ;
      private bool[] H00092_n25DataRetorno ;
      private DateTime[] H00092_A24DataRetirada ;
      private string[] H00092_A17Destino ;
      private long[] H00092_A5ClienteId ;
      private long[] H00092_A10VeiculoId ;
      private long[] H00092_A16RegistroPedidoId ;
      private long[] H00092_A1EmpresaId ;
      private long[] H00093_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pEmpresaId ;
      private long aP1_pRegistroPedidoId ;
   }

   public class gx0040__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00092( IGxContext context ,
                                             long AV8cVeiculoId ,
                                             long AV9cClienteId ,
                                             string AV10cDestino ,
                                             DateTime AV16cDataRetirada ,
                                             DateTime AV17cDataRetorno ,
                                             long A10VeiculoId ,
                                             long A5ClienteId ,
                                             string A17Destino ,
                                             DateTime A24DataRetirada ,
                                             DateTime A25DataRetorno ,
                                             long AV6cEmpresaId ,
                                             long AV7cRegistroPedidoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [DataRetorno], [DataRetirada], [Destino], [ClienteId], [VeiculoId], [RegistroPedidoId], [EmpresaId]";
         sFromString = " FROM [TRegistroPedido]";
         sOrderString = "";
         AddWhere(sWhereString, "([EmpresaId] >= @AV6cEmpresaId and [RegistroPedidoId] >= @AV7cRegistroPedidoId)");
         if ( ! (0==AV8cVeiculoId) )
         {
            AddWhere(sWhereString, "([VeiculoId] >= @AV8cVeiculoId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cClienteId) )
         {
            AddWhere(sWhereString, "([ClienteId] >= @AV9cClienteId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cDestino)) )
         {
            AddWhere(sWhereString, "([Destino] like @lV10cDestino)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV16cDataRetirada) )
         {
            AddWhere(sWhereString, "([DataRetirada] >= @AV16cDataRetirada)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV17cDataRetorno) )
         {
            AddWhere(sWhereString, "([DataRetorno] >= @AV17cDataRetorno)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [EmpresaId], [RegistroPedidoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00093( IGxContext context ,
                                             long AV8cVeiculoId ,
                                             long AV9cClienteId ,
                                             string AV10cDestino ,
                                             DateTime AV16cDataRetirada ,
                                             DateTime AV17cDataRetorno ,
                                             long A10VeiculoId ,
                                             long A5ClienteId ,
                                             string A17Destino ,
                                             DateTime A24DataRetirada ,
                                             DateTime A25DataRetorno ,
                                             long AV6cEmpresaId ,
                                             long AV7cRegistroPedidoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [TRegistroPedido]";
         AddWhere(sWhereString, "([EmpresaId] >= @AV6cEmpresaId and [RegistroPedidoId] >= @AV7cRegistroPedidoId)");
         if ( ! (0==AV8cVeiculoId) )
         {
            AddWhere(sWhereString, "([VeiculoId] >= @AV8cVeiculoId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cClienteId) )
         {
            AddWhere(sWhereString, "([ClienteId] >= @AV9cClienteId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cDestino)) )
         {
            AddWhere(sWhereString, "([Destino] like @lV10cDestino)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV16cDataRetirada) )
         {
            AddWhere(sWhereString, "([DataRetirada] >= @AV16cDataRetirada)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV17cDataRetorno) )
         {
            AddWhere(sWhereString, "([DataRetorno] >= @AV17cDataRetorno)");
         }
         else
         {
            GXv_int3[6] = 1;
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
                     return conditional_H00092(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
               case 1 :
                     return conditional_H00093(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
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
          Object[] prmH00092;
          prmH00092 = new Object[] {
          new ParDef("@AV6cEmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@AV7cRegistroPedidoId",GXType.Decimal,12,0) ,
          new ParDef("@AV8cVeiculoId",GXType.Decimal,12,0) ,
          new ParDef("@AV9cClienteId",GXType.Decimal,12,0) ,
          new ParDef("@lV10cDestino",GXType.NChar,20,0) ,
          new ParDef("@AV16cDataRetirada",GXType.Date,8,0) ,
          new ParDef("@AV17cDataRetorno",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00093;
          prmH00093 = new Object[] {
          new ParDef("@AV6cEmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@AV7cRegistroPedidoId",GXType.Decimal,12,0) ,
          new ParDef("@AV8cVeiculoId",GXType.Decimal,12,0) ,
          new ParDef("@AV9cClienteId",GXType.Decimal,12,0) ,
          new ParDef("@lV10cDestino",GXType.NChar,20,0) ,
          new ParDef("@AV16cDataRetirada",GXType.Date,8,0) ,
          new ParDef("@AV17cDataRetorno",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00092", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00092,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00093", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00093,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
