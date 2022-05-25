using Npgsql;
using TourPlanner.DAL.DB;
using TourPlanner.Models;

namespace TourPlanner.DAL.Repositories {
    public class TourRepository : IRepository<Tour> {

        public Database _db;

        public TourRepository(Database db) {
            _db = db;

        }

        public bool Create(Tour data) {

            string sql = "INSERT INTO tours (id, name, description, startadd, startaddnum, startzip, startcountry, endadd, endaddnum, " +
                "endzip, endcountry, transport, startcity, endcity) Values (@id,@n,@d,@sa, @san, @sz, @sc, @ea, @ean, @ez, @ec, @t, @sci, @eci)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", data.Id);
            cmd.Parameters.AddWithValue("n", data.Name);
            cmd.Parameters.AddWithValue("d", data.Description);
            cmd.Parameters.AddWithValue("sa", data.StartAddress);
            cmd.Parameters.AddWithValue("san", data.StartAddressNum);
            cmd.Parameters.AddWithValue("sz", data.StartZip);
            cmd.Parameters.AddWithValue("sc", data.StartCountry);
            cmd.Parameters.AddWithValue("ea", data.EndAddress);
            cmd.Parameters.AddWithValue("ean", data.EndAddressNum);
            cmd.Parameters.AddWithValue("ez", data.EndZip);
            cmd.Parameters.AddWithValue("ec", data.EndCountry);
            cmd.Parameters.AddWithValue("t", Convert.ToInt32(data.TransportType));
            cmd.Parameters.AddWithValue("sci", data.StartCity);
            cmd.Parameters.AddWithValue("eci", data.EndCity);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool Delete(string id) {
            string sql = "DELETE FROM tours WHERE id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", id);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }

        public Tour Read(string id) {
            string sql = "SELECT * FROM tours WHERE id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("id", id);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {

                if (reader.Read()) {
                    return new Tour(reader.GetValue(0).ToString(),      //id
                        reader.GetValue(1).ToString(),                  //name
                        reader.GetValue(2).ToString(),                  //description
                        reader.GetValue(3).ToString(),                  //startadd
                        reader.GetValue(4).ToString(),                  //startaddnum
                        reader.GetValue(5).ToString(),                  //startzip
                        reader.GetValue(6).ToString(),                  //startcountry
                        reader.GetValue(7).ToString(),                  //endadd
                        reader.GetValue(8).ToString(),                  //endaddnum
                        reader.GetValue(9).ToString(),                  //endzip
                        reader.GetValue(10).ToString(),                 //endcountry
                        (Tour.transportType)reader.GetValue(11),         //transport
                        reader.GetValue(12).ToString(),                 //startcity
                        reader.GetValue(13).ToString()                  //endcity
                        );
                }
                return null;
            }
        }

        public List<Tour> ReadAll() {
            List<Tour> list = new List<Tour>();
            string sql = "SELECT * FROM tours";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);

            using (NpgsqlDataReader reader = _db.ExecuteQuery(cmd)) {
                while (reader.Read()) {
                    list.Add(new Tour(reader.GetValue(0).ToString(),    //id
                        reader.GetValue(1).ToString(),                  //name
                        reader.GetValue(2).ToString(),                  //description
                        reader.GetValue(3).ToString(),                  //startadd
                        reader.GetValue(4).ToString(),                  //startaddnum
                        reader.GetValue(5).ToString(),                  //startzip
                        reader.GetValue(6).ToString(),                  //startcountry
                        reader.GetValue(7).ToString(),                  //endadd
                        reader.GetValue(8).ToString(),                  //endaddnum
                        reader.GetValue(9).ToString(),                  //endzip
                        reader.GetValue(10).ToString(),                 //endcountry
                        (Tour.transportType)reader.GetValue(11),         //transport
                        reader.GetValue(12).ToString(),                 //startcity
                        reader.GetValue(13).ToString()                  //endcity

                        ));
                }
                return list;
            }
        }

        public bool Update(Tour data) {
            string sql = "UPDATE tours SET name = @n, description = @d WHERE id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql);
            cmd.Parameters.AddWithValue("n", data.Name);
            cmd.Parameters.AddWithValue("d", data.Description);
            cmd.Parameters.AddWithValue("id", data.Id);

            if (_db.ExecuteNonQuery(cmd)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
