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
   public class gx0031 : GXDataArea
   {
      public gx0031( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ProjetoFrotas", true);
      }

      public gx0031( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pEmpresaId ,
                           out long aP1_pVeiculoId )
      {
         this.AV12pEmpresaId = aP0_pEmpresaId;
         this.AV13pVeiculoId = 0 ;
         ExecuteImpl();
         aP1_pVeiculoId=this.AV13pVeiculoId;
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
               AV12pEmpresaId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pEmpresaId", StringUtil.LTrimStr( (decimal)(AV12pEmpresaId), 12, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pVeiculoId = (long)(Math.Round(NumberUtil.Val( GetPar( "pVeiculoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pVeiculoId", StringUtil.LTrimStr( (decimal)(AV13pVeiculoId), 12, 0));
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
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
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
         AV6cVeiculoId = (long)(Math.Round(NumberUtil.Val( GetPar( "cVeiculoId"), "."), 18, MidpointRounding.ToEven));
         AV7cVeiculoMarca = GetPar( "cVeiculoMarca");
         AV8cVeiculoModelo = GetPar( "cVeiculoModelo");
         AV9cVeiculoPlaca = GetPar( "cVeiculoPlaca");
         AV10cVeiculoCor = GetPar( "cVeiculoCor");
         AV11cVeiculoAno = (short)(Math.Round(NumberUtil.Val( GetPar( "cVeiculoAno"), "."), 18, MidpointRounding.ToEven));
         AV12pEmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "pEmpresaId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cVeiculoId, AV7cVeiculoMarca, AV8cVeiculoModelo, AV9cVeiculoPlaca, AV10cVeiculoCor, AV11cVeiculoAno, AV12pEmpresaId) ;
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
         PA082( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START082( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0031.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pEmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV13pVeiculoId,12,0))}, new string[] {"pEmpresaId","pVeiculoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCVEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cVeiculoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCVEICULOMARCA", AV7cVeiculoMarca);
         GxWebStd.gx_hidden_field( context, "GXH_vCVEICULOMODELO", AV8cVeiculoModelo);
         GxWebStd.gx_hidden_field( context, "GXH_vCVEICULOPLACA", StringUtil.RTrim( AV9cVeiculoPlaca));
         GxWebStd.gx_hidden_field( context, "GXH_vCVEICULOCOR", StringUtil.RTrim( AV10cVeiculoCor));
         GxWebStd.gx_hidden_field( context, "GXH_vCVEICULOANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cVeiculoAno), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPEMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pEmpresaId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPVEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pVeiculoId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "VEICULOIDFILTERCONTAINER_Class", StringUtil.RTrim( divVeiculoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VEICULOMARCAFILTERCONTAINER_Class", StringUtil.RTrim( divVeiculomarcafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VEICULOMODELOFILTERCONTAINER_Class", StringUtil.RTrim( divVeiculomodelofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VEICULOPLACAFILTERCONTAINER_Class", StringUtil.RTrim( divVeiculoplacafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VEICULOCORFILTERCONTAINER_Class", StringUtil.RTrim( divVeiculocorfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VEICULOANOFILTERCONTAINER_Class", StringUtil.RTrim( divVeiculoanofiltercontainer_Class));
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
            WE082( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT082( ) ;
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
         return formatLink("gx0031.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pEmpresaId,12,0)),UrlEncode(StringUtil.LTrimStr(AV13pVeiculoId,12,0))}, new string[] {"pEmpresaId","pVeiculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0031" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List TVeiculo" ;
      }

      protected void WB080( )
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
            GxWebStd.gx_div_start( context, divVeiculoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVeiculoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblveiculoidfilter_Internalname, "Veiculo Id", "", "", lblLblveiculoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0031.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCveiculoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cVeiculoId), 12, 0, ".", "")), StringUtil.LTrim( ((edtavCveiculoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cVeiculoId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cVeiculoId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCveiculoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCveiculoid_Visible, edtavCveiculoid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0031.htm");
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
            GxWebStd.gx_div_start( context, divVeiculomarcafiltercontainer_Internalname, 1, 0, "px", 0, "px", divVeiculomarcafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblveiculomarcafilter_Internalname, "Veiculo Marca", "", "", lblLblveiculomarcafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0031.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCveiculomarca_Internalname, "Veiculo Marca", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCveiculomarca_Internalname, AV7cVeiculoMarca, StringUtil.RTrim( context.localUtil.Format( AV7cVeiculoMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCveiculomarca_Jsonclick, 0, "Attribute", "", "", "", "", edtavCveiculomarca_Visible, edtavCveiculomarca_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0031.htm");
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
            GxWebStd.gx_div_start( context, divVeiculomodelofiltercontainer_Internalname, 1, 0, "px", 0, "px", divVeiculomodelofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblveiculomodelofilter_Internalname, "Veiculo Modelo", "", "", lblLblveiculomodelofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0031.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCveiculomodelo_Internalname, "Veiculo Modelo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCveiculomodelo_Internalname, AV8cVeiculoModelo, StringUtil.RTrim( context.localUtil.Format( AV8cVeiculoModelo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCveiculomodelo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCveiculomodelo_Visible, edtavCveiculomodelo_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0031.htm");
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
            GxWebStd.gx_div_start( context, divVeiculoplacafiltercontainer_Internalname, 1, 0, "px", 0, "px", divVeiculoplacafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblveiculoplacafilter_Internalname, "Veiculo Placa", "", "", lblLblveiculoplacafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0031.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCveiculoplaca_Internalname, "Veiculo Placa", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCveiculoplaca_Internalname, StringUtil.RTrim( AV9cVeiculoPlaca), StringUtil.RTrim( context.localUtil.Format( AV9cVeiculoPlaca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCveiculoplaca_Jsonclick, 0, "Attribute", "", "", "", "", edtavCveiculoplaca_Visible, edtavCveiculoplaca_Enabled, 0, "text", "", 7, "chr", 1, "row", 7, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0031.htm");
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
            GxWebStd.gx_div_start( context, divVeiculocorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVeiculocorfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblveiculocorfilter_Internalname, "Veiculo Cor", "", "", lblLblveiculocorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0031.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCveiculocor_Internalname, "Veiculo Cor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCveiculocor_Internalname, StringUtil.RTrim( AV10cVeiculoCor), StringUtil.RTrim( context.localUtil.Format( AV10cVeiculoCor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCveiculocor_Jsonclick, 0, "Attribute", "", "", "", "", edtavCveiculocor_Visible, edtavCveiculocor_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0031.htm");
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
            GxWebStd.gx_div_start( context, divVeiculoanofiltercontainer_Internalname, 1, 0, "px", 0, "px", divVeiculoanofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblveiculoanofilter_Internalname, "Veiculo Ano", "", "", lblLblveiculoanofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0031.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCveiculoano_Internalname, "Veiculo Ano", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCveiculoano_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cVeiculoAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCveiculoano_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cVeiculoAno), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cVeiculoAno), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCveiculoano_Jsonclick, 0, "Attribute", "", "", "", "", edtavCveiculoano_Visible, edtavCveiculoano_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0031.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17081_client"+"'", TempTags, "", 2, "HLP_Gx0031.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0031.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 74 )
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

      protected void START082( )
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
         Form.Meta.addItem("description", "Selection List TVeiculo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP080( ) ;
      }

      protected void WS082( )
      {
         START082( ) ;
         EVT082( ) ;
      }

      protected void EVT082( )
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
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A10VeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVeiculoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A11VeiculoMarca = cgiGet( edtVeiculoMarca_Internalname);
                              A12VeiculoModelo = cgiGet( edtVeiculoModelo_Internalname);
                              A13VeiculoPlaca = cgiGet( edtVeiculoPlaca_Internalname);
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
                                    E18082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cveiculoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVEICULOID"), ".", ",") != Convert.ToDecimal( AV6cVeiculoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cveiculomarca Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCVEICULOMARCA"), AV7cVeiculoMarca) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cveiculomodelo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCVEICULOMODELO"), AV8cVeiculoModelo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cveiculoplaca Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCVEICULOPLACA"), AV9cVeiculoPlaca) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cveiculocor Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCVEICULOCOR"), AV10cVeiculoCor) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cveiculoano Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVEICULOANO"), ".", ",") != Convert.ToDecimal( AV11cVeiculoAno )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20082 ();
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

      protected void WE082( )
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

      protected void PA082( )
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cVeiculoId ,
                                        string AV7cVeiculoMarca ,
                                        string AV8cVeiculoModelo ,
                                        string AV9cVeiculoPlaca ,
                                        string AV10cVeiculoCor ,
                                        short AV11cVeiculoAno ,
                                        long AV12pEmpresaId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF082( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VEICULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VEICULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")));
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
         RF082( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF082( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cVeiculoMarca ,
                                                 AV8cVeiculoModelo ,
                                                 AV9cVeiculoPlaca ,
                                                 AV10cVeiculoCor ,
                                                 AV11cVeiculoAno ,
                                                 A11VeiculoMarca ,
                                                 A12VeiculoModelo ,
                                                 A13VeiculoPlaca ,
                                                 A14VeiculoCor ,
                                                 A15VeiculoAno ,
                                                 AV12pEmpresaId ,
                                                 AV6cVeiculoId ,
                                                 A1EmpresaId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV7cVeiculoMarca = StringUtil.Concat( StringUtil.RTrim( AV7cVeiculoMarca), "%", "");
            lV8cVeiculoModelo = StringUtil.Concat( StringUtil.RTrim( AV8cVeiculoModelo), "%", "");
            lV9cVeiculoPlaca = StringUtil.PadR( StringUtil.RTrim( AV9cVeiculoPlaca), 7, "%");
            lV10cVeiculoCor = StringUtil.PadR( StringUtil.RTrim( AV10cVeiculoCor), 10, "%");
            /* Using cursor H00082 */
            pr_default.execute(0, new Object[] {AV12pEmpresaId, AV6cVeiculoId, lV7cVeiculoMarca, lV8cVeiculoModelo, lV9cVeiculoPlaca, lV10cVeiculoCor, AV11cVeiculoAno, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A15VeiculoAno = H00082_A15VeiculoAno[0];
               A14VeiculoCor = H00082_A14VeiculoCor[0];
               A1EmpresaId = H00082_A1EmpresaId[0];
               A13VeiculoPlaca = H00082_A13VeiculoPlaca[0];
               A12VeiculoModelo = H00082_A12VeiculoModelo[0];
               A11VeiculoMarca = H00082_A11VeiculoMarca[0];
               A10VeiculoId = H00082_A10VeiculoId[0];
               /* Execute user event: Load */
               E19082 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB080( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes082( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VEICULOID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9"), context));
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
                                              AV7cVeiculoMarca ,
                                              AV8cVeiculoModelo ,
                                              AV9cVeiculoPlaca ,
                                              AV10cVeiculoCor ,
                                              AV11cVeiculoAno ,
                                              A11VeiculoMarca ,
                                              A12VeiculoModelo ,
                                              A13VeiculoPlaca ,
                                              A14VeiculoCor ,
                                              A15VeiculoAno ,
                                              AV12pEmpresaId ,
                                              AV6cVeiculoId ,
                                              A1EmpresaId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV7cVeiculoMarca = StringUtil.Concat( StringUtil.RTrim( AV7cVeiculoMarca), "%", "");
         lV8cVeiculoModelo = StringUtil.Concat( StringUtil.RTrim( AV8cVeiculoModelo), "%", "");
         lV9cVeiculoPlaca = StringUtil.PadR( StringUtil.RTrim( AV9cVeiculoPlaca), 7, "%");
         lV10cVeiculoCor = StringUtil.PadR( StringUtil.RTrim( AV10cVeiculoCor), 10, "%");
         /* Using cursor H00083 */
         pr_default.execute(1, new Object[] {AV12pEmpresaId, AV6cVeiculoId, lV7cVeiculoMarca, lV8cVeiculoModelo, lV9cVeiculoPlaca, lV10cVeiculoCor, AV11cVeiculoAno});
         GRID1_nRecordCount = H00083_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVeiculoId, AV7cVeiculoMarca, AV8cVeiculoModelo, AV9cVeiculoPlaca, AV10cVeiculoCor, AV11cVeiculoAno, AV12pEmpresaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVeiculoId, AV7cVeiculoMarca, AV8cVeiculoModelo, AV9cVeiculoPlaca, AV10cVeiculoCor, AV11cVeiculoAno, AV12pEmpresaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVeiculoId, AV7cVeiculoMarca, AV8cVeiculoModelo, AV9cVeiculoPlaca, AV10cVeiculoCor, AV11cVeiculoAno, AV12pEmpresaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVeiculoId, AV7cVeiculoMarca, AV8cVeiculoModelo, AV9cVeiculoPlaca, AV10cVeiculoCor, AV11cVeiculoAno, AV12pEmpresaId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cVeiculoId, AV7cVeiculoMarca, AV8cVeiculoModelo, AV9cVeiculoPlaca, AV10cVeiculoCor, AV11cVeiculoAno, AV12pEmpresaId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtVeiculoId_Enabled = 0;
         AssignProp("", false, edtVeiculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoId_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtVeiculoMarca_Enabled = 0;
         AssignProp("", false, edtVeiculoMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoMarca_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtVeiculoModelo_Enabled = 0;
         AssignProp("", false, edtVeiculoModelo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoModelo_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtVeiculoPlaca_Enabled = 0;
         AssignProp("", false, edtVeiculoPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVeiculoPlaca_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP080( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18082 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCveiculoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCveiculoid_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVEICULOID");
               GX_FocusControl = edtavCveiculoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cVeiculoId = 0;
               AssignAttri("", false, "AV6cVeiculoId", StringUtil.LTrimStr( (decimal)(AV6cVeiculoId), 12, 0));
            }
            else
            {
               AV6cVeiculoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCveiculoid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cVeiculoId", StringUtil.LTrimStr( (decimal)(AV6cVeiculoId), 12, 0));
            }
            AV7cVeiculoMarca = cgiGet( edtavCveiculomarca_Internalname);
            AssignAttri("", false, "AV7cVeiculoMarca", AV7cVeiculoMarca);
            AV8cVeiculoModelo = cgiGet( edtavCveiculomodelo_Internalname);
            AssignAttri("", false, "AV8cVeiculoModelo", AV8cVeiculoModelo);
            AV9cVeiculoPlaca = cgiGet( edtavCveiculoplaca_Internalname);
            AssignAttri("", false, "AV9cVeiculoPlaca", AV9cVeiculoPlaca);
            AV10cVeiculoCor = cgiGet( edtavCveiculocor_Internalname);
            AssignAttri("", false, "AV10cVeiculoCor", AV10cVeiculoCor);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCveiculoano_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCveiculoano_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVEICULOANO");
               GX_FocusControl = edtavCveiculoano_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cVeiculoAno = 0;
               AssignAttri("", false, "AV11cVeiculoAno", StringUtil.LTrimStr( (decimal)(AV11cVeiculoAno), 4, 0));
            }
            else
            {
               AV11cVeiculoAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCveiculoano_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11cVeiculoAno", StringUtil.LTrimStr( (decimal)(AV11cVeiculoAno), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVEICULOID"), ".", ",") != Convert.ToDecimal( AV6cVeiculoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCVEICULOMARCA"), AV7cVeiculoMarca) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCVEICULOMODELO"), AV8cVeiculoModelo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCVEICULOPLACA"), AV9cVeiculoPlaca) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCVEICULOCOR"), AV10cVeiculoCor) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVEICULOANO"), ".", ",") != Convert.ToDecimal( AV11cVeiculoAno )) )
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
         E18082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18082( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "TVeiculo", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E19082( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E20082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20082( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pVeiculoId = A10VeiculoId;
         AssignAttri("", false, "AV13pVeiculoId", StringUtil.LTrimStr( (decimal)(AV13pVeiculoId), 12, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pVeiculoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pVeiculoId"});
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
         AV12pEmpresaId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pEmpresaId", StringUtil.LTrimStr( (decimal)(AV12pEmpresaId), 12, 0));
         AV13pVeiculoId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13pVeiculoId", StringUtil.LTrimStr( (decimal)(AV13pVeiculoId), 12, 0));
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
         PA082( ) ;
         WS082( ) ;
         WE082( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20244261715277", true, true);
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
         context.AddJavascriptSource("gx0031.js", "?20244261715277", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtVeiculoId_Internalname = "VEICULOID_"+sGXsfl_74_idx;
         edtVeiculoMarca_Internalname = "VEICULOMARCA_"+sGXsfl_74_idx;
         edtVeiculoModelo_Internalname = "VEICULOMODELO_"+sGXsfl_74_idx;
         edtVeiculoPlaca_Internalname = "VEICULOPLACA_"+sGXsfl_74_idx;
         edtEmpresaId_Internalname = "EMPRESAID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtVeiculoId_Internalname = "VEICULOID_"+sGXsfl_74_fel_idx;
         edtVeiculoMarca_Internalname = "VEICULOMARCA_"+sGXsfl_74_fel_idx;
         edtVeiculoModelo_Internalname = "VEICULOMODELO_"+sGXsfl_74_fel_idx;
         edtVeiculoPlaca_Internalname = "VEICULOPLACA_"+sGXsfl_74_fel_idx;
         edtEmpresaId_Internalname = "EMPRESAID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB080( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVeiculoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10VeiculoId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVeiculoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdManual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtVeiculoMarca_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtVeiculoMarca_Internalname, "Link", edtVeiculoMarca_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVeiculoMarca_Internalname,(string)A11VeiculoMarca,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtVeiculoMarca_Link,(string)"",(string)"",(string)"",(string)edtVeiculoMarca_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVeiculoModelo_Internalname,(string)A12VeiculoModelo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVeiculoModelo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVeiculoPlaca_Internalname,StringUtil.RTrim( A13VeiculoPlaca),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVeiculoPlaca_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)7,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEmpresaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 12, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEmpresaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"DIdAuto",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes082( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
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
            context.SendWebValue( "Marca") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Modelo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Placa") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10VeiculoId), 12, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A11VeiculoMarca));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtVeiculoMarca_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A12VeiculoModelo));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A13VeiculoPlaca)));
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
         lblLblveiculoidfilter_Internalname = "LBLVEICULOIDFILTER";
         edtavCveiculoid_Internalname = "vCVEICULOID";
         divVeiculoidfiltercontainer_Internalname = "VEICULOIDFILTERCONTAINER";
         lblLblveiculomarcafilter_Internalname = "LBLVEICULOMARCAFILTER";
         edtavCveiculomarca_Internalname = "vCVEICULOMARCA";
         divVeiculomarcafiltercontainer_Internalname = "VEICULOMARCAFILTERCONTAINER";
         lblLblveiculomodelofilter_Internalname = "LBLVEICULOMODELOFILTER";
         edtavCveiculomodelo_Internalname = "vCVEICULOMODELO";
         divVeiculomodelofiltercontainer_Internalname = "VEICULOMODELOFILTERCONTAINER";
         lblLblveiculoplacafilter_Internalname = "LBLVEICULOPLACAFILTER";
         edtavCveiculoplaca_Internalname = "vCVEICULOPLACA";
         divVeiculoplacafiltercontainer_Internalname = "VEICULOPLACAFILTERCONTAINER";
         lblLblveiculocorfilter_Internalname = "LBLVEICULOCORFILTER";
         edtavCveiculocor_Internalname = "vCVEICULOCOR";
         divVeiculocorfiltercontainer_Internalname = "VEICULOCORFILTERCONTAINER";
         lblLblveiculoanofilter_Internalname = "LBLVEICULOANOFILTER";
         edtavCveiculoano_Internalname = "vCVEICULOANO";
         divVeiculoanofiltercontainer_Internalname = "VEICULOANOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtVeiculoId_Internalname = "VEICULOID";
         edtVeiculoMarca_Internalname = "VEICULOMARCA";
         edtVeiculoModelo_Internalname = "VEICULOMODELO";
         edtVeiculoPlaca_Internalname = "VEICULOPLACA";
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
         edtVeiculoPlaca_Jsonclick = "";
         edtVeiculoModelo_Jsonclick = "";
         edtVeiculoMarca_Jsonclick = "";
         edtVeiculoMarca_Link = "";
         edtVeiculoId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtEmpresaId_Enabled = 0;
         edtVeiculoPlaca_Enabled = 0;
         edtVeiculoModelo_Enabled = 0;
         edtVeiculoMarca_Enabled = 0;
         edtVeiculoId_Enabled = 0;
         edtavCveiculoano_Jsonclick = "";
         edtavCveiculoano_Enabled = 1;
         edtavCveiculoano_Visible = 1;
         edtavCveiculocor_Jsonclick = "";
         edtavCveiculocor_Enabled = 1;
         edtavCveiculocor_Visible = 1;
         edtavCveiculoplaca_Jsonclick = "";
         edtavCveiculoplaca_Enabled = 1;
         edtavCveiculoplaca_Visible = 1;
         edtavCveiculomodelo_Jsonclick = "";
         edtavCveiculomodelo_Enabled = 1;
         edtavCveiculomodelo_Visible = 1;
         edtavCveiculomarca_Jsonclick = "";
         edtavCveiculomarca_Enabled = 1;
         edtavCveiculomarca_Visible = 1;
         edtavCveiculoid_Jsonclick = "";
         edtavCveiculoid_Enabled = 1;
         edtavCveiculoid_Visible = 1;
         divVeiculoanofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVeiculocorfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVeiculoplacafiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVeiculomodelofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVeiculomarcafiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divVeiculoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List TVeiculo";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cVeiculoMarca","fld":"vCVEICULOMARCA"},{"av":"AV8cVeiculoModelo","fld":"vCVEICULOMODELO"},{"av":"AV9cVeiculoPlaca","fld":"vCVEICULOPLACA"},{"av":"AV10cVeiculoCor","fld":"vCVEICULOCOR"},{"av":"AV11cVeiculoAno","fld":"vCVEICULOANO","pic":"ZZZ9"},{"av":"AV12pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E17081","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLVEICULOIDFILTER.CLICK","""{"handler":"E11081","iparms":[{"av":"divVeiculoidfiltercontainer_Class","ctrl":"VEICULOIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLVEICULOIDFILTER.CLICK",""","oparms":[{"av":"divVeiculoidfiltercontainer_Class","ctrl":"VEICULOIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCveiculoid_Visible","ctrl":"vCVEICULOID","prop":"Visible"}]}""");
         setEventMetadata("LBLVEICULOMARCAFILTER.CLICK","""{"handler":"E12081","iparms":[{"av":"divVeiculomarcafiltercontainer_Class","ctrl":"VEICULOMARCAFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLVEICULOMARCAFILTER.CLICK",""","oparms":[{"av":"divVeiculomarcafiltercontainer_Class","ctrl":"VEICULOMARCAFILTERCONTAINER","prop":"Class"},{"av":"edtavCveiculomarca_Visible","ctrl":"vCVEICULOMARCA","prop":"Visible"}]}""");
         setEventMetadata("LBLVEICULOMODELOFILTER.CLICK","""{"handler":"E13081","iparms":[{"av":"divVeiculomodelofiltercontainer_Class","ctrl":"VEICULOMODELOFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLVEICULOMODELOFILTER.CLICK",""","oparms":[{"av":"divVeiculomodelofiltercontainer_Class","ctrl":"VEICULOMODELOFILTERCONTAINER","prop":"Class"},{"av":"edtavCveiculomodelo_Visible","ctrl":"vCVEICULOMODELO","prop":"Visible"}]}""");
         setEventMetadata("LBLVEICULOPLACAFILTER.CLICK","""{"handler":"E14081","iparms":[{"av":"divVeiculoplacafiltercontainer_Class","ctrl":"VEICULOPLACAFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLVEICULOPLACAFILTER.CLICK",""","oparms":[{"av":"divVeiculoplacafiltercontainer_Class","ctrl":"VEICULOPLACAFILTERCONTAINER","prop":"Class"},{"av":"edtavCveiculoplaca_Visible","ctrl":"vCVEICULOPLACA","prop":"Visible"}]}""");
         setEventMetadata("LBLVEICULOCORFILTER.CLICK","""{"handler":"E15081","iparms":[{"av":"divVeiculocorfiltercontainer_Class","ctrl":"VEICULOCORFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLVEICULOCORFILTER.CLICK",""","oparms":[{"av":"divVeiculocorfiltercontainer_Class","ctrl":"VEICULOCORFILTERCONTAINER","prop":"Class"},{"av":"edtavCveiculocor_Visible","ctrl":"vCVEICULOCOR","prop":"Visible"}]}""");
         setEventMetadata("LBLVEICULOANOFILTER.CLICK","""{"handler":"E16081","iparms":[{"av":"divVeiculoanofiltercontainer_Class","ctrl":"VEICULOANOFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLVEICULOANOFILTER.CLICK",""","oparms":[{"av":"divVeiculoanofiltercontainer_Class","ctrl":"VEICULOANOFILTERCONTAINER","prop":"Class"},{"av":"edtavCveiculoano_Visible","ctrl":"vCVEICULOANO","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E20082","iparms":[{"av":"A10VeiculoId","fld":"VEICULOID","pic":"ZZZZZZZZZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV13pVeiculoId","fld":"vPVEICULOID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cVeiculoMarca","fld":"vCVEICULOMARCA"},{"av":"AV8cVeiculoModelo","fld":"vCVEICULOMODELO"},{"av":"AV9cVeiculoPlaca","fld":"vCVEICULOPLACA"},{"av":"AV10cVeiculoCor","fld":"vCVEICULOCOR"},{"av":"AV11cVeiculoAno","fld":"vCVEICULOANO","pic":"ZZZ9"},{"av":"AV12pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cVeiculoMarca","fld":"vCVEICULOMARCA"},{"av":"AV8cVeiculoModelo","fld":"vCVEICULOMODELO"},{"av":"AV9cVeiculoPlaca","fld":"vCVEICULOPLACA"},{"av":"AV10cVeiculoCor","fld":"vCVEICULOCOR"},{"av":"AV11cVeiculoAno","fld":"vCVEICULOANO","pic":"ZZZ9"},{"av":"AV12pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cVeiculoMarca","fld":"vCVEICULOMARCA"},{"av":"AV8cVeiculoModelo","fld":"vCVEICULOMODELO"},{"av":"AV9cVeiculoPlaca","fld":"vCVEICULOPLACA"},{"av":"AV10cVeiculoCor","fld":"vCVEICULOCOR"},{"av":"AV11cVeiculoAno","fld":"vCVEICULOANO","pic":"ZZZ9"},{"av":"AV12pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cVeiculoId","fld":"vCVEICULOID","pic":"ZZZZZZZZZZZ9"},{"av":"AV7cVeiculoMarca","fld":"vCVEICULOMARCA"},{"av":"AV8cVeiculoModelo","fld":"vCVEICULOMODELO"},{"av":"AV9cVeiculoPlaca","fld":"vCVEICULOPLACA"},{"av":"AV10cVeiculoCor","fld":"vCVEICULOCOR"},{"av":"AV11cVeiculoAno","fld":"vCVEICULOANO","pic":"ZZZ9"},{"av":"AV12pEmpresaId","fld":"vPEMPRESAID","pic":"ZZZZZZZZZZZ9"}]}""");
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
         AV7cVeiculoMarca = "";
         AV8cVeiculoModelo = "";
         AV9cVeiculoPlaca = "";
         AV10cVeiculoCor = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblveiculoidfilter_Jsonclick = "";
         TempTags = "";
         lblLblveiculomarcafilter_Jsonclick = "";
         lblLblveiculomodelofilter_Jsonclick = "";
         lblLblveiculoplacafilter_Jsonclick = "";
         lblLblveiculocorfilter_Jsonclick = "";
         lblLblveiculoanofilter_Jsonclick = "";
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
         AV15Linkselection_GXI = "";
         A11VeiculoMarca = "";
         A12VeiculoModelo = "";
         A13VeiculoPlaca = "";
         lV7cVeiculoMarca = "";
         lV8cVeiculoModelo = "";
         lV9cVeiculoPlaca = "";
         lV10cVeiculoCor = "";
         A14VeiculoCor = "";
         H00082_A15VeiculoAno = new short[1] ;
         H00082_A14VeiculoCor = new string[] {""} ;
         H00082_A1EmpresaId = new long[1] ;
         H00082_A13VeiculoPlaca = new string[] {""} ;
         H00082_A12VeiculoModelo = new string[] {""} ;
         H00082_A11VeiculoMarca = new string[] {""} ;
         H00082_A10VeiculoId = new long[1] ;
         H00083_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0031__default(),
            new Object[][] {
                new Object[] {
               H00082_A15VeiculoAno, H00082_A14VeiculoCor, H00082_A1EmpresaId, H00082_A13VeiculoPlaca, H00082_A12VeiculoModelo, H00082_A11VeiculoMarca, H00082_A10VeiculoId
               }
               , new Object[] {
               H00083_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11cVeiculoAno ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A15VeiculoAno ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCveiculoid_Enabled ;
      private int edtavCveiculoid_Visible ;
      private int edtavCveiculomarca_Visible ;
      private int edtavCveiculomarca_Enabled ;
      private int edtavCveiculomodelo_Visible ;
      private int edtavCveiculomodelo_Enabled ;
      private int edtavCveiculoplaca_Visible ;
      private int edtavCveiculoplaca_Enabled ;
      private int edtavCveiculocor_Visible ;
      private int edtavCveiculocor_Enabled ;
      private int edtavCveiculoano_Enabled ;
      private int edtavCveiculoano_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtVeiculoId_Enabled ;
      private int edtVeiculoMarca_Enabled ;
      private int edtVeiculoModelo_Enabled ;
      private int edtVeiculoPlaca_Enabled ;
      private int edtEmpresaId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pEmpresaId ;
      private long AV13pVeiculoId ;
      private long wcpOAV12pEmpresaId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cVeiculoId ;
      private long A10VeiculoId ;
      private long A1EmpresaId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divVeiculoidfiltercontainer_Class ;
      private string divVeiculomarcafiltercontainer_Class ;
      private string divVeiculomodelofiltercontainer_Class ;
      private string divVeiculoplacafiltercontainer_Class ;
      private string divVeiculocorfiltercontainer_Class ;
      private string divVeiculoanofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV9cVeiculoPlaca ;
      private string AV10cVeiculoCor ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divVeiculoidfiltercontainer_Internalname ;
      private string lblLblveiculoidfilter_Internalname ;
      private string lblLblveiculoidfilter_Jsonclick ;
      private string edtavCveiculoid_Internalname ;
      private string TempTags ;
      private string edtavCveiculoid_Jsonclick ;
      private string divVeiculomarcafiltercontainer_Internalname ;
      private string lblLblveiculomarcafilter_Internalname ;
      private string lblLblveiculomarcafilter_Jsonclick ;
      private string edtavCveiculomarca_Internalname ;
      private string edtavCveiculomarca_Jsonclick ;
      private string divVeiculomodelofiltercontainer_Internalname ;
      private string lblLblveiculomodelofilter_Internalname ;
      private string lblLblveiculomodelofilter_Jsonclick ;
      private string edtavCveiculomodelo_Internalname ;
      private string edtavCveiculomodelo_Jsonclick ;
      private string divVeiculoplacafiltercontainer_Internalname ;
      private string lblLblveiculoplacafilter_Internalname ;
      private string lblLblveiculoplacafilter_Jsonclick ;
      private string edtavCveiculoplaca_Internalname ;
      private string edtavCveiculoplaca_Jsonclick ;
      private string divVeiculocorfiltercontainer_Internalname ;
      private string lblLblveiculocorfilter_Internalname ;
      private string lblLblveiculocorfilter_Jsonclick ;
      private string edtavCveiculocor_Internalname ;
      private string edtavCveiculocor_Jsonclick ;
      private string divVeiculoanofiltercontainer_Internalname ;
      private string lblLblveiculoanofilter_Internalname ;
      private string lblLblveiculoanofilter_Jsonclick ;
      private string edtavCveiculoano_Internalname ;
      private string edtavCveiculoano_Jsonclick ;
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
      private string edtVeiculoId_Internalname ;
      private string edtVeiculoMarca_Internalname ;
      private string edtVeiculoModelo_Internalname ;
      private string A13VeiculoPlaca ;
      private string edtVeiculoPlaca_Internalname ;
      private string edtEmpresaId_Internalname ;
      private string lV9cVeiculoPlaca ;
      private string lV10cVeiculoCor ;
      private string A14VeiculoCor ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtVeiculoId_Jsonclick ;
      private string edtVeiculoMarca_Link ;
      private string edtVeiculoMarca_Jsonclick ;
      private string edtVeiculoModelo_Jsonclick ;
      private string edtVeiculoPlaca_Jsonclick ;
      private string edtEmpresaId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cVeiculoMarca ;
      private string AV8cVeiculoModelo ;
      private string AV15Linkselection_GXI ;
      private string A11VeiculoMarca ;
      private string A12VeiculoModelo ;
      private string lV7cVeiculoMarca ;
      private string lV8cVeiculoModelo ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00082_A15VeiculoAno ;
      private string[] H00082_A14VeiculoCor ;
      private long[] H00082_A1EmpresaId ;
      private string[] H00082_A13VeiculoPlaca ;
      private string[] H00082_A12VeiculoModelo ;
      private string[] H00082_A11VeiculoMarca ;
      private long[] H00082_A10VeiculoId ;
      private long[] H00083_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pVeiculoId ;
   }

   public class gx0031__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00082( IGxContext context ,
                                             string AV7cVeiculoMarca ,
                                             string AV8cVeiculoModelo ,
                                             string AV9cVeiculoPlaca ,
                                             string AV10cVeiculoCor ,
                                             short AV11cVeiculoAno ,
                                             string A11VeiculoMarca ,
                                             string A12VeiculoModelo ,
                                             string A13VeiculoPlaca ,
                                             string A14VeiculoCor ,
                                             short A15VeiculoAno ,
                                             long AV12pEmpresaId ,
                                             long AV6cVeiculoId ,
                                             long A1EmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [VeiculoAno], [VeiculoCor], [EmpresaId], [VeiculoPlaca], [VeiculoModelo], [VeiculoMarca], [VeiculoId]";
         sFromString = " FROM [TVeiculo]";
         sOrderString = "";
         AddWhere(sWhereString, "([EmpresaId] = @AV12pEmpresaId and [VeiculoId] >= @AV6cVeiculoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cVeiculoMarca)) )
         {
            AddWhere(sWhereString, "([VeiculoMarca] like @lV7cVeiculoMarca)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cVeiculoModelo)) )
         {
            AddWhere(sWhereString, "([VeiculoModelo] like @lV8cVeiculoModelo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cVeiculoPlaca)) )
         {
            AddWhere(sWhereString, "([VeiculoPlaca] like @lV9cVeiculoPlaca)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cVeiculoCor)) )
         {
            AddWhere(sWhereString, "([VeiculoCor] like @lV10cVeiculoCor)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV11cVeiculoAno) )
         {
            AddWhere(sWhereString, "([VeiculoAno] >= @AV11cVeiculoAno)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [EmpresaId], [VeiculoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00083( IGxContext context ,
                                             string AV7cVeiculoMarca ,
                                             string AV8cVeiculoModelo ,
                                             string AV9cVeiculoPlaca ,
                                             string AV10cVeiculoCor ,
                                             short AV11cVeiculoAno ,
                                             string A11VeiculoMarca ,
                                             string A12VeiculoModelo ,
                                             string A13VeiculoPlaca ,
                                             string A14VeiculoCor ,
                                             short A15VeiculoAno ,
                                             long AV12pEmpresaId ,
                                             long AV6cVeiculoId ,
                                             long A1EmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [TVeiculo]";
         AddWhere(sWhereString, "([EmpresaId] = @AV12pEmpresaId and [VeiculoId] >= @AV6cVeiculoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cVeiculoMarca)) )
         {
            AddWhere(sWhereString, "([VeiculoMarca] like @lV7cVeiculoMarca)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cVeiculoModelo)) )
         {
            AddWhere(sWhereString, "([VeiculoModelo] like @lV8cVeiculoModelo)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cVeiculoPlaca)) )
         {
            AddWhere(sWhereString, "([VeiculoPlaca] like @lV9cVeiculoPlaca)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cVeiculoCor)) )
         {
            AddWhere(sWhereString, "([VeiculoCor] like @lV10cVeiculoCor)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV11cVeiculoAno) )
         {
            AddWhere(sWhereString, "([VeiculoAno] >= @AV11cVeiculoAno)");
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
                     return conditional_H00082(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00083(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00082;
          prmH00082 = new Object[] {
          new ParDef("@AV12pEmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@AV6cVeiculoId",GXType.Decimal,12,0) ,
          new ParDef("@lV7cVeiculoMarca",GXType.NVarChar,20,0) ,
          new ParDef("@lV8cVeiculoModelo",GXType.NVarChar,10,0) ,
          new ParDef("@lV9cVeiculoPlaca",GXType.NChar,7,0) ,
          new ParDef("@lV10cVeiculoCor",GXType.NChar,10,0) ,
          new ParDef("@AV11cVeiculoAno",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00083;
          prmH00083 = new Object[] {
          new ParDef("@AV12pEmpresaId",GXType.Decimal,12,0) ,
          new ParDef("@AV6cVeiculoId",GXType.Decimal,12,0) ,
          new ParDef("@lV7cVeiculoMarca",GXType.NVarChar,20,0) ,
          new ParDef("@lV8cVeiculoModelo",GXType.NVarChar,10,0) ,
          new ParDef("@lV9cVeiculoPlaca",GXType.NChar,7,0) ,
          new ParDef("@lV10cVeiculoCor",GXType.NChar,10,0) ,
          new ParDef("@AV11cVeiculoAno",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00082", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00082,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00083", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00083,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 7);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
