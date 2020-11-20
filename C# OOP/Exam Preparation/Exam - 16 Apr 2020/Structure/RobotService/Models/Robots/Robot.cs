using System;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private const int MinHappinessAndEnergy = 0;
        private const int MaxHappinessAndEnergy = 100;

        private int energy;
        private int happiness;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

            this.Owner = "Service";
            this.IsBought = false;
            this.IsChipped = false;
            this.IsChecked = false;
        }

        public string Name { get; }//Maybe occur bug because dont have validation!

        public int Happiness
        {
            get
            {
                return this.happiness;
            } 
            set
            {
                if (value < MinHappinessAndEnergy || value > MaxHappinessAndEnergy)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < MinHappinessAndEnergy || value > MaxHappinessAndEnergy)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsBought { get; set; }

        public bool IsChipped { get; set; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
