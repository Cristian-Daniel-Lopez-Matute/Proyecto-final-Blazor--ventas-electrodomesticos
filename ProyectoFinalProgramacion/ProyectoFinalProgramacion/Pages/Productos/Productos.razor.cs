using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalProgramacion.Interfaces;

namespace ProyectoFinalProgramacion.Pages.Productos;

partial class Productos
{
    [Inject] private IProductoServicio _usuarioServicio { get; set; }

    private IEnumerable<Producto> productosLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        productosLista = await _usuarioServicio.GetLista();
    }
}
