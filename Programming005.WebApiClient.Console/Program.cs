using Newtonsoft.Json;
using Programming005.WebApiClient.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Programming005.WebApiClient.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Type a number for operation\n1 for list\n2 for details\n3 for add\n4 for update\n");
                int opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        ListALL();
                        break;
                    case 2:
                        Details();
                        break;
                    case 3:
                        Create();
                        break;
                    default:
                        throw new NotSupportedException();
                }


                Console.WriteLine("=======================================================");
            }
        }

        static void ListALL()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44332/Planet/Planets").Result;

            response.EnsureSuccessStatusCode();

            string content = response.Content.ReadAsStringAsync().Result;

            IEnumerable<PlanetModel> planets = JsonConvert.DeserializeObject<IEnumerable<PlanetModel>>(content);

            foreach (var p in planets)
            {
                Console.WriteLine($"{p.Id}: {p.Name}");
            }
        }

        static void Details()
        {
            Console.Write("Please enter planet id: ");
            int planetId = int.Parse(Console.ReadLine());

            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:44332/Planet/Planet/" + planetId).Result;

            response.EnsureSuccessStatusCode();

            string rawContent = response.Content.ReadAsStringAsync().Result;

            var model = JsonConvert.DeserializeObject<PlanetDetailModel>(rawContent);

            Console.WriteLine("Id: " + model.Id);
            Console.WriteLine("Name: " + model.Name);
            Console.WriteLine("PlanetarySystem: " + model.PlenatarySystem);
            Console.WriteLine("Livable: " + model.Livable);
            Console.WriteLine("HasWater: " + model.HasWater);
        }

        static void Create()
        {
            CreatePlanetModel model = new CreatePlanetModel();

            Console.Write("Name: ");
            model.Name = Console.ReadLine();

            Console.Write("PlanetarySystem: ");
            model.PlenatarySystem = Console.ReadLine();

            Console.Write("HasWater: ");
            model.HasWater = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Livable: ");
            model.Livable = Convert.ToBoolean(Console.ReadLine());

            string bodyJson = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var res = client.PostAsync("https://localhost:44332/Planet/Add", content).Result;
            res.EnsureSuccessStatusCode();

            Console.WriteLine("Successfully created");
        }
    }
}
