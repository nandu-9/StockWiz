using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDataController : ControllerBase
    {
        // Need to change this implimentation by using configuration procedure
        private string API_KEY = "Q7VUS7OFT17PHC85";
        public StockDataController()
        {
            
        }

        [HttpGet("get-demo-data")]
        public async Task<IActionResult> GetDemoData() {
            
            
            HttpClient client = new HttpClient();

            string data = await client.GetStringAsync(ModifyQuery());
            return Ok(data);
        }

        [HttpGet("get-data/{sym}")]
        public async Task<IActionResult> GetStockDataByCompany(string sym) 
        {
            HttpClient client = new HttpClient();

            string data = await client.GetStringAsync(ModifyQuery(cmp_sym:sym));
            return Ok(data);
        }

        [HttpGet("get-data/{sym}/{interval}")]
        public async Task<IActionResult> GetStockDataByCompanyAndInterval(string sym, string interval) 
        {
            HttpClient client = new HttpClient();

            string data = await client.GetStringAsync(ModifyQuery(cmp_sym: sym,interval:interval));
            return Ok(data);
        }

        // Helper method for modifying the query
        private Uri ModifyQuery(string function= "TIME_SERIES_INTRADAY",string cmp_sym="IBM",string interval="5min") {

            // Possible functions: TIME_SERIES_INTRADAY, TIME_SERIES_DAILY, TIME_SERIES_DAILY_ADJUSTED
            // Possible intervals: 1min, 5min, 15min, 30min
            string query = $"https://www.alphavantage.co/query?function={function}&symbol={cmp_sym}&interval={interval}&apikey={API_KEY}";
            return new Uri(query);
        }
    }
}
