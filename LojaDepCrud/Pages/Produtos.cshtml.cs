using LojaDepCrud.Controllers;
using LojaDepCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace LojaDepCrud.Pages
{
    public class ProdutosModel : PageModel
    {
        public List<Produtos> produtos = new();


        public void OnGet()
        {
            ProdutoController controller = new();


            produtos = controller.Listar();
        }
    }
}
