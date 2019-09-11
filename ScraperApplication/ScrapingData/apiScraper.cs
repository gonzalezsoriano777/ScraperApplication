using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using ScraperApplication.Models;

namespace ScraperApplication.ScrapingData
{
    public class ApiScraper
    {
        public void ScrapeFromContent()
        {
            // Initialized restSharper to grab the api url
            RestClient client = new RestClient("https://morning-star.p.rapidapi.com/market/get-summary");
            RestRequest request = new RestRequest(Method.GET);

            request.AddHeader("x-rapidapi-host", "morning-star.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "bfab8a0181mshf12c4afb207144ap126f55jsnecf3c75cf681");

            IRestResponse response = client.Execute(request);
            var content = response.Content.ToString();

            // Console.WriteLine(content);

            dynamic stockDataAsJObject = JsonConvert.DeserializeObject(content);

            JArray USAStockData = stockDataAsJObject["MarketRegions"]["USA"];

            // Console.WriteLine(USAStockData);

            // string sym = Convert.ToString(stockDataAsJObject["MarketRegions"]["USA"][0]["Exchange"]);

            // Console.WriteLine(stockDataAsJObject["MarketRegions"]["USA"][0]["Exchange"]);

            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=apiDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                Console.WriteLine("Database has been opened!");
                Console.WriteLine();

                foreach (JToken stocks in USAStockData)
                {
                    SqlCommand insertion = new SqlCommand("INSERT INTO dbo.apiScrapeTable (StockRecord, Symbol, LastPrice, PercentChange, MarketChange) VALUES ( @stockRecord, @symbol, @lastPrice, @percentChange, @marketChange )", db);

                    insertion.Parameters.AddWithValue("@stockRecord", DateTime.Now);
                    insertion.Parameters.AddWithValue("@symbol", stocks["Exchange"].ToString());
                    insertion.Parameters.AddWithValue("@lastPrice", stocks["Price"].ToString());
                    insertion.Parameters.AddWithValue("@percentChange", stocks["PercentChange"].ToString());
                    insertion.Parameters.AddWithValue("@marketChange", stocks["PriceChange"].ToString());

                    insertion.ExecuteNonQuery();
                }

                db.Close();
                Console.WriteLine("Database has been updated with data!");
                Console.WriteLine();


            }

        }
    }
}
