using AdactinHotel_NUnit;
using CsvHelper;
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
    public class SearchPage : BasePage
    {
        public void Search()
        {
            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "search.csv")))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    GotoUrl((string)record.url);
                    Write(By.Id("username"), (string)record.username);
                    Write(By.Id("password"), (string)record.password);
                    Click(By.Id("login"));
                    Write(By.Name("location"), (string)record.location);
                    Write(By.Id("hotels"), (string)record.hotels);
                    Write(By.Id("room_type"), (string)record.room_type);
                    Write(By.Id("room_nos"), (string)record.room_nos);
                    Write(By.Id("datepick_in"), (string)record.datepick_in);
                    Write(By.Id("datepick_out"), (string)record.datepick_out);
                    Write(By.Id("adult_room"), (string)record.adult_room);
                    Write(By.Id("child_room"), (string)record.child_room);
                    Click(By.Id("Submit"));
                }                              
            }
        }
        public static List<string> GetTestCasesSearch()
        {
            var testCases = new List<string>();

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "search.csv")))
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