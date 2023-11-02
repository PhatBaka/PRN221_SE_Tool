using SETool_Data.Models.Entities;
using System;

namespace SETool_Data.Extensions
{
    public static class DateTimePicker
    {
        public static DateTime GetDateTimeByTimeZone()
        {
            TimeZoneInfo timeZoneInfo;
            DateTime dateTime;
            //Set the time zone information to US Mountain Standard Time 
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            //Get date and time in US Mountain Standard Time 
            dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            //Print out the date and time
            return dateTime;
        }

        public static bool CheckDateTimeInRange(DateTime start, DateTime end)
        {
            if (GetDateTimeByTimeZone() >= start && GetDateTimeByTimeZone() <= end)
                return true;
            return false;
        }

        public static string CreateSemesterString(string vacation)
        {
            return vacation + GetDateTimeByTimeZone().Year.ToString();
        }

        public static DateTime? GetFirstDateOfSemester(string vacation)
        {
            if (vacation == "SP")
                return new DateTime(GetDateTimeByTimeZone().Year, 1, 1, 0, 0, 0);
            else if (vacation == "SM")
                return new DateTime(GetDateTimeByTimeZone().Year, 4, 1, 0, 0, 0);
            else if (vacation == "FA")
                return new DateTime(GetDateTimeByTimeZone().Year, 10, 1, 0, 0, 0);
            return null;
        }

        public static DateTime? GetLastDateOfSemester(string vacation)
        {
            if (vacation == "SP")
                return new DateTime(GetDateTimeByTimeZone().Year, 4, 30, 11, 59, 59);
            else if (vacation == "SM")
                return new DateTime(GetDateTimeByTimeZone().Year, 8, 31, 11, 59, 59);
            else if (vacation == "FA")
                return new DateTime(GetDateTimeByTimeZone().Year, 12, 31, 11, 59, 59);
            return null;
        }

        public static string GetCurrentVacation()
        {
            int month = DateTimePicker.GetDateTimeByTimeZone().Month;
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return "SP";
                case 5:
                case 6:
                case 7:
                case 8:
                    return "SU";
                case 9:
                case 10:
                case 11:
                case 12:
                    return "FA";
            }
            return null;
        }
    }
}
