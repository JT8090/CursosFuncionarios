using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursosFuncionarios.Data;
using CursosFuncionarios.Models;

namespace CursosFuncionarios.Controllers
{
    public class CursoAplicacaoController : Controller
    {
        private readonly AppDbContext _context;

        public CursoAplicacaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CursoAplicacao
        public async Task<IActionResult> Index()
        {
            var cursos = await _context.CursoAplicacao.Include("Curso").ToListAsync();

            return View(cursos);
        }

        // GET: CursoAplicacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CursoAplicacao == null)
            {
                return NotFound();
            }

            var cursoAplicacao = await _context.CursoAplicacao.FirstOrDefaultAsync(m => m.Id == id);
            if (cursoAplicacao == null)
            {
                return NotFound();
            }

            cursoAplicacao.Curso = _context.Curso.FirstOrDefault(m => m.Id == cursoAplicacao.IdCurso);

            return View(cursoAplicacao);
        }

        // GET: CursoAplicacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CursoAplicacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCurso,DtInicio,DtFim,Estado,Tipo")] CursoAplicacao cursoAplicacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoAplicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoAplicacao);
        }

        // GET: CursoAplicacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CursoAplicacao == null)
            {
                return NotFound();
            }

            var cursoAplicacao = await _context.CursoAplicacao.FindAsync(id);
            if (cursoAplicacao == null)
            {
                return NotFound();
            }
            cursoAplicacao.Curso = _context.Curso.FirstOrDefault(m => m.Id == cursoAplicacao.IdCurso);
            return View(cursoAplicacao);
        }

        // POST: CursoAplicacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCurso,DtInicio,DtFim,Estado,Tipo")] CursoAplicacao cursoAplicacao)
        {
            if (id != cursoAplicacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoAplicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoAplicacaoExists(cursoAplicacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cursoAplicacao);
        }

        // GET: CursoAplicacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CursoAplicacao == null)
            {
                return NotFound();
            }

            var cursoAplicacao = await _context.CursoAplicacao.FirstOrDefaultAsync(m => m.Id == id);
            if (cursoAplicacao == null)
            {
                return NotFound();
            }
            cursoAplicacao.Curso = _context.Curso.FirstOrDefault(m => m.Id == cursoAplicacao.IdCurso);

            return View(cursoAplicacao);
        }

        // POST: CursoAplicacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CursoAplicacao == null)
            {
                return Problem("Entity set 'AppDbContext.CursoAplicacao'  is null.");
            }
            var cursoAplicacao = await _context.CursoAplicacao.FindAsync(id);
            if (cursoAplicacao != null)
            {
                _context.CursoAplicacao.Remove(cursoAplicacao);
            }
            cursoAplicacao.Curso = _context.Curso.FirstOrDefault(m => m.Id == cursoAplicacao.IdCurso);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoAplicacaoExists(int id)
        {
          return _context.CursoAplicacao.Any(e => e.Id == id);
        }
    }
}
