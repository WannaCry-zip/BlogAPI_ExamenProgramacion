namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }

    public class Comentario
    {
        public int Id { get; set; }
        public string Autor { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}
