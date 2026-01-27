using Microsoft.EntityFrameworkCore;
using SGVendas.Application.Interfaces;
using SGVendas.Application.Services;
using SGVendas.Infra.Repositories;
using SGVendas.Infra.Context;

namespace SGVendas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Repositórios
            builder.Services.AddScoped<IClienteCadastroRepository, ClienteCadastroRepository>();
            builder.Services.AddScoped<IVendaCommandRepository, VendaCommandRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();
            builder.Services.AddScoped<IVendaRepository, VendaRepository>();          
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();
            
           
           
            





            // Configuração do DbContext
            builder.Services.AddDbContext<SGVendasDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );
            // Registro dos serviços da aplicação
            builder.Services.AddScoped<IVendaService, VendaService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
