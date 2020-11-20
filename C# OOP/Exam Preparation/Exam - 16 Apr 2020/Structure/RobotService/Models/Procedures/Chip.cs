using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.Happiness -= 5;
            robot.IsChipped = true;
        }
    }
}
