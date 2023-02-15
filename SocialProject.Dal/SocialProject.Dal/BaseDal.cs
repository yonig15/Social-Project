using MyUtilities_CS_yoni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Dal
{
    public class BaseDal
    {
        public static LogManager Log;
        public BaseDal(LogManager log) { Log = log; }

        public BaseDal() { }
    }
}
