using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_JPWP_Sebastian_Kowanda
{
    public class item
    {
        /// <summary>
        /// Item class
        /// </summary>

        /// <summary>
        /// Name of an item
        /// </summary>
        public string name;
        /// <summary>
        /// Value of an item
        /// </summary>
        public string value;

        /// <summary>
        /// Item main method
        /// </summary>
        /// <param name="name1">Item name</param>
        /// <param name="value1">Item value</param>
        public item(string name1, string value1)
        {
             name = name1;
            value = value1;
        }
    }
}
