gx.evt.autoSkip=!1;gx.define("wwtregistropedido",!1,function(){var n,t;this.ServerClass="wwtregistropedido";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwtregistropedido.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="ProjetoFrotas";this.SetStandaloneVars=function(){this.AV15IdEmpresa=gx.fn.getIntegerValue("vIDEMPRESA",",")};this.Valid_Empresaid=function(){var n=gx.fn.currentGridRowImpl(27);return this.validCliEvt("Valid_Empresaid",27,function(){try{if(gx.fn.currentGridRowImpl(27)===0)return!0;var n=gx.util.balloon.getNew("EMPRESAID",gx.fn.currentGridRowImpl(27));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110l2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e150l2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e160l2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,22,23,24,25,26,28,29,30,31,32,33,34,35,36,37,38,39];this.GXLastCtrlId=39;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",27,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwtregistropedido",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(1,28,"EMPRESAID","Empresa Id","","EmpresaId","int",0,"px",12,12,"end",null,[],1,"EmpresaId",!1,0,!1,!1,"Attribute",0,"column column-optional");t.addSingleLineEdit(16,29,"REGISTROPEDIDOID","Id","","RegistroPedidoId","int",0,"px",12,12,"end",null,[],16,"RegistroPedidoId",!0,0,!1,!1,"Attribute",0,"column column-optional");t.addSingleLineEdit(2,30,"EMPRESANOME","Empresa","","EmpresaNome","svchar",0,"px",30,30,"start",null,[],2,"EmpresaNome",!0,0,!1,!1,"Attribute",0,"column column-optional");t.addSingleLineEdit(11,31,"VEICULOMARCA","Veículo","","VeiculoMarca","svchar",0,"px",20,20,"start",null,[],11,"VeiculoMarca",!0,0,!1,!1,"Attribute",0,"column column-optional");t.addComboBox(5,32,"CLIENTEID","Cliente Id","ClienteId","int",null,0,!0,!1,0,"px","column column-optional");t.addSingleLineEdit(17,33,"DESTINO","Destino","","Destino","char",0,"px",20,20,"start",null,[],17,"Destino",!0,0,!1,!1,"attribute-description",0,"column");t.addSingleLineEdit(24,34,"DATARETIRADA","Data da Retirada","","DataRetirada","date",0,"px",10,10,"end",null,[],24,"DataRetirada",!0,0,!1,!1,"Attribute",0,"column column-optional");t.addSingleLineEdit(25,35,"DATARETORNO","Data do Retorno","","DataRetorno","date",0,"px",10,10,"end",null,[],25,"DataRetorno",!0,0,!1,!1,"Attribute",0,"column column-optional");t.addSingleLineEdit("Update",36,"vUPDATE","","","Update","char",0,"px",20,20,"start",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");t.addSingleLineEdit("Delete",37,"vDELETE","","","Delete","char",0,"px",20,20,"start",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"GRIDCELL",grid:0};n[6]={id:6,fld:"GRIDTABLE",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLETOP",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"BTNINSERT",grid:0,evt:"e110l2_client"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vDESTINO",fmt:0,gxz:"ZV11Destino",gxold:"OV11Destino",gxvar:"AV11Destino",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11Destino=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11Destino=n)},v2c:function(){gx.fn.setControlValue("vDESTINO",gx.O.AV11Destino,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11Destino=this.val())},val:function(){return gx.fn.getControlValue("vDESTINO")},nac:gx.falseFn};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"GRIDCONTAINER",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[28]={id:28,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:this.Valid_Empresaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPRESAID",fmt:0,gxz:"Z1EmpresaId",gxold:"O1EmpresaId",gxvar:"A1EmpresaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EmpresaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EmpresaId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("EMPRESAID",n||gx.fn.currentGridRowImpl(27),gx.O.A1EmpresaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EmpresaId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("EMPRESAID",n||gx.fn.currentGridRowImpl(27),",")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGISTROPEDIDOID",fmt:0,gxz:"Z16RegistroPedidoId",gxold:"O16RegistroPedidoId",gxvar:"A16RegistroPedidoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A16RegistroPedidoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z16RegistroPedidoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("REGISTROPEDIDOID",n||gx.fn.currentGridRowImpl(27),gx.O.A16RegistroPedidoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16RegistroPedidoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("REGISTROPEDIDOID",n||gx.fn.currentGridRowImpl(27),",")},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"svchar",len:30,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPRESANOME",fmt:0,gxz:"Z2EmpresaNome",gxold:"O2EmpresaNome",gxvar:"A2EmpresaNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2EmpresaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EmpresaNome=n)},v2c:function(n){gx.fn.setGridControlValue("EMPRESANOME",n||gx.fn.currentGridRowImpl(27),gx.O.A2EmpresaNome,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2EmpresaNome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("EMPRESANOME",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"svchar",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"VEICULOMARCA",fmt:0,gxz:"Z11VeiculoMarca",gxold:"O11VeiculoMarca",gxvar:"A11VeiculoMarca",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A11VeiculoMarca=n)},v2z:function(n){n!==undefined&&(gx.O.Z11VeiculoMarca=n)},v2c:function(n){gx.fn.setGridControlValue("VEICULOMARCA",n||gx.fn.currentGridRowImpl(27),gx.O.A11VeiculoMarca,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A11VeiculoMarca=this.val(n))},val:function(n){return gx.fn.getGridControlValue("VEICULOMARCA",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEID",fmt:0,gxz:"Z5ClienteId",gxold:"O5ClienteId",gxvar:"A5ClienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A5ClienteId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5ClienteId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridComboBoxValue("CLIENTEID",n||gx.fn.currentGridRowImpl(27),gx.O.A5ClienteId);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5ClienteId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CLIENTEID",n||gx.fn.currentGridRowImpl(27),",")},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DESTINO",fmt:0,gxz:"Z17Destino",gxold:"O17Destino",gxvar:"A17Destino",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A17Destino=n)},v2z:function(n){n!==undefined&&(gx.O.Z17Destino=n)},v2c:function(n){gx.fn.setGridControlValue("DESTINO",n||gx.fn.currentGridRowImpl(27),gx.O.A17Destino,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A17Destino=this.val(n))},val:function(n){return gx.fn.getGridControlValue("DESTINO",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"date",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DATARETIRADA",fmt:0,gxz:"Z24DataRetirada",gxold:"O24DataRetirada",gxvar:"A24DataRetirada",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A24DataRetirada=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z24DataRetirada=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("DATARETIRADA",n||gx.fn.currentGridRowImpl(27),gx.O.A24DataRetirada,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A24DataRetirada=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("DATARETIRADA",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[35]={id:35,lvl:2,type:"date",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DATARETORNO",fmt:0,gxz:"Z25DataRetorno",gxold:"O25DataRetorno",gxvar:"A25DataRetorno",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A25DataRetorno=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z25DataRetorno=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("DATARETORNO",n||gx.fn.currentGridRowImpl(27),gx.O.A25DataRetorno,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A25DataRetorno=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("DATARETORNO",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(27),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};this.AV11Destino="";this.ZV11Destino="";this.OV11Destino="";this.Z1EmpresaId=0;this.O1EmpresaId=0;this.Z16RegistroPedidoId=0;this.O16RegistroPedidoId=0;this.Z2EmpresaNome="";this.O2EmpresaNome="";this.Z11VeiculoMarca="";this.O11VeiculoMarca="";this.Z5ClienteId=0;this.O5ClienteId=0;this.Z17Destino="";this.O17Destino="";this.Z24DataRetirada=gx.date.nullDate();this.O24DataRetirada=gx.date.nullDate();this.Z25DataRetorno=gx.date.nullDate();this.O25DataRetorno=gx.date.nullDate();this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11Destino="";this.A10VeiculoId=0;this.A1EmpresaId=0;this.A16RegistroPedidoId=0;this.A2EmpresaNome="";this.A11VeiculoMarca="";this.A5ClienteId=0;this.A17Destino="";this.A24DataRetirada=gx.date.nullDate();this.A25DataRetorno=gx.date.nullDate();this.AV12Update="";this.AV13Delete="";this.AV15IdEmpresa=0;this.Events={e110l2_client:["'DOINSERT'",!0],e150l2_client:["ENTER",!0],e160l2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV11Destino",fld:"vDESTINO"},{av:"AV12Update",fld:"vUPDATE"},{av:"AV13Delete",fld:"vDELETE"},{av:"AV15IdEmpresa",fld:"vIDEMPRESA",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"A16RegistroPedidoId",fld:"REGISTROPEDIDOID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{av:"gx.fn.getCtrlProperty('vUPDATE','Link')",ctrl:"vUPDATE",prop:"Link"},{av:"gx.fn.getCtrlProperty('vDELETE','Link')",ctrl:"vDELETE",prop:"Link"},{av:"gx.fn.getCtrlProperty('EMPRESANOME','Link')",ctrl:"EMPRESANOME",prop:"Link"},{av:"gx.fn.getCtrlProperty('DESTINO','Link')",ctrl:"DESTINO",prop:"Link"},{ctrl:"COMPONENT1"}]];this.EvtParms["'DOINSERT'"]=[[{av:"AV15IdEmpresa",fld:"vIDEMPRESA",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"A16RegistroPedidoId",fld:"REGISTROPEDIDOID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV11Destino",fld:"vDESTINO"},{av:"AV15IdEmpresa",fld:"vIDEMPRESA",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV12Update",fld:"vUPDATE"},{av:"AV13Delete",fld:"vDELETE"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV11Destino",fld:"vDESTINO"},{av:"AV15IdEmpresa",fld:"vIDEMPRESA",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV12Update",fld:"vUPDATE"},{av:"AV13Delete",fld:"vDELETE"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV11Destino",fld:"vDESTINO"},{av:"AV15IdEmpresa",fld:"vIDEMPRESA",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV12Update",fld:"vUPDATE"},{av:"AV13Delete",fld:"vDELETE"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{av:"",ctrl:"GRID",prop:"Rows"},{av:"AV11Destino",fld:"vDESTINO"},{av:"AV15IdEmpresa",fld:"vIDEMPRESA",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV12Update",fld:"vUPDATE"},{av:"AV13Delete",fld:"vDELETE"}],[]];this.EvtParms.VALID_EMPRESAID=[[],[]];this.setVCMap("AV15IdEmpresa","vIDEMPRESA",0,"int",12,0);this.setVCMap("AV15IdEmpresa","vIDEMPRESA",0,"int",12,0);this.setVCMap("AV15IdEmpresa","vIDEMPRESA",0,"int",12,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[18]);t.addRefreshingVar({rfrVar:"AV15IdEmpresa"});t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[18]);t.addRefreshingParm({rfrVar:"AV15IdEmpresa"});t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize();this.setComponent({id:"COMPONENT1",GXClass:"wpdashboard",Prefix:"W0040",lvl:1})});gx.wi(function(){gx.createParentObj(this.wwtregistropedido)})