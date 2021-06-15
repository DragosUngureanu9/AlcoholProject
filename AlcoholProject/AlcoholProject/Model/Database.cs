using System.Collections.Generic;
using System.Threading.Tasks;
using AlcoholProject.Model;
using SQLite;

namespace AlcoholProject
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Alcohol>().Wait();
        }

        public Task<List<Alcohol>> GetPeopleAsync()
        {
            return _database.Table<Alcohol>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Alcohol person)
        {
            return _database.InsertAsync(person);
        }
    }
}