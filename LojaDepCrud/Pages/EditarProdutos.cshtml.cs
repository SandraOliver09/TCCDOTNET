using LojaDepCrud.Controllers;
using LojaDepCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LojaDepCrud.Pages
{
    public class EditarProdutosModel : PageModel
    {
        [BindProperty]
        public Produtos produtos { get; set; } = new();
        public void OnGet(int id)
        {
            ProdutoController controller = new();
            produtos = controller.BuscarPorId(id);
        }


        public IActionResult OnPost()
        {
            ProdutoController controller = new();
            controller.Atualizar(produtos);
            return RedirectToPage("produtos");
        }
    }
}


