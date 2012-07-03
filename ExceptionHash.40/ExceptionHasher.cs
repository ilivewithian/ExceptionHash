using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHash
{
    public static class ExceptionHasher
    {
        public static string Hash(this Exception target)
        {
            if (target == null)
            {
                throw new NullReferenceException();
            }

            return string.Format("{0:X8}", GetExceptionString(target).GetHashCode());
        }

        private static string GetExceptionString(Exception exc)
        {
            string result = exc.Message + exc.StackTrace;

            if (exc.InnerException != null)
            {
                result = result + GetExceptionString(exc.InnerException);
            }

            return result;
        }
    }
}
