using System;

namespace BpstEducation.ViewModels
{
    public class StudentCourseViewModel
    {
        // -------------------- Student Details --------------------
        public string FullName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public string AadhaarNumber { get; set; }
        public string PanNumber { get; set; }
        public string? AadharFileUrl { get; set; }
        public string? PanFileUrl { get; set; }

        // -------------------- Batch Details --------------------
        public string BatchTitle { get; set; }
        public string BatchDescription { get; set; }
        public string BatchDuration { get; set; }
        public DateTime BatchStartDate { get; set; }
        public int BatchFee { get; set; }
        public string BatchDisplayName { get; set; }
        public int RemainingDays { get; set; }

        // -------------------- Course Details --------------------
        public string CourseName { get; set; }
        public bool CourseInternshipAvailable { get; set; }

        // -------------------- Optional --------------------
        public string? CourseOfInterestName { get; set; }
    }
}
