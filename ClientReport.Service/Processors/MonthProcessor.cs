using ClientReport.DAL.Entites;
using ClientReport.DAL.Interface;
using ClientReport.Service.Interface.Dto;
using ClientReport.Service.Interface.Mappers;
using ClientReport.Service.Interface.Processors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientReport.Service.Processors
{
    public class MonthProcessor : IMonthProcessor
    {
        private readonly IMonthRepository monthRepository;
        private readonly IClientMapper clientMapper;

        public MonthProcessor(IMonthRepository monthRepository, IClientMapper clientMapper)
        {
            this.monthRepository = monthRepository;
            this.clientMapper = clientMapper;
        }

        public async Task AddDataAsync(ClientDto value)
        {
            var date = value?.Month ?? DateTime.Now;
            var entry = clientMapper.ToEntry(value);
            await monthRepository.UpdateMonthDataAsync(date, entry);
        }

        public async Task<IEnumerable<MonthEntity>> GetLastMonthsAsync(int numberOfMonths)
        {
            var lastMonths = new List<MonthEntity>();

            lastMonths.Add(await monthRepository.GetMonthDataAsync(DateTime.Now) ?? new MonthEntity());
            lastMonths.Add(await monthRepository.GetMonthDataAsync(DateTime.Now.AddMonths(-1)) ?? new MonthEntity());
            lastMonths.Add(await monthRepository.GetMonthDataAsync(DateTime.Now.AddMonths(-2)) ?? new MonthEntity());

            return lastMonths;
        }
    }
}
