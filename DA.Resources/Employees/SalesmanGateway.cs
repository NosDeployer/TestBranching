using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// SalesmanGateway
    /// </summary>
    public class SalesmanGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SalesmanGateway()
            : base("LFS_SALESMAN")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SalesmanGateway(DataSet data)
            : base(data, "LFS_SALESMAN")
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
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_SALESMAN";
            tableMapping.ColumnMappings.Add("SalesmanID", "SalesmanID");
            tableMapping.ColumnMappings.Add("IdForProjects", "IdForProjects");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_SALESMAN] WHERE (([SalesmanID] = @Original_SalesmanID) AND ([IdForProjects] = @Original_IdForProjects))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SalesmanID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesmanID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IdForProjects", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "IdForProjects", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_SALESMAN] ([SalesmanID], [IdForProjects]) VALUES (@SalesmanID, @IdForProjects);\r\nSELECT SalesmanID, IdForProjects FROM LFS_SALESMAN WHERE (SalesmanID = @SalesmanID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SalesmanID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesmanID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdForProjects", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "IdForProjects", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_SALESMAN] SET [SalesmanID] = @SalesmanID, [IdForProjects] = @IdForProjects WHERE (([SalesmanID] = @Original_SalesmanID) AND ([IdForProjects] = @Original_IdForProjects));SELECT SalesmanID, IdForProjects FROM LFS_SALESMAN WHERE (SalesmanID = @SalesmanID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SalesmanID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesmanID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdForProjects", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "IdForProjects", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SalesmanID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesmanID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IdForProjects", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "IdForProjects", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadBySalesmanId
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>Data</returns>
        public DataSet LoadBySalesmanId(int salesmanId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_SALESMANGATEWAY_LOADBYSALESMANID", new SqlParameter("@salesmanId", salesmanId));
            return Data;
        }



        /// <summary>
        /// LoadByIdForProjects
        /// </summary>
        /// <param name="idForProjects">idForProjects</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdForProjects(string idForProjects)
        {
            FillDataWithStoredProcedure("LFS_RESORUCES_SALESMANGATEWAY_LOADBYIDFORPROJECTS", new SqlParameter("@idForProjects", idForProjects));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int salesmanId)
        {
            string filter = string.Format("SalesmanID = {0}", salesmanId);
            return Table.Select(filter)[0];
        }



        /// <summary>
        /// GetIdForProjects
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>IdForProjects</returns>
        public string GetIdForProjects(int salesmanId)
        {
            return (string)GetRow(salesmanId)["IdForProjects"];
        }



        /// <summary>
        /// GetFullName
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>Full name</returns>
        public string GetFullName(int salesmanId)
        {
            return (string)GetRow(salesmanId)["FullName"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// LoadExpandedBySalesmanId
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>Data</returns>
        public DataSet LoadExpandedBySalesmanId(int salesmanId) //---------------- DEBERIA SER UN QUERY JUNTO AL DE ABAJO ???
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_SALESMANGATEWAY_LOADEXPANDEDBYSALESMANID", new SqlParameter("@salesmanId", salesmanId));
            return Data;
        }



        /// <summary>
        /// IsIdForProjectInUse
        /// </summary>
        /// <param name="idForProjects">idForProjects</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>bool</returns>
        public bool IsIdForProjectInUse(string idForProjects, int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_SALESMANGATEWAY_ISIDFORPROJECTINUSE", new SqlParameter("@idForProjects", idForProjects), new SqlParameter("@employeeId", employeeId));

            if ((int)Table.Rows[0]["No"] > 0)
            {
                return true;
            }
            return false;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a salesman (direct to DB)
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>       
        /// <param name="idForProjects">idForProjects</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int salesmanId, string idForProjects)
        {
            SqlParameter salesmanIdParameter = new SqlParameter("SalesmanID", salesmanId);
            SqlParameter idForProjectsParameter = (idForProjects.Trim() != "") ? new SqlParameter("IdForProjects", idForProjects.Trim()) : new SqlParameter("IdForProjects", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_SALESMAN] ([SalesmanID], [IdForProjects]) VALUES (@SalesmanID, @IdForProjects)";

            int rowsAffected = (int)ExecuteNonQuery(command, salesmanIdParameter, idForProjectsParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update service employee (direct to DB)
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>       
        /// <param name="originalIdForProjects">originalIdForProjects</param>
        /// <param name="newIdForProjects">newIdForProjects</param>
        /// <returns>rowsAffected</returns>
        public int Update(int salesmanId, string originalIdForProjects, string newIdForProjects)
        {
            SqlParameter originalSalesmanIdParameter = new SqlParameter("Original_SalesmanID", salesmanId);
            SqlParameter originalIdForProjectsParameter = (originalIdForProjects.Trim() != "") ? new SqlParameter("Original_IdForProjects", originalIdForProjects.Trim()) : new SqlParameter("Original_IdForProjects", DBNull.Value);

            SqlParameter newSalesmanIdParameter = new SqlParameter("SalesmanID", salesmanId);
            SqlParameter newIdForProjectsParameter = (newIdForProjects.Trim() != "") ? new SqlParameter("IdForProjects", newIdForProjects.Trim()) : new SqlParameter("IdForProjects", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_SALESMAN] SET [SalesmanID] = @SalesmanID, " +
                " [IdForProjects] = @IdForProjects " +
                " WHERE ([SalesmanID] = @Original_SalesmanID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalSalesmanIdParameter, originalIdForProjectsParameter, newSalesmanIdParameter, newIdForProjectsParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


    }
}
