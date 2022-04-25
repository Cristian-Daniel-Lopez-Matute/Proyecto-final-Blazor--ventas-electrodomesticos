using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalProgramacion.Interfaces;

namespace ProyectoFinalProgramacion.Pages.Productos;

partial class NuevoProducto
{
    [Inject] private IProductoServicio productoServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Producto product = new Producto();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(product.Codigo) || string.IsNullOrEmpty(product.Descripcion))
        {
            return;
        }

        bool inserto = await productoServicio.Nuevo(product);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Producto creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Producto no se pudo crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Productos");

    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Productos");
    }

}
