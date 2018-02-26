using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCore.Models
{
    public class TestModel:Entity<int>
    {
        [Key]
        public override int Id { get; set; }
        public int Sex { get; set; }
        public string   Name{ get; set; }
        public string Moblie { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsDel { get; set; }
    }
}
