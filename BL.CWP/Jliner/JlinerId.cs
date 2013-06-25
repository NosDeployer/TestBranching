using System;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerId
    /// </summary>
    public class JlinerId
    {
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC FIELDS
        //

        public Guid id;

        public int refId;

        public int companyId;




        
        
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Deafult Constructor
        /// </summary>
        public JlinerId()
        {
            id = new Guid();
            refId = 0;
            companyId = 0;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id_">LFS_MASTER_AREA ID</param>
        /// <param name="refId_">LFS_JUNCTION_LINER2 ID</param>
        /// <param name="companyId_">COMPANY_ID</param>
        public JlinerId(Guid id_,  int refId_, int companyId_)
        {
            id = id_;
            refId = refId_;
            companyId = companyId_;
        }



    }
}
