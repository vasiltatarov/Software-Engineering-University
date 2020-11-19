using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
            => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals 
            => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public override double OverallPerformance => this.components.Count == 0
            ? base.OverallPerformance
            : base.OverallPerformance + this.components.Average(x => x.OverallPerformance);

        public override decimal Price => this.CalculatePrice();

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (this.components.Count == 0 || component == null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(component);
            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (this.peripherals.Count == 0 || peripheral == null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.CalculateOverallPerformance():F2}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }

        private double CalculateOverallPerformance()
            => this.peripherals.Count == 0
            ? 0
            : this.peripherals.Average(x => x.OverallPerformance);

        private decimal CalculatePrice()
        {
            var result = base.Price;

            if (this.components.Any())
            {
                result += this.components
                    .Sum(x => x.Price);
            }

            if (this.peripherals.Any())
            {
                result += this.peripherals
                    .Sum(x => x.Price);
            }

            return result;
        }
    }
}
