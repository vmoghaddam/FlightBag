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

        DbSet<AppCrewFlight> GetCrewFlightsQuery();
        DbSet<AppLeg> GetFlightsQuery();
        Task<DataResponse> GetFlightCrews(int flightId);
        Task<DataResponse> GetFlight(int flightId);
        Task<DataResponse> GetFlightDelays(int flightId);
        Task<DataResponse> SaveLog(LogViewModel log);
        Task<DataResponse> CheckLog(LogViewModel log);
        Task<DataResponse> GetCrewCalendarByYearMonth(int crewId, int year, int month);
        Task<DataResponse> GetCrewCalendarByYearMonth(int crewId, DateTime from, DateTime to);
        Task<DataResponse> GetCrewDuties(int crewId, DateTime from, DateTime to, int noFDP);
        Task<DataResponse> GetFDPFlights(int fdpId);

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

        public async Task<DataResponse> GetFDPFlights(int fdpId)
        {
           
            var flights = await _context.AppCrewFlights.Where(q =>
                    q.FDPId==fdpId
            ).OrderBy(q=>q.STD).ToListAsync();
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

        public async Task<DataResponse> SaveLog(LogViewModel log)
        {
            var flight = await _context.FlightInformations.FirstOrDefaultAsync(q => q.ID == log.FlightId);
            flight.JLOffBlock = log.BlockOffDate; //Helper.ConvertToDate(log.BlockOff);
            flight.JLTakeOff = log.TakeOffDate; //Helper.ConvertToDate(log.TakeOff);
            flight.JLLanding = log.LandingDate; //Helper.ConvertToDate(log.Landing);
            flight.JLOnBlock = log.BlockOnDate; //Helper.ConvertToDate(log.BlockOn);

            flight.FuelDensity = log.FuelDensity;
            flight.FuelDeparture = log.FuelUplift;
            flight.FuelArrival = log.FuelRemaining;
            flight.UsedFuel = log.FuelUsed;



            flight.PaxAdult = log.PaxAdult;
            flight.PaxChild = log.PaxChild;
            flight.PaxInfant = log.PaxInfant;

            flight.BaggageWeight = log.BaggageWeight;
            flight.CargoWeight = log.CargoWeight;

            flight.SerialNo = log.SerialNo;
            flight.LTR = log.LTR;
            flight.PF = log.PF;

            flight.RVSM_GND_CPT = log.RVSM_GND_CPT;
            flight.RVSM_GND_STBY = log.RVSM_GND_STBY;
            flight.RVSM_GND_FO = log.RVSM_GND_FO;

            flight.RVSM_FLT_CPT = log.RVSM_FLT_CPT;
            flight.RVSM_FLT_STBY = log.RVSM_FLT_STBY;
            flight.RVSM_FLT_FO = log.RVSM_FLT_FO;

            flight.AttRepositioning1 = log.AttRepositioning1;
            flight.AttRepositioning2 = log.AttRepositioning2;

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
                   IStart=q.IStart,
                   FDPId=q.Id,
                   IsSynced=q.IsSynced,
                   Customer=q.Customer,
                   CustomerId=q.CustomerId,
                   DutyStart=q.DutyStart,
                   DutyEnd=q.DutyEnd,
                   GroupId=q.Id,
                   CrewId=q.CrewId,

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
                    var _id =Convert.ToDecimal(Convert.ToInt32( q.Id).ToString() + q.CrewId.ToString() + c.ToString());
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
                        IStart=c==0?q.IStart:sd,
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
                        MainStart=q.DutyStart,
                        MainEnd=q.DutyEnd,
                        GroupId=q.Id,
                        CrewId=q.CrewId,

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
