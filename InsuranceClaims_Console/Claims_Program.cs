using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims_Console
{
    public class Claims_Program
    {

        static void Main(string[] args)
        {
            Claims_ProgramUI claimsUI = new Claims_ProgramUI();
            claimsUI.Run();
        }
    }
}
