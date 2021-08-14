using System;
using System.Collections.Generic;
using System.Text;

namespace Tron
{
    public class JSON
    {
        public Vignette Vignette { get; set; }
        public bool Ok { get; set; }
        public Status Status { get; set; }
    }

    public class Vignette
    {
        public string LicensePlateNumber { get; set; }
        public string Country { get; set; }
        public string Exempt { get; set; }
        public string VignetteNumber { get; set; }
        public string VehicleClass { get; set; }
        public string EmissionsClass { get; set; }
        public string ValidityDateFromFormated { get; set; }
        public string ValidityDateFrom { get; set; }
        public string ValidityDateToFormated { get; set; }
        public string ValidityDateTo { get; set; }
        public string IssueDateFormated { get; set; }
        public string IssueDate { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public bool Whitelist { get; set; }
        public bool StatusBoolean { get; set; }
        public string VehicleType { get; set; }
        public string VehicleClassCode { get; set; }
        public string EmissionsClassCode { get; set; }
        public string VehicleTypeCode { get; set; }
    }

    public class Status
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
