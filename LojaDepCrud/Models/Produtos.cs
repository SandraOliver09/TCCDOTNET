namespace LojaDepCrud.Models
{
   public class Produtos
   {
       public int Id { get; set; }


       public string Nome { get; set; } = "";


       public string Categoria { get; set; } = "";


       public string Tamanho { get; set; } = "";

       public double Preco { get; set; } 


       public int Estoque { get; set; }
   }
}
