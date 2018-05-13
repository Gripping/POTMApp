using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Potm.Data;
using SQLite;

namespace Potm.Data
{
    public class VoteRepo
    {
        private SQLiteAsyncConnection conn;
        public VoteRepo(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            //conn.CreateTableAsync<deviceId>().Wait();
        }

        public async Task<deviceId> GetDeviceId()
        {
            var deviceId = await conn.Table<deviceId>().ToListAsync();
			int result = 0;

            if(deviceId.Count == 0)
            {
                var newId = Guid.NewGuid().ToString();

                try
                {

                    result = await conn.InsertAsync(new deviceId
                    {
                        id = newId
                    });

                    deviceId = await conn.Table<deviceId>().ToListAsync();

                }
                catch
                {
                    result = 0;
                }
            }else{
                
            }

            return deviceId.First();
        }
    }
}
