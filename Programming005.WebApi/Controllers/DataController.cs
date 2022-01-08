using Microsoft.AspNetCore.Mvc;
using Programming005.WebApi.Models.DataModels;
using System;
using System.Collections.Generic;

namespace Programming005.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DataController : ControllerBase
    {
        private readonly Dictionary<string, string> _languagePack = new Dictionary<string, string>
        {
            { "en", "Hello" },
            { "tr", "Selam" },
            { "az", "Salam" },
            { "ru", "Привет" }
        };
            
        [HttpGet]
        public IActionResult Dummy()
        {
            return Ok(new DummyResponse
            {
                Message = "Hellooo, it is me dummy"
            });
        }

        [HttpGet]
        public IActionResult Hello(string lang)
        {
            if(_languagePack.TryGetValue(lang, out string helloText))
            {
                return Ok(new HelloResponse
                {
                    Text = helloText
                });
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Sum(decimal a, decimal b)
        {
            return Ok(new SumResponse
            {
                Result = a + b
            });
        }


        [HttpPost]
        public IActionResult Reverse([FromQuery]ReverseRequest request)
        {
            string reverted = ReverseInternal(request.Text);

            return Ok(new ReverseResponse
            {
                Text = reverted
            });
        }

        private string ReverseInternal(string text)
        {
            var charArray = text.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}
