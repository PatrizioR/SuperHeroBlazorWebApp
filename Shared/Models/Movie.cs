using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroBlazorWebApp.Shared.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public int? SuperHeroId { get; set; }
        public SuperHero? SuperHero { get; set; }
        [Required]
        public string Title { get; set; } = null!;
    }
}
