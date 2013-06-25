using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlAddLateralsSearch
    /// </summary>
    public class JlAddLateralsSearch : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlAddLateralsSearch() : base("JlAddLateralsSearch")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlAddLateralsSearch(DataSet data) : base(data, "JlAddLateralsSearch")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlAddLateralsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        public void Load(string whereClause, string orderByClause)
        {
            JlAddLateralsSearchGateway JlAddLateralsSearchGateway = new JlAddLateralsSearchGateway(Data);
            JlAddLateralsSearchGateway.Table.Clear();
            JlAddLateralsSearchGateway.ClearBeforeFill = true;
            JlAddLateralsSearchGateway.LoadWhereOrderBy(whereClause, orderByClause);
        }



    }
}

