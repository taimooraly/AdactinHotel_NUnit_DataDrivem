using AdactinHotel_NUnit;
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
    public class Json
    {
        public static object[] Login
        {
            get
            {
                //string path = @"C:\Users\Syed Taimoor Ali\source\repos\AdactinHotel_NUnit\AdactinHotel_NUnit\bin\Debug\net6.0\TestData.json";
                string login_path = @"C:\Users\Syed Taimoor Ali\source\repos\AdactinHotel_NUnit\AdactinHotel_NUnit\Login.json";
                using (StreamReader r = new StreamReader(login_path))
                {
                    string json = r.ReadToEnd();
                    dynamic data = JsonConvert.DeserializeObject(json);
                    List<object[]> loginDataList = new List<object[]>();
                    foreach (var loginObject in data)
                    {
                        string username = loginObject.username;
                        string password = loginObject.password;
                        loginDataList.Add(new object[] { username, password });
                    }
                    return loginDataList.ToArray();
                }
            }
        }
        public static object[] Search
        {
            get
            {
                string search_path = @"C:\Users\Syed Taimoor Ali\source\repos\AdactinHotel_NUnit\AdactinHotel_NUnit\Search.json";
                //string path = @"C:\Users\Syed Taimoor Ali\source\repos\HotelAdactinWithAllureInNUnit\HotelAdactinWithAllureInNUnit\bin\Debug\net6.0\login.json";
                using (StreamReader r = new StreamReader(search_path))
                {
                    string json = r.ReadToEnd();
                    dynamic data = JsonConvert.DeserializeObject(json);
                    List<object[]> searchDataList = new List<object[]>();
                    foreach (var searchObject in data)
                    {
                        string username = searchObject.username;
                        string password = searchObject.password;
                        string location = searchObject.location;
                        string hotels = searchObject.hotels;    
                        string room_type = searchObject.room_type;
                        string room_nos = searchObject.room_nos;
                        string datepick_in = searchObject.datepick_in;
                        string datepick_out = searchObject.datepick_out;
                        string adult_room = searchObject.adult_room;
                        string child_room = searchObject.child_room;
                        searchDataList.Add(new object[] {username, password, location, hotels, room_type, room_nos, datepick_in, datepick_out, adult_room, child_room });
                    }
                    return searchDataList.ToArray();
                }
            }
        }
    }
}