using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlsNavigator
    /// </summary>
    public class JlsNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlsNavigator() : base("JlsNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlsNavigator(DataSet data) : base(data, "JlsNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlsNavigatorTDS();
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
            JlsNavigatorGateway jlsNavigatorGateway = new JlsNavigatorGateway(Data);
            jlsNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="selected">selected</param>
        public void Update(int workId, bool selected)
        {
            JlsNavigatorTDS.JlsNavigatorRow jlsNavigatorRow = GetRow(workId);
            jlsNavigatorRow.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>JlsNavigatorRow</returns>
        private JlsNavigatorTDS.JlsNavigatorRow GetRow(int workId)
        {
            JlsNavigatorTDS.JlsNavigatorRow row = ((JlsNavigatorTDS.JlsNavigatorDataTable)Table).FindByWorkID(workId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.JlsNavigator.GetRow");
            }

            return row;
        }



    }
}
