gx.evt.autoSkip=!1;gx.define("gam_wwuserapplications",!1,function(){var n,t;this.ServerClass="gam_wwuserapplications";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_wwuserapplications.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV31UserGUID=gx.fn.getControlValue("vUSERGUID");this.AV10BoolenFilter=gx.fn.getControlValue("vBOOLENFILTER");this.AV27PermissionAccessType=gx.fn.getControlValue("vPERMISSIONACCESSTYPE");this.subGridww_Recordcount=gx.fn.getIntegerValue("subGridww_Recordcount",gx.thousandSeparator)};this.e203f2_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV33Window.Url=gx.http.formatLink("gam_warningnotification.aspx",["user:revokeapikey",this.AV31UserGUID,this.AV13ClientID]);this.AV33Window.ReturnParms=[];this.popupOpen(this.AV33Window);this.refreshOutputs([]);this.refreshGrid("Gridww");this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e213f2_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV33Window.Url=gx.http.formatLink("gam_userapplicationapikey.aspx",[this.AV31UserGUID,this.AV13ClientID]);this.AV33Window.ReturnParms=[];this.popupOpen(this.AV33Window);this.refreshOutputs([]);this.refreshGrid("Gridww");this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e223f1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.refreshOutputs([]);this.refreshGrid("Gridww");this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e133f1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.refreshOutputs([]);this.refreshGrid("Gridww");this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e123f1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV27PermissionAccessType="";this.AV10BoolenFilter="";this.refreshOutputs([]);this.refreshGrid("Gridww");this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e113f1_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.text.compare(gx.fn.getCtrlProperty("GAM_FILTERSWW","Class"),"filters-container")==0?(gx.fn.setCtrlProperty("GAM_FILTERSWW","Class",gx.text.format("%1 %2","filters-container","filters-container-floating--visible","","","","","","","")),gx.fn.setCtrlProperty("GAM_HEADERWWBACKFILTERS_TOGGLEFILTERS","Tooltiptext",gx.getMessage("GAM_Hidefilters"))):(gx.fn.setCtrlProperty("GAM_FILTERSWW","Class","filters-container"),gx.fn.setCtrlProperty("GAM_HEADERWWBACKFILTERS_TOGGLEFILTERS","Tooltiptext",gx.getMessage("GAM_Showfilters")));this.refreshOutputs([{av:"gx.fn.getCtrlProperty('GAM_FILTERSWW','Class')",ctrl:"GAM_FILTERSWW",prop:"Class"},{av:"gx.fn.getCtrlProperty('GAM_HEADERWWBACKFILTERS_TOGGLEFILTERS','Tooltiptext')",ctrl:"GAM_HEADERWWBACKFILTERS_TOGGLEFILTERS",prop:"Tooltiptext"}]);this.OnClientEventEnd()},arguments)};this.e173f1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV15CurrentPage=gx.num.trunc(1,0);this.refreshOutputs([{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.refreshGrid("Gridww");this.refreshOutputs([{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e183f1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV15CurrentPage=gx.num.trunc(this.AV15CurrentPage-1,0);this.refreshOutputs([{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.refreshGrid("Gridww");this.refreshOutputs([{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e193f1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV15CurrentPage=gx.num.trunc(this.AV15CurrentPage+1,0);this.refreshOutputs([{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.refreshGrid("Gridww");this.refreshOutputs([{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]);this.OnClientEventEnd()},arguments)};this.e143f2_client=function(){return this.executeServerEvent("GAM_HEADERWWBACKFILTERS_TABLEBACK.CLICK",!0,null,!1,!0)};this.e233f2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e243f2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40,41,42,43,44,45,46,47,50,52,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,89,90,91,92,93,94,95,96,97,98];this.GXLastCtrlId=98;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",34,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_wwuserapplications",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addSingleLineEdit("Id",35,"vID",gx.getMessage("GAM_ID"),"","Id","int",0,"px",12,12,"end",null,[],"Id","Id",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit("Name",36,"vNAME",gx.getMessage("GAM_ApplicationName"),"","Name","char",300,"px",254,80,"start",null,[],"Name","Name",!0,0,!1,!1,"Attribute",0,"column");t.addSingleLineEdit("Description",37,"vDESCRIPTION",gx.getMessage("GAM_Description"),"","Description","char",300,"px",254,80,"start",null,[],"Description","Description",!0,0,!1,!1,"Attribute",0,"column");t.addSingleLineEdit("Clientid",38,"vCLIENTID",gx.getMessage("GAM_ClientID"),"","ClientID","char",300,"px",40,40,"start",null,[],"Clientid","ClientID",!0,0,!1,!1,"Attribute",0,"column");t.addSingleLineEdit("Status",39,"vSTATUS",gx.getMessage("GAM_APIKeyStatus"),"","Status","svchar",100,"px",40,40,"start",null,[],"Status","Status",!0,0,!1,!1,"",0,"column column-optional");t.addSingleLineEdit("Btnrevoke",40,"vBTNREVOKE","","","BtnRevoke","char",0,"px",20,20,"start","e203f2_client",[],"Btnrevoke","BtnRevoke",!0,0,!1,!1,"TextActionAttribute",0,"WWTextActionColumn column-optional");t.addSingleLineEdit("Btngenerate",41,"vBTNGENERATE","","","BtnGenerate","char",0,"px",20,20,"start","e213f2_client",[],"Btngenerate","BtnGenerate",!0,0,!1,!1,"TextActionAttribute",0,"WWTextActionColumn column-optional");this.GridwwContainer.emptyText=gx.getMessage("No results found.");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"GAM_HEADERWWBACKFILTERS",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"GAM_HEADERWWBACKFILTERS_TBLBACKCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"GAM_HEADERWWBACKFILTERS_TABLEBACK",grid:0,evt:"e143f2_client"};n[15]={id:15,fld:"GAM_HEADERWWBACKFILTERS_TXTBACK",format:0,grid:0,ctrltype:"textblock"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GAM_HEADERWWBACKFILTERS_TABLEACTIONS",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"GAM_HEADERWWBACKFILTERS_TITLE",format:0,grid:0,ctrltype:"textblock"};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"GAM_HEADERWWBACKFILTERS_ADDNEW",grid:0,evt:"e253f1_client"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e223f1_client",evt_cvcing:null,rgrid:[],fld:"vSEARCH",fmt:0,gxz:"ZV29Search",gxold:"OV29Search",gxvar:"AV29Search",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV29Search=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29Search=n)},v2c:function(){gx.fn.setControlValue("vSEARCH",gx.O.AV29Search,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV29Search=this.val())},val:function(){return gx.fn.getControlValue("vSEARCH")},nac:gx.falseFn};this.declareDomainHdlr(25,function(){});n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"GAM_HEADERWWBACKFILTERS_TOGGLEFILTERS",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"SECTIONGRID",grid:0};n[31]={id:31,fld:"GRIDTABLE",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:34,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",fmt:0,gxz:"ZV21Id",gxold:"OV21Id",gxvar:"AV21Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV21Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV21Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(34),gx.O.AV21Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(34),gx.thousandSeparator)},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:34,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV24Name",gxold:"OV24Name",gxvar:"AV24Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV24Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(34),gx.O.AV24Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV24Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:34,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDESCRIPTION",fmt:0,gxz:"ZV38Description",gxold:"OV38Description",gxvar:"AV38Description",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV38Description=n)},v2z:function(n){n!==undefined&&(gx.O.ZV38Description=n)},v2c:function(n){gx.fn.setGridControlValue("vDESCRIPTION",n||gx.fn.currentGridRowImpl(34),gx.O.AV38Description,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV38Description=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDESCRIPTION",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"char",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:34,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCLIENTID",fmt:0,gxz:"ZV13ClientID",gxold:"OV13ClientID",gxvar:"AV13ClientID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV13ClientID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13ClientID=n)},v2c:function(n){gx.fn.setGridControlValue("vCLIENTID",n||gx.fn.currentGridRowImpl(34),gx.O.AV13ClientID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13ClientID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vCLIENTID",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[39]={id:39,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:34,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTATUS",fmt:0,gxz:"ZV30Status",gxold:"OV30Status",gxvar:"AV30Status",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV30Status=n)},v2z:function(n){n!==undefined&&(gx.O.ZV30Status=n)},v2c:function(n){gx.fn.setGridControlValue("vSTATUS",n||gx.fn.currentGridRowImpl(34),gx.O.AV30Status,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV30Status=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSTATUS",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn};n[40]={id:40,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:34,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNREVOKE",fmt:0,gxz:"ZV12BtnRevoke",gxold:"OV12BtnRevoke",gxvar:"AV12BtnRevoke",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12BtnRevoke=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12BtnRevoke=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNREVOKE",n||gx.fn.currentGridRowImpl(34),gx.O.AV12BtnRevoke,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12BtnRevoke=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNREVOKE",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn,evt:"e203f2_client"};n[41]={id:41,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:34,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNGENERATE",fmt:0,gxz:"ZV34BtnGenerate",gxold:"OV34BtnGenerate",gxvar:"AV34BtnGenerate",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV34BtnGenerate=n)},v2z:function(n){n!==undefined&&(gx.O.ZV34BtnGenerate=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNGENERATE",n||gx.fn.currentGridRowImpl(34),gx.O.AV34BtnGenerate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV34BtnGenerate=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNGENERATE",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn,evt:"e213f2_client"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"GAM_PAGINGWW",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"GAM_PAGINGWW_TBLPAGINGBUTTONS",grid:0};n[50]={id:50,fld:"GAM_PAGINGWW_BTNFIRST",grid:0,evt:"e173f1_client"};n[52]={id:52,fld:"GAM_PAGINGWW_BTNPREVIOUS",grid:0,evt:"e183f1_client"};n[54]={id:54,fld:"GAM_PAGINGWW_BTNNEXT",grid:0,evt:"e193f1_client"};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCURRENTPAGE",fmt:0,gxz:"ZV15CurrentPage",gxold:"OV15CurrentPage",gxvar:"AV15CurrentPage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15CurrentPage=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15CurrentPage=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCURRENTPAGE",gx.O.AV15CurrentPage,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15CurrentPage=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCURRENTPAGE",gx.thousandSeparator)},nac:gx.falseFn};n[59]={id:59,fld:"GAM_FILTERSWW",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"GAM_FILTERSWW_HIDEFILTERS",grid:0,evt:"e113f1_client"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"GAM_FILTERSWW_TABLEFILTERS",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILTERGUID",fmt:0,gxz:"ZV35FilterGUID",gxold:"OV35FilterGUID",gxvar:"AV35FilterGUID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV35FilterGUID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV35FilterGUID=n)},v2c:function(){gx.fn.setControlValue("vFILTERGUID",gx.O.AV35FilterGUID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV35FilterGUID=this.val())},val:function(){return gx.fn.getControlValue("vFILTERGUID")},nac:gx.falseFn};this.declareDomainHdlr(70,function(){});n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILTERCLIENTID",fmt:0,gxz:"ZV36FilterClientId",gxold:"OV36FilterClientId",gxvar:"AV36FilterClientId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV36FilterClientId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV36FilterClientId=n)},v2c:function(){gx.fn.setControlValue("vFILTERCLIENTID",gx.O.AV36FilterClientId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV36FilterClientId=this.val())},val:function(){return gx.fn.getControlValue("vFILTERCLIENTID")},nac:gx.falseFn};this.declareDomainHdlr(75,function(){});n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILTERDESCRIPTION",fmt:0,gxz:"ZV37FilterDescription",gxold:"OV37FilterDescription",gxvar:"AV37FilterDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV37FilterDescription=n)},v2z:function(n){n!==undefined&&(gx.O.ZV37FilterDescription=n)},v2c:function(){gx.fn.setControlValue("vFILTERDESCRIPTION",gx.O.AV37FilterDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV37FilterDescription=this.val())},val:function(){return gx.fn.getControlValue("vFILTERDESCRIPTION")},nac:gx.falseFn};this.declareDomainHdlr(80,function(){});n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"GAM_FILTERSWW_CLEARFILTERS",grid:0,evt:"e123f1_client"};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"GAM_FILTERSWW_APPLY",grid:0,evt:"e133f1_client"};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"GAM_FOOTERENTRY",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"GAM_FOOTERENTRY_TABLEBUTTONS",grid:0};n[95]={id:95,fld:"",grid:0};n[96]={id:96,fld:"GAM_FOOTERENTRY_BTNCANCEL",grid:0,evt:"e263f1_client"};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"GAM_FOOTERENTRY_BTNCONFIRM",grid:0,evt:"e273f1_client"};this.AV29Search="";this.ZV29Search="";this.OV29Search="";this.ZV21Id=0;this.OV21Id=0;this.ZV24Name="";this.OV24Name="";this.ZV38Description="";this.OV38Description="";this.ZV13ClientID="";this.OV13ClientID="";this.ZV30Status="";this.OV30Status="";this.ZV12BtnRevoke="";this.OV12BtnRevoke="";this.ZV34BtnGenerate="";this.OV34BtnGenerate="";this.AV15CurrentPage=0;this.ZV15CurrentPage=0;this.OV15CurrentPage=0;this.AV35FilterGUID="";this.ZV35FilterGUID="";this.OV35FilterGUID="";this.AV36FilterClientId="";this.ZV36FilterClientId="";this.OV36FilterClientId="";this.AV37FilterDescription="";this.ZV37FilterDescription="";this.OV37FilterDescription="";this.AV29Search="";this.AV15CurrentPage=0;this.AV35FilterGUID="";this.AV36FilterClientId="";this.AV37FilterDescription="";this.AV31UserGUID="";this.AV21Id=0;this.AV24Name="";this.AV38Description="";this.AV13ClientID="";this.AV30Status="";this.AV12BtnRevoke="";this.AV34BtnGenerate="";this.AV10BoolenFilter="";this.AV27PermissionAccessType="";this.AV33Window={};this.Events={e143f2_client:["GAM_HEADERWWBACKFILTERS_TABLEBACK.CLICK",!0],e233f2_client:["ENTER",!0],e243f2_client:["CANCEL",!0],e203f2_client:["VBTNREVOKE.CLICK",!1],e213f2_client:["VBTNGENERATE.CLICK",!1],e223f1_client:["VSEARCH.CONTROLVALUECHANGED",!1],e133f1_client:["'APPLY'",!1],e123f1_client:["'CLEARFILTERS'",!1],e113f1_client:["'HIDE'",!1],e173f1_client:["'FIRST'",!1],e183f1_client:["'PREVIOUS'",!1],e193f1_client:["'NEXT'",!1]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"}],[{av:"AV12BtnRevoke",fld:"vBTNREVOKE"},{av:"AV34BtnGenerate",fld:"vBTNGENERATE"},{av:"AV21Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV24Name",fld:"vNAME"},{av:"AV38Description",fld:"vDESCRIPTION"},{av:"AV13ClientID",fld:"vCLIENTID",hsh:!0},{av:"AV30Status",fld:"vSTATUS"},{av:"gx.fn.getCtrlProperty('vSTATUS','Class')",ctrl:"vSTATUS",prop:"Class"},{av:"gx.fn.getCtrlProperty('vBTNREVOKE','Enabled')",ctrl:"vBTNREVOKE",prop:"Enabled"},{ctrl:"GAM_PAGINGWW_BTNNEXT",prop:"Enabled"},{ctrl:"GAM_PAGINGWW_BTNFIRST",prop:"Enabled"},{ctrl:"GAM_PAGINGWW_BTNPREVIOUS",prop:"Enabled"}]];this.EvtParms["VBTNREVOKE.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0},{av:"AV13ClientID",fld:"vCLIENTID",hsh:!0}],[]];this.EvtParms["VBTNGENERATE.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0},{av:"AV13ClientID",fld:"vCLIENTID",hsh:!0}],[]];this.EvtParms["VSEARCH.CONTROLVALUECHANGED"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[]];this.EvtParms["'APPLY'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[]];this.EvtParms["'CLEARFILTERS'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[]];this.EvtParms["'HIDE'"]=[[{av:"gx.fn.getCtrlProperty('GAM_FILTERSWW','Class')",ctrl:"GAM_FILTERSWW",prop:"Class"}],[{av:"gx.fn.getCtrlProperty('GAM_FILTERSWW','Class')",ctrl:"GAM_FILTERSWW",prop:"Class"},{av:"gx.fn.getCtrlProperty('GAM_HEADERWWBACKFILTERS_TOGGLEFILTERS','Tooltiptext')",ctrl:"GAM_HEADERWWBACKFILTERS_TOGGLEFILTERS",prop:"Tooltiptext"}]];this.EvtParms["GAM_HEADERWWBACKFILTERS_TABLEBACK.CLICK"]=[[{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[]];this.EvtParms["'FIRST'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]];this.EvtParms["'PREVIOUS'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]];this.EvtParms["'NEXT'"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRIDWW_FIRSTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[]];this.EvtParms.GRIDWW_PREVPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[]];this.EvtParms.GRIDWW_NEXTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0}],[]];this.EvtParms.GRIDWW_LASTPAGE=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"",ctrl:"GRIDWW",prop:"Rows"},{av:"AV15CurrentPage",fld:"vCURRENTPAGE",pic:"ZZZ9"},{av:"AV29Search",fld:"vSEARCH"},{av:"AV35FilterGUID",fld:"vFILTERGUID"},{av:"AV36FilterClientId",fld:"vFILTERCLIENTID"},{av:"AV37FilterDescription",fld:"vFILTERDESCRIPTION"},{av:"AV31UserGUID",fld:"vUSERGUID",hsh:!0},{av:"subGridww_Recordcount"}],[]];this.setVCMap("AV31UserGUID","vUSERGUID",0,"char",40,0);this.setVCMap("AV10BoolenFilter","vBOOLENFILTER",0,"char",1,0);this.setVCMap("AV27PermissionAccessType","vPERMISSIONACCESSTYPE",0,"char",1,0);this.setVCMap("AV31UserGUID","vUSERGUID",0,"char",40,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Gridww"});t.addRefreshingVar(this.GXValidFnc[58]);t.addRefreshingVar(this.GXValidFnc[25]);t.addRefreshingVar(this.GXValidFnc[70]);t.addRefreshingVar(this.GXValidFnc[75]);t.addRefreshingVar(this.GXValidFnc[80]);t.addRefreshingVar({rfrVar:"AV31UserGUID"});t.addRefreshingParm(this.GXValidFnc[58]);t.addRefreshingParm(this.GXValidFnc[25]);t.addRefreshingParm(this.GXValidFnc[70]);t.addRefreshingParm(this.GXValidFnc[75]);t.addRefreshingParm(this.GXValidFnc[80]);t.addRefreshingParm({rfrVar:"AV31UserGUID"});this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0088",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_wwuserapplications)})