using System;
using System.Text.RegularExpressions;
using System.Data;


namespace LiquiForce.LFSLive.Tools
{
    /// <summary>
    /// Time
    /// </summary
    public class Time
    {
        ///////////////////////////////////////////////////////////////////////////
        /// PROPERTIES AND FIELDS
        /// 

        enum timeType { invalid, t1, t2 };

        // Regular expression 
        private const string patternT1 = "^([0-9]|[0-1][0-9]|[2][0-3])[:.](00|15|30|45)$";
        private const string patternT2 = "^([1-9]|1[0-2]|0[1-9])[:.](00|15|30|45) ?([aApP][mM])$";

        // Time parts
        private int hours;
        private int minutes;
        private string apm;

        // Time type
        private int type;



        ///////////////////////////////////////////////////////////////////////////
        /// CONSTRUCTORS
        /// 

        public Time()
        {
            // Initialize time parts
            hours = 0;
            minutes = 0;
            apm = "AM";

            // Type type
            type = (int)timeType.t1;
        }



        public Time(string time)
        {
            if (IsValidTimeInFormatT1(time))
            {
                type = (int)timeType.t1;
            }
            else if (IsValidTimeInFormatT2(time))
            {
                type = (int)timeType.t2;
            }
            else
            {
                type = (int)timeType.invalid;
            }

            switch (type)
            {
                case (int)timeType.t1:
                    #region timeType.t1
                    // Parse the time representation against the regular expression
                    Regex regexT1 = new Regex(patternT1);
                    Match matchT1 = regexT1.Match(time);

                    // Initialize time parts
                    GroupCollection groupCollectionT1 = matchT1.Groups;

                    // ... apm
                    apm = "";
                    // ... hours
                    hours = int.Parse(groupCollectionT1[1].Captures[0].Value);
                    // ... minutes
                    minutes = int.Parse(groupCollectionT1[2].Captures[0].Value);
                    #endregion
                    break;

                case (int)timeType.t2:
                    #region timeType.t2
                    // Parse the time representation against the regular expression
                    Regex regexT2 = new Regex(patternT2);
                    Match matchT2 = regexT2.Match(time);

                    //--- Initialize time parts
                    GroupCollection groupCollectionT2 = matchT2.Groups;

                    // ... apm
                    apm = groupCollectionT2[3].Captures[0].Value.ToUpper();
                    // ... hours
                    if (apm == "AM")
                    {
                        hours = int.Parse(groupCollectionT2[1].Captures[0].Value);
                    }
                    else
                    {
                        hours = int.Parse(groupCollectionT2[1].Captures[0].Value) + 12;
                    }
                    // ... minutes
                    minutes = int.Parse(groupCollectionT2[2].Captures[0].Value);
                    #endregion
                    break;

                case (int)timeType.invalid:
                    #region timeType.invalid
                    //Initialize time parts
                    apm = "";
                    hours = 0;
                    minutes = 0;
                    #endregion
                    break;
            }
        }



        public Time(DateTime dateTime)
        {
            type = (int) timeType.t1;
            hours = dateTime.Hour;
            minutes = dateTime.Minute;
            apm = "";
        }



        public Time(int hour, int minute)
        {
            type = (int) timeType.t1;
            hours = hour;
            minutes = minute;
            apm = "";
        }






        ///////////////////////////////////////////////////////////////////////////
        /// STATIC METHODS
        /// 

        public static bool IsValidTime(string time)
        {
            if (IsValidTimeInFormatT1(time))
            {
                return true;
            }
            else if (IsValidTimeInFormatT2(time))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static bool IsValidTimeInFormatT1(string time)
        {
            Regex regex = new Regex(patternT1);

            return regex.IsMatch(time.Trim());
        }



        public static bool IsValidTimeInFormatT2(string time)
        {
            Regex regex = new Regex(patternT2);

            return regex.IsMatch(time.Trim());
        }



        public static Time operator -(Time arg1, Time arg2)
        {
            // Convert arguments to XX:XX format
            if (arg1.type != (int)timeType.t1)
            {
                if (arg1.apm == "PM")
                {
                    arg1.hours += 12;
                }
            }

            if (arg2.type != (int)timeType.t1)
            {
                if (arg2.apm == "PM")
                {
                    arg2.hours += 12;
                }
            }

            // Subtract arguments
            DateTime dateArg1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Second, arg1.hours, arg1.minutes, 0);
            DateTime dateArg2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Second, arg2.hours, arg2.minutes, 0);
            TimeSpan dateResult;

            dateResult = dateArg1 - dateArg2;

            Time result = new Time(dateResult.Hours, dateResult.Minutes);

            // Return result
            return result;
        }






        ///////////////////////////////////////////////////////////////////////////
        /// METHODS
        /// 

        public override string ToString()
        {
            string hoursResult = (hours > 9) ? hours.ToString() : "0"+hours.ToString();
            string result = "0:00";

            if (type == (int) timeType.t1)
            {
                result = hoursResult + ":" + minutes.ToString();
            }
            else
            {
                result = hoursResult + ":" + minutes.ToString() + " "+apm;
            }

            return result;
        }



        public static string ToString24Format(DateTime ?time)
        {
            string time24 = "";

            if (time.HasValue)
            {
                if (time.Value.Hour < 10)
                {
                    time24 = "0" + time.Value.Hour.ToString() + ":";
                }
                else
                {
                    time24 = time.Value.Hour.ToString() + ":";
                }

                if (time.Value.Minute < 10)
                {
                    time24 += "0" + time.Value.Minute.ToString();
                }
                else
                {
                    time24 += time.Value.Minute.ToString();
                }
            }
                
            return time24;
        }

       

        public static DataSet GetTimeInterval()
        {
            // Create data set
            DataSet data = new DataSet("TimeInterval");

            // Create table
            DataTable table = new DataTable("TimeInterval");
            data.Tables.Add(table);

            // Declare DataColumn variable
            DataColumn column;

            // Create columns
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Time";
            table.Columns.Add(column);

            // Declare DataRow variable
            DataRow row;

            //Create rows
            row = table.NewRow();
            row["Time"] = "";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "12:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "12:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "12:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "12:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "1:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "1:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "1:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "1:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "2:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "2:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "2:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "2:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "3:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "3:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "3:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "3:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "4:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "4:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "4:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "4:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "5:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "5:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "5:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "5:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "6:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "6:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "6:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "6:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "7:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "7:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "7:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "7:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "8:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "8:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "8:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "8:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "9:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "9:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "9:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "9:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "10:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "10:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "10:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "10:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "11:00 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "11:15 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "11:30 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "11:45 AM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "12:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "12:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "12:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "12:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "1:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "1:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "1:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "1:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "2:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "2:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "2:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "2:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "3:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "3:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "3:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "3:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "4:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "4:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "4:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "4:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "5:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "5:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "5:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "5:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "6:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "6:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "6:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "6:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "7:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "7:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "7:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "7:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "8:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "8:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "8:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "8:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "9:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "9:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "9:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "9:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "10:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "10:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "10:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "10:45 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "11:00 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "11:15 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "11:30 PM";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Time"] = "11:45 PM";
            table.Rows.Add(row);

            //return
            return data;
        }
    }
}
