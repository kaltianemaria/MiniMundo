using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMundo.Models;
using MiniMundo.Data;
using System.Threading.Tasks;

namespace MiniMundo.Controllers
{
    public class VendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendaController(ApplicationDbContext context)
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
        public async Task<IActionResult> Salvar([Bind("VendaId, ProdutoId, ClienteId, NomeDoFuncionario, Preco, DataDaVenda")] Venda Venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListarVendas));
            }
            return View(Venda);
        }

        public async Task<IActionResult> ListarVendas()
        {
            var Vendas = await _context.Venda.ToListAsync();
            return View(Vendas);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Venda = await _context.Venda.FindAsync(id);
            if (Venda == null)
            {
                return NotFound();
            }
            return View(Venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("VendaId, ProdutoId, ClienteId, NomeDoFuncionario, Preco, DataDaVenda")] Venda Venda)
        {
            if (id != Venda.VendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != Venda.VendaId)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListarVendas));
            }
            return View(Venda);
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Venda = await _context.Venda.FindAsync(id);
            if (Venda == null)
            {
                return NotFound();
            }
            return View(Venda);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var Venda = await _context.Venda.FindAsync(id);
            if (Venda == null)
            {
                return NotFound();
            }

            _context.Venda.Remove(Venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListarVendas));
        }

    }
}
