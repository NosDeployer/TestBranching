using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Subcontractors;

namespace LiquiForce.LFSLive.BL.Resources.Subcontractors
{
    /// <summary>
    /// SubcontractorsAddSubcontractors
    /// </summary>
    public class SubcontractorsAddSubcontractors: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorsAddSubcontractors()
            : base("Subcontractors")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorsAddSubcontractors(DataSet data)
            : base(data, "Subcontractors")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorsAddTDS();
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// Insert subcontractors
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <param name="udf">udf</param>
        /// <param name="active">active</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int companiesId, DateTime date, string name, bool udf, bool active, bool deleted, int companyId)
        {
            SubcontractorsAddTDS.SubcontractorsRow row = ((SubcontractorsAddTDS.SubcontractorsDataTable)Table).NewSubcontractorsRow();
            row.COMPANIES_ID = companiesId;
            row.Date = date;
            row.Name = name;
            row.Udf = udf;
            row.Active = active;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;

            ((SubcontractorsAddTDS.SubcontractorsDataTable)Table).AddSubcontractorsRow(row);
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////
               
        /// <summary>
        /// Save all subcontractors to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            SubcontractorsAddTDS subcontractorChanges = (SubcontractorsAddTDS)Data.GetChanges();

            if (subcontractorChanges.Subcontractors.Rows.Count > 0)
            {
                SubcontractorsAddSubcontractorsGateway subcontractorsAddSubcontractorsGateway = new SubcontractorsAddSubcontractorsGateway(subcontractorChanges);

                foreach (SubcontractorsAddTDS.SubcontractorsRow row in (SubcontractorsAddTDS.SubcontractorsDataTable)subcontractorChanges.Subcontractors)
                {
                    //Insert companies                   
                    SubcontractorsResoucesSubcontractors subcontractorsResoucesSubcontractors = new SubcontractorsResoucesSubcontractors(null);
                    subcontractorsResoucesSubcontractors.InsertDirect(row.COMPANIES_ID, row.Date, row.Name, row.Active, row.Udf, row.Deleted, row.COMPANY_ID);                    
                }
            }
        }



        /// <summary>
        /// Get a single subcontractor. If not exists, raise an exception
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <returns>SubcontractorsAddTDS.SubcontractorsRow</returns>
        private SubcontractorsAddTDS.SubcontractorsRow GetRow(int companiesId, DateTime date)
        {
            SubcontractorsAddTDS.SubcontractorsRow row = ((SubcontractorsAddTDS.SubcontractorsDataTable)Table).FindByCOMPANIES_IDDate(companiesId, date);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsAddSubcontractors.GetRow");
            }

            return row;
        }


    }
}
