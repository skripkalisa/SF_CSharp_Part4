// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using CSBlog.Data;
// using CSBlog.Models.Blog;
//
// namespace CSBlog.Controllers.api
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ArticlesController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;
//
//         public ArticlesController(ApplicationDbContext context)
//         {
//             _context = context;
//         }
//
//         // GET: api/Articles
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
//         {
//             return await _context.Articles.ToListAsync();
//         }
//
//         // GET: api/Articles/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Article>> GetArticle(string id)
//         {
//             var article = await _context.Articles.FindAsync(id);
//
//             if (article == null)
//             {
//                 return NotFound();
//             }
//
//             return article;
//         }
//
//         // PUT: api/Articles/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutArticle(string id, Article article)
//         {
//             if (id != article.Id)
//             {
//                 return BadRequest();
//             }
//
//             _context.Entry(article).State = EntityState.Modified;
//
//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!ArticleExists(id))
//                 {
//                     return NotFound();
//                 }
//
//                 throw;
//             }
//
//             return NoContent();
//         }
//
//         // POST: api/Articles
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<Article>> PostArticle(Article article)
//         {
//             _context.Articles.Add(article);
//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateException)
//             {
//                 if (article.Id != null && ArticleExists(article.Id))
//                 {
//                     return Conflict();
//                 }
//
//                 throw;
//             }
//
//             return CreatedAtAction("GetArticle", new { id = article.Id }, article);
//         }
//
//         // DELETE: api/Articles/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteArticle(string id)
//         {
//             var article = await _context.Articles.FindAsync(id);
//             if (article == null)
//             {
//                 return NotFound();
//             }
//
//             _context.Articles.Remove(article);
//             await _context.SaveChangesAsync();
//
//             return NoContent();
//         }
//
//         private bool ArticleExists(string id)
//         {
//             return _context.Articles.Any(e => e.Id == id);
//         }
//     }
// }

