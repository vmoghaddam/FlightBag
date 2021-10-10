using APCore.Models;
using APCore.Objects;
using APCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APCore.Services
{
    public interface IFlightService
    {

        Task<DataResponse> GetCrewFlights(int crewId, DateTime from, DateTime to);
        Task<DataResponse> GetFlights(DateTime from, DateTime to, string no, string origin, string destination, string route, string cpt, string fo, string ip, string sccm, string register);

        DbSet<AppCrewFlight> GetCrewFlightsQuery();
        DbSet<AppLeg> GetFlightsQuery();
        Task<DataResponse> GetFlightCrews(int flightId);
        Task<DataResponse> GetFlightCommanders(int flightId);
        Task<DataResponse> GetFlight(int flightId);
        Task<DataResponse> GetFlightDelays(int flightId);
        Task<DataResponse> SaveLog(LogViewModel log);
        Task<DataResponse> SaveLog2(LogViewModel2 log);
        Task<DataResponse> SaveSign(int flightId, int pic, string picStr, string doc, string user);
        Task<DataResponse> SaveSignJL(List<int> flightIds, int pic, string picStr, string doc, string user);
        Task<DataResponse> CheckLog(LogViewModel log);
        Task<DataResponse> GetCrewCalendarByYearMonth(int crewId, int year, int month);
        Task<DataResponse> GetCrewCalendarByYearMonth(int crewId, DateTime from, DateTime to);
        Task<DataResponse> GetCrewDuties(int crewId, DateTime from, DateTime to, int noFDP);
        Task<DataResponse> GetFDPFlights(int fdpId);


        Task<DataResponse> GetOFP(int flightId);
        Task<DataResponse> GetOFPProps(int ofpId);
        Task<DataResponse> SaveOFPProp(int ofpId, string propName, string propValue, string user);
        Task<DataResponse> SaveOFPProps(List<OFPPropViewModel> items);
        Task<DataResponse> GetOFPPropsByIds(List<int> ids);
        Task<DataResponse> GetOFPsByFlightIds(List<int?> ids);
        Task<DataResponse> GetDRsByFlightIds(List<int?> ids);

        Task<DataResponse> CheckLock(int flightId, string doc);

        //Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token);

        //Task<UserManagerResponse> ForgetPasswordAsync(string email);

        //Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordViewModel model);
    }
    public class FlightService : IFlightService
    {
        private readonly ppa_cspnContext _context;
        public FlightService(ppa_cspnContext context)
        {
            _context = context;
        }
        public async Task<DataResponse> GetCrewFlights(int crewId, DateTime from, DateTime to)
        {
            var _from = from.Date;
            var _to = to.Date;
            var flights = await _context.AppCrewFlights.Where(q =>
                    q.CrewId == crewId &&
                    q.STDDay >= _from && q.STDDay <= _to
            ).ToListAsync();
            return new DataResponse
            {
                Data = flights,
                Errors = null,
                IsSuccess = true
            };
        }
        public async Task<DataResponse> GetFlights(DateTime from, DateTime to, string no, string origin, string destination, string route, string cpt, string fo, string ip, string sccm, string register)
        {
            var _from = from.Date;
            var _to = to.Date;
            var query = _context.AppLegs.Where(q =>

                  q.STDDay >= _from && q.STDDay <= _to
            );
            if (!string.IsNullOrEmpty(no))
                query = query.Where(q => q.FlightNumber == no);
            if (!string.IsNullOrEmpty(origin))
                query = query.Where(q => q.FromAirportIATA == origin);
            if (!string.IsNullOrEmpty(destination))
                query = query.Where(q => q.ToAirportIATA == destination);
            if (!string.IsNullOrEmpty(register))
                query = query.Where(q => q.Register == register);
            var flights = await query.ToListAsync();
            return new DataResponse
            {
                Data = flights,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> GetFDPFlights(int fdpId)
        {

            var flights = await _context.AppCrewFlights.Where(q =>
                    q.FDPId == fdpId
            ).OrderBy(q => q.STD).ToListAsync();
            return new DataResponse
            {
                Data = flights,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> GetFlightCrews(int flightId)
        {

            var crews = await _context.ViewFlightCrewNewXes.Where(q => q.FlightId == flightId).OrderBy(q => q.IsPositioning).ThenBy(q => q.GroupOrder).ToListAsync();
            return new DataResponse
            {
                Data = crews,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> GetFlightCommanders(int flightId)
        {

            var crews = await _context.ViewFlightCrewNewXes.Where(q => q.FlightId == flightId && q.IsPositioning == false && (q.PositionId == 1160 || q.PositionId == 1161 || q.PositionId == 12000)).OrderBy(q => q.GroupOrder).ToListAsync();

            return new DataResponse
            {
                Data = new
                {
                    commander = crews.FirstOrDefault(),
                    items = crews,
                },
                Errors = null,
                IsSuccess = true
            };
        }


        public async Task<DataResponse> GetFlight(int flightId)
        {
            var flight = await _context.AppLegs.FirstOrDefaultAsync(q => q.ID == flightId);
            return new DataResponse
            {
                Data = flight,
                Errors = null,
                IsSuccess = true
            };

        }
        public async Task<DataResponse> GetOFPPropsByIds(List<int> ids)
        {
            var _ids = ids.Select(q => (Nullable<int>)q).ToList();
            var entity = await _context.OFPImportProps.Where(q => _ids.Contains(q.Id)).ToListAsync();
            return new DataResponse()
            {
                Data = entity,
                IsSuccess = true

            };
        }
        public async Task<DataResponse> GetOFP(int flightId)
        {
            var ofp = await _context.OFPImports.FirstOrDefaultAsync(q => q.FlightId == flightId);
            if (ofp == null)
                return new DataResponse
                {
                    Data = null,
                    Errors = null,
                    IsSuccess = true
                };
            else
                return new DataResponse
                {
                    Data = new
                    {
                        ofp.Id,
                        ofp.FlightId,
                        ofp.TextOutput,
                        ofp.User,
                        ofp.DateCreate,
                        ofp.PIC,
                        ofp.PICId,
                        ofp.JLSignedBy,
                        ofp.JLDatePICApproved

                    },
                    Errors = null,
                    IsSuccess = true
                };

        }
        //GetDRsByFlightIds
        public async Task<DataResponse> GetDRsByFlightIds(List<int?> ids)
        {
            var _drs = await _context.EFBDSPReleases.Where(q => ids.Contains(q.FlightId)).ToListAsync();

            return new DataResponse
            {
                Data = _drs,
                Errors = null,
                IsSuccess = true
            };

        }
        public async Task<DataResponse> GetOFPsByFlightIds(List<int?> ids)
        {
            var _ofps = await _context.OFPImports.Where(q => ids.Contains(q.FlightId)).ToListAsync();
            var ofpIds = _ofps.Select(q => q.Id).ToList();
            var ofpProps = await _context.OFPImportProps.Where(q => ofpIds.Contains(q.OFPId)).ToListAsync();
            //var filledprops = ofpProps.Where(q => !q.User.ToLower().StartsWith("demo") && !q.User.ToLower().StartsWith("dis.")).ToList();
            var props = ofpProps.Select(q => new { q.Id, q.OFPId, q.PropName, q.PropValue, q.User, q.DateUpdate, q.PropType }).ToList();
            return new DataResponse
            {
                Data = new
                {
                    ofps = _ofps.Select(q => new { q.Id, q.DateCreate, q.DateFlight, q.Destination, q.FileName, q.FlightId, q.FlightNo, q.Origin, q.TextOutput, q.User, q.JLSignedBy, q.JLDatePICApproved, q.PIC, q.PICId }).ToList(),
                    ofpProps = props




                },
                Errors = null,
                IsSuccess = true
            };

        }

        public async Task<DataResponse> GetOFPProps(int ofpId)
        {
            var props = await _context.OFPImportProps.Where(q => q.OFPId == ofpId).ToListAsync();

            return new DataResponse
            {
                Data = props,
                Errors = null,
                IsSuccess = true
            };

        }

        public async Task<DataResponse> GetFlightDelays(int flightId)
        {
            var delays = await _context.ViewFlightDelays.FirstOrDefaultAsync(q => q.FlightId == flightId);
            return new DataResponse
            {
                Data = delays,
                Errors = null,
                IsSuccess = true
            };
        }

        public DbSet<AppCrewFlight> GetCrewFlightsQuery()
        {
            return _context.AppCrewFlights;
        }

        public DbSet<AppLeg> GetFlightsQuery()
        {
            return _context.AppLegs;
        }
        public async Task<DataResponse> SaveOFPProps(List<OFPPropViewModel> items)
        {
            var ids = items.Select(q => q.Id).ToList();
            var props = await _context.OFPImportProps.Where(q => ids.Contains(q.Id)).ToListAsync();
            foreach (var item in items)
            {
                var prop = props.Where(q => q.Id == item.Id).FirstOrDefault();
                if (prop == null)
                {
                    prop = new OFPImportProp()
                    {

                    };
                }
                else
                {
                    if (!string.IsNullOrEmpty(item.PropValue) && !string.IsNullOrEmpty(item.PropValue.Trim().Replace(" ", "")))
                    {
                        if (prop.DateUpdateLocal == null || Convert.ToDecimal(item.DateUpdate) > prop.DateUpdateLocal)
                        {
                            prop.DateUpdate = item.DateUpdate; //DateTime.UtcNow.ToString("yyyyMMddHHmmss");
                            prop.User = item.User;
                            prop.PropValue = item.PropValue;
                            prop.DateUpdateLocal = Convert.ToDecimal(item.DateUpdate);
                        }

                    }



                }
            }
            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
                return new DataResponse() { IsSuccess = true, Data = props };
            else
                return new DataResponse() { IsSuccess = false };
        }
        public async Task<DataResponse> SaveOFPProp(int ofpId, string propName, string propValue, string user)
        {

            var prop = await _context.OFPImportProps.Where(q => q.OFPId == ofpId && q.PropName == propName).FirstOrDefaultAsync();
            if (prop == null)
            {
                prop = new OFPImportProp()
                {
                    OFPId = ofpId,

                    PropName = propName,

                };
                _context.OFPImportProps.Add(prop);
            }
            prop.DateUpdate = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            if (!string.IsNullOrEmpty(propValue.Trim().Replace(" ", "")))
                prop.PropValue = propValue;
            prop.User = user;
            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
                return new DataResponse() { IsSuccess = true, Data = new { prop.Id, prop.OFPId, prop.PropName, prop.PropValue, prop.DateUpdate, prop.User, prop.PropType } };
            else
                return new DataResponse() { IsSuccess = false };

        }

        //Task<DataResponse> SaveSign(int flightId,string doc,string user)
        public async Task<DataResponse> SaveSignJL(List<int> flightIds, int pic, string picStr, string doc, string user)
        {
            var flights = await _context.FlightInformations.Where(q => flightIds.Contains(q.ID)).ToListAsync();
            var dt = DateTime.UtcNow;
            foreach (var flight in flights)
            {
                flight.JLSignedBy = user;
                flight.JLDatePICApproved = dt;
                flight.PICId = pic;
                flight.PIC = picStr;
            }
            var saveResult1 = await _context.SaveAsync();
            if (saveResult1.Succeed)
                return new DataResponse() { IsSuccess = true, Data = new { ID = flightIds, PICId = pic, JLSignedBy = user, JLDatePICApproved = dt, PIC = pic } };
            else
                return new DataResponse() { IsSuccess = false };
        }
        public async Task<DataResponse> SaveSign(int flightId, int pic, string picStr, string doc, string user)
        {
            switch (doc)
            {
                case "log":
                    var flight = await _context.FlightInformations.FirstOrDefaultAsync(q => q.ID == flightId);
                    flight.JLSignedBy = user;
                    flight.JLDatePICApproved = DateTime.UtcNow;
                    flight.PICId = pic;
                    flight.PIC = picStr;
                    var saveResult1 = await _context.SaveAsync();
                    if (saveResult1.Succeed)
                        return new DataResponse() { IsSuccess = true, Data = new { flight.ID, flight.PICId, flight.JLSignedBy, flight.JLDatePICApproved, flight.PIC } };
                    else
                        return new DataResponse() { IsSuccess = false };
                case "dr":
                    var dr = await _context.EFBDSPReleases.SingleOrDefaultAsync(q => q.FlightId == flightId);

                    if (dr != null)
                    {
                        dr.JLSignedBy = user;
                        dr.JLDatePICApproved = DateTime.UtcNow;
                        dr.PICId = pic;
                        dr.PIC = picStr;
                        var saveResult2 = await _context.SaveAsync();
                        if (saveResult2.Succeed)
                            return new DataResponse() { IsSuccess = true, Data = new { dr.Id, dr.FlightId, dr.PICId, dr.JLSignedBy, dr.JLDatePICApproved, dr.PIC } };
                        else
                            return new DataResponse() { IsSuccess = false };
                    }
                    else
                        return new DataResponse { IsSuccess = true, Data = null };
                case "asr":
                    var asr = await _context.EFBASRs.SingleOrDefaultAsync(q => q.FlightId == flightId);
                    if (asr != null)
                    {
                        asr.JLSignedBy = user;
                        asr.JLDatePICApproved = DateTime.UtcNow;
                        asr.PICId = pic;
                        asr.PIC = picStr;
                        var saveResult3 = await _context.SaveAsync();
                        if (saveResult3.Succeed)
                            return new DataResponse() { IsSuccess = true, Data = new { asr.Id, asr.FlightId, asr.PICId, asr.JLSignedBy, asr.JLDatePICApproved, asr.PIC } };
                        else
                            return new DataResponse() { IsSuccess = false };
                    }
                    else
                        return new DataResponse { IsSuccess = true, Data = null };
                case "ofp":
                    var ofp = await _context.OFPImports.SingleOrDefaultAsync(q => q.FlightId == flightId);
                    if (ofp != null)
                    {
                        ofp.JLSignedBy = user;
                        ofp.JLDatePICApproved = DateTime.UtcNow;
                        ofp.PICId = pic;
                        ofp.PIC = picStr;
                        var saveResult4 = await _context.SaveAsync();
                        if (saveResult4.Succeed)
                            return new DataResponse() { IsSuccess = true, Data = new { ofp.Id, ofp.FlightId, ofp.PICId, ofp.JLSignedBy, ofp.JLDatePICApproved, ofp.PIC } };
                        else
                            return new DataResponse() { IsSuccess = false };
                    }
                    else
                        return new DataResponse { IsSuccess = true, Data = null };
                case "vr":
                    var vr = await _context.EFBVoyageReports.SingleOrDefaultAsync(q => q.FlightId == flightId);
                    if (vr != null)
                    {
                        vr.JLSignedBy = user;
                        vr.JLDatePICApproved = DateTime.UtcNow;
                        vr.PICId = pic;
                        vr.PIC = picStr;
                        var saveResult5 = await _context.SaveAsync();
                        if (saveResult5.Succeed)
                            return new DataResponse() { IsSuccess = true, Data = new { vr.Id, vr.FlightId, vr.PICId, vr.JLSignedBy, vr.JLDatePICApproved, vr.PIC } };
                        else
                            return new DataResponse() { IsSuccess = false };
                    }
                    else
                        return new DataResponse { IsSuccess = true, Data = null };
                default:
                    return new DataResponse { IsSuccess = true, Data = null };
            }
        }

        public decimal getPropDate(List<LogProp> props, string propName)
        {
            try
            {
                var prop = props.Where(q => q.PropName.ToLower() == propName.ToLower()).FirstOrDefault();
                if (prop == null)
                    return -1;
                if (prop.DateUpdateLocal == null)
                    return -1;
                return Convert.ToDecimal(prop.DateUpdateLocal);
            }
            catch (Exception ex)
            {
                return -1;
            }


        }

        public bool checkLogProp(string dt, string propName, List<LogProp> props)
        {
            if (string.IsNullOrEmpty(dt))
                return false;
            var _dt = Convert.ToDecimal(dt);
            var pd = getPropDate(props, propName);
            if (_dt > pd)
                return true;
            else
                return false;
        }

        void updateProp(int fid,int crew,string name,string date,string value,List<LogProp> props)
        {
            var prop = props.FirstOrDefault(q => q.PropName == name);
            if (prop == null)
            {
                prop = new LogProp()
                {
                    FlightId =fid,
                    User =crew.ToString(),
                    DateUpdate = DateTime.UtcNow,
                    DateUpdateLocal = Convert.ToDecimal(date),
                    PropValue = value,
                    PropName=name,
                };
                _context.LogProps.Add(prop);
            }
            else
            {
                prop.PropValue = value;
                prop.User = crew.ToString();
                prop.DateUpdate = DateTime.UtcNow;
                prop.DateUpdateLocal = Convert.ToDecimal(date);
            }
        }
        public async Task<DataResponse> SaveLog2(LogViewModel2 log)
        {
            var flight = await _context.FlightInformations.FirstOrDefaultAsync(q => q.ID == log.FlightId);
            var props = await _context.LogProps.Where(q => q.FlightId == flight.ID).ToListAsync();

            if (log.BlockOffDate!=null && checkLogProp(log.BlockOffDateDt, "BLOCKOFF", props))
            {
                updateProp(flight.ID, log.CrewId, "BLOCKOFF", log.BlockOffDateDt, log.BlockOffDate.ToString(), props);
                flight.JLOffBlock = log.BlockOffDate;
            }

            if (log.TakeOffDate!=null && checkLogProp(log.TakeOffDateDt, "TAKEOFF", props))
            {
                updateProp(flight.ID, log.CrewId, "TAKEOFF", log.TakeOffDateDt, log.TakeOffDate.ToString(), props);
                flight.JLTakeOff = log.TakeOffDate;
            }


         
            if (log.LandingDate != null && checkLogProp(log.LandingDateDt, "LANDING", props))
            {
                updateProp(flight.ID, log.CrewId, "LANDING", log.LandingDateDt, log.LandingDate.ToString(), props);
                flight.JLLanding = log.LandingDate;
            }

          
            if (log.BlockOnDate != null && checkLogProp(log.BlockOnDateDt, "BLOCKON", props))
            {
                updateProp(flight.ID, log.CrewId, "BLOCKON", log.BlockOnDateDt, log.BlockOnDate.ToString(), props);
                flight.JLOnBlock = log.BlockOnDate;
            }

           
            if (log.FuelDensity != null && checkLogProp(log.FuelDensityDt, "DENSITY", props))
            {
                updateProp(flight.ID, log.CrewId, "DENSITY", log.FuelDensityDt, log.FuelDensity.ToString(), props);
                flight.FuelDensity = log.FuelDensity;
            }

             
            if (log.FuelUplift != null && checkLogProp(log.FuelUpliftDt, "UPLIFT", props))
            {
                updateProp(flight.ID, log.CrewId, "UPLIFT", log.FuelUpliftDt, log.FuelUplift.ToString(), props);
                flight.FuelDeparture = log.FuelUplift;
            }

           
            if (log.FuelRemaining != null && checkLogProp(log.FuelRemainingDt, "FuelRemaining", props))
            {
                updateProp(flight.ID, log.CrewId, "FuelRemaining", log.FuelRemainingDt, log.FuelRemaining.ToString(), props);
                flight.FuelArrival = log.FuelRemaining;
            }

          
            if (log.FuelUsed != null && checkLogProp(log.FuelUsedDt, "FuelUsed", props))
            {
                updateProp(flight.ID, log.CrewId, "FuelUsed", log.FuelUsedDt, log.FuelUsed.ToString(), props);
                flight.UsedFuel = log.FuelUsed;
            }


            
            if (log.PaxAdult != null && checkLogProp(log.PaxAdultDt, "PaxAdult", props))
            {
                updateProp(flight.ID, log.CrewId, "PaxAdult", log.PaxAdultDt, log.PaxAdult.ToString(), props);
                flight.PaxAdult = log.PaxAdult;
            }

           
            if (log.PaxChild != null && checkLogProp(log.PaxChildDt, "PaxAdult", props))
            {
                updateProp(flight.ID, log.CrewId, "PaxChild", log.PaxChildDt, log.PaxChild.ToString(), props);
                flight.PaxChild = log.PaxChild;
            }

             
            if (log.PaxInfant != null && checkLogProp(log.PaxInfantDt, "PaxInfant", props))
            {
                updateProp(flight.ID, log.CrewId, "PaxInfant", log.PaxInfantDt, log.PaxInfant.ToString(), props);
                flight.PaxInfant = log.PaxInfant;
            }


           
            if (log.BaggageWeight != null && checkLogProp(log.BaggageWeightDt, "BaggageWeight", props))
            {
                updateProp(flight.ID, log.CrewId, "BaggageWeight", log.BaggageWeightDt, log.BaggageWeight.ToString(), props);
                flight.BaggageWeight = log.BaggageWeight;
            }

            
            if (log.CargoWeight != null && checkLogProp(log.CargoWeightDt, "CargoWeight", props))
            {
                updateProp(flight.ID, log.CrewId, "CargoWeight", log.CargoWeightDt, log.CargoWeight.ToString(), props);
                flight.CargoWeight = log.CargoWeight;
            }

          
            if (log.SerialNo != null && checkLogProp(log.SerialNoDt, "SerialNo", props))
            {
                updateProp(flight.ID, log.CrewId, "SerialNo", log.SerialNoDt, log.SerialNo.ToString(), props);
                flight.SerialNo = log.SerialNo;
            }

            
            if (log.LTR != null && checkLogProp(log.LTRDt, "LTR", props))
            {
                updateProp(flight.ID, log.CrewId, "LTR", log.LTRDt, log.LTR.ToString(), props);
                flight.LTR = log.LTR;
            }

            
            if (log.PF != null && checkLogProp(log.PFDt, "PF", props))
            {
                updateProp(flight.ID, log.CrewId, "PF", log.PFDt, log.PF.ToString(), props);
                flight.PF = log.PF;
            }

             
            if (log.RVSM_GND_CPT != null && checkLogProp(log.RVSM_GND_CPTDt, "RVSM_GND_CPT", props))
            {
                updateProp(flight.ID, log.CrewId, "RVSM_GND_CPT", log.RVSM_GND_CPTDt, log.RVSM_GND_CPT.ToString(), props);
                flight.RVSM_GND_CPT = log.RVSM_GND_CPT;
            }

           
            if (log.RVSM_GND_STBY != null && checkLogProp(log.RVSM_GND_STBYDt, "RVSM_GND_STBY", props))
            {
                updateProp(flight.ID, log.CrewId, "RVSM_GND_STBY", log.RVSM_GND_STBYDt, log.RVSM_GND_STBY.ToString(), props);
                flight.RVSM_GND_STBY = log.RVSM_GND_STBY;
            }

             
            if (log.RVSM_GND_FO != null && checkLogProp(log.RVSM_GND_FODt, "RVSM_GND_FO", props))
            {
                updateProp(flight.ID, log.CrewId, "RVSM_GND_FO", log.RVSM_GND_FODt, log.RVSM_GND_FO.ToString(), props);
                flight.RVSM_GND_FO = log.RVSM_GND_FO;
            }

            
            if (log.RVSM_FLT_CPT != null && checkLogProp(log.RVSM_FLT_CPTDt, "RVSM_FLT_CPT", props))
            {
                updateProp(flight.ID, log.CrewId, "RVSM_FLT_CPT", log.RVSM_FLT_CPTDt, log.RVSM_FLT_CPT.ToString(), props);
                flight.RVSM_FLT_CPT = log.RVSM_FLT_CPT;
            }
 
            if (log.RVSM_FLT_STBY != null && checkLogProp(log.RVSM_FLT_STBYDt, "RVSM_FLT_STBY", props))
            {
                updateProp(flight.ID, log.CrewId, "RVSM_FLT_STBY", log.RVSM_FLT_STBYDt, log.RVSM_FLT_STBY.ToString(), props);
                flight.RVSM_FLT_STBY = log.RVSM_FLT_STBY;
            }

           
            if (log.RVSM_FLT_FO != null && checkLogProp(log.RVSM_FLT_FODt, "RVSM_FLT_FO", props))
            {
                updateProp(flight.ID, log.CrewId, "RVSM_FLT_FO", log.RVSM_FLT_FODt, log.RVSM_FLT_FO.ToString(), props);
                flight.RVSM_FLT_FO = log.RVSM_FLT_FO;
            }


            
            if (log.AttRepositioning1 != null && checkLogProp(log.AttRepositioning1Dt, "AttRepositioning1", props))
            {
                updateProp(flight.ID, log.CrewId, "AttRepositioning1", log.AttRepositioning1Dt, log.AttRepositioning1.ToString(), props);
                flight.AttRepositioning1 = log.AttRepositioning1;
            }


            
            if (log.AttRepositioning2 != null && checkLogProp(log.AttRepositioning2Dt, "AttRepositioning2", props))
            {
                updateProp(flight.ID, log.CrewId, "AttRepositioning2", log.AttRepositioning2Dt, log.AttRepositioning2.ToString(), props);
                flight.AttRepositioning2 = log.AttRepositioning2;
            }

            
            if (log.CommanderNote != null && checkLogProp(log.CommanderNoteDt, "CommanderNoteDt", props))
            {
                updateProp(flight.ID, log.CrewId, "CommanderNote", log.CommanderNoteDt, log.CommanderNote.ToString(), props);
                flight.CommanderNote = log.CommanderNote;
            }

            flight.JLUserId = log.CrewId;
            flight.JLDate = DateTime.UtcNow;
            flight.Version = log.Version;
            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
            {
                var _flt = await _context.AppCrewFlights.Where(q => q.FlightId == flight.ID && q.CrewId == log.CrewId).FirstOrDefaultAsync();
                return new DataResponse() { IsSuccess = true, Data = new { flight=_flt, props } };
            }
                
            else
                return new DataResponse() { IsSuccess = false };



        }

        public async Task<DataResponse> SaveLog(LogViewModel log)
        {
            var flight = await _context.FlightInformations.FirstOrDefaultAsync(q => q.ID == log.FlightId);
            if (log.BlockOffDate != null)
                flight.JLOffBlock = log.BlockOffDate;

            if (log.TakeOffDate != null)
                flight.JLTakeOff = log.TakeOffDate;

            if (log.LandingDate != null)
                flight.JLLanding = log.LandingDate;

            if (log.BlockOnDate != null)
                flight.JLOnBlock = log.BlockOnDate;

            if (log.FuelDensity != null)
                flight.FuelDensity = log.FuelDensity;

            if (log.FuelUplift != null)
                flight.FuelDeparture = log.FuelUplift;

            if (log.FuelRemaining != null)
                flight.FuelArrival = log.FuelRemaining;

            if (log.FuelUsed != null)
                flight.UsedFuel = log.FuelUsed;


            if (log.PaxAdult != null)
                flight.PaxAdult = log.PaxAdult;

            if (log.PaxChild != null)
                flight.PaxChild = log.PaxChild;

            if (log.PaxInfant != null)
                flight.PaxInfant = log.PaxInfant;


            if (log.BaggageWeight != null)
                flight.BaggageWeight = log.BaggageWeight;

            if (log.CargoWeight != null)
                flight.CargoWeight = log.CargoWeight;

            if (!string.IsNullOrEmpty(log.SerialNo))
                flight.SerialNo = log.SerialNo;

            if (!string.IsNullOrEmpty(log.LTR))
                flight.LTR = log.LTR;

            if (!string.IsNullOrEmpty(log.PF))
                flight.PF = log.PF;

            if (log.RVSM_GND_CPT != null)
                flight.RVSM_GND_CPT = log.RVSM_GND_CPT;

            if (log.RVSM_GND_STBY != null)
                flight.RVSM_GND_STBY = log.RVSM_GND_STBY;

            if (log.RVSM_GND_FO != null)
                flight.RVSM_GND_FO = log.RVSM_GND_FO;

            if (log.RVSM_FLT_CPT != null)
                flight.RVSM_FLT_CPT = log.RVSM_FLT_CPT;

            if (log.RVSM_FLT_STBY != null)
                flight.RVSM_FLT_STBY = log.RVSM_FLT_STBY;

            if (log.RVSM_FLT_FO != null)
                flight.RVSM_FLT_FO = log.RVSM_FLT_FO;


            flight.AttRepositioning1 = log.AttRepositioning1;


            flight.AttRepositioning2 = log.AttRepositioning2;

            if (!string.IsNullOrEmpty(log.CommanderNote))
                flight.CommanderNote = log.CommanderNote;

            flight.JLUserId = log.CrewId;
            flight.JLDate = DateTime.UtcNow;
            flight.Version = log.Version;
            var saveResult = await _context.SaveAsync();
            if (saveResult.Succeed)
                return new DataResponse() { IsSuccess = true, Data = flight.JLDate };
            else
                return new DataResponse() { IsSuccess = false };
        }

        public async Task<DataResponse> CheckLog(LogViewModel log)
        {
            var flight = await _context.AppCrewFlights.FirstOrDefaultAsync(q => q.FlightId == log.FlightId && q.CrewId == log.CrewId);

            return new DataResponse()
            {
                IsSuccess = true,
                //Data = new
                //{
                //    log.FlightId,
                //    flight.JLUserId,
                //    flight.JLDate,
                //    flight.JLUser,
                //}
                Data = flight,
            };

        }

        public async Task<DataResponse> CheckLock(int flightId, string doc)
        {
            var flight = await _context.AppLegs.Where(q => q.FlightId == flightId).Select(q => new { q.FlightStatusID, q.JLSignedBy }).FirstOrDefaultAsync();
            if (flight == null)

                return new DataResponse()
                {
                    IsSuccess = true,

                    Data = new { canLock = false },
                };
            else
            {
                var _canLock = false;
                if (doc == "log")
                    _canLock = (flight.FlightStatusID == 3 || flight.FlightStatusID == 15) && flight.JLSignedBy == null;
                else if (doc == "dr")
                {
                    var obj = await _context.EFBDSPReleases.Select(q => new { q.FlightId, q.JLSignedBy }).FirstOrDefaultAsync(q => q.FlightId == flightId);
                    _canLock = obj != null && obj.JLSignedBy == null && (flight.FlightStatusID == 3 || flight.FlightStatusID == 15);
                }
                else if (doc == "vr")
                {
                    var obj = await _context.EFBVoyageReports.Select(q => new { q.FlightId, q.JLSignedBy }).FirstOrDefaultAsync(q => q.FlightId == flightId);
                    _canLock = obj != null && obj.JLSignedBy == null && (flight.FlightStatusID == 3 || flight.FlightStatusID == 15);
                }
                else if (doc == "asr")
                {
                    var obj = await _context.EFBASRs.Select(q => new { q.FlightId, q.JLSignedBy }).FirstOrDefaultAsync(q => q.FlightId == flightId);
                    _canLock = obj != null && obj.JLSignedBy == null && (flight.FlightStatusID == 3 || flight.FlightStatusID == 15);
                }
                else if (doc == "ofp")
                {
                    var obj = await _context.OFPImports.Select(q => new { q.FlightId, q.JLSignedBy }).FirstOrDefaultAsync(q => q.FlightId == flightId);
                    _canLock = obj != null && obj.JLSignedBy == null && (flight.FlightStatusID == 3 || flight.FlightStatusID == 15);
                }
                else
                    _canLock = flight.FlightStatusID == 3 || flight.FlightStatusID == 15;
                _canLock = true;
                return new DataResponse()
                {
                    IsSuccess = true,

                    Data = new { canLock = _canLock },
                };
            }


        }

        public class Calendar
        {
            public decimal Id { get; set; }
            public DateTime? Date { get; set; }
            public DateTime? DateStart { get; set; }
            public DateTime? DateEnd { get; set; }
            public int? Sectors { get; set; }
            public int? Legs { get; set; }
            public int? DutyType { get; set; }
            public string DutyTypeTitle { get; set; }
            public int? Year { get; set; }
            public int? Month { get; set; }
            public int? Day { get; set; }

            public int? YearEnd { get; set; }
            public int? MonthEnd { get; set; }
            public int? DayEnd { get; set; }
            public decimal? FDPId { get; set; }
            public int? CustomerId { get; set; }
            public string Customer { get; set; }
            public int? CrewId { get; set; }



        }

        public class Duty : Calendar
        {
            public DateTime? RestUntil { get; set; }
            public string Remark { get; set; }
            public string Remark2 { get; set; }
            public DateTime? DateConfirmed { get; set; }
            public int? UPD { get; set; }
            public string ConfirmedBy { get; set; }
            public string UserName { get; set; }
            public DateTime? IStart { get; set; }
            public int? IsSynced { get; set; }
            public DateTime? DutyStart { get; set; }
            public DateTime? DutyEnd { get; set; }
            public decimal? GroupId { get; set; }
            public DateTime? MainStart { get; set; }
            public DateTime? MainEnd { get; set; }
        }


        public async Task<DataResponse> GetCrewCalendarByYearMonth(int crewId, int year, int month)
        {
            var data = await _context.AppFDPRests.Where(q => q.CrewId == crewId &&
             ((q.Year == year && q.Month == month) || (q.YearEnd == year && q.MonthEnd == month))

            )
                .Select(q => new Calendar()
                {
                    Id = q.Id,
                    Date = q.DateDutyStart,
                    DateEnd = q.DateDutyEnd,
                    DateStart = q.DateDutyStart,
                    Day = q.Day,
                    DayEnd = q.DayEnd,
                    DutyType = q.DutyType,
                    DutyTypeTitle = q.DutyTypeTitle,
                    Legs = q.Legs,
                    Month = q.Month,
                    MonthEnd = q.MonthEnd,
                    Sectors = q.Sectors,
                    Year = q.Year,
                    YearEnd = q.YearEnd

                }

                ).ToListAsync();
            var result = data.Where(q => q.DateEnd == q.DateStart).ToList();
            var rows = data.Where(q => q.DutyType != 1165 && q.DateEnd != q.DateStart).ToList();
            foreach (var q in rows)
            {
                var sd = (DateTime)q.DateStart;
                while (sd <= q.DateEnd)
                {
                    result.Add(new Calendar()
                    {
                        Id = q.Id,
                        Date = sd,
                        DateEnd = sd,
                        DateStart = sd,
                        Day = (sd).Day,
                        DayEnd = (sd).Day,
                        DutyType = q.DutyType,
                        DutyTypeTitle = q.DutyTypeTitle,
                        Legs = q.Legs,
                        Month = sd.Month,
                        MonthEnd = sd.Month,
                        Sectors = q.Sectors,
                        Year = sd.Year,
                        YearEnd = sd.Year

                    });
                    sd = sd.AddDays(1);
                }
            }
            return new DataResponse()
            {
                IsSuccess = true,

                Data = result,
            };
        }

        public async Task<DataResponse> GetCrewDuties(int crewId, DateTime from, DateTime to, int noFDP)
        {
            var query = _context.AppFDPRests.Where(q => q.CrewId == crewId &&
              ((q.DateDutyStart >= from && q.DateDutyStart <= to) || (q.DateDutyEnd >= from && q.DateDutyEnd <= to))

           );
            if (noFDP == 1)
                query = query.Where(q => q.DutyType != 1165);
            var data = await query
               .Select(q => new Duty()
               {
                   Id = q.Id,
                   Date = q.DateDutyStart,
                   DateEnd = q.DateDutyEnd,
                   DateStart = q.DateDutyStart,
                   Day = q.Day,
                   DayEnd = q.DayEnd,
                   DutyType = q.DutyType,
                   DutyTypeTitle = q.DutyTypeTitle,
                   Legs = q.Legs,
                   Month = q.Month,
                   MonthEnd = q.MonthEnd,
                   Sectors = q.Sectors,
                   Year = q.Year,
                   YearEnd = q.YearEnd,
                   Remark = q.Remark,
                   Remark2 = q.Remark2,
                   RestUntil = q.RestUntil,
                   DateConfirmed = q.DateConfirmed,
                   UserName = q.UserName,
                   UPD = q.UPD,
                   ConfirmedBy = q.ConfirmedBy,
                   IStart = q.IStart,
                   FDPId = q.Id,
                   IsSynced = q.IsSynced,
                   Customer = q.Customer,
                   CustomerId = q.CustomerId,
                   DutyStart = q.DutyStart,
                   DutyEnd = q.DutyEnd,
                   GroupId = q.Id,
                   CrewId = q.CrewId,

               }

               ).ToListAsync();
            var result = data.Where(q => q.DateEnd == q.DateStart).ToList();

            var rows = data.Where(q => q.DutyType != 1165 && q.DateEnd != q.DateStart).ToList();
            foreach (var q in rows)
            {
                List<Duty> result2 = new List<Duty>();
                var sd = (DateTime)q.DateStart;
                var c = 0;
                while (sd <= q.DateEnd)
                {
                    var _id = Convert.ToDecimal(Convert.ToInt32(q.Id).ToString() + q.CrewId.ToString() + c.ToString());
                    result2.Add(new Duty()
                    {
                        Id = _id,
                        Date = sd,
                        DateEnd = sd,
                        DateStart = sd,
                        Day = (sd).Day,
                        DayEnd = (sd).Day,
                        DutyType = q.DutyType,
                        DutyTypeTitle = q.DutyTypeTitle,
                        Legs = q.Legs,
                        Month = sd.Month,
                        MonthEnd = sd.Month,
                        Sectors = q.Sectors,
                        Year = sd.Year,
                        YearEnd = sd.Year,
                        Remark = q.Remark,
                        Remark2 = q.Remark2,
                        RestUntil = q.RestUntil,
                        IStart = c == 0 ? q.IStart : sd,
                        FDPId = _id,
                        IsSynced = q.IsSynced,
                        Customer = q.Customer,
                        CustomerId = q.CustomerId,
                        DateConfirmed = q.DateConfirmed,
                        UserName = q.UserName,
                        UPD = q.UPD,
                        ConfirmedBy = q.ConfirmedBy,
                        DutyStart = sd,
                        DutyEnd = sd.AddHours(24),
                        MainStart = q.DutyStart,
                        MainEnd = q.DutyEnd,
                        GroupId = q.Id,
                        CrewId = q.CrewId,

                    });
                    sd = sd.AddDays(1);
                    c++;
                }
                if (result2.Count > 0)
                {
                    result2[0].DutyStart = q.DutyStart;
                    result2.Last().DutyEnd = q.DutyEnd;

                }
                result = result.Concat(result2).ToList();
            }

            return new DataResponse()
            {
                IsSuccess = true,

                Data = result,
            };
        }
        public async Task<DataResponse> GetCrewCalendarByYearMonth(int crewId, DateTime from, DateTime to)
        {
            var data = await _context.AppFDPRests.Where(q => q.CrewId == crewId &&
             ((q.DateDutyStart >= from && q.DateDutyStart <= to) || (q.DateDutyEnd >= from && q.DateDutyEnd <= to))

            )
                .Select(q => new Calendar()
                {
                    Id = q.Id,
                    Date = q.DateDutyStart,
                    DateEnd = q.DateDutyEnd,
                    DateStart = q.DateDutyStart,
                    Day = q.Day,
                    DayEnd = q.DayEnd,
                    DutyType = q.DutyType,
                    DutyTypeTitle = q.DutyTypeTitle,
                    Legs = q.Legs,
                    Month = q.Month,
                    MonthEnd = q.MonthEnd,
                    Sectors = q.Sectors,
                    Year = q.Year,
                    YearEnd = q.YearEnd

                }

                ).ToListAsync();
            var result = data.Where(q => q.DateEnd == q.DateStart).ToList();
            var rows = data.Where(q => q.DutyType != 1165 && q.DateEnd != q.DateStart).ToList();
            foreach (var q in rows)
            {
                var sd = (DateTime)q.DateStart;
                while (sd <= q.DateEnd)
                {
                    result.Add(new Calendar()
                    {
                        Id = q.Id,
                        Date = sd,
                        DateEnd = sd,
                        DateStart = sd,
                        Day = (sd).Day,
                        DayEnd = (sd).Day,
                        DutyType = q.DutyType,
                        DutyTypeTitle = q.DutyTypeTitle,
                        Legs = q.Legs,
                        Month = sd.Month,
                        MonthEnd = sd.Month,
                        Sectors = q.Sectors,
                        Year = sd.Year,
                        YearEnd = sd.Year

                    });
                    sd = sd.AddDays(1);
                }
            }
            return new DataResponse()
            {
                IsSuccess = true,

                Data = result,
            };
        }



    }
}
