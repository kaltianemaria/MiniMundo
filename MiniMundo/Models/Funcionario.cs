using System.ComponentModel.DataAnnotations;

namespace MiniMundo.Models;

public class Funcionario
{
    public int Id { get; set; }

    public required string TipoCadastro { get; set; }

    public required string Nome { get; set; }

    public required string Matricula { get; set; }

    public required string Email { get; set; }
}
