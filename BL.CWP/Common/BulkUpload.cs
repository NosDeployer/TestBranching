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
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// BulkUpload
    /// </summary>
    public class BulkUpload : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public BulkUpload() : base("BulkUpload")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public BulkUpload(DataSet data)
            : base(data, "BulkUpload")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new BulkUploadTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="street">street</param>
        /// <param name="clientId">clientId</param>
        /// <param name="subArea">subArea</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="confirmedSize">confirmedSize</param>
        /// <param name="mapLength">mapLength</param>
        /// <param name="actualLength">actualLength</param>
        /// <param name="raWork">raWork</param>
        /// <param name="raComments">raComments</param>
        /// <param name="fllWork">fllWork</param>
        /// <param name="fllComments">fllComments</param>
        /// <param name="jlWork">jlWork</param>
        public void Insert(string id, string street, string clientId, string subArea, string usmh, string dsmh, string mapSize, string confirmedSize, string mapLength, string actualLength, bool raWork, string raComments, bool fllWork, string fllComments, bool jlWork)
        {
            BulkUploadTDS.BulkUploadRow row = ((BulkUploadTDS.BulkUploadDataTable)Table).NewBulkUploadRow();

            row.ID = id;
            if (street.Trim() != "") row.Street = street; else row.SetStreetNull();
            if (clientId.Trim() != "") row.ClientID = clientId; else row.SetClientIDNull();
            if (subArea.Trim() != "") row.SubArea = subArea; else row.SetSubAreaNull();
            if (usmh.Trim() != "") row.USMH = usmh; else row.SetUSMHNull();
            if (dsmh.Trim() != "") row.DSMH = dsmh; else row.SetDSMHNull();
            if (mapSize.Trim() != "") row.MapSize = mapSize; else row.SetMapSizeNull();
            if (confirmedSize.Trim() != "") row.ConfirmedSize = confirmedSize; else row.SetConfirmedSizeNull();
            if (mapLength.Trim() != "") row.MapLength = mapLength; else row.SetMapLengthNull();
            if (actualLength.Trim() != "") row.ActualLength = actualLength; else row.SetActualLengthNull();
            row.RAWork = raWork;
            if (raComments.Trim() != "") row.RAComments = raComments; else row.SetRACommentsNull();
            row.FLLWork = fllWork;
            if (fllComments.Trim() != "") row.FLLComments = fllComments; else row.SetFLLCommentsNull();
            row.JLWork = jlWork;
            
            ((BulkUploadTDS.BulkUploadDataTable)Table).AddBulkUploadRow(row);
        }



        
        /// <summary>
        /// GetSectionsSummary
        /// </summary>
        /// <param name="header">header</param>
        /// <returns></returns>
        public string GetSectionsSummary(string header)
        {
            string sectionsSummary = header + "\n";

            foreach (BulkUploadTDS.BulkUploadRow row in (BulkUploadTDS.BulkUploadDataTable)Table)
            {
                string street = "(empty)"; if (!row.IsStreetNull()) street = row.Street.Trim();
                string clientId = "(empty)"; if (!row.IsClientIDNull()) clientId = row.ClientID.Trim();
                string subArea = "(empty)"; if (!row.IsSubAreaNull()) subArea = row.SubArea.Trim();
                string usmh = "(empty)"; if (!row.IsUSMHNull()) usmh = row.USMH.Trim();
                string dsmh = "(empty)"; if (!row.IsDSMHNull()) dsmh = row.DSMH.Trim();
                
                // Get Works
                string works = "";
                if (row.RAWork) works = "Rehab Assessment";
                if (row.FLLWork)
                {
                    if (works.Length > 0)
                    {
                        works = works + ", Full Length Lining";
                    }
                    else
                    {
                        works = "Full Length Lining";
                    }
                }
                if (row.JLWork)
                {
                    if (works.Length > 0)
                    {
                        works = works + ",  Junction Lining";
                    }
                    else
                    {
                        works = "Junction Lining";
                    }
                }

                sectionsSummary = sectionsSummary + "- " + street + ", " + clientId + ", " + subArea + ", " + usmh + ", " + dsmh + ", " + works + "\n";
                
            }
            return sectionsSummary;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="loginId">loginId</param>
        public void Save(int projectId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId, int loginId)
        {
            foreach (BulkUploadTDS.BulkUploadRow row in (BulkUploadTDS.BulkUploadDataTable)Table)
            {
                int section_assetId = SaveSection(row, projectId, countryId, provinceId, countyId, cityId, companyId);

                if ((!row.IsClientIDNull()) && (!row.FLLWork)) row.FLLWork = true;

                if (row.RAWork)
                {
                    string raComments = ""; if (!row.IsRACommentsNull()) raComments = row.RAComments;
                    SaveRAWork(projectId, section_assetId, companyId, raComments, loginId);
                }

                if (row.FLLWork)
                {
                    string clientId = ""; if (!row.IsClientIDNull()) clientId = row.ClientID;
                    string fllComments = ""; if (!row.IsFLLCommentsNull()) fllComments = row.FLLComments;

                    SaveFLLWork(projectId, section_assetId, companyId, fllComments, loginId, clientId);
                }

                if (row.JLWork)
                {
                    SaveJLWork(projectId, section_assetId, companyId);
                }               
            }
        }

      

        /// <summary>
        /// Save a section
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>section_assetId</returns>
        private int SaveSection(BulkUploadTDS.BulkUploadRow row, int projectId, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            string street = ""; if (!row.IsStreetNull()) street = row.Street;            
            string subArea = ""; if (!row.IsSubAreaNull()) subArea = row.SubArea;
            string usmh = ""; if (!row.IsUSMHNull()) usmh = row.USMH;
            string dsmh = ""; if (!row.IsDSMHNull()) dsmh = row.DSMH;
            string mapLength = ""; if (!row.IsMapLengthNull()) mapLength = row.MapLength;
            string actualLength = ""; if (!row.IsActualLengthNull()) actualLength = row.ActualLength;
            string mapSize = ""; if (!row.IsMapSizeNull()) mapSize = row.MapSize;
            string confirmedSize = ""; if (!row.IsConfirmedSizeNull()) confirmedSize = row.ConfirmedSize;
            string thickness = "";

            // insert usmh (if not exists)
            int? usmh_assetId = null;
            if (usmh != "")
            {
                LfsAssetSewerMH lfsAssetSewerUsmh = new LfsAssetSewerMH(null);
                usmh_assetId = lfsAssetSewerUsmh.InsertDirect(countryId, provinceId, countyId, cityId, usmh, "", "", "", false, companyId, "", "", null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "", null);
            }

            // insert dsmh (if not exists)
            int? dsmh_assetId = null;
            if (dsmh != "")
            {
                LfsAssetSewerMH lfsAssetSewerDsmh = new LfsAssetSewerMH(null);
                dsmh_assetId = lfsAssetSewerDsmh.InsertDirect(countryId, provinceId, countyId, cityId, dsmh, "", "", "", false, companyId, "", "", null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "", null);
            }

            // insert section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            int section_assetId = lfsAssetSewerSection.InsertDirect(countryId, provinceId, countyId, cityId, row.ID, street, usmh_assetId, dsmh_assetId, mapSize, confirmedSize, mapLength, actualLength, null, null, "", "", "", "", "", actualLength, "", "", "", "", "", "", "", "", "", "", "", "", false, companyId, subArea, thickness, -1, "", DateTime.Now);

            return section_assetId;
        }



        /// <summary>
        /// SaveRAWork
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="subArea">subArea</param>
        /// <param name="comments">comments</param>
        /// <param name="loginId">loginId</param>
        private void SaveRAWork(int projectId, int section_assetId, int companyId, string comments, int loginId)
        {
            DateTime dateTime_ = DateTime.Now;
            string commentsToWork = "";

            if (comments != "")
            {
                // ... Get user name
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                // ... Form the comment string
                commentsToWork = commentsToWork + dateTime_ + "\n" + "(" + user.Trim() + ") \n Subject: Bulk Upload Comments \n Comment: " + comments;
            }

            WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
            int workId = workRehabAssessment.InsertDirect(projectId, section_assetId, null, null, null, false, companyId, commentsToWork, "");

            if (comments != "")
            {
                WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
                workCommentsGateway.LoadByWorkIdWorkType(workId, companyId, "Rehab Assessment");
                WorkComments workComments = new WorkComments(workCommentsGateway.Data);
                workComments.Insert(workId, 0, "Rehab Assessment", "Bulk Upload Comments", loginId, DateTime.Now, comments, null, false, companyId, false, "Rehab Assessment");

                // UpdateComments               
                workCommentsGateway.Update();
            }
        }



        /// <summary>
        /// SaveFLLWork
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comments">comments</param>
        /// <param name="loginId">loginId</param>
        /// <param name="clientId">clientId</param>
        private void SaveFLLWork(int projectId, int section_assetId, int companyId, string comments, int loginId, string clientId)
        {
            DateTime dateTime_ = DateTime.Now;
            string commentsToWork = "";
            
            if (comments != "")
            {
                // ... Get user name
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                // ... Form the comment string
                commentsToWork = commentsToWork + dateTime_ + "\n" + "(" + user.Trim() + ") \n Subject: Bulk Upload Comments \n Comment: " + comments;
            }

            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
            int workId = workFullLengthLining.InsertDirectEmptyWorks(projectId, section_assetId, null, clientId, null, null, null, null, null, null, null, false, false, false, false, false, false, false, companyId, false, commentsToWork, "");

            if (comments != "")
            {
                WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
                workCommentsGateway.LoadByWorkIdWorkType(workId, companyId, "Full Length Lining");
                WorkComments workComments = new WorkComments(workCommentsGateway.Data);
                workComments.Insert(workId, 0, "Other", "Bulk Upload Comments", loginId, dateTime_, comments, null, false, companyId, false, "Full Length Lining");
                
                // UpdateComments               
                workCommentsGateway.Update();
            }
        }



        /// <summary>
        /// Save a JL Work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        private void SaveJLWork(int projectId, int section_assetId, int companyId)
        {
            WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
            workJunctionLiningSection.InsertDirect(projectId, section_assetId, null, 0, 0, false, "No", 0, 0, false, companyId, "", "", "", "", false, "", 0);            
        }


                
    }
}