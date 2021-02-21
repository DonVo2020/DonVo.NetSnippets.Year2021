using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfLinqQuerySnippets._02.AutoMappingObjects.Enums;
using EfLinqQuerySnippets._02.AutoMappingObjects.MappingConfiguration;
using EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfLinqQuerySnippets._02.AutoMappingObjects
{
    public class OrderStartUp
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;
        private readonly CreateOrderInputModel _viewModel;

        public OrderStartUp()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<FastFoodProfile>());
            _mapper = new Mapper(config);

            _context = new FastFoodContext();

            _viewModel = new CreateOrderInputModel
            {
                Customer = "Sing Song",
                EmployeeName = "Calvin Chan",
                ItemName = "TV 66 inches",
                Quantity = 1,
                Type = OrderType.ToGo.ToString()
            };
        }

        public void Run()
        {
            AddOrder();

            var orders = GetAllOrders();
            Console.WriteLine("Orders: ");
            foreach (var order in orders)
            {
                Console.WriteLine("\t" + $"OrderId: {order.OrderId} - Customer: {order.Customer} - Employee: {order.Employee} - DateTime: {order.DateTime}");
            }
            Console.WriteLine("------------------------------------------------------------");
            var viewOrder = GetOrderView();
            Console.WriteLine("Create Order View: ");
            foreach (var employee in viewOrder.Employees)
            {
                Console.WriteLine("\t" + $"Employee: {employee}");
            }
            foreach (var item in viewOrder.Items)
            {
                Console.WriteLine("\t" + $"Item: {item}");
            }
        }

        private CreateOrderViewModel GetOrderView()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = _context.Items.Select(x => x.Name).ToList(),
                Employees = _context.Employees.Select(x => x.Name).ToList(),
            };


            return viewOrder;
        }

        private List<OrderAllViewModel> GetAllOrders()
        {
            var orders = _context
                .Orders
                .ProjectTo<OrderAllViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return orders;
        }

        private int? AddOrder()
        {
            var order = _mapper.Map<Order>(_viewModel);
            order.DateTime = DateTime.UtcNow;

            var employee = _context
                .Employees
                .FirstOrDefault(e => e.Name == _viewModel.EmployeeName);

            order.Employee = employee;
            order.EmployeeId = employee.Id;

            var item = _context
                .Items
                .FirstOrDefault(i => i.Name == _viewModel.ItemName);

            var orderItems = new List<OrderItem>()
            {
                new OrderItem()
                {
                    Item = item,
                    Order = order,
                    Quantity = _viewModel.Quantity
                }
            };

            order.OrderItems = orderItems;

            order.Type = Enum.Parse<OrderType>(_viewModel.Type);

            _context.Orders.Add(order);
            _context.SaveChanges();

            return order.Id;
        }
    }
}
