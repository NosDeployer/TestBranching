using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectEngineerSubcontractorsGateway 
    /// </summary>
    public class ProjectEngineerSubcontractorsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectEngineerSubcontractorsGateway() : base("LFS_PROJECT_ENGINEER_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectEngineerSubcontractorsGateway(DataSet data) : base(data, "LFS_PROJECT_ENGINEER_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_PROJECT_ENGINEER_SUBCONTRACTORS";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("GeneralContractor", "GeneralContractor");
            tableMapping.ColumnMappings.Add("GeneralWSIB", "GeneralWSIB");
            tableMapping.ColumnMappings.Add("GeneralInsuranceCertificate", "GeneralInsuranceCertificate");
            tableMapping.ColumnMappings.Add("GeneralBondingSupplied", "GeneralBondingSupplied");
            tableMapping.ColumnMappings.Add("GeneralMOLForm", "GeneralMOLForm");
            tableMapping.ColumnMappings.Add("GeneralNoticeProject", "GeneralNoticeProject");
            tableMapping.ColumnMappings.Add("GeneralForm1000", "GeneralForm1000");
            tableMapping.ColumnMappings.Add("EngineeringFirmID", "EngineeringFirmID");
            tableMapping.ColumnMappings.Add("EngineerID", "EngineerID");
            tableMapping.ColumnMappings.Add("EngineerNumber", "EngineerNumber");
            tableMapping.ColumnMappings.Add("SubcontractorUsed", "SubcontractorUsed");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("BondNumber", "BondNumber");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_ENGINEER_SUBCONTRACTORS] WHERE (([ProjectID] = @Original_ProjectID) AND ([GeneralContractor] = @Original_GeneralContractor) AND ([GeneralWSIB] = @Original_GeneralWSIB) AND ([GeneralInsuranceCertificate] = @Original_GeneralInsuranceCertificate) AND ([GeneralBondingSupplied] = @Original_GeneralBondingSupplied) AND ([GeneralMOLForm] = @Original_GeneralMOLForm) AND ([GeneralNoticeProject] = @Original_GeneralNoticeProject) AND ([GeneralForm1000] = @Original_GeneralForm1000) AND ((@IsNull_EngineeringFirmID = 1 AND [EngineeringFirmID] IS NULL) OR ([EngineeringFirmID] = @Original_EngineeringFirmID)) AND ((@IsNull_EngineerID = 1 AND [EngineerID] IS NULL) OR ([EngineerID] = @Original_EngineerID)) AND ((@IsNull_EngineerNumber = 1 AND [EngineerNumber] IS NULL) OR ([EngineerNumber] = @Original_EngineerNumber)) AND ([SubcontractorUsed] = @Original_SubcontractorUsed) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_BondNumber = 1 AND [BondNumber] IS NULL) OR ([BondNumber] = @Original_BondNumber)))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralContractor", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralContractor", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralWSIB", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralWSIB", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralInsuranceCertificate", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralInsuranceCertificate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralBondingSupplied", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralBondingSupplied", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralMOLForm", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralMOLForm", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralNoticeProject", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralNoticeProject", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralForm1000", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralForm1000", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EngineeringFirmID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineeringFirmID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EngineeringFirmID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineeringFirmID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EngineerID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EngineerID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EngineerNumber", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerNumber", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EngineerNumber", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerNumber", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubcontractorUsed", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorUsed", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BondNumber", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BondNumber", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BondNumber", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BondNumber", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_ENGINEER_SUBCONTRACTORS] ([ProjectID], [GeneralContractor], [GeneralWSIB], [GeneralInsuranceCertificate], [GeneralBondingSupplied], [GeneralMOLForm], [GeneralNoticeProject], [GeneralForm1000], [EngineeringFirmID], [EngineerID], [EngineerNumber], [SubcontractorUsed], [COMPANY_ID], [BondNumber]) VALUES (@ProjectID, @GeneralContractor, @GeneralWSIB, @GeneralInsuranceCertificate, @GeneralBondingSupplied, @GeneralMOLForm, @GeneralNoticeProject, @GeneralForm1000, @EngineeringFirmID, @EngineerID, @EngineerNumber, @SubcontractorUsed, @COMPANY_ID, @BondNumber);
