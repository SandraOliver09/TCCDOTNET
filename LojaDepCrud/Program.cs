var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço do Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Configuração de erros
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapeia as páginas Razor
app.MapRazorPages();

// Inicia a aplicação
app.Run();