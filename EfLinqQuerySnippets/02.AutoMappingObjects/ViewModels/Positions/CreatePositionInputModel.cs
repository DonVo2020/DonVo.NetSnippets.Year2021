using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Positions
{
    public class CreatePositionInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string PositionName { get; set; }
    }
}
