using System.Collections.Generic;
using System.Threading.Tasks;
using MvcStartApp1.Models.Db;

namespace MvcStartApp1.Data.Interfaces
{
    public interface IRequestLogRepository
    {
        Task LogRequestAsync(Request request);
        Task<List<Request>> GetAllRequestsAsync();
    }
}