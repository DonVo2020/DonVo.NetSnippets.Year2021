using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfLinqQuerySnippets._02.AutoMappingObjects.MappingConfiguration;
using EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Employees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfLinqQuerySnippets._02.AutoMappingObjects
{
    public class EmployeeStartUp
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;
        private readonly RegisterEmployeeInputModel _viewModel;

        public EmployeeStartUp()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<FastFoodProfile>());
            _mapper = new Mapper(config);

            _context = new FastFoodContext();
            
            _viewModel = new RegisterEmployeeInputModel
            {
                Name = "Ken Jotisa",
                Age = 28,
                PositionName = "Software Engineer",
                Address = "Miami, FL"
            };
        }

        public void Run()
        {
            AddEmployee();

            var employees = GetAllEmployees();
            Console.WriteLine("Employees: ");
            foreach (var employee in employees)
            {
                Console.WriteLine("\t" + $"Name: {employee.Name} - Position: {employee.Position} - Age: {employee.Age}");
            }

            var postions = GetPositions();
            Console.WriteLine("Positions: ");
            foreach (var position in postions)
            {
                Console.WriteLine("\t" + $"Position Name: {position.PositionName}");
            }
        }

        private List<RegisterEmployeeViewModel> GetPositions()
        {
            var positions = _context
                .Positions
                .ProjectTo<RegisterEmployeeViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return positions;
        }

        private List<EmployeesAllViewModel> GetAllEmployees()
        {
            var employees = _context
                .Employees
                .ProjectTo<EmployeesAllViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return employees;
        }

        private int? AddEmployee()
        {
            var employee = _mapper.Map<Employee>(_viewModel);
            employee.Position = _context.Positions
                        .FirstOrDefault(p => p.Name == _viewModel.PositionName);

            employee.PositionId = employee.Position.Id;
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id;
        }
    }
}
