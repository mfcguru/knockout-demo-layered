using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KnockoutDemo.Business.Services.Csv
{
    using KnockoutDemo.Business.BusinessRules;
    using KnockoutDemo.Business.Dto;
    using KnockoutDemo.Data.Entities;

    public class CsvService : ICsvService
    {
        private readonly DataContext context;
        public CsvService(DataContext context) => this.context = context;

        public async Task<CsvServiceResultDto> ParseAndSave(IFormFile file)
        {
            var result = new CsvServiceResultDto();
            var items = ReadAsList(file);
            var lineNo = 1;
            foreach (var item in items)
            {
                var data = item.Split(',');
                await Validate(data, lineNo);
                context.Users.Add(new User
                {
                    UserId = int.Parse(data[0]),
                    FirstName = data[1],
                    LastName = data[2],
                    Age = int.Parse(data[3])
                });
                lineNo++;
            }
            await context.SaveChangesAsync();
            return result;
        }

        private async Task Validate(string[] data, int lineNo)
        {
            if (data.Length != 4)
            {
                throw new InvalidRowException(lineNo);
            }

            if (data[0].Length == 0 ||
                data[1].Length == 0 ||
                data[2].Length == 0 ||
                data[3].Length == 0)
            {
                throw new RequiredFieldsException(lineNo);
            }

            int userId;
            if (int.TryParse(data[0], out userId) == false)
            {
                throw new InvalidUserIdException(lineNo);
            }
            if (await context.Users.AnyAsync(o => o.UserId == userId) == true)
            {
                throw new InvalidUserIdException(lineNo);
            }

            int age;
            if (int.TryParse(data[3], out age) == false)
            {
                throw new InvalidAgeException(lineNo);
            }
            if (age < 0)
            {
                throw new InvalidAgeException(lineNo);
            }
        }

        private List<string> ReadAsList(IFormFile file)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var header = reader.ReadLine().Replace(" ", "").Split(',');
                if (header.Length != 4)
                {
                    throw new InvalidCsvHeaderException();
                }
                if (header[0].ToLower() != "userid" ||
                    header[1].ToLower() != "firstname" ||
                    header[2].ToLower() != "lastname" ||
                    header[3].ToLower() != "age")
                {
                    throw new InvalidCsvHeaderException();
                }
                while (reader.Peek() >= 0)
                {
                    result.Add(reader.ReadLine());
                }   
            }
            return result;
        }
    }
}
