using System;

namespace EmployeeManagement.BuildingBlocks
{
    public static class Extensions
    {
        public static DateTime ConvertToEST(this DateTime dateTime) 
        {
            // Specifying the Eastern Standard Time zone
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var a = dateTime;
            // Convert UTC time to EST
            DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, estZone);

            return estTime;
        }

    }
}
