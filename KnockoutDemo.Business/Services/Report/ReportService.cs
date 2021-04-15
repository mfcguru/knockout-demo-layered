using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutDemo.Business.Services.Report
{
    using KnockoutDemo.Business.Dto;
    using KnockoutDemo.Data.Entities;

    public class ReportService : IReportService
    {
        private readonly DataContext context;
        public ReportService(DataContext context) => this.context = context;

        public async Task<List<ReportServiceResultDto>> GetAllUsers()
        {
            var result = await context.Users
                .OrderBy(o => o.UserId)
                .Select(o => new ReportServiceResultDto
                {
                    UserId = o.UserId,
                    FullName = string.Format("{0} {1}", o.FirstName, o.LastName),
                    Age = o.Age
                }).ToListAsync();

            return result;
        }

        public async Task DeleteAllUsers()
        {
            context.Users.RemoveRange(context.Users);

            await context.SaveChangesAsync();
        }
    }
}
