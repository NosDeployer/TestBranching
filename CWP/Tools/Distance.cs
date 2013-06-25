using System;
using System.Text.RegularExpressions;

namespace LiquiForce.LFSLive.CWP.Tools
{
	public class Distance
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		/// 

		// 
		// enum for distance type
		//
		enum distanceType {invalid, eng1, eng2, eng3, met1, mil1};

		//
		// Regular expression for parsing feet and inches in format X' Y''
		//
		private const string patternEng1 = "^([+-]?)\\s*(\\d*\\d)'\\s*(\\d|1[0-9])\"$|^([+-]?)\\s*(\\d*\\d)'$|^([+-]?)\\s*(\\d|1[0-9])\"$";
		private const string patternEng2 = "^([+-]?)\\s*(\\d*\\d)ft\\s*(\\d|1[0-9])in$|^([+-]?)\\s*(\\d*\\d)ft$|^([+-]?)\\s*(\\d|1[0-9])in$";
		private const string patternEng3 = "^([+-]?)\\s*(((\\d{1,3})(,\\d{3})*)|(\\d+))(\\.\\d+)?$";
        private const string patternMet1 = "^^([+-]?)\\s*(((\\d{1,3})(,\\d{3})*)|(\\d+))(\\.\\d+)?m$";
        private const string patternMil1 = "^^([+-]?)\\s*(((\\d{1,3})(,\\d{3})*)|(\\d+))(\\.\\d+)?mm$";       

		//
		// Distance parts
		//
		private string sign;
		private int feet1;
		private int inches1;
		private double feet2;
		private double meters;
        private double millimeters;

		//
		// Distance type
		//
		private int type;
		

		
		///////////////////////////////////////////////////////////////////////////
		/// CONSTRUCTORS
		/// 

		//
		// Default
		//
		public Distance()
		{
			//--- Initialize distance parts
			sign = "+";
			feet1 = 0;
			inches1 = 0;
			feet2 = 0;
			meters = 0;
            millimeters = 0;

			//--- Distance type
			type = (int) distanceType.eng1;
		}

