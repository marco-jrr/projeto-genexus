gx.evt.autoSkip=!1;gx.define("tempresatclientewc",!0,function(n){var t,i;this.ServerClass="tempresatclientewc";this.PackageName="GeneXus.Programs";this.ServerFullClass="tempresatclientewc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="ProjetoFrotas";this.SetStandaloneVars=function(){this.AV6EmpresaId=gx.fn.getIntegerValue("vEMPRESAID",",")};this.e110e2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e140e2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e150e2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20,21,23,24,25,26,27,28,29,30,31,32,33];this.GXLastCtrlId=33;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",22,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"tempresatclientewc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(5,23,"CLIENTEID","Id","","ClienteId","int",0,"px",12,12,"end",null,[],5,"ClienteId",!0,0,!1,!1,"Attribute",0,"column column-optional");i.addSingleLineEdit(6,24,"CLIENTENOME","Nome","","ClienteNome","svchar",0,"px",40,40,"start",null,[],6,"ClienteNome",!0,0,!1,!1,"attribute-description",0,"column");i.addSingleLineEdit(7,25,"CLIENTECPF","CPF","","ClienteCPF","int",0,"px",11,11,"end",null,[],7,"ClienteCPF",!0,0,!1,!1,"Attribute",0,"column column-optional");i.addSingleLineEdit(8,26,"CLIENTEEMAIL","Email","","ClienteEmail","svchar",0,"px",100,80,"start",null,[],8,"ClienteEmail",!0,0,!1,!1,"Attribute",0,"column column-optional");i.addSingleLineEdit(9,27,"CLIENTETELEFONE","Telefone","","ClienteTelefone","char",0,"px",20,20,"start",null,[],9,"ClienteTelefone",!0,0,!1,!1,"Attribute",0,"column column-optional");i.addSingleLineEdit("Update",28,"vUPDATE","","","Update","char",0,"px",20,20,"start",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");i.addSingleLineEdit("Delete",29,"vDELETE","","","Delete","char",0,"px",20,20,"start",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLETOP",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e110e2_client"};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"GRIDCONTAINER",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[23]={id:23,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEID",fmt:0,gxz:"Z5ClienteId",gxold:"O5ClienteId",gxvar:"A5ClienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A5ClienteId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5ClienteId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CLIENTEID",n||gx.fn.currentGridRowImpl(22),gx.O.A5ClienteId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5ClienteId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CLIENTEID",n||gx.fn.currentGridRowImpl(22),",")},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTENOME",fmt:0,gxz:"Z6ClienteNome",gxold:"O6ClienteNome",gxvar:"A6ClienteNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A6ClienteNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z6ClienteNome=n)},v2c:function(n){gx.fn.setGridControlValue("CLIENTENOME",n||gx.fn.currentGridRowImpl(22),gx.O.A6ClienteNome,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6ClienteNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CLIENTENOME",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"int",len:11,dec:0,sign:!1,pic:"ZZZZZZZZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTECPF",fmt:0,gxz:"Z7ClienteCPF",gxold:"O7ClienteCPF",gxvar:"A7ClienteCPF",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7ClienteCPF=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7ClienteCPF=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CLIENTECPF",n||gx.fn.currentGridRowImpl(22),gx.O.A7ClienteCPF,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7ClienteCPF=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CLIENTECPF",n||gx.fn.currentGridRowImpl(22),",")},nac:gx.falseFn};t[26]={id:26,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEEMAIL",fmt:0,gxz:"Z8ClienteEmail",gxold:"O8ClienteEmail",gxvar:"A8ClienteEmail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"email",v2v:function(n){n!==undefined&&(gx.O.A8ClienteEmail=n)},v2z:function(n){n!==undefined&&(gx.O.Z8ClienteEmail=n)},v2c:function(n){gx.fn.setGridControlValue("CLIENTEEMAIL",n||gx.fn.currentGridRowImpl(22),gx.O.A8ClienteEmail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8ClienteEmail=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CLIENTEEMAIL",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTETELEFONE",fmt:0,gxz:"Z9ClienteTelefone",gxold:"O9ClienteTelefone",gxvar:"A9ClienteTelefone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"tel",v2v:function(n){n!==undefined&&(gx.O.A9ClienteTelefone=n)},v2z:function(n){n!==undefined&&(gx.O.Z9ClienteTelefone=n)},v2c:function(n){gx.fn.setGridControlValue("CLIENTETELEFONE",n||gx.fn.currentGridRowImpl(22),gx.O.A9ClienteTelefone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A9ClienteTelefone=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CLIENTETELEFONE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[28]={id:28,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV13Update",gxold:"OV13Update",gxvar:"AV13Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22),gx.O.AV13Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[29]={id:29,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV14Delete",gxold:"OV14Delete",gxvar:"AV14Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22),gx.O.AV14Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPRESAID",fmt:0,gxz:"Z1EmpresaId",gxold:"O1EmpresaId",gxvar:"A1EmpresaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1EmpresaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EmpresaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("EMPRESAID",gx.O.A1EmpresaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1EmpresaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("EMPRESAID",",")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});this.Z5ClienteId=0;this.O5ClienteId=0;this.Z6ClienteNome="";this.O6ClienteNome="";this.Z7ClienteCPF=0;this.O7ClienteCPF=0;this.Z8ClienteEmail="";this.O8ClienteEmail="";this.Z9ClienteTelefone="";this.O9ClienteTelefone="";this.ZV13Update="";this.OV13Update="";this.ZV14Delete="";this.OV14Delete="";this.A1EmpresaId=0;this.Z1EmpresaId=0;this.O1EmpresaId=0;this.A1EmpresaId=0;this.AV6EmpresaId=0;this.A5ClienteId=0;this.A6ClienteNome="";this.A7ClienteCPF=0;this.A8ClienteEmail="";this.A9ClienteTelefone="";this.AV13Update="";this.AV14Delete="";this.Events={e110e2_client:["'DOINSERT'",!0],e140e2_client:["ENTER",!0],e150e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV6EmpresaId",fld:"vEMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"AV13Update",fld:"vUPDATE"},{av:"AV14Delete",fld:"vDELETE"},{av:"sPrefix"},{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"AV6EmpresaId",fld:"vEMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"A5ClienteId",fld:"CLIENTEID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"}],[{av:"gx.fn.getCtrlProperty('vUPDATE','Link')",ctrl:"vUPDATE",prop:"Link"},{av:"gx.fn.getCtrlProperty('vDELETE','Link')",ctrl:"vDELETE",prop:"Link"},{av:"gx.fn.getCtrlProperty('CLIENTENOME','Link')",ctrl:"CLIENTENOME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"AV6EmpresaId",fld:"vEMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"A5ClienteId",fld:"CLIENTEID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV6EmpresaId",fld:"vEMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"AV13Update",fld:"vUPDATE"},{av:"AV14Delete",fld:"vDELETE"},{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV6EmpresaId",fld:"vEMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"AV13Update",fld:"vUPDATE"},{av:"AV14Delete",fld:"vDELETE"},{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV6EmpresaId",fld:"vEMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"AV13Update",fld:"vUPDATE"},{av:"AV14Delete",fld:"vDELETE"},{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV6EmpresaId",fld:"vEMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"AV13Update",fld:"vUPDATE"},{av:"AV14Delete",fld:"vDELETE"},{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"sPrefix"}],[]];this.setVCMap("AV6EmpresaId","vEMPRESAID",0,"int",12,0);this.setVCMap("AV6EmpresaId","vEMPRESAID",0,"int",12,0);this.setVCMap("AV6EmpresaId","vEMPRESAID",0,"int",12,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6EmpresaId"});i.addRefreshingVar({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingVar(this.GXValidFnc[33]);i.addRefreshingParm({rfrVar:"AV6EmpresaId"});i.addRefreshingParm({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm(this.GXValidFnc[33]);this.Initialize()})