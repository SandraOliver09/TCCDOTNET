using LojaDepCrud.Controllers;
using LojaDepCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LojaDepCrud.Pages
{
    public class CadastrarProdutosModel : PageModel
    {
        [BindProperty]
        public Produtos Produtos { get; set; } = new();


        public IActionResult OnPost()
        {
            ProdutoController controller = new();
            controller.Inserir(Produtos);
            return RedirectToPage("Produtos");
        }
    }
}
