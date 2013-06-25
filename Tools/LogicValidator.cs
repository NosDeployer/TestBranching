using System;
using System.Collections;
using System.Text.RegularExpressions;
using Eval3;

namespace LiquiForce.LFSLive.Tools
{
    public class LogicValidator
    {
        ///////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        // 

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="conditions"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Validate(string expr, ArrayList conditions, out string message)
        {
            bool bOk = false;

            // trasnform to lowercase
            for (int i = 0; i < conditions.Count; i++)
            {
                conditions[i] = ((string)conditions[i]).ToLower();
            }
            expr = expr.ToLower();
            expr = expr + " ";

            // validations
            // ... validate members
            bOk = ValidateMembers(expr, out message);

            // ... validate conditions
            if (bOk) bOk = ValidateConditions(expr, conditions, out message);

            // ... validate syntax
            if (bOk) bOk = ValidateSyntax(expr, out message);

            return bOk;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// ValidateSyntax
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool ValidateSyntax(string expr, out string message)
        {
            message = "";

            // replace conditions to true
            Regex regex = new Regex("condition\\d+");
            expr = regex.Replace(expr, "true");

            // parsing
            Evaluator evaluator = new Evaluator(eParserSyntax.cSharp, false);

            try
            {
                opCode result = evaluator.Parse(expr);
                return true;
            }
            catch (Exception ex)
            {
                message = "There is a syntax error in the logical expression (" + ex.Message + ").";
                return false;
            }
        }



        /// <summary>
        /// ValidateConditions
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="conditions"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool ValidateConditions(string expr, ArrayList conditions, out string message)
        {
            message = "";
            bool bOk = true;

            // validate conditions in 'conditions'
            for (int i = 0; (i < conditions.Count) && (bOk); i++)
            {
                string condition = (string)conditions[i];

                if (!((expr.Contains(condition + " ")) || (expr.Contains(condition + ")"))))
                {
                    bOk = false;
                    message = string.Format("The {0}, defined previously, does not exist within the logical expression.", "C" + condition.Substring(1));
                }
            }

            // validate conditions in 'expr'
            if (bOk)
            {
                Regex regex = new Regex("condition\\d+");
                MatchCollection matches = regex.Matches(expr);

                for (int i = 0; (i < matches.Count) && (bOk); i++)
                {
                    string condition = matches[i].ToString();

                    if (!conditions.Contains(condition))
                    {
                        bOk = false;
                        message = string.Format("The {0} was not defined previously.", "C" + condition.Substring(1));
                    }
                }
            }

            return bOk;
        }



        /// <summary>
        /// ValidateMembers
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool ValidateMembers(string expr, out string message)
        {
            message = "";
            string pattern = "^(\\sand\\s|\\sor\\s|condition\\d+|\\s|\\(|\\))*$";

            Regex regex = new Regex(pattern);
            bool bOk = regex.IsMatch(expr);

            if (!bOk)
            {
                message = "The logical expression has invalid elements (only AND, OR, ConditionN and parentheses can exist).";
            }

            return bOk;
        }



    }
}
