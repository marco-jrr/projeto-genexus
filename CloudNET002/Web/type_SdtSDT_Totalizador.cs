/*
				   File: type_SdtSDT_Totalizador
			Description: SDT_Totalizador
				 Author: Nemo 🐠 for C# (.NET) version 18.0.9.182098
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDT_Totalizador")]
	[XmlType(TypeName="SDT_Totalizador" , Namespace="ProjetoFrotas" )]
	[Serializable]
	public class SdtSDT_Totalizador : GxUserType
	{
		public SdtSDT_Totalizador( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_Totalizador(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("QtdUsuarios", gxTpr_Qtdusuarios, false);


			AddObjectProperty("QtdRegistroHoje", gxTpr_Qtdregistrohoje, false);


			AddObjectProperty("QtdVeiculos", gxTpr_Qtdveiculos, false);


			AddObjectProperty("QtdVeiculosEmUso", gxTpr_Qtdveiculosemuso, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="QtdUsuarios")]
		[XmlElement(ElementName="QtdUsuarios")]
		public short gxTpr_Qtdusuarios
		{
			get {
				return gxTv_SdtSDT_Totalizador_Qtdusuarios; 
			}
			set {
				gxTv_SdtSDT_Totalizador_Qtdusuarios = value;
				SetDirty("Qtdusuarios");
			}
		}




		[SoapElement(ElementName="QtdRegistroHoje")]
		[XmlElement(ElementName="QtdRegistroHoje")]
		public short gxTpr_Qtdregistrohoje
		{
			get {
				return gxTv_SdtSDT_Totalizador_Qtdregistrohoje; 
			}
			set {
				gxTv_SdtSDT_Totalizador_Qtdregistrohoje = value;
				SetDirty("Qtdregistrohoje");
			}
		}




		[SoapElement(ElementName="QtdVeiculos")]
		[XmlElement(ElementName="QtdVeiculos")]
		public short gxTpr_Qtdveiculos
		{
			get {
				return gxTv_SdtSDT_Totalizador_Qtdveiculos; 
			}
			set {
				gxTv_SdtSDT_Totalizador_Qtdveiculos = value;
				SetDirty("Qtdveiculos");
			}
		}




		[SoapElement(ElementName="QtdVeiculosEmUso")]
		[XmlElement(ElementName="QtdVeiculosEmUso")]
		public short gxTpr_Qtdveiculosemuso
		{
			get {
				return gxTv_SdtSDT_Totalizador_Qtdveiculosemuso; 
			}
			set {
				gxTv_SdtSDT_Totalizador_Qtdveiculosemuso = value;
				SetDirty("Qtdveiculosemuso");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSDT_Totalizador_Qtdusuarios;
		 

		protected short gxTv_SdtSDT_Totalizador_Qtdregistrohoje;
		 

		protected short gxTv_SdtSDT_Totalizador_Qtdveiculos;
		 

		protected short gxTv_SdtSDT_Totalizador_Qtdveiculosemuso;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Totalizador", Namespace="ProjetoFrotas")]
	public class SdtSDT_Totalizador_RESTInterface : GxGenericCollectionItem<SdtSDT_Totalizador>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Totalizador_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Totalizador_RESTInterface( SdtSDT_Totalizador psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="QtdUsuarios", Order=0)]
		public short gxTpr_Qtdusuarios
		{
			get { 
				return sdt.gxTpr_Qtdusuarios;

			}
			set { 
				sdt.gxTpr_Qtdusuarios = value;
			}
		}

		[DataMember(Name="QtdRegistroHoje", Order=1)]
		public short gxTpr_Qtdregistrohoje
		{
			get { 
				return sdt.gxTpr_Qtdregistrohoje;

			}
			set { 
				sdt.gxTpr_Qtdregistrohoje = value;
			}
		}

		[DataMember(Name="QtdVeiculos", Order=2)]
		public short gxTpr_Qtdveiculos
		{
			get { 
				return sdt.gxTpr_Qtdveiculos;

			}
			set { 
				sdt.gxTpr_Qtdveiculos = value;
			}
		}

		[DataMember(Name="QtdVeiculosEmUso", Order=3)]
		public short gxTpr_Qtdveiculosemuso
		{
			get { 
				return sdt.gxTpr_Qtdveiculosemuso;

			}
			set { 
				sdt.gxTpr_Qtdveiculosemuso = value;
			}
		}


		#endregion

		public SdtSDT_Totalizador sdt
		{
			get { 
				return (SdtSDT_Totalizador)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtSDT_Totalizador() ;
			}
		}
	}
	#endregion
}