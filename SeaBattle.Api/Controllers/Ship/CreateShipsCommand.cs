using System.ComponentModel.DataAnnotations;

namespace SeaBattle.Api.Controllers.Ship
{
    public class CreateShipsCommand
    {
        [Required]
        [StringLength(100)]
        public string Coordinates { get; set; }
    }
}