using CursosFuncionarios.Data;
using CursosFuncionarios.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

public static class InicializaDb
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<AppDbContext>>()))
        {
            // Cursos.
            if (!context.Curso.Any())
            {
                context.Curso.AddRange(
                    new Curso
                    {
                        Nome = "Asp.Net Core",
                        Descricao = "Curso de desenvolvimeno em Asp.Net Core usando C#",
                        QtdHora = 40
                    },
                    new Curso
                    {
                        Nome = "PHP",
                        Descricao = "Curso básico de PHP",
                        QtdHora = 30
                    },
                    new Curso
                    {
                        Nome = "Trello",
                        Descricao = "Curso de uso da fermant Trello para acompanhamento de projetos",
                        QtdHora = 10
                    });
            }
            // Funcionarios.
            if (!context.Funcionario.Any())
            {
                context.Funcionario.AddRange(
                    new Funcionario
                    {
                        Nome = "João",
                        Email = "joao@CursosFuncionarios.com.br",
                    },
                    new Funcionario
                    {
                        Nome = "Maria",
                        Email = "maria@CursosFuncionarios.com.br",
                    }
                );
            }
            context.SaveChanges();

            int idCurso = context.Curso.OrderBy(d => d.Id).First().Id;
            int idFuncionario = context.Funcionario.OrderBy(d => d.Id).First().Id;
            int idFuncionario2 = context.Funcionario.OrderByDescending(d => d.Id).First().Id;

            // Curso Aplicacao.
            if (!context.CursoAplicacao.Any())
            {
                return;   // Já inicializado
            }
            context.CursoAplicacao.AddRange(
                new CursoAplicacao
                {
                    IdCurso = idCurso,
                    DtInicio = DateTime.Today.AddDays(-20),
                    DtFim = DateTime.Today.AddDays(10),
                },
                new CursoAplicacao
                {
                    IdCurso = idCurso,
                    DtInicio = DateTime.Today.AddDays(10),
                    DtFim = DateTime.Today.AddDays(40),
                }
            );

            context.SaveChanges();

            int idCursoAplicacao = context.CursoAplicacao.Where(c => c.IdCurso == idCurso).OrderBy(d => d.Id).First().Id;

            // Funcionario Curso.
            if (context.FuncionarioCurso.Any())
            {
                context.FuncionarioCurso.AddRange(
                    new FuncionarioCurso
                    {
                        IdFuncionario = idFuncionario,
                        IdCursoAplicacao = idCursoAplicacao,
                        Andamento = AndamentoCurso.Inscrito,
                        Observacao = "Incluído na inicialização"
                    },
                    new FuncionarioCurso
                    {
                        IdFuncionario = idFuncionario2,
                        IdCursoAplicacao = idCursoAplicacao,
                        Andamento = AndamentoCurso.Inscrito,
                        Observacao = "Incluído na inicialização"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

