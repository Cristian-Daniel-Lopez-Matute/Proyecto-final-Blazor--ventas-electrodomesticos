using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalProgramacion.Interfaces;

namespace ProyectoFinalProgramacion.Pages.Facturas;

partial class Facturas
{

    [Inject] private IFacturaServicio _facturaServicio { get; set; }

    private IEnumerable<Factura> facturaLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        facturaLista = (IEnumerable<Factura>)await _facturaServicio.GetLista();
    }

}
