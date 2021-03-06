using System.Collections.ObjectModel;

namespace TourPlanner.DAL.Repositories {
    public interface IRepository<T> {

        public bool Create(T data);
        public bool Update(T data);
        public T Read(string name);
        public ObservableCollection<T> ReadAll();
        public bool Delete(string name);

    }
}
