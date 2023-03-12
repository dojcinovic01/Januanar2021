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

    public class GradController : ControllerBase
    {
        public PrognozaContext Context{get;set;}
        public GradController(PrognozaContext context)
        {
            Context = context;

        }


        [Route("DodajGrad")]
        [HttpPost]
        public async Task<ActionResult> DodajGrad([FromBody] Grad grad)
        {
            try
            {
                Context.Gradovi.Add(grad);
                await Context.SaveChangesAsync();
                return Ok("Grad je dodat u bazu");
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PreuzmiGradove")]
        [HttpGet]

        public async Task<ActionResult> PreuzmiGradove(/*string imeGrada*/)
        {
            try
            {
                //var gradovi= Context.Gradovi.Include(g=>g.Meseci).Where(g=>g.ImeGrada==imeGrada);
                var gradovi=Context.Gradovi.Include(g=>g.Meseci);
                return Ok(gradovi);
            }
            
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("AzurirajGrad/{idGrada}")]
        [HttpPut]

        public async Task<ActionResult> AzurirajGrad(int idGrada,[FromBody] Grad grad)
        {
            
            try
            {
                var gradic=await Context.Gradovi.FindAsync(idGrada);

                 if(gradic!=null)
                 {
                    gradic.ImeGrada=grad.ImeGrada;
                    gradic.Longituda=grad.Longituda;
                    gradic.Latituda=grad.Latituda;
                    gradic.Godina=grad.Godina;
                    gradic.SlikaGrada=grad.SlikaGrada;

                    await Context.SaveChangesAsync();
                    return Ok("Grad uspesno izmenenjen");
                 }

                 else
                 {
                    return BadRequest("Grad ne postoji");
                 }

            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
/*
        [Route("AzurirajSlikuGrada/{idGrada}/{slikaGrada")]
        [HttpPut]

        public async Task<ActionResult> AzurirajSlikuGrada(int idGrada,string slikaGrada)
        {
            
            try
            {
                var gradic=await Context.Gradovi.FindAsync(idGrada);

                 if(gradic!=null)
                 {
                   
                    gradic.SlikaGrada=slikaGrada;

                    await Context.SaveChangesAsync();
                    return Ok("Grad uspesno izmenenjen");
                 }

                 else
                 {
                    return BadRequest("Grad ne postoji");
                 }

            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
*/
    }

    
}


