using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using System;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using System.Threading;
using Allure.Net.Commons;
using System.IO;

namespace AdactinHotel_NUnit
{
    public class BasePage
    {
        public static IWebDriver driver;
        public static ExtentReports extentReports;
        public static ExtentTest exParent;
        public static ExtentTest exChild;
        public static string path;
        public static void SeleniumInitialization(string browser)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public static void ExtentReport(string testcase)
        {
            extentReports = new ExtentReports();
            path = @"C:\Users\Syed Taimoor Ali\source\repos\AdactinHotel_NUnit\AdactinHotel_NUnit\bin\ExtentReport" + '_' + testcase;
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = Theme.Standard;
            extentReports.AttachReporter(htmlReporter);
        }
        public static void TakeScreenshotExtent(AventStack.ExtentReports.Status status, string stepDetail)
        {
            string path = @"C:\Users\Syed Taimoor Ali\source\repos\AdactinHotel_NUnit\AdactinHotel_NUnit\ExtentReportScreenshots\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            exChild.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public static void TakeScreenshotAllure(string stepDetail)
        {
            string path = @"C:\Users\Syed Taimoor Ali\source\repos\AdactinHotel_NUnit\AdactinHotel_NUnit\ExtentReportScreenshots\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            AllureLifecycle.Instance.AddAttachment(stepDetail, "image/png", path);
        }
        public static void SeleniumClose()
        {
            driver.Close();
        }
        public void Write(By by, string data)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshotExtent(AventStack.ExtentReports.Status.Pass, "Write");
                TakeScreenshotAllure("Write");
            }
            catch (Exception ex)
            {
                TakeScreenshotExtent(AventStack.ExtentReports.Status.Fail, "Write Failed " + ex);
                TakeScreenshotAllure("Write Failed");
            }
        }
        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                Thread.Sleep(2000);
                TakeScreenshotExtent(AventStack.ExtentReports.Status.Pass, "Click");
                TakeScreenshotAllure("Click");
            }
            catch (Exception ex)
            {
                TakeScreenshotExtent(AventStack.ExtentReports.Status.Fail, "Click Failed " + ex);
                TakeScreenshotAllure("Click Failed");
            }
        }
        public void Clear(By by)
        {
            try
            {
                driver.FindElement(by).Clear();
                TakeScreenshotExtent(AventStack.ExtentReports.Status.Pass, "Clear");
                TakeScreenshotAllure("Clear");
            }
            catch (Exception ex)
            {
                TakeScreenshotExtent(AventStack.ExtentReports.Status.Fail, "Clear Failed " + ex);
                TakeScreenshotAllure("Clear Failed");
            }
        }
        public void OpenUrl(string url)
        {
            try
            {
                driver.Url = url;
                TakeScreenshotExtent(AventStack.ExtentReports.Status.Pass, "Open Url");
                TakeScreenshotAllure("Open Url");
            }
            catch (Exception ex)
            {
                TakeScreenshotExtent(AventStack.ExtentReports.Status.Fail, "Open Url Failed " + ex);
                TakeScreenshotAllure("Open Url Failed");
            }
        }
        public void GotoUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}