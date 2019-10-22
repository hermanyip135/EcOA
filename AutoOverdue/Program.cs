using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOverdue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OfficialSealOverdue officialsealOverdue = new OfficialSealOverdue();
            officialsealOverdue.SetOverdue();
        }


    }
}
