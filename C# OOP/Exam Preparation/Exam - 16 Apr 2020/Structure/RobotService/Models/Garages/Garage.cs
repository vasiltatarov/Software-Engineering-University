using System;
using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int DefaultCapacity = 10;
        private readonly IDictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
            this.Capacity = DefaultCapacity;
        }

        public IReadOnlyDictionary<string, IRobot> Robots 
            => (IReadOnlyDictionary<string, IRobot>)robots;

        public int Capacity { get;}

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!(this.robots.ContainsKey(robotName)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = this.robots.FirstOrDefault(x => x.Key == robotName).Value;

            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
