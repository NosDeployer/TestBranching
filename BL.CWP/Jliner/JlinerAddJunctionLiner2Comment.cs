using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerAddJunctionLiner2Comment
    /// </summary>
    public class JlinerAddJunctionLiner2Comment : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerAddJunctionLiner2Comment()
            : base("JunctionLiner2Comment")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerAddJunctionLiner2Comment(DataSet data)
            : base(data, "JunctionLiner2Comment")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinerAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Delete all comments for  a jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllCommentsForAJliner(Guid id, int refId, int companyId)
        {
            foreach (JlinerAddTDS.JunctionLiner2CommentRow row in (JlinerAddTDS.JunctionLiner2CommentDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    row.Deleted = true;
                }
            }
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public void Save(Guid id, int companyId)
        {
            JlinerAddTDS jlinerAddChanges = (JlinerAddTDS)Data.GetChanges();

            if (jlinerAddChanges != null)
            {
                if (jlinerAddChanges.JunctionLiner2Comment.Rows.Count > 0)
                {
                    JlinerAddJunctionLiner2CommentGateway jlinerAddJunctionLiner2CommentGateway = new JlinerAddJunctionLiner2CommentGateway(jlinerAddChanges);

                    foreach (JlinerAddTDS.JunctionLiner2CommentRow row in (JlinerAddTDS.JunctionLiner2CommentDataTable)jlinerAddChanges.JunctionLiner2Comment)
                    {
                        // Deleted lateral comments
                        if (row.Deleted)
                        {
                            JlinerComments jlinerComments = new JlinerComments(null);
                            jlinerComments.DeleteAllDirect(row.ID, row.RefID, companyId);
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>JlinerAddTDS.JunctionLiner2Row</returns>
        private JlinerAddTDS.JunctionLiner2Row GetRow(Guid id, int refId, int companyId)
        {
            JlinerAddTDS.JunctionLiner2Row row = ((JlinerAddTDS.JunctionLiner2DataTable)Table).FindByIDRefIDCOMPANY_ID(id, refId, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.Jliner.JlinerAddJunctionLiner2.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (JlinerAddTDS.JunctionLiner2Row row in (JlinerAddTDS.JunctionLiner2DataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }
    
    }
}
