using Business.Entities;
using Data.Core.Repositories.Base;

namespace Data.Core.Repositories.Interfaces
{
    public interface IParameterRepository : IRepository<DMParameter>
    {
        DMParameter GetParameterByKey(string key);
        int InsParameter(DMParameter item);
    }
}
