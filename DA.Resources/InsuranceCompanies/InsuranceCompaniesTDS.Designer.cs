﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3643
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace LiquiForce.LFSLive.DA.Resources.InsuranceCompanies {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("InsuranceCompaniesTDS")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class InsuranceCompaniesTDS : global::System.Data.DataSet {
        
        private LFS_RESOURCES_INSURANCE_COMPANIESDataTable tableLFS_RESOURCES_INSURANCE_COMPANIES;
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public InsuranceCompaniesTDS() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected InsuranceCompaniesTDS(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["LFS_RESOURCES_INSURANCE_COMPANIES"] != null)) {
                    base.Tables.Add(new LFS_RESOURCES_INSURANCE_COMPANIESDataTable(ds.Tables["LFS_RESOURCES_INSURANCE_COMPANIES"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.Browsable(false)]
        [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public LFS_RESOURCES_INSURANCE_COMPANIESDataTable LFS_RESOURCES_INSURANCE_COMPANIES {
            get {
                return this.tableLFS_RESOURCES_INSURANCE_COMPANIES;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.BrowsableAttribute(true)]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override global::System.Data.DataSet Clone() {
            InsuranceCompaniesTDS cln = ((InsuranceCompaniesTDS)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["LFS_RESOURCES_INSURANCE_COMPANIES"] != null)) {
                    base.Tables.Add(new LFS_RESOURCES_INSURANCE_COMPANIESDataTable(ds.Tables["LFS_RESOURCES_INSURANCE_COMPANIES"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableLFS_RESOURCES_INSURANCE_COMPANIES = ((LFS_RESOURCES_INSURANCE_COMPANIESDataTable)(base.Tables["LFS_RESOURCES_INSURANCE_COMPANIES"]));
            if ((initTable == true)) {
                if ((this.tableLFS_RESOURCES_INSURANCE_COMPANIES != null)) {
                    this.tableLFS_RESOURCES_INSURANCE_COMPANIES.InitVars();
                }
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "InsuranceCompaniesTDS";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/InsuranceCompaniesTDS.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableLFS_RESOURCES_INSURANCE_COMPANIES = new LFS_RESOURCES_INSURANCE_COMPANIESDataTable();
            base.Tables.Add(this.tableLFS_RESOURCES_INSURANCE_COMPANIES);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeLFS_RESOURCES_INSURANCE_COMPANIES() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            InsuranceCompaniesTDS ds = new InsuranceCompaniesTDS();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace)) {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length)) {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length) 
                                        && (s1.ReadByte() == s2.ReadByte())); ) {
                                ;
                            }
                            if ((s1.Position == s1.Length)) {
                                return type;
                            }
                        }
                    }
                }
                finally {
                    if ((s1 != null)) {
                        s1.Close();
                    }
                    if ((s2 != null)) {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }
        
        public delegate void LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEventHandler(object sender, LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEvent e);
        
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [global::System.Serializable()]
        [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class LFS_RESOURCES_INSURANCE_COMPANIESDataTable : global::System.Data.TypedTableBase<LFS_RESOURCES_INSURANCE_COMPANIESRow> {
            
            private global::System.Data.DataColumn columnCOMPANIES_ID;
            
            private global::System.Data.DataColumn columnDate;
            
            private global::System.Data.DataColumn columnName;
            
            private global::System.Data.DataColumn columnDeleted;
            
            private global::System.Data.DataColumn columnCOMPANY_ID;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public LFS_RESOURCES_INSURANCE_COMPANIESDataTable() {
                this.TableName = "LFS_RESOURCES_INSURANCE_COMPANIES";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal LFS_RESOURCES_INSURANCE_COMPANIESDataTable(global::System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected LFS_RESOURCES_INSURANCE_COMPANIESDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn COMPANIES_IDColumn {
                get {
                    return this.columnCOMPANIES_ID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn DateColumn {
                get {
                    return this.columnDate;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn NameColumn {
                get {
                    return this.columnName;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn DeletedColumn {
                get {
                    return this.columnDeleted;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn COMPANY_IDColumn {
                get {
                    return this.columnCOMPANY_ID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public LFS_RESOURCES_INSURANCE_COMPANIESRow this[int index] {
                get {
                    return ((LFS_RESOURCES_INSURANCE_COMPANIESRow)(this.Rows[index]));
                }
            }
            
            public event LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEventHandler LFS_RESOURCES_INSURANCE_COMPANIESRowChanging;
            
            public event LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEventHandler LFS_RESOURCES_INSURANCE_COMPANIESRowChanged;
            
            public event LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEventHandler LFS_RESOURCES_INSURANCE_COMPANIESRowDeleting;
            
            public event LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEventHandler LFS_RESOURCES_INSURANCE_COMPANIESRowDeleted;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddLFS_RESOURCES_INSURANCE_COMPANIESRow(LFS_RESOURCES_INSURANCE_COMPANIESRow row) {
                this.Rows.Add(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public LFS_RESOURCES_INSURANCE_COMPANIESRow AddLFS_RESOURCES_INSURANCE_COMPANIESRow(int COMPANIES_ID, System.DateTime Date, string Name, bool Deleted, int COMPANY_ID) {
                LFS_RESOURCES_INSURANCE_COMPANIESRow rowLFS_RESOURCES_INSURANCE_COMPANIESRow = ((LFS_RESOURCES_INSURANCE_COMPANIESRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        COMPANIES_ID,
                        Date,
                        Name,
                        Deleted,
                        COMPANY_ID};
                rowLFS_RESOURCES_INSURANCE_COMPANIESRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowLFS_RESOURCES_INSURANCE_COMPANIESRow);
                return rowLFS_RESOURCES_INSURANCE_COMPANIESRow;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public LFS_RESOURCES_INSURANCE_COMPANIESRow FindByCOMPANIES_IDDate(int COMPANIES_ID, System.DateTime Date) {
                return ((LFS_RESOURCES_INSURANCE_COMPANIESRow)(this.Rows.Find(new object[] {
                            COMPANIES_ID,
                            Date})));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override global::System.Data.DataTable Clone() {
                LFS_RESOURCES_INSURANCE_COMPANIESDataTable cln = ((LFS_RESOURCES_INSURANCE_COMPANIESDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataTable CreateInstance() {
                return new LFS_RESOURCES_INSURANCE_COMPANIESDataTable();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnCOMPANIES_ID = base.Columns["COMPANIES_ID"];
                this.columnDate = base.Columns["Date"];
                this.columnName = base.Columns["Name"];
                this.columnDeleted = base.Columns["Deleted"];
                this.columnCOMPANY_ID = base.Columns["COMPANY_ID"];
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnCOMPANIES_ID = new global::System.Data.DataColumn("COMPANIES_ID", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCOMPANIES_ID);
                this.columnDate = new global::System.Data.DataColumn("Date", typeof(global::System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnDate);
                this.columnName = new global::System.Data.DataColumn("Name", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnName);
                this.columnDeleted = new global::System.Data.DataColumn("Deleted", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnDeleted);
                this.columnCOMPANY_ID = new global::System.Data.DataColumn("COMPANY_ID", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCOMPANY_ID);
                this.Constraints.Add(new global::System.Data.UniqueConstraint("Constraint1", new global::System.Data.DataColumn[] {
                                this.columnCOMPANIES_ID,
                                this.columnDate}, true));
                this.columnCOMPANIES_ID.AllowDBNull = false;
                this.columnDate.AllowDBNull = false;
                this.columnName.MaxLength = 150;
                this.columnDeleted.AllowDBNull = false;
                this.columnCOMPANY_ID.AllowDBNull = false;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public LFS_RESOURCES_INSURANCE_COMPANIESRow NewLFS_RESOURCES_INSURANCE_COMPANIESRow() {
                return ((LFS_RESOURCES_INSURANCE_COMPANIESRow)(this.NewRow()));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder) {
                return new LFS_RESOURCES_INSURANCE_COMPANIESRow(builder);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Type GetRowType() {
                return typeof(LFS_RESOURCES_INSURANCE_COMPANIESRow);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.LFS_RESOURCES_INSURANCE_COMPANIESRowChanged != null)) {
                    this.LFS_RESOURCES_INSURANCE_COMPANIESRowChanged(this, new LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEvent(((LFS_RESOURCES_INSURANCE_COMPANIESRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.LFS_RESOURCES_INSURANCE_COMPANIESRowChanging != null)) {
                    this.LFS_RESOURCES_INSURANCE_COMPANIESRowChanging(this, new LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEvent(((LFS_RESOURCES_INSURANCE_COMPANIESRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.LFS_RESOURCES_INSURANCE_COMPANIESRowDeleted != null)) {
                    this.LFS_RESOURCES_INSURANCE_COMPANIESRowDeleted(this, new LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEvent(((LFS_RESOURCES_INSURANCE_COMPANIESRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.LFS_RESOURCES_INSURANCE_COMPANIESRowDeleting != null)) {
                    this.LFS_RESOURCES_INSURANCE_COMPANIESRowDeleting(this, new LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEvent(((LFS_RESOURCES_INSURANCE_COMPANIESRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveLFS_RESOURCES_INSURANCE_COMPANIESRow(LFS_RESOURCES_INSURANCE_COMPANIESRow row) {
                this.Rows.Remove(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                InsuranceCompaniesTDS ds = new InsuranceCompaniesTDS();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "LFS_RESOURCES_INSURANCE_COMPANIESDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace)) {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length)) {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length) 
                                            && (s1.ReadByte() == s2.ReadByte())); ) {
                                    ;
                                }
                                if ((s1.Position == s1.Length)) {
                                    return type;
                                }
                            }
                        }
                    }
                    finally {
                        if ((s1 != null)) {
                            s1.Close();
                        }
                        if ((s2 != null)) {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }
        
        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class LFS_RESOURCES_INSURANCE_COMPANIESRow : global::System.Data.DataRow {
            
            private LFS_RESOURCES_INSURANCE_COMPANIESDataTable tableLFS_RESOURCES_INSURANCE_COMPANIES;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal LFS_RESOURCES_INSURANCE_COMPANIESRow(global::System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableLFS_RESOURCES_INSURANCE_COMPANIES = ((LFS_RESOURCES_INSURANCE_COMPANIESDataTable)(this.Table));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int COMPANIES_ID {
                get {
                    return ((int)(this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.COMPANIES_IDColumn]));
                }
                set {
                    this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.COMPANIES_IDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime Date {
                get {
                    return ((global::System.DateTime)(this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.DateColumn]));
                }
                set {
                    this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.DateColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Name {
                get {
                    try {
                        return ((string)(this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.NameColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Name\' in table \'LFS_RESOURCES_INSURANCE_COMPANIES\' is DBNul" +
                                "l.", e);
                    }
                }
                set {
                    this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.NameColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool Deleted {
                get {
                    return ((bool)(this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.DeletedColumn]));
                }
                set {
                    this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.DeletedColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int COMPANY_ID {
                get {
                    return ((int)(this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.COMPANY_IDColumn]));
                }
                set {
                    this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.COMPANY_IDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsNameNull() {
                return this.IsNull(this.tableLFS_RESOURCES_INSURANCE_COMPANIES.NameColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetNameNull() {
                this[this.tableLFS_RESOURCES_INSURANCE_COMPANIES.NameColumn] = global::System.Convert.DBNull;
            }
        }
        
        /// <summary>
        ///Row event argument class
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEvent : global::System.EventArgs {
            
            private LFS_RESOURCES_INSURANCE_COMPANIESRow eventRow;
            
            private global::System.Data.DataRowAction eventAction;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public LFS_RESOURCES_INSURANCE_COMPANIESRowChangeEvent(LFS_RESOURCES_INSURANCE_COMPANIESRow row, global::System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public LFS_RESOURCES_INSURANCE_COMPANIESRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591