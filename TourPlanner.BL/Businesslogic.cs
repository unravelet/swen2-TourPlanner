﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using TourPlanner.DAL.DB;
using TourPlanner.DAL.Repositories;
using TourPlanner.Models;

namespace TourPlanner.BL {
    public class Businesslogic {
        public ObservableCollection<string> Tours { get; set; }
        

        public Businesslogic() {
            Tours = new ObservableCollection<string>();


            JObject config = JObject.Parse(ReadJsonFile());

            _db = new Database((string)config["connstr"]);
            _tourRepo = new TourRepository(_db);
            _tourLogRepo = new TourLogRepository(_db);


        }

        private Database _db;
        private TourRepository _tourRepo;
        private TourLogRepository _tourLogRepo;



        private string ReadJsonFile() {
            string path = "appsettings.json";

            string readText = File.ReadAllText(path);

            return readText;

        }

        public Tour CreateTour(string name, string description, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, string transporttype, string startCity, string endCity) {

            Tour.transportType transp = (Tour.transportType)Enum.Parse(typeof(Tour.transportType), transporttype, true);

            Tour tour = new Tour(Guid.NewGuid().ToString(), name, description, startAddress, startAddressNum, startZip, startCountry, endAddress, endAddressNum,
                endZip, endCountry, transp, startCity, endCity);



            _tourRepo.Create(tour);

            return tour;

        }

        public bool CanCreateTour(string name, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, string startCity, string endCity) {

            return !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(startAddress) && !String.IsNullOrEmpty(startAddressNum) &&
                !String.IsNullOrEmpty(startZip) && !String.IsNullOrEmpty(startCountry) && !String.IsNullOrEmpty(endAddress) &&
                !String.IsNullOrEmpty(endAddressNum) && !String.IsNullOrEmpty(endZip) && !String.IsNullOrEmpty(endCountry) && !String.IsNullOrEmpty(startCity)
                && !String.IsNullOrEmpty(endCity);

        }



        public ObservableCollection<Tour> GetTourCollection() {
            var tourList = new List<Tour>();
            tourList = _tourRepo.ReadAll();


            TourCollection = new ObservableCollection<Tour>();

            for (int i = 0; i < tourList.Count; i++) {
                TourCollection.Add(tourList[i]);
            }

            return TourCollection;
        }

        public ObservableCollection<Tour> TourCollection { get; set; }


        public void DeleteTour(string id) {
            _tourRepo.Delete(id);
        }

        public void DeleteTourLog(string id) {
            _tourLogRepo.Delete(id);
        }

        public void UpdateTour(Tour tour) {
            _tourRepo.Update(tour);
        }

        public void UpdateTourLog(TourLog tourlog) {
            _tourLogRepo.Update(tourlog);
        }

        public Tour FindTour(string id) {
            return _tourRepo.Read(id);
        }


        public void CreateTourLog(string tourId, string date, string duration, string distance, string rating, string difficulty, string comment) {

            TourLog tourLog = new TourLog(Guid.NewGuid().ToString(), tourId, date, duration, distance, rating, difficulty, comment);
            _tourLogRepo.Create(tourLog);
        }

        public ObservableCollection<TourLog> GetTourLogs(string tourId) {

            return _tourLogRepo.GetTourLogs(tourId);
        }


    }
}
