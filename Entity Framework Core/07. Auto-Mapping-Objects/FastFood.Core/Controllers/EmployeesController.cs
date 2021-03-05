using System.Linq;
using AutoMapper.QueryableExtensions;
using FastFood.Models;

namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            var employeeViewModel = context.Positions
                .ProjectTo<RegisterEmployeeViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = this.mapper.Map<Employee>(model);

            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            return RedirectToAction("All", "Employees");
        }

        public IActionResult All()
        {
            var employees = this.context.Employees
                .ProjectTo<EmployeesAllViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(employees);
        }
    }
}
