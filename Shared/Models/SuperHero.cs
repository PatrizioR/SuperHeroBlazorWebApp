using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroBlazorWebApp.Shared.Models
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RealName { get; set; } = null!;

        [Required]
        public string HeroName { get; set; } = null!;
        
        public List<Movie>? Movies { get; set; }
        public List<int>? MovieIds => Movies?.Select((item) => item.Id).ToList();
    }
}
