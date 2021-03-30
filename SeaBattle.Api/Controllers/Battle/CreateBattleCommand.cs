using System.ComponentModel.DataAnnotations;

namespace SeaBattle.Api.Controllers.Battle
{
    public class CreateBattleCommand
    {
        [Required]
        [Range(1, 100)]
        public int Range { get; set; }
    }
}