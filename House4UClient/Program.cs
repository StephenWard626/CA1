using House4U.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace House4UClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllHouses().Wait();
            Console.WriteLine();
            GetAHouse().Wait();
            Console.WriteLine();
            //Causing issues - fix if possible
            //GetAllEmails().Wait();
            Console.WriteLine();
            AddAProperty().Wait();
            Console.WriteLine();
            UpdateBedrooms().Wait();
        }

        private static async Task GetAllHouses()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44372/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/house");

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Houses> prop = await response.Content.ReadAsAsync<IEnumerable<Houses>>();

                foreach (Houses h in prop)
                {
                    Console.WriteLine(h);
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode + "Reason Phrase:  " + response.ReasonPhrase);
            }

        }

        private static async Task GetAHouse()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44372/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/house/3");

            if (response.IsSuccessStatusCode)
            {
                Houses prop = await response.Content.ReadAsAsync<Houses>();

                if (prop != null)
                {
                    Console.WriteLine("Property is: " + prop.ToString());
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode + "Reason Phrase:  " + response.ReasonPhrase);
            }

        }

        private static async Task GetAllEmails()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44372/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/house/email");

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Houses> prop = await response.Content.ReadAsAsync<IEnumerable<Houses>>();

                foreach (Houses h in prop)
                {
                    Console.WriteLine(h);
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode + "Reason Phrase:  " + response.ReasonPhrase);
            }

        }

        private static async Task AddAProperty()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44372/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            Houses newHouse = new Houses() { ID = 012, Address = "351 Farmington Ave., Hartford", Bedrooms = 1, Lease = LeaseType.Managed, ExpiryDate = DateTime.Today, Email = "mtwain@hotmail.com" };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/House", newHouse);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Property has been added to the porfolio.");
            }
            else
            {
                Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);

            }
        }

        private static async Task UpdateBedrooms()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44372/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PutAsJsonAsync("api/House/4", 3);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Property has been updated.");
            }
            else
            {
                Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);

            }
        }

    }
}
