using System;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string _username;
        private int _health;
        private int _armor;
        private IGun _gun;

        public Player(string username, int health,int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Gun = gun;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get
            {
                return this._username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this._username = value;
            }
        }

        public int Health
        {
            get
            {
                return this._health;
            }
            private set
            {
                if (value < 0) // TODO <= 0 ?
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this._health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this._armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this._armor = value;
            }
        }

        public IGun Gun
        {
            get
            {
                return this._gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this._gun = value;
            }
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            if (this.Armor >= points)
            {
                this.Armor -= points;
            }
            else
            {
                points -= this.Armor;

                this.Armor = 0;

                if (this.Health > points)
                {
                    this.Health -= points;
                }
                else
                {
                    this.Health = 0;
                }
                //if (this.Health - points < 0)
                //{
                //    this.Health = 0;
                //}
                //else
                //{
                //    this.Health -= points;
                //}
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"{this.GetType().Name}: {this.Username}")
                .AppendLine($"--Health: {this.Health}")
                .AppendLine($"--Armor: {this.Armor}")
                .AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
