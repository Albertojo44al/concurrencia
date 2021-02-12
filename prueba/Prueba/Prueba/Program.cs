using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prueba
{
    class Program
    {
        private static object objeto  = new Object();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Ingrese los tickers");
            string tickers = Console.ReadLine();
            string[] tickersArray;
            tickersArray = tickers.Split(",");
           
            Parallel.ForEach(tickersArray, async (ticker,index )=>
            {
                var data = await GetAlbums(ticker);
                Average(data);
            });
             
            
        }

            private static async Task<IEnumerable<Stock>> GetAlbums(string ticker)
            {
                
                using (var client = new HttpClient())
                {
                    var response = await client.GetStreamAsync($"https://stooq.com/q/d/l/?s={ticker}&i=d");
                    using (var reader = new StreamReader(response))

                    {

                        using (var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)

                        {}))

                        {
                            return csvReader.GetRecords<Stock>().ToList();
                        }

                    }
                }
            }
        }

    private static IEnumerable<CalculationResult> Average(IEnumerable<Stock> data)

    {

        return data.GroupBy(x => x.Date.Year, (k, g) => new CalculationResult

        { 
            Year = k,

            Result = g.Average(s => s.Close)

        }).ToList();

    }

    class Stock
    {
        public int Date { 
            get; 
            set;

        }
        public int Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
    }

    class CalculationResult
    {
        public int Year { get; set; }
        public int Result { get; set; }
    }
}
