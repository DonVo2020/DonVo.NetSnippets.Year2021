using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfLinqQuerySnippets._02.AutoMappingObjects.MappingConfiguration;
using EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfLinqQuerySnippets._02.AutoMappingObjects
{
    public class ItemStartUp
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;
        private readonly CreateItemInputModel _viewModel;

        public ItemStartUp()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<FastFoodProfile>());
            _mapper = new Mapper(config);

            _context = new FastFoodContext();

            _viewModel = new CreateItemInputModel
            {
                Name = "Power Supply",
                CategoryName = "Electronics",
                Price = 37.77M
            };
        }

        public void Run()
        {
            CreateItem();

            var items = GetAllItems();
            Console.WriteLine("Items: ");
            foreach (var item in items)
            {
                Console.WriteLine("\t" + $"Name: {item.Name} - Price: ${item.Price} - Category: {item.Category}");
            }

            var categories = GetCategories();
            Console.WriteLine("Categories: ");
            foreach (var category in categories)
            {
                Console.WriteLine("\t" + $"Name: {category.CategoryName}");
            }
        }

        private List<ItemsAllViewModels> GetAllItems()
        {
            var items = _context
                .Items
                .ProjectTo<ItemsAllViewModels>(_mapper.ConfigurationProvider)
                .ToList();

            return items;
        }

        private List<CreateItemViewModel> GetCategories()
        {
            var categories = _context
                 .Categories
                 .ProjectTo<CreateItemViewModel>(_mapper.ConfigurationProvider)
                 .ToList();

            return categories;
        }

        private int? CreateItem()
        {
            var item = _mapper.Map<Item>(_viewModel);

            var category = _context.Categories.FirstOrDefault(c => c.Name == _viewModel.CategoryName);
            item.CategoryId = category.Id;
            item.Category = category;
            _context.Items.Add(item);
            _context.SaveChanges();

            return item.Id;
        }
    }
}
