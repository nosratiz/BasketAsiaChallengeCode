﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Mc2.CrudTest.Behavior.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CreateReadEditDeleteCustomerFeature : object, Xunit.IClassFixture<CreateReadEditDeleteCustomerFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CustomerManager.feature"
#line hidden
        
        public CreateReadEditDeleteCustomerFeature(CreateReadEditDeleteCustomerFeature.FixtureData fixtureData, Mc2_CrudTest_Behavior_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Create Read Edit Delete Customer", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
    #line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Code",
                        "Description"});
            table2.AddRow(new string[] {
                        "101",
                        "Invalid Mobile Number"});
            table2.AddRow(new string[] {
                        "102",
                        "Invalid Email address"});
            table2.AddRow(new string[] {
                        "103",
                        "Invalid Bank Account Number"});
            table2.AddRow(new string[] {
                        "201",
                        "Duplicate customer by First-name, Last-name, Date-of-Birth"});
            table2.AddRow(new string[] {
                        "202",
                        "Duplicate customer by Email address"});
#line 4
        testRunner.Given("system error codes are following", ((string)(null)), table2, "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Read Edit Delete Customer")]
        [Xunit.TraitAttribute("FeatureTitle", "Create Read Edit Delete Customer")]
        [Xunit.TraitAttribute("Description", "Create Read Edit Delete Customer")]
        [Xunit.TraitAttribute("Category", "CreateReadEditDeleteCustomer")]
        public void CreateReadEditDeleteCustomer()
        {
            string[] tagsOfScenario = new string[] {
                    "CreateReadEditDeleteCustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Read Edit Delete Customer", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 13
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
    this.FeatureBackground();
#line hidden
#line 14
        testRunner.Given("platform has \"0\" customers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "PhoneNumber",
                            "DateOfBirth",
                            "BankAccountNumber"});
                table3.AddRow(new string[] {
                            "John",
                            "Doe",
                            "john@doe.com",
                            "+989121234567",
                            "01-JAN-2000",
                            "IR000000000000001"});
#line 15
      testRunner.When("user creates a customer with following data by sending \'Create Customer Command\'", ((string)(null)), table3, "When ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "PhoneNumber",
                            "DateOfBirth",
                            "BankAccountNumber"});
                table4.AddRow(new string[] {
                            "John",
                            "Doe",
                            "john@doe.com",
                            "+989121234567",
                            "01-JAN-2000",
                            "IR000000000000001"});
#line 18
        testRunner.Then("user can query to get all customers and must have \"1\" record with following data", ((string)(null)), table4, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "PhoneNumber",
                            "DateOfBirth",
                            "BankAccountNumber"});
                table5.AddRow(new string[] {
                            "John",
                            "Doe",
                            "john@doe.com",
                            "+989121234567",
                            "01-JAN-2000",
                            "IR000000000000001"});
#line 21
        testRunner.When("user creates a customer with following data by sending \' Create Customer Command\'" +
                        "", ((string)(null)), table5, "When ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Code"});
                table6.AddRow(new string[] {
                            "201"});
                table6.AddRow(new string[] {
                            "202"});
#line 24
        testRunner.Then("user must receive error codes", ((string)(null)), table6, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "PhoneNumber",
                            "DateOfBirth",
                            "BankAccountNumber"});
                table7.AddRow(new string[] {
                            "Jane",
                            "William",
                            "jane@william.com",
                            "+989107602786",
                            "01-FEB-2010",
                            "IR000000000000002"});
#line 28
        testRunner.When("user edit customer with new data", ((string)(null)), table7, "When ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "PhoneNumber",
                            "DateOfBirth",
                            "BankAccountNumber"});
                table8.AddRow(new string[] {
                            "John",
                            "Doe",
                            "john@doe.com",
                            "+989121234567",
                            "01-JAN-2000",
                            "IR000000000000001"});
#line 31
        testRunner.Then("user can lookup all customers and filter by below properties and get \"0\" records", ((string)(null)), table8, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "Email",
                            "PhoneNumber",
                            "DateOfBirth",
                            "BankAccountNumber"});
                table9.AddRow(new string[] {
                            "Jane",
                            "William",
                            "jane@william.com",
                            "+989107602786",
                            "01-FEB-2010",
                            "IR000000000000002"});
#line 34
        testRunner.And("user can lookup all customers and filter by below properties and get \"1\" records", ((string)(null)), table9, "And ");
#line hidden
#line 37
        testRunner.When("user delete customer by email of \"jane@william.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
        testRunner.Then("user can query to get all customers and must have \"0\" records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CreateReadEditDeleteCustomerFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CreateReadEditDeleteCustomerFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
