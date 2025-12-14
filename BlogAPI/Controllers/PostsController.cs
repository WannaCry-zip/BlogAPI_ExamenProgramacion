using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly BlogService _blogService;

        public PostsController(BlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/posts
        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            return Ok(_blogService.ObtenerTodos());
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        public ActionResult<Post> GetById(int id)
        {
            var post = _blogService.ObtenerPorId(id);
            if (post == null)
            {
                return NotFound(new { mensaje = "Post no encontrado" });
            }
            return Ok(post);
        }

        // POST: api/posts
        [HttpPost]
        public ActionResult<Post> Create([FromBody] Post post)
        {
            if (string.IsNullOrWhiteSpace(post.Titulo) || string.IsNullOrWhiteSpace(post.Contenido))
            {
                return BadRequest(new { mensaje = "Título y contenido son requeridos" });
            }

            var nuevoPost = _blogService.Crear(post);
            return CreatedAtAction(nameof(GetById), new { id = nuevoPost.Id }, nuevoPost);
        }

        // PUT: api/posts/5
        [HttpPut("{id}")]
        public ActionResult<Post> Update(int id, [FromBody] Post post)
        {
            if (string.IsNullOrWhiteSpace(post.Titulo) || string.IsNullOrWhiteSpace(post.Contenido))
            {
                return BadRequest(new { mensaje = "Título y contenido son requeridos" });
            }

            var postActualizado = _blogService.Actualizar(id, post);
            if (postActualizado == null)
            {
                return NotFound(new { mensaje = "Post no encontrado" });
            }

            return Ok(postActualizado);
        }

        // DELETE: api/posts/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eliminado = _blogService.Eliminar(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = "Post no encontrado" });
            }

            return Ok(new { mensaje = "Post eliminado correctamente" });
        }

        // POST: api/posts/5/comentarios
        [HttpPost("{id}/comentarios")]
        public ActionResult<Comentario> AddComment(int id, [FromBody] Comentario comentario)
        {
            if (string.IsNullOrWhiteSpace(comentario.Autor) || string.IsNullOrWhiteSpace(comentario.Contenido))
            {
                return BadRequest(new { mensaje = "Autor y contenido son requeridos" });
            }

            var nuevoComentario = _blogService.AgregarComentario(id, comentario);
            if (nuevoComentario == null)
            {
                return NotFound(new { mensaje = "Post no encontrado" });
            }

            return Ok(nuevoComentario);
        }
    }
}