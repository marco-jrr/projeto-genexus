gx.evt.autoSkip=!1;gx.define("tusuariogeneral",!0,function(n){this.ServerClass="tusuariogeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="tusuariogeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="ProjetoFrotas";this.SetStandaloneVars=function(){};this.Valid_Empresaid=function(){return this.validCliEvt("Valid_Empresaid",0,function(){try{var n=gx.util.balloon.getNew("EMPRESAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Usuarioid=function(){return this.validCliEvt("Valid_Usuarioid",0,function(){try{var n=gx.util.balloon.getNew("USUARIOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110j1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("tusuario.aspx",["UPD",this.A1EmpresaId,this.A20UsuarioId],null,["Mode","EmpresaId","UsuarioId"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e120j1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("tusuario.aspx",["DLT",this.A1EmpresaId,this.A20UsuarioId],null,["Mode","EmpresaId","UsuarioId"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e150j2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160j2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42];this.GXLastCtrlId=42;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e110j1_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e120j1_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Empresaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPRESAID",fmt:0,gxz:"Z1EmpresaId",gxold:"O1EmpresaId",gxvar:"A1EmpresaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1EmpresaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EmpresaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("EMPRESAID",gx.O.A1EmpresaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1EmpresaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("EMPRESAID",",")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Usuarioid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOID",fmt:0,gxz:"Z20UsuarioId",gxold:"O20UsuarioId",gxvar:"A20UsuarioId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A20UsuarioId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z20UsuarioId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("USUARIOID",gx.O.A20UsuarioId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A20UsuarioId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("USUARIOID",",")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIONOME",fmt:0,gxz:"Z21UsuarioNome",gxold:"O21UsuarioNome",gxvar:"A21UsuarioNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A21UsuarioNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z21UsuarioNome=n)},v2c:function(){gx.fn.setControlValue("USUARIONOME",gx.O.A21UsuarioNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A21UsuarioNome=this.val())},val:function(){return gx.fn.getControlValue("USUARIONOME")},nac:gx.falseFn};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOEMAIL",fmt:0,gxz:"Z22UsuarioEmail",gxold:"O22UsuarioEmail",gxvar:"A22UsuarioEmail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A22UsuarioEmail=n)},v2z:function(n){n!==undefined&&(gx.O.Z22UsuarioEmail=n)},v2c:function(){gx.fn.setControlValue("USUARIOEMAIL",gx.O.A22UsuarioEmail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A22UsuarioEmail=this.val())},val:function(){return gx.fn.getControlValue("USUARIOEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){gx.fn.setCtrlProperty("USUARIOEMAIL","Link",gx.fn.getCtrlProperty("USUARIOEMAIL","Enabled")?"":"mailto:"+this.A22UsuarioEmail)});t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"svchar",len:30,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPRESANOME",fmt:0,gxz:"Z2EmpresaNome",gxold:"O2EmpresaNome",gxvar:"A2EmpresaNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2EmpresaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EmpresaNome=n)},v2c:function(){gx.fn.setControlValue("EMPRESANOME",gx.O.A2EmpresaNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2EmpresaNome=this.val())},val:function(){return gx.fn.getControlValue("EMPRESANOME")},nac:gx.falseFn};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"USUARIOSENHA",fmt:0,gxz:"Z23UsuarioSenha",gxold:"O23UsuarioSenha",gxvar:"A23UsuarioSenha",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A23UsuarioSenha=n)},v2z:function(n){n!==undefined&&(gx.O.Z23UsuarioSenha=n)},v2c:function(){gx.fn.setControlValue("USUARIOSENHA",gx.O.A23UsuarioSenha,0)},c2v:function(){this.val()!==undefined&&(gx.O.A23UsuarioSenha=this.val())},val:function(){return gx.fn.getControlValue("USUARIOSENHA")},nac:gx.falseFn};this.A1EmpresaId=0;this.Z1EmpresaId=0;this.O1EmpresaId=0;this.A20UsuarioId=0;this.Z20UsuarioId=0;this.O20UsuarioId=0;this.A21UsuarioNome="";this.Z21UsuarioNome="";this.O21UsuarioNome="";this.A22UsuarioEmail="";this.Z22UsuarioEmail="";this.O22UsuarioEmail="";this.A2EmpresaNome="";this.Z2EmpresaNome="";this.O2EmpresaNome="";this.A23UsuarioSenha="";this.Z23UsuarioSenha="";this.O23UsuarioSenha="";this.A1EmpresaId=0;this.A20UsuarioId=0;this.A21UsuarioNome="";this.A22UsuarioEmail="";this.A2EmpresaNome="";this.A23UsuarioSenha="";this.Events={e150j2_client:["ENTER",!0],e160j2_client:["CANCEL",!0],e110j1_client:["'DOUPDATE'",!1],e120j1_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"A20UsuarioId",fld:"USUARIOID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"A20UsuarioId",fld:"USUARIOID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A1EmpresaId",fld:"EMPRESAID",pic:"ZZZZZZZZZZZ9"},{av:"A20UsuarioId",fld:"USUARIOID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_EMPRESAID=[[],[]];this.EvtParms.VALID_USUARIOID=[[],[]];this.Initialize()})