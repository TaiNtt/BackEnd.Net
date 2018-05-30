using Business.Entities;
using Data.Core.Repositories.Base;
using Data.Core.Repositories.Interfaces;
using log4net;

namespace Data.Core.Repositories
{
    public class DuongDiQuyTrinhRepository : Repository<DMDuongDiQuyTrinh>, IDuongDiQuyTrinhRepository
    {
        private const string TableName = "";
        private readonly ILog _logger;

        public DuongDiQuyTrinhRepository(ILog logger) : base(TableName,"")
        {
            _logger = logger;
        }
    }
}
