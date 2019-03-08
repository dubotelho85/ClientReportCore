using ClientReport.DAL.Entites;
using ClientReport.Service.Interface.Dto;

namespace ClientReport.Service.Interface.Mappers
{
    public interface IClientMapper
    {
        ClientEntity ToEntry(ClientDto client);
    }
}
