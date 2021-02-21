using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfLinqQuerySnippets._02.AutoMappingObjects.MappingConfiguration;
using EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Positions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfLinqQuerySnippets._02.AutoMappingObjects
{
    public class PositionStartUp
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;
        private readonly CreatePositionInputModel _viewModel;

        public PositionStartUp()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<FastFoodProfile>());
            _mapper = new Mapper(config);

            _context = new FastFoodContext();

            _viewModel = new CreatePositionInputModel
            {
                 PositionName = "QA Level 3"
            };
        }

        public void Run()
        {
            CreatePosition();

            var positions = GetAllPositions();
            Console.WriteLine("Positions: ");
            foreach (var position in positions)
            {
                Console.WriteLine("\t" + position.Name);
            }
        }

        private int? CreatePosition()
        {
            var position = _mapper.Map<Position>(_viewModel);
            _context.Positions.Add(position);
            _context.SaveChanges();
            return position.Id;
        }

        private List<PositionsAllViewModel> GetAllPositions()
        {
            var positions = _context
                .Positions
                .ProjectTo<PositionsAllViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return positions;
        }
    }
}
