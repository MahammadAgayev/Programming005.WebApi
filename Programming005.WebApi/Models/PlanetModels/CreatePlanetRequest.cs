using System.ComponentModel.DataAnnotations;

namespace Programming005.WebApi.Models.PlanetModels
{
    public class CreatePlanetRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool HasWater { get; set; }
        [Required]
        public string PlenatarySystem { get; set; }
        [Required]
        public bool Livable { get; set; }
    }
}
