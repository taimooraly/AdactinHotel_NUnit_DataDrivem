using AdactinHotel_NUnit;
using CsvHelper;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Security.Policy;
using System.Threading;

namespace AdactinHotel_NUnit
{
    public class LoginPage : BasePage
    {
        
        public void Login()
        {
            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.csv")))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    OpenUrl((string)record.url);
                    Write(By.Id("username"), (string)record.username);
                    Write(By.Id("password"), (string)record.password);
                    Click(By.Id("login"));
                }
            }            
        }
        public static List<string> GetTestCasesLogin()
        {
            var testCases = new List<string>();

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.csv")))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    string testCaseName = (string)record.testcase;
                    testCases.Add(testCaseName);
                }
            }
            return testCases;
        }
        public void Valid_Login()
        {
            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "validlogin.csv")))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    GotoUrl((string)record.url);
                    Write(By.Id("username"), (string)record.username);
                    Write(By.Id("password"), (string)record.password);
                    Click(By.Id("login"));
                }
            }

        }
        public static List<string> GetTestCasesValidLogin()
        {
            var testCases = new List<string>();

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "validlogin.csv")))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    string testCaseName = (string)record.testcase;
                    testCases.Add(testCaseName);
                }
            }
            return testCases;
        }

    }
}