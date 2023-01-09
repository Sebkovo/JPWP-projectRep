using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_JPWP_Sebastian_Kowanda
{
    static class Program
    {
        [STAThread]
        
        static void Main()
        {
            
            Application.SetCompatibleTextRenderingDefault(false);
            Gierka apka = new Gierka();
            Application.Run(apka);
        }
       
    }
    
}
