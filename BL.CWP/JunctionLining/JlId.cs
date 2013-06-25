using System;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlId
    /// </summary>
    public class JlId
    {
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC FIELDS
        //

        public int assetId;
        public int sectionId;

        



        
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Deafult Constructor
        /// </summary>
        public JlId()
        {
            assetId = 0;
            sectionId = 0;
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="assetId_">AssetSewerLateral</param>
        /// <param name="sectionWorkId_">AssetSewerSection</param>
        public JlId(int assetId_, int sectionId_)
        {
            assetId = assetId_;
            sectionId = sectionId_;
        }



    }
}