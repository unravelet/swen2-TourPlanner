using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;
using Npgsql;

namespace TourPlanner.DAL.Repositories {
    public class TourRepository : IRepository<Tour> {
        public bool Create(Tour data) {
            throw new NotImplementedException();
        }

        public bool Delete(string name) {
            throw new NotImplementedException();
        }

        public Tour Read(string name) {
            throw new NotImplementedException();
        }

        public List<Tour> ReadAll() {
            throw new NotImplementedException();
        }

        public bool Update(Tour data) {
            throw new NotImplementedException();
        }
    }
}
