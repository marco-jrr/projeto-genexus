gx.evt.autoSkip=!1;gx.define("gam_usercustomattributes",!1,function(){var t,i,n;this.ServerClass="gam_usercustomattributes";this.PackageName="GeneXus.Security.Backend";this.ServerFullClass="gam_usercustomattributes.aspx";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="GAMDesignSystem";this.SetStandaloneVars=function(){this.AV17GUID=gx.fn.getControlValue("vGUID");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV19Title=gx.fn.getControlValue("vTITLE");this.subGridattributes_Recordcount=gx.fn.getIntegerValue("subGridattributes_Recordcount",gx.thousandSeparator)};this.s112_client=function(){return this.executeClientEvent(function(){this.createWebComponent("Wcmessages","GAM_Messages",[])},arguments)};this.s122_client=function(){return this.executeClientEvent(function(){this.AV10Delete=gx.getMessage("GAM_Delete");this.AV11ClearMV=gx.getMessage("GAM_Clear");gx.text.compare(this.Gx_mode,"DSP")==0||gx.text.compare(this.Gx_mode,"DLT")==0?(gx.fn.setCtrlProperty("vATTRIBUTEID","Enabled",!1),gx.fn.setCtrlProperty("vATTRIBUTEVALUE","Enabled",!1),gx.fn.setCtrlProperty("vATTRIBUTEISMV","Enabled",!1),gx.fn.setCtrlProperty("vDELETE","Visible",!1),gx.fn.setCtrlProperty("vCLEARMV","Visible",!1),gx.fn.setCtrlProperty("NEWMV","Visible",!1),this.AV6AttributeIsMV?(gx.fn.setCtrlProperty("TABLEMV","Visible",!0),gx.fn.setCtrlProperty("vATTRIBUTEVALUE","Visible",!1)):(gx.fn.setCtrlProperty("TABLEMV","Visible",!1),gx.fn.setCtrlProperty("vATTRIBUTEVALUE","Visible",!0))):(gx.fn.setCtrlProperty("vATTRIBUTEID","Enabled",!0),gx.fn.setCtrlProperty("vATTRIBUTEVALUE","Enabled",!0),gx.fn.setCtrlProperty("vATTRIBUTEISMV","Enabled",!0),this.AV6AttributeIsMV?(gx.fn.setCtrlProperty("vCLEARMV","Visible",!0),gx.fn.setCtrlProperty("NEWMV","Visible",!0),gx.fn.setCtrlProperty("TABLEMV","Visible",!0),gx.fn.setCtrlProperty("vATTRIBUTEVALUE","Visible",!1)):(gx.fn.setCtrlProperty("vCLEARMV","Visible",!1),gx.fn.setCtrlProperty("NEWMV","Visible",!1),gx.fn.setCtrlProperty("TABLEMV","Visible",!1),gx.fn.setCtrlProperty("vATTRIBUTEVALUE","Visible",!0)))},arguments)};this.e203j2_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.s122_client();this.refreshOutputs([{av:"AV10Delete",fld:"vDELETE"},{av:"AV11ClearMV",fld:"vCLEARMV"},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEID','Enabled')",ctrl:"vATTRIBUTEID",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Enabled')",ctrl:"vATTRIBUTEVALUE",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEISMV','Enabled')",ctrl:"vATTRIBUTEISMV",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vCLEARMV','Visible')",ctrl:"vCLEARMV",prop:"Visible"},{ctrl:"NEWMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('TABLEMV','Visible')",ctrl:"TABLEMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Visible')",ctrl:"vATTRIBUTEVALUE",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e193j2_client=function(){return this.executeClientEvent(function(){this.clearMessages();gx.fn.setCtrlProperty("vATTRIBUTEID","Visible",!1);gx.fn.setCtrlProperty("vDELETE","Visible",!1);this.AV5AttributeID="";this.AV10Delete="";gx.fn.setCtrlProperty("MVTABLE","Visible",!1);gx.fn.setCtrlProperty("VALUESTABLE","Visible",!1);this.refreshOutputs([{av:"gx.fn.getCtrlProperty('vATTRIBUTEID','Visible')",ctrl:"vATTRIBUTEID",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV5AttributeID",fld:"vATTRIBUTEID"},{av:"AV10Delete",fld:"vDELETE"},{av:"gx.fn.getCtrlProperty('MVTABLE','Visible')",ctrl:"MVTABLE",prop:"Visible"},{av:"gx.fn.getCtrlProperty('VALUESTABLE','Visible')",ctrl:"VALUESTABLE",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e183j2_client=function(){return this.executeClientEvent(function(){this.clearMessages();for(var r=gx.fn.currentGridRowImpl(30),n=1,i=gx.fn.currentGridRowImpl(71),u,t=gx.O.getGridById(71,r);n<=t.grid.rows.length;)u=gx.text.padl(gx.text.tostring(n),4,"0"),t.instanciateRow(t.grid.getRowById(n-1)),gx.fn.setCtrlProperty("vATTRIBUTEMVID","Visible",!1),gx.fn.setCtrlProperty("vATTRIBUTEMVVALUE","Visible",!1),this.AV7AttributeMVID="",this.AV8AttributeMVValue="",n=gx.num.trunc(n+1,0),this.refreshRowOutputs([{av:"gx.fn.getCtrlProperty('vATTRIBUTEMVID','Visible')",ctrl:"vATTRIBUTEMVID",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEMVVALUE','Visible')",ctrl:"vATTRIBUTEMVVALUE",prop:"Visible"},{av:"AV7AttributeMVID",fld:"vATTRIBUTEMVID"},{av:"AV8AttributeMVValue",fld:"vATTRIBUTEMVVALUE"}]);i&&t.instanciateRow(i);this.refreshOutputs([{av:"gx.fn.getCtrlProperty('vATTRIBUTEMVID','Visible')",ctrl:"vATTRIBUTEMVID",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEMVVALUE','Visible')",ctrl:"vATTRIBUTEMVVALUE",prop:"Visible"},{av:"AV7AttributeMVID",fld:"vATTRIBUTEMVID"},{av:"AV8AttributeMVValue",fld:"vATTRIBUTEMVVALUE"}]);this.OnClientEventEnd()},arguments)};this.e113j2_client=function(){return this.executeServerEvent("'NEWROW'",!1,null,!1,!1)};this.e143j2_client=function(){return this.executeServerEvent("'NEWROWMV'",!0,arguments[0],!1,!1)};this.e123j2_client=function(){return this.executeServerEvent("'CANCEL'",!1,null,!1,!1)};this.e133j2_client=function(){return this.executeServerEvent("'CONFIRM'",!1,null,!1,!1)};this.e213j2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e223j2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,31,32,33,34,35,36,37,38,41,42,43,46,47,48,51,52,53,56,59,62,64,67,68,72,73,74,75,76,77,78,79,81,82,83,84,85,86,87,88,89,90];this.GXLastCtrlId=90;this.GridmvContainer=new gx.grid.grid(this,3,"WbpLvl3",71,"Gridmv","Gridmv","GridmvContainer",this.CmpContext,this.IsMasterPage,"gam_usercustomattributes",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!0,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridmvContainer;i.addSingleLineEdit("Attributemvid",72,"vATTRIBUTEMVID",gx.getMessage("GAM_AttributeID"),"","AttributeMVID","svchar",0,"px",40,40,"start",null,[],"Attributemvid","AttributeMVID",!0,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit("Attributemvvalue",73,"vATTRIBUTEMVVALUE",gx.getMessage("GAM_AttributeValue"),"","AttributeMVValue","svchar",0,"px",40,40,"start",null,[],"Attributemvvalue","AttributeMVValue",!0,0,!1,!1,"Attribute",0,"");this.GridmvContainer.emptyText=gx.getMessage("");this.GridattributesContainer=new gx.grid.grid(this,2,"WbpLvl2",30,"Gridattributes","Gridattributes","GridattributesContainer",this.CmpContext,this.IsMasterPage,"gam_usercustomattributes",[],!0,1,!1,!0,0,!1,!1,!1,"",100,"%",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!0,null,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);n=this.GridattributesContainer;n.startDiv(31,"Resposibletable","0px","0px");n.startDiv(32,"","0px","0px");n.startDiv(33,"","0px","0px");n.startDiv(34,"","0px","0px");n.addLabel();n.startDiv(35,"","0px","0px");n.addSingleLineEdit("Attributeid",36,"vATTRIBUTEID","","","AttributeID","svchar",40,"chr",40,40,"start",null,[],"Attributeid","AttributeID",!0,0,!1,!1,"Attribute",0,"");n.endDiv();n.endDiv();n.endDiv();n.startDiv(37,"","0px","0px");n.startTable("Mvtable",38,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startDiv(41,"","0px","0px");n.addLabel();n.startDiv(42,"","0px","100%");n.addCheckBox("Attributeismv",43,"vATTRIBUTEISMV","","","AttributeIsMV","boolean","true","false",null,!0,!1,1,"chr","");n.endDiv();n.endDiv();n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","","","","","","","","","stack-bottom-r");n.addButton(46,"NEWMV","standard","'","e143j2_client");n.endCell();n.endRow();n.endTable();n.endDiv();n.startDiv(47,"","0px","0px");n.startTable("Valuestable",48,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startDiv(51,"","0px","0px");n.addLabel();n.startDiv(52,"","0px","100%");n.addSingleLineEdit("Attributevalue",53,"vATTRIBUTEVALUE","","","AttributeValue","svchar",75,"%",40,40,"start",null,[],"Attributevalue","AttributeValue",!0,0,!1,!1,"Attribute",0,"");n.endDiv();n.endDiv();n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startTable("Tablemv",56,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startTable("Tablemvtitle",59,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.addTextBlock("TBATTRIBUTEVALUELIST",null,62);n.endCell();n.startCell("","","","","","","","","","");n.startTable("Tableclearmv",64,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startDiv(67,"","0px","0px");n.addSingleLineEdit("Clearmv",68,"vCLEARMV","","","ClearMV","char",20,"chr",20,20,"start","e183j2_client",[],"Clearmv","ClearMV",!0,0,!1,!1,"TextActionAttribute",0,"");n.endDiv();n.endCell();n.endRow();n.endTable();n.endCell();n.endRow();n.endTable();n.endCell();n.endRow();n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.addGrid(this.GridmvContainer);n.endCell();n.endRow();n.endTable();n.endCell();n.endRow();n.endTable();n.endDiv();n.startDiv(74,"","0px","0px");n.startDiv(75,"","0px","0px");n.startDiv(76,"","0px","0px");n.addSingleLineEdit("Delete",77,"vDELETE","","","Delete","char",20,"chr",20,20,"start","e193j2_client",[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",0,"");n.endDiv();n.endDiv();n.endDiv();n.endDiv();n.endDiv();this.GridattributesContainer.emptyText=gx.getMessage("GAM_Noresultsfound");this.setGrid(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"GAM_HEADERWWNOFILTERS",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"GAM_HEADERWWNOFILTERS_TABLEACTIONS",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"GAM_HEADERWWNOFILTERS_TITLE",format:0,grid:0,ctrltype:"textblock"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"GAM_HEADERWWNOFILTERS_ADDNEW",grid:0,evt:"e233j1_client"};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSEARCH",fmt:0,gxz:"ZV18Search",gxold:"OV18Search",gxvar:"AV18Search",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV18Search=n)},v2z:function(n){n!==undefined&&(gx.O.ZV18Search=n)},v2c:function(){gx.fn.setControlValue("vSEARCH",gx.O.AV18Search,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV18Search=this.val())},val:function(){return gx.fn.getControlValue("vSEARCH")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"SECTION1",grid:0};t[20]={id:20,fld:"GRIDTABLE",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"GROUPPROPERTIES",grid:0};t[24]={id:24,fld:"GROUPPROPERTIESTABLE1",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"BTNADDGRIDLINE",grid:0,evt:"e113j2_client"};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"",grid:0};t[31]={id:31,fld:"RESPOSIBLETABLE",grid:30};t[32]={id:32,fld:"",grid:30};t[33]={id:33,fld:"",grid:30};t[34]={id:34,fld:"",grid:30};t[35]={id:35,fld:"",grid:30};t[36]={id:36,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.GridattributesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vATTRIBUTEID",fmt:0,gxz:"ZV5AttributeID",gxold:"OV5AttributeID",gxvar:"AV5AttributeID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV5AttributeID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5AttributeID=n)},v2c:function(n){gx.fn.setGridControlValue("vATTRIBUTEID",n||gx.fn.currentGridRowImpl(30),gx.O.AV5AttributeID,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5AttributeID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vATTRIBUTEID",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};t[37]={id:37,fld:"",grid:30};t[38]={id:38,fld:"MVTABLE",grid:30};t[41]={id:41,fld:"",grid:30};t[42]={id:42,fld:"",grid:30};t[43]={id:43,lvl:2,type:"boolean",len:1,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.GridattributesContainer,fnc:null,isvalid:null,evt_cvc:"e203j2_client",evt_cvcing:null,rgrid:[],fld:"vATTRIBUTEISMV",fmt:0,gxz:"ZV6AttributeIsMV",gxold:"OV6AttributeIsMV",gxvar:"AV6AttributeIsMV",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV6AttributeIsMV=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6AttributeIsMV=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("vATTRIBUTEISMV",n||gx.fn.currentGridRowImpl(30),gx.O.AV6AttributeIsMV,!0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6AttributeIsMV=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("vATTRIBUTEISMV",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn,values:["true","false"]};t[46]={id:46,fld:"NEWMV",grid:30,evt:"e143j2_client"};t[47]={id:47,fld:"",grid:30};t[48]={id:48,fld:"VALUESTABLE",grid:30};t[51]={id:51,fld:"",grid:30};t[52]={id:52,fld:"",grid:30};t[53]={id:53,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.GridattributesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vATTRIBUTEVALUE",fmt:0,gxz:"ZV9AttributeValue",gxold:"OV9AttributeValue",gxvar:"AV9AttributeValue",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV9AttributeValue=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9AttributeValue=n)},v2c:function(n){gx.fn.setGridControlValue("vATTRIBUTEVALUE",n||gx.fn.currentGridRowImpl(30),gx.O.AV9AttributeValue,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9AttributeValue=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vATTRIBUTEVALUE",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn};t[56]={id:56,fld:"TABLEMV",grid:30};t[59]={id:59,fld:"TABLEMVTITLE",grid:30};t[62]={id:62,fld:"TBATTRIBUTEVALUELIST",format:0,grid:30,ctrltype:"textblock"};t[64]={id:64,fld:"TABLECLEARMV",grid:30};t[67]={id:67,fld:"",grid:30};t[68]={id:68,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.GridattributesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCLEARMV",fmt:0,gxz:"ZV11ClearMV",gxold:"OV11ClearMV",gxvar:"AV11ClearMV",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11ClearMV=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11ClearMV=n)},v2c:function(n){gx.fn.setGridControlValue("vCLEARMV",n||gx.fn.currentGridRowImpl(30),gx.O.AV11ClearMV,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11ClearMV=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vCLEARMV",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn,evt:"e183j2_client"};t[72]={id:72,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:71,gxgrid:this.GridmvContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vATTRIBUTEMVID",fmt:0,gxz:"ZV7AttributeMVID",gxold:"OV7AttributeMVID",gxvar:"AV7AttributeMVID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV7AttributeMVID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7AttributeMVID=n)},v2c:function(n){gx.fn.setGridControlValue("vATTRIBUTEMVID",n||gx.fn.currentGridRowImpl(71),gx.O.AV7AttributeMVID,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV7AttributeMVID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vATTRIBUTEMVID",n||gx.fn.currentGridRowImpl(71))},nac:gx.falseFn};t[73]={id:73,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:0,isacc:0,grid:71,gxgrid:this.GridmvContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vATTRIBUTEMVVALUE",fmt:0,gxz:"ZV8AttributeMVValue",gxold:"OV8AttributeMVValue",gxvar:"AV8AttributeMVValue",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV8AttributeMVValue=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8AttributeMVValue=n)},v2c:function(n){gx.fn.setGridControlValue("vATTRIBUTEMVVALUE",n||gx.fn.currentGridRowImpl(71),gx.O.AV8AttributeMVValue,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8AttributeMVValue=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vATTRIBUTEMVVALUE",n||gx.fn.currentGridRowImpl(71))},nac:gx.falseFn};t[74]={id:74,fld:"",grid:30};t[75]={id:75,fld:"",grid:30};t[76]={id:76,fld:"",grid:30};t[77]={id:77,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:30,gxgrid:this.GridattributesContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV10Delete",gxold:"OV10Delete",gxvar:"AV10Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV10Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(30),gx.O.AV10Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(30))},nac:gx.falseFn,evt:"e193j2_client"};t[78]={id:78,fld:"",grid:0};t[79]={id:79,fld:"",grid:0};t[81]={id:81,fld:"",grid:0};t[82]={id:82,fld:"",grid:0};t[83]={id:83,fld:"GAM_FOOTERPOPUP",grid:0};t[84]={id:84,fld:"",grid:0};t[85]={id:85,fld:"",grid:0};t[86]={id:86,fld:"GAM_FOOTERPOPUP_TABLEBUTTONS",grid:0};t[87]={id:87,fld:"",grid:0};t[88]={id:88,fld:"GAM_FOOTERPOPUP_BTNCANCEL",grid:0,evt:"e123j2_client"};t[89]={id:89,fld:"",grid:0};t[90]={id:90,fld:"GAM_FOOTERPOPUP_BTNCONFIRM",grid:0,evt:"e133j2_client"};this.AV18Search="";this.ZV18Search="";this.OV18Search="";this.ZV5AttributeID="";this.OV5AttributeID="";this.ZV6AttributeIsMV=!1;this.OV6AttributeIsMV=!1;this.ZV9AttributeValue="";this.OV9AttributeValue="";this.ZV11ClearMV="";this.OV11ClearMV="";this.ZV7AttributeMVID="";this.OV7AttributeMVID="";this.ZV8AttributeMVValue="";this.OV8AttributeMVValue="";this.ZV10Delete="";this.OV10Delete="";this.AV18Search="";this.AV19Title="";this.AV17GUID="";this.AV5AttributeID="";this.AV6AttributeIsMV=!1;this.AV9AttributeValue="";this.AV11ClearMV="";this.AV10Delete="";this.AV7AttributeMVID="";this.AV8AttributeMVValue="";this.Gx_mode="";this.Events={e113j2_client:["'NEWROW'",!0],e143j2_client:["'NEWROWMV'",!0],e123j2_client:["'CANCEL'",!0],e133j2_client:["'CONFIRM'",!0],e213j2_client:["ENTER",!0],e223j2_client:["CANCEL",!0],e203j2_client:["VATTRIBUTEISMV.CONTROLVALUECHANGED",!1],e193j2_client:["'DELETEROW'",!1],e183j2_client:["'CLEARROWSMV'",!1]};this.EvtParms.REFRESH=[[{av:"GRIDATTRIBUTES_nFirstRecordOnPage"},{av:"GRIDATTRIBUTES_nEOF"},{av:"AV6AttributeIsMV",fld:"vATTRIBUTEISMV"},{av:"GRIDMV_nFirstRecordOnPage"},{av:"GRIDMV_nEOF"},{av:"AV17GUID",fld:"vGUID",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV19Title",fld:"vTITLE",hsh:!0}],[]];this.EvtParms["GRIDATTRIBUTES.LOAD"]=[[{av:"AV17GUID",fld:"vGUID",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV6AttributeIsMV",fld:"vATTRIBUTEISMV"}],[{av:"AV5AttributeID",fld:"vATTRIBUTEID"},{av:"AV9AttributeValue",fld:"vATTRIBUTEVALUE"},{av:"AV6AttributeIsMV",fld:"vATTRIBUTEISMV"},{ctrl:"WCMESSAGES"},{av:"AV10Delete",fld:"vDELETE"},{av:"AV11ClearMV",fld:"vCLEARMV"},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEID','Enabled')",ctrl:"vATTRIBUTEID",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Enabled')",ctrl:"vATTRIBUTEVALUE",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEISMV','Enabled')",ctrl:"vATTRIBUTEISMV",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vCLEARMV','Visible')",ctrl:"vCLEARMV",prop:"Visible"},{ctrl:"NEWMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('TABLEMV','Visible')",ctrl:"TABLEMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Visible')",ctrl:"vATTRIBUTEVALUE",prop:"Visible"}]];this.EvtParms["GRIDMV.LOAD"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[{av:"AV7AttributeMVID",fld:"vATTRIBUTEMVID"},{av:"AV8AttributeMVValue",fld:"vATTRIBUTEMVVALUE"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEMVID','Enabled')",ctrl:"vATTRIBUTEMVID",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEMVVALUE','Enabled')",ctrl:"vATTRIBUTEMVVALUE",prop:"Enabled"}]];this.EvtParms["VATTRIBUTEISMV.CONTROLVALUECHANGED"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV6AttributeIsMV",fld:"vATTRIBUTEISMV"}],[{av:"AV10Delete",fld:"vDELETE"},{av:"AV11ClearMV",fld:"vCLEARMV"},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEID','Enabled')",ctrl:"vATTRIBUTEID",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Enabled')",ctrl:"vATTRIBUTEVALUE",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEISMV','Enabled')",ctrl:"vATTRIBUTEISMV",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vCLEARMV','Visible')",ctrl:"vCLEARMV",prop:"Visible"},{ctrl:"NEWMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('TABLEMV','Visible')",ctrl:"TABLEMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Visible')",ctrl:"vATTRIBUTEVALUE",prop:"Visible"}]];this.EvtParms["'NEWROW'"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV6AttributeIsMV",fld:"vATTRIBUTEISMV"}],[{av:"AV6AttributeIsMV",fld:"vATTRIBUTEISMV"},{av:"AV10Delete",fld:"vDELETE"},{av:"AV11ClearMV",fld:"vCLEARMV"},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEID','Enabled')",ctrl:"vATTRIBUTEID",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Enabled')",ctrl:"vATTRIBUTEVALUE",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEISMV','Enabled')",ctrl:"vATTRIBUTEISMV",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vCLEARMV','Visible')",ctrl:"vCLEARMV",prop:"Visible"},{ctrl:"NEWMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('TABLEMV','Visible')",ctrl:"TABLEMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Visible')",ctrl:"vATTRIBUTEVALUE",prop:"Visible"}]];this.EvtParms["'NEWROWMV'"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV6AttributeIsMV",fld:"vATTRIBUTEISMV"}],[{av:"AV10Delete",fld:"vDELETE"},{av:"AV11ClearMV",fld:"vCLEARMV"},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEID','Enabled')",ctrl:"vATTRIBUTEID",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Enabled')",ctrl:"vATTRIBUTEVALUE",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEISMV','Enabled')",ctrl:"vATTRIBUTEISMV",prop:"Enabled"},{av:"gx.fn.getCtrlProperty('vCLEARMV','Visible')",ctrl:"vCLEARMV",prop:"Visible"},{ctrl:"NEWMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('TABLEMV','Visible')",ctrl:"TABLEMV",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEVALUE','Visible')",ctrl:"vATTRIBUTEVALUE",prop:"Visible"}]];this.EvtParms["'DELETEROW'"]=[[],[{av:"gx.fn.getCtrlProperty('vATTRIBUTEID','Visible')",ctrl:"vATTRIBUTEID",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vDELETE','Visible')",ctrl:"vDELETE",prop:"Visible"},{av:"AV5AttributeID",fld:"vATTRIBUTEID"},{av:"AV10Delete",fld:"vDELETE"},{av:"gx.fn.getCtrlProperty('MVTABLE','Visible')",ctrl:"MVTABLE",prop:"Visible"},{av:"gx.fn.getCtrlProperty('VALUESTABLE','Visible')",ctrl:"VALUESTABLE",prop:"Visible"}]];this.EvtParms["'CLEARROWSMV'"]=[[],[{av:"gx.fn.getCtrlProperty('vATTRIBUTEMVID','Visible')",ctrl:"vATTRIBUTEMVID",prop:"Visible"},{av:"gx.fn.getCtrlProperty('vATTRIBUTEMVVALUE','Visible')",ctrl:"vATTRIBUTEMVVALUE",prop:"Visible"},{av:"AV7AttributeMVID",fld:"vATTRIBUTEMVID"},{av:"AV8AttributeMVValue",fld:"vATTRIBUTEMVVALUE"}]];this.EvtParms["'CANCEL'"]=[[],[]];this.EvtParms["'CONFIRM'"]=[[{av:"AV17GUID",fld:"vGUID",hsh:!0},{av:"AV5AttributeID",fld:"vATTRIBUTEID",grid:30},{av:"GRIDATTRIBUTES_nFirstRecordOnPage"},{av:"nRC_GXsfl_30",ctrl:"GRIDATTRIBUTES",grid:30,prop:"GridRC",grid:30},{av:"AV6AttributeIsMV",fld:"vATTRIBUTEISMV",grid:30},{av:"AV7AttributeMVID",fld:"vATTRIBUTEMVID",grid:71},{av:"GRIDMV_nFirstRecordOnPage"},{av:"nRC_GXsfl_71",ctrl:"GRIDMV",grid:71,prop:"GridRC",grid:71},{av:"AV8AttributeMVValue",fld:"vATTRIBUTEMVVALUE",grid:71},{av:"AV9AttributeValue",fld:"vATTRIBUTEVALUE",grid:30}],[{ctrl:"WCMESSAGES"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV17GUID","vGUID",0,"svchar",40,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV19Title","vTITLE",0,"svchar",40,0);this.setVCMap("AV17GUID","vGUID",0,"svchar",40,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV17GUID","vGUID",0,"svchar",40,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);i.addRefreshingVar({rfrVar:"Gx_mode"});i.addRefreshingVar({rfrVar:"AV17GUID"});i.addRefreshingVar({rfrVar:"AV19Title"});i.addRefreshingParm({rfrVar:"Gx_mode"});i.addRefreshingParm({rfrVar:"AV17GUID"});i.addRefreshingParm({rfrVar:"AV19Title"});n.addRefreshingVar({rfrVar:"AV17GUID"});n.addRefreshingVar({rfrVar:"Gx_mode"});n.addRefreshingVar({rfrVar:"AV6AttributeIsMV",rfrProp:"Value",gxAttId:"Attributeismv"});n.addRefreshingVar({rfrVar:"AV19Title"});n.addRefreshingParm({rfrVar:"AV17GUID"});n.addRefreshingParm({rfrVar:"Gx_mode"});n.addRefreshingParm({rfrVar:"AV6AttributeIsMV",rfrProp:"Value",gxAttId:"Attributeismv"});n.addRefreshingParm({rfrVar:"AV19Title"});this.Initialize();this.setComponent({id:"WCMESSAGES",GXClass:null,Prefix:"W0080",lvl:1})});gx.wi(function(){gx.createParentObj(this.gam_usercustomattributes)})