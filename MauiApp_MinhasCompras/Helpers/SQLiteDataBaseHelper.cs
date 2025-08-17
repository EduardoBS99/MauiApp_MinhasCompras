
// Importa a pasta "Models" do projeto, onde está definida a classe Produto
using MauiApp_MinhasCompras.Models;

// Importa a biblioteca SQLite, usada para persistência de dados no banco local
using SQLite;

namespace MauiApp_MinhasCompras.Helpers
{
    // Classe responsável por gerenciar o banco de dados SQLite
    public class SQLiteDataBaseHelper
    {
        // Cria a conexão assíncrona com o banco de dados
        readonly SQLiteAsyncConnection _conn;

        // Construtor da classe: recebe o caminho do banco e garante a criação da tabela Produto
        public SQLiteDataBaseHelper(string path) 
        { 
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync <Produto>().Wait();
        }

        // Insere um novo produto no banco (operação CREATE do CRUD)
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        
        }

        // Atualiza um produto existente no banco (operação UPDATE do CRUD)
        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto Set Descricao=?, Quantidade=?, Preco=?, WHERE Id=?";
            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        // Remove um produto pelo Id (operação DELETE do CRUD)
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Retorna todos os produtos cadastrados (operação READ do CRUD)
        public Task<List<Produto>> GetAll ()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        // Busca produtos pelo texto da descrição (filtragem no banco)
        public Task<List<Produto>> Search (string q)
        {
            string sql = "SELECT * Produto WHERE Descricao LIKE '%" + q + "%'" ;
            return _conn.QueryAsync<Produto>(sql);


        }
    }
}
