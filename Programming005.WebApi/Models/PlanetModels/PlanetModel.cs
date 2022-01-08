namespace Programming005.WebApi.Models.PlanetModels
{
    public class PlanetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasWater { get; set; }
        public string PlenatarySystem { get; set; }
        public bool Livable { get; set; }
    }
}
