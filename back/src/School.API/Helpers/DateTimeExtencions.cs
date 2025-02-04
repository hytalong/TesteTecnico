using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Helpers
{
    public static class DateTimeExtencions
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var currentDate = DateTime.UtcNow;
            int age = (currentDate.Year - dateTime.Year);

            if(currentDate < dateTime.AddYears(age))
                age--;
            
            return age;
        }
    }
}