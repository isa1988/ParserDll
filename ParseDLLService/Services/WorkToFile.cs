using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ParseDLLService.Dtos;
using ParseDLLService.Services.Contracts;

namespace ParseDLLService.Services
{
    public class WorkToFile : IWorkToFile
    {
        public string ShowMethods(FileDllDto fileDll)
        {
            if (fileDll == null) return "объект пустой";

            string[] fileList = Directory.GetFiles(fileDll.Path, "*.dll");
            string retVal = string.Empty;
            for (int i = 0; i <fileList.Length; i++)
            {
                ResultReadFile(fileList[i], ref retVal);
            }
            return retVal;
        }

        private void ResultReadFile(string path, ref string result)
        {
            var asm = System.Reflection.Assembly.LoadFile(path);

            var classesTypes = asm.DefinedTypes.ToList();
            MethodInfo[] methods = null;
            foreach (var recType in classesTypes)
            {
                result += recType.Name.Trim() + Environment.NewLine;
                methods = recType.GetMethods();
                foreach (var method in methods)
                {
                    if (method.IsPrivate) continue;
                    result += "     o " + method.Name.Trim() + Environment.NewLine;
                }

            }
        }
    }
}
