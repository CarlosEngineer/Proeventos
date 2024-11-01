using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Proeventos.APi.Data;
using Proeventos.APi.Models;

namespace Proeventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        
        public readonly DataContext _context;
        
        public EventoController(DataContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }


        [HttpGet("{id}")]
        public Evento Get(int id )
        {
            
            return _context.Eventos.FirstOrDefault(c => c.EventoId == id);

        }

        [HttpPost]
        public string Inserir()
        {
            return "Iserido";
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var evento = _context.Eventos.FirstOrDefault(f => f.EventoId == (id));

            if (evento == null){

                return NotFound($"O Id não foi encontrado {id}.");
            }

            _context.Eventos.Remove(evento);
            _context.SaveChanges();


            return Ok($"Evento com ID {id} foi removido com sucesso!");
        }

        [HttpPut("{id}")]
        public string Alterar(int id )
        {
            return $"Alterando pelo ID {id}";
        }
    }   
}

