using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Factories;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly Dictionary<int, IComputer> _computers;
        private readonly Dictionary<int, IComponent> _components;
        private readonly Dictionary<int, IPeripheral> _peripherals;
        private readonly Factory _factory;

        public Controller()
        {
            _computers = new Dictionary<int, IComputer>();
            _components = new Dictionary<int, IComponent>();
            _peripherals = new Dictionary<int, IPeripheral>();
            _factory = new Factory();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (_computers.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = _factory.CreateComputer(computerType, id, manufacturer, model, price);

            _computers.Add(id, computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            CheckIfComputerIdExist(computerId);
            IComputer computer = _computers[computerId];

            if (_peripherals.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = _factory.CreatePeripheral(id, peripheralType, manufacturer, model, price,
                overallPerformance, connectionType);

            computer.AddPeripheral(peripheral);
            _peripherals.Add(id, peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerIdExist(computerId);
            IComputer computer = _computers[computerId];

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);

            _peripherals.Remove(peripheral.Id);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            CheckIfComputerIdExist(computerId);

            IComputer computer = _computers[computerId];

            if (_components.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = _factory.CreateComponent(id, componentType, manufacturer, model, price,
                overallPerformance, generation);

            computer.AddComponent(component);
            _components.Add(id, component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerIdExist(computerId);
            IComputer computer = _computers[computerId];

            IComponent component = computer.RemoveComponent(componentType);

            _components.Remove(component.Id);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerIdExist(id);

            IComputer computer = _computers[id];
            _computers.Remove(id);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            if (_computers.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            var computersCanBuy = _computers.Where(x => x.Value.Price <= budget)
                .OrderByDescending(x => x.Value.Price)
                .ToDictionary(x => x.Key, x => x.Value);

            if (computersCanBuy.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer computer = null;

            foreach (var kvp in computersCanBuy)
            {
                computer = kvp.Value;
                break;
            }

            _computers.Remove(computer.Id);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfComputerIdExist(id);

            return _computers[id].ToString();
        }

        private void CheckIfComputerIdExist(int id)
        {
            if (!_computers.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
