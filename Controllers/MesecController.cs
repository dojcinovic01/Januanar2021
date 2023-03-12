using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Januar_2021.Controllers
{
   [ApiController]
    [Route("[controller]")]

    public class MesecController : ControllerBase
    {
        public PrognozaContext Context{get;set;}
        public MesecController(PrognozaContext context)
        {
            Context = context;

        }


        [Route("UnesiMesec/{idGrada}")]
        [HttpPost]

        public async Task<ActionResult> UnesiMesec(int idGrada,[FromBody] Mesec mesec)
        {
            try
            {
                var grad= Context.Gradovi.Include(g=>g.Meseci).Where(g=>g.ID==idGrada).FirstOrDefault();
                          if(grad.Meseci.Count<12)
                            {
                                Mesec mesec2= new Mesec();
                            mesec2.ImeMeseca=mesec.ImeMeseca;
                            mesec2.ProsecnaTemp=mesec.ProsecnaTemp;
                            mesec2.KolicinaPadavina=mesec.KolicinaPadavina;
                            mesec2.SuncaniDani=mesec.SuncaniDani;
                            mesec2.Grad= (Grad)grad;
                            Context.Meseci.Add(mesec2);
                            await Context.SaveChangesAsync();
                            return Ok("Uspesno dodat mesec");
                            }
                            else
                            {
                                return BadRequest("Puna godina");
                            }
                           
            }

            catch(Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [Route("IzbrisiMesec/{idMeseca}")]
        [HttpDelete]
        
        public async Task<ActionResult> BrisiMesec(int idMeseca)
        {
            try
            {
                var mesec=await Context.Meseci.FindAsync(idMeseca);
                if(mesec!=null)
                {
                    Context.Meseci.Remove(mesec);
                    await Context.SaveChangesAsync();
                    return Ok("Mesec uspesno izbrisan");
                }

                else
                {
                    return BadRequest("Mesec ne postoji");
                }
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

    
}
