using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLabanowski.Models.Entities
{
    public class PortfolioProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Technologies { get; set; }
        public string Description { get; set; }
        public string LinkUrl { get; set; }
        public string ImgUrl { get; set; }
    }
}
