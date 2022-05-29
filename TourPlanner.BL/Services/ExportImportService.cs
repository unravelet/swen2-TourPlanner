using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.BL.Services {
    public class ExportImportService {

        public ExportImportService() {
            

        }

        public void ExportTour(Tour tour) {
            //create folder for exports
            string path = Environment.CurrentDirectory + "/jsontours";
            Directory.CreateDirectory(path);

            string fileName = $"{tour.Name}_{tour.Id}.json";
            string jsonString = JsonConvert.SerializeObject(tour);

            File.WriteAllText($"{path}/{fileName}", jsonString);


        }

        public Tour ImportTour(string jsonString) {
            if(jsonString == null) {
                Tour emptyTour = new Tour("", "Import failed", "", "", "", "", "", "", "", "", "", Tour.transportType.car, "", "");
                return emptyTour;
            }
            else {
                return JsonConvert.DeserializeObject<Tour>(jsonString);
            }
            
        }


    }
}
