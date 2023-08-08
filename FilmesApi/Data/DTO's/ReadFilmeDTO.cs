using System.Collections;
using System.ComponentModel.DataAnnotations;
using FilmesApi.Data.DTO_s;

namespace FilmesApi.Data.Dtos
{
    public class ReadFilmeDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public ICollection<ReadSessaoDTO> Sessoes { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
