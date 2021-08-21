using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class EFBBirdStrikeCAO
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int? OperatorId { get; set; }
        public string EngineModel { get; set; }
        public DateTime? Date { get; set; }
        public int? LocalTimeId { get; set; }
        public string AerodromeName { get; set; }
        public string RunwayUsed { get; set; }
        public string EnRouteLoc { get; set; }
        public decimal? HeightAGl { get; set; }
        public decimal? Speed_IAS_ { get; set; }
        public int? PhaseOrFlightId { get; set; }
        public int? A_CPartRadom { get; set; }
        public int? A_CPartWindShield { get; set; }
        public int? A_CPartNose { get; set; }
        public int? A_CPartEngineNO1 { get; set; }
        public int? A_CPartEngineNO2 { get; set; }
        public int? A_CPartEngineNO3 { get; set; }
        public int? A_CPartEngineNO4 { get; set; }
        public int? A_CPartPropeller { get; set; }
        public int? A_CPartWing_Rotor { get; set; }
        public int? A_CPartFuselage { get; set; }
        public int? A_CPartLandingGear { get; set; }
        public int? A_CPartTail { get; set; }
        public int? A_CPartLight { get; set; }
        public int? A_CPartOther_Specify_ { get; set; }
        public bool? IsEffect__None { get; set; }
        public bool? IsEffectAbortedTakeOff { get; set; }
        public bool? IsEffectLanding { get; set; }
        public bool? IsEffectEngineShutDown { get; set; }
        public bool? IsEffectOther { get; set; }
        public int? SkyConditionId { get; set; }
        public int? IsPrecipitationFog { get; set; }
        public int? IsPrecipitationRain { get; set; }
        public int? IsPrecipitationSnow { get; set; }
        public string BirdSpecies { get; set; }
        public int? BirdNrSeenId { get; set; }
        public int? BirdNrStruckId { get; set; }
        public int? BirdSizeId { get; set; }
        public bool? IspilotWarned { get; set; }
        public string Remarks { get; set; }
        public int? ReportedById { get; set; }
    }
}
