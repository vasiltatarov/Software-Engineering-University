using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        protected ICollection<IRobot> Robots { get; set; }

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            foreach (var robot in this.Robots)
            {
                sb.AppendLine($" Robot type: {robot.GetType().Name} - {robot.Name} - Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            //if (expr)
            //{
                
            //}

            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);
        }
    }
}
