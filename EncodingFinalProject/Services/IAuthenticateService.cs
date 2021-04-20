using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncodingFinalProject.Models;

namespace EncodingFinalProject.Services
{
    public interface IAuthenticateService
    {
        Teacher Authenticate(String UserName, String Password);
    }

}
