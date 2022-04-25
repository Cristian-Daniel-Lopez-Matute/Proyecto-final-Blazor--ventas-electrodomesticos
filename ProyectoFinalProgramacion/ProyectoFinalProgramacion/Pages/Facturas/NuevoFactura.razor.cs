using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalProgramacion.Interfaces;

namespace ProyectoFinalProgramacion.Pages.Facturas;

partial class NuevoFactura
{
    [Inject] private IFacturaServicio facturaServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Factura fact = new Factura();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(fact.Codigo) || string.IsNullOrEmpty(fact.Descripcion))
        {
            return;
        }

        bool inserto = await facturaServicio.Nuevo(fact);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Factura creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Factura no se pudo crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Facturas");

    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Facturas");
    }


}
