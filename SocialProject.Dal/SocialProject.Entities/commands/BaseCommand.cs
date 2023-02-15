using MyUtilities_CS_yoni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities.commands
{
    public class BaseCommand
    {
        public LogManager Log;
        public BaseCommand(LogManager log) { Log = log; }
    }
}
