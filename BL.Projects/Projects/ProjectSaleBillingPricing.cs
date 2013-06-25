using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSaleBillingPricing
    /// </summary>
    public class ProjectSaleBillingPricing : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSaleBillingPricing() : base("LFS_PROJECT_SALE_BILLING_PRICING")
        {
        }

        


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectSaleBillingPricing(DataSet data) : base(data, "LFS_PROJECT_SALE_BILLING_PRICING")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="saleBidProject">saleBidProject</param>
        /// <param name="saleRFP">saleRFP</param>
        /// <param name="saleSoleSource">saleSoleSource</param>
        /// <param name="saleTermContract">saleTermContract</param>
        /// <param name="saleTermContractDetail">saleTermContractDetail</param>
        /// <param name="saleOther">saleOther</param>
        /// <param name="saleOtherDetail">saleOtherDetail</param>
        /// <param name="saleGettingJob">saleGettingJob</param>
        /// <param name="gettingJob">gettingJob</param>
        /// <param name="billPrice">billPrice</param>
        /// <param name="billMoney">billMoney</param>
        /// <param name="billBidHardDollar">billBidHardDollar</param>
        /// <param name="billPerUnit">billPerUnit</param>
        /// <param name="billHourly">billHourly</param>
        /// <param name="billExpectExtras">billExpectExtras</param>
        /// <param name="billSubcontractorAmount">billSubcontractorAmount</param>
        /// <param name="chargesWater">chargesWater</param>
        /// <param name="chargesWaterAmount">chargesWaterAmount</param>
        /// <param name="chargesDisposal">chargesDisposal</param>
        /// <param name="chargesDisposalAmount">chargesDisposalAmount</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int projectId, bool saleBidProject, bool saleRFP, bool saleSoleSource, bool saleTermContract, string saleTermContractDetail, bool saleOther, string saleOtherDetail, int? saleGettingJob, decimal? billPrice, string billMoney, string billBidHardDollar, bool billPerUnit, bool billHourly, string billExpectExtras, decimal? billSubcontractorAmount, bool chargesWater, decimal? chargesWaterAmount, bool chargesDisposal, decimal? chargesDisposalAmount, int companyId)
        {
            ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGRow lfsProjectSaleBillingPricingRow = ((ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGDataTable)Table).NewLFS_PROJECT_SALE_BILLING_PRICINGRow();
            lfsProjectSaleBillingPricingRow.ProjectID = projectId;
            lfsProjectSaleBillingPricingRow.SaleBidProject = saleBidProject;
            lfsProjectSaleBillingPricingRow.SaleRFP = saleRFP;
            lfsProjectSaleBillingPricingRow.SaleSoleSource = saleSoleSource;
            lfsProjectSaleBillingPricingRow.SaleTermContract = saleTermContract;
            if (saleTermContractDetail.Trim() != "") lfsProjectSaleBillingPricingRow.SaleTermContractDetail = saleTermContractDetail.Trim();
            lfsProjectSaleBillingPricingRow.SaleOther = saleOther;
            if (saleOtherDetail.Trim() != "") lfsProjectSaleBillingPricingRow.SaleOtherDetail = saleOtherDetail.Trim();
            if (saleGettingJob.HasValue) lfsProjectSaleBillingPricingRow.SaleGettingJob = (int) saleGettingJob;
            if (billPrice.HasValue) lfsProjectSaleBillingPricingRow.BillPrice = (decimal)billPrice;
            lfsProjectSaleBillingPricingRow.BillMoney = billMoney;
            if (billBidHardDollar.Trim() != "") lfsProjectSaleBillingPricingRow.BillBidHardDollar = billBidHardDollar.Trim();
            lfsProjectSaleBillingPricingRow.BillPerUnit = billPerUnit;
            lfsProjectSaleBillingPricingRow.BillHourly = billHourly;
            if (billExpectExtras.Trim() != "") lfsProjectSaleBillingPricingRow.BillExpectExtras = billExpectExtras.Trim();
            if (billSubcontractorAmount.HasValue) lfsProjectSaleBillingPricingRow.BillSubcontractorAmount = (decimal)billSubcontractorAmount;
            lfsProjectSaleBillingPricingRow.ChargesWater = chargesWater;
            if (chargesWaterAmount.HasValue) lfsProjectSaleBillingPricingRow.ChargesWaterAmount = (decimal) chargesWaterAmount;
            lfsProjectSaleBillingPricingRow.ChargesDisposal = chargesDisposal;
            if (chargesDisposalAmount.HasValue) lfsProjectSaleBillingPricingRow.ChargesDisposalAmount = (decimal)chargesDisposalAmount;
            lfsProjectSaleBillingPricingRow.COMPANY_ID = companyId;

            ((ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGDataTable)Table).AddLFS_PROJECT_SALE_BILLING_PRICINGRow(lfsProjectSaleBillingPricingRow);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="saleBidProject">saleBidProject</param>
        /// <param name="saleRFP">saleRFP</param>
        /// <param name="saleSoleSource">saleSoleSource</param>
        /// <param name="saleTermContract">saleTermContract</param>
        /// <param name="saleTermContractDetail">saleTermContractDetail</param>
        /// <param name="saleOther">saleOther</param>
        /// <param name="saleOtherDetail">saleOtherDetail</param>
        /// <param name="saleGettingJob">saleGettingJob</param>
        /// <param name="billPrice">billPrice</param>
        /// <param name="billMoney">billMoney</param>
        /// <param name="billBidHardDollar">billBidHardDollar</param>
        /// <param name="billPerUnit">billPerUnit</param>
        /// <param name="billHourly">billHourly</param>
        /// <param name="billExpectExtras">billExpectExtras</param>
        /// <param name="billSubcontractorAmount">billSubcontractorAmount</param>
        /// <param name="chargesWater">chargesWater</param>
        /// <param name="chargesWaterAmount">chargesWaterAmount</param>
        /// <param name="chargesDisposal">chargesDisposal</param>
        /// <param name="chargesDisposalAmount">chargesDisposalAmount</param>
        /// <param name="companyId">companyId</param>
        //public void Update(int projectId, bool saleBidProject, bool saleRFP, bool saleSoleSource, bool saleTermContract, string saleTermContractDetail, bool saleOther, string saleOtherDetail, int? saleGettingJob, decimal? billPrice, string billMoney, string billBidHardDollar, bool billPerUnit, bool billHourly, string billExpectExtras, decimal? billSubcontractorAmount, bool chargesWater, decimal? chargesWaterAmount, bool chargesDisposal, decimal? chargesDisposalAmount, int companyId)
        public void Update(int projectId, decimal? billPrice, string billMoney, decimal? billSubcontractorAmount, int companyId)     
        {
            ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGRow lfsProjectSaleBillingPricingRow = GetRow(projectId);

            //lfsProjectSaleBillingPricingRow.SaleBidProject = saleBidProject;
            //lfsProjectSaleBillingPricingRow.SaleRFP = saleRFP;
            //lfsProjectSaleBillingPricingRow.SaleSoleSource = saleSoleSource;
            //lfsProjectSaleBillingPricingRow.SaleTermContract = saleTermContract;
            //if (saleTermContractDetail.Trim() != "") lfsProjectSaleBillingPricingRow.SaleTermContractDetail = saleTermContractDetail.Trim(); else lfsProjectSaleBillingPricingRow.SetSaleTermContractDetailNull();
            //lfsProjectSaleBillingPricingRow.SaleOther = saleOther;
            //if (saleOtherDetail.Trim() != "") lfsProjectSaleBillingPricingRow.SaleOtherDetail = saleOtherDetail.Trim(); else lfsProjectSaleBillingPricingRow.SetSaleOtherDetailNull();
            //if (saleGettingJob.HasValue) lfsProjectSaleBillingPricingRow.SaleGettingJob = (int) saleGettingJob; else lfsProjectSaleBillingPricingRow.SetSaleGettingJobNull();
            if (billPrice.HasValue) lfsProjectSaleBillingPricingRow.BillPrice = (decimal)billPrice; else lfsProjectSaleBillingPricingRow.SetBillPriceNull();
            lfsProjectSaleBillingPricingRow.BillMoney = billMoney;
            //if (billBidHardDollar.Trim() != "") lfsProjectSaleBillingPricingRow.BillBidHardDollar = billBidHardDollar.Trim(); else lfsProjectSaleBillingPricingRow.SetBillBidHardDollarNull();
            //lfsProjectSaleBillingPricingRow.BillPerUnit = billPerUnit;
            //lfsProjectSaleBillingPricingRow.BillHourly = billHourly;
            //if (billExpectExtras.Trim() != "") lfsProjectSaleBillingPricingRow.BillExpectExtras = billExpectExtras.Trim(); else lfsProjectSaleBillingPricingRow.SetBillExpectExtrasNull();
            if (billSubcontractorAmount.HasValue) lfsProjectSaleBillingPricingRow.BillSubcontractorAmount = (decimal)billSubcontractorAmount; else lfsProjectSaleBillingPricingRow.SetBillSubcontractorAmountNull();
            //lfsProjectSaleBillingPricingRow.ChargesWater = chargesWater;
            //if (chargesWaterAmount.HasValue) lfsProjectSaleBillingPricingRow.ChargesWaterAmount = (decimal)chargesWaterAmount; else lfsProjectSaleBillingPricingRow.SetChargesWaterAmountNull();
            //lfsProjectSaleBillingPricingRow.ChargesDisposal = chargesDisposal;
            //if (chargesDisposalAmount.HasValue) lfsProjectSaleBillingPricingRow.ChargesDisposalAmount = (decimal)chargesDisposalAmount; else lfsProjectSaleBillingPricingRow.SetChargesDisposalAmountNull();
            lfsProjectSaleBillingPricingRow.COMPANY_ID = companyId;
        }



        /// <summary>
        /// UpdateBillPrice
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="billPrice">billPrice</param>
        public void UpdateBillPrice(int projectId, decimal? billPrice, string billMoney)
        {
            ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGRow lfsProjectSaleBillingPricingRow = GetRow(projectId);

            if (billPrice.HasValue) lfsProjectSaleBillingPricingRow.BillPrice = (decimal)billPrice; else lfsProjectSaleBillingPricingRow.SetBillPriceNull();
            lfsProjectSaleBillingPricingRow.BillMoney = billMoney;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_SALE:BILLING_PRICINGRow</returns>
        private ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGRow GetRow(int projectId)
        {
            ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGRow row = ((ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectSaleBillingPricing.GetRow");
            }

            return row;

        }



    }
}
