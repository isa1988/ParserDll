using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
                retVal +=  ResultReadFile(fileList[i], fileDll.Path, retVal);
            }
            return retVal;
        }

        private string ResultReadFile(string fullPath, string path, string result)
        {
            var asm = System.Reflection.Assembly.LoadFile(fullPath);
            
            var classesTypes = asm.DefinedTypes.Where(n => n.IsClass).ToList();
            MethodInfo[] methods = null;
            result = "файл " + fullPath.Replace(path + "\\", "") + Environment.NewLine;
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
            return result;
        }
    }
}
