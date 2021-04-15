using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnockoutDemo.Business.Services.Report
{
    using KnockoutDemo.Business.Dto;

    public interface IReportService
    {
        Task<List<ReportServiceResultDto>> GetAllUsers();
        Task DeleteAllUsers();
    }
}
