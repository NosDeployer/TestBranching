using System;
using System.Text.RegularExpressions;

namespace LiquiForce.LFSLive.CWP.Tools
{
	public class Validator
	{
		///////////////////////////////////////////////////////////////////////////
		/// CONSTRUCTORS
		///

		//
		// Default
		//
		public Validator()
		{
		}


		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// IsValidDate
		//
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

		//
		// IsValidDecimal
		//
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

		//
		// IsValidDecimalForGrid
		//
		public static bool IsValidDecimalForGrid(string decimalRepresentation)
		{
			string pattern = @"^(\d*)(\.\d+)?$";
			
			Regex regex = new Regex(pattern);

			return regex.IsMatch(decimalRepresentation);
		}

		//
		// IsValidInt32
		//
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

		//
		// IsValidInt32
		//
		public static bool IsValidDouble(string doubleRepresentation)
		{
			try
			{
				Convert.ToDouble(doubleRepresentation);
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}


	}
}
