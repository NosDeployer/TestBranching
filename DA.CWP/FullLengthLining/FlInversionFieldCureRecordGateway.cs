using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlInversionFieldCureRecordGateway
    /// </summary>
    public class FlInversionFieldCureRecordGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlInversionFieldCureRecordGateway()
            : base("InversionFieldCureRecord")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlInversionFieldCureRecordGateway(DataSet data)
            : base(data, "InversionFieldCureRecord")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlInversionFieldCureRecordTDS();
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
            tableMapping.DataSetTable = "InversionFieldCureRecord";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("ReadingTime", "ReadingTime");
            tableMapping.ColumnMappings.Add("HeadFt", "HeadFt");
            tableMapping.ColumnMappings.Add("BoilerInF", "BoilerInF");
            tableMapping.ColumnMappings.Add("BoilerOutF", "BoilerOutF");
            tableMapping.ColumnMappings.Add("PumpFlow", "PumpFlow");
            tableMapping.ColumnMappings.Add("PumpPsi", "PumpPsi");
            tableMapping.ColumnMappings.Add("MH1Top", "MH1Top");
            tableMapping.ColumnMappings.Add("MH1Bot", "MH1Bot");
            tableMapping.ColumnMappings.Add("MH2Top", "MH2Top");
            tableMapping.ColumnMappings.Add("MH2Bot", "MH2Bot");
            tableMapping.ColumnMappings.Add("MH3Top", "MH3Top");
            tableMapping.ColumnMappings.Add("MH3Bot", "MH3Bot");
            tableMapping.ColumnMappings.Add("MH4Top", "MH4Top");
            tableMapping.ColumnMappings.Add("MH4Bot", "MH4Bot");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            
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
        /// LoadAllByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>data set</returns>
        public DataSet LoadAllByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FULLLENGTHLININGINVERSIONFIELCURERECORDGATEWAY_LOADALLBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>data set</returns>
        public DataSet LoadByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FULLLENGTHLININGINVERSIONFIELCURERECORDGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId, int refId)
        {
            string filter = string.Format("WorkID = {0} AND RefID = {1}", workId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLenthLining.FullLengthLiningInversionFieldCureRecordGateway.GetRow");
            }
        }



        /// <summary>
        /// GetReadingTime
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>ReadingTime or EMPTY</returns>
        public DateTime GetReadingTime(int workId, int refId)
        {
            return (DateTime)GetRow(workId, refId)["ReadingTime"];
        }



        /// <summary>
        /// GetReadingTime Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original ReadingTime or EMPTY</returns>
        public DateTime GetReadingTimeOriginal(int workId, int refId)
        {
            return (DateTime)GetRow(workId, refId)["ReadingTime", DataRowVersion.Original];   
        }



        /// <summary>
        /// GetHeadFt
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>HeadFt or EMPTY</returns>
        public decimal? GetHeadFt(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("HeadFt"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["HeadFt"];
            }            
        }



        /// <summary>
        /// GetHeadFt Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original HeadFt or EMPTY</returns>
        public decimal? GetHeadFtOriginal(int workId, int refId)
        {            
            if (GetRow(workId, refId).IsNull(Table.Columns["HeadFt"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["HeadFt", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBoilerInF
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>BoilerInF or EMPTY</returns>
        public decimal? GetBoilerInF(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("BoilerInF"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["BoilerInF"];
            }
        }



        /// <summary>
        /// GetBoilerInF Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original BoilerInF or EMPTY</returns>
        public decimal? GetBoilerInFOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["BoilerInF"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["BoilerInF", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBoilerOutF
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>BoilerOutF or EMPTY</returns>
        public decimal? GetBoilerOutF(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("BoilerOutF"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["BoilerOutF"];
            }
        }



        /// <summary>
        /// GetBoilerOutF Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original BoilerOutF or EMPTY</returns>
        public decimal? GetBoilerOutFOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["BoilerOutF"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["BoilerOutF", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPumpFlow
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>PumpFlow or EMPTY</returns>
        public decimal? GetPumpFlow(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("PumpFlow"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["PumpFlow"];
            }
        }



        /// <summary>
        /// GetPumpFlow Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original PumpFlow or EMPTY</returns>
        public decimal? GetPumpFlowOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["PumpFlow"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["PumpFlow", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPumpPsi
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>PumpPsi or EMPTY</returns>
        public decimal? GetPumpPsi(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("PumpPsi"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["PumpPsi"];
            }
        }



        /// <summary>
        /// GetPumpPsi Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original PumpPsi or EMPTY</returns>
        public decimal? GetPumpPsiOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["PumpPsi"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["PumpPsi", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMH1Top
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>MH1Top or EMPTY</returns>
        public decimal? GetMH1Top(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("MH1Top"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH1Top"];
            }
        }



        /// <summary>
        /// GetMH1Top Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MH1Top or EMPTY</returns>
        public decimal? GetMH1TopOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["MH1Top"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH1Top", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMH1Bot
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>MH1Bot or EMPTY</returns>
        public decimal? GetMH1Bot(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("MH1Bot"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH1Bot"];
            }
        }



        /// <summary>
        /// GetMH1Bot Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MH1Bot or EMPTY</returns>
        public decimal? GetMH1BotOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["MH1Bot"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH1Bot", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMH2Top
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>MH2Top or EMPTY</returns>
        public decimal? GetMH2Top(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("MH2Top"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH2Top"];
            }
        }



        /// <summary>
        /// GetMH2Top Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MH2Top or EMPTY</returns>
        public decimal? GetMH2TopOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["MH2Top"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH2Top", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMH2Bot
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>MH2Bot or EMPTY</returns>
        public decimal? GetMH2Bot(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("MH2Bot"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH2Bot"];
            }
        }



        /// <summary>
        /// GetMH2Bot Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MH2Bot or EMPTY</returns>
        public decimal? GetMH2BotOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["MH2Bot"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH2Bot", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMH3Top
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>MH3Top or EMPTY</returns>
        public decimal? GetMH3Top(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("MH3Top"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH3Top"];
            }
        }



        /// <summary>
        /// GetMH3Top Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MH3Top or EMPTY</returns>
        public decimal? GetMH3TopOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["MH3Top"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH3Top", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMH3Bot
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>MH3Bot or EMPTY</returns>
        public decimal? GetMH3Bot(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("MH3Bot"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH3Bot"];
            }
        }



        /// <summary>
        /// GetMH3Bot Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MH3Bot or EMPTY</returns>
        public decimal? GetMH3BotOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["MH3Bot"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH3Bot", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMH4Top
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>MH4Top or EMPTY</returns>
        public decimal? GetMH4Top(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("MH4Top"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH4Top"];
            }
        }



        /// <summary>
        /// GetMH4Top Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MH4Top or EMPTY</returns>
        public decimal? GetMH4TopOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["MH4Top"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH4Top", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMH4Bot
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>MH4Bot or EMPTY</returns>
        public decimal? GetMH4Bot(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("MH4Bot"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH4Bot"];
            }
        }



        /// <summary>
        /// GetMH4Bot Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MH4Bot or EMPTY</returns>
        public decimal? GetMH4BotOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["MH4Bot"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId, refId)["MH4Bot", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Comments", DataRowVersion.Original];
            }
        }



    }
}
