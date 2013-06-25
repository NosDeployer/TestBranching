using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintVehicleLocationDaysGateway 
    /// </summary>
    public class PrintVehicleLocationDaysGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTOR
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrintVehicleLocationDaysGateway()
            : base("PrintVehicleLocationDays")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrintVehicleLocationDaysGateway(DataSet data)
            : base(data, "PrintVehicleLocationDays")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintVehicleLocationTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC CONSTRUCTOR
        //

        /// <summary>
        /// FillData
        /// </summary>
        public void FillData()
        {
            PrintVehicleLocationGateway printVehicleLocationGateway = new PrintVehicleLocationGateway(Data);

            foreach (PrintVehicleLocationTDS.PrintVehicleLocationRow vehicleRow in (PrintVehicleLocationTDS.PrintVehicleLocationDataTable)printVehicleLocationGateway.Table)
            {
                PrintVehicleLocationTDS.PrintVehicleLocationDaysRow daysRow = GetRowByUnitCodeCountryId(vehicleRow.UnitCode, vehicleRow.CountryID);

                if (daysRow == null)
                {
                    daysRow = ((PrintVehicleLocationTDS.PrintVehicleLocationDaysDataTable)Table).NewPrintVehicleLocationDaysRow();

                    daysRow.UnitCode = vehicleRow.UnitCode;
                    daysRow.CountryID = vehicleRow.CountryID;
                    daysRow.CountryName = vehicleRow.CountryName;
                    daysRow.Days = 1;
                    daysRow.LastDate = vehicleRow.Date_;
                    
                    ((PrintVehicleLocationTDS.PrintVehicleLocationDaysDataTable)Table).AddPrintVehicleLocationDaysRow(daysRow);
                }
                else
                {
                    if (daysRow.LastDate != vehicleRow.Date_)
                    {
                        daysRow.Days += 1;
                        daysRow.LastDate = vehicleRow.Date_;
                    }
                }

            }
        }



        /// <summary>
        /// GetRowByUnitCodeCountryId
        /// </summary>
        /// <param name="unitCode">unitCode</param>
        /// <param name="countryId">countryId</param>
        private PrintVehicleLocationTDS.PrintVehicleLocationDaysRow GetRowByUnitCodeCountryId(string unitCode, Int64 countryId)
        {
            foreach (PrintVehicleLocationTDS.PrintVehicleLocationDaysRow row in ((PrintVehicleLocationTDS.PrintVehicleLocationDaysDataTable)Table))
            {
                if ((row.UnitCode == unitCode) && (row.CountryID == countryId))
                {
                    return row;
                }
            }

            return null;
        }
    }
}
