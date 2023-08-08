﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome do filme é obrigatório.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Gênero do filme é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O tamanho do titulo não pode exercer 50 caracteres.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "Nome do filme é obrigatório.")]
    [Range(70,600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")]
    public int Duracao { get; set; }
    public virtual ICollection<Sessao> Sessoes { get; set; }
}
