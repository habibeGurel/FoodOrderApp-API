using System.Collections.Generic;

namespace RestAPI.Core.Services
{
    public class LoginResult
    {
        public bool Success { get; }
        public List<string> Errors { get; }

        public LoginResult(bool success, List<string> errors)
        {
            Success = success;
            Errors = errors;
        }
    }
}