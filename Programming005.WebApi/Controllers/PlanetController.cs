using Microsoft.AspNetCore.Mvc;
using Programming005.WebApi.Models.PlanetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Programming005.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PlanetController : ControllerBase
    {
        private static readonly List<PlanetModel> _planets = new List<PlanetModel>
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

        [HttpGet("{id}")]
        public IActionResult Planet(int id)
        {
            var planet = _planets.FirstOrDefault(x => x.Id == id);

            return Ok(planet);
        }

        [HttpPost]
        public IActionResult Add([FromBody]CreatePlanetRequest request)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest("requesy is not valid");
            }

            var planet = new PlanetModel
            {
                HasWater = request.HasWater,
                PlenatarySystem = request.PlenatarySystem,
                Livable = request.Livable,
                Name = request.Name
            };

            var lastElem = _planets.LastOrDefault();
            int lastId = 0;

            if(lastElem != null)
            {
                lastId = lastElem.Id;
            }
            planet.Id = lastId + 1;

            _planets.Add(planet);

            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPost]
        public IActionResult Update([FromBody]UpdatePlanetRequest request)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest("request is not valid");
            }

            var planet = _planets.FirstOrDefault(x => x.Id == request.PlanetId);

            if(planet == null)
            {
                return BadRequest("Planet not found");
            }

            planet.Name = request.Name;
            planet.HasWater = request.HasWater;
            planet.Livable = request.Livable;
            planet.PlenatarySystem = request.PlenatarySystem;

            return Ok();
        }
    }
}
