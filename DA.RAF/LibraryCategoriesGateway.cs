using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// LibraryCategoriesGateway
    /// </summary>
    public class LibraryCategoriesGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LibraryCategoriesGateway()
            : base("LIBRARY_CATEGORIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LibraryCategoriesGateway(DataSet data)
            : base(data, "LIBRARY_CATEGORIES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LibraryTDS();
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
            tableMapping.DataSetTable = "LIBRARY_CATEGORIES";
            tableMapping.ColumnMappings.Add("LIBRARY_CATEGORIES_ID", "LIBRARY_CATEGORIES_ID");
            tableMapping.ColumnMappings.Add("CATEGORY_NAME", "CATEGORY_NAME");
            tableMapping.ColumnMappings.Add("PARENT_ID", "PARENT_ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ACTIVE", "ACTIVE");
            tableMapping.ColumnMappings.Add("DEV_MATRIX_CATEGORIES_ID", "DEV_MATRIX_CATEGORIES_ID");
            tableMapping.ColumnMappings.Add("DEV_MATRIX_STUDY_ID", "DEV_MATRIX_STUDY_ID");
            tableMapping.ColumnMappings.Add("INHERIT_LIBRARY_LOGIN", "INHERIT_LIBRARY_LOGIN");
            tableMapping.ColumnMappings.Add("INHERIT_LIBRARY_LOGIN_WRITE", "INHERIT_LIBRARY_LOGIN_WRITE");
            tableMapping.ColumnMappings.Add("INHERIT_LIBRARY_LOGIN_ADMIN", "INHERIT_LIBRARY_LOGIN_ADMIN");
            this._adapter.TableMappings.Add(tableMapping);

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
        /// LoadAllByContactIdCompanyId
        /// </summary>
        /// <param name="contactId">contactId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByLibraryCategoriesId(int libraryCategoriesId, int companyId)
        {
            FillDataWithStoredProcedure("LIBRARY_CATEGORIES_RETURN_FOR_LIBRARY_CATEGORIES_ID", new SqlParameter("@library_categories_id", libraryCategoriesId), new SqlParameter("@company_id", companyId));  //Note: COMPANY_ID
            return Data;
        }


        
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public DataSet LoadAllByParentId(int parentId, int companyId)
        {
            FillDataWithStoredProcedure("LIBRARY_CATEGORIES_RETURN_FOR_PARENT_ID", new SqlParameter("@parent_id", parentId), new SqlParameter("@company_id", companyId)); //Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int libraryCategoriesId)
        {
            string filter = string.Format("LIBRARY_CATEGORIES_ID = {0}", libraryCategoriesId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.RAF.LibraryCategoriesGateway.GetRow");
            }
        }



        /// <summary>
        /// GetCategoryName
        /// </summary>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <returns>CategoryName</returns>
        public string GetCategoryName(int libraryCategoriesId)
        {
            return (string)GetRow(libraryCategoriesId)["CATEGORY_NAME"];
        }


        /// <summary>
        /// GetParentId
        /// </summary>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <returns>ParendId</returns>
        public int GetParentId(int libraryCategoriesId)
        {
            return (int)GetRow(libraryCategoriesId)["PARENT_ID"];
        }



        /// <summary>
        /// GetActive
        /// </summary>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <returns>ACTIVE</returns>
        public bool GetActive(int libraryCategoriesId)
        {
            return (bool)GetRow(libraryCategoriesId)["ACTIVE"];
        }



        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        public int CountByParentId(int parentId, int companyId)
        {
            return (int)ExecuteScalarWithStoredProcedure("LIBRARY_CATEGORIES_RETURN_COUNT_FOR_PARENT_ID", new SqlParameter("@parent_id", parentId), new SqlParameter("@company_id", companyId)); //Note: COMPANY_ID
        }
        


    }
}
