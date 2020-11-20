using System;
using System.Linq;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private IProcedure chip;
        private IProcedure techCheck;
        private IProcedure rest;
        private IProcedure work;
        private IProcedure charge;
        private IProcedure polish;

        public Controller()
        {
            this.garage = new Garage();
            this.chip = new Chip();
            this.techCheck = new TechCheck();
            this.rest = new Rest();
            this.work = new Work();
            this.charge = new Charge();
            this.polish = new Polish();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
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

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            this.EnsureRobotExist(robotName);

            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.chip.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            this.EnsureRobotExist(robotName);

            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.techCheck.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            this.EnsureRobotExist(robotName);

            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.rest.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            this.EnsureRobotExist(robotName);

            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.work.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            this.EnsureRobotExist(robotName);

            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.charge.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            this.EnsureRobotExist(robotName);

            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.polish.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            this.EnsureRobotExist(robotName);

            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string History(string procedureType)
        {
            if (procedureType == "Chip")
            {
                return this.chip.History();
            }
            else if (procedureType == "TechCheck")
            {
                return this.techCheck.History();
            }
            else if (procedureType == "Rest")
            {
                return this.rest.History();
            }
            else if (procedureType == "Work")
            {
                return this.work.History();
            }
            else if (procedureType == "Charge")
            {
                return this.charge.History();
            }
            else if (procedureType == "Polish")
            {
                return this.polish.History();
            }
            else
            {
                return null;
            }
        }

        private void EnsureRobotExist(string robotName)
        {
            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
