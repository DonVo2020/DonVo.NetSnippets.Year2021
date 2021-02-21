using System.Collections.Generic;

namespace EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        public List<string> Items { get; set; }

        public List<string> Employees { get; set; }
    }
}
