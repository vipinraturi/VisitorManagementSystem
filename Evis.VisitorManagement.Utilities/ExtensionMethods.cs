/********************************************************************************
 * File Name    : ExtensionMethods.cs
 * Company Name : East Vision Information System
 * Author       : Shambhoo
 * Created On   : 01/20/2016
 * Description  : 
 *******************************************************************************/

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Evis.eLearning.Business
{
    public static class ExtensionMethods
    {
        public static string GetDateFormat(this DateTime dateTime)
        {
            return string.Format("{0:MM/dd/yyyy}", dateTime);
        }

        public static string ToMoney(this double money)
        {
            return string.Format("{0:C}", money);
        }

        public static string GetFileSize(this long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        public static DateTime GetDateFormatForStringDate(this string dateTime)
        {
            DateTime date;
            string[] formats =
                {
                    "MM/dd/yyyy", "M/dd/yyyy", "MM-dd-yyyy", "dd-MM-yyyy", "M-dd-yyyy", "M/d/yyyy h:mm:ss tt","M/d/yyyy h:m:ss",
                    "M/d/yyyy","M/d/yyyy h:mm tt", "MM-dd-yyyy hh:mm tt",
                    "MM/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "MM/d/yyyy h:mm tt", "M/dd/yyyy h:mm tt",
                    "dd-MM-yyyy h:mm:ss tt","dd-MM-yyyy hh:mm:ss", "dd-MM-yyyy h:mm tt", "yyyy-MM-dd", "yy/MM/dd", "dd-MMM-yy", "M/d/yy",
                    "yyyy-MM-dd h:mm:ss tt", "yyyy-MM-dd h:mm tt"
                    , "yy/MM/dd h:mm:ss tt", "yy/MM/dd h:mm tt", "dd-MMM-yy h:mm:ss tt", "dd-MMM-yy h:mm tt",
                    "M/d/yy h:mm:ss tt", "M/d/yy h:mm tt", "M/dd/yyyy", "M/dd/yyyy h:mm tt", "M/dd/yyyy h:mm:ss tt"
                };
            DateTime.TryParseExact(dateTime, formats, CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out date);
            return date;
        }

        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value); if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                     Attribute.GetCustomAttribute(field,
                     typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}
