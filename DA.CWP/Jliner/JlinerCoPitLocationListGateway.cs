using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Section;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// JlinerCoPitLocationListGateway
    /// </summary>
    public class JlinerCoPitLocationListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerCoPitLocationListGateway()
            : base("LFS_JUNCTION_LINER2_CO_PIT_LOCATION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerCoPitLocationListGateway(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_CO_PIT_LOCATION")
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
        /// <returns>Data</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERCOPITLOCATIONLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(string name)
        {
            string filter = string.Format("Name = {0}", name);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Jliner.JlinerCoPitLocationListGateway.GetRow");
            }
        }



        /// <summary>
        /// GetAbbreviation
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Abbreviation</returns>
        public string GetAbbreviation(string name, int companyId)
        {
            string commandText = "SELECT Abbreviation FROM LFS_JUNCTION_LINER2_CO_PIT_LOCATION WHERE (Name = @name) AND (COMPANY_ID = @companyId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@name", name));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));
            
            object abbreviation = ExecuteScalar(command);
            
            return (abbreviation != DBNull.Value) ? abbreviation.ToString() : " ";
        }



    }
}
