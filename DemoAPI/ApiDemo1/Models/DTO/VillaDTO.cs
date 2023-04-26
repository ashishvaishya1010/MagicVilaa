using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo1.Models.DTO
{
    public class VillaDTO
    {
        
    public int Id {get; set;}
    [Required]
    [MaxLength(30)]
    public string Name {get; set;}
     
     public int Occupancy{get;set;}
     public int sqft{get;set;} 

    }
}