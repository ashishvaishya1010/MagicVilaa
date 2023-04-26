using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo1.Models.DTO;

namespace ApiDemo1.Data
{
    public  static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>{
                new VillaDTO {Id=1, Name="Ashish",sqft=100,Occupancy=4}, 
                new VillaDTO {Id=2, Name="Krishna",sqft=100,Occupancy=4},
                new  VillaDTO{Id=3, Name="Akshay",sqft=100,Occupancy=4},
                new VillaDTO {Id=4, Name="Prajkta",sqft=100,Occupancy=4},
                new  VillaDTO{Id=5, Name="Ayush",sqft=100,Occupancy=4}
                
        };
    }
}