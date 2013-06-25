using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListNavigator
    /// </summary>
    public class ToDoListNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListNavigator()
            : base("ToDoListNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListNavigator(DataSet data)
            : base(data, "ToDoListNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="conditionName">conditionName</param>
        /// <param name="textForSearch">textForSearch</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        public void Load(string whereClause, string orderByClause, string conditionValue, string conditionName, string textForSearch, int companyId, string fmType)
        {
            ToDoListNavigatorGateway toDoListNavigatorGateway = new ToDoListNavigatorGateway(Data);
            toDoListNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, conditionName, textForSearch);
        }


       
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="selected">selected</param>
        public void Update(int toDoId, bool selected)
        {
            ToDoListNavigatorTDS.ToDoListNavigatorRow toDoListNavigatorRow = GetRow(toDoId);
            toDoListNavigatorRow.Selected = selected;
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="ToDoListNavigatorTDS">ToDoListNavigatorTDS</param>
        /// <param name="currentToDoId">currentToDoId</param>
        /// <returns>prevToDoId</returns>
        public static int GetPreviousId(ToDoListNavigatorTDS toDoListNavigatorTDS, int currentToDoId)
        {
            int prevToDoId = currentToDoId;

            for (int i = 0; i < toDoListNavigatorTDS.ToDoListNavigator.DefaultView.Count; i++)
            {
                if ((int)toDoListNavigatorTDS.ToDoListNavigator.DefaultView[i]["ToDoID"] == currentToDoId)
                {
                    if (i == 0)
                    {
                        prevToDoId = currentToDoId;
                    }
                    else
                    {
                        prevToDoId = (int)toDoListNavigatorTDS.ToDoListNavigator.DefaultView[i - 1]["ToDoID"];
                    }

                    break;
                }
               
            }

            return prevToDoId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="ToDoListNavigatorTDS">ToDoListNavigatorTDS</param>
        /// <param name="currentToDoId">currentToDoId</param>
        /// <returns>nextToDoId</returns>
        public static int GetNextId(ToDoListNavigatorTDS toDoListNavigatorTDS, int currentToDoId)
        {
            int nextToDoId = currentToDoId;

            for (int i = 0; i < toDoListNavigatorTDS.ToDoListNavigator.DefaultView.Count; i++)
            {
                if ((int)toDoListNavigatorTDS.ToDoListNavigator.DefaultView[i]["ToDoID"] == currentToDoId)
                {
                    if (i == toDoListNavigatorTDS.ToDoListNavigator.DefaultView.Count - 1)
                    {
                        nextToDoId = currentToDoId;
                    }
                    else
                    {
                        nextToDoId = (int)toDoListNavigatorTDS.ToDoListNavigator.DefaultView[i + 1]["ToDoID"];
                    }
                    break;
                }
                
            }
            return nextToDoId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
       
        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="toDoId">toDoId</param>
        ///<returns>ToDoListNavigatorTDS.ToDoListNavigatorRow</returns>
        private ToDoListNavigatorTDS.ToDoListNavigatorRow GetRow(int toDoId)
        {
            ToDoListNavigatorTDS.ToDoListNavigatorRow row = ((ToDoListNavigatorTDS.ToDoListNavigatorDataTable)Table).FindByToDoID(toDoId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FM.ToDoList.ToDoListNavigator.GetRow");
            }

            return row;
        }



    }
}