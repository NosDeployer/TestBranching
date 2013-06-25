using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsInformationBasicInformationGateway
    /// </summary>
    public class MaterialsInformationBasicInformationGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsInformationBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsInformationBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsInformationTDS();
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
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Size", "Size");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");                       
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
        /// LoadByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByMaterialId(int materialId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSINFORMATIONBASICINFORMATIONGATEWAY_LOADBYMATERIALID", new SqlParameter("@materialId", materialId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int materialId)
        {
            string filter = string.Format("MaterialID = {0}", materialId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Materials.MaterialsInformationBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Description or EMPTY</returns>
        public string GetDescription(int materialId)
        {
            if (GetRow(materialId).IsNull("Description"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Description"];
            }
        }



        /// <summary>
        /// GetDescription Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Original Description or EMPTY</returns>
        public string GetDescriptionOriginal(int materialId)
        {
            if (GetRow(materialId).IsNull(Table.Columns["Description"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Description", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSize
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Size or EMPTY</returns>
        public string GetSize(int materialId)
        {
            if (GetRow(materialId).IsNull("Size"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Size"];
            }
        }



        /// <summary>
        /// GetSize Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Original Size or EMPTY</returns>
        public string GetSizeOriginal(int materialId)
        {
            if (GetRow(materialId).IsNull(Table.Columns["Size"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Size", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Type or EMPTY</returns>
        public string GetType(int materialId)
        {
            if (GetRow(materialId).IsNull("Type"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Type"];
            }
        }



        /// <summary>
        /// GetType Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Original Type or EMPTY</returns>
        public string GetTypeOriginal(int materialId)
        {
            if (GetRow(materialId).IsNull(Table.Columns["Type"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Type", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>State or EMPTY</returns>
        public string GetState(int materialId)
        {
            if (GetRow(materialId).IsNull("State"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["State"];
            }
        }



        /// <summary>
        /// GetState Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Original State or EMPTY</returns>
        public string GetStateOriginal(int materialId)
        {
            if (GetRow(materialId).IsNull(Table.Columns["State"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["State", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetThickness
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Thickness or EMPTY</returns>
        public string GetThickness(int materialId)
        {
            if (GetRow(materialId).IsNull("Thickness"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Thickness"];
            }
        }



        /// <summary>
        /// GeteThickness Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Original Thickness or EMPTY</returns>
        public string GetThicknessOriginal(int materialId)
        {
            if (GetRow(materialId).IsNull(Table.Columns["Thickness"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Thickness", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLength
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Length or EMPTY</returns>
        public string GetLength(int materialId)
        {
            if (GetRow(materialId).IsNull("Length"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Length"];
            }
        }



        /// <summary>
        /// GeteLength Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Original Length or EMPTY</returns>
        public string GetLengthOriginal(int materialId)
        {
            if (GetRow(materialId).IsNull(Table.Columns["Length"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId)["Length", DataRowVersion.Original];
            }
        }


                
    }
}

