using System;
using System.Collections.Generic;
using System.Linq;
using RobotService.Core.Contracts;
using RobotService.Factories;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly RobotFactory robotFactory;
        private readonly IGarage garage;
        private readonly Dictionary<string, IProcedure> procedures;
        private IProcedure chip;
        private IProcedure techCheck;
        private IProcedure rest;
        private IProcedure work;
        private IProcedure charge;
        private IProcedure polish;

        public Controller()
        {
            this.robotFactory = new RobotFactory();
            this.garage = new Garage();
            this.procedures = new Dictionary<string, IProcedure>();
            this.InitializeProcedures();
        }

        private void InitializeProcedures()
        {
            this.chip = new Chip();
            this.techCheck = new TechCheck();
            this.rest = new Rest();
            this.work = new Work();
            this.charge = new Charge();
            this.polish = new Polish();

            procedures.Add("Chip", this.chip);
            procedures.Add("TechCheck", this.techCheck);
            procedures.Add("Rest", this.rest);
            procedures.Add("Work", this.work);
            procedures.Add("Charge", this.charge);
            procedures.Add("Polish", this.polish);
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = this.robotFactory.CreateRobot(robotType, name, energy, happiness, procedureTime);

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
            IProcedure procedure = this.procedures[procedureType];
            return procedure.History();
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
