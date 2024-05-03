using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMundo.Models;
using MiniMundo.Data;
using System.Threading.Tasks;

namespace MiniMundo.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Salvar()
        {
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Salvar([Bind("ProdutoId, NomeDoProduto, Preco")] Produto Produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListarProdutos));
            }
            return View(Produto);
        }

        public async Task<IActionResult> ListarProdutos()
        {
            var Produtos = await _context.Produto.ToListAsync();
            return View(Produtos);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Produto = await _context.Produto.FindAsync(id);
            if (Produto == null)
            {
                return NotFound();
            }
            return View(Produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ProdutoId, NomeDoProduto, Preco")] Produto Produto)
        {
            if (id != Produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != Produto.ProdutoId)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListarProdutos));
            }
            return View(Produto);
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Produto = await _context.Produto.FindAsync(id);
            if (Produto == null)
            {
                return NotFound();
            }
            return View(Produto);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var Produto = await _context.Produto.FindAsync(id);
            if (Produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(Produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListarProdutos));
        }

    }
}
