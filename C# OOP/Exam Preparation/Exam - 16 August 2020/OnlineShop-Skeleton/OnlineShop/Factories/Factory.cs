using System;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Factories
{
    public class Factory
    {
        public IComputer CreateComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;

            if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            return computer;
        }

        public IPeripheral CreatePeripheral(int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IPeripheral peripheral = null;

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            return peripheral;
        }

        public IComponent CreateComponent(int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            IComponent component = null;

            if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            return component;
        }
    }
}
