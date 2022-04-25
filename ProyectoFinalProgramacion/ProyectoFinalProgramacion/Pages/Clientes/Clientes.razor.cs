using Microsoft.AspNetCore.Components;
using Modelos;
using ProyectoFinalProgramacion.Interfaces;


namespace ProyectoFinalProgramacion.Pages.Clientes
{
    partial class Clientes
    {
        [Inject] private IClienteServicio _clienteServicio { get; set; }

        private IEnumerable<Cliente> clientesLista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            clientesLista = (IEnumerable<Cliente>)await _clienteServicio.GetLista();
        }

    }
}
