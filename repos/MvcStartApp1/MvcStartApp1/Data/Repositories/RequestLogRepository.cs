using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcStartApp1.Data;
using MvcStartApp1.Data.Interfaces;
using MvcStartApp1.Models.Db;

namespace MvcStartApp1.Data.Repositories
{
    public class RequestLogRepository : IRequestLogRepository
    {
        private readonly BlogContext _context;

        public RequestLogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task LogRequestAsync(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }
    }
}