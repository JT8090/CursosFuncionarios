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
    public class FuncionarioCursoController : Controller
    {
        private readonly AppDbContext _context;

        public FuncionarioCursoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FuncionarioCurso
        public async Task<IActionResult> Index()
        {
            var reg = await _context.FuncionarioCurso.Include("CursoAplicacao").Include("Funcionario").ToListAsync();

            foreach(var ca in reg)
            {
                ca.CursoAplicacao.Curso = _context.Curso.Where(c => c.Id == ca.CursoAplicacao.IdCurso).FirstOrDefault();
            }

            return View(reg);
        }

        // GET: FuncionarioCurso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FuncionarioCurso == null)
            {
                return NotFound();
            }

            var funcionarioCurso = GetFuncionarioCurso((int) id);

            if (funcionarioCurso == null)
            {
                return NotFound();
            }

            return View(funcionarioCurso);
        }

        // GET: FuncionarioCurso/Create
        public IActionResult Create()
        {
            ViewBag.Funcionarios = new SelectList(_context.Funcionario.OrderBy(s => s.Nome), "IdFuncionario", "Nome").ToList();

            var ca = _context.CursoAplicacao.Include("Curso")
                .Select(t => new {Id = t.Id, Nome = $"{t.Curso.Nome} - {t.DtInicio:dd/MM/yyyy}" }).OrderBy(t => t.Nome).ToList();
            ViewBag.CursosAplicacao = new SelectList(ca, "Id", "Nome");
            return View();
        }

        // POST: FuncionarioCurso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdFuncionario,IdCursoAplicacao,Observacao,Nota,Andamento")] FuncionarioCurso funcionarioCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionarioCurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionarioCurso);
        }

        // GET: FuncionarioCurso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FuncionarioCurso == null)
            {
                return NotFound();
            }

            var funcionarioCurso = GetFuncionarioCurso((int)id);

            if (funcionarioCurso == null)
            {
                return NotFound();
            }
            return View(funcionarioCurso);
        }

        // POST: FuncionarioCurso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdFuncionario,IdCursoAplicacao,Observacao,Nota,Andamento")] FuncionarioCurso funcionarioCurso)
        {
            if (id != funcionarioCurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionarioCurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioCursoExists(funcionarioCurso.Id))
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
            return View(funcionarioCurso);
        }

        // GET: FuncionarioCurso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FuncionarioCurso == null)
            {
                return NotFound();
            }

            var funcionarioCurso = GetFuncionarioCurso((int)id);
            if (funcionarioCurso == null)
            {
                return NotFound();
            }

            return View(funcionarioCurso);
        }

        // POST: FuncionarioCurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FuncionarioCurso == null)
            {
                return Problem("Entity set 'AppDbContext.FuncionarioCurso'  is null.");
            }
            var funcionarioCurso = GetFuncionarioCurso((int)id);
            if (funcionarioCurso != null)
            {
                _context.FuncionarioCurso.Remove(funcionarioCurso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private FuncionarioCurso GetFuncionarioCurso (int id)
        {
            var funcionarioCurso = _context.FuncionarioCurso.FirstOrDefault(m => m.Id == id);

            if (funcionarioCurso == null)
            {
                return funcionarioCurso;
            }

            funcionarioCurso.Funcionario = _context.Funcionario?.Where(f => f.Id == funcionarioCurso.IdFuncionario).FirstOrDefault();
            funcionarioCurso.CursoAplicacao = _context.CursoAplicacao?.Where(c => c.Id == funcionarioCurso.IdCursoAplicacao).FirstOrDefault();
            funcionarioCurso.CursoAplicacao.Curso = _context.Curso?.Where(c => c.Id == funcionarioCurso.CursoAplicacao.IdCurso).FirstOrDefault();

            return funcionarioCurso;
        }

        private bool FuncionarioCursoExists(int id)
        {
          return _context.FuncionarioCurso.Any(e => e.Id == id);
        }
    }
}
