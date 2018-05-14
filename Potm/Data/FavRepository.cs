using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Potm.Data;
using SQLite;

namespace Potm.Data
{
    public class FavRepository
    {
        private SQLiteAsyncConnection conn;
        public FavRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Favourite>().Wait();
        }

        public async Task addFav(favTeam t)
        {
            int result = 0;

            try {
				result = await conn.InsertAsync(new Favourite
				{
					clubId = t.clubId,
					clubLogo = t.clubLogo,
					clubName = t.clubName,
					teamName = t.teamName,
					teamGender = t.teamGender,
					sportName = t.sportName
					              
                });
            }
            catch 
            {
                result = 0;
            }
        }

        public async Task<List<Favourite>> GetFavs()
        {
            try
            {
                return await conn.Table<Favourite>().ToListAsync();
            }
            catch
            {
                return new List<Favourite>();            
            }
        }

        public async Task DeleteFav(Favourite fav)
        {
            int result = 0;

            try
            {
                result = await conn.DeleteAsync(fav);
            }
            catch
            {
                result = 0;   
            }
        }
    }
}
