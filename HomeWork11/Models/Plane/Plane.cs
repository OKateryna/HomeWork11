using System;

namespace HomeWork11.Models.Plane
{
    public class Plane
    {
        public int Id { get; set; }
        public string PlaneName { get; set; }
        public PlaneType.PlaneType PlaneType { get; set; }
        public DateTime ManufectureDate { get; set; }
        public int LifeSpan { get; set; }
    }
}