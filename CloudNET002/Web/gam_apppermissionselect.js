gx.evt.autoSkip=!1;gx.define("gam_apppermissionselect",!1,function(){var n,t;this.ServerClass="gam_apppermissionselect";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_apppermissionselect.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV7ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV19PermissionId=gx.fn.getControlValue("vPERMISSIONID");this.AV17isOK=gx.fn.getControlValue("vISOK");this.subGridww_Recordcount=gx.fn.getIntegerValue("subGridww_Recordcount",gx.thousandSeparator)};this.Validv_Accesstype=function(){var n=gx.fn.currentGridRowImpl(22);return this.validCliEvt("Validv_Accesstype",22,function(){try{var n=gx.util.balloon.getNew("vACCESSTYPE");if(this.AnyError=0,!(gx.text.compare(this.AV21AccessType,"A")==0||gx.text.compare(this.AV21AccessType,"R")==0))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Default Access"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.s112_client=function(){return this.executeClientEvent(function(){this.createWebComponent("Wcmessages","GAM_Messages",[])},arguments)};this.e111f2_client=function(){return this.executeServerEvent("'CONFIRM'",!1,null,!1,!1)};this.e121f2_client=function(){return this.executeServerEvent("'CANCEL'",!1,null,!1,!1)};this.e151f2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e161f2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,23,24,25,26,27,28,29,30,32,33,34,35,36,37,38,39,40,41];this.GXLastCtrlId=41;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",22,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_apppermissionselect",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!0,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addCheckBox("Select",23,"vSELECT",gx.getMessage("GAM_Select"),"","Select","boolean","true","false",null,!0,!1,60,"px","");t.addSingleLineEdit("Name",24,"vNAME",gx.getMessage("GAM_Permissionname"),"","Name","char",0,"px",254,80,"start",null,[],"Name","Name",!0,0,!1,!1,"Attribute",0,"column");t.addSingleLineEdit("Dsc",25,"vDSC",gx.getMessage("GAM_Description"),"","Dsc","char",0,"px",254,80,"start",null,[],"Dsc","Dsc",!0,0,!1,!1,"Attribute",0,"column column-optional");t.addComboBox("Accesstype",26,"vACCESSTYPE",gx.getMessage("GAM_DefaultAccess"),"AccessType","char",null,0,!0,!1,130,"px","column column-optional");t.addSingleLineEdit("Id",27,"vID",gx.getMessage("GAM_GUID"),"","Id","char",0,"px",40,40,"start",null,[],"Id","Id",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit("Appid",28,"vAPPID",gx.getMessage("GAM_KeyNumericLong"),"","AppId","int",0,"px",12,12,"end",null,[],"Appid","AppId",!1,0,!1,!1,"Attribute",0,"");this.GridwwContainer.emptyText=gx.getMessage("No results found.");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"GAM_HEADERWWNOFILTERS",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"GAM_HEADERWWNOFILTERS_TABLEACTIONS",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"GAM_HEADERWWNOFILTERS_TITLE",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"GAM_HEADERWWNOFILTERS_ADDNEW",grid:0,evt:"e171f1_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSEARCH",fmt:0,gxz:"ZV22Search",gxold:"OV22Search",gxvar:"AV22Search",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV22Search=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22Search=n)},v2c:function(){gx.fn.setControlValue("vSEARCH",gx.O.AV22Search,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV22Search=this.val())},val:function(){return gx.fn.getControlValue("vSEARCH")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"GRIDCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[23]={id:23,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:0,isacc:0,grid:22,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELECT",fmt:0,gxz:"ZV20Select",gxold:"OV20Select",gxvar:"AV20Select",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV20Select=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV20Select=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vSELECT",n||gx.fn.currentGridRowImpl(22),gx.O.AV20Select,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV20Select=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vSELECT",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn,values:["true","false"]};n[24]={id:24,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:22,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV18Name",gxold:"OV18Name",gxvar:"AV18Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV18Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(22),gx.O.AV18Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV18Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[25]={id:25,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:22,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",fmt:0,gxz:"ZV11Dsc",gxold:"OV11Dsc",gxvar:"AV11Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11Dsc=n)},v2c:function(n){gx.fn.setGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(22),gx.O.AV11Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11Dsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[26]={id:26,lvl:2,type:"char",len:1,dec:0,sign:!1,ro:0,isacc:0,grid:22,gxgrid:this.GridwwContainer,fnc:this.Validv_Accesstype,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vACCESSTYPE",fmt:0,gxz:"ZV21AccessType",gxold:"OV21AccessType",gxvar:"AV21AccessType",ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV21AccessType=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21AccessType=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vACCESSTYPE",n||gx.fn.currentGridRowImpl(22),gx.O.AV21AccessType);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21AccessType=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vACCESSTYPE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:22,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV16Id",gxold:"OV16Id",gxvar:"AV16Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV16Id=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16Id=n)},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(22),gx.O.AV16Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV16Id=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vID",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:22,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vAPPID",fmt:0,gxz:"ZV6AppId",gxold:"OV6AppId",gxvar:"AV6AppId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV6AppId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6AppId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vAPPID",n||gx.fn.currentGridRowImpl(22),gx.O.AV6AppId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6AppId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vAPPID",n||gx.fn.currentGridRowImpl(22),gx.thousandSeparator)},nac:gx.falseFn};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"GAM_FOOTERENTRY",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"GAM_FOOTERENTRY_TABLEBUTTONS",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"GAM_FOOTERENTRY_BTNCANCEL",grid:0,evt:"e121f2_client"};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"GAM_FOOTERENTRY_BTNCONFIRM",grid:0,evt:"e111f2_client"};this.AV22Search="";this.ZV22Search="";this.OV22Search="";this.ZV20Select=!1;this.OV20Select=!1;this.ZV18Name="";this.OV18Name="";this.ZV11Dsc="";this.OV11Dsc="";this.ZV21AccessType="";this.OV21AccessType="";this.ZV16Id="";this.OV16Id="";this.ZV6AppId=0;this.OV6AppId=0;this.AV22Search="";this.AV7ApplicationId=0;this.AV19PermissionId="";this.AV20Select=!1;this.AV18Name="";this.AV11Dsc="";this.AV21AccessType="";this.AV16Id="";this.AV6AppId=0;this.AV17isOK=!1;this.Events={e111f2_client:["'CONFIRM'",!0],e121f2_client:["'CANCEL'",!0],e151f2_client:["ENTER",!0],e161f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV22Search",fld:"vSEARCH"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV19PermissionId",fld:"vPERMISSIONID",hsh:!0}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV19PermissionId",fld:"vPERMISSIONID",hsh:!0},{av:"AV22Search",fld:"vSEARCH"}],[{ctrl:"FORM",prop:"Caption"},{av:"AV6AppId",fld:"vAPPID",pic:"ZZZZZZZZZZZ9"},{av:"AV16Id",fld:"vID",hsh:!0},{av:"AV18Name",fld:"vNAME"},{av:"AV11Dsc",fld:"vDSC"},{ctrl:"vACCESSTYPE"},{av:"AV21AccessType",fld:"vACCESSTYPE"}]];this.EvtParms["'CONFIRM'"]=[[{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV20Select",fld:"vSELECT",grid:22},{av:"GRIDWW_nFirstRecordOnPage"},{av:"nRC_GXsfl_22",ctrl:"GRIDWW",grid:22,prop:"GridRC",grid:22},{av:"AV19PermissionId",fld:"vPERMISSIONID",hsh:!0},{av:"AV16Id",fld:"vID",grid:22,hsh:!0},{av:"AV17isOK",fld:"vISOK"}],[{av:"AV17isOK",fld:"vISOK"},{ctrl:"WCMESSAGES"}]];this.EvtParms["'CANCEL'"]=[[{av:"AV19PermissionId",fld:"vPERMISSIONID",hsh:!0},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRIDWW_FIRSTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV19PermissionId",fld:"vPERMISSIONID",hsh:!0},{av:"AV22Search",fld:"vSEARCH"}],[]];this.EvtParms.GRIDWW_PREVPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV19PermissionId",fld:"vPERMISSIONID",hsh:!0},{av:"AV22Search",fld:"vSEARCH"}],[]];this.EvtParms.GRIDWW_NEXTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV19PermissionId",fld:"vPERMISSIONID",hsh:!0},{av:"AV22Search",fld:"vSEARCH"}],[]];this.EvtParms.GRIDWW_LASTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV7ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV19PermissionId",fld:"vPERMISSIONID",hsh:!0},{av:"AV22Search",fld:"vSEARCH"},{av:"subGridww_Recordcount"}],[]];this.EvtParms.VALIDV_ACCESSTYPE=[[{ctrl:"vACCESSTYPE"},{av:"AV21AccessType",fld:"vACCESSTYPE"}],[{ctrl:"vACCESSTYPE"},{av:"AV21AccessType",fld:"vACCESSTYPE"}]];this.setVCMap("AV7ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV19PermissionId","vPERMISSIONID",0,"char",40,0);this.setVCMap("AV17isOK","vISOK",0,"boolean",4,0);this.setVCMap("AV7ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV19PermissionId","vPERMISSIONID",0,"char",40,0);this.setVCMap("AV7ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV19PermissionId","vPERMISSIONID",0,"char",40,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Gridww"});t.addRefreshingVar({rfrVar:"AV7ApplicationId"});t.addRefreshingVar({rfrVar:"AV19PermissionId"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV7ApplicationId"});t.addRefreshingParm({rfrVar:"AV19PermissionId"});t.addRefreshingParm(this.GXValidFnc[16]);this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0031",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_apppermissionselect)})