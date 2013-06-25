using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    public class Print3ChartReportGateway : DataTableGateway
    {
        // CONSTRUCTORS
        public Print3ChartReportGateway()
            : base("Print3ChartReport")
        {
        }

        public Print3ChartReportGateway(DataSet data)
            : base(data, "Print3ChartReport")
        {
        }



        // INITIALIZERS
        protected override void InitData()
        {
            _data = new Print3ChartReportTDS();
        }

        protected override void InitAdapter()
        {
            #region Adapter initialization

            #endregion
        }



        // METHODS
        public void LoadByDateProjectTimeState(DateTime date, string projectTimeState)
        {
            Print3ChartReportTempGateway print3ChartReportTempGateway = new Print3ChartReportTempGateway(Data);

            // Load and insert for date-14
            print3ChartReportTempGateway.LoadByDateProjectTimeState(date.AddDays(-13), projectTimeState);
            foreach (Print3ChartReportTDS.Print3ChartReportTempRow tempRow in (Print3ChartReportTDS.Print3ChartReportTempDataTable)print3ChartReportTempGateway.Table)
            {
                // Find a report row
                Print3ChartReportTDS.Print3ChartReportRow reportRow = ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).FindByEmployeeID(tempRow.EmployeeID);
                
                // Update report row data
                if (reportRow == null)
                {
                    reportRow = ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).NewPrint3ChartReportRow();
                    reportRow.EmployeeID = tempRow.EmployeeID;
                    reportRow.FullName = tempRow.FullName;
                    reportRow.Sum14 = tempRow.ProjectTime;
                    ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).AddPrint3ChartReportRow(reportRow);
                }
                else
                {
                    reportRow.Sum14 = tempRow.ProjectTime;
                }
            }

            // Load and insert for date-7
            print3ChartReportTempGateway.LoadByDateProjectTimeState(date.AddDays(-6), projectTimeState);
            foreach (Print3ChartReportTDS.Print3ChartReportTempRow tempRow in (Print3ChartReportTDS.Print3ChartReportTempDataTable)print3ChartReportTempGateway.Table)
            {
                // Find a report row
                Print3ChartReportTDS.Print3ChartReportRow reportRow = ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).FindByEmployeeID(tempRow.EmployeeID);

                // Update report row data
                if (reportRow == null)
                {
                    reportRow = ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).NewPrint3ChartReportRow();
                    reportRow.EmployeeID = tempRow.EmployeeID;
                    reportRow.FullName = tempRow.FullName;
                    reportRow.Sum7 = tempRow.ProjectTime;
                    ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).AddPrint3ChartReportRow(reportRow);
                }
                else
                {
                    reportRow.Sum7 = tempRow.ProjectTime;
                }
            }

            // Load and insert for date-8
            print3ChartReportTempGateway.LoadByDateProjectTimeState(date.AddDays(-7), projectTimeState);
            foreach (Print3ChartReportTDS.Print3ChartReportTempRow tempRow in (Print3ChartReportTDS.Print3ChartReportTempDataTable)print3ChartReportTempGateway.Table)
            {
                // Find a report row
                Print3ChartReportTDS.Print3ChartReportRow reportRow = ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).FindByEmployeeID(tempRow.EmployeeID);

                // Update report row data
                if (reportRow == null)
                {
                    reportRow = ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).NewPrint3ChartReportRow();
                    reportRow.EmployeeID = tempRow.EmployeeID;
                    reportRow.FullName = tempRow.FullName;
                    reportRow.Sum8 = tempRow.ProjectTime;
                    ((Print3ChartReportTDS.Print3ChartReportDataTable)Table).AddPrint3ChartReportRow(reportRow);
                }
                else
                {
                    reportRow.Sum8 = tempRow.ProjectTime;
                }
            }
        }
    }
}
