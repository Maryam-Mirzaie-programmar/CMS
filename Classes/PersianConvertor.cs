using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace MyCms
{
    public static class PersianConvertor
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            string persianDate =$"{pc.GetDayOfMonth(dateTime).ToString("00")}  / {pc.GetMonth(dateTime).ToString("00")} / {pc.GetYear(dateTime).ToString()}";
            return persianDate;
        }
    }
}