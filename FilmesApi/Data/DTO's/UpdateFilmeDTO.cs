using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTO_s;

public class CreateFilmeDTO
{

    [Required(ErrorMessage = "Nome do filme é obrigatório.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Gênero do filme é obrigatório.")]
    [StringLength(50, ErrorMessage = "O tamanho do titulo não pode exercer 50 caracteres.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "Nome do filme é obrigatório.")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")]
    public int Duracao { get; set; }
}
