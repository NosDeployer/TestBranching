using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetAddMaterialsInformation
    /// </summary>
    public class ProjectCombinedCostingSheetAddMaterialsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetAddMaterialsInformation()
            : base("CombinedMaterialsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetAddMaterialsInformation(DataSet data)
            : base(data, "CombinedMaterialsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }

        decimal transitionBuildCostCad = 175;
        decimal transitionBuildCostUsd = 185.5M;



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="works">works</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void Load(ArrayList works, ArrayList projects, DateTime startDate, DateTime endDate, int companyId)
        {
            int refId = 0;

            foreach (int projectId in projects)
            {
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                string project = projectGateway.GetName(projectId);

                // Foreach of Works (FLL, JL, PR, MH Rehab)
                foreach (string work_ in works)
                {
                    ProjectCostingSheetAddMaterialListGateway projectCostingSheetAddMaterialListGateway = new ProjectCostingSheetAddMaterialListGateway(Data);
                    projectCostingSheetAddMaterialListGateway.LoadByWork_(work_);

                    foreach (ProjectCostingSheetAddTDS.MaterialListRow materialListRow in (ProjectCostingSheetAddTDS.MaterialListDataTable)projectCostingSheetAddMaterialListGateway.Table)
                    {
                        string thickness1 = ""; if (!materialListRow.IsThicknessNull()) thickness1 = materialListRow.Thickness;
                        string size1 = ""; if (!materialListRow.IsSizeNull()) size1 = materialListRow.Size;
                        string length1 = ""; if (!materialListRow.IsLengthNull()) length1 = materialListRow.Length;
                        
                        DateTime newStartDate = new DateTime();
                        newStartDate = startDate;
                        DateTime newEndDate = new DateTime();
                        newEndDate = endDate;
                        string function_ = "";

                        ProjectCostingSheetAddMaterialPayPeriodGateway projectCostingSheetAddMaterialPayPeriodGateway = new ProjectCostingSheetAddMaterialPayPeriodGateway(Data);
                        projectCostingSheetAddMaterialPayPeriodGateway.LoadByStartDateEndDateMaterialId(startDate, endDate, materialListRow.MaterialID);

                        if (projectCostingSheetAddMaterialPayPeriodGateway.Table.Rows.Count > 0)
                        {
                            foreach (ProjectCostingSheetAddTDS.MaterialPayPeriodRow materialPayPeriodRow in (ProjectCostingSheetAddTDS.MaterialPayPeriodDataTable)projectCostingSheetAddMaterialPayPeriodGateway.Table)
                            {
                                newEndDate = materialPayPeriodRow.Date_.AddDays(-1);

                                ProjectCostingSheetAddOriginalMaterialGateway projectCostingSheetAddOriginalMaterialGateway = new ProjectCostingSheetAddOriginalMaterialGateway(Data);

                                switch (materialListRow.Description)
                                {
                                    case "Lateral / Misc Supplies":
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Misc Supplies", size1, thickness1, length1, newStartDate, newEndDate);
                                        function_ = "Install";
                                        break;

                                    case "Lateral / Cleanout Material":
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Cleanout Material", size1, thickness1, length1, newStartDate, newEndDate);
                                        function_ = "Other";
                                        break;

                                    case "Lateral / Backfill - Cleanout":
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Backfill Cleanut", size1, thickness1, length1, newStartDate, newEndDate);
                                        function_ = "Other";
                                        break;

                                    case "Lateral / Restoration & Crowle Cap":
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Restoration Crowle", size1, thickness1, length1, newStartDate, newEndDate);
                                        function_ = "Restoration";
                                        break;

                                    default:
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, work_, size1, thickness1, length1, newStartDate, newEndDate);
                                        function_ = "Install";
                                        break;
                                }

                                if (projectCostingSheetAddOriginalMaterialGateway.Table.Rows.Count > 0)
                                {
                                    double quantity = 0;
                                    decimal costCad = 0;
                                    decimal costUsd = 0;
                                    refId++;

                                    ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow newRow = ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).NewCombinedMaterialsInformationRow();
                                    GetMaterialData(newStartDate, newEndDate, materialListRow.MaterialID, work_, newRow);

                                    if (work_ == "Full Length Lining")
                                    {
                                        foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                        {
                                            double steelTapeLengt = 0;

                                            if (!originalRow.IsSteelTapeLengthNull())
                                            {
                                                Distance d2 = new Distance(originalRow.SteelTapeLength);
                                                steelTapeLengt = d2.ToDoubleInEng3();
                                            }

                                            quantity = quantity + steelTapeLengt;
                                        }
                                    }

                                    if (work_ == "Point Repairs")
                                    {
                                        foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                        {
                                            quantity = quantity + 1;
                                        }
                                    }

                                    if (work_ == "Manhole Rehab")
                                    {
                                        foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                        {
                                            double totalSurfaceArea = 0;

                                            if (!originalRow.IsSizeNull())
                                            {
                                                Distance d2 = new Distance(originalRow.Size);
                                                totalSurfaceArea = d2.ToDoubleInEng3();
                                            }

                                            quantity = quantity + totalSurfaceArea;
                                        }
                                    }

                                    if (work_ == "Junction Lining")
                                    {
                                        if (materialListRow.Description == "Lateral / Misc Supplies" || materialListRow.Description == "Lateral / Cleanout Material" || materialListRow.Description == "Lateral / Backfill - Cleanout" || materialListRow.Description == "Lateral / Restoration & Crowle Cap")
                                        {
                                            foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                            {
                                                quantity = quantity + 1;
                                            }
                                        }
                                        else
                                        {
                                            foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                            {
                                                if (!originalRow.IsLinerSizeNull())
                                                {
                                                    // Ex: M1 Size = 6", Liner Size = 30' or 29'6"
                                                    if (!originalRow.LinerSize.ToLower().Contains("x"))
                                                    {
                                                        // 6"
                                                        string m1Size = "Junction Liner / Lateral " + originalRow.Size;
                                                        decimal m1SizeCostCad = GetCostCad(newStartDate, newEndDate, m1Size, work_, companyId);
                                                        decimal m1SizeCostUsd = GetCostUsd(newStartDate, newEndDate, m1Size, work_, companyId);

                                                        // 30' 
                                                        if (originalRow.LinerSize[originalRow.LinerSize.Length - 1] == '\'')
                                                        {
                                                            string linerSize = originalRow.LinerSize.Substring(0, originalRow.LinerSize.Length - 1);
                                                            decimal dmLinerSize = decimal.Parse(linerSize);

                                                            //newRow.CostCad = Cost (Main Size)
                                                            costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                            costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                        }
                                                        else
                                                        {
                                                            // or 29'6"
                                                            string linerSize = originalRow.LinerSize.Substring(0, originalRow.LinerSize.Length);
                                                            Distance dLinerSize = new Distance(linerSize);
                                                            double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                            decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                            dmLinerSize = Math.Ceiling(dmLinerSize);

                                                            //newRow.CostCad = Cost (Main Size)
                                                            costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                            costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        int numX = originalRow.LinerSize.ToLower().Split('x').Length - 1;

                                                        // Ex: Liner Size = 4" x 10' or 4" x 9'6" or (4" x 10') or (4" x 9'6") ==> M1 Size = 4"
                                                        if (numX == 1)
                                                        {
                                                            //4"
                                                            string m1Size = "";
                                                            int endIndexM1Size = originalRow.LinerSize.IndexOf('"');

                                                            //(....)
                                                            if (originalRow.LinerSize[0] == '(')
                                                            {
                                                                m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Substring(1, endIndexM1Size);
                                                                decimal m1SizeCostCad = GetCostCad(newStartDate, newEndDate, m1Size, work_, companyId);
                                                                decimal m1SizeCostUsd = GetCostUsd(newStartDate, newEndDate, m1Size, work_, companyId);

                                                                //9'6")
                                                                if (originalRow.LinerSize[originalRow.LinerSize.Length - 2] == '"')
                                                                {
                                                                    int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', startIndexLinerSize);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, (endIndexLinerSize + 1) - startIndexLinerSize);
                                                                    Distance dLinerSize = new Distance(linerSize);
                                                                    double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                    decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                                    dmLinerSize = Math.Ceiling(dmLinerSize);

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                    costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                                }
                                                                else
                                                                {
                                                                    //10')
                                                                    int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, endIndexLinerSize - startIndexLinerSize);
                                                                    decimal dmLinerSize = decimal.Parse(linerSize);

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                    costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //.....
                                                                m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Substring(0, endIndexM1Size);
                                                                decimal m1SizeCostCad = GetCostCad(newStartDate, newEndDate, m1Size, work_, companyId);
                                                                decimal m1SizeCostUsd = GetCostUsd(newStartDate, newEndDate, m1Size, work_, companyId);

                                                                //9'6"
                                                                if (originalRow.LinerSize[originalRow.LinerSize.Length - 1] == '"')
                                                                {
                                                                    int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', startIndexLinerSize);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, (endIndexLinerSize + 1) - startIndexLinerSize);
                                                                    Distance dLinerSize = new Distance(linerSize);
                                                                    double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                    decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                                    dmLinerSize = Math.Ceiling(dmLinerSize);

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                    costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                                }
                                                                else
                                                                {
                                                                    //10'
                                                                    int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, endIndexLinerSize - startIndexLinerSize);
                                                                    decimal dmLinerSize = decimal.Parse(linerSize);


                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                    costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // Ex: M1 Size = 6", Liner Size = 20' x (4" x 10') or 19'6" x (4" x 9'3") ==> M1 Size 2 = 4"
                                                            if (numX == 2)
                                                            {
                                                                if (originalRow.LinerSize[0] == '(')
                                                                {
                                                                    // Ex: M1 Size = 6", Liner Size = (6"x20')(4"x10') or (6"x19'6")(4"x10') or (6"x20')(4"x19'6"') or (6"x19'6")(4"x19'6"')
                                                                    //6"
                                                                    string m1Size = "";
                                                                    int endIndexM1Size = originalRow.LinerSize.Trim().IndexOf('"');
                                                                    m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(1, endIndexM1Size);

                                                                    decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                                    decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                                    decimal dmLinerSize = 0;

                                                                    //19'6"
                                                                    if (originalRow.LinerSize[originalRow.LinerSize.Trim().IndexOf(')', endIndexM1Size) - 1] == '"')
                                                                    {
                                                                        int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size) + 1;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                        Distance dLinerSize = new Distance(linerSize);
                                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                        dmLinerSize = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                    }
                                                                    else
                                                                    {
                                                                        //20'
                                                                        int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size) + 1;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, endIndexLinerSize - firtsXIndex);
                                                                        dmLinerSize = decimal.Parse(linerSize);
                                                                    }

                                                                    //4"
                                                                    int startIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('(', 1) + 1;
                                                                    int endIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('"', startIndexM1Size2);
                                                                    string m1Size2 = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(startIndexM1Size2, (endIndexM1Size2 + 1) - startIndexM1Size2);

                                                                    decimal m1Size2CostCad = GetCostCad(startDate, endDate, m1Size2, work_, companyId);
                                                                    decimal m1Size2CostUsd = GetCostUsd(startDate, endDate, m1Size2, work_, companyId);

                                                                    decimal dmLinerSize2 = 0;

                                                                    //9'6"
                                                                    if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf(')', endIndexM1Size2) - 1] == '"')
                                                                    {
                                                                        int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                        Distance dLinerSize = new Distance(linerSize);
                                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                        dmLinerSize2 = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                    }
                                                                    else
                                                                    {
                                                                        //10'
                                                                        int startIndexLinerSize2 = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                        int endIndexLinerSize2 = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize2);
                                                                        string linerSize2 = originalRow.LinerSize.Trim().Substring(startIndexLinerSize2, endIndexLinerSize2 - startIndexLinerSize2);
                                                                        dmLinerSize2 = decimal.Parse(linerSize2);
                                                                    }

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + transitionBuildCostCad + (m1SizeCostCad * dmLinerSize) + (m1Size2CostCad * dmLinerSize2);
                                                                    costUsd = newRow.CostUsd + transitionBuildCostUsd + (m1SizeCostUsd * dmLinerSize) + (m1Size2CostUsd * dmLinerSize2);
                                                                }
                                                                else
                                                                {
                                                                    //Ex: M1 Size = 6", Liner Size = 20' x (4" x 10') or 19'6" x (4" x 9'3") ==> M1 Size 2 = 4"
                                                                    //6"
                                                                    string m1Size = "Junction Liner / Lateral " + originalRow.Size;

                                                                    decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                                    decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                                    decimal dmLinerSize = 0;

                                                                    //19'6"
                                                                    if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf('x', 0) - 1] == '"')
                                                                    {
                                                                        int firtsXIndex = 0;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                        Distance dLinerSize = new Distance(linerSize);
                                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                        dmLinerSize = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                    }
                                                                    else
                                                                    {
                                                                        //20'
                                                                        int firtsXIndex = 0;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, endIndexLinerSize - firtsXIndex);
                                                                        dmLinerSize = decimal.Parse(linerSize);
                                                                    }

                                                                    //4"
                                                                    int startIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('(') + 1;
                                                                    int endIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('"', startIndexM1Size2);
                                                                    string m1Size2 = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(startIndexM1Size2, (endIndexM1Size2 + 1) - startIndexM1Size2);

                                                                    decimal m1Size2CostCad = GetCostCad(startDate, endDate, m1Size2, work_, companyId);
                                                                    decimal m1Size2CostUsd = GetCostUsd(startDate, endDate, m1Size2, work_, companyId);

                                                                    decimal dmLinerSize2 = 0;

                                                                    //9'6"
                                                                    if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf(')', endIndexM1Size2) - 1] == '"')
                                                                    {
                                                                        int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                        Distance dLinerSize = new Distance(linerSize);
                                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                        dmLinerSize2 = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                    }
                                                                    else
                                                                    {
                                                                        //10'
                                                                        int startIndexLinerSize2 = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                        int endIndexLinerSize2 = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize2);
                                                                        string linerSize2 = originalRow.LinerSize.Trim().Substring(startIndexLinerSize2, endIndexLinerSize2 - startIndexLinerSize2);
                                                                        dmLinerSize2 = decimal.Parse(linerSize2);
                                                                    }

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + transitionBuildCostCad + (m1SizeCostCad * dmLinerSize) + (m1Size2CostCad * dmLinerSize2);
                                                                    costUsd = newRow.CostUsd + transitionBuildCostUsd + (m1SizeCostUsd * dmLinerSize) + (m1Size2CostUsd * dmLinerSize2);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                ////
                                                if (materialListRow.Description != "Lateral / Misc Supplies" && materialListRow.Description != "Lateral / Cleanout Material" && materialListRow.Description != "Lateral / Backfill - Cleanout" && materialListRow.Description != "Lateral / Restoration & Crowle Cap")
                                                {
                                                    ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow newRow2 = ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).NewCombinedMaterialsInformationRow();
                                                    GetMaterialData(startDate, endDate, materialListRow.MaterialID, work_, newRow2);

                                                    newRow2.CostingSheetID = 0;
                                                    newRow2.RefID = refId;
                                                    newRow2.Quantity = 1;
                                                    newRow2.CostCad = costCad;
                                                    newRow2.CostUsd = costUsd;
                                                    newRow2.TotalCostCad = newRow2.CostCad;
                                                    newRow2.TotalCostUsd = newRow2.CostUsd;
                                                    newRow2.Deleted = false;
                                                    newRow2.COMPANY_ID = companyId;
                                                    newRow2.InDatabase = false;
                                                    newRow2.Process = work_;
                                                    newRow2.Description = materialListRow.Description;
                                                    newRow2.UnitOfMeasurement = "Each";
                                                    newRow2.StartDate = newStartDate;
                                                    newRow2.EndDate = newEndDate;
                                                    newRow2.FromDatabase = true;
                                                    newRow2.MaterialID = materialListRow.MaterialID;
                                                    refId++;
                                                    newRow2.Function_ = function_;
                                                    newRow2.WorkFunction = work_ + " . " + function_;
                                                    newRow2.ProjectID = projectId;
                                                    newRow2.Project = project;
                                                    ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).AddCombinedMaterialsInformationRow(newRow2);
                                                }
                                                ////
                                            }
                                        }
                                    }//JL

                                    if (work_ != "Junction Lining" || materialListRow.Description == "Lateral / Misc Supplies" || materialListRow.Description == "Lateral / Cleanout Material" || materialListRow.Description == "Lateral / Backfill - Cleanout" || materialListRow.Description == "Lateral / Restoration & Crowle Cap")
                                    {
                                        newRow.CostingSheetID = 0;
                                        newRow.RefID = refId;
                                        newRow.Quantity = quantity;
                                        newRow.TotalCostCad = (Convert.ToDecimal(quantity) * newRow.CostCad);
                                        newRow.TotalCostUsd = (Convert.ToDecimal(quantity) * newRow.CostUsd);
                                        newRow.Deleted = false;
                                        newRow.COMPANY_ID = companyId;
                                        newRow.InDatabase = false;
                                        newRow.Process = work_;
                                        newRow.Description = materialListRow.Description;
                                        if (work_ == "Point Repairs" || work_ == "Junction Lining")
                                        {
                                            newRow.UnitOfMeasurement = "Each";
                                        }
                                        else
                                        {
                                            if (work_ == "Manhole Rehab")
                                            {
                                                newRow.UnitOfMeasurement = "Square Foot";
                                            }
                                            {
                                                newRow.UnitOfMeasurement = materialListRow.UnitOfMeasurement;
                                            }
                                        }
                                        newRow.StartDate = newStartDate;
                                        newRow.EndDate = newEndDate;
                                        newRow.FromDatabase = true;
                                        newRow.MaterialID = materialListRow.MaterialID;
                                        newRow.Function_ = function_;
                                        newRow.WorkFunction = work_ + " . " + function_;
                                        newRow.ProjectID = projectId;
                                        newRow.Project = project;
                                        ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).AddCombinedMaterialsInformationRow(newRow);
                                    }
                                }

                                newStartDate = newEndDate.AddDays(1);
                            }

                            if (newEndDate <= endDate)
                            {
                                ProjectCostingSheetAddOriginalMaterialGateway projectCostingSheetAddOriginalMaterialGateway = new ProjectCostingSheetAddOriginalMaterialGateway(Data);

                                switch (materialListRow.Description)
                                {
                                    case "Lateral / Misc Supplies":
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Misc Supplies", size1, thickness1, length1, newStartDate, endDate);
                                        function_ = "Install";
                                        break;

                                    case "Lateral / Cleanout Material":
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Cleanout Material", size1, thickness1, length1, newStartDate, endDate);
                                        function_ = "Other";
                                        break;

                                    case "Lateral / Backfill - Cleanout":
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Backfill Cleanut", size1, thickness1, length1, newStartDate, endDate);
                                        function_ = "Other";
                                        break;

                                    case "Lateral / Restoration & Crowle Cap":
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Restoration Crowle", size1, thickness1, length1, newStartDate, endDate);
                                        function_ = "Restoration";
                                        break;

                                    default:
                                        projectCostingSheetAddOriginalMaterialGateway.Load(projectId, work_, size1, thickness1, length1, newStartDate, endDate);
                                        function_ = "Install";
                                        break;
                                }

                                if (projectCostingSheetAddOriginalMaterialGateway.Table.Rows.Count > 0)
                                {
                                    double quantity = 0;
                                    decimal costCad = 0;
                                    decimal costUsd = 0;
                                    refId++;

                                    ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow newRow = ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).NewCombinedMaterialsInformationRow();
                                    GetMaterialData(newStartDate, endDate, materialListRow.MaterialID, work_, newRow);

                                    if (work_ == "Full Length Lining")
                                    {
                                        foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                        {
                                            double steelTapeLengt = 0;

                                            if (!originalRow.IsSteelTapeLengthNull())
                                            {
                                                Distance d2 = new Distance(originalRow.SteelTapeLength);
                                                steelTapeLengt = d2.ToDoubleInEng3();
                                            }

                                            quantity = quantity + steelTapeLengt;
                                        }
                                    }

                                    if (work_ == "Point Repairs")
                                    {
                                        foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                        {
                                            quantity = quantity + 1;
                                        }
                                    }

                                    if (work_ == "Manhole Rehab")
                                    {
                                        foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                        {
                                            double totalSurfaceArea = 0;

                                            if (!originalRow.IsSizeNull())
                                            {
                                                Distance d2 = new Distance(originalRow.Size);
                                                totalSurfaceArea = d2.ToDoubleInEng3();
                                            }

                                            quantity = quantity + totalSurfaceArea;
                                        }
                                    }

                                    if (work_ == "Junction Lining")
                                    {
                                        if (materialListRow.Description == "Lateral / Misc Supplies" || materialListRow.Description == "Lateral / Cleanout Material" || materialListRow.Description == "Lateral / Backfill - Cleanout" || materialListRow.Description == "Lateral / Restoration & Crowle Cap")
                                        {
                                            foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                            {
                                                quantity = quantity + 1;
                                            }
                                        }
                                        else
                                        {
                                            foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                            {
                                                if (!originalRow.IsLinerSizeNull())
                                                {
                                                    // Ex: M1 Size = 6", Liner Size = 30' or 29'6"
                                                    if (!originalRow.LinerSize.ToLower().Contains("x"))
                                                    {
                                                        // 6"
                                                        string m1Size = "Junction Liner / Lateral " + originalRow.Size;
                                                        decimal m1SizeCostCad = GetCostCad(newStartDate, endDate, m1Size, work_, companyId);
                                                        decimal m1SizeCostUsd = GetCostUsd(newStartDate, endDate, m1Size, work_, companyId);

                                                        // 30' 
                                                        if (originalRow.LinerSize[originalRow.LinerSize.Length - 1] == '\'')
                                                        {
                                                            string linerSize = originalRow.LinerSize.Substring(0, originalRow.LinerSize.Length - 1);
                                                            decimal dmLinerSize = decimal.Parse(linerSize);

                                                            //newRow.CostCad = Cost (Main Size)
                                                            costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                            costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                        }
                                                        else
                                                        {
                                                            // or 29'6"
                                                            string linerSize = originalRow.LinerSize.Substring(0, originalRow.LinerSize.Length);
                                                            Distance dLinerSize = new Distance(linerSize);
                                                            double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                            decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                            dmLinerSize = Math.Ceiling(dmLinerSize);

                                                            //newRow.CostCad = Cost (Main Size)
                                                            costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                            costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        int numX = originalRow.LinerSize.ToLower().Split('x').Length - 1;

                                                        // Ex: Liner Size = 4" x 10' or 4" x 9'6" or (4" x 10') or (4" x 9'6") ==> M1 Size = 4"
                                                        if (numX == 1)
                                                        {
                                                            //4"
                                                            string m1Size = "";
                                                            int endIndexM1Size = originalRow.LinerSize.IndexOf('"');

                                                            //(....)
                                                            if (originalRow.LinerSize[0] == '(')
                                                            {
                                                                m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Substring(1, endIndexM1Size);
                                                                decimal m1SizeCostCad = GetCostCad(newStartDate, endDate, m1Size, work_, companyId);
                                                                decimal m1SizeCostUsd = GetCostUsd(newStartDate, endDate, m1Size, work_, companyId);

                                                                //9'6")
                                                                if (originalRow.LinerSize[originalRow.LinerSize.Length - 2] == '"')
                                                                {
                                                                    int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', startIndexLinerSize);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, (endIndexLinerSize + 1) - startIndexLinerSize);
                                                                    Distance dLinerSize = new Distance(linerSize);
                                                                    double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                    decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                                    dmLinerSize = Math.Ceiling(dmLinerSize);

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                    costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                                }
                                                                else
                                                                {
                                                                    //10')
                                                                    int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, endIndexLinerSize - startIndexLinerSize);
                                                                    decimal dmLinerSize = decimal.Parse(linerSize);

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                    costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //.....
                                                                m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Substring(0, endIndexM1Size);
                                                                decimal m1SizeCostCad = GetCostCad(newStartDate, endDate, m1Size, work_, companyId);
                                                                decimal m1SizeCostUsd = GetCostUsd(newStartDate, endDate, m1Size, work_, companyId);

                                                                //9'6"
                                                                if (originalRow.LinerSize[originalRow.LinerSize.Length - 1] == '"')
                                                                {
                                                                    int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', startIndexLinerSize);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, (endIndexLinerSize + 1) - startIndexLinerSize);
                                                                    Distance dLinerSize = new Distance(linerSize);
                                                                    double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                    decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                                    dmLinerSize = Math.Ceiling(dmLinerSize);

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                    costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                                }
                                                                else
                                                                {
                                                                    //10'
                                                                    int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, endIndexLinerSize - startIndexLinerSize);
                                                                    decimal dmLinerSize = decimal.Parse(linerSize);

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                    costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // Ex: M1 Size = 6", Liner Size = 20' x (4" x 10') or 19'6" x (4" x 9'3") ==> M1 Size 2 = 4"
                                                            if (numX == 2)
                                                            {
                                                                if (originalRow.LinerSize[0] == '(')
                                                                {
                                                                    // Ex: M1 Size = 6", Liner Size = (6"x20')(4"x10') or (6"x19'6")(4"x10') or (6"x20')(4"x19'6"') or (6"x19'6")(4"x19'6"')
                                                                    //6"
                                                                    string m1Size = "";
                                                                    int endIndexM1Size = originalRow.LinerSize.Trim().IndexOf('"');
                                                                    m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(1, endIndexM1Size);

                                                                    decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                                    decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                                    decimal dmLinerSize = 0;

                                                                    //19'6"
                                                                    if (originalRow.LinerSize[originalRow.LinerSize.Trim().IndexOf(')', endIndexM1Size) - 1] == '"')
                                                                    {
                                                                        int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size) + 1;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                        Distance dLinerSize = new Distance(linerSize);
                                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                        dmLinerSize = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                    }
                                                                    else
                                                                    {
                                                                        //20'
                                                                        int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size) + 1;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, endIndexLinerSize - firtsXIndex);
                                                                        dmLinerSize = decimal.Parse(linerSize);
                                                                    }

                                                                    //4"
                                                                    int startIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('(', 1) + 1;
                                                                    int endIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('"', startIndexM1Size2);
                                                                    string m1Size2 = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(startIndexM1Size2, (endIndexM1Size2 + 1) - startIndexM1Size2);

                                                                    decimal m1Size2CostCad = GetCostCad(startDate, endDate, m1Size2, work_, companyId);
                                                                    decimal m1Size2CostUsd = GetCostUsd(startDate, endDate, m1Size2, work_, companyId);

                                                                    decimal dmLinerSize2 = 0;

                                                                    //9'6"
                                                                    if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf(')', endIndexM1Size2) - 1] == '"')
                                                                    {
                                                                        int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                        Distance dLinerSize = new Distance(linerSize);
                                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                        dmLinerSize2 = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                    }
                                                                    else
                                                                    {
                                                                        //10'
                                                                        int startIndexLinerSize2 = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                        int endIndexLinerSize2 = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize2);
                                                                        string linerSize2 = originalRow.LinerSize.Trim().Substring(startIndexLinerSize2, endIndexLinerSize2 - startIndexLinerSize2);
                                                                        dmLinerSize2 = decimal.Parse(linerSize2);
                                                                    }

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + transitionBuildCostCad + (m1SizeCostCad * dmLinerSize) + (m1Size2CostCad * dmLinerSize2);
                                                                    costUsd = newRow.CostUsd + transitionBuildCostUsd + (m1SizeCostUsd * dmLinerSize) + (m1Size2CostUsd * dmLinerSize2);
                                                                }
                                                                else
                                                                {
                                                                    //Ex: M1 Size = 6", Liner Size = 20' x (4" x 10') or 19'6" x (4" x 9'3") ==> M1 Size 2 = 4"
                                                                    //6"
                                                                    string m1Size = "Junction Liner / Lateral " + originalRow.Size;

                                                                    decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                                    decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                                    decimal dmLinerSize = 0;

                                                                    //19'6"
                                                                    if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf('x', 0) - 1] == '"')
                                                                    {
                                                                        int firtsXIndex = 0;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                        Distance dLinerSize = new Distance(linerSize);
                                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                        dmLinerSize = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                    }
                                                                    else
                                                                    {
                                                                        //20'
                                                                        int firtsXIndex = 0;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, endIndexLinerSize - firtsXIndex);
                                                                        dmLinerSize = decimal.Parse(linerSize);
                                                                    }

                                                                    //4"
                                                                    int startIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('(') + 1;
                                                                    int endIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('"', startIndexM1Size2);
                                                                    string m1Size2 = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(startIndexM1Size2, (endIndexM1Size2 + 1) - startIndexM1Size2);

                                                                    decimal m1Size2CostCad = GetCostCad(startDate, endDate, m1Size2, work_, companyId);
                                                                    decimal m1Size2CostUsd = GetCostUsd(startDate, endDate, m1Size2, work_, companyId);

                                                                    decimal dmLinerSize2 = 0;

                                                                    //9'6"
                                                                    if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf(')', endIndexM1Size2) - 1] == '"')
                                                                    {
                                                                        int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                        int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                        string linerSize = originalRow.LinerSize.Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                        Distance dLinerSize = new Distance(linerSize);
                                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                        dmLinerSize2 = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                    }
                                                                    else
                                                                    {
                                                                        //10'
                                                                        int startIndexLinerSize2 = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                        int endIndexLinerSize2 = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize2);
                                                                        string linerSize2 = originalRow.LinerSize.Trim().Substring(startIndexLinerSize2, endIndexLinerSize2 - startIndexLinerSize2);
                                                                        dmLinerSize2 = decimal.Parse(linerSize2);
                                                                    }

                                                                    //newRow.CostCad = Cost (Main Size)
                                                                    costCad = newRow.CostCad + transitionBuildCostCad + (m1SizeCostCad * dmLinerSize) + (m1Size2CostCad * dmLinerSize2);
                                                                    costUsd = newRow.CostUsd + transitionBuildCostUsd + (m1SizeCostUsd * dmLinerSize) + (m1Size2CostUsd * dmLinerSize2);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                ////
                                                if (materialListRow.Description != "Lateral / Misc Supplies" && materialListRow.Description != "Lateral / Cleanout Material" && materialListRow.Description != "Lateral / Backfill - Cleanout" && materialListRow.Description != "Lateral / Restoration & Crowle Cap")
                                                {
                                                    ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow newRow2 = ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).NewCombinedMaterialsInformationRow();
                                                    GetMaterialData(startDate, endDate, materialListRow.MaterialID, work_, newRow2);

                                                    newRow2.CostingSheetID = 0;
                                                    newRow2.RefID = refId;
                                                    newRow2.Quantity = 1;
                                                    newRow2.CostCad = costCad;
                                                    newRow2.CostUsd = costUsd;
                                                    newRow2.TotalCostCad = newRow2.CostCad;
                                                    newRow2.TotalCostUsd = newRow2.CostUsd;
                                                    newRow2.Deleted = false;
                                                    newRow2.COMPANY_ID = companyId;
                                                    newRow2.InDatabase = false;
                                                    newRow2.Process = work_;
                                                    newRow2.Description = materialListRow.Description;
                                                    newRow2.UnitOfMeasurement = "Each";
                                                    newRow2.StartDate = newStartDate;
                                                    newRow2.EndDate = endDate;
                                                    newRow2.FromDatabase = true;
                                                    newRow2.MaterialID = materialListRow.MaterialID;
                                                    refId++;
                                                    newRow2.Function_ = function_;
                                                    newRow2.WorkFunction = work_ + " . " + function_;
                                                    newRow2.ProjectID = projectId;
                                                    newRow2.Project = project;
                                                    ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).AddCombinedMaterialsInformationRow(newRow2);
                                                }
                                                ////
                                            }
                                        }
                                    }

                                    if (work_ != "Junction Lining" || materialListRow.Description == "Lateral / Misc Supplies" || materialListRow.Description == "Lateral / Cleanout Material" || materialListRow.Description == "Lateral / Backfill - Cleanout" || materialListRow.Description == "Lateral / Restoration & Crowle Cap")
                                    {
                                        newRow.CostingSheetID = 0;
                                        newRow.RefID = refId;
                                        newRow.Quantity = quantity;
                                        newRow.TotalCostCad = (Convert.ToDecimal(quantity) * newRow.CostCad);
                                        newRow.TotalCostUsd = (Convert.ToDecimal(quantity) * newRow.CostUsd);
                                        newRow.Deleted = false;
                                        newRow.COMPANY_ID = companyId;
                                        newRow.InDatabase = false;
                                        newRow.Process = work_;
                                        newRow.Description = materialListRow.Description;
                                        if (work_ == "Point Repairs" || work_ == "Junction Lining")
                                        {
                                            newRow.UnitOfMeasurement = "Each";
                                        }
                                        else
                                        {
                                            if (work_ == "Manhole Rehab")
                                            {
                                                newRow.UnitOfMeasurement = "Square Foot";
                                            }
                                            {
                                                newRow.UnitOfMeasurement = materialListRow.UnitOfMeasurement;
                                            }
                                        }
                                        newRow.StartDate = newStartDate;
                                        newRow.EndDate = endDate;
                                        newRow.FromDatabase = true;
                                        newRow.MaterialID = materialListRow.MaterialID;
                                        newRow.Function_ = function_;
                                        newRow.WorkFunction = work_ + " . " + function_;
                                        newRow.ProjectID = projectId;
                                        newRow.Project = project;
                                        ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).AddCombinedMaterialsInformationRow(newRow);
                                    }
                                }
                            }
                        }
                        else
                        {
                            ProjectCostingSheetAddOriginalMaterialGateway projectCostingSheetAddOriginalMaterialGateway = new ProjectCostingSheetAddOriginalMaterialGateway(Data);

                            switch (materialListRow.Description)
                            {
                                case "Lateral / Misc Supplies":
                                    projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Misc Supplies", size1, thickness1, length1, startDate, endDate);
                                    function_ = "Install";
                                    break;

                                case "Lateral / Cleanout Material":
                                    projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Cleanout Material", size1, thickness1, length1, startDate, endDate);
                                    function_ = "Other";
                                    break;

                                case "Lateral / Backfill - Cleanout":
                                    projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Backfill Cleanut", size1, thickness1, length1, startDate, endDate);
                                    function_ = "Other";
                                    break;

                                case "Lateral / Restoration & Crowle Cap":
                                    projectCostingSheetAddOriginalMaterialGateway.Load(projectId, "Junction Lining Restoration Crowle", size1, thickness1, length1, startDate, endDate);
                                    function_ = "Restoration";
                                    break;

                                default:
                                    projectCostingSheetAddOriginalMaterialGateway.Load(projectId, work_, size1, thickness1, length1, startDate, endDate);
                                    function_ = "Install";
                                    break;
                            }

                            if (projectCostingSheetAddOriginalMaterialGateway.Table.Rows.Count > 0)
                            {
                                double quantity = 0;
                                decimal costCad = 0;
                                decimal costUsd = 0;
                                refId++;

                                ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow newRow = ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).NewCombinedMaterialsInformationRow();
                                GetMaterialData(startDate, endDate, materialListRow.MaterialID, work_, newRow);

                                if (work_ == "Full Length Lining")
                                {
                                    foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                    {
                                        double steelTapeLengt = 0;

                                        if (!originalRow.IsSteelTapeLengthNull())
                                        {
                                            Distance d2 = new Distance(originalRow.SteelTapeLength);
                                            steelTapeLengt = d2.ToDoubleInEng3();
                                        }

                                        quantity = quantity + steelTapeLengt;
                                    }
                                }

                                if (work_ == "Point Repairs")
                                {
                                    foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                    {
                                        quantity = quantity + 1;
                                    }
                                }

                                if (work_ == "Manhole Rehab")
                                {
                                    foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                    {
                                        double totalSurfaceArea = 0;

                                        if (!originalRow.IsSizeNull())
                                        {
                                            Distance d2 = new Distance(originalRow.Size);
                                            totalSurfaceArea = d2.ToDoubleInEng3();
                                        }

                                        quantity = quantity + totalSurfaceArea;
                                    }
                                }

                                if (work_ == "Junction Lining")
                                {
                                    if (materialListRow.Description == "Lateral / Misc Supplies" || materialListRow.Description == "Lateral / Cleanout Material" || materialListRow.Description == "Lateral / Backfill - Cleanout" || materialListRow.Description == "Lateral / Restoration & Crowle Cap")
                                    {
                                        foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                        {
                                            quantity = quantity + 1;
                                        }
                                    }
                                    else
                                    {
                                        foreach (ProjectCostingSheetAddTDS.OriginalMaterialRow originalRow in (ProjectCostingSheetAddTDS.OriginalMaterialDataTable)projectCostingSheetAddOriginalMaterialGateway.Table)
                                        {
                                            if (!originalRow.IsLinerSizeNull())
                                            {
                                                // Ex: M1 Size = 6", Liner Size = 30' or 29'6"
                                                if (!originalRow.LinerSize.ToLower().Contains("x"))
                                                {
                                                    // 6"
                                                    string m1Size = "Junction Liner / Lateral " + originalRow.Size;
                                                    decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                    decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                    // 30' 
                                                    if (originalRow.LinerSize[originalRow.LinerSize.Length - 1] == '\'')
                                                    {
                                                        string linerSize = originalRow.LinerSize.Substring(0, originalRow.LinerSize.Length - 1);
                                                        decimal dmLinerSize = decimal.Parse(linerSize);

                                                        //newRow.CostCad = Cost (Main Size)
                                                        costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                        costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                    }
                                                    else
                                                    {
                                                        // or 29'6"
                                                        string linerSize = originalRow.LinerSize.Substring(0, originalRow.LinerSize.Length);
                                                        Distance dLinerSize = new Distance(linerSize);
                                                        double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                        decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                        dmLinerSize = Math.Ceiling(dmLinerSize);

                                                        //newRow.CostCad = Cost (Main Size)
                                                        costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                        costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                    }
                                                }
                                                else
                                                {
                                                    int numX = originalRow.LinerSize.ToLower().Split('x').Length - 1;

                                                    // Ex: Liner Size = 4" x 10' or 4" x 9'6" or (4" x 10') or (4" x 9'6") ==> M1 Size = 4"
                                                    if (numX == 1)
                                                    {
                                                        //4"
                                                        string m1Size = "";
                                                        int endIndexM1Size = originalRow.LinerSize.Trim().IndexOf('"');

                                                        //(....)
                                                        if (originalRow.LinerSize[0] == '(')
                                                        {
                                                            m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(1, endIndexM1Size);
                                                            decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                            decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                            //9'6")
                                                            if (originalRow.LinerSize[originalRow.LinerSize.Length - 2] == '"')
                                                            {
                                                                int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', startIndexLinerSize);
                                                                string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, (endIndexLinerSize + 1) - startIndexLinerSize);
                                                                Distance dLinerSize = new Distance(linerSize);
                                                                double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                                dmLinerSize = Math.Ceiling(dmLinerSize);

                                                                //newRow.CostCad = Cost (Main Size)
                                                                costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                            }
                                                            else
                                                            {
                                                                //10')
                                                                int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize);
                                                                string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, endIndexLinerSize - startIndexLinerSize);
                                                                decimal dmLinerSize = decimal.Parse(linerSize);

                                                                //newRow.CostCad = Cost (Main Size)
                                                                costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //.....
                                                            m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(0, endIndexM1Size + 1);
                                                            decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                            decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                            //9'6"
                                                            if (originalRow.LinerSize[originalRow.LinerSize.Length - 1] == '"')
                                                            {
                                                                int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', startIndexLinerSize);
                                                                string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, (endIndexLinerSize + 1) - startIndexLinerSize);
                                                                Distance dLinerSize = new Distance(linerSize);
                                                                double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                decimal dmLinerSize = decimal.Parse(doubleLinerSize.ToString());
                                                                dmLinerSize = Math.Ceiling(dmLinerSize);

                                                                //newRow.CostCad = Cost (Main Size)
                                                                costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                            }
                                                            else
                                                            {
                                                                //10'
                                                                int startIndexLinerSize = originalRow.LinerSize.ToLower().Trim().IndexOf('x') + 1;
                                                                int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize);
                                                                string linerSize = originalRow.LinerSize.Trim().Substring(startIndexLinerSize, endIndexLinerSize - startIndexLinerSize);
                                                                decimal dmLinerSize = decimal.Parse(linerSize);

                                                                //newRow.CostCad = Cost (Main Size)
                                                                costCad = newRow.CostCad + (m1SizeCostCad * dmLinerSize);
                                                                costUsd = newRow.CostUsd + (m1SizeCostUsd * dmLinerSize);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // Ex: M1 Size = 6", Liner Size = 20' x (4" x 10') or 19'6" x (4" x 9'3") ==> M1 Size 2 = 4" or  M1 Size = 6", Liner Size = (6"x20')(4"x10') or (6"x19'6")(4"x10') or (6"x20')(4"x19'6"') or (6"x19'6")(4"x19'6"')
                                                        if (numX == 2)
                                                        {
                                                            if (originalRow.LinerSize[0] == '(')
                                                            {
                                                                // Ex: M1 Size = 6", Liner Size = (6"x20')(4"x10') or (6"x19'6")(4"x10') or (6"x20')(4"x19'6"') or (6"x19'6")(4"x19'6"')
                                                                //6"
                                                                string m1Size = "";
                                                                int endIndexM1Size = originalRow.LinerSize.Trim().IndexOf('"');
                                                                m1Size = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(1, endIndexM1Size);

                                                                decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                                decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                                decimal dmLinerSize = 0;

                                                                //19'6"
                                                                if (originalRow.LinerSize[originalRow.LinerSize.Trim().IndexOf(')', endIndexM1Size) - 1] == '"')
                                                                {
                                                                    int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size) + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                    Distance dLinerSize = new Distance(linerSize);
                                                                    double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                    dmLinerSize = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                }
                                                                else
                                                                {
                                                                    //20'
                                                                    int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size) + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', firtsXIndex);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, endIndexLinerSize - firtsXIndex);
                                                                    dmLinerSize = decimal.Parse(linerSize);
                                                                }

                                                                //4"
                                                                int startIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('(', 1) + 1;
                                                                int endIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('"', startIndexM1Size2);
                                                                string m1Size2 = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(startIndexM1Size2, (endIndexM1Size2 + 1) - startIndexM1Size2);

                                                                decimal m1Size2CostCad = GetCostCad(startDate, endDate, m1Size2, work_, companyId);
                                                                decimal m1Size2CostUsd = GetCostUsd(startDate, endDate, m1Size2, work_, companyId);

                                                                decimal dmLinerSize2 = 0;

                                                                //9'6"
                                                                if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf(')', endIndexM1Size2) - 1] == '"')
                                                                {
                                                                    int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                    Distance dLinerSize = new Distance(linerSize);
                                                                    double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                    dmLinerSize2 = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                }
                                                                else
                                                                {
                                                                    //10'
                                                                    int startIndexLinerSize2 = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                    int endIndexLinerSize2 = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize2);
                                                                    string linerSize2 = originalRow.LinerSize.Trim().Substring(startIndexLinerSize2, endIndexLinerSize2 - startIndexLinerSize2);
                                                                    dmLinerSize2 = decimal.Parse(linerSize2);
                                                                }

                                                                //newRow.CostCad = Cost (Main Size)
                                                                costCad = newRow.CostCad + transitionBuildCostCad + (m1SizeCostCad * dmLinerSize) + (m1Size2CostCad * dmLinerSize2);
                                                                costUsd = newRow.CostUsd + transitionBuildCostUsd + (m1SizeCostUsd * dmLinerSize) + (m1Size2CostUsd * dmLinerSize2);
                                                            }
                                                            else
                                                            {
                                                                //Ex: M1 Size = 6", Liner Size = 20' x (4" x 10') or 19'6" x (4" x 9'3") ==> M1 Size 2 = 4"
                                                                //6"
                                                                string m1Size = "Junction Liner / Lateral " + originalRow.Size;

                                                                decimal m1SizeCostCad = GetCostCad(startDate, endDate, m1Size, work_, companyId);
                                                                decimal m1SizeCostUsd = GetCostUsd(startDate, endDate, m1Size, work_, companyId);

                                                                decimal dmLinerSize = 0;

                                                                //19'6"
                                                                if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf('x', 0) - 1] == '"')
                                                                {
                                                                    int firtsXIndex = 0;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                    string linerSize = originalRow.LinerSize.Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                    Distance dLinerSize = new Distance(linerSize);
                                                                    double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                    dmLinerSize = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                }
                                                                else
                                                                {
                                                                    //20'
                                                                    int firtsXIndex = 0;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('\'', firtsXIndex);
                                                                    string linerSize = originalRow.LinerSize.Trim().Substring(firtsXIndex, endIndexLinerSize - firtsXIndex);
                                                                    dmLinerSize = decimal.Parse(linerSize);
                                                                }

                                                                //4"
                                                                int startIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('(') + 1;
                                                                int endIndexM1Size2 = originalRow.LinerSize.Trim().IndexOf('"', startIndexM1Size2);
                                                                string m1Size2 = "Junction Liner / Lateral " + originalRow.LinerSize.Trim().Substring(startIndexM1Size2, (endIndexM1Size2 + 1) - startIndexM1Size2);

                                                                decimal m1Size2CostCad = GetCostCad(startDate, endDate, m1Size2, work_, companyId);
                                                                decimal m1Size2CostUsd = GetCostUsd(startDate, endDate, m1Size2, work_, companyId);

                                                                decimal dmLinerSize2 = 0;

                                                                //9'6"
                                                                if (originalRow.LinerSize[originalRow.LinerSize.ToLower().Trim().IndexOf(')', endIndexM1Size2) - 1] == '"')
                                                                {
                                                                    int firtsXIndex = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                    int endIndexLinerSize = originalRow.LinerSize.Trim().IndexOf('"', firtsXIndex);
                                                                    string linerSize = originalRow.LinerSize.Substring(firtsXIndex, (endIndexLinerSize + 1) - firtsXIndex);

                                                                    Distance dLinerSize = new Distance(linerSize);
                                                                    double doubleLinerSize = dLinerSize.ToDoubleInEng3();
                                                                    dmLinerSize2 = Math.Ceiling(decimal.Parse(doubleLinerSize.ToString()));
                                                                }
                                                                else
                                                                {
                                                                    //10'
                                                                    int startIndexLinerSize2 = originalRow.LinerSize.ToLower().Trim().IndexOf('x', endIndexM1Size2) + 1;
                                                                    int endIndexLinerSize2 = originalRow.LinerSize.Trim().IndexOf('\'', startIndexLinerSize2);
                                                                    string linerSize2 = originalRow.LinerSize.Trim().Substring(startIndexLinerSize2, endIndexLinerSize2 - startIndexLinerSize2);
                                                                    dmLinerSize2 = decimal.Parse(linerSize2);
                                                                }

                                                                //newRow.CostCad = Cost (Main Size)
                                                                costCad = newRow.CostCad + transitionBuildCostCad + (m1SizeCostCad * dmLinerSize) + (m1Size2CostCad * dmLinerSize2);
                                                                costUsd = newRow.CostUsd + transitionBuildCostUsd + (m1SizeCostUsd * dmLinerSize) + (m1Size2CostUsd * dmLinerSize2);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            ////
                                            if (materialListRow.Description != "Lateral / Misc Supplies" && materialListRow.Description != "Lateral / Cleanout Material" && materialListRow.Description != "Lateral / Backfill - Cleanout" && materialListRow.Description != "Lateral / Restoration & Crowle Cap")
                                            {
                                                ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow newRow2 = ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).NewCombinedMaterialsInformationRow();
                                                GetMaterialData(startDate, endDate, materialListRow.MaterialID, work_, newRow2);

                                                newRow2.CostingSheetID = 0;
                                                newRow2.RefID = refId;
                                                newRow2.Quantity = 1;
                                                newRow2.CostCad = costCad;
                                                newRow2.CostUsd = costUsd;
                                                newRow2.TotalCostCad = newRow2.CostCad;
                                                newRow2.TotalCostUsd = newRow2.CostUsd;
                                                newRow2.Deleted = false;
                                                newRow2.COMPANY_ID = companyId;
                                                newRow2.InDatabase = false;
                                                newRow2.Process = work_;
                                                newRow2.Description = materialListRow.Description;
                                                newRow2.UnitOfMeasurement = "Each";
                                                newRow2.StartDate = startDate;
                                                newRow2.EndDate = endDate;
                                                newRow2.FromDatabase = true;
                                                newRow2.MaterialID = materialListRow.MaterialID;
                                                refId++;
                                                newRow2.Function_ = function_;
                                                newRow2.WorkFunction = work_ + " . " + function_;
                                                newRow2.ProjectID = projectId;
                                                newRow2.Project = project;
                                                ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).AddCombinedMaterialsInformationRow(newRow2);
                                            }
                                            ////
                                        }
                                    }
                                }

                                if (work_ != "Junction Lining" || materialListRow.Description == "Lateral / Misc Supplies" || materialListRow.Description == "Lateral / Cleanout Material" || materialListRow.Description == "Lateral / Backfill - Cleanout" || materialListRow.Description == "Lateral / Restoration & Crowle Cap")
                                {
                                    newRow.CostingSheetID = 0;
                                    newRow.RefID = refId;
                                    newRow.Quantity = quantity;
                                    newRow.TotalCostCad = (Convert.ToDecimal(quantity) * newRow.CostCad);
                                    newRow.TotalCostUsd = (Convert.ToDecimal(quantity) * newRow.CostUsd);
                                    newRow.Deleted = false;
                                    newRow.COMPANY_ID = companyId;
                                    newRow.InDatabase = false;
                                    newRow.Process = work_;
                                    newRow.Description = materialListRow.Description;
                                    if (work_ == "Point Repairs" || work_ == "Junction Lining")
                                    {
                                        newRow.UnitOfMeasurement = "Each";
                                    }
                                    else
                                    {
                                        if (work_ == "Manhole Rehab")
                                        {
                                            newRow.UnitOfMeasurement = "Square Foot";
                                        }
                                        {
                                            newRow.UnitOfMeasurement = materialListRow.UnitOfMeasurement;
                                        }
                                    }
                                    newRow.StartDate = startDate;
                                    newRow.EndDate = endDate;
                                    newRow.FromDatabase = true;
                                    newRow.MaterialID = materialListRow.MaterialID;
                                    newRow.Function_ = function_;
                                    newRow.WorkFunction = work_ + " . " + function_;
                                    newRow.ProjectID = projectId;
                                    newRow.Project = project;
                                    ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).AddCombinedMaterialsInformationRow(newRow);
                                }
                            }
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="process">process</param>
        /// <param name="description">description</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="function_">function_</param>
        /// <param name="workFunction">workFunction</param>
        public void Insert(int costingSheetId, int materialId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string process, string description, DateTime startDate, DateTime endDate, string function_, string workFunction, int projectId)
        {
            ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow row = ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).NewCombinedMaterialsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.MaterialID = materialId;
            row.RefID = GetNewRefId();
            row.UnitOfMeasurement = unitOfMeasurement;
            row.Quantity = quantity;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Process = process;
            row.Description = description;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;
            row.Function_ = function_;
            row.WorkFunction = workFunction;
            row.ProjectID = projectId;

            ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).AddCombinedMaterialsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="process">process</param>
        /// <param name="description">description</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="function_">function_</param>
        /// <param name="workFunction">workFunction</param>
        public void Update(int costingSheetId, int materialId, int refId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string process, string description, DateTime startDate, DateTime endDate, string function_, string workFunction)
        {
            ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow row = GetRow(costingSheetId, materialId, refId);

            row.UnitOfMeasurement = unitOfMeasurement;
            row.Quantity = quantity;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Process = process;
            row.Description = description;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.Function_ = function_;
            row.WorkFunction = workFunction;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int materialId, int refId)
        {
            ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow row = GetRow(costingSheetId, materialId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Materials Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS materialsInformationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (materialsInformationChanges.CombinedMaterialsInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow row in (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)materialsInformationChanges.CombinedMaterialsInformation)
                {
                    // Insert new costing sheet Materials 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCombinedCostingSheetMaterials materials = new ProjectCombinedCostingSheetMaterials(null);
                        materials.InsertDirect(costingSheetId, row.MaterialID, row.RefID, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Function_, row.ProjectID);
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
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow GetRow(int costingSheetId, int materialId, int refId)
        {
            ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow row = ((ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table).FindByCostingSheetIDMaterialIDRefID(costingSheetId, materialId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetAddMaterialsInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>newRefId</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow row in (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// GetMaterialData
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="materialId">v</param>
        /// <param name="work_">work_</param>
        /// <param name="newRow">newRow</param>
        private void GetMaterialData(DateTime startDate, DateTime endDate, int materialId, string work_, ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow newRow)
        {
            ProjectCostingSheetAddMaterialListGateway projectCostingSheetAddMaterialListGateway = new ProjectCostingSheetAddMaterialListGateway();
            projectCostingSheetAddMaterialListGateway.LoadByStartDateEndDateMaterialIdWork_(startDate, endDate, materialId, work_);

            if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
            {
                projectCostingSheetAddMaterialListGateway.LoadByStartDateEndDateMaterialId(startDate, endDate, materialId);
                if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                {
                    projectCostingSheetAddMaterialListGateway.LoadByStartDateMaterialIdWork_(startDate, materialId, work_);
                    if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                    {
                        projectCostingSheetAddMaterialListGateway.LoadByStartDateMaterialId(startDate, materialId);
                        if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                        {
                            projectCostingSheetAddMaterialListGateway.LoadByMaterialId(materialId);
                        }
                    }
                }
            }

            DataRow materialRow = projectCostingSheetAddMaterialListGateway.GetRow(materialId);
            newRow.CostUsd = (decimal)materialRow["CostUsd"];
            newRow.CostCad = (decimal)materialRow["CostCad"];
        }



        /// <summary>
        /// GetCostCad
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="description">description</param>
        /// <param name="work_">work_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>cost</returns>
        private decimal GetCostCad(DateTime startDate, DateTime endDate, string description, string work_, int companyId)
        {
            decimal cost = 0;
            MaterialsGateway materialsGateway = new MaterialsGateway();
            materialsGateway.LoadByDescription(description, companyId);

            if (materialsGateway.Table.Rows.Count > 0)
            {
                int materialId = materialsGateway.GetMaterialId(description);

                ProjectCostingSheetAddMaterialListGateway projectCostingSheetAddMaterialListGateway = new ProjectCostingSheetAddMaterialListGateway();
                projectCostingSheetAddMaterialListGateway.LoadByStartDateEndDateMaterialIdWork_(startDate, endDate, materialId, work_);

                if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                {
                    projectCostingSheetAddMaterialListGateway.LoadByStartDateEndDateMaterialId(startDate, endDate, materialId);
                    if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                    {
                        projectCostingSheetAddMaterialListGateway.LoadByStartDateMaterialIdWork_(startDate, materialId, work_);
                        if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                        {
                            projectCostingSheetAddMaterialListGateway.LoadByStartDateMaterialId(startDate, materialId);
                            if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                            {
                                projectCostingSheetAddMaterialListGateway.LoadByMaterialId(materialId);
                            }
                        }
                    }
                }

                DataRow materialRow = projectCostingSheetAddMaterialListGateway.GetRow(materialId);
                cost = (decimal)materialRow["CostCad"];
            }

            return cost;
        }



        /// <summary>
        /// GetCostUsd
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="description">description</param>
        /// <param name="work_">work_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>cost</returns>
        private decimal GetCostUsd(DateTime startDate, DateTime endDate, string description, string work_, int companyId)
        {
            decimal cost = 0;
            MaterialsGateway materialsGateway = new MaterialsGateway();
            materialsGateway.LoadByDescription(description, companyId);

            if (materialsGateway.Table.Rows.Count > 0)
            {
                int materialId = materialsGateway.GetMaterialId(description);

                ProjectCostingSheetAddMaterialListGateway projectCostingSheetAddMaterialListGateway = new ProjectCostingSheetAddMaterialListGateway();
                projectCostingSheetAddMaterialListGateway.LoadByStartDateEndDateMaterialIdWork_(startDate, endDate, materialId, work_);

                if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                {
                    projectCostingSheetAddMaterialListGateway.LoadByStartDateEndDateMaterialId(startDate, endDate, materialId);
                    if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                    {
                        projectCostingSheetAddMaterialListGateway.LoadByStartDateMaterialIdWork_(startDate, materialId, work_);
                        if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                        {
                            projectCostingSheetAddMaterialListGateway.LoadByStartDateMaterialId(startDate, materialId);
                            if (projectCostingSheetAddMaterialListGateway.Table.Rows.Count <= 0)
                            {
                                projectCostingSheetAddMaterialListGateway.LoadByMaterialId(materialId);
                            }
                        }
                    }
                }

                DataRow materialRow = projectCostingSheetAddMaterialListGateway.GetRow(materialId);
                cost = (decimal)materialRow["CostUsd"];
            }

            return cost;
        }



    }
}