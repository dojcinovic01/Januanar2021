using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Models
{
    [Table("Mesec")]
    
    public class Mesec
    {
        [Key]
        public int ID { get; set; }
        public string ImeMeseca { get; set; }
        public double ProsecnaTemp { get; set; }        
        public double KolicinaPadavina { get; set; }
        public int SuncaniDani { get; set; } 
         [JsonIgnore]
        public Grad Grad { get; set; }

    }

}