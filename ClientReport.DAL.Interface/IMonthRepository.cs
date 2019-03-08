using ClientReport.DAL.Entites;
using System;
using System.Threading.Tasks;

namespace ClientReport.DAL.Interface
{
    public interface IMonthRepository
    {
        Task UpdateMonthDataAsync(DateTime month, ClientEntity client);
        Task<MonthEntity> GetMonthDataAsync(DateTime month);
    }
}
