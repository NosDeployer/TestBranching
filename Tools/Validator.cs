using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace LiquiForce.LFSLive.Tools
{
    /// <summary>
    /// Tools
    /// </summary>
	public class Validator
	{
		// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
		public Validator()
		{
		}






		// ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// IsValidDate
        /// </summary>
        /// <param name="dateRepresentation">dateRepresentation</param>
        /// <returns>bool</returns>
		public static bool IsValidDate(string dateRepresentation)
		{
			try
			{
				Convert.ToDateTime(dateRepresentation);
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}

		

        /// <summary>
        /// IsValidDecimal
        /// </summary>
        /// <param name="decimalRepresentation">decimalRepresentation</param>
        /// <returns>bool</returns>
		public static bool IsValidDecimal(string decimalRepresentation)
		{
			try
			{
				Convert.ToDecimal(decimalRepresentation);
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}

		

        /// <summary>
        /// IsValidDecimalForGrid
        /// </summary>
        /// <param name="decimalRepresentation">decimalRepresentation</param>
        /// <returns>bool</returns>
		public static bool IsValidDecimalForGrid(string decimalRepresentation)
		{
			string pattern = @"^(\d*)(\.\d+)?$";
			
			Regex regex = new Regex(pattern);

			return regex.IsMatch(decimalRepresentation);
		}



		/// <summary>
		/// IsValidInt32
		/// </summary>
		/// <param name="int32Representation">int32Representation</param>
		/// <returns>bool</returns>
		public static bool IsValidInt32(string int32Representation)
		{
			try
			{
				Convert.ToInt32(int32Representation);
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}



		/// <summary>
		/// IsValidDouble
		/// </summary>
		/// <param name="doubleRepresentation">doubleRepresentation</param>
		/// <returns>bool</returns>
		public static bool IsValidDouble(string doubleRepresentation)
		{
            string positiveValue = "";
			try
			{
                if (doubleRepresentation.Contains("-"))
                {
                    positiveValue = doubleRepresentation.Replace('-',' ').Trim();
                    Convert.ToDouble(positiveValue);
                }
                else
                {
                    Convert.ToDouble(doubleRepresentation);
                }

				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}



	}
}
