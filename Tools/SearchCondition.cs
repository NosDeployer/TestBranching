using System;
using System.Text.RegularExpressions;
using System.Data;

namespace LiquiForce.LFSLive.Tools
{
    /// <summary>
    /// SearchCondition
    /// </summary
    public class SearchCondition 
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        public SearchCondition()
        {
        }




       
        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// GetConditions
        /// </summary>
        /// <returns>Dataset</returns>
        public static DataSet GetConditions()
        {
            // Create data set
            DataSet data = new DataSet("Condition");

            // Create table
            DataTable table = new DataTable("Condition");
            data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ConditionKey";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ConditionText";
            table.Columns.Add(column);

            // Declare DataRow variable
            DataRow row;

            //Create rows
            row = table.NewRow();
            row["ConditionKey"] = "=";
            row["ConditionText"] = "equals to";
            table.Rows.Add(row);
            
            row = table.NewRow();
            row["ConditionKey"] = "<>";
            row["ConditionText"] = "not";
            table.Rows.Add(row);

            row = table.NewRow();
            row["ConditionKey"] = ">";
            row["ConditionText"] = "greater than";
            table.Rows.Add(row);

            row = table.NewRow();
            row["ConditionKey"] = ">=";
            row["ConditionText"] = "greater than & equals to";
            table.Rows.Add(row);

            row = table.NewRow();
            row["ConditionKey"] = "<";
            row["ConditionText"] = "less than";
            table.Rows.Add(row);

            row = table.NewRow();
            row["ConditionKey"] = "<=";
            row["ConditionText"] = "less than & equals to";
            table.Rows.Add(row);

            //return
            return data;
        }

    }
}
