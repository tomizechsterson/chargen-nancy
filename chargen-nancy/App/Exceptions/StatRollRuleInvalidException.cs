using System;

namespace chargen_nancy.App.Exceptions
{
    public class StatRollRuleInvalidException : ArgumentOutOfRangeException
    {
        public StatRollRuleInvalidException(string paramName, string paramValue, string message) : base(paramName, paramValue, message) {}
    }
}