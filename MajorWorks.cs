using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moskalchuk_IKM722a_2kurs_project
{
    internal class MajorWorks
    {
        private string Data; 
        private string Result;

        public void Write(string D)
        {
            this.Data = D;
        }
        public string Read()
        {
            return this.Result;
        }
        public void Task() 
        {
            if (this.Data.Length> 5)
            {
                this.Result = Convert.ToString (true);
            }
            else
            {
                this.Result = Convert.ToString(false);
            }
        }
    }
}