		//
		// Overloaded
		//
		public Distance(string distance)
		{
            if (distance == "")
            {
                distance = "0.00";
            }

			if (IsValidDistanceInFormatEng1(distance))
			{
				type = (int) distanceType.eng1;
			}
			else if (IsValidDistanceInFormatEng2(distance))
			{
				type = (int) distanceType.eng2;
			}
			else if (IsValidDistanceInFormatEng3(distance))
			{
				type = (int) distanceType.eng3;
			}
			else if (IsValidDistanceInFormatMet1(distance))
			{
				type = (int) distanceType.met1;
			}
            else if (IsValidDistanceInFormatMil1(distance))
            {
                type = (int)distanceType.mil1;
            }
			else
			{
				type = (int) distanceType.invalid;
			}

			switch (type)
			{
				case (int) distanceType.eng1:
					#region distanceType.eng1
					//--- Parse the distance representation against the regular expression
					Regex regexEng1 = new Regex(patternEng1);
					Match matchEng1 = regexEng1.Match(distance);

					//--- Initialize distance parts
					GroupCollection groupCollectionEng1 = matchEng1.Groups;

					//--- ... sign
					if (groupCollectionEng1[1].Captures.Count > 0)
					{
						sign = (groupCollectionEng1[1].Captures[0].Value == "") ? "+" : groupCollectionEng1[1].Captures[0].Value;
					}
					else if (groupCollectionEng1[4].Captures.Count > 0)
					{
						sign = (groupCollectionEng1[4].Captures[0].Value == "") ? "+" : groupCollectionEng1[4].Captures[0].Value;
					}
					else
					{
						sign = (groupCollectionEng1[6].Captures[0].Value == "") ? "+" : groupCollectionEng1[6].Captures[0].Value;
					}

					//--- ... feet
					if (groupCollectionEng1[2].Captures.Count > 0)
					{
						feet1 = int.Parse(groupCollectionEng1[2].Captures[0].Value);
					}
					else if (groupCollectionEng1[5].Captures.Count > 0)
					{
						feet1 = int.Parse(groupCollectionEng1[5].Captures[0].Value);
					}
					else
					{
						feet1 = 0;
					}

					//--- ... inches
					if (groupCollectionEng1[3].Captures.Count > 0)
					{
						inches1 = int.Parse(groupCollectionEng1[3].Captures[0].Value);
					}
					else if (groupCollectionEng1[7].Captures.Count > 0)
					{
						inches1 = int.Parse(groupCollectionEng1[7].Captures[0].Value);
					}
					else
					{
						inches1 = 0;
					}

					//--- ... others
					/*feet2 = 0;
					meters = 0;*/
                    //--- ... others
                    feet2 = feet1 + (inches1 / (double)12);
                    meters = meters = (feet1 * 12 * 0.0254) + (inches1 * 0.0254);
                    millimeters = meters * 1000;
					#endregion
					break;

				case (int) distanceType.eng2:
					#region distanceType.eng2
					//--- Parse the distance representation against the regular expression
					Regex regexEng2 = new Regex(patternEng2);
					Match matchEng2 = regexEng2.Match(distance);

					//--- Initialize distance parts
					GroupCollection groupCollectionEng2 = matchEng2.Groups;

					//--- ... sign
					if (groupCollectionEng2[1].Captures.Count > 0)
					{
						sign = (groupCollectionEng2[1].Captures[0].Value == "") ? "+" : groupCollectionEng2[1].Captures[0].Value;
					}
					else if (groupCollectionEng2[4].Captures.Count > 0)
					{
						sign = (groupCollectionEng2[4].Captures[0].Value == "") ? "+" : groupCollectionEng2[4].Captures[0].Value;
					}
					else
					{
						sign = (groupCollectionEng2[6].Captures[0].Value == "") ? "+" : groupCollectionEng2[6].Captures[0].Value;
					}

					//--- ... feet
					if (groupCollectionEng2[2].Captures.Count > 0)
					{
						feet1 = int.Parse(groupCollectionEng2[2].Captures[0].Value);
					}
					else if (groupCollectionEng2[5].Captures.Count > 0)
					{
						feet1 = int.Parse(groupCollectionEng2[5].Captures[0].Value);
					}
					else
					{
						feet1 = 0;
					}

					//--- ... inches
					if (groupCollectionEng2[3].Captures.Count > 0)
					{
						inches1 = int.Parse(groupCollectionEng2[3].Captures[0].Value);
					}
					else if (groupCollectionEng2[7].Captures.Count > 0)
					{
						inches1 = int.Parse(groupCollectionEng2[7].Captures[0].Value);
					}
					else
					{
						inches1 = 0;
					}

					//--- ... others
					/*feet2 = 0;
					meters = 0;*/
                    //--- ... others
                    feet2 = feet1 + (inches1 / (double)12);
                    meters = (feet1 * 12 * 0.0254) + (inches1 * 0.0254);
                    millimeters = meters * 1000;
					#endregion
					break;

				case (int) distanceType.eng3:
					#region distanceType.eng3
					//--- Initialize distance parts
					distance = distance.Replace(" ","");

					//--- ... sign
					if ((distance.Substring(0,1) == "+") || (distance.Substring(0,1) == "-"))
					{
						sign = distance.Substring(0,1);
						distance = distance.Substring(1,distance.Length-1);
					}
					else 
					{
						sign = "+";
					}

					//--- ... feet
					feet2 = double.Parse(distance);

					//--- ... others
					/*feet1 = 0;
					inches1 = 0;
					meters = 0;*/
                    //--- ... others
                    feet1 = (int)feet2;
                    inches1 = (int)((feet2 - feet1) * 12);
                    meters = (feet1 * 12 * 0.0254) + (inches1 * 0.0254);
                    millimeters = meters * 1000;
					#endregion
					break;

				case (int) distanceType.met1:
					#region distanceType.met1
					//--- Initialize distance parts
					distance = distance.Replace(" ","");
					distance = distance.Substring(0,distance.Length-1);

					//--- ... sign
					if ((distance.Substring(0,1) == "+") || (distance.Substring(0,1) == "-"))
					{
						sign = distance.Substring(0,1);
						distance = distance.Substring(1,distance.Length-1);
					}
					else 
					{
						sign = "+";
					}

					//--- ... meters
					meters = double.Parse(distance);

					//--- ... others
                    feet2 = (meters * 39.37) / 12;
                    feet1 = (int)(meters * 39.37) / 12;
                    inches1 = (int)((feet2 - feet1) * 12);
                    millimeters = meters * 1000;
					#endregion
					break;

                case (int)distanceType.mil1:
                    #region distanceType.mil1
                    //--- Initialize distance parts
                    distance = distance.Replace(" ", "");
                    distance = distance.Substring(0, distance.Length - 2);

                    //--- ... sign
                    if ((distance.Substring(0, 1) == "+") || (distance.Substring(0, 1) == "-"))
                    {
                        sign = distance.Substring(0, 1);
                        distance = distance.Substring(1, distance.Length - 1);
                    }
                    else
                    {
                        sign = "+";
                    }

                    //--- ... milimeters
                    millimeters = double.Parse(distance);

                    //--- ... meters
                    meters = millimeters / 1000;

                    //--- ... others
                    feet2 = ((meters * 39.37) / 12);
                    feet1 = (int)(meters * 39.37) / 12;
                    inches1 = (int)Math.Round(((feet2 - feet1) * 12));
                    #endregion
                    break;

				case (int) distanceType.invalid:
					#region distanceType.invalid
					//--- Initialize distance parts
					sign = null;
					feet1 = 0;
					inches1 = 0;
					feet2 = 0;
					meters = 0;
                    millimeters = 0;
					#endregion
					break;
			}
		}



