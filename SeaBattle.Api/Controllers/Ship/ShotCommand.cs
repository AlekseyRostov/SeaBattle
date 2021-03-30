using System.ComponentModel.DataAnnotations;

namespace SeaBattle.Api.Controllers.Ship
{
    public class ShotCommand
    {
        [Required]
        [StringLength(100)]
        public string Coordinates { get; set; }
    }
}