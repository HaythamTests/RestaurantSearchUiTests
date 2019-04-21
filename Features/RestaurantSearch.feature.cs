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
namespace RestaurantSearch.Tests.Features
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
        [NUnit.Framework.TestCaseAttribute("AR51 1AA", "Domino\'s", null)]
        [NUnit.Framework.TestCaseAttribute("EC2Y 8BN", "Papa John", null)]
        [NUnit.Framework.TestCaseAttribute("WC2H 7LE", "tinseltown great portland Street", null)]
        [NUnit.Framework.TestCaseAttribute("WC2H 7LE", "subway goodge", null)]
        public virtual void PositiveScenarioSearchForRestaurantSInAnArea(string postcode, string restaurant, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Positive Scenario) Search for restaurant(s) in an area", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
   testRunner.Given(string.Format("I want food in area {0}", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
   testRunner.When(string.Format("I search for restaurant {0}", restaurant), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
  testRunner.Then("I should see the correct subheader details in the search results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
  testRunner.And("the restaurant name is included in the first and last search result titles", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
  testRunner.And("the search result count is reflected in the subheader", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("(Negative Scenario) Invalid Postcode in Search page")]
        public virtual void NegativeScenarioInvalidPostcodeInSearchPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Negative Scenario) Invalid Postcode in Search page", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
   testRunner.Given("I want food in area invalidSearchValue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "PostCodeErrorMessage"});
            table1.AddRow(new string[] {
                        "Please enter a full, valid postcode"});
#line 21
  testRunner.Then("I should see the error message", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("(Negative Scenario) Invalid restaurant search in an area")]
        public virtual void NegativeScenarioInvalidRestaurantSearchInAnArea()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Negative Scenario) Invalid restaurant search in an area", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
   testRunner.Given("I want food in area AR51 1AA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
   testRunner.When("I search for restaurant invalidSearchValue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
  testRunner.Then("I should see the correct subheader details in the search results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Subheader",
                        "EmptySearchResultMessage",
                        "SearchButtonText",
                        "SearchButtonLink",
                        "TipUsOffText",
                        "TipUsOffLink"});
            table2.AddRow(new string[] {
                        "No open restaurants",
                        "We\'re coming up empty. Try casting your net a little wider.",
                        "Show All Restaurants",
                        "https://www.just-eat.co.uk/area/",
                        "Tip us off",
                        "https://www.just-eat.co.uk/suggest-a-restaurant"});
#line 29
  testRunner.And("I should see the following texts and links on the page", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

