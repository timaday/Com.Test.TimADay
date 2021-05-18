using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Authenticators;

namespace Com.Test.TimADay.APIs
{
    class BaseAPITests
    {
        public static readonly string baseUrl = "https://restful-booker.herokuapp.com";
        public static RestClient Client;
        public static IRestRequest Request;
        public static IRestResponse Response;

        private static JwtAuthenticator AuthHero()
        {
            Dictionary<string, string> User = new Dictionary<string, string>();
            User.Add("username", "Tester");
            User.Add("password", "password123");
            Request = new RestRequest("auth").AddJsonBody(User);
            Response = Client.Post(Request);
            var jObject = JObject.Parse(Response.Content);
            string token = jObject.GetValue("token").ToString();
            return new JwtAuthenticator(token);
        }

        public static void SetBaseUriAndAuth()
        {
            Client = new RestClient(baseUrl);
            Client.Authenticator = AuthHero();
        }

        public static void Ping() 
        {
            Request = new RestRequest("ping", Method.GET);
            GetResponse();
            Assert.That(Response.StatusCode, Is.EqualTo(201), "Api is not working");
        }

        public static JObject updateBookingFirstname(
            string id,
          string firstname)
        {
            Dictionary<string, dynamic> Booking = new Dictionary<string, dynamic>();
            Booking.Add("firstname", firstname);
            Request = new RestRequest("booking", Method.PUT)
                .AddQueryParameter("id", id)
                .AddJsonBody(Booking); ;
            GetResponse();
            return JObject.Parse(Response.Content);
        }

        public static JObject getBooking(string id)
        {
            Request = new RestRequest("booking/{id}", Method.DELETE).AddUrlSegment("id", id);
            GetResponse();
            return JObject.Parse(Response.Content);
        }

        public static JObject deleteBooking(string id)
        {
            Request = new RestRequest("booking/{id}", Method.DELETE).AddUrlSegment("id", id);
            GetResponse();
            return JObject.Parse(Response.Content);
        }

        public static JObject createBooking(
            string firstname, 
            string lastname, 
            string totalprice = "", 
            string depositpaid = "",
            string checkin = "",
            string checkout = "",
            string additionalneeds = "") 
        {
            Dictionary<string, dynamic> Booking = new Dictionary<string, dynamic>();
            Booking.Add("firstname", firstname);
            Booking.Add("lastname", lastname);
            Booking.Add("totalprice", totalprice);
            Booking.Add("depositpaid", depositpaid);
            Dictionary<string, string> Bookingdates = new Dictionary<string, string>();
            Bookingdates.Add("checkin", checkin);
            Bookingdates.Add("checkout", checkout);
            Booking.Add("bookingdates", Bookingdates);
            Booking.Add("additionalneeds", additionalneeds);
            Request = new RestRequest("booking", Method.POST).AddJsonBody(Booking);
            GetResponse();
            return JObject.Parse(Response.Content);
        }

        private static void GetResponse()
        {
            Response = Client.Execute(Request);
        }

        public static JObject GetResponseBody() 
        {
            return JObject.Parse(Response.Content);
        }
    }
}
