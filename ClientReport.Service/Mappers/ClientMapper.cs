using ClientReport.DAL.Entites;
using ClientReport.Service.Interface.Dto;
using ClientReport.Service.Interface.Mappers;

namespace ClientReport.Service.Mappers
{
    public class ClientMapper : IClientMapper
    {
        public ClientEntity ToEntry(ClientDto client)
        {
            return new ClientEntity
            {
                Name = client.Name,
                Value = client.Value
            };
        }
    }
}
