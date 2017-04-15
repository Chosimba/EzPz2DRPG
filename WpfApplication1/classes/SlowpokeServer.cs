using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzPzRPG.classes
{
    public class SlowpokeServer
    {
        private double Interval;
        public SlowpokeServer(double seconds) {
            if (seconds == 0.0 || seconds > 30.0)
                throw new Exception("Even slowpoke has his limits... (Greater than zero, less than thirty)");
            Interval = seconds;
        }
    }
}
