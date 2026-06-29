using LojaDepCrud.Controllers;
using LojaDepCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LojaDepCrud.Pages
{
    public class ExcluirProdutosModel : PageModel
    {
        [BindProperty]
        public Produtos Produtos { get; set; } = new();
        public void OnGet(int id)
        {
            ProdutoController controller = new();
            Produtos = controller.BuscarPorId(id);
        }


        public IActionResult OnPost()
        {
            ProdutoController controller = new();
            controller.Excluir(Produtos.Id);
            return RedirectToPage("Produtos");
        }
    }
}
