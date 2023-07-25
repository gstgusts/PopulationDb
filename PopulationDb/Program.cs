namespace PopulationDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var populationService = new PopulationService();

            var regions = populationService.GetRegions();

            //foreach (var region in regions) {
            //    Console.WriteLine(region.Name);
            //}

            var region1 = populationService.GetRegionById(1);

            //Console.WriteLine(region1?.Name);

            var regionsByName = populationService.GetRegionsByName("me");

            foreach (var region in regionsByName)
            {
                Console.WriteLine(region.Name);
            }
        }
    }
}