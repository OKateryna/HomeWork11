using System;

namespace HomeWork11.Models.Plane
{
    public class EditablePlaneFields
    {
        public string PlaneName { get; set; }
        public int PlaneTypeId { get; set; }
        public DateTime ManufectureDate { get; set; }
        public int LifeSpan { get; set; }
    }
}