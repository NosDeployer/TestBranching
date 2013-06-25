using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerNavigator
    /// </summary>
    public class JlinerNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerNavigator()
            : base("JlinerNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerNavigator(DataSet data)
            : base(data, "JlinerNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinerNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="where">whereClause</param>
        /// <param name="orderBy">orderByClause</param>
        public void Load(string whereClause, string orderByClause)
        {
            JlinerNavigatorGateway jlinerNavigatorGateway = new JlinerNavigatorGateway(Data);
            jlinerNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id_">id_</param>
        /// <param name="selected">selected</param>
        public void Update(string id_, bool selected)
        {
            JlinerNavigatorTDS.JlinerNavigatorRow jlinerNavigatorRow = GetRow(id_);
            jlinerNavigatorRow.Selected = selected;
        }



        /// <summary>
        /// UpdateCommentsHistoryForReport
        /// </summary>
        public void UpdateCommentsHistoryForReport()
        {
            foreach (JlinerNavigatorTDS.JlinerNavigatorRow jlinerNavigatorRow in (JlinerNavigatorTDS.JlinerNavigatorDataTable)Table)
            {
                if (!jlinerNavigatorRow.IsCommentsNull())
                {
                    jlinerNavigatorRow.Comments = jlinerNavigatorRow.Comments.Replace("<br>", "\n");
                }
                if (!jlinerNavigatorRow.IsHistoryNull())
                {
                    jlinerNavigatorRow.History = jlinerNavigatorRow.History.Replace("<br>", "\n");
                }
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //



        /// <summary>
        /// Get a single jlinernavigator row. If not exists, raise an exception
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">RefID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>JlinerNavigatorTDS.JlinerNavigatorRow</returns>
        private JlinerNavigatorTDS.JlinerNavigatorRow GetRow(string id_)
        {
            JlinerNavigatorTDS.JlinerNavigatorRow row = ((JlinerNavigatorTDS.JlinerNavigatorDataTable)Table).FindByID_(id_);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.JlinerNavigator.GetRow");
            }

            return row;
        }



    }
}
