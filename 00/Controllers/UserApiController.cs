using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using _00.Models;
using Newtonsoft.Json;

namespace _00.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserApiController : ControllerBase
    {
        static readonly HttpClient Client = new HttpClient();

      //  [HttpGet]
      //  public async Task<List<Holiday>> GetHolidays(string countryCode, int year)
     //   {
     //       List<Holiday> _holidays = null;
     //       var URL = $"https://date.nager.at/api/v1/Get/{countryCode}/{year}";
      //      string responseBody = await Client.GetStringAsync(URL);
    //        _holidays = JsonConvert.DeserializeObject<List<Holiday>>(responseBody);
    //        return _holidays;
    //    }

        [HttpGet]
        public async Task<List<Result>> GetHolidays(string countryCodeForFirstCountry, string countryCodeForSecondCountry, int year)
        {
            List<Result> _holidays = new List<Result>();
            var firstUrl = $"https://date.nager.at/api/v1/Get/{countryCodeForFirstCountry}/{year}";
            var secondUrl = $"https://date.nager.at/api/v1/Get/{countryCodeForSecondCountry}/{year}";
            string firstResponseBody = await Client.GetStringAsync(firstUrl);
            string secondResponseBody = await Client.GetStringAsync(secondUrl);
            List<Holiday> firstCountryHolidays = JsonConvert.DeserializeObject<List<Holiday>>(firstResponseBody);
            List<Holiday> secondCountryHolidays = JsonConvert.DeserializeObject<List<Holiday>>(secondResponseBody);
            var bothCountryHolidays = firstCountryHolidays.Concat(secondCountryHolidays).ToList();
            for (int i = 0; i <= bothCountryHolidays.Count-1; i++)
            {
                foreach (var holiday in bothCountryHolidays)
                {
                    if (bothCountryHolidays[i].Name == holiday.Name)
                    {
                        _holidays.Add(new Result()
                        {
                            Name = bothCountryHolidays[i].Name,
                            Date = bothCountryHolidays[i].Date,
                            LocalName = new List<string>()
                            {
                                bothCountryHolidays[i].LocalName,
                                holiday.LocalName
                            }

                        });
                    }
                }
            }
            return _holidays;
        }
    }
}