using System;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Factories
{
    public class RobotFactory
    {
        public IRobot CreateRobot(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            return robot;
        }
    }
}
