using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;
using Npgsql;

namespace TourPlanner.DAL.Repositories {
    public class TourLogRepository : IRepository<TourLog> {
        public bool Create(TourLog data) {
            throw new NotImplementedException();
        }

        public bool Delete(string name) {
            throw new NotImplementedException();
        }

        public TourLog Read(string name) {
            throw new NotImplementedException();
        }

        public List<TourLog> ReadAll() {
            throw new NotImplementedException();
        }

        public bool Update(TourLog data) {
            throw new NotImplementedException();
        }
    }
}
