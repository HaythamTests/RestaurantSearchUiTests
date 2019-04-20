using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Helpers
{
    public static class StateManager
    {
        //Saving and Getting results using the ScenarioContext feature
        public static T Get<T>(string key)
        {
            return (T) ScenarioContext.Current[key];
        }

        public static void Set<T>(string key, T value)
        {
            ScenarioContext.Current[key] = value;
        }
    }
}