		///////////////////////////////////////////////////////////////////////////
		// STATIC METHODS
		// 

        /// <summary>
        /// Determine if a distance is in valid format
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
		public static bool IsValidDistance(string distance)
		{
			if (IsValidDistanceInFormatEng1(distance))
			{
				return true;
			}
			else if (IsValidDistanceInFormatEng2(distance))
			{
				return true;
			}
			else if (IsValidDistanceInFormatEng3(distance))
			{
				return true;
			}
			else if (IsValidDistanceInFormatMet1(distance))
			{
				return true;
			}
            else if (IsValidDistanceInFormatMil1(distance))
            {
                return true;
            }
			else
			{
				return false;
			}
		}

		//
		// IsValidDistanceInFormatEng1
		// Determine if a distance is in X' Y'' format
		//
		public static bool IsValidDistanceInFormatEng1(string distance)
		{
			Regex regex = new Regex(patternEng1);

			return regex.IsMatch(distance.Trim());
		}

		//
		// IsValidDistanceInFormatEng2
		// Determine if a distance is in Xft Yin format
		//
		public static bool IsValidDistanceInFormatEng2(string distance)
		{
			Regex regex = new Regex(patternEng2);

			return regex.IsMatch(distance.Trim());
		}

		//
		// IsValidDistanceInFormatEng3
		// Determine if a distance is in X.Y format
		//
		public static bool IsValidDistanceInFormatEng3(string distance)
		{
			Regex regex = new Regex(patternEng3);

			return regex.IsMatch(distance.Trim());
		}

		//
		// IsValidDistanceInFormatMet1
		// Determine if a distance is in X.Ym format
		//
		public static bool IsValidDistanceInFormatMet1(string distance)
		{
			Regex regex = new Regex(patternMet1);

			return regex.IsMatch(distance.Trim());
		}

        //
        // IsValidDistanceInFormatMil1
        // Determine if a distance is in X.Ymm format
        //
        public static bool IsValidDistanceInFormatMil1(string distance)
        {
            Regex regex = new Regex(patternMil1);

            return regex.IsMatch(distance.Trim());
        }
		
		//
		// Add
		//
		public static string Add(string arg1, string arg2)
		{
			if (IsValidDistance(arg1) && IsValidDistance(arg2))
			{
				Distance result = new Distance();
				Distance distance1 = new Distance(arg1);
				Distance distance2 = new Distance(arg2);

				result = distance1 + distance2;
			
				return result.ToString();
			}
			else
			{
				return "Invalid distance";
			}
		}

		//
		// Distance operator +
		//
		public static Distance operator + (Distance arg1, Distance arg2)
		{
			/*if ((arg1.type == (int) distanceType.eng1) && (arg2.type == (int) distanceType.eng1))
			{*/
            if ((arg1.type != 0) && (arg2.type != 0))
            {
				Distance result = new Distance();

				int resultInInches;
				int arg1InInches = (arg1.feet1 * 12) + arg1.inches1;
				int arg2InInches = (arg2.feet1 * 12) + arg2.inches1;
			
				if ((arg1InInches == 0) && (arg2InInches == 0))
				{
					return result;
				}

				if (arg1.sign == arg2.sign)
				{
					result.sign = arg1.sign;
					resultInInches = arg1InInches + arg2InInches;
				}
				else
				{
					if (arg1InInches == arg2InInches)
					{
						result.sign = "+";
						resultInInches = 0;
					}
					else if (arg1InInches > arg2InInches)
					{
						result.sign = arg1.sign;
						resultInInches = arg1InInches - arg2InInches;
					}
					else
					{
						result.sign = arg2.sign;
						resultInInches = arg2InInches - arg1InInches;
					}
				}
			
				result.feet1 = resultInInches / 12;
                result.inches1 = resultInInches % 12;
                result.feet2 = resultInInches / (double)12;
                result.meters = (result.feet1 * 12 * 0.0254) + (result.inches1 * 0.0254);
                result.millimeters = result.meters * 1000;
				return result;
			}
			else
			{
				throw(new Exception ("Add operations are only supported in this format X' Y\""));
			}			
		}

