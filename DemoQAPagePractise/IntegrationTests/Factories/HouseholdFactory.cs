namespace IntegrationTests.Factories
{
    using Models;

    public class HouseholdFactory
    {
        public static Household CreateHousehold()
        {
            return new Household()
            {
                Name = "Johnsons"
            };
        }
    }
}