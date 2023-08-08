using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTO_s
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Nome { get; set; }
    }
}
