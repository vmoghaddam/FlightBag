using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class EFBDSPRelease
    {
        public int? FlightId { get; set; }
        public bool? ActualWXDSP { get; set; }
        public bool? ActualWXCPT { get; set; }
        public string ActualWXDSPRemark { get; set; }
        public string ActualWXCPTRemark { get; set; }
        public bool? WXForcastDSP { get; set; }
        public bool? WXForcastCPT { get; set; }
        public string WXForcastDSPRemark { get; set; }
        public string WXForcastCPTRemark { get; set; }
        public bool? SigxWXDSP { get; set; }
        public bool? SigxWXCPT { get; set; }
        public string SigxWXDSPRemark { get; set; }
        public string SigxWXCPTRemark { get; set; }
        public bool? WindChartDSP { get; set; }
        public bool? WindChartCPT { get; set; }
        public string WindChartDSPRemark { get; set; }
        public string WindChartCPTRemark { get; set; }
        public bool? NotamDSP { get; set; }
        public bool? NotamCPT { get; set; }
        public string NotamDSPRemark { get; set; }
        public string NotamCPTRemark { get; set; }
        public bool? ComputedFligthPlanDSP { get; set; }
        public bool? ComputedFligthPlanCPT { get; set; }
        public string ComputedFligthPlanDSPRemark { get; set; }
        public string ComputedFligthPlanCPTRemark { get; set; }
        public bool? ATCFlightPlanDSP { get; set; }
        public bool? ATCFlightPlanCPT { get; set; }
        public string ATCFlightPlanDSPRemark { get; set; }
        public string ATCFlightPlanCPTRemark { get; set; }
        public bool? PermissionsDSP { get; set; }
        public bool? PermissionsCPT { get; set; }
        public string PermissionsDSPRemark { get; set; }
        public string PermissionsCPTRemark { get; set; }
        public bool? JeppesenAirwayManualDSP { get; set; }
        public bool? JeppesenAirwayManualCPT { get; set; }
        public string JeppesenAirwayManualDSPRemark { get; set; }
        public string JeppesenAirwayManualCPTRemark { get; set; }
        public bool? MinFuelRequiredDSP { get; set; }
        public bool? MinFuelRequiredCPT { get; set; }
        public decimal? MinFuelRequiredCFP { get; set; }
        public decimal? MinFuelRequiredPilotReq { get; set; }
        public bool? GeneralDeclarationDSP { get; set; }
        public bool? GeneralDeclarationCPT { get; set; }
        public string GeneralDeclarationDSPRemark { get; set; }
        public string GeneralDeclarationCPTRemark { get; set; }
        public bool? FlightReportDSP { get; set; }
        public bool? FlightReportCPT { get; set; }
        public string FlightReportDSPRemark { get; set; }
        public string FlightReportCPTRemark { get; set; }
        public bool? TOLndCardsDSP { get; set; }
        public bool? TOLndCardsCPT { get; set; }
        public string TOLndCardsDSPRemark { get; set; }
        public string TOLndCardsCPTRemark { get; set; }
        public bool? LoadSheetDSP { get; set; }
        public bool? LoadSheetCPT { get; set; }
        public string LoadSheetDSPRemark { get; set; }
        public string LoadSheetCPTRemark { get; set; }
        public bool? FlightSafetyReportDSP { get; set; }
        public bool? FlightSafetyReportCPT { get; set; }
        public string FlightSafetyReportDSPRemark { get; set; }
        public string FlightSafetyReportCPTRemark { get; set; }
        public bool? AVSECIncidentReportDSP { get; set; }
        public bool? AVSECIncidentReportCPT { get; set; }
        public string AVSECIncidentReportDSPRemark { get; set; }
        public string AVSECIncidentReportCPTRemark { get; set; }
        public bool? OperationEngineeringDSP { get; set; }
        public bool? OperationEngineeringCPT { get; set; }
        public string OperationEngineeringDSPRemark { get; set; }
        public string OperationEngineeringCPTRemark { get; set; }
        public bool? VoyageReportDSP { get; set; }
        public bool? VoyageReportCPT { get; set; }
        public string VoyageReportDSPRemark { get; set; }
        public string VoyageReportCPTRemark { get; set; }
        public bool? PIFDSP { get; set; }
        public bool? PIFCPT { get; set; }
        public string PIFDSPRemark { get; set; }
        public string PIFCPTRemark { get; set; }
        public bool? GoodDeclarationDSP { get; set; }
        public bool? GoodDeclarationCPT { get; set; }
        public string GoodDeclarationDSPRemark { get; set; }
        public string GoodDeclarationCPTRemark { get; set; }
        public bool? IPADDSP { get; set; }
        public bool? IPADCPT { get; set; }
        public string IPADDSPRemark { get; set; }
        public string IPADCPTRemark { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public int? DispatcherId { get; set; }
        public int Id { get; set; }
        public string DateUpdate { get; set; }
        public string User { get; set; }
        public string JLSignedBy { get; set; }
        public DateTime? JLDatePICApproved { get; set; }
        public int? PICId { get; set; }
        public string PIC { get; set; }

        public virtual Employee Dispatcher { get; set; }
        public virtual FlightInformation Flight { get; set; }
    }
}
