﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RestaurantSearch.UITests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Use the website to find restaurants")]
    public partial class UseTheWebsiteToFindRestaurantsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RestaurantSearch.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Use the website to find restaurants", "\tSo that I can order food\r\n\tAs a hungry customer\r\n\tI want to be able to find rest" +
                    "aurants in my area", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("(Positive Scenario) Search for restaurant(s) in an area")]
        [NUnit.Framework.TestCaseAttribute("Domino\'s", null)]
        [NUnit.Framework.TestCaseAttribute("Papa Johns", null)]
        [NUnit.Framework.TestCaseAttribute("Kfc", null)]
        public virtual void PositiveScenarioSearchForRestaurantSInAnArea(string restaurant, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Positive Scenario) Search for restaurant(s) in an area", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
   testRunner.Given("I want food in area AR51 1AA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
   testRunner.When(string.Format("I search for restaurant {0}", restaurant), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
  testRunner.Then("I should see the correct details in the subheader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
  testRunner.And("the restaurant name is included in the first and last search results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("(Negative Scenario) Unable to search for restaurant(s) in an area")]
        [NUnit.Framework.TestCaseAttribute("Nando\'s", null)]
        [NUnit.Framework.TestCaseAttribute("Persian Palace", null)]
        public virtual void NegativeScenarioUnableToSearchForRestaurantSInAnArea(string restaurants, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Negative Scenario) Unable to search for restaurant(s) in an area", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
   testRunner.Given("I want food in area AR51 1AA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
   testRunner.When(string.Format("I search for restaurant {0}", restaurants), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
   testRunner.Then(string.Format("I shouldn\'t see the {0} and I see the error message No open restaurants", restaurants), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unable to search in an area using invalid values")]
        [NUnit.Framework.TestCaseAttribute("£$$£$", null)]
        [NUnit.Framework.TestCaseAttribute("09098", null)]
        public virtual void UnableToSearchInAnAreaUsingInvalidValues(string invalidValues, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unable to search in an area using invalid values", exampleTags);
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
   testRunner.Given("I want food in area AR51 1AA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
   testRunner.When(string.Format("I search for restaurant {0}", invalidValues), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
   testRunner.Then(string.Format("I shouldn\'t see the {0} and I see the error message No open restaurants", invalidValues), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("(Positive Scenario) Search for restaurant(s) through \'Change Location\'")]
        [NUnit.Framework.TestCaseAttribute("", null)]
        [NUnit.Framework.TestCaseAttribute("Awafi Foods", null)]
        [NUnit.Framework.TestCaseAttribute("Adams Lounge", null)]
        [NUnit.Framework.TestCaseAttribute("Hot Bread", null)]
        public virtual void PositiveScenarioSearchForRestaurantSThroughChangeLocation(string restaurants, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Positive Scenario) Search for restaurant(s) through \'Change Location\'", exampleTags);
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
   testRunner.Given("I want food in area AR51 1AA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
   testRunner.When(string.Format("I search for restaurant {0}", restaurants), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
   testRunner.And("I change the area to W3 7JL using the \'Change Location\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
  testRunner.And(string.Format("I search for restaurant {0}", restaurants), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
  testRunner.Then(string.Format("I should see some {0} in W3 7JL", restaurants), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("(Negative Scenario) Unable to search for restaurant(s) through \'Change Location\'")]
        [NUnit.Framework.TestCaseAttribute("Papa Johns", null)]
        [NUnit.Framework.TestCaseAttribute("Frankie & Bennys", null)]
        public virtual void NegativeScenarioUnableToSearchForRestaurantSThroughChangeLocation(string restaurants, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Negative Scenario) Unable to search for restaurant(s) through \'Change Location\'", exampleTags);
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
   testRunner.Given("I want food in area AR51 1AA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
   testRunner.When(string.Format("I search for restaurant {0}", restaurants), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
   testRunner.And("I change the area to W3 7JL using the \'Change Location\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
  testRunner.And(string.Format("I search for restaurant {0}", restaurants), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
  testRunner.Then(string.Format("I shouldn\'t see the {0} and I see the error message No open restaurants", restaurants), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unable to search through \'Change Location\' using invalid values")]
        [NUnit.Framework.TestCaseAttribute("£$$£$", null)]
        [NUnit.Framework.TestCaseAttribute("09098", null)]
        public virtual void UnableToSearchThroughChangeLocationUsingInvalidValues(string invalidValues, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unable to search through \'Change Location\' using invalid values", exampleTags);
#line 64
this.ScenarioSetup(scenarioInfo);
#line 65
   testRunner.Given("I want food in area AR51 1AA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
   testRunner.When(string.Format("I search for restaurant {0}", invalidValues), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
   testRunner.And("I change the area to W3 7JL using the \'Change Location\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
  testRunner.And(string.Format("I search for restaurant {0}", invalidValues), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
  testRunner.Then(string.Format("I shouldn\'t see the {0} and I see the error message No open restaurants", invalidValues), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

