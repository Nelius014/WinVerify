using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  WinVerify
{
  

    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<KeyValuePair<long, string>> Sites { get; set; }
        public string DeviceGUID { get; set; }

    }

    public class RegisterRequest
    {
        public string CompanyID { get; set; }
        public string ApplicationGUID { get; set; }
        public string DeviceSpecs { get; set; }
        public string DeviceGUID { get; set; }

        public long SiteID { get; set; }
    }

    public class Attendance
    {
        public string DeviceID { get; set; }

        public string ApplicationGUID { get; set; }

        public string Image { get; set; }

        public string DateTime { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public int ClockStatus { get; set; }

        public string EmployeeID { get; set; }

    }

    public class VerifyResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
        public int UserStatus { get; set; }
        public string EmployeeID { get; set; }
        public List<KeyValuePair<string, string>> AdditionalData { get; set; }

    }
}
