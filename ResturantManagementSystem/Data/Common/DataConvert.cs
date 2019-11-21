using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Data.Common
{
    internal static class DataConvert
    {
        internal static int ToInt(object element)
        {
            return (element == DBNull.Value ? 0 : Convert.ToInt32(element));
        }

        internal static DateTime ToDateTime(object element)
        {
            return (element == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(element));
        }

        internal static string ToString(object element)
        {
            return (element == DBNull.Value ? string.Empty : Convert.ToString(element));
        }

        internal static bool ToBoolean(object element)
        {
            return (element == DBNull.Value ? false : Convert.ToBoolean(element));
        }

        internal static Decimal ToDecimal(object element)
        {
            return (element == DBNull.Value ? 0m : Convert.ToDecimal(element));
        }
    }
}
