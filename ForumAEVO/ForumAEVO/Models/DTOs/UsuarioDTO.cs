﻿namespace ForumAEVO.Models.DTOs
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Foto { get; set; }= string.Empty;
    }
}
