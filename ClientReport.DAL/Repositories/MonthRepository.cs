using ClientReport.DAL.Entites;
using ClientReport.DAL.Extensions;
using ClientReport.DAL.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientReport.DAL.Repositories
{
    public class MonthRepository : IMonthRepository
    {
        private readonly IConfiguration config;
        private IMongoCollection<MonthEntity> collection;

        public MonthRepository(IConfiguration config)
        {
            this.config = config;
            var client = new MongoClient(config.GetConnectionString("DefaultDB"));
            collection = client
                .GetDatabase("Report")
                .GetCollection<MonthEntity>("ClientsByMonth");
        }

        public async Task<MonthEntity> GetMonthDataAsync(DateTime month)
        {
            var months = await collection
                .FindAsync(p=>p.MonthId == month.ToString("yyyyMM"));
            return await months?.FirstOrDefaultAsync();
        }

        public async Task UpdateMonthDataAsync(DateTime month, ClientEntity client)
        {
            var monthDb = await this.GetMonthDataAsync(month);

            if(monthDb != null)
            {
                var clientDb = monthDb.Clients
                    .Where(p => p.Name == client?.Name)
                    .FirstOrDefault();

                if (clientDb != null)
                {
                    clientDb.Value += client.Value;
                }
                else
                {
                    var clients = monthDb.Clients.ToList();
                    clients.Add(client);
                    monthDb.Clients = clients;
                }

                await collection
                    .ReplaceOneAsync(p => p.MonthId == monthDb.MonthId, monthDb);
            }
            else
            {
                monthDb = new MonthEntity
                {
                    MonthId = month.ToString("yyyyMM"),
                    Month = month.GetMonthName(),
                    Clients = new List<ClientEntity>() { client }
                };

                collection.InsertOne(monthDb);
            }
        }
    }
}
