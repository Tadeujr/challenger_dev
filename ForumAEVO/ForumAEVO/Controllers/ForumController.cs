﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForumAEVO.Models;
using ForumAEVO.Models.DTOs;

namespace ForumAEVO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly Context _context;

        public ForumController(Context context)
        {
            _context = context;
        }

        // GET: api/forum
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicoDto>>> GetTopicos()
        {
            var topicos = await _context.Topicos
                .Include(t => t.Usuario)
                .Include(t => t.Comentarios)
                .ToListAsync();

            //Buscando os topicos do Forum e exibindo de maneira organizada na API
            var topicosDto = topicos.Select(t => new TopicoDto
            {
                UserId = t.UserId,
                Comentarios = t.Comentarios.Select(c => new ComentarioDto
                {
                    UserId = c.UserId,
                    Id = c.Id,
                    Msg = c.Msg,
                    TopicoId = c.TopicoId,
                    Data = t.Data.ToString("dd-MM-yyyy")
                }).ToList(),
                Id = t.Id,
                Msg = t.Msg,
                Data = t.Data.ToString("dd-MM-yyyy") 
            }).ToList();

            return Ok(topicosDto);
        }
    }

}
