﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3615
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("VacationsSetupTDS")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class VacationsSetupTDS : global::System.Data.DataSet {
        
        private VacationsSetupDataTable tableVacationsSetup;
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public VacationsSetupTDS() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected VacationsSetupTDS(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
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
                if ((ds.Tables["VacationsSetup"] != null)) {
                    base.Tables.Add(new VacationsSetupDataTable(ds.Tables["VacationsSetup"]));
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
        public VacationsSetupDataTable VacationsSetup {
            get {
                return this.tableVacationsSetup;
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
            VacationsSetupTDS cln = ((VacationsSetupTDS)(base.Clone()));
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
                if ((ds.Tables["VacationsSetup"] != null)) {
                    base.Tables.Add(new VacationsSetupDataTable(ds.Tables["VacationsSetup"]));
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
            this.tableVacationsSetup = ((VacationsSetupDataTable)(base.Tables["VacationsSetup"]));
            if ((initTable == true)) {
                if ((this.tableVacationsSetup != null)) {
                    this.tableVacationsSetup.InitVars();
                }
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "VacationsSetupTDS";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/VacationsSetupTDS.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableVacationsSetup = new VacationsSetupDataTable();
            base.Tables.Add(this.tableVacationsSetup);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeVacationsSetup() {
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
            VacationsSetupTDS ds = new VacationsSetupTDS();
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
        
        public delegate void VacationsSetupRowChangeEventHandler(object sender, VacationsSetupRowChangeEvent e);
        
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [global::System.Serializable()]
        [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class VacationsSetupDataTable : global::System.Data.DataTable, global::System.Collections.IEnumerable {
            
            private global::System.Data.DataColumn columnYear;
            
            private global::System.Data.DataColumn columnEmployeeID;
            
            private global::System.Data.DataColumn columnEmployeeName;
            
            private global::System.Data.DataColumn columnVacationDays;
            
            private global::System.Data.DataColumn columnInDatabase;
            
            private global::System.Data.DataColumn columnTotalTakenVacationDays;
            
            private global::System.Data.DataColumn columnCarryOverDays;
            
            private global::System.Data.DataColumn columnTotalVacationDays;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public VacationsSetupDataTable() {
                this.TableName = "VacationsSetup";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal VacationsSetupDataTable(global::System.Data.DataTable table) {
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
            protected VacationsSetupDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn YearColumn {
                get {
                    return this.columnYear;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn EmployeeIDColumn {
                get {
                    return this.columnEmployeeID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn EmployeeNameColumn {
                get {
                    return this.columnEmployeeName;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn VacationDaysColumn {
                get {
                    return this.columnVacationDays;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn InDatabaseColumn {
                get {
                    return this.columnInDatabase;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn TotalTakenVacationDaysColumn {
                get {
                    return this.columnTotalTakenVacationDays;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn CarryOverDaysColumn {
                get {
                    return this.columnCarryOverDays;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn TotalVacationDaysColumn {
                get {
                    return this.columnTotalVacationDays;
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
            public VacationsSetupRow this[int index] {
                get {
                    return ((VacationsSetupRow)(this.Rows[index]));
                }
            }
            
            public event VacationsSetupRowChangeEventHandler VacationsSetupRowChanging;
            
            public event VacationsSetupRowChangeEventHandler VacationsSetupRowChanged;
            
            public event VacationsSetupRowChangeEventHandler VacationsSetupRowDeleting;
            
            public event VacationsSetupRowChangeEventHandler VacationsSetupRowDeleted;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddVacationsSetupRow(VacationsSetupRow row) {
                this.Rows.Add(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public VacationsSetupRow AddVacationsSetupRow(int Year, int EmployeeID, string EmployeeName, double VacationDays, bool InDatabase, double TotalTakenVacationDays, double CarryOverDays, double TotalVacationDays) {
                VacationsSetupRow rowVacationsSetupRow = ((VacationsSetupRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        Year,
                        EmployeeID,
                        EmployeeName,
                        VacationDays,
                        InDatabase,
                        TotalTakenVacationDays,
                        CarryOverDays,
                        TotalVacationDays};
                rowVacationsSetupRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowVacationsSetupRow);
                return rowVacationsSetupRow;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public VacationsSetupRow FindByYearEmployeeID(int Year, int EmployeeID) {
                return ((VacationsSetupRow)(this.Rows.Find(new object[] {
                            Year,
                            EmployeeID})));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual global::System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override global::System.Data.DataTable Clone() {
                VacationsSetupDataTable cln = ((VacationsSetupDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataTable CreateInstance() {
                return new VacationsSetupDataTable();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnYear = base.Columns["Year"];
                this.columnEmployeeID = base.Columns["EmployeeID"];
                this.columnEmployeeName = base.Columns["EmployeeName"];
                this.columnVacationDays = base.Columns["VacationDays"];
                this.columnInDatabase = base.Columns["InDatabase"];
                this.columnTotalTakenVacationDays = base.Columns["TotalTakenVacationDays"];
                this.columnCarryOverDays = base.Columns["CarryOverDays"];
                this.columnTotalVacationDays = base.Columns["TotalVacationDays"];
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnYear = new global::System.Data.DataColumn("Year", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnYear);
                this.columnEmployeeID = new global::System.Data.DataColumn("EmployeeID", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnEmployeeID);
                this.columnEmployeeName = new global::System.Data.DataColumn("EmployeeName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnEmployeeName);
                this.columnVacationDays = new global::System.Data.DataColumn("VacationDays", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnVacationDays);
                this.columnInDatabase = new global::System.Data.DataColumn("InDatabase", typeof(bool), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnInDatabase);
                this.columnTotalTakenVacationDays = new global::System.Data.DataColumn("TotalTakenVacationDays", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTotalTakenVacationDays);
                this.columnCarryOverDays = new global::System.Data.DataColumn("CarryOverDays", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCarryOverDays);
                this.columnTotalVacationDays = new global::System.Data.DataColumn("TotalVacationDays", typeof(double), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTotalVacationDays);
                this.Constraints.Add(new global::System.Data.UniqueConstraint("Constraint1", new global::System.Data.DataColumn[] {
                                this.columnYear,
                                this.columnEmployeeID}, true));
                this.columnYear.AllowDBNull = false;
                this.columnEmployeeID.AllowDBNull = false;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public VacationsSetupRow NewVacationsSetupRow() {
                return ((VacationsSetupRow)(this.NewRow()));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder) {
                return new VacationsSetupRow(builder);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Type GetRowType() {
                return typeof(VacationsSetupRow);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.VacationsSetupRowChanged != null)) {
                    this.VacationsSetupRowChanged(this, new VacationsSetupRowChangeEvent(((VacationsSetupRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.VacationsSetupRowChanging != null)) {
                    this.VacationsSetupRowChanging(this, new VacationsSetupRowChangeEvent(((VacationsSetupRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.VacationsSetupRowDeleted != null)) {
                    this.VacationsSetupRowDeleted(this, new VacationsSetupRowChangeEvent(((VacationsSetupRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.VacationsSetupRowDeleting != null)) {
                    this.VacationsSetupRowDeleting(this, new VacationsSetupRowChangeEvent(((VacationsSetupRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveVacationsSetupRow(VacationsSetupRow row) {
                this.Rows.Remove(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                VacationsSetupTDS ds = new VacationsSetupTDS();
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
                attribute2.FixedValue = "VacationsSetupDataTable";
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
        public partial class VacationsSetupRow : global::System.Data.DataRow {
            
            private VacationsSetupDataTable tableVacationsSetup;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal VacationsSetupRow(global::System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableVacationsSetup = ((VacationsSetupDataTable)(this.Table));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int Year {
                get {
                    return ((int)(this[this.tableVacationsSetup.YearColumn]));
                }
                set {
                    this[this.tableVacationsSetup.YearColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int EmployeeID {
                get {
                    return ((int)(this[this.tableVacationsSetup.EmployeeIDColumn]));
                }
                set {
                    this[this.tableVacationsSetup.EmployeeIDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string EmployeeName {
                get {
                    try {
                        return ((string)(this[this.tableVacationsSetup.EmployeeNameColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'EmployeeName\' in table \'VacationsSetup\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableVacationsSetup.EmployeeNameColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public double VacationDays {
                get {
                    try {
                        return ((double)(this[this.tableVacationsSetup.VacationDaysColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'VacationDays\' in table \'VacationsSetup\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableVacationsSetup.VacationDaysColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool InDatabase {
                get {
                    try {
                        return ((bool)(this[this.tableVacationsSetup.InDatabaseColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'InDatabase\' in table \'VacationsSetup\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableVacationsSetup.InDatabaseColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public double TotalTakenVacationDays {
                get {
                    try {
                        return ((double)(this[this.tableVacationsSetup.TotalTakenVacationDaysColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'TotalTakenVacationDays\' in table \'VacationsSetup\' is DBNull" +
                                ".", e);
                    }
                }
                set {
                    this[this.tableVacationsSetup.TotalTakenVacationDaysColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public double CarryOverDays {
                get {
                    try {
                        return ((double)(this[this.tableVacationsSetup.CarryOverDaysColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'CarryOverDays\' in table \'VacationsSetup\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableVacationsSetup.CarryOverDaysColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public double TotalVacationDays {
                get {
                    try {
                        return ((double)(this[this.tableVacationsSetup.TotalVacationDaysColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'TotalVacationDays\' in table \'VacationsSetup\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableVacationsSetup.TotalVacationDaysColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEmployeeNameNull() {
                return this.IsNull(this.tableVacationsSetup.EmployeeNameColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEmployeeNameNull() {
                this[this.tableVacationsSetup.EmployeeNameColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsVacationDaysNull() {
                return this.IsNull(this.tableVacationsSetup.VacationDaysColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetVacationDaysNull() {
                this[this.tableVacationsSetup.VacationDaysColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsInDatabaseNull() {
                return this.IsNull(this.tableVacationsSetup.InDatabaseColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetInDatabaseNull() {
                this[this.tableVacationsSetup.InDatabaseColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsTotalTakenVacationDaysNull() {
                return this.IsNull(this.tableVacationsSetup.TotalTakenVacationDaysColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetTotalTakenVacationDaysNull() {
                this[this.tableVacationsSetup.TotalTakenVacationDaysColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCarryOverDaysNull() {
                return this.IsNull(this.tableVacationsSetup.CarryOverDaysColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCarryOverDaysNull() {
                this[this.tableVacationsSetup.CarryOverDaysColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsTotalVacationDaysNull() {
                return this.IsNull(this.tableVacationsSetup.TotalVacationDaysColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetTotalVacationDaysNull() {
                this[this.tableVacationsSetup.TotalVacationDaysColumn] = global::System.Convert.DBNull;
            }
        }
        
        /// <summary>
        ///Row event argument class
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class VacationsSetupRowChangeEvent : global::System.EventArgs {
            
            private VacationsSetupRow eventRow;
            
            private global::System.Data.DataRowAction eventAction;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public VacationsSetupRowChangeEvent(VacationsSetupRow row, global::System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public VacationsSetupRow Row {
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