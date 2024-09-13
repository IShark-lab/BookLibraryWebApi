using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Repositories
{
    public class ServiceResult
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        private ServiceResult(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public static ServiceResult Success() => new ServiceResult(true, null);
        public static ServiceResult Failure(string errorMessage) => new ServiceResult(false, errorMessage);
    }
}
