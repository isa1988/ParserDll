using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ParseDLLService.Dtos
{
    public class FileDllDto
    {
        public string Path { get; set; }

        // Данный метод выводит информацию о содержащихся в классе методах
        public string MethodReflectInfo<T>(T obj) where T : class
        {
            string retVal = string.Empty;
            Type t = typeof(T);
            // Получаем коллекцию методов
            MethodInfo[] MArr = t.GetMethods();
            retVal ="*** Список методов класса {0} ***\n" + obj.ToString();

            // Вывести методы
            foreach (MethodInfo m in MArr)
            {
                retVal += " --> " + m.ReturnType.Name + " \t" + m.Name + "(";
                // Вывести параметры методов
                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    retVal += p[i].ParameterType.Name + " " + p[i].Name;
                    if (i + 1 < p.Length) retVal += ", ";
                }
                retVal += ")\n";
            }

            return retVal;
        }
    }
}
