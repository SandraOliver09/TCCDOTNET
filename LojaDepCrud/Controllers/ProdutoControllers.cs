using LojaDepCrud.Models;
using MySql.Data.MySqlClient;

namespace LojaDepCrud.Controllers
{
    public class ProdutoController
    {
        private readonly string conexao = "server=localhost;database=lojadepcrud;uid=root;pwd=;";


        public List<Produtos> Listar()
        {
            List<Produtos> lista = new();


            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql = "SELECT * FROM produtos";


                MySqlCommand cmd = new(sql, conn);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Produtos
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString()!,
                            Categoria = reader["categoria"].ToString()!,
                            Tamanho = reader["tamanho"].ToString()!,
                            Preco = Convert.ToInt32(reader["preco"]),
                            Estoque = Convert.ToInt32(reader["estoque"])
                        });
                    }
                }
            }


            return lista;
        }


        public void Inserir(Produtos produto)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql =
                    @"INSERT INTO produtos
                    (nome, categoria, tamanho, preco,estoque)
                    VALUES
                    (@nome,@categoria,@tamanho,@preco,@estoque)";


                MySqlCommand cmd = new(sql, conn);


                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@tamanho", produto.Tamanho);
                cmd.Parameters.AddWithValue("@preco", produto.Preco);
                cmd.Parameters.AddWithValue("@estoque", produto.Estoque);



                cmd.ExecuteNonQuery();
            }
        }


        public Produtos BuscarPorId(int id)
        {
            Produtos produtos = new();


            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql =
                    "SELECT * FROM produtos WHERE id=@id";


                MySqlCommand cmd = new(sql, conn);


                cmd.Parameters.AddWithValue("@id", id);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       produtos.Id = Convert.ToInt32(reader["id"]);
                       produtos.Nome = reader["nome"].ToString()!;
                       produtos.Categoria = reader["categoria"].ToString()!;
                       produtos.Tamanho = reader["tamanho"].ToString()!;
                       produtos.Preco = Convert.ToInt32(reader["preco"]);
                       produtos.Estoque = Convert.ToInt32(reader["estoque"]);
                    }
                }
            }


            return produtos;
        }


        public void Atualizar(Produtos produtos)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql =
                    @"UPDATE produtos
                    SET nome=@nome,
                        categoria=@categoria,
                        tamanho=@tamanho,
                        preco=@preco,
                        estoque=@estoque
                    WHERE id=@id";


                MySqlCommand cmd = new(sql, conn);


                cmd.Parameters.AddWithValue("@id", produtos.Id);
                cmd.Parameters.AddWithValue("@nome", produtos.Nome);
                cmd.Parameters.AddWithValue("@categoria", produtos.Categoria);
                cmd.Parameters.AddWithValue("@tamanho", produtos.Tamanho);
                cmd.Parameters.AddWithValue("@preco", produtos.Preco);
                cmd.Parameters.AddWithValue("@estoque", produtos.Estoque);


                cmd.ExecuteNonQuery();
            }
        }


        public void Excluir(int id)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();


                string sql =
                    "DELETE FROM produtos WHERE id=@id";


                MySqlCommand cmd = new(sql, conn);


                cmd.Parameters.AddWithValue("@id", id);


                cmd.ExecuteNonQuery();
            }
        }
    }
}
