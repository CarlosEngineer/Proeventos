using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proeventos.APi.Models;

namespace Proeventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]{

            new Evento(){
                EventoId = 1,
                Tema = "Angular",
                Local = "Sao Paulo",
                Lote = "primeiro lote",
                 QtdPessoas = 100,
                DataEvento = DateTime.Now.AddDays(2).ToString()

                },
            new Evento(){
                EventoId = 2,
                Tema = "Dotnet",
                 Local = "Sao Paulo",
                Lote = "segundo lote",
                 QtdPessoas = 200,
                DataEvento = DateTime.Now.AddDays(2).ToString()
                }
                
            };
        
        
        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id )
        {
            var evento = _evento.Where(c => c.EventoId == id).ToList();

            if(!evento.Any() || id < 0)
            {
                throw new Exception($"Numero não encontrado {id}.");
            }

            return _evento.Where(c => c.EventoId.Equals(id));
        }

        [HttpPost]
        public string Inserir()
        {
            return "Iserido";
        }

        [HttpDelete("{id}")]
        public string Apagar(int id)
        {
            return $"Deletando o id {id}";
        }

        [HttpPut("{id}")]
        public string Alterar(int id )
        {
            return $"Alterando pelo ID {id}";
        }
    }   
}

