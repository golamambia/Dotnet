using System;

namespace RMS.Process
{
    public static class CommonProcess
    {
        internal static string GetDetailException(Exception ex)
        {
            return String.Format("{0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace);
        }
    }
}
