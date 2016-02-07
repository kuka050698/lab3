using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake1
{
    public class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Yellow;
            sign = '$';
        }
    }
}
 