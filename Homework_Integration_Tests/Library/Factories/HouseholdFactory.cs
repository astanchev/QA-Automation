namespace Library.Factories
{
    using Models;

    public static class HouseholdFactory
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