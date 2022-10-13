using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaHumanBrands.MOD;
using PruebaHumanBrands.MOD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHumanBrands.BLL
{
    public class PersonaRoutingBLL
    {
        private readonly ApplicationDbContext context;

        public PersonaRoutingBLL(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await context.Personas.ToListAsync();
        }

        public async Task<Persona> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return persona;
        }

        public async Task<Persona> Put(Persona persona, int id)
        {
            if (persona.Id != id)
            {
                throw new Exception("Id no coincide");
            }

            var exist = await context.Personas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                throw new Exception("Id no existe");
            }

            context.Update(persona);
            await context.SaveChangesAsync();
            return persona;
        }

        public async Task<int> State(int id)
        {
            var exist = await context.Personas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                throw new Exception("Id no existe");
            }
            var exist_persona = await context.Personas.FindAsync(id);
            if (exist_persona.EstadoPersona == 0)
            {
                exist_persona.EstadoPersona = 1;
            }
            else
            {
                exist_persona.EstadoPersona = 0;
            }

            context.Update(exist_persona);
            await context.SaveChangesAsync();
            return id;
        }

    }
}
