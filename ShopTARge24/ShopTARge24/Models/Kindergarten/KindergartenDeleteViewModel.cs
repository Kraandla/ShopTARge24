﻿namespace ShopTARge24.Models.Kindergarten
{
    public class KindergartenDeleteViewModel
    {
        public Guid? Id { get; set; }
        public string? KindergartenName { get; set; }
        public string? GroupName { get; set; }
        public string? TeacherName { get; set; }
        public int? ChildCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
