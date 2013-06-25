using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Common;

namespace LiquiForce.LFSLive.BL.Resources.Common
{
    /// <summary>
    /// ResourceTypeViewDisplay
    /// </summary>
    public class ResourceTypeViewDisplay : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTypeViewDisplay()
            : base("LFS_RESOURCES_TYPE_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ResourceTypeViewDisplay(DataSet data)
            : base(data, "LFS_RESOURCES_TYPE_VIEW_DISPLAY")
        {
        }
                           


        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ResourceViewTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// GetColumnsByDefault
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsByDefault">inColumnsByDefault</param>
        /// <returns></returns>
        public string GetColumnsByDefault(string resourceType, int companyId, bool inColumnsByDefault)
        {
            ResourceTypeViewDisplayGateway resourceTypeViewDisplayGateway = new ResourceTypeViewDisplayGateway(Data);
            resourceTypeViewDisplayGateway.LoadByWorkTypeInColumnsByDefault(resourceType, companyId, inColumnsByDefault);
            
            string columnsByDefault = "";

            foreach (ResourceViewTDS.LFS_RESOURCES_TYPE_VIEW_DISPLAYRow row in (ResourceViewTDS.LFS_RESOURCES_TYPE_VIEW_DISPLAYDataTable)Table)
            {
                if ((row.ResourceType == resourceType) && (row.COMPANY_ID == companyId) && (row.Always))
                {
                    columnsByDefault = columnsByDefault + row.Column_ + ", ";
                }
            }

            columnsByDefault = columnsByDefault.Substring(0, columnsByDefault.Length - 2);

            return columnsByDefault;
        }
      

    }
}
