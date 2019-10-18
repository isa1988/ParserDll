using System;
using System.Collections.Generic;
using System.Text;
using ParseDLLService.Dtos;

namespace ParseDLLService.Services.Contracts
{
    public interface IWorkToFile
    {
        string ShowMethods(FileDllDto fileDll);
    }
}
