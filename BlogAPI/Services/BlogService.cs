using BlogAPI.Models;
using System.Text.Json;

namespace BlogAPI.Services
{
    public class BlogService
    {
        private readonly string _jsonFilePath = "Data/posts.json";
        private List<Post> _posts;

        public BlogService()
        {
            CargarPosts();
        }

        private void CargarPosts()
        {
            if (File.Exists(_jsonFilePath))
            {
                var jsonData = File.ReadAllText(_jsonFilePath);
                _posts = JsonSerializer.Deserialize<List<Post>>(jsonData) ?? new List<Post>();
            }
            else
            {
                // Datos iniciales
                _posts = new List<Post>
                {
                    new Post
                    {
                        Id = 1,
                        Titulo = "Mi primer post en el blog",
                        Contenido = "Bienvenidos a mi blog personal. Aquí compartiré mis experiencias en programación y tecnología.",
                        Autor = "Admin",
                        FechaCreacion = DateTime.Now.AddDays(-5),
                        Imagen = "https://via.placeholder.com/800x400?text=Primer+Post",
                        Comentarios = new List<Comentario>
                        {
                            new Comentario { Id = 1, Autor = "Juan", Contenido = "Excelente inicio!", Fecha = DateTime.Now.AddDays(-4) },
                            new Comentario { Id = 2, Autor = "Maria", Contenido = "Espero más contenido pronto", Fecha = DateTime.Now.AddDays(-3) }
                        }
                    },
                    new Post
                    {
                        Id = 2,
                        Titulo = "Aprendiendo ASP.NET Core",
                        Contenido = "ASP.NET Core es un framework potente para crear APIs modernas y escalables.",
                        Autor = "Admin",
                        FechaCreacion = DateTime.Now.AddDays(-3),
                        Imagen = "https://via.placeholder.com/800x400?text=ASP.NET+Core",
                        Comentarios = new List<Comentario>()
                    }
                };
                GuardarPosts();
            }
        }

        private void GuardarPosts()
        {
            var directory = Path.GetDirectoryName(_jsonFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory!);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonData = JsonSerializer.Serialize(_posts, options);
            File.WriteAllText(_jsonFilePath, jsonData);
        }

        public List<Post> ObtenerTodos()
        {
            return _posts;
        }

        public Post? ObtenerPorId(int id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public Post Crear(Post post)
        {
            post.Id = _posts.Any() ? _posts.Max(p => p.Id) + 1 : 1;
            post.FechaCreacion = DateTime.Now;
            post.Comentarios = new List<Comentario>();
            _posts.Add(post);
            GuardarPosts();
            return post;
        }

        public Post? Actualizar(int id, Post postActualizado)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return null;

            post.Titulo = postActualizado.Titulo;
            post.Contenido = postActualizado.Contenido;
            post.Autor = postActualizado.Autor;
            post.Imagen = postActualizado.Imagen;

            GuardarPosts();
            return post;
        }

        public bool Eliminar(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return false;

            _posts.Remove(post);
            GuardarPosts();
            return true;
        }

        public Comentario? AgregarComentario(int postId, Comentario comentario)
        {
            var post = _posts.FirstOrDefault(p => p.Id == postId);
            if (post == null) return null;

            comentario.Id = post.Comentarios.Any() ? post.Comentarios.Max(c => c.Id) + 1 : 1;
            comentario.Fecha = DateTime.Now;
            post.Comentarios.Add(comentario);

            GuardarPosts();
            return comentario;
        }
    }
}
