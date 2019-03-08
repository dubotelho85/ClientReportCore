using ClientReport.DAL.Entites;
using ClientReport.Service.Interface.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientReport.Service.Interface.Processors
{
    public interface IMonthProcessor
    {
        Task<IEnumerable<MonthEntity>> GetLastMonthsAsync(int numberOfMonths);
        Task AddDataAsync(ClientDto value);
    }
}
