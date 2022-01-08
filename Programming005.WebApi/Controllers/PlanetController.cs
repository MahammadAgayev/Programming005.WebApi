using Microsoft.AspNetCore.Mvc;
using Programming005.WebApi.Models.PlanetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming005.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PlanetController : ControllerBase
    {
        private readonly List<PlanetModel> _planets = new List<PlanetModel>
        {
            new PlanetModel
            {
                Id = 1,
                HasWater = true,
                PlenatarySystem = "SolarSystem",
                Livable = true,
                Name = "Earth"
            },
            new PlanetModel
            {
                Id = 2,
                PlenatarySystem = "SolarSystem",
                HasWater = false,
                Livable = false,
                Name = "Mars"
            }
        };

        [HttpGet()]
        public IActionResult Planets()
        {
            var models = _planets.Select(x => new PlanetNameModel
            {
                Id = x.Id,
                Name = x.Name
            });

            return Ok(models);
        }

        [HttpGet("{id}/{name}")]
        public IActionResult Planet(int id, string name)
        {
            var planet = _planets.FirstOrDefault(x => x.Id == id);

            return Ok(planet);
        }
    }
}
