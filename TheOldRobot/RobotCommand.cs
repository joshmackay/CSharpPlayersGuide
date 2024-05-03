using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOldRobot
{
    public abstract class RobotCommand
    {
        public RobotCommand() { }

        public abstract void Run(Robot robot);
    }
}
