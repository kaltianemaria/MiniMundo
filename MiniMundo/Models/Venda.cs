namespace MiniMundo.Models;

public class Venda
{
    public int VendaId { get; set; }
    public int ProdutoId { get; set; }
    public int ClienteId { get; set; }
    public required string NomeDoFuncionario { get; set; }
    public required string Preco { get; set; }
    public required string DataDaVenda { get; set; }

}
