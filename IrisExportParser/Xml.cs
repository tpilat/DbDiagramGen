namespace IrisExportParser
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class Export
	{

		private object[] itemsField;

		private ExportChecksum checksumField;

		private string generatorField;

		private sbyte versionField;

		private bool versionFieldSpecified;

		private string zvField;

		private string tsField;

		private System.Xml.XmlAttribute[] anyAttrField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyElementAttribute()]
		[System.Xml.Serialization.XmlElementAttribute("CSP", typeof(ExportCSP))]
		[System.Xml.Serialization.XmlElementAttribute("CSPBase64", typeof(ExportCSPBase64))]
		[System.Xml.Serialization.XmlElementAttribute("Class", typeof(Class))]
		[System.Xml.Serialization.XmlElementAttribute("Document", typeof(ExportDocument))]
		[System.Xml.Serialization.XmlElementAttribute("Global", typeof(ExportGlobal))]
		[System.Xml.Serialization.XmlElementAttribute("OBJ", typeof(ExportOBJ))]
		[System.Xml.Serialization.XmlElementAttribute("Package", typeof(ExportPackage))]
		[System.Xml.Serialization.XmlElementAttribute("Project", typeof(ExportProject))]
		[System.Xml.Serialization.XmlElementAttribute("Routine", typeof(ExportRoutine))]
		[System.Xml.Serialization.XmlElementAttribute("RoutineBase64", typeof(ExportRoutineBase64))]
		[System.Xml.Serialization.XmlElementAttribute("RoutineWideBase64", typeof(ExportRoutineWideBase64))]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		public ExportChecksum Checksum
		{
			get
			{
				return this.checksumField;
			}
			set
			{
				this.checksumField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string generator
		{
			get
			{
				return this.generatorField;
			}
			set
			{
				this.generatorField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public sbyte version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool versionSpecified
		{
			get
			{
				return this.versionFieldSpecified;
			}
			set
			{
				this.versionFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string zv
		{
			get
			{
				return this.zvField;
			}
			set
			{
				this.zvField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ts
		{
			get
			{
				return this.tsField;
			}
			set
			{
				this.tsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportCSP
	{

		private string nameField;

		private string applicationField;

		private bool defaultField;

		private bool defaultFieldSpecified;

		private System.Xml.XmlAttribute[] anyAttrField;

		private string valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string application
		{
			get
			{
				return this.applicationField;
			}
			set
			{
				this.applicationField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public bool @default
		{
			get
			{
				return this.defaultField;
			}
			set
			{
				this.defaultField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool defaultSpecified
		{
			get
			{
				return this.defaultFieldSpecified;
			}
			set
			{
				this.defaultFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportCSPBase64
	{

		private string nameField;

		private string applicationField;

		private bool defaultField;

		private bool defaultFieldSpecified;

		private System.Xml.XmlAttribute[] anyAttrField;

		private byte[] valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string application
		{
			get
			{
				return this.applicationField;
			}
			set
			{
				this.applicationField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public bool @default
		{
			get
			{
				return this.defaultField;
			}
			set
			{
				this.defaultField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool defaultSpecified
		{
			get
			{
				return this.defaultFieldSpecified;
			}
			set
			{
				this.defaultFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
		public byte[] Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class Class
	{

		private object[] itemsField;

		private ItemsChoiceType19[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Abstract", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ClassDefinitionError", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ClassType", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ClientDataType", typeof(ClassClientDataType))]
		[System.Xml.Serialization.XmlElementAttribute("ClientName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("CompileAfter", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ConstraintClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Copyright", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("DdlAllowed", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("DependsOn", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Deployed", typeof(string), DataType = "integer")]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Dynamic", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("EmbeddedClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Final", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ForeignKey", typeof(ClassForeignKey))]
		[System.Xml.Serialization.XmlElementAttribute("GeneratedBy", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Hidden", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Import", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("IncludeCode", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("IncludeGenerator", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Index", typeof(ClassIndex))]
		[System.Xml.Serialization.XmlElementAttribute("IndexClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Inheritance", typeof(ClassInheritance))]
		[System.Xml.Serialization.XmlElementAttribute("Language", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("LegacyInstanceContext", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("MemberSuper", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Method", typeof(ClassMethod))]
		[System.Xml.Serialization.XmlElementAttribute("Modified", typeof(ClassModified))]
		[System.Xml.Serialization.XmlElementAttribute("NoContext", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("NoExtent", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("OdbcType", typeof(ClassOdbcType))]
		[System.Xml.Serialization.XmlElementAttribute("Owner", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Parameter", typeof(ClassParameter))]
		[System.Xml.Serialization.XmlElementAttribute("ProcedureBlock", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Projection", typeof(ClassProjection))]
		[System.Xml.Serialization.XmlElementAttribute("ProjectionClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Property", typeof(ClassProperty))]
		[System.Xml.Serialization.XmlElementAttribute("PropertyClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Query", typeof(ClassQuery))]
		[System.Xml.Serialization.XmlElementAttribute("QueryClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ServerOnly", typeof(ClassServerOnly))]
		[System.Xml.Serialization.XmlElementAttribute("Sharded", typeof(string), DataType = "integer")]
		[System.Xml.Serialization.XmlElementAttribute("SoapBindingStyle", typeof(ClassSoapBindingStyle))]
		[System.Xml.Serialization.XmlElementAttribute("SoapBodyUse", typeof(ClassSoapBodyUse))]
		[System.Xml.Serialization.XmlElementAttribute("SqlCategory", typeof(ClassSqlCategory))]
		[System.Xml.Serialization.XmlElementAttribute("SqlRoutinePrefix", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlRowIdName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlRowIdPrivate", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("SqlTableName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Storage", typeof(ClassStorage))]
		[System.Xml.Serialization.XmlElementAttribute("StorageStrategy", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Super", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("System", typeof(ClassSystem))]
		[System.Xml.Serialization.XmlElementAttribute("TimeChanged", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("TimeCreated", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Trigger", typeof(ClassTrigger))]
		[System.Xml.Serialization.XmlElementAttribute("TriggerClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("UDLText", typeof(ClassUDLText))]
		[System.Xml.Serialization.XmlElementAttribute("ViewQuery", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("XData", typeof(ClassXData))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType19[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassClientDataType
	{

		/// <remarks/>
		bigint,

		/// <remarks/>
		BIGINT,

		/// <remarks/>
		Bigint,

		/// <remarks/>
		binary,

		/// <remarks/>
		BINARY,

		/// <remarks/>
		Binary,

		/// <remarks/>
		binarystream,

		/// <remarks/>
		BINARYSTREAM,

		/// <remarks/>
		Binarystream,

		/// <remarks/>
		boolean,

		/// <remarks/>
		BOOLEAN,

		/// <remarks/>
		Boolean,

		/// <remarks/>
		characterstream,

		/// <remarks/>
		CHARACTERSTREAM,

		/// <remarks/>
		Characterstream,

		/// <remarks/>
		currency,

		/// <remarks/>
		CURRENCY,

		/// <remarks/>
		Currency,

		/// <remarks/>
		date,

		/// <remarks/>
		DATE,

		/// <remarks/>
		Date,

		/// <remarks/>
		@double,

		/// <remarks/>
		DOUBLE,

		/// <remarks/>
		Double,

		/// <remarks/>
		handle,

		/// <remarks/>
		HANDLE,

		/// <remarks/>
		Handle,

		/// <remarks/>
		integer,

		/// <remarks/>
		INTEGER,

		/// <remarks/>
		Integer,

		/// <remarks/>
		list,

		/// <remarks/>
		LIST,

		/// <remarks/>
		List,

		/// <remarks/>
		longvarchar,

		/// <remarks/>
		LONGVARCHAR,

		/// <remarks/>
		Longvarchar,

		/// <remarks/>
		numeric,

		/// <remarks/>
		NUMERIC,

		/// <remarks/>
		Numeric,

		/// <remarks/>
		status,

		/// <remarks/>
		STATUS,

		/// <remarks/>
		Status,

		/// <remarks/>
		time,

		/// <remarks/>
		TIME,

		/// <remarks/>
		Time,

		/// <remarks/>
		timestamp,

		/// <remarks/>
		TIMESTAMP,

		/// <remarks/>
		Timestamp,

		/// <remarks/>
		varchar,

		/// <remarks/>
		VARCHAR,

		/// <remarks/>
		Varchar,

		/// <remarks/>
		fdate,

		/// <remarks/>
		FDATE,

		/// <remarks/>
		Fdate,

		/// <remarks/>
		ftimestamp,

		/// <remarks/>
		FTIMESTAMP,

		/// <remarks/>
		Ftimestamp,

		/// <remarks/>
		@decimal,

		/// <remarks/>
		DECIMAL,

		/// <remarks/>
		Decimal,

		/// <remarks/>
		mvdate,

		/// <remarks/>
		MVDATE,

		/// <remarks/>
		Mvdate,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassForeignKey
	{

		private object[] itemsField;

		private ItemsChoiceType[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("NoCheck", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("OnDelete", typeof(ClassForeignKeyOnDelete))]
		[System.Xml.Serialization.XmlElementAttribute("OnUpdate", typeof(ClassForeignKeyOnUpdate))]
		[System.Xml.Serialization.XmlElementAttribute("Properties", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ReferencedClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ReferencedKey", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlName", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassForeignKeyOnDelete
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		cascade,

		/// <remarks/>
		CASCADE,

		/// <remarks/>
		Cascade,

		/// <remarks/>
		noaction,

		/// <remarks/>
		NOACTION,

		/// <remarks/>
		Noaction,

		/// <remarks/>
		setdefault,

		/// <remarks/>
		SETDEFAULT,

		/// <remarks/>
		Setdefault,

		/// <remarks/>
		setnull,

		/// <remarks/>
		SETNULL,

		/// <remarks/>
		Setnull,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassForeignKeyOnUpdate
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		cascade,

		/// <remarks/>
		CASCADE,

		/// <remarks/>
		Cascade,

		/// <remarks/>
		noaction,

		/// <remarks/>
		NOACTION,

		/// <remarks/>
		Noaction,

		/// <remarks/>
		setdefault,

		/// <remarks/>
		SETDEFAULT,

		/// <remarks/>
		Setdefault,

		/// <remarks/>
		setnull,

		/// <remarks/>
		SETNULL,

		/// <remarks/>
		Setnull,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType
	{

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Internal,

		/// <remarks/>
		NoCheck,

		/// <remarks/>
		OnDelete,

		/// <remarks/>
		OnUpdate,

		/// <remarks/>
		Properties,

		/// <remarks/>
		ReferencedClass,

		/// <remarks/>
		ReferencedKey,

		/// <remarks/>
		SqlName,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassIndex
	{

		private object[] itemsField;

		private ItemsChoiceType1[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Abstract", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Condition", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("CoshardWith", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Data", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Extent", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("IdKey", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Parameter", typeof(ClassIndexParameter))]
		[System.Xml.Serialization.XmlElementAttribute("PrimaryKey", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Properties", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ShardKey", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("SqlName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Type", typeof(ClassIndexType))]
		[System.Xml.Serialization.XmlElementAttribute("TypeClass", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Unique", typeof(bool))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType1[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassIndexParameter
	{

		private string nameField;

		private string valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassIndexType
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		bitmap,

		/// <remarks/>
		BITMAP,

		/// <remarks/>
		Bitmap,

		/// <remarks/>
		bitslice,

		/// <remarks/>
		BITSLICE,

		/// <remarks/>
		Bitslice,

		/// <remarks/>
		index,

		/// <remarks/>
		INDEX,

		/// <remarks/>
		Index,

		/// <remarks/>
		collatedkey,

		/// <remarks/>
		COLLATEDKEY,

		/// <remarks/>
		Collatedkey,

		/// <remarks/>
		key,

		/// <remarks/>
		KEY,

		/// <remarks/>
		Key,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType1
	{

		/// <remarks/>
		Abstract,

		/// <remarks/>
		Condition,

		/// <remarks/>
		CoshardWith,

		/// <remarks/>
		Data,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Extent,

		/// <remarks/>
		IdKey,

		/// <remarks/>
		Internal,

		/// <remarks/>
		Parameter,

		/// <remarks/>
		PrimaryKey,

		/// <remarks/>
		Properties,

		/// <remarks/>
		ShardKey,

		/// <remarks/>
		SqlName,

		/// <remarks/>
		Type,

		/// <remarks/>
		TypeClass,

		/// <remarks/>
		Unique,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassInheritance
	{

		/// <remarks/>
		left,

		/// <remarks/>
		LEFT,

		/// <remarks/>
		Left,

		/// <remarks/>
		right,

		/// <remarks/>
		RIGHT,

		/// <remarks/>
		Right,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassMethod
	{

		private object[] itemsField;

		private ItemsChoiceType2[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Abstract", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ClassMethod", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ClientMethod", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ClientName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("CodeMode", typeof(ClassMethodCodeMode))]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ExternalProcName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Final", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ForceGenerate", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("FormalSpec", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("GenerateAfter", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Implementation", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ImplementationBase64", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ImplementationWideBase64", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Language", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("NoContext", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("NotForProperty", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("NotInheritable", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("PlaceAfter", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Private", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ProcedureBlock", typeof(ClassMethodProcedureBlock))]
		[System.Xml.Serialization.XmlElementAttribute("PublicList", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Requires", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ReturnResultsets", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ReturnType", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ReturnTypeParams", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ServerOnly", typeof(ClassMethodServerOnly))]
		[System.Xml.Serialization.XmlElementAttribute("SoapAction", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SoapBindingStyle", typeof(ClassMethodSoapBindingStyle))]
		[System.Xml.Serialization.XmlElementAttribute("SoapBodyUse", typeof(ClassMethodSoapBodyUse))]
		[System.Xml.Serialization.XmlElementAttribute("SoapMessageName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SoapNameSpace", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SoapRequestMessage", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SoapTypeNameSpace", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlProc", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("SqlRoutine", typeof(ClassMethodSqlRoutine))]
		[System.Xml.Serialization.XmlElementAttribute("WebMethod", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ZenMethod", typeof(bool))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType2[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassMethodCodeMode
	{

		/// <remarks/>
		call,

		/// <remarks/>
		CALL,

		/// <remarks/>
		Call,

		/// <remarks/>
		code,

		/// <remarks/>
		CODE,

		/// <remarks/>
		Code,

		/// <remarks/>
		expression,

		/// <remarks/>
		EXPRESSION,

		/// <remarks/>
		Expression,

		/// <remarks/>
		generator,

		/// <remarks/>
		GENERATOR,

		/// <remarks/>
		Generator,

		/// <remarks/>
		objectgenerator,

		/// <remarks/>
		OBJECTGENERATOR,

		/// <remarks/>
		Objectgenerator,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassMethodProcedureBlock
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("0")]
		Item0,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("1")]
		Item1,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassMethodServerOnly
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("0")]
		Item0,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("1")]
		Item1,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassMethodSoapBindingStyle
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		document,

		/// <remarks/>
		DOCUMENT,

		/// <remarks/>
		Document,

		/// <remarks/>
		rpc,

		/// <remarks/>
		RPC,

		/// <remarks/>
		Rpc,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassMethodSoapBodyUse
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		literal,

		/// <remarks/>
		LITERAL,

		/// <remarks/>
		Literal,

		/// <remarks/>
		encoded,

		/// <remarks/>
		ENCODED,

		/// <remarks/>
		Encoded,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassMethodSqlRoutine
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		procedure,

		/// <remarks/>
		PROCEDURE,

		/// <remarks/>
		Procedure,

		/// <remarks/>
		function,

		/// <remarks/>
		FUNCTION,

		/// <remarks/>
		Function,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType2
	{

		/// <remarks/>
		Abstract,

		/// <remarks/>
		ClassMethod,

		/// <remarks/>
		ClientMethod,

		/// <remarks/>
		ClientName,

		/// <remarks/>
		CodeMode,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		ExternalProcName,

		/// <remarks/>
		Final,

		/// <remarks/>
		ForceGenerate,

		/// <remarks/>
		FormalSpec,

		/// <remarks/>
		GenerateAfter,

		/// <remarks/>
		Implementation,

		/// <remarks/>
		ImplementationBase64,

		/// <remarks/>
		ImplementationWideBase64,

		/// <remarks/>
		Internal,

		/// <remarks/>
		Language,

		/// <remarks/>
		NoContext,

		/// <remarks/>
		NotForProperty,

		/// <remarks/>
		NotInheritable,

		/// <remarks/>
		PlaceAfter,

		/// <remarks/>
		Private,

		/// <remarks/>
		ProcedureBlock,

		/// <remarks/>
		PublicList,

		/// <remarks/>
		Requires,

		/// <remarks/>
		ReturnResultsets,

		/// <remarks/>
		ReturnType,

		/// <remarks/>
		ReturnTypeParams,

		/// <remarks/>
		ServerOnly,

		/// <remarks/>
		SoapAction,

		/// <remarks/>
		SoapBindingStyle,

		/// <remarks/>
		SoapBodyUse,

		/// <remarks/>
		SoapMessageName,

		/// <remarks/>
		SoapNameSpace,

		/// <remarks/>
		SoapRequestMessage,

		/// <remarks/>
		SoapTypeNameSpace,

		/// <remarks/>
		SqlName,

		/// <remarks/>
		SqlProc,

		/// <remarks/>
		SqlRoutine,

		/// <remarks/>
		WebMethod,

		/// <remarks/>
		ZenMethod,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassModified
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("0")]
		Item0,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("1")]
		Item1,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("2")]
		Item2,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("3")]
		Item3,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassOdbcType
	{

		/// <remarks/>
		bigint,

		/// <remarks/>
		BIGINT,

		/// <remarks/>
		Bigint,

		/// <remarks/>
		bit,

		/// <remarks/>
		BIT,

		/// <remarks/>
		Bit,

		/// <remarks/>
		date,

		/// <remarks/>
		DATE,

		/// <remarks/>
		Date,

		/// <remarks/>
		@double,

		/// <remarks/>
		DOUBLE,

		/// <remarks/>
		Double,

		/// <remarks/>
		guid,

		/// <remarks/>
		GUID,

		/// <remarks/>
		Guid,

		/// <remarks/>
		integer,

		/// <remarks/>
		INTEGER,

		/// <remarks/>
		Integer,

		/// <remarks/>
		longvarbinary,

		/// <remarks/>
		LONGVARBINARY,

		/// <remarks/>
		Longvarbinary,

		/// <remarks/>
		longvarchar,

		/// <remarks/>
		LONGVARCHAR,

		/// <remarks/>
		Longvarchar,

		/// <remarks/>
		numeric,

		/// <remarks/>
		NUMERIC,

		/// <remarks/>
		Numeric,

		/// <remarks/>
		posixtime,

		/// <remarks/>
		POSIXTIME,

		/// <remarks/>
		Posixtime,

		/// <remarks/>
		smallint,

		/// <remarks/>
		SMALLINT,

		/// <remarks/>
		Smallint,

		/// <remarks/>
		time,

		/// <remarks/>
		TIME,

		/// <remarks/>
		Time,

		/// <remarks/>
		timestamp,

		/// <remarks/>
		TIMESTAMP,

		/// <remarks/>
		Timestamp,

		/// <remarks/>
		tinyint,

		/// <remarks/>
		TINYINT,

		/// <remarks/>
		Tinyint,

		/// <remarks/>
		varbinary,

		/// <remarks/>
		VARBINARY,

		/// <remarks/>
		Varbinary,

		/// <remarks/>
		varchar,

		/// <remarks/>
		VARCHAR,

		/// <remarks/>
		Varchar,

		/// <remarks/>
		resultset,

		/// <remarks/>
		RESULTSET,

		/// <remarks/>
		Resultset,

		/// <remarks/>
		@struct,

		/// <remarks/>
		STRUCT,

		/// <remarks/>
		Struct,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassParameter
	{

		private object[] itemsField;

		private ItemsChoiceType3[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Abstract", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Constraint", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Default", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Encoded", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Expression", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Final", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Flags", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Type", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType3[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType3
	{

		/// <remarks/>
		Abstract,

		/// <remarks/>
		Constraint,

		/// <remarks/>
		Default,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Encoded,

		/// <remarks/>
		Expression,

		/// <remarks/>
		Final,

		/// <remarks/>
		Flags,

		/// <remarks/>
		Internal,

		/// <remarks/>
		Type,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassProjection
	{

		private object[] itemsField;

		private ItemsChoiceType4[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("NotInheritable", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Parameter", typeof(ClassProjectionParameter))]
		[System.Xml.Serialization.XmlElementAttribute("Type", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType4[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassProjectionParameter
	{

		private string nameField;

		private string valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType4
	{

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Internal,

		/// <remarks/>
		NotInheritable,

		/// <remarks/>
		Parameter,

		/// <remarks/>
		Type,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassProperty
	{

		private object[] itemsField;

		private ItemsChoiceType6[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Aliases", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Calculated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Cardinality", typeof(ClassPropertyCardinality))]
		[System.Xml.Serialization.XmlElementAttribute("ClientName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Collection", typeof(ClassPropertyCollection))]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Final", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Identity", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("InitialExpression", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Inverse", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("MultiDimensional", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("NoModBit", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("NotInheritable", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("OnDelete", typeof(ClassPropertyOnDelete))]
		[System.Xml.Serialization.XmlElementAttribute("Parameter", typeof(ClassPropertyParameter))]
		[System.Xml.Serialization.XmlElementAttribute("Private", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ReadOnly", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Relationship", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Required", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ServerOnly", typeof(ClassPropertyServerOnly))]
		[System.Xml.Serialization.XmlElementAttribute("SqlCollation", typeof(ClassPropertySqlCollation))]
		[System.Xml.Serialization.XmlElementAttribute("SqlColumnNumber", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlComputeCode", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlComputeOnChange", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlComputed", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("SqlFieldName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlListDelimiter", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlListType", typeof(ClassPropertySqlListType))]
		[System.Xml.Serialization.XmlElementAttribute("Transient", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Type", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("UDLText", typeof(ClassPropertyUDLText))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType6[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassPropertyCardinality
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		one,

		/// <remarks/>
		ONE,

		/// <remarks/>
		One,

		/// <remarks/>
		many,

		/// <remarks/>
		MANY,

		/// <remarks/>
		Many,

		/// <remarks/>
		parent,

		/// <remarks/>
		PARENT,

		/// <remarks/>
		Parent,

		/// <remarks/>
		children,

		/// <remarks/>
		CHILDREN,

		/// <remarks/>
		Children,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassPropertyCollection
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		array,

		/// <remarks/>
		ARRAY,

		/// <remarks/>
		Array,

		/// <remarks/>
		list,

		/// <remarks/>
		LIST,

		/// <remarks/>
		List,

		/// <remarks/>
		binarystream,

		/// <remarks/>
		BINARYSTREAM,

		/// <remarks/>
		Binarystream,

		/// <remarks/>
		characterstream,

		/// <remarks/>
		CHARACTERSTREAM,

		/// <remarks/>
		Characterstream,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassPropertyOnDelete
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		cascade,

		/// <remarks/>
		CASCADE,

		/// <remarks/>
		Cascade,

		/// <remarks/>
		noaction,

		/// <remarks/>
		NOACTION,

		/// <remarks/>
		Noaction,

		/// <remarks/>
		setdefault,

		/// <remarks/>
		SETDEFAULT,

		/// <remarks/>
		Setdefault,

		/// <remarks/>
		setnull,

		/// <remarks/>
		SETNULL,

		/// <remarks/>
		Setnull,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassPropertyParameter
	{

		private string nameField;

		private string valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassPropertyServerOnly
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("0")]
		Item0,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("1")]
		Item1,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassPropertySqlCollation
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		alphaup,

		/// <remarks/>
		ALPHAUP,

		/// <remarks/>
		Alphaup,

		/// <remarks/>
		plus,

		/// <remarks/>
		PLUS,

		/// <remarks/>
		Plus,

		/// <remarks/>
		minus,

		/// <remarks/>
		MINUS,

		/// <remarks/>
		Minus,

		/// <remarks/>
		space,

		/// <remarks/>
		SPACE,

		/// <remarks/>
		Space,

		/// <remarks/>
		exact,

		/// <remarks/>
		EXACT,

		/// <remarks/>
		Exact,

		/// <remarks/>
		upper,

		/// <remarks/>
		UPPER,

		/// <remarks/>
		Upper,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassPropertySqlListType
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		delimited,

		/// <remarks/>
		DELIMITED,

		/// <remarks/>
		Delimited,

		/// <remarks/>
		list,

		/// <remarks/>
		LIST,

		/// <remarks/>
		List,

		/// <remarks/>
		subnode,

		/// <remarks/>
		SUBNODE,

		/// <remarks/>
		Subnode,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassPropertyUDLText
	{

		private object[] itemsField;

		private ItemsChoiceType5[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Category", typeof(ClassPropertyUDLTextCategory))]
		[System.Xml.Serialization.XmlElementAttribute("Content", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ContentBase64", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ContentWideBase64", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Position", typeof(ClassPropertyUDLTextPosition))]
		[System.Xml.Serialization.XmlElementAttribute("TextType", typeof(string), DataType = "integer")]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType5[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassPropertyUDLTextCategory
	{

		/// <remarks/>
		comment,

		/// <remarks/>
		COMMENT,

		/// <remarks/>
		Comment,

		/// <remarks/>
		error,

		/// <remarks/>
		ERROR,

		/// <remarks/>
		Error,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassPropertyUDLTextPosition
	{

		/// <remarks/>
		body,

		/// <remarks/>
		BODY,

		/// <remarks/>
		Body,

		/// <remarks/>
		header,

		/// <remarks/>
		HEADER,

		/// <remarks/>
		Header,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType5
	{

		/// <remarks/>
		Category,

		/// <remarks/>
		Content,

		/// <remarks/>
		ContentBase64,

		/// <remarks/>
		ContentWideBase64,

		/// <remarks/>
		Position,

		/// <remarks/>
		TextType,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType6
	{

		/// <remarks/>
		Aliases,

		/// <remarks/>
		Calculated,

		/// <remarks/>
		Cardinality,

		/// <remarks/>
		ClientName,

		/// <remarks/>
		Collection,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Final,

		/// <remarks/>
		Identity,

		/// <remarks/>
		InitialExpression,

		/// <remarks/>
		Internal,

		/// <remarks/>
		Inverse,

		/// <remarks/>
		MultiDimensional,

		/// <remarks/>
		NoModBit,

		/// <remarks/>
		NotInheritable,

		/// <remarks/>
		OnDelete,

		/// <remarks/>
		Parameter,

		/// <remarks/>
		Private,

		/// <remarks/>
		ReadOnly,

		/// <remarks/>
		Relationship,

		/// <remarks/>
		Required,

		/// <remarks/>
		ServerOnly,

		/// <remarks/>
		SqlCollation,

		/// <remarks/>
		SqlColumnNumber,

		/// <remarks/>
		SqlComputeCode,

		/// <remarks/>
		SqlComputeOnChange,

		/// <remarks/>
		SqlComputed,

		/// <remarks/>
		SqlFieldName,

		/// <remarks/>
		SqlListDelimiter,

		/// <remarks/>
		SqlListType,

		/// <remarks/>
		Transient,

		/// <remarks/>
		Type,

		/// <remarks/>
		UDLText,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassQuery
	{

		private object[] itemsField;

		private ItemsChoiceType7[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ClientName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Final", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("FormalSpec", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("NotInheritable", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Parameter", typeof(ClassQueryParameter))]
		[System.Xml.Serialization.XmlElementAttribute("Private", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("SoapBindingStyle", typeof(ClassQuerySoapBindingStyle))]
		[System.Xml.Serialization.XmlElementAttribute("SoapBodyUse", typeof(ClassQuerySoapBodyUse))]
		[System.Xml.Serialization.XmlElementAttribute("SoapNameSpace", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlProc", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("SqlQuery", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlView", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("SqlViewName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Type", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("WebMethod", typeof(bool))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType7[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassQueryParameter
	{

		private string nameField;

		private string valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassQuerySoapBindingStyle
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		document,

		/// <remarks/>
		DOCUMENT,

		/// <remarks/>
		Document,

		/// <remarks/>
		rpc,

		/// <remarks/>
		RPC,

		/// <remarks/>
		Rpc,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassQuerySoapBodyUse
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		literal,

		/// <remarks/>
		LITERAL,

		/// <remarks/>
		Literal,

		/// <remarks/>
		encoded,

		/// <remarks/>
		ENCODED,

		/// <remarks/>
		Encoded,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType7
	{

		/// <remarks/>
		ClientName,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Final,

		/// <remarks/>
		FormalSpec,

		/// <remarks/>
		Internal,

		/// <remarks/>
		NotInheritable,

		/// <remarks/>
		Parameter,

		/// <remarks/>
		Private,

		/// <remarks/>
		SoapBindingStyle,

		/// <remarks/>
		SoapBodyUse,

		/// <remarks/>
		SoapNameSpace,

		/// <remarks/>
		SqlName,

		/// <remarks/>
		SqlProc,

		/// <remarks/>
		SqlQuery,

		/// <remarks/>
		SqlView,

		/// <remarks/>
		SqlViewName,

		/// <remarks/>
		Type,

		/// <remarks/>
		WebMethod,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassServerOnly
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("0")]
		Item0,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("1")]
		Item1,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassSoapBindingStyle
	{

		/// <remarks/>
		document,

		/// <remarks/>
		DOCUMENT,

		/// <remarks/>
		Document,

		/// <remarks/>
		rpc,

		/// <remarks/>
		RPC,

		/// <remarks/>
		Rpc,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassSoapBodyUse
	{

		/// <remarks/>
		literal,

		/// <remarks/>
		LITERAL,

		/// <remarks/>
		Literal,

		/// <remarks/>
		encoded,

		/// <remarks/>
		ENCODED,

		/// <remarks/>
		Encoded,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassSqlCategory
	{

		/// <remarks/>
		date,

		/// <remarks/>
		DATE,

		/// <remarks/>
		Date,

		/// <remarks/>
		@double,

		/// <remarks/>
		DOUBLE,

		/// <remarks/>
		Double,

		/// <remarks/>
		fmdate,

		/// <remarks/>
		FMDATE,

		/// <remarks/>
		Fmdate,

		/// <remarks/>
		fmtimestamp,

		/// <remarks/>
		FMTIMESTAMP,

		/// <remarks/>
		Fmtimestamp,

		/// <remarks/>
		integer,

		/// <remarks/>
		INTEGER,

		/// <remarks/>
		Integer,

		/// <remarks/>
		mvdate,

		/// <remarks/>
		MVDATE,

		/// <remarks/>
		Mvdate,

		/// <remarks/>
		name,

		/// <remarks/>
		NAME,

		/// <remarks/>
		Name,

		/// <remarks/>
		numeric,

		/// <remarks/>
		NUMERIC,

		/// <remarks/>
		Numeric,

		/// <remarks/>
		posixts,

		/// <remarks/>
		POSIXTS,

		/// <remarks/>
		Posixts,

		/// <remarks/>
		@string,

		/// <remarks/>
		STRING,

		/// <remarks/>
		String,

		/// <remarks/>
		time,

		/// <remarks/>
		TIME,

		/// <remarks/>
		Time,

		/// <remarks/>
		timestamp,

		/// <remarks/>
		TIMESTAMP,

		/// <remarks/>
		Timestamp,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorage
	{

		private object[] itemsField;

		private ItemsChoiceType15[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CounterLocation", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Data", typeof(ClassStorageData))]
		[System.Xml.Serialization.XmlElementAttribute("DataLocation", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("DefaultData", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ExtentLocation", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ExtentSize", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Final", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("IdExpression", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("IdFunction", typeof(ClassStorageIdFunction))]
		[System.Xml.Serialization.XmlElementAttribute("IdLocation", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Index", typeof(ClassStorageIndex))]
		[System.Xml.Serialization.XmlElementAttribute("IndexLocation", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Property", typeof(ClassStorageProperty))]
		[System.Xml.Serialization.XmlElementAttribute("SQLMap", typeof(ClassStorageSQLMap))]
		[System.Xml.Serialization.XmlElementAttribute("SqlChildSub", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlIdExpression", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlRowIdName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlRowIdProperty", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SqlTableNumber", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("State", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("StreamLocation", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Type", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("VersionLocation", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType15[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageData
	{

		private object[] itemsField;

		private ItemsChoiceType8[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Attribute", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Structure", typeof(ClassStorageDataStructure))]
		[System.Xml.Serialization.XmlElementAttribute("Subscript", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Value", typeof(ClassStorageDataValue))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType8[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassStorageDataStructure
	{

		/// <remarks/>
		node,

		/// <remarks/>
		NODE,

		/// <remarks/>
		Node,

		/// <remarks/>
		listnode,

		/// <remarks/>
		LISTNODE,

		/// <remarks/>
		Listnode,

		/// <remarks/>
		subnode,

		/// <remarks/>
		SUBNODE,

		/// <remarks/>
		Subnode,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageDataValue
	{

		private string[] itemsField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Value")]
		public string[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType8
	{

		/// <remarks/>
		Attribute,

		/// <remarks/>
		Structure,

		/// <remarks/>
		Subscript,

		/// <remarks/>
		Value,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassStorageIdFunction
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		increment,

		/// <remarks/>
		INCREMENT,

		/// <remarks/>
		Increment,

		/// <remarks/>
		sequence,

		/// <remarks/>
		SEQUENCE,

		/// <remarks/>
		Sequence,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageIndex
	{

		private string[] itemsField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Location")]
		public string[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageProperty
	{

		private object[] itemsField;

		private ItemsChoiceType9[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("AverageFieldSize", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("BiasQueriesAsOutlier", typeof(ClassStoragePropertyBiasQueriesAsOutlier))]
		[System.Xml.Serialization.XmlElementAttribute("ChildBlockCount", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ChildExtentSize", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("OutlierSelectivity", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Selectivity", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("StreamLocation", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType9[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassStoragePropertyBiasQueriesAsOutlier
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("0")]
		Item0,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("1")]
		Item1,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType9
	{

		/// <remarks/>
		AverageFieldSize,

		/// <remarks/>
		BiasQueriesAsOutlier,

		/// <remarks/>
		ChildBlockCount,

		/// <remarks/>
		ChildExtentSize,

		/// <remarks/>
		OutlierSelectivity,

		/// <remarks/>
		Selectivity,

		/// <remarks/>
		StreamLocation,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageSQLMap
	{

		private object[] itemsField;

		private ItemsChoiceType14[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("BlockCount", typeof(string), DataType = "integer")]
		[System.Xml.Serialization.XmlElementAttribute("Condition", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ConditionFields", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ConditionalWithHostVars", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Data", typeof(ClassStorageSQLMapData))]
		[System.Xml.Serialization.XmlElementAttribute("Global", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("PopulationPct", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("PopulationType", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("RowIdSpec", typeof(ClassStorageSQLMapRowIdSpec))]
		[System.Xml.Serialization.XmlElementAttribute("RowReference", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Structure", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Subscript", typeof(ClassStorageSQLMapSubscript))]
		[System.Xml.Serialization.XmlElementAttribute("Type", typeof(ClassStorageSQLMapType))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType14[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageSQLMapData
	{

		private string[] itemsField;

		private ItemsChoiceType10[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Delimiter", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Node", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Piece", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("RetrievalCode", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public string[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType10[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType10
	{

		/// <remarks/>
		Delimiter,

		/// <remarks/>
		Node,

		/// <remarks/>
		Piece,

		/// <remarks/>
		RetrievalCode,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageSQLMapRowIdSpec
	{

		private string[] itemsField;

		private ItemsChoiceType11[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Expression", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Field", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public string[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType11[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType11
	{

		/// <remarks/>
		Expression,

		/// <remarks/>
		Field,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageSQLMapSubscript
	{

		private object[] itemsField;

		private ItemsChoiceType13[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("AccessType", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Accessvar", typeof(ClassStorageSQLMapSubscriptAccessvar))]
		[System.Xml.Serialization.XmlElementAttribute("DataAccess", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Delimiter", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Expression", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Invalidcondition", typeof(ClassStorageSQLMapSubscriptInvalidcondition))]
		[System.Xml.Serialization.XmlElementAttribute("LoopInitValue", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("NextCode", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("NullMarker", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("StartValue", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("StopExpression", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("StopValue", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType13[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageSQLMapSubscriptAccessvar
	{

		private string[] itemsField;

		private ItemsChoiceType12[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Code", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Variable", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public string[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType12[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType12
	{

		/// <remarks/>
		Code,

		/// <remarks/>
		Variable,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassStorageSQLMapSubscriptInvalidcondition
	{

		private string[] itemsField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Expression")]
		public string[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType13
	{

		/// <remarks/>
		AccessType,

		/// <remarks/>
		Accessvar,

		/// <remarks/>
		DataAccess,

		/// <remarks/>
		Delimiter,

		/// <remarks/>
		Expression,

		/// <remarks/>
		Invalidcondition,

		/// <remarks/>
		LoopInitValue,

		/// <remarks/>
		NextCode,

		/// <remarks/>
		NullMarker,

		/// <remarks/>
		StartValue,

		/// <remarks/>
		StopExpression,

		/// <remarks/>
		StopValue,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassStorageSQLMapType
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		data,

		/// <remarks/>
		DATA,

		/// <remarks/>
		Data,

		/// <remarks/>
		index,

		/// <remarks/>
		INDEX,

		/// <remarks/>
		Index,

		/// <remarks/>
		bitmap,

		/// <remarks/>
		BITMAP,

		/// <remarks/>
		Bitmap,

		/// <remarks/>
		bitmapextent,

		/// <remarks/>
		BITMAPEXTENT,

		/// <remarks/>
		Bitmapextent,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType14
	{

		/// <remarks/>
		BlockCount,

		/// <remarks/>
		Condition,

		/// <remarks/>
		ConditionFields,

		/// <remarks/>
		ConditionalWithHostVars,

		/// <remarks/>
		Data,

		/// <remarks/>
		Global,

		/// <remarks/>
		PopulationPct,

		/// <remarks/>
		PopulationType,

		/// <remarks/>
		RowIdSpec,

		/// <remarks/>
		RowReference,

		/// <remarks/>
		Structure,

		/// <remarks/>
		Subscript,

		/// <remarks/>
		Type,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType15
	{

		/// <remarks/>
		CounterLocation,

		/// <remarks/>
		Data,

		/// <remarks/>
		DataLocation,

		/// <remarks/>
		DefaultData,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		ExtentLocation,

		/// <remarks/>
		ExtentSize,

		/// <remarks/>
		Final,

		/// <remarks/>
		IdExpression,

		/// <remarks/>
		IdFunction,

		/// <remarks/>
		IdLocation,

		/// <remarks/>
		Index,

		/// <remarks/>
		IndexLocation,

		/// <remarks/>
		Internal,

		/// <remarks/>
		Property,

		/// <remarks/>
		SQLMap,

		/// <remarks/>
		SqlChildSub,

		/// <remarks/>
		SqlIdExpression,

		/// <remarks/>
		SqlRowIdName,

		/// <remarks/>
		SqlRowIdProperty,

		/// <remarks/>
		SqlTableNumber,

		/// <remarks/>
		State,

		/// <remarks/>
		StreamLocation,

		/// <remarks/>
		Type,

		/// <remarks/>
		VersionLocation,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassSystem
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("0")]
		Item0,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("1")]
		Item1,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("2")]
		Item2,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("3")]
		Item3,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("4")]
		Item4,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassTrigger
	{

		private object[] itemsField;

		private ItemsChoiceType16[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Code", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("CodeMode", typeof(ClassTriggerCodeMode))]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Event", typeof(ClassTriggerEvent))]
		[System.Xml.Serialization.XmlElementAttribute("Final", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Foreach", typeof(ClassTriggerForeach))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Language", typeof(ClassTriggerLanguage))]
		[System.Xml.Serialization.XmlElementAttribute("NewTable", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("OldTable", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Order", typeof(string), DataType = "integer")]
		[System.Xml.Serialization.XmlElementAttribute("SqlName", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Time", typeof(ClassTriggerTime))]
		[System.Xml.Serialization.XmlElementAttribute("UpdateColumnList", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType16[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassTriggerCodeMode
	{

		/// <remarks/>
		code,

		/// <remarks/>
		CODE,

		/// <remarks/>
		Code,

		/// <remarks/>
		generator,

		/// <remarks/>
		GENERATOR,

		/// <remarks/>
		Generator,

		/// <remarks/>
		objectgenerator,

		/// <remarks/>
		OBJECTGENERATOR,

		/// <remarks/>
		Objectgenerator,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassTriggerEvent
	{

		/// <remarks/>
		insert,

		/// <remarks/>
		INSERT,

		/// <remarks/>
		Insert,

		/// <remarks/>
		update,

		/// <remarks/>
		UPDATE,

		/// <remarks/>
		Update,

		/// <remarks/>
		delete,

		/// <remarks/>
		DELETE,

		/// <remarks/>
		Delete,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("insert/update")]
		insertupdate,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("INSERT/UPDATE")]
		INSERTUPDATE,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Insert/update")]
		Insertupdate,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("insert/delete")]
		insertdelete,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("INSERT/DELETE")]
		INSERTDELETE,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Insert/delete")]
		Insertdelete,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("update/delete")]
		updatedelete,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("UPDATE/DELETE")]
		UPDATEDELETE,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Update/delete")]
		Updatedelete,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("insert/update/delete")]
		insertupdatedelete,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("INSERT/UPDATE/DELETE")]
		INSERTUPDATEDELETE,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Insert/update/delete")]
		Insertupdatedelete,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassTriggerForeach
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		row,

		/// <remarks/>
		ROW,

		/// <remarks/>
		Row,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("row/object")]
		rowobject,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("ROW/OBJECT")]
		ROWOBJECT,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Row/object")]
		Rowobject,

		/// <remarks/>
		statement,

		/// <remarks/>
		STATEMENT,

		/// <remarks/>
		Statement,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassTriggerLanguage
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,

		/// <remarks/>
		objectscript,

		/// <remarks/>
		OBJECTSCRIPT,

		/// <remarks/>
		Objectscript,

		/// <remarks/>
		tsql,

		/// <remarks/>
		TSQL,

		/// <remarks/>
		Tsql,

		/// <remarks/>
		ispl,

		/// <remarks/>
		ISPL,

		/// <remarks/>
		Ispl,

		/// <remarks/>
		cache,

		/// <remarks/>
		CACHE,

		/// <remarks/>
		Cache,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassTriggerTime
	{

		/// <remarks/>
		before,

		/// <remarks/>
		BEFORE,

		/// <remarks/>
		Before,

		/// <remarks/>
		after,

		/// <remarks/>
		AFTER,

		/// <remarks/>
		After,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType16
	{

		/// <remarks/>
		Code,

		/// <remarks/>
		CodeMode,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Event,

		/// <remarks/>
		Final,

		/// <remarks/>
		Foreach,

		/// <remarks/>
		Internal,

		/// <remarks/>
		Language,

		/// <remarks/>
		NewTable,

		/// <remarks/>
		OldTable,

		/// <remarks/>
		Order,

		/// <remarks/>
		SqlName,

		/// <remarks/>
		Time,

		/// <remarks/>
		UpdateColumnList,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassUDLText
	{

		private object[] itemsField;

		private ItemsChoiceType17[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Category", typeof(ClassUDLTextCategory))]
		[System.Xml.Serialization.XmlElementAttribute("Content", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ContentBase64", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("ContentWideBase64", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Position", typeof(ClassUDLTextPosition))]
		[System.Xml.Serialization.XmlElementAttribute("TextType", typeof(string), DataType = "integer")]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType17[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassUDLTextCategory
	{

		/// <remarks/>
		comment,

		/// <remarks/>
		COMMENT,

		/// <remarks/>
		Comment,

		/// <remarks/>
		error,

		/// <remarks/>
		ERROR,

		/// <remarks/>
		Error,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ClassUDLTextPosition
	{

		/// <remarks/>
		body,

		/// <remarks/>
		BODY,

		/// <remarks/>
		Body,

		/// <remarks/>
		header,

		/// <remarks/>
		HEADER,

		/// <remarks/>
		Header,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType17
	{

		/// <remarks/>
		Category,

		/// <remarks/>
		Content,

		/// <remarks/>
		ContentBase64,

		/// <remarks/>
		ContentWideBase64,

		/// <remarks/>
		Position,

		/// <remarks/>
		TextType,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ClassXData
	{

		private object[] itemsField;

		private ItemsChoiceType18[] itemsElementNameField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Data", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("DataBase64", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("DataWideBase64", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Deprecated", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("Description", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("Internal", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("MimeType", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SchemaSpec", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("XMLNamespace", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType18[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType18
	{

		/// <remarks/>
		Data,

		/// <remarks/>
		DataBase64,

		/// <remarks/>
		DataWideBase64,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Internal,

		/// <remarks/>
		MimeType,

		/// <remarks/>
		SchemaSpec,

		/// <remarks/>
		XMLNamespace,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemsChoiceType19
	{

		/// <remarks/>
		Abstract,

		/// <remarks/>
		ClassDefinitionError,

		/// <remarks/>
		ClassType,

		/// <remarks/>
		ClientDataType,

		/// <remarks/>
		ClientName,

		/// <remarks/>
		CompileAfter,

		/// <remarks/>
		ConstraintClass,

		/// <remarks/>
		Copyright,

		/// <remarks/>
		DdlAllowed,

		/// <remarks/>
		DependsOn,

		/// <remarks/>
		Deployed,

		/// <remarks/>
		Deprecated,

		/// <remarks/>
		Description,

		/// <remarks/>
		Dynamic,

		/// <remarks/>
		EmbeddedClass,

		/// <remarks/>
		Final,

		/// <remarks/>
		ForeignKey,

		/// <remarks/>
		GeneratedBy,

		/// <remarks/>
		Hidden,

		/// <remarks/>
		Import,

		/// <remarks/>
		IncludeCode,

		/// <remarks/>
		IncludeGenerator,

		/// <remarks/>
		Index,

		/// <remarks/>
		IndexClass,

		/// <remarks/>
		Inheritance,

		/// <remarks/>
		Language,

		/// <remarks/>
		LegacyInstanceContext,

		/// <remarks/>
		MemberSuper,

		/// <remarks/>
		Method,

		/// <remarks/>
		Modified,

		/// <remarks/>
		NoContext,

		/// <remarks/>
		NoExtent,

		/// <remarks/>
		OdbcType,

		/// <remarks/>
		Owner,

		/// <remarks/>
		Parameter,

		/// <remarks/>
		ProcedureBlock,

		/// <remarks/>
		Projection,

		/// <remarks/>
		ProjectionClass,

		/// <remarks/>
		Property,

		/// <remarks/>
		PropertyClass,

		/// <remarks/>
		Query,

		/// <remarks/>
		QueryClass,

		/// <remarks/>
		ServerOnly,

		/// <remarks/>
		Sharded,

		/// <remarks/>
		SoapBindingStyle,

		/// <remarks/>
		SoapBodyUse,

		/// <remarks/>
		SqlCategory,

		/// <remarks/>
		SqlRoutinePrefix,

		/// <remarks/>
		SqlRowIdName,

		/// <remarks/>
		SqlRowIdPrivate,

		/// <remarks/>
		SqlTableName,

		/// <remarks/>
		Storage,

		/// <remarks/>
		StorageStrategy,

		/// <remarks/>
		Super,

		/// <remarks/>
		System,

		/// <remarks/>
		TimeChanged,

		/// <remarks/>
		TimeCreated,

		/// <remarks/>
		Trigger,

		/// <remarks/>
		TriggerClass,

		/// <remarks/>
		UDLText,

		/// <remarks/>
		ViewQuery,

		/// <remarks/>
		XData,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportDocument
	{

		private System.Xml.XmlElement[] itemsField;

		private string[] textField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyElementAttribute()]
		public System.Xml.XmlElement[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string[] Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportGlobal
	{

		private Node nodeField;

		/// <remarks/>
		public Node Node
		{
			get
			{
				return this.nodeField;
			}
			set
			{
				this.nodeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class Node
	{

		private object itemField;

		private ItemChoiceType itemElementNameField;

		private object item1Field;

		private Item1ChoiceType item1ElementNameField;

		private Node[] node1Field;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Sub", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SubBase64", typeof(byte[]), DataType = "base64Binary")]
		[System.Xml.Serialization.XmlElementAttribute("SubCrLf", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SubWideBase64", typeof(byte[]), DataType = "base64Binary")]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public object Item
		{
			get
			{
				return this.itemField;
			}
			set
			{
				this.itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType ItemElementName
		{
			get
			{
				return this.itemElementNameField;
			}
			set
			{
				this.itemElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Data", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("DataBase64", typeof(byte[]), DataType = "base64Binary")]
		[System.Xml.Serialization.XmlElementAttribute("DataCrLf", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("DataWideBase64", typeof(byte[]), DataType = "base64Binary")]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("Item1ElementName")]
		public object Item1
		{
			get
			{
				return this.item1Field;
			}
			set
			{
				this.item1Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public Item1ChoiceType Item1ElementName
		{
			get
			{
				return this.item1ElementNameField;
			}
			set
			{
				this.item1ElementNameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Node")]
		public Node[] Node1
		{
			get
			{
				return this.node1Field;
			}
			set
			{
				this.node1Field = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum ItemChoiceType
	{

		/// <remarks/>
		Sub,

		/// <remarks/>
		SubBase64,

		/// <remarks/>
		SubCrLf,

		/// <remarks/>
		SubWideBase64,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
	public enum Item1ChoiceType
	{

		/// <remarks/>
		Data,

		/// <remarks/>
		DataBase64,

		/// <remarks/>
		DataCrLf,

		/// <remarks/>
		DataWideBase64,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportOBJ
	{

		private byte[] dataBase64Field;

		private Node[] nodeField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
		public byte[] DataBase64
		{
			get
			{
				return this.dataBase64Field;
			}
			set
			{
				this.dataBase64Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Node")]
		public Node[] Node
		{
			get
			{
				return this.nodeField;
			}
			set
			{
				this.nodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportPackage
	{

		private string descriptionField;

		private string nameField;

		private string clientnameField;

		private string globalprefixField;

		private string ownernameField;

		private string rtnprefixField;

		private string sqlnameField;

		private System.Xml.XmlAttribute[] anyAttrField;

		/// <remarks/>
		public string Description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string clientname
		{
			get
			{
				return this.clientnameField;
			}
			set
			{
				this.clientnameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string globalprefix
		{
			get
			{
				return this.globalprefixField;
			}
			set
			{
				this.globalprefixField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ownername
		{
			get
			{
				return this.ownernameField;
			}
			set
			{
				this.ownernameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string rtnprefix
		{
			get
			{
				return this.rtnprefixField;
			}
			set
			{
				this.rtnprefixField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string sqlname
		{
			get
			{
				return this.sqlnameField;
			}
			set
			{
				this.sqlnameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProject
	{

		private object[] itemsField;

		private string nameField;

		private string lastModifiedField;

		private string targetField;

		private string targetTypeField;

		private string httpServerField;

		private bool runInTerminalField;

		private bool runInTerminalFieldSpecified;

		private string terminalUsernameField;

		private string terminalPasswordField;

		private string terminalPortField;

		private string definesField;

		private System.Xml.XmlAttribute[] anyAttrField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("BreakPoints", typeof(ExportProjectBreakPoints))]
		[System.Xml.Serialization.XmlElementAttribute("Items", typeof(ExportProjectItems))]
		[System.Xml.Serialization.XmlElementAttribute("ProjectDescription", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("WatchPoints", typeof(ExportProjectWatchPoints))]
		[System.Xml.Serialization.XmlElementAttribute("WatchVariables", typeof(ExportProjectWatchVariables))]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string LastModified
		{
			get
			{
				return this.lastModifiedField;
			}
			set
			{
				this.lastModifiedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
		public string TargetType
		{
			get
			{
				return this.targetTypeField;
			}
			set
			{
				this.targetTypeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HttpServer
		{
			get
			{
				return this.httpServerField;
			}
			set
			{
				this.httpServerField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public bool RunInTerminal
		{
			get
			{
				return this.runInTerminalField;
			}
			set
			{
				this.runInTerminalField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool RunInTerminalSpecified
		{
			get
			{
				return this.runInTerminalFieldSpecified;
			}
			set
			{
				this.runInTerminalFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string TerminalUsername
		{
			get
			{
				return this.terminalUsernameField;
			}
			set
			{
				this.terminalUsernameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string TerminalPassword
		{
			get
			{
				return this.terminalPasswordField;
			}
			set
			{
				this.terminalPasswordField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string TerminalPort
		{
			get
			{
				return this.terminalPortField;
			}
			set
			{
				this.terminalPortField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Defines
		{
			get
			{
				return this.definesField;
			}
			set
			{
				this.definesField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProjectBreakPoints
	{

		private ExportProjectBreakPointsBreakPoint[] breakPointField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("BreakPoint")]
		public ExportProjectBreakPointsBreakPoint[] BreakPoint
		{
			get
			{
				return this.breakPointField;
			}
			set
			{
				this.breakPointField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProjectBreakPointsBreakPoint
	{

		private string conditionField;

		private string routineField;

		private string offsetField;

		private System.Xml.XmlAttribute[] anyAttrField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Condition
		{
			get
			{
				return this.conditionField;
			}
			set
			{
				this.conditionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Routine
		{
			get
			{
				return this.routineField;
			}
			set
			{
				this.routineField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Offset
		{
			get
			{
				return this.offsetField;
			}
			set
			{
				this.offsetField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProjectItems
	{

		private ExportProjectItemsProjectItem[] projectItemField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ProjectItem")]
		public ExportProjectItemsProjectItem[] ProjectItem
		{
			get
			{
				return this.projectItemField;
			}
			set
			{
				this.projectItemField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProjectItemsProjectItem
	{

		private string nameField;

		private string typeField;

		private System.Xml.XmlAttribute[] anyAttrField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProjectWatchPoints
	{

		private ExportProjectWatchPointsWatchPoint[] watchPointField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("WatchPoint")]
		public ExportProjectWatchPointsWatchPoint[] WatchPoint
		{
			get
			{
				return this.watchPointField;
			}
			set
			{
				this.watchPointField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProjectWatchPointsWatchPoint
	{

		private string conditionField;

		private string variableField;

		private System.Xml.XmlAttribute[] anyAttrField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Condition
		{
			get
			{
				return this.conditionField;
			}
			set
			{
				this.conditionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Variable
		{
			get
			{
				return this.variableField;
			}
			set
			{
				this.variableField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProjectWatchVariables
	{

		private ExportProjectWatchVariablesWatchVariable[] watchVariableField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("WatchVariable")]
		public ExportProjectWatchVariablesWatchVariable[] WatchVariable
		{
			get
			{
				return this.watchVariableField;
			}
			set
			{
				this.watchVariableField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportProjectWatchVariablesWatchVariable
	{

		private string paneField;

		private string variableField;

		private System.Xml.XmlAttribute[] anyAttrField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Pane
		{
			get
			{
				return this.paneField;
			}
			set
			{
				this.paneField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Variable
		{
			get
			{
				return this.variableField;
			}
			set
			{
				this.variableField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportRoutine
	{

		private string nameField;

		private ExportRoutineType typeField;

		private sbyte languagemodeField;

		private string timestampField;

		private bool generatedField;

		private bool generatedFieldSpecified;

		private System.Xml.XmlAttribute[] anyAttrField;

		private string valueField;

		public ExportRoutine()
		{
			this.languagemodeField = ((sbyte)(0));
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ExportRoutineType type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(sbyte), "0")]
		public sbyte languagemode
		{
			get
			{
				return this.languagemodeField;
			}
			set
			{
				this.languagemodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string timestamp
		{
			get
			{
				return this.timestampField;
			}
			set
			{
				this.timestampField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public bool generated
		{
			get
			{
				return this.generatedField;
			}
			set
			{
				this.generatedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool generatedSpecified
		{
			get
			{
				return this.generatedFieldSpecified;
			}
			set
			{
				this.generatedFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum ExportRoutineType
	{

		/// <remarks/>
		INC,

		/// <remarks/>
		INT,

		/// <remarks/>
		BAS,

		/// <remarks/>
		MAC,

		/// <remarks/>
		MVB,

		/// <remarks/>
		MVI,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportRoutineBase64
	{

		private string nameField;

		private ExportRoutineType typeField;

		private sbyte languagemodeField;

		private string timestampField;

		private bool generatedField;

		private bool generatedFieldSpecified;

		private System.Xml.XmlAttribute[] anyAttrField;

		private byte[] valueField;

		public ExportRoutineBase64()
		{
			this.languagemodeField = ((sbyte)(0));
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ExportRoutineType type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(sbyte), "0")]
		public sbyte languagemode
		{
			get
			{
				return this.languagemodeField;
			}
			set
			{
				this.languagemodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string timestamp
		{
			get
			{
				return this.timestampField;
			}
			set
			{
				this.timestampField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public bool generated
		{
			get
			{
				return this.generatedField;
			}
			set
			{
				this.generatedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool generatedSpecified
		{
			get
			{
				return this.generatedFieldSpecified;
			}
			set
			{
				this.generatedFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
		public byte[] Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportRoutineWideBase64
	{

		private string nameField;

		private ExportRoutineType typeField;

		private sbyte languagemodeField;

		private string timestampField;

		private bool generatedField;

		private bool generatedFieldSpecified;

		private System.Xml.XmlAttribute[] anyAttrField;

		private byte[] valueField;

		public ExportRoutineWideBase64()
		{
			this.languagemodeField = ((sbyte)(0));
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ExportRoutineType type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(sbyte), "0")]
		public sbyte languagemode
		{
			get
			{
				return this.languagemodeField;
			}
			set
			{
				this.languagemodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string timestamp
		{
			get
			{
				return this.timestampField;
			}
			set
			{
				this.timestampField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public bool generated
		{
			get
			{
				return this.generatedField;
			}
			set
			{
				this.generatedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool generatedSpecified
		{
			get
			{
				return this.generatedFieldSpecified;
			}
			set
			{
				this.generatedFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute(DataType = "base64Binary")]
		public byte[] Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("Raider.TestConsoleFramework", "1.0.0.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ExportChecksum
	{

		private long valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public long value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

}
