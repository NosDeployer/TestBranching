using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectSaleBillingPricingGateway 
    /// </summary>
    public class ProjectSaleBillingPricingGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSaleBillingPricingGateway() : base("LFS_PROJECT_SALE_BILLING_PRICING")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectSaleBillingPricingGateway(DataSet data) : base(data, "LFS_PROJECT_SALE_BILLING_PRICING")
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
            tableMapping.DataSetTable = "LFS_PROJECT_SALE_BILLING_PRICING";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SaleBidProject", "SaleBidProject");
            tableMapping.ColumnMappings.Add("SaleRFP", "SaleRFP");
            tableMapping.ColumnMappings.Add("SaleSoleSource", "SaleSoleSource");
            tableMapping.ColumnMappings.Add("SaleTermContract", "SaleTermContract");
            tableMapping.ColumnMappings.Add("SaleTermContractDetail", "SaleTermContractDetail");
            tableMapping.ColumnMappings.Add("SaleOther", "SaleOther");
            tableMapping.ColumnMappings.Add("SaleOtherDetail", "SaleOtherDetail");
            tableMapping.ColumnMappings.Add("SaleGettingJob", "SaleGettingJob");
            tableMapping.ColumnMappings.Add("BillPrice", "BillPrice");
            tableMapping.ColumnMappings.Add("BillMoney", "BillMoney");
            tableMapping.ColumnMappings.Add("BillBidHardDollar", "BillBidHardDollar");
            tableMapping.ColumnMappings.Add("BillPerUnit", "BillPerUnit");
            tableMapping.ColumnMappings.Add("BillHourly", "BillHourly");
            tableMapping.ColumnMappings.Add("BillExpectExtras", "BillExpectExtras");
            tableMapping.ColumnMappings.Add("BillSubcontractorAmount", "BillSubcontractorAmount");
            tableMapping.ColumnMappings.Add("ChargesWater", "ChargesWater");
            tableMapping.ColumnMappings.Add("ChargesWaterAmount", "ChargesWaterAmount");
            tableMapping.ColumnMappings.Add("ChargesDisposal", "ChargesDisposal");
            tableMapping.ColumnMappings.Add("ChargesDisposalAmount", "ChargesDisposalAmount");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);
            
            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_PROJECT_SALE_BILLING_PRICING] WHERE (([ProjectID] = @Origi" +
                "nal_ProjectID) AND ([SaleBidProject] = @Original_SaleBidProject) AND ([SaleRFP] " +
                "= @Original_SaleRFP) AND ([SaleSoleSource] = @Original_SaleSoleSource) AND ([Sal" +
                "eTermContract] = @Original_SaleTermContract) AND ((@IsNull_SaleTermContractDetai" +
                "l = 1 AND [SaleTermContractDetail] IS NULL) OR ([SaleTermContractDetail] = @Orig" +
                "inal_SaleTermContractDetail)) AND ([SaleOther] = @Original_SaleOther) AND ((@IsN" +
                "ull_SaleOtherDetail = 1 AND [SaleOtherDetail] IS NULL) OR ([SaleOtherDetail] = @" +
                "Original_SaleOtherDetail)) AND ((@IsNull_SaleGettingJob = 1 AND [SaleGettingJob]" +
                " IS NULL) OR ([SaleGettingJob] = @Original_SaleGettingJob)) AND ((@IsNull_BillPr" +
                "ice = 1 AND [BillPrice] IS NULL) OR ([BillPrice] = @Original_BillPrice)) AND ([B" +
                "illMoney] = @Original_BillMoney) AND ((@IsNull_BillBidHardDollar = 1 AND [BillBi" +
                "dHardDollar] IS NULL) OR ([BillBidHardDollar] = @Original_BillBidHardDollar)) AN" +
                "D ([BillPerUnit] = @Original_BillPerUnit) AND ([BillHourly] = @Original_BillHour" +
                "ly) AND ((@IsNull_BillExpectExtras = 1 AND [BillExpectExtras] IS NULL) OR ([Bill" +
                "ExpectExtras] = @Original_BillExpectExtras)) AND ((@IsNull_BillSubcontractorAmou" +
                "nt = 1 AND [BillSubcontractorAmount] IS NULL) OR ([BillSubcontractorAmount] = @O" +
                "riginal_BillSubcontractorAmount)) AND ([ChargesWater] = @Original_ChargesWater) " +
                "AND ((@IsNull_ChargesWaterAmount = 1 AND [ChargesWaterAmount] IS NULL) OR ([Char" +
                "gesWaterAmount] = @Original_ChargesWaterAmount)) AND ([ChargesDisposal] = @Origi" +
                "nal_ChargesDisposal) AND ((@IsNull_ChargesDisposalAmount = 1 AND [ChargesDisposa" +
                "lAmount] IS NULL) OR ([ChargesDisposalAmount] = @Original_ChargesDisposalAmount)" +
                ") AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleBidProject", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleBidProject", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleRFP", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleRFP", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleSoleSource", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleSoleSource", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleTermContract", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContract", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SaleTermContractDetail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContractDetail", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleTermContractDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContractDetail", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleOther", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOther", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SaleOtherDetail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOtherDetail", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleOtherDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOtherDetail", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SaleGettingJob", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleGettingJob", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleGettingJob", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleGettingJob", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BillPrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPrice", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillPrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPrice", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillMoney", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillMoney", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BillBidHardDollar", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BillBidHardDollar", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillBidHardDollar", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillBidHardDollar", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillPerUnit", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPerUnit", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillHourly", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BillHourly", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BillExpectExtras", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BillExpectExtras", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillExpectExtras", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillExpectExtras", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BillSubcontractorAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BillSubcontractorAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillSubcontractorAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "BillSubcontractorAmount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChargesWater", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWater", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ChargesWaterAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWaterAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChargesWaterAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWaterAmount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChargesDisposal", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposal", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ChargesDisposalAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposalAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChargesDisposalAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposalAmount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_SALE_BILLING_PRICING] ([ProjectID], [SaleBidProject], [SaleRFP], [SaleSoleSource], [SaleTermContract], [SaleTermContractDetail], [SaleOther], [SaleOtherDetail], [SaleGettingJob], [BillPrice], [BillMoney], [BillBidHardDollar], [BillPerUnit], [BillHourly], [BillExpectExtras], [BillSubcontractorAmount], [ChargesWater], [ChargesWaterAmount], [ChargesDisposal], [ChargesDisposalAmount], [COMPANY_ID]) VALUES (@ProjectID, @SaleBidProject, @SaleRFP, @SaleSoleSource, @SaleTermContract, @SaleTermContractDetail, @SaleOther, @SaleOtherDetail, @SaleGettingJob, @BillPrice, @BillMoney, @BillBidHardDollar, @BillPerUnit, @BillHourly, @BillExpectExtras, @BillSubcontractorAmount, @ChargesWater, @ChargesWaterAmount, @ChargesDisposal, @ChargesDisposalAmount, @COMPANY_ID);
SELECT ProjectID, SaleBidProject, SaleRFP, SaleSoleSource, SaleTermContract, SaleTermContractDetail, SaleOther, SaleOtherDetail, SaleGettingJob, BillPrice, BillMoney, BillBidHardDollar, BillPerUnit, BillHourly, BillExpectExtras, BillSubcontractorAmount, ChargesWater, ChargesWaterAmount, ChargesDisposal, ChargesDisposalAmount, COMPANY_ID FROM LFS_PROJECT_SALE_BILLING_PRICING WHERE (ProjectID = @ProjectID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleBidProject", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleBidProject", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleRFP", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleRFP", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleSoleSource", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleSoleSource", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleTermContract", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContract", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleTermContractDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContractDetail", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleOther", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOther", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleOtherDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOtherDetail", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleGettingJob", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleGettingJob", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillPrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPrice", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillMoney", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillMoney", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillBidHardDollar", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillBidHardDollar", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillPerUnit", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPerUnit", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillHourly", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BillHourly", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillExpectExtras", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillExpectExtras", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillSubcontractorAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "BillSubcontractorAmount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChargesWater", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWater", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChargesWaterAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWaterAmount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChargesDisposal", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposal", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChargesDisposalAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposalAmount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT_SALE_BILLING_PRICING] SET [ProjectID] = @ProjectID, [Sa" +
                "leBidProject] = @SaleBidProject, [SaleRFP] = @SaleRFP, [SaleSoleSource] = @SaleS" +
                "oleSource, [SaleTermContract] = @SaleTermContract, [SaleTermContractDetail] = @S" +
                "aleTermContractDetail, [SaleOther] = @SaleOther, [SaleOtherDetail] = @SaleOtherD" +
                "etail, [SaleGettingJob] = @SaleGettingJob, [BillPrice] = @BillPrice, [BillMoney]" +
                " = @BillMoney, [BillBidHardDollar] = @BillBidHardDollar, [BillPerUnit] = @BillPe" +
                "rUnit, [BillHourly] = @BillHourly, [BillExpectExtras] = @BillExpectExtras, [Bill" +
                "SubcontractorAmount] = @BillSubcontractorAmount, [ChargesWater] = @ChargesWater," +
                " [ChargesWaterAmount] = @ChargesWaterAmount, [ChargesDisposal] = @ChargesDisposa" +
                "l, [ChargesDisposalAmount] = @ChargesDisposalAmount, [COMPANY_ID] = @COMPANY_ID " +
                "WHERE (([ProjectID] = @Original_ProjectID) AND ([SaleBidProject] = @Original_Sal" +
                "eBidProject) AND ([SaleRFP] = @Original_SaleRFP) AND ([SaleSoleSource] = @Origin" +
                "al_SaleSoleSource) AND ([SaleTermContract] = @Original_SaleTermContract) AND ((@" +
                "IsNull_SaleTermContractDetail = 1 AND [SaleTermContractDetail] IS NULL) OR ([Sal" +
                "eTermContractDetail] = @Original_SaleTermContractDetail)) AND ([SaleOther] = @Or" +
                "iginal_SaleOther) AND ((@IsNull_SaleOtherDetail = 1 AND [SaleOtherDetail] IS NUL" +
                "L) OR ([SaleOtherDetail] = @Original_SaleOtherDetail)) AND ((@IsNull_SaleGetting" +
                "Job = 1 AND [SaleGettingJob] IS NULL) OR ([SaleGettingJob] = @Original_SaleGetti" +
                "ngJob)) AND ((@IsNull_BillPrice = 1 AND [BillPrice] IS NULL) OR ([BillPrice] = @" +
                "Original_BillPrice)) AND ([BillMoney] = @Original_BillMoney) AND ((@IsNull_BillB" +
                "idHardDollar = 1 AND [BillBidHardDollar] IS NULL) OR ([BillBidHardDollar] = @Ori" +
                "ginal_BillBidHardDollar)) AND ([BillPerUnit] = @Original_BillPerUnit) AND ([Bill" +
                "Hourly] = @Original_BillHourly) AND ((@IsNull_BillExpectExtras = 1 AND [BillExpe" +
                "ctExtras] IS NULL) OR ([BillExpectExtras] = @Original_BillExpectExtras)) AND ((@" +
                "IsNull_BillSubcontractorAmount = 1 AND [BillSubcontractorAmount] IS NULL) OR ([B" +
                "illSubcontractorAmount] = @Original_BillSubcontractorAmount)) AND ([ChargesWater" +
                "] = @Original_ChargesWater) AND ((@IsNull_ChargesWaterAmount = 1 AND [ChargesWat" +
                "erAmount] IS NULL) OR ([ChargesWaterAmount] = @Original_ChargesWaterAmount)) AND" +
                " ([ChargesDisposal] = @Original_ChargesDisposal) AND ((@IsNull_ChargesDisposalAm" +
                "ount = 1 AND [ChargesDisposalAmount] IS NULL) OR ([ChargesDisposalAmount] = @Ori" +
                "ginal_ChargesDisposalAmount)) AND ([COMPANY_ID] = @Original_COMPANY_ID));\r\nSELEC" +
                "T ProjectID, SaleBidProject, SaleRFP, SaleSoleSource, SaleTermContract, SaleTerm" +
                "ContractDetail, SaleOther, SaleOtherDetail, SaleGettingJob, BillPrice, BillMoney" +
                ", BillBidHardDollar, BillPerUnit, BillHourly, BillExpectExtras, BillSubcontracto" +
                "rAmount, ChargesWater, ChargesWaterAmount, ChargesDisposal, ChargesDisposalAmoun" +
                "t, COMPANY_ID FROM LFS_PROJECT_SALE_BILLING_PRICING WHERE (ProjectID = @ProjectI" +
                "D)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleBidProject", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleBidProject", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleRFP", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleRFP", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleSoleSource", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleSoleSource", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleTermContract", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContract", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleTermContractDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContractDetail", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleOther", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOther", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleOtherDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOtherDetail", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SaleGettingJob", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleGettingJob", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillPrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPrice", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillMoney", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillMoney", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillBidHardDollar", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillBidHardDollar", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillPerUnit", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPerUnit", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillHourly", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BillHourly", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillExpectExtras", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillExpectExtras", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BillSubcontractorAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "BillSubcontractorAmount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChargesWater", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWater", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChargesWaterAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWaterAmount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChargesDisposal", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposal", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChargesDisposalAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposalAmount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleBidProject", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleBidProject", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleRFP", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleRFP", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleSoleSource", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleSoleSource", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleTermContract", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContract", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SaleTermContractDetail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContractDetail", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleTermContractDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleTermContractDetail", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleOther", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOther", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SaleOtherDetail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOtherDetail", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleOtherDetail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleOtherDetail", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SaleGettingJob", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleGettingJob", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SaleGettingJob", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SaleGettingJob", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BillPrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPrice", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillPrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPrice", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillMoney", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillMoney", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BillBidHardDollar", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BillBidHardDollar", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillBidHardDollar", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillBidHardDollar", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillPerUnit", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BillPerUnit", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillHourly", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BillHourly", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BillExpectExtras", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BillExpectExtras", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillExpectExtras", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BillExpectExtras", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BillSubcontractorAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BillSubcontractorAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BillSubcontractorAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "BillSubcontractorAmount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChargesWater", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWater", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ChargesWaterAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWaterAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChargesWaterAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesWaterAmount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChargesDisposal", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposal", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ChargesDisposalAmount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposalAmount", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChargesDisposalAmount", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ChargesDisposalAmount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTSALEBILLINGPRICINGGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectSaleBillingPricingGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSaleBidProject. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>SaleBidProject</returns>
        public bool GetSaleBidProject(int projectId)
        {
            return (bool)GetRow(projectId)["SaleBidProject"];
        }



        /// <summary>
        /// GetSaleRFP. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>SaleRFP</returns>
        public bool GetSaleRFP(int projectId)
        {
            return (bool)GetRow(projectId)["SaleRFP"];
        }



        /// <summary>
        /// GetSaleSoleSource. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>SaleSoleSource</returns>
        public bool GetSaleSoleSource(int projectId)
        {
            return (bool)GetRow(projectId)["SaleSoleSource"];
        }



        /// <summary>
        /// GetSaleTermContract. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>SaleTermContract</returns>
        public bool GetSaleTermContract(int projectId)
        {
            return (bool)GetRow(projectId)["SaleTermContract"];
        }



        /// <summary>
        /// GetSaleTermContractDetail. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>SaleTermContractDetail or EMPTY</returns>
        public string GetSaleTermContractDetail(int projectId)
        {
            if (GetRow(projectId).IsNull("SaleTermContractDetail"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["SaleTermContractDetail"];
            }
        }



        /// <summary>
        /// GetSaleOther. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>SaleOther</returns>
        public bool GetSaleOther(int projectId)
        {
            return (bool)GetRow(projectId)["SaleOther"];
        }



        /// <summary>
        /// GetSaleOtherDetail. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>SaleOtherDetail or EMPTY</returns>
        public string GetSaleOtherDetail(int projectId)
        {
            if (GetRow(projectId).IsNull("SaleOtherDetail"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["SaleOtherDetail"];
            }
        }



        /// <summary>
        /// GetSaleGettingJob. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>SaleGettingJob or EMPTY</returns>
        public int? GetSaleGettingJob(int projectId)
        {
            if (GetRow(projectId).IsNull("SaleGettingJob"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["SaleGettingJob"];
            }
        }

        
        
        /// <summary>
        /// GetBillPrice. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>BillPrice or EMPTY</returns>
        public decimal? GetBillPrice(int projectId)
        {
            if (GetRow(projectId).IsNull("BillPrice"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["BillPrice"];
            }
        }



        /// <summary>
        /// GetBillMoney. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>BillMoney</returns>
        public string GetBillMoney(int projectId)
        {
            return (string)GetRow(projectId)["BillMoney"];
        }



        /// <summary>
        /// GetBillBidHardDollar. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>BillBidHardDollar or EMPTY</returns>
        public string GetBillBidHardDollar(int projectId)
        {
            if (GetRow(projectId).IsNull("BillBidHardDollar"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["BillBidHardDollar"];
            }
        }



        /// <summary>
        /// GetBillPerUnit. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>BillPerUnit</returns>
        public bool GetBillPerUnit(int projectId)
        {
            return (bool)GetRow(projectId)["BillPerUnit"];
        }



        /// <summary>
        /// GetBillHourly. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>BillHourly</returns>
        public bool GetBillHourly(int projectId)
        {
            return (bool)GetRow(projectId)["BillHourly"];
        }



        /// <summary>
        /// GetBillExpectExtras. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>BillExpectExtras or EMPTY</returns>
        public string GetBillExpectExtras(int projectId)
        {
            if (GetRow(projectId).IsNull("BillExpectExtras"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["BillExpectExtras"];
            }
        }



        /// <summary>
        /// GetBillSubcontractorAmount. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>BillSubcontractorAmount or EMPTY</returns>
        public decimal? GetBillSubcontractorAmount(int projectId)
        {
            if (GetRow(projectId).IsNull("BillSubcontractorAmount"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["BillSubcontractorAmount"];
            }
        }



        /// <summary>
        /// GetChargesWater. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ChargesWater</returns>
        public bool GetChargesWater(int projectId)
        {
            return (bool)GetRow(projectId)["ChargesWater"];
        }
        


        /// <summary>
        /// GetChargesWaterAmount. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ChargesWaterAmount or EMPTY</returns>
        public decimal? GetChargesWaterAmount(int projectId)
        {
            if (GetRow(projectId).IsNull("ChargesWaterAmount"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["ChargesWaterAmount"];
            }
        }



        /// <summary>
        /// GetChargesDisposal. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ChargesDisposal</returns>
        public bool GetChargesDisposal(int projectId)
        {
            return (bool)GetRow(projectId)["ChargesDisposal"];
        }



        /// <summary>
        /// GetChargesDisposalAmount. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ChargesDisposalAmount or EMPTY</returns>
        public decimal? GetChargesDisposalAmount(int projectId)
        {
            if (GetRow(projectId).IsNull("ChargesDisposalAmount"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["ChargesDisposalAmount"];
            }
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
        /// Update 2 - Sale/Billing/Pricing and Service
        /// </summary>
        public void Update2()
        {
            ProjectServiceGateway projectServiceGateway = new ProjectServiceGateway(Data);

            DataTable saleBillingPricingChanges = Table.GetChanges();
            DataTable serviceChanges = projectServiceGateway.Table.GetChanges();

            if ((saleBillingPricingChanges == null) && (serviceChanges == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectServiceGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectServiceGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectServiceGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((saleBillingPricingChanges != null) && (saleBillingPricingChanges.Rows.Count > 0))
                {
                    Adapter.Update(saleBillingPricingChanges);
                }

                if ((serviceChanges != null) && (serviceChanges.Rows.Count > 0))
                {
                    projectServiceGateway.Adapter.Update(serviceChanges);
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
