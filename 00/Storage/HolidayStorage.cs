using System.Collections.Generic;
using _00.Models;

namespace _00.Storage
{
    public class HolidayStorage
    {
        public static Result ConvertToResult(Holiday holiday)
        {
            var result = new Result
            {
                Date = holiday.Date,
                Name = holiday.Name,
                LocalName = holiday.LocalName
            };
            return result;
        }
    }
}