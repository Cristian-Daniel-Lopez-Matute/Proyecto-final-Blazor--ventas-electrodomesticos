using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalProgramacion.Interfaces;

namespace ProyectoFinalProgramacion.Pages.Clientes;

partial class NuevoCliente
{
    [Inject] private IClienteServicio clienteServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }

    private Cliente customer = new Cliente();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(customer.IdCliente) || string.IsNullOrEmpty(customer.Nombres))
        {
            return;
        }

        bool inserto = await clienteServicio.Nuevo(customer);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Cliente creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Cliente no se pudo crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Clientes");

    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Clientes");
    }


}
