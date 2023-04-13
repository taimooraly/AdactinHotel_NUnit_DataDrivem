using AventStack.ExtentReports;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace AdactinHotel_NUnit
{
    [AllureNUnit]
    [TestFixture]
    public class TestExecution : BasePage
    {
        private TestContext testContext;
        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }
        
        [SetUp]
        public void TestInit()
        {
            SeleniumInitialization("Chrome");
            ExtentReport("TestReport");
            if (extentReports == null)
            {
                ExtentReport(TestContext.CurrentContext.Test.Name);
            }
            exParent = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
        }        
        [TearDown]
        public void TestClose()
        { 
            extentReports.Flush();
            SeleniumClose();
        }
        [Test]
        [Category ("Login")]        
        public void Login()
        {            
            LoginPage loginPage = new LoginPage();
            List<string> testCases = LoginPage.GetTestCasesLogin();
            foreach (string testCase in testCases)
            {
                exChild = BasePage.exParent.CreateNode(testCase);
            }
            loginPage.Login(); 
        }
        [Test]
        [Category("Search")]
        public void Search()
        {            
            LoginPage loginPage = new LoginPage();
            List<string> testCases = LoginPage.GetTestCasesValidLogin();
            foreach (string testCase in testCases)
            {
                exChild = BasePage.exParent.CreateNode(testCase);
            }
            loginPage.Valid_Login();
            SearchPage searchPage = new SearchPage();
            List<string> testCases1 = SearchPage.GetTestCasesSearch();
            foreach (string testCase in testCases1)
            {
                exChild = BasePage.exParent.CreateNode(testCase);
            }
            searchPage.Search();
        }
    }
}