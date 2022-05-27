using Npgsql;
using System.Collections.ObjectModel;
using TourPlanner.DAL.DB;
using TourPlanner.Models;

namespace TourPlanner.DAL.Repositories {
    public class TourLogRepository : IRepository<TourLog> {

        public Database _db;
        public TourLogRepository(Database db) {
            _db = db;
        }

        public bool Create(TourLog data) {
            string sql = "INSERT INTO tourlogs (id, tourid, date, duration, distance, rating, difficulty, comment) " +
                "Values (@id, @tid, @da,@du,@di, @ra, @dif, @c)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", data.Id);
            cmd.Parameters.AddWithValue("tid", data.TourId);
            cmd.Parameters.AddWithValue("da", data.Date);
            cmd.Parameters.AddWithValue("du", data.Duration);
            cmd.Parameters.AddWithValue("di", data.Distance);
            cmd.Parameters.AddWithValue("ra", data.Rating);
            cmd.Parameters.AddWithValue("dif", data.Difficulty);
            cmd.Parameters.AddWithValue("c", data.Comment);


            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool Delete(string id) {
            string sql = "DELETE FROM tourlogs WHERE id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", id);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public TourLog Read(string name) {
            throw new NotImplementedException();
        }

        public ObservableCollection<TourLog> ReadAll() {
            var list = new ObservableCollection<TourLog>();
            string sql = "SELECT * FROM tourlogs";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {
                while (reader.Read()) {
                    list.Add(new TourLog(reader.GetValue(0).ToString(),     //id
                        reader.GetValue(1).ToString(),                      //tourid
                        reader.GetValue(2).ToString(),                      //date
                        reader.GetValue(3).ToString(),                      //duration
                        reader.GetValue(4).ToString(),                      //distance
                        reader.GetValue(5).ToString(),                      //rating
                        reader.GetValue(6).ToString(),                      //difficulty
                        reader.GetValue(7).ToString()                       //comment
                        ));
                }
                return list;
            }
        }

        public bool Update(TourLog data) {
            string sql = "UPDATE tourlogs SET date = @da, duration = @du, distance = @di" +
                ", rating = @ra, difficulty = @dif, comment = @c WHERE id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("da", data.Date);
            cmd.Parameters.AddWithValue("du", data.Duration);
            cmd.Parameters.AddWithValue("di", data.Distance);
            cmd.Parameters.AddWithValue("ra", data.Rating);
            cmd.Parameters.AddWithValue("dif", data.Difficulty);
            cmd.Parameters.AddWithValue("c", data.Comment);
            cmd.Parameters.AddWithValue("id", data.Id);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public ObservableCollection<TourLog> GetTourLogs(string tourId) {

            var logCollection = new ObservableCollection<TourLog>();

            string sql = "SELECT * FROM tourlogs WHERE tourid=@tid";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("tid", tourId);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                while (reader.Read()) {

                    logCollection.Add(new TourLog(reader.GetValue(0).ToString(),     //id
                        reader.GetValue(1).ToString(),                              //tourid
                        reader.GetValue(2).ToString(),                              //date
                        reader.GetValue(3).ToString(),                              //duration
                        reader.GetValue(4).ToString(),                              //distance
                        reader.GetValue(5).ToString(),                              //rating
                        reader.GetValue(6).ToString(),                              //difficulty
                        reader.GetValue(7).ToString()                               //comment
                        ));
                }
                return logCollection;

            }
        }
    }
}
