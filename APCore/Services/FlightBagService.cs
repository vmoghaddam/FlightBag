using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APCore.Models;
using APCore.Objects;
using APCore.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace APCore.Services
{

    public interface IFlightBagService
    {
        Task<DataResponse> SaveRelease(DSPReleaseViewModel DSPRelease);
        Task<DataResponse> SaveEFBBirdStrike(EFBBirdStrikeViewModel EFBBirdStrike);
        Task<DataResponse> SaveEFBOccurrence(EFBOccurrenceViewModel EFBOccurrence);
        Task<DataResponse> SaveEFBVoyageReport(EFBVoyageReportViewModel EFBVoyageReport);
        Task<DataResponse> SaveEFBASR(EFBASRViewModel EFBASR);
       // DbSet<ViewEFBVoyageReport> GetEFBVoyageReports();
        DbSet<ViewEFBVoyageReportsAll> GetEFBVoyageReportsAll();
        DbSet<ViewEFBDSPRelease> GetEFBDSPReleases();
        DbSet<ViewEFBVoyageReport> GetEFBVoyageReports();
        Task<DataResponse> GetEFBVoyageReportByFlightId(int flightId);
        Task<DataResponse> GetEFBVoyageReportById(int flightId);
        DbSet<ViewEFBASR> GetEFBASRs();
        Task<DataResponse> GetEFBASRViewByFlightId(int flightId);
        Task<DataResponse> GetEFBASRByFlightId(int flightId);
        Task<DataResponse> GetEFBASRById(int Id);
        DbSet<EFBBirdStrikeCAO> GetEFBBirdStrikeCAOs();
        Task<DataResponse> GetEFBBirdStrikeCAOByFlightId(int flightId);
    }




    public class FlightBagService : IFlightBagService
    {
        private readonly ppa_cspnContext _context;

        public FlightBagService(ppa_cspnContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        //public DbSet<ViewEFBVoyageReport> GetEFBVoyageReports()
        //{
         //   return _context.ViewEFBVoyageReports;

        //}

        public DbSet<ViewEFBVoyageReportsAll> GetEFBVoyageReportsAll()
        {
            return _context.ViewEFBVoyageReportsAlls;

        }

        public DbSet<ViewEFBVoyageReport> GetEFBVoyageReports ()
        {
            return _context.ViewEFBVoyageReports;

        }

        public DbSet<ViewEFBASR> GetEFBASRs()
        {
            return _context.ViewEFBASRs;

        }
        public DbSet<EFBBirdStrikeCAO> GetEFBBirdStrikeCAOs()
        {
            return _context.EFBBirdStrikeCAOs;
        }


        public DbSet<ViewEFBDSPRelease> GetEFBDSPReleases()
        {
            return _context.ViewEFBDSPReleases;

        }

        public async Task<DataResponse> GetEFBASRViewByFlightId(int flightId)
        {
            var entity = await _context.ViewEFBASRs.SingleOrDefaultAsync(q => q.FlightId == flightId);
            return new DataResponse()
            {
                Data = entity,
                IsSuccess=true

            };
        }

        public async Task<DataResponse> GetEFBASRByFlightId(int flightId)
        {
            var entity = await _context.EFBASRs.SingleOrDefaultAsync(q => q.FlightId == flightId);
            return new DataResponse()
            {
                Data = entity,
                IsSuccess = true

            };
        }

        public async Task<DataResponse> GetEFBASRById(int Id)
        {
            var entity = await _context.ViewEFBASRs.SingleOrDefaultAsync(q => q.Id== Id);
            return new DataResponse()
            {
                Data = entity,
                IsSuccess = true

            };
        }

      public async Task<DataResponse> GetEFBVoyageReportByFlightId(int flightId)
        {
            try
            {
                var voyage = await _context.EFBVoyageReports.SingleOrDefaultAsync(q => q.FlightId == flightId);
                if (voyage != null)
                {
                    voyage.EFBFlightIrregularities = await _context.EFBFlightIrregularities.Where(q => q.VoyageReportId == voyage.Id).ToListAsync();
                    voyage.EFBReasons = await _context.EFBReasons.Where(q => q.VoyageReportId == voyage.Id).ToListAsync();
                    //var irregularity = await _context.EFBFlightIrregularities.Where(q => q.VoyageReportId == voyage.Id).Select(q => q.IrrId).ToListAsync();
                   // var reason = await _context.EFBReasons.Where(q => q.VoyageReportId == voyage.Id).Select(q => q.ReasonId).ToListAsync();
                    return new DataResponse()
                    {
                        //Data = new
                        //{
                        //    voyage,
                        //    irregularity,
                        //    reason
                        //},
                        Data=voyage,
                        IsSuccess = true

                    };
                }
                else
                {
                    return new DataResponse()
                    {
                        Data = voyage,
                        IsSuccess = false
                    };
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "    INNER:" + ex.InnerException.Message;
                return new DataResponse()
                {
                    Data = msg,
                    IsSuccess = false
                };
            }
            
        }

        public async Task<DataResponse> GetEFBVoyageReportById(int Id)
        {
            var voyage = await _context.ViewEFBVoyageReportsAlls.SingleOrDefaultAsync(q => q.Id == Id);
            if (voyage != null)
            {
                var irregularity = await _context.EFBFlightIrregularities.Where(q => q.VoyageReportId == voyage.Id).ToListAsync();
                var reason = await _context.EFBReasons.Where(q => q.VoyageReportId == voyage.Id).ToListAsync();
                return new DataResponse()
                {
                    Data = new
                    {
                        voyage,
                        irregularity,
                        reason
                    },
                    IsSuccess = true

                };
            } else
            {
                return new DataResponse()
                {
                    Data = voyage,
                    IsSuccess = false
                };
                    }
        }
        public async Task<DataResponse> GetEFBBirdStrikeCAOByFlightId(int flightId) 
        {

            var entity = await _context.EFBBirdStrikeCAOs.SingleOrDefaultAsync(q => q.FlightId == flightId);
            return new DataResponse()
            {
                Data = entity,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> SaveEFBASR(EFBASRViewModel EFBASR)
        {
            //var entity = await _context.EFBASRs.FirstOrDefaultAsync(q => q.Id == EFBASR.Id);
            var entity = await _context.EFBASRs.FirstOrDefaultAsync(q => q.FlightId == EFBASR.FlightId);
            if (entity == null)
            {
                entity = new EFBASR();
                _context.EFBASRs.Add(entity);
            }
            entity.User = EFBASR.User;
            entity.DateUpdate= DateTime.UtcNow.ToString("yyyyMMddHHmm"); 

            entity.FlightId = EFBASR.FlightId;
            entity.EventTypeId = EFBASR.EventTypeId;
            entity.OccurrenceDate =Helper.ConvertToDate( EFBASR.OccurrenceDate);
            entity.IsDay = EFBASR.IsDay;
            entity.SQUAWK = EFBASR.SQUAWK;
            entity.FuelJettisoned = EFBASR.FuelJettisoned;
            entity.Altitude = EFBASR.Altitude;
            //entity.SpeedMACHNO = EFBASR.SpeedMACHNO;
            entity.MachNo = EFBASR.MachNo;
            entity.Speed = EFBASR.Speed;
            entity.ACWeight = EFBASR.ACWeight;
            entity.TechLogPageNO = EFBASR.TechLogPageNO;
            entity.TechLogItemNO = EFBASR.TechLogItemNO;
            entity.FlightPhaseId = EFBASR.FlightPhaseId;
            entity.LOCAirport = EFBASR.LOCAirport;
            entity.LOCStand = EFBASR.LOCStand;
            entity.LOCRunway = EFBASR.LOCRunway;
           // entity.LOCGEOLongitude = EFBASR.LOCGEOLongitude;
            entity.LOCGEOAltitude = EFBASR.LOCGEOAltitude;
            entity.LOCGEOLongtitude = EFBASR.LOCGEOLongtitude;
            entity.METId = EFBASR.METId;
            entity.ActualWX = EFBASR.ActualWX;
            entity.SigxWXId = EFBASR.SigxWXId;
            entity.RunwayConditionId = EFBASR.RunwayConditionId;
            entity.ACConfigAP = EFBASR.ACConfigAP;
            entity.ACConfigATHR = EFBASR.ACConfigATHR;
            entity.ACConfigGear = EFBASR.ACConfigGear;
            entity.ACConfigFlap = EFBASR.ACConfigFlap;
            entity.ACConfigSlat = EFBASR.ACConfigSlat;
            entity.ACConfigSpoilers = EFBASR.ACConfigSpoilers;
            entity.Summary = EFBASR.Summary;
            entity.Result = EFBASR.Result;
            entity.OthersInfo = EFBASR.OthersInfo;
            entity.AATRiskId = EFBASR.AATRiskId;
            entity.AATIsActionTaken = EFBASR.AATIsActionTaken;
            entity.AATReportedToATC = EFBASR.AATReportedToATC;
            entity.AATATCInstruction = EFBASR.AATATCInstruction;
            entity.AATFrequency = EFBASR.AATFrequency;
            entity.AATHeading = EFBASR.AATHeading;
            entity.AATClearedAltitude = EFBASR.AATClearedAltitude;
            entity.AATMinVerticalSep = EFBASR.AATMinVerticalSep;
            entity.AATMinHorizontalSep = EFBASR.AATMinHorizontalSep;
            entity.AATTCASAlertId = EFBASR.AATTCASAlertId;
            entity.AATTypeRA = EFBASR.AATTypeRA;
            entity.AATIsRAFollowed = EFBASR.AATIsRAFollowed;
            entity.AATVerticalDeviation = EFBASR.AATVerticalDeviation;
            entity.AATOtherACType = EFBASR.AATOtherACType;
            entity.AATMarkingColour = EFBASR.AATMarkingColour;
            entity.AATCallSign = EFBASR.AATCallSign;
            entity.AATLighting = EFBASR.AATLighting;
            entity.WTHeading = EFBASR.WTHeading;
            entity.WTTurningId = EFBASR.WTTurningId;
            entity.WTGlideSlopePosId = EFBASR.WTGlideSlopePosId;
            entity.WTExtendedCenterlinePosId = EFBASR.WTExtendedCenterlinePosId;
            entity.WTAttitudeChangeId = EFBASR.WTAttitudeChangeId;
            entity.WTAttitudeChangeDeg = EFBASR.WTAttitudeChangeDeg;
            entity.WTIsBuffet = EFBASR.WTIsBuffet;
            entity.WTIsStickShaker = EFBASR.WTIsStickShaker;
            entity.WTSuspect = EFBASR.WTSuspect;
            entity.WTDescribeVA = EFBASR.WTDescribeVA;
            entity.WTPrecedingAC = EFBASR.WTPrecedingAC;
            entity.WTIsAware = EFBASR.WTIsAware;
            entity.BSBirdType = EFBASR.BSBirdType;
            entity.BSNrSeenId = EFBASR.BSNrSeenId;
            entity.BSNrStruckId = EFBASR.BSNrStruckId;
            entity.BSTimeId = EFBASR.BSTimeId;
            entity.PICDate = EFBASR.PICDate;

            entity.DayNightStatusId = EFBASR.DayNightStatusId;
            entity.IncidentTypeId = EFBASR.IncidentTypeId;
            entity.AATXAbove = EFBASR.AATXAbove;
            entity.AATYAbove = EFBASR.AATYAbove;
            entity.AATXAstern = EFBASR.AATXAstern;
            entity.AATYAstern = EFBASR.AATYAstern;
            entity.AATHorizontalPlane = EFBASR.AATHorizontalPlane;
            entity.BSImpactDec = EFBASR.BSImpactDec;
            entity.BSHeading = EFBASR.BSHeading;
            entity.IsSecurityEvent = EFBASR.IsSecurityEvent;
            entity.IsAirproxATC = EFBASR.IsAirproxATC;
            entity.IsTCASRA = EFBASR.IsTCASRA;
            entity.IsWakeTur = EFBASR.IsWakeTur;
            entity.IsBirdStrike = EFBASR.IsBirdStrike;
            entity.IsOthers = EFBASR.IsOthers;
            entity.SigxWXTypeId = EFBASR.SigxWXTypeId;
            entity.BSTurningId = EFBASR.BSTurningId;


            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
                return new DataResponse() { IsSuccess = true,Data= entity };
            else
                return new DataResponse() { IsSuccess = false };
        }


        public async Task<DataResponse> SaveEFBVoyageReport(EFBVoyageReportViewModel EFBVoyageReport)
        {
            var entity = await _context.EFBVoyageReports.FirstOrDefaultAsync(q => q.FlightId == EFBVoyageReport.FlightId);

            if (entity == null)
            {
                entity = new EFBVoyageReport();
                _context.EFBVoyageReports.Add(entity);
            }
            entity.User = EFBVoyageReport.User;
            entity.DateUpdate = DateTime.UtcNow.ToString("yyyyMMddHHmm");
            entity.FlightId = EFBVoyageReport.FlightId;
            entity.Route = EFBVoyageReport.Route;
            entity.RestReduction = EFBVoyageReport.RestReduction;
            entity.DutyExtention = EFBVoyageReport.DutyExtention;
            entity.DepDelay = EFBVoyageReport.DepDelay;
            entity.Report = EFBVoyageReport.Report;
            entity.DatePICSignature = Helper.ConvertToDate(EFBVoyageReport.DatePICSignature);
            entity.ActionedById = EFBVoyageReport.ActionedById;
            entity.DateActioned = Helper.ConvertToDate(EFBVoyageReport.DateActioned);
            entity.DateConfirmed = null;

            var exist = await _context.EFBFlightIrregularities.Where(q => q.VoyageReportId == entity.Id).ToListAsync();
            _context.EFBFlightIrregularities.RemoveRange(exist);

            if (EFBVoyageReport.Irregularities != null)
            {
                foreach (int x in EFBVoyageReport.Irregularities)
                {
                    entity.EFBFlightIrregularities.Add(new EFBFlightIrregularity()
                    {
                        VoyageReport = entity,
                        IrrId = x
                    });

                }
            }

            var existReason = await _context.EFBReasons.Where(q => q.VoyageReportId == entity.Id).ToListAsync();
            _context.EFBReasons.RemoveRange(existReason);

            if (EFBVoyageReport.Reasons != null)
            {
                foreach (int x in EFBVoyageReport.Reasons)
                {
                    entity.EFBReasons.Add(new EFBReason()
                    {
                        VoyageReport = entity,
                        ReasonId = x
                    });

                }
            }

            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
            {

                return new DataResponse() { IsSuccess = true, Data = entity };
            }
                
            else
                return new DataResponse() { IsSuccess = false };
        }


        public async Task<DataResponse> SaveEFBOccurrence(EFBOccurrenceViewModel EFBOccurrence)
        {
            var entity = await _context.EFBOccurrenceCAOs.FirstOrDefaultAsync(q => q.Id == EFBOccurrence.Id);
            if (entity == null)
            {
                entity = new EFBOccurrenceCAO();
                _context.EFBOccurrenceCAOs.Add(entity);
                var xxxx = _context.Entry(entity).State;
            }

            entity.FlightId = EFBOccurrence.FlightId;
            entity.ReporterId = EFBOccurrence.ReporterId;
            entity.OccurrenceTypeId = EFBOccurrence.OccurrenceTypeId;
            entity.OccurrenceDate = EFBOccurrence.OccurrenceDate;
            entity.IsDay = EFBOccurrence.IsDay;
            entity.Location = EFBOccurrence.Location;
            entity.Altitude = EFBOccurrence.Altitude;
            entity.OperatorId = EFBOccurrence.OperatorId;
            //entity.A_CFlightPhaseId = EFBOccurrence.A_CFlightPhaseId;
            //entity.A_CFlightPhaseRemark = EFBOccurrence.A_CFlightPhaseRemark;
            entity.EquipmentType = EFBOccurrence.EquipmentType;
            entity.EquipmentAirportPlacard = EFBOccurrence.EquipmentAirportPlacard;
            entity.EquipmentCompany = EFBOccurrence.EquipmentCompany;
            entity.EquipmentDriverName = EFBOccurrence.EquipmentDriverName;
            entity.EquipmentIdNO = EFBOccurrence.EquipmentIdNO;
            entity.EquipmentContan = EFBOccurrence.EquipmentContan;
            entity.FatalInjuryCrewNr = EFBOccurrence.FatalInjuryCrewNr;
            entity.FatalInjuryPassengerNr = EFBOccurrence.FatalInjuryPassengerNr;
            entity.FatalInjuryOtherNr = EFBOccurrence.FatalInjuryOtherNr;
            entity.SeriousInjuryCrewNr = EFBOccurrence.SeriousInjuryCrewNr;
            entity.SeriousInjuryPassengerNr = EFBOccurrence.SeriousInjuryPassengerNr;
            entity.SeriousInjuryOtherNr = EFBOccurrence.SeriousInjuryOtherNr;
            entity.MinorInjuryCrewNr = EFBOccurrence.MinorInjuryCrewNr;
            entity.MinorInjuryPassengerNr = EFBOccurrence.MinorInjuryPassengerNr;
            entity.MinorInjuryOtherNr = EFBOccurrence.MinorInjuryOtherNr;
            entity.NoneInjuryCrewNr = EFBOccurrence.NoneInjuryCrewNr;
            entity.NoneInjuryPassengerNr = EFBOccurrence.NoneInjuryPassengerNr;
            entity.NoneInjuryOtherNr = EFBOccurrence.NoneInjuryOtherNr;
            entity.DamageId = EFBOccurrence.DamageId;
            entity.DamageDetail = EFBOccurrence.DamageDetail;
            entity.PriorEventWX = EFBOccurrence.PriorEventWX;
            entity.EventTimeWX = EFBOccurrence.EventTimeWX;
            entity.ForcastWX = EFBOccurrence.ForcastWX;
            entity.IsExplosivesGoods = EFBOccurrence.IsExplosivesGoods;
            entity.IsRadioActiveGoods = EFBOccurrence.IsRadioActiveGoods;
            entity.OtherDangerousGood = EFBOccurrence.OtherDangerousGood;
            entity.EventDescription = EFBOccurrence.EventDescription;
            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
                return new DataResponse() { IsSuccess = true };
            else
                return new DataResponse() { IsSuccess = false };
        }

        public async Task<DataResponse> SaveEFBBirdStrike(EFBBirdStrikeViewModel EFBBirdStrike)
        {
            var entity = await _context.EFBBirdStrikeCAOs.FirstOrDefaultAsync(q => q.Id == EFBBirdStrike.Id);
            if (entity == null)
            {
                entity = new EFBBirdStrikeCAO();
                _context.EFBBirdStrikeCAOs.Add(entity);
                var xxxx = _context.Entry(entity).State;
            }

            entity.FlightId = EFBBirdStrike.FlightId;
            entity.OperatorId = EFBBirdStrike.OperatorId;
            entity.EngineModel = EFBBirdStrike.EngineModel;
            entity.Date = EFBBirdStrike.Date;
            entity.LocalTimeId = EFBBirdStrike.LocalTimeId;
            entity.AerodromeName = EFBBirdStrike.AerodromeName;
            entity.RunwayUsed = EFBBirdStrike.RunwayUsed;
            entity.EnRouteLoc = EFBBirdStrike.EnRouteLoc;
            ; entity.HeightAGl = EFBBirdStrike.HeightAGl;
            entity.Speed_IAS_ = EFBBirdStrike.Speed_IAS_;
            entity.PhaseOrFlightId = EFBBirdStrike.PhaseOrFlightId;
            entity.A_CPartRadom = EFBBirdStrike.A_CPartRadom;
            entity.A_CPartWindShield = EFBBirdStrike.A_CPartWindShield;
            entity.A_CPartNose = EFBBirdStrike.A_CPartNose;
            entity.A_CPartEngineNO1 = EFBBirdStrike.A_CPartEngineNO1;
            entity.A_CPartEngineNO2 = EFBBirdStrike.A_CPartEngineNO2;
            entity.A_CPartEngineNO3 = EFBBirdStrike.A_CPartEngineNO3;
            entity.A_CPartEngineNO4 = EFBBirdStrike.A_CPartEngineNO4;
            entity.A_CPartPropeller = EFBBirdStrike.A_CPartPropeller;
            entity.A_CPartWing_Rotor = EFBBirdStrike.A_CPartWing_Rotor;
            entity.A_CPartFuselage = EFBBirdStrike.A_CPartFuselage;
            entity.A_CPartLandingGear = EFBBirdStrike.A_CPartLandingGear;
            entity.A_CPartTail = EFBBirdStrike.A_CPartTail;
            entity.A_CPartLight = EFBBirdStrike.A_CPartLight;
            entity.A_CPartOther_Specify_ = EFBBirdStrike.A_CPartOther_Specify_;
            entity.IsEffect__None = EFBBirdStrike.IsEffect__None;
            entity.IsEffectAbortedTakeOff = EFBBirdStrike.IsEffectAbortedTakeOff;
            entity.IsEffectLanding = EFBBirdStrike.IsEffectLanding;
            entity.IsEffectEngineShutDown = EFBBirdStrike.IsEffectEngineShutDown;
            entity.IsEffectOther = EFBBirdStrike.IsEffectOther;
            entity.SkyConditionId = EFBBirdStrike.SkyConditionId;
            entity.IsPrecipitationFog = EFBBirdStrike.IsPrecipitationFog;
            entity.IsPrecipitationRain = EFBBirdStrike.IsPrecipitationRain;
            entity.IsPrecipitationSnow = EFBBirdStrike.IsPrecipitationSnow;
            entity.BirdSpecies = EFBBirdStrike.BirdSpecies;
            entity.BirdNrSeenId = EFBBirdStrike.BirdNrSeenId;
            entity.BirdNrStruckId = EFBBirdStrike.BirdNrStruckId;
            entity.BirdSizeId = EFBBirdStrike.BirdSizeId;
            entity.IspilotWarned = EFBBirdStrike.IspilotWarned;
            entity.Remarks = EFBBirdStrike.Remarks;
            entity.ReportedById = EFBBirdStrike.ReportedById;
            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
                return new DataResponse() { IsSuccess = true };
            else
                return new DataResponse() { IsSuccess = false };

        }

        public async Task<DataResponse> SaveRelease(DSPReleaseViewModel DSPRelease)
        {
            var release = await _context.EFBDSPReleases.FirstOrDefaultAsync(q => q.Id == DSPRelease.Id);
            if (release == null)
            {
                release = new EFBDSPRelease();
                _context.EFBDSPReleases.Add(release);
                var xxxx = _context.Entry(release).State;
            }
            release.FlightId = DSPRelease.FlightId;
            release.ActualWXDSP = DSPRelease.ActualWXDSP;
            release.ActualWXCPT = DSPRelease.ActualWXCPT;
            release.ActualWXDSPRemark = DSPRelease.ActualWXDSPRemark;
            release.ActualWXCPTRemark = DSPRelease.ActualWXCPTRemark;
            release.WXForcastDSP = DSPRelease.WXForcastDSP;
            release.WXForcastCPT = DSPRelease.WXForcastCPT;
            release.WXForcastDSPRemark = DSPRelease.WXForcastDSPRemark;
            release.WXForcastCPTRemark = DSPRelease.WXForcastCPTRemark;
            release.SigxWXDSP = DSPRelease.SigxWXDSP;
            release.SigxWXCPT = DSPRelease.SigxWXCPT;
            release.SigxWXDSPRemark = DSPRelease.SigxWXDSPRemark;
            release.SigxWXCPTRemark = DSPRelease.SigxWXCPTRemark;
            release.WindChartDSP = DSPRelease.WindChartDSP;
            release.WindChartCPT = DSPRelease.WindChartCPT;
            release.WindChartDSPRemark = DSPRelease.WindChartDSPRemark;
            release.WindChartCPTRemark = DSPRelease.WindChartCPTRemark;
            release.NotamDSP = DSPRelease.NotamDSP;
            release.NotamCPT = DSPRelease.NotamCPT;
            release.NotamDSPRemark = DSPRelease.NotamDSPRemark;
            release.NotamCPTRemark = DSPRelease.NotamCPTRemark;
            release.ComputedFligthPlanDSP = DSPRelease.ComputedFligthPlanDSP;
            release.ComputedFligthPlanCPT = DSPRelease.ComputedFligthPlanCPT;
            release.ComputedFligthPlanDSPRemark = DSPRelease.ComputedFligthPlanDSPRemark;
            release.ComputedFligthPlanCPTRemark = DSPRelease.ComputedFligthPlanCPTRemark;
            release.ATCFlightPlanDSP = DSPRelease.ATCFlightPlanDSP;
            release.ATCFlightPlanCPT = DSPRelease.ATCFlightPlanCPT;
            release.ATCFlightPlanDSPRemark = DSPRelease.ATCFlightPlanDSPRemark;
            release.ATCFlightPlanCPTRemark = DSPRelease.ATCFlightPlanCPTRemark;
            release.PermissionsDSP = DSPRelease.PermissionsDSP;
            release.PermissionsCPT = DSPRelease.PermissionsCPT;
            release.PermissionsDSPRemark = DSPRelease.PermissionsDSPRemark;
            release.PermissionsCPTRemark = DSPRelease.PermissionsCPTRemark;
            release.JeppesenAirwayManualDSP = DSPRelease.JeppesenAirwayManualDSP;
            release.JeppesenAirwayManualCPT = DSPRelease.JeppesenAirwayManualCPT;
            release.JeppesenAirwayManualDSPRemark = DSPRelease.JeppesenAirwayManualDSPRemark;
            release.JeppesenAirwayManualCPTRemark = DSPRelease.JeppesenAirwayManualCPTRemark;
            release.MinFuelRequiredDSP = DSPRelease.MinFuelRequiredDSP;
            release.MinFuelRequiredCPT = DSPRelease.MinFuelRequiredCPT;
            //release.MinFuelRequiredSFP = DSPRelease.MinFuelRequiredSFP;
            release.MinFuelRequiredPilotReq = DSPRelease.MinFuelRequiredPilotReq;
            release.GeneralDeclarationDSP = DSPRelease.GeneralDeclarationDSP;
            release.GeneralDeclarationCPT = DSPRelease.GeneralDeclarationCPT;
            release.GeneralDeclarationDSPRemark = DSPRelease.GeneralDeclarationDSPRemark;
            release.GeneralDeclarationCPTRemark = DSPRelease.GeneralDeclarationCPTRemark;
            release.FlightReportDSP = DSPRelease.FlightReportDSP;
            release.FlightReportCPT = DSPRelease.FlightReportCPT;
            release.FlightReportDSPRemark = DSPRelease.FlightReportDSPRemark;
            release.FlightReportCPTRemark = DSPRelease.FlightReportCPTRemark;
            release.TOLndCardsDSP = DSPRelease.TOLndCardsDSP;
            release.TOLndCardsCPT = DSPRelease.TOLndCardsCPT;
            release.TOLndCardsDSPRemark = DSPRelease.TOLndCardsDSPRemark;
            release.TOLndCardsCPTRemark = DSPRelease.TOLndCardsCPTRemark;
            release.LoadSheetDSP = DSPRelease.LoadSheetDSP;
            release.LoadSheetCPT = DSPRelease.LoadSheetCPT;
            release.LoadSheetDSPRemark = DSPRelease.LoadSheetDSPRemark;
            release.LoadSheetCPTRemark = DSPRelease.LoadSheetCPTRemark;
            release.FlightSafetyReportDSP = DSPRelease.FlightSafetyReportDSP;
            release.FlightSafetyReportCPT = DSPRelease.FlightSafetyReportCPT;
            release.FlightSafetyReportDSPRemark = DSPRelease.FlightSafetyReportDSPRemark;
            release.FlightSafetyReportCPTRemark = DSPRelease.FlightSafetyReportCPTRemark;
            release.AVSECIncidentReportDSP = DSPRelease.AVSECIncidentReportDSP;
            release.AVSECIncidentReportCPT = DSPRelease.AVSECIncidentReportCPT;
            release.AVSECIncidentReportDSPRemark = DSPRelease.AVSECIncidentReportDSPRemark;
            release.AVSECIncidentReportCPTRemark = DSPRelease.AVSECIncidentReportCPTRemark;
            release.OperationEngineeringDSP = DSPRelease.OperationEngineeringDSP;
            release.OperationEngineeringCPT = DSPRelease.OperationEngineeringCPT;
            release.OperationEngineeringDSPRemark = DSPRelease.OperationEngineeringDSPRemark;
            release.OperationEngineeringCPTRemark = DSPRelease.OperationEngineeringCPTRemark;
            release.VoyageReportDSP = DSPRelease.VoyageReportDSP;
            release.VoyageReportCPT = DSPRelease.VoyageReportCPT;
            release.VoyageReportDSPRemark = DSPRelease.VoyageReportDSPRemark;
            release.VoyageReportCPTRemark = DSPRelease.VoyageReportCPTRemark;
            release.PIFDSP = DSPRelease.PIFDSP;
            release.PIFCPT = DSPRelease.PIFCPT;
            release.PIFDSPRemark = DSPRelease.PIFDSPRemark;
            release.PIFCPTRemark = DSPRelease.PIFCPTRemark;
            release.GoodDeclarationDSP = DSPRelease.GoodDeclarationDSP;
            release.GoodDeclarationCPT = DSPRelease.GoodDeclarationCPT;
            release.GoodDeclarationDSPRemark = DSPRelease.GoodDeclarationDSPRemark;
            release.GoodDeclarationCPTRemark = DSPRelease.GoodDeclarationCPTRemark;
            release.IPADDSP = DSPRelease.IPADDSP;
            release.IPADCPT = DSPRelease.IPADCPT;
            release.IPADDSPRemark = DSPRelease.IPADDSPRemark;
            release.IPADCPTRemark = DSPRelease.IPADCPTRemark;
            release.DateConfirmed = DSPRelease.DateConfirmed;
            release.DispatcherId = DSPRelease.DispatcherId;
            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
                return new DataResponse() { IsSuccess = true };
            else
                return new DataResponse() { IsSuccess = false };
        }

    }

}
