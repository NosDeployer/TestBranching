// ////////////////////////////////////////////////////////////////////////
// AUXILIAR EVENTS
//

function cbxClick()
{
     return false;
 }






// ////////////////////////////////////////////////////////////////////////
// NAVIGATION EVENTS
//

 function tkrpbLeftMenuItemClick(sender, eventArgs) 
 {
     var item = eventArgs.get_item().get_value();

     switch (item) 
     {
        case "nbReportsPrintHoursForPayrollPeriodOld":
            window.open("./../projecttime/print_hours_for_payroll_period_old.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width= 800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "nbReportsPrintHoursForPayrollPeriod":
            window.open("./../projecttime/print_hours_for_payroll_period.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width= 800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "nbReportsPrintHoursForPayrollPeriodWithApproval":
            window.open("./../projecttime/print_hours_for_payroll_period_with_approval.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width= 800, height=680");
            eventArgs.set_cancel(true);
            break;

        case "nbReportsPrintUnapprovedProjectTimes":
            window.open("./../projecttime/print_unapproved_project_times.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width= 800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "nbReportsPrintTeamMemberLocation":
            window.open("./../projecttime/print_employee_location.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "nbReportsPrintVehicleLocation":
            window.open("./../projecttime/print_vehicle_location.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "nbReportsPrintVehicleUsageInUSA":
            window.open("./../projecttime/print_vehicle_usage_in_usa.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "nbReportsPrint3ChartReport":
            window.open("./../projecttime/print_3_chart_report.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "nbReportsPrintTeamMemberHoursForRestartWeek":
            window.open("./../projecttime/print_employee_hours_for_restart_week.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "nbReportsPrintLogsOver15Hours":
            window.open("./../projecttime/print_logs_over_15_hours.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
            
        case "nbReportsPrintMeals":
            window.open("./../projecttime/print_meals.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;            
                                        
        case "nbReportsPrintHoursForProject":
            window.open("./../projecttime/print_hours_for_project.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;            

        case "nbReportsPrintProjectCosting":        
            window.open("./../projecttime/print_project_costing.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;            

        case "nbReportsPrintManhoursPerPhase":        
            window.open("./../projecttime/print_manhours_per_phase.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;            
            
        case "nbTimesheetsToolsAddTeamProjectTime":
            window.open("./../teamprojecttime/timesheet_team.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=1024, height=790");
            eventArgs.set_cancel(true);
            break;            

        case "nbTimesheetsToolsMissingProjectTime":
            window.open("./../projecttime/timesheet_missing.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=550, height=420");
            eventArgs.set_cancel(true);
            break;

        case "nbReportsPrintSummaryCostingSheetByMonth":
            window.open("./../projecttime/print_summary_costingsheet_by_month.aspx?source_page=timesheet.aspx", "_blank", "toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680");
            eventArgs.set_cancel(true);
            break;
    }
}