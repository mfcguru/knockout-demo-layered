using System.Net;

namespace KnockoutDemo.Business.BusinessRules
{
    public class InvalidCsvHeaderException : BusinessRulesException
    {
        private const string message = "Parse error: Invalid CSV header";

        public InvalidCsvHeaderException() : base(HttpStatusCode.BadRequest, string.Format(message)) { }
    }
}
