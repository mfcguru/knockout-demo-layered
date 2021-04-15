using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KnockoutDemo.Business.Services.Csv
{
    using KnockoutDemo.Business.Dto;

    public interface ICsvService
    {
        Task<CsvServiceResultDto> ParseAndSave(IFormFile file);
    }
}
