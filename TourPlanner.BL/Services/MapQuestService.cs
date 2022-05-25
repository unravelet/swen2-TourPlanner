﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.BL.Services {
    public class MapQuestService {


        private HttpClient _client;
        private string _key;
        private string _directionsApi = "http://www.mapquestapi.com/directions/v2/route";
        private string _staticMapApi = "https://www.mapquestapi.com/staticmap/v5/map";

        public MapQuestService() {
            _key = "StvQtLCwcKCAcP4B7AjgypEe7AIaOj0t";
            _client = new();
        }

        public async Task<Tour> getTourData(Tour userInput) {
            string tmpUrl = _directionsApi + $"?key={_key}&from={userInput.StartAddressNum} {userInput.StartAddress}" +
                                                                $",{userInput.StartCity}" +
                                                                $",{userInput.StartCountry}" +
                                                                $",{userInput.StartZip}" +
                                                          $"&to={userInput.EndAddressNum} {userInput.EndAddress}" +
                                                                $",{userInput.EndCity}" +
                                                                $",{userInput.EndCountry}" +
                                                                $",{userInput.EndZip}" +
                                                          $"&routType={userInput.TransportType}";

            using (HttpResponseMessage response = await _client.GetAsync(tmpUrl)) {
                using (HttpContent content = response.Content) {
                    string mycontent = await content.ReadAsStringAsync();
                    Console.WriteLine(mycontent);

                    JObject o = JObject.Parse(mycontent);

                    Console.WriteLine(o["route"]);
                    Console.WriteLine("---------------------------------------------------------------------------------");
                    //Startpoint
                    userInput.StartLat = (string)o["route"]["locations"][0]["latLng"]["lat"];
                    userInput.StartLng = (string)o["route"]["locations"][0]["latLng"]["lng"];
                    //Endpoint
                    userInput.EndLat = (string)o["route"]["locations"][1]["latLng"]["lat"];
                    userInput.EndLng = (string)o["route"]["locations"][1]["latLng"]["lng"];

                    //
                    return userInput;
                }
            }
        }

        public async void getStaticMap(Tour tour) {
            try {
                string tmpUrl = _staticMapApi + $"?key={_key}&start={tour.StartLat},{tour.StartLng}&end={tour.EndLat},{tour.EndLng}&size=500,500@2x";

                using (HttpResponseMessage response = await _client.GetAsync(tmpUrl)) {
                    byte[] image = await response.Content.ReadAsByteArrayAsync();
                    saveTourImage(image, tour.Id);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void saveTourImage(byte[] image, string name) {
            using (var ms = new MemoryStream(image)) {
                using (var fs = new FileStream("./img/new.jpg", FileMode.Create)) {
                    ms.WriteTo(fs);
                }
            }
        }



    }
}