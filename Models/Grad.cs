using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Models
{
    [Table("Grad")]

    public class Grad
    {
        [Key]
        public int ID { get; set; }
        public string ImeGrada { get; set; }
        public double Longituda { get; set; }
        public double Latituda { get; set; }
        public string SlikaGrada { get; set; }
        public int Godina { get; set; }
        public List<Mesec> Meseci { get; set; }
    }
}