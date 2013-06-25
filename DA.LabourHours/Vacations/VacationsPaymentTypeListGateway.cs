using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsPaymentTypeListGateway
    /// </summary>
    public class VacationsPaymentTypeListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsPaymentTypeListGateway()
            : base("LFS_VACATION_PAYMENTTYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsPaymentTypeListGateway(DataSet data)
            : base(data, "LFS_VACATION_PAYMENTTYPE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            _adapter = new SqlDataAdapter("", DB.Connection);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_PAYMENTTYPELISTGATEWAY_LOAD", new SqlParameter("companyId", companyId));
            return Data;
        }
             

    
    }
}