using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_15.Controllers;
using WebAPI_15.Data.Models;

namespace WebAPI_15.Data.Services
{
    public class LogsService
    {
        private readonly AppDbContext _context;
        public LogsService(AppDbContext context)
        {
            _context = context;
        }

        public List<Log> GetAllLogs() => _context.Logs.ToList();
    }
}
