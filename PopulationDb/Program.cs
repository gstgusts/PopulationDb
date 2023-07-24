namespace PopulationDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var populationService = new PopulationService();

            populationService.GetRegions();
        }
    }
}