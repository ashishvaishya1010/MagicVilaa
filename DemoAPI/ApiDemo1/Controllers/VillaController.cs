using ApiDemo1.Data;
using ApiDemo1.Models.DTO;
using DemoAPI;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace controller{

    [ApiController]
    [Route("/apiVilla")]
    public class VillaAPIController : ControllerBase
         {       
            // private readonly ILogger<VillaAPIController>
              
            // public VillaAPIController(ILogger<VillaAPIController> logger)
            // {
            //   _logger = logger;
            // }

        private object villaDTO;

        [HttpGet]
        [Route("")]
        public ActionResult<VillaDTO> GetVillas()
        {
          //_logger.LogInfromation("Geting all villas");
            return Ok (VillaStore.villaList);
        }

         [HttpGet("{id:int}",Name="GetVilla")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult <VillaDTO>GetVillas( int id )
        {
          if (id==0){
            //_logger.LoError("Get Villa Error with id "+id);
            return BadRequest();
          }

          var  villa = VillaStore.villaList.FirstOrDefault(u=>u.Id==id);
           if (villa == null){
            return NotFound();
           }
            return  Ok (villa);
        }
         
          [HttpPost]
           [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
             

             
            public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO)
          {
            if(villaDTO==null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villaDTO.Id= VillaStore.villaList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            VillaStore.villaList.Add(villaDTO);
            
            return CreatedAtRoute("GetVilla",new {id =villaDTO.Id},villaDTO);

          }
           [HttpDelete("{id:int}",Name="DeleteVilla")]
           public IActionResult DeleteVilla(int id) {
            if (id==0){
              return BadRequest();
            }
              var  villa = VillaStore.villaList.FirstOrDefault(u=>u.Id==id);
           if (villa == null){
            return NotFound();
           }
            VillaStore.villaList.Remove(villa);
              return NoContent();
           }
           [HttpPut("{id:int}",Name="DeleteVilla")]
           public  IActionResult  UpdateVilla ( int id ,[FromBody]VillaDTO villaDTO)
           {
            if(villaDTO==null|| id !=villaDTO.Id)
            {
                return BadRequest(villaDTO);
            }
             var  villa = VillaStore.villaList.FirstOrDefault(u=>u.Id==id);
            villa.Name=villaDTO.Name;
            villa.sqft=villaDTO.sqft;
            villa.Occupancy=villaDTO.Occupancy;

            return NoContent();

           }
           [HttpPatch("{id :int}",Name ="UpdatePartialVilla")]
            [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public IActionResult UpdatePartialVilla(int id,JsonPatchDocument<VillaDTO> patchDTO)
          {
            if(patchDTO == null || id==0)
            {
                return BadRequest(villaDTO);
            }
             var  villa = VillaStore.villaList.FirstOrDefault(u=>u.Id==id);
              if(villa ==null )
            {
                return BadRequest(villaDTO);
            }
            patchDTO.ApplyTo(villa,ModelState);
            if(!ModelState.IsValid)
            {
                  return BadRequest();
               
           }  
               return NoContent();

          }
            
          }     
    }
