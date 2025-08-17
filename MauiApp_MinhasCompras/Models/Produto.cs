// Importa a biblioteca SQLite, usada para mapear esta classe como uma tabela do banco
using SQLite;

namespace MauiApp_MinhasCompras.Models

{
    // Classe que representa a entidade Produto (será uma tabela no banco SQLite)
    public class Produto
        // Propriedade Id será a chave primária da tabela
        // AutoIncrement garante que cada novo produto receba um Id único automaticamente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Nome ou descrição do produto, em texto;caracteres 
        public string Descricao { get; set; }

        // Quantidade do produto, em ponto flutuante
        public double Quantidade { get; set; }

        // Preço unitário do produto, em ponto flutuante
        public double Preco { get; set; }
    }
}
