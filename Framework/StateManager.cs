using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Framework
{
    public static class StateManager
    {   
        //Getting results from the ScenarioContext for the Assertion purpose
        public static T Get<T>(string key)
        {
            return (T) ScenarioContext.Current[key];
        }

        //Saving results using the ScenarioContext feature
        public static void Set(string key, object value)
        {
            ScenarioContext.Current[key] = value;
        }
    }
}
