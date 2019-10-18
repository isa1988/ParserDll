using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Animal
    {
        public string Name { get; set; }

        protected void Method1(string value) { }

        public bool Method2()
        {
            return false;
        }

        private void Method3() { }
    }

    class Bird : Animal
    {
        public string Method4()
        {
            return string.Empty;
        }
        private void Method5() { }
    }
}
