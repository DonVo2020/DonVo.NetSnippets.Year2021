using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfLinqQuerySnippets._02.AutoMappingObjects.MappingConfiguration;
using EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfLinqQuerySnippets._02.AutoMappingObjects
{
    public class CategoryStartUp
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;
        private readonly CreateCategoryInputModel _viewModel;

        public CategoryStartUp()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<FastFoodProfile>());
            _context = new FastFoodContext();
            _mapper = new Mapper(config);

            _viewModel = new CreateCategoryInputModel
            {
                CategoryName = "Watches"
            };

        }

        public void Run()
        {
            CreateCategory();

            var categories = GetAllCategories();
            Console.WriteLine("Departments: ");
            foreach (var category in categories)
            {
                Console.WriteLine("\t" + category.Name);
            }
        }

        private List<CategoryAllViewModel> GetAllCategories()
        {
            var categories = _context
                .Categories
                .ProjectTo<CategoryAllViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return categories;
        }

        private int? CreateCategory()
        {
            var category = _mapper.Map<Category>(_viewModel);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.Id;
        }
    }
}