		//
		// Subtract
		//
		public static string Subtract(string arg1, string arg2)
		{
			if (IsValidDistance(arg1) && IsValidDistance(arg2))
			{
				Distance result = new Distance();
				Distance distance1 = new Distance(arg1);
				Distance distance2 = new Distance(arg2);

				result = distance1 - distance2;
			
				return result.ToString();
			}
			else
			{
				return "Invalid distance";
			}
		}

		//
		// Distance operator -
		//
		public static Distance operator - (Distance arg1, Distance arg2)
		{
			if ((arg1.type != 0) && (arg2.type != 0))
            {
				Distance result = new Distance();

				arg2.sign = (arg2.sign == "+") ? "-" : "+";
				result = arg1 + arg2;

				return result;
			}
			else
			{
				throw(new Exception ("Subtract operations are only supported in this format X' Y\""));
			}
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		/// 

		//
		// ToString
		//
		public override string ToString()
		{
			string result;

			switch (type)
			{
				case (int) distanceType.eng1:
					if ((feet1 == 0) && (inches1 == 0))
					{
						result = "0\"";
					}
					else if (sign == "+")
					{
						result = "";
						result += (feet1 > 0) ? feet1.ToString() + "'" : "";
						result += (feet1 > 0) && (inches1 > 0) ? " " : "";
						result += (inches1 > 0) ? inches1.ToString() + "\"" : "";
					}
					else
					{
						result = "- ";
						result += (feet1 > 0) ? feet1.ToString() + "'" : "";
						result += (feet1 > 0) && (inches1 > 0) ? " " : "";
						result += (inches1 > 0) ? inches1.ToString() + "\"" : "";
					}
					break;

				case (int) distanceType.eng2:
					if ((feet1 == 0) && (inches1 == 0))
					{
						result = "0in";
					}
					else if (sign == "+")
					{
						result = "";
						result += (feet1 > 0) ? feet1.ToString() + "ft" : "";
						result += (feet1 > 0) && (inches1 > 0) ? " " : "";
						result += (inches1 > 0) ? inches1.ToString() + "in" : "";
					}
					else
					{
						result = "- ";
						result += (feet1 > 0) ? feet1.ToString() + "ft" : "";
						result += (feet1 > 0) && (inches1 > 0) ? " " : "";
						result += (inches1 > 0) ? inches1.ToString() + "in" : "";
					}
					break;
				
				case (int) distanceType.eng3:
					if (feet2 == 0)
					{
						result = "0.00";
					}
					else if (sign == "+")
					{
						result = feet2.ToString();
					}
					else
					{
						result = "- ";
						result += feet2.ToString();
					}
					break;

				case (int)distanceType.met1:
					if (meters == 0)
					{
						result = "0.00m";
					}
					else if (sign == "+")
					{
						result = meters.ToString() + "m";
					}
					else
					{
						result = "- ";
						result += meters.ToString() + "m";
					}
					break;

                case (int)distanceType.mil1:
                    if (millimeters == 0)
                    {
                        result = "0.00mm";
                    }
                    else if (sign == "+")
                    {
                        result = millimeters.ToString() + "mm";
                    }
                    else
                    {
                        result = "- ";
                        result += millimeters.ToString() + "mm";
                    }
                    break;

				default:
					result = "Invalid distance";
					break;

			}

			return result;
		}

		//
		// ToFeetDouble
		//
		public double ToFeetDouble()
		{
			double result;

			switch (type)
			{
				case (int) distanceType.eng1:
					result = feet1 + ((double) inches1 / 12);
					if (sign == "-")
					{
						result = -result;
					}
					break;

				case (int) distanceType.eng2:
					result = feet1 + ((double) inches1 / 12);
					if (sign == "-")
					{
						result = -result;
					}
					break;

				case (int) distanceType.eng3:
					result = feet2;
					if (sign == "-")
					{
						result = -result;
					}
					break;

				case (int) distanceType.met1:
					result = (meters * 100) / (2.54 * 12);
					if (sign == "-")
					{
						result = -result;
					}
					break;

                case (int)distanceType.mil1:
                    result = (meters * 100) / (2.54 * 12);
                    if (sign == "-")
                    {
                        result = -result;
                    }
                    break;

				default:
					result = 0;
					break;
			}

			return result;
		}



        /// <summary>
        /// Return a distance in X'Y" format
        /// </summary>
        /// <returns></returns>
        public string ToStringInEng1()
        {
            string result = "";

            if (type != 0)
            {
                if ((feet1 == 0) && (inches1 == 0))
                {
                    result = "0\"";
                }
                else if (sign == "+")
                {
                    result = "";
                    result += (feet1 > 0) ? feet1.ToString() + "'" : "";
                    result += (feet1 > 0) && (inches1 > 0) ? " " : "";
                    result += (inches1 > 0) ? inches1.ToString() + "\"" : "";
                }
                else
                {
                    result = "- ";
                    result += (feet1 > 0) ? feet1.ToString() + "'" : "";
                    result += (feet1 > 0) && (inches1 > 0) ? " " : "";
                    result += (inches1 > 0) ? inches1.ToString() + "\"" : "";
                }
            }
            else
            {
                result = "Invalid distance";
            }

            return result;
        }



        /// <summary>
        /// Return a distance in Xft Yin format
        /// </summary>
        /// <returns></returns>
        public string ToStringInEng2()
        {
            string result = "";

            if (type != 0)
            {
                if ((feet1 == 0) && (inches1 == 0))
                {
                    result = "0in";
                }
                else if (sign == "+")
                {
                    result = "";
                    result += (feet1 > 0) ? feet1.ToString() + "ft" : "";
                    result += (feet1 > 0) && (inches1 > 0) ? " " : "";
                    result += (inches1 > 0) ? inches1.ToString() + "in" : "";
                }
                else
                {
                    result = "- ";
                    result += (feet1 > 0) ? feet1.ToString() + "ft" : "";
                    result += (feet1 > 0) && (inches1 > 0) ? " " : "";
                    result += (inches1 > 0) ? inches1.ToString() + "in" : "";
                }
            }
            else
            {
                result = "Invalid distance";
            }

            return result;
        }



        /// <summary>
        /// Return a distance in X.Y format
        /// </summary>
        /// <returns></returns>
        public string ToStringInEng3()
        {
            string result = "";

            if (type != 0)
            {
                if (feet2 == 0)
                {
                    result = "0.00";
                }
                else if (sign == "+")
                {
                    result = feet2.ToString();
                }
                else
                {
                    result = "- ";
                    result += feet2.ToString();
                }
            }
            else
            {
                result = "Invalid distance";
            }

            return result;
        }



        /// <summary>
        /// Return a distance in X.Ym format
        /// </summary>
        /// <returns></returns>
        public string ToStringInMet1()
        {
            string result = "";

            if (type != 0)
            {
                if (meters == 0)
                {
                    result = "0.00m";
                }
                else if (sign == "+")
                {
                    result = meters.ToString() + "m";
                }
                else
                {
                    result = "- ";
                    result += meters.ToString() + "m";
                }
            }
            else
            {
                result = "Invalid distance";
            }

            return result;
        }



        /// <summary>
        /// Return a distance in X.Ymm format
        /// </summary>
        /// <returns></returns>
        public string ToStringInMil1()
        {
            string result = "";

            if (type != 0)
            {
                if (millimeters == 0)
                {
                    result = "0.00mm";
                }
                else if (sign == "+")
                {
                    result = millimeters.ToString() + "mm";
                }
                else
                {
                    result = "- ";
                    result += millimeters.ToString() + "mm";
                }
            }
            else
            {
                result = "Invalid distance";
            }

            return result;
        }



        /// <summary>
        /// Convert distance in a double with X.Y format
        /// </summary>
        /// <returns></returns>
        public double ToDoubleInEng3()
        {
            if (type != 0)
            {
                return double.Parse(ToStringInEng3().Replace(" ", ""));
            }
            else
            {
                throw new Exception("Invalid distance");
            }
        }



	}
}