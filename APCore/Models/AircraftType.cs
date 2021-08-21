using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AircraftType
    {
        public AircraftType()
        {
            AircraftModels = new HashSet<AircraftModel>();
            BookRelatedAircraftTypes = new HashSet<BookRelatedAircraftType>();
            CaoTypes = new HashSet<CaoType>();
            CourseAircraftTypes = new HashSet<CourseAircraftType>();
            CourseRelatedAircraftTypes = new HashSet<CourseRelatedAircraftType>();
            Courses = new HashSet<Course>();
            FlightInformations = new HashSet<FlightInformation>();
            FlightPlanItems = new HashSet<FlightPlanItem>();
            PersonAircraftTypes = new HashSet<PersonAircraftType>();
            PersonRatings = new HashSet<PersonRating>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public int ManufacturerId { get; set; }
        public string Remark { get; set; }

        public virtual Organization Manufacturer { get; set; }
        public virtual ICollection<AircraftModel> AircraftModels { get; set; }
        public virtual ICollection<BookRelatedAircraftType> BookRelatedAircraftTypes { get; set; }
        public virtual ICollection<CaoType> CaoTypes { get; set; }
        public virtual ICollection<CourseAircraftType> CourseAircraftTypes { get; set; }
        public virtual ICollection<CourseRelatedAircraftType> CourseRelatedAircraftTypes { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<FlightInformation> FlightInformations { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItems { get; set; }
        public virtual ICollection<PersonAircraftType> PersonAircraftTypes { get; set; }
        public virtual ICollection<PersonRating> PersonRatings { get; set; }
    }
}
