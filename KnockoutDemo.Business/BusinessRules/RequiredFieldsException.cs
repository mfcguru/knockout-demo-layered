using System.Net;

namespace KnockoutDemo.Business.BusinessRules
{
    public class RequiredFieldsException : BusinessRulesException
    {
        private const string message = "Parse error: Required fields are missing.";

        public RequiredFieldsException(int lineNo) : base(HttpStatusCode.BadRequest, string.Format(message, lineNo)) { }
    }
}