SELECT ProjectID, GeneralContractor, GeneralWSIB, GeneralInsuranceCertificate, GeneralBondingSupplied, GeneralMOLForm, GeneralNoticeProject, GeneralForm1000, EngineeringFirmID, EngineerID, EngineerNumber, SubcontractorUsed, COMPANY_ID, BondNumber FROM LFS_PROJECT_ENGINEER_SUBCONTRACTORS WHERE (ProjectID = @ProjectID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralContractor", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralContractor", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralWSIB", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralWSIB", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralInsuranceCertificate", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralInsuranceCertificate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralBondingSupplied", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralBondingSupplied", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralMOLForm", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralMOLForm", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralNoticeProject", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralNoticeProject", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralForm1000", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralForm1000", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineeringFirmID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineeringFirmID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerNumber", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerNumber", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubcontractorUsed", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorUsed", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BondNumber", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BondNumber", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT_ENGINEER_SUBCONTRACTORS] SET [ProjectID] = @ProjectID, " +
                "[GeneralContractor] = @GeneralContractor, [GeneralWSIB] = @GeneralWSIB, [General" +
                "InsuranceCertificate] = @GeneralInsuranceCertificate, [GeneralBondingSupplied] =" +
                " @GeneralBondingSupplied, [GeneralMOLForm] = @GeneralMOLForm, [GeneralNoticeProj" +
                "ect] = @GeneralNoticeProject, [GeneralForm1000] = @GeneralForm1000, [Engineering" +
                "FirmID] = @EngineeringFirmID, [EngineerID] = @EngineerID, [EngineerNumber] = @En" +
                "gineerNumber, [SubcontractorUsed] = @SubcontractorUsed, [COMPANY_ID] = @COMPANY_" +
                "ID, [BondNumber] = @BondNumber WHERE (([ProjectID] = @Original_ProjectID) AND ([" +
                "GeneralContractor] = @Original_GeneralContractor) AND ([GeneralWSIB] = @Original" +
                "_GeneralWSIB) AND ([GeneralInsuranceCertificate] = @Original_GeneralInsuranceCer" +
                "tificate) AND ([GeneralBondingSupplied] = @Original_GeneralBondingSupplied) AND " +
                "([GeneralMOLForm] = @Original_GeneralMOLForm) AND ([GeneralNoticeProject] = @Ori" +
                "ginal_GeneralNoticeProject) AND ([GeneralForm1000] = @Original_GeneralForm1000) " +
                "AND ((@IsNull_EngineeringFirmID = 1 AND [EngineeringFirmID] IS NULL) OR ([Engine" +
                "eringFirmID] = @Original_EngineeringFirmID)) AND ((@IsNull_EngineerID = 1 AND [E" +
                "ngineerID] IS NULL) OR ([EngineerID] = @Original_EngineerID)) AND ((@IsNull_Engi" +
                "neerNumber = 1 AND [EngineerNumber] IS NULL) OR ([EngineerNumber] = @Original_En" +
                "gineerNumber)) AND ([SubcontractorUsed] = @Original_SubcontractorUsed) AND ([COM" +
                "PANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_BondNumber = 1 AND [BondNumber] I" +
                "S NULL) OR ([BondNumber] = @Original_BondNumber)));\r\nSELECT ProjectID, GeneralCo" +
                "ntractor, GeneralWSIB, GeneralInsuranceCertificate, GeneralBondingSupplied, Gene" +
                "ralMOLForm, GeneralNoticeProject, GeneralForm1000, EngineeringFirmID, EngineerID" +
                ", EngineerNumber, SubcontractorUsed, COMPANY_ID, BondNumber FROM LFS_PROJECT_ENG" +
                "INEER_SUBCONTRACTORS WHERE (ProjectID = @ProjectID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralContractor", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralContractor", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralWSIB", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralWSIB", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralInsuranceCertificate", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralInsuranceCertificate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralBondingSupplied", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralBondingSupplied", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralMOLForm", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralMOLForm", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralNoticeProject", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralNoticeProject", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GeneralForm1000", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralForm1000", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineeringFirmID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineeringFirmID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerNumber", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerNumber", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubcontractorUsed", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorUsed", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BondNumber", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BondNumber", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralContractor", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralContractor", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralWSIB", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralWSIB", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralInsuranceCertificate", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralInsuranceCertificate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralBondingSupplied", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralBondingSupplied", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralMOLForm", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralMOLForm", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralNoticeProject", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralNoticeProject", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GeneralForm1000", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GeneralForm1000", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EngineeringFirmID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineeringFirmID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EngineeringFirmID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineeringFirmID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EngineerID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EngineerID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EngineerNumber", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerNumber", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EngineerNumber", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "EngineerNumber", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubcontractorUsed", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorUsed", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BondNumber", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BondNumber", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BondNumber", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BondNumber", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTENGINEERSUBCONTRACTORGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project row</returns>
        public DataRow GetRow(int projectId)
        {
            string filter = string.Format("ProjectID = {0}", projectId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];

                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectEngineerSubcontractorsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetGeneralContractor
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>General contractor</returns>
        public bool GetGeneralContractor(int projectId)
        {
            return (bool)GetRow(projectId)["GeneralContractor"];
        }



        /// <summary>
        /// GetGeneralWSIB
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>General WSIB</returns>
        public bool GetGeneralWSIB(int projectId)
        {
            return (bool)GetRow(projectId)["GeneralWSIB"];
        }



        /// <summary>
        /// GetGeneralInsuranceCertificate
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>General Insurance Certificate</returns>
        public bool GetGeneralInsuranceCertificate(int projectId)
        {
            return (bool)GetRow(projectId)["GeneralInsuranceCertificate"];
        }



        /// <summary>
        /// GetGeneralBondingSupplied
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>General Bondings supplied</returns>
        public string GetGeneralBondingSupplied(int projectId)
        {
            return (string)GetRow(projectId)["GeneralBondingSupplied"];
        }



        /// <summary>
        /// GetGeneralMOLForm
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>General MOLForm</returns>
        public string GetGeneralMOLForm(int projectId)
        {
            return (string)GetRow(projectId)["GeneralMOLForm"];
        }



        /// <summary>
        /// GetBondNumber
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>General MOLForm</returns>
        public string GetBondNumber(int projectId)
        {
            if (GetRow(projectId).IsNull("BondNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["BondNumber"];
            }
        }



        /// <summary>
        /// GetGeneralNoticeProject
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>General Notice Project</returns>
        public bool GetGeneralNoticeProject(int projectId)
        {
            return (bool)GetRow(projectId)["GeneralNoticeProject"];
        }



        /// <summary>
        /// GetGeneralForm1000
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>General Form 1000</returns>
        public bool GetGeneralForm1000(int projectId)
        {
            return (bool)GetRow(projectId)["GeneralForm1000"];
        }



        /// <summary>
        /// GetEngineeringFirmId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>EngineeringFirmID</returns>
        public int? GetEngineeringFirmId(int projectId)
        {
            if (GetRow(projectId).IsNull("EngineeringFirmID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["EngineeringFirmID"];
            }
        }



        /// <summary>
        /// GetEngineerId
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>EngineerID</returns>
        public int? GetEngineerId(int projectId)
        {
            if (GetRow(projectId).IsNull("EngineerID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["EngineerID"];
            }
        }



        /// <summary>
        /// GetEngineerNumber
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>Engineer Number</returns>
        public string GetEngineerNumber(int projectId)
        {
            if (GetRow(projectId).IsNull("EngineerNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["EngineerNumber"];
            }
        }



        /// <summary>
        /// GetSubcontractorUsed
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>Subcontractor used</returns>
        public bool GetSubcontractorUsed(int projectId)
        {
            return (bool)GetRow(projectId)["SubcontractorUsed"];
        }

        
        
        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            DataTable tableChanges = Table.GetChanges();

            if ((tableChanges != null) && (tableChanges.Rows.Count > 0))
            {
                try
                {
                    Adapter.Update(Data, this.TableName);
                }
                catch (DBConcurrencyException dBConcurrencyException)
                {
                    throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
                }
                catch (SqlException sqlException)
                {
                    byte severityLevel = sqlException.Class;
                    if (severityLevel <= 16)
                    {
                        throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if ((severityLevel >= 17) && (severityLevel <= 19))
                    {
                        throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if (severityLevel >= 20)
                    {
                        throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Unknow error. Your operation has been cancelled.", e);
                }
            }
        }



        /// <summary>
        /// Update 2 - Engineer/Subcontractors and Subcontractors
        /// </summary>
        public void Update2()
        {
            ProjectSubcontractorGateway projectSubcontractorGateway = new ProjectSubcontractorGateway(Data);

            DataTable EngineerSubcontractorsChanges = Table.GetChanges();
            DataTable subcontractorsChanges = projectSubcontractorGateway.Table.GetChanges();

            if ((EngineerSubcontractorsChanges == null) && (subcontractorsChanges == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectSubcontractorGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectSubcontractorGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectSubcontractorGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((EngineerSubcontractorsChanges != null) && (EngineerSubcontractorsChanges.Rows.Count > 0))
                {
                    Adapter.Update(EngineerSubcontractorsChanges);
                }

                if ((subcontractorsChanges != null) && (subcontractorsChanges.Rows.Count > 0))
                {
                    projectSubcontractorGateway.Adapter.Update(subcontractorsChanges);
                }

                DB.CommitTransaction();
            }

            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }

            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
                byte severityLevel = sqlException.Class;
                if (severityLevel <= 16)
                {
                    throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if ((severityLevel >= 17) && (severityLevel <= 19))
                {
                    throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if (severityLevel >= 20)
                {
                    throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
            }

            catch (Exception e)
            {
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }

            finally
            {
                DB.Close();
            }

        }



    }
}
