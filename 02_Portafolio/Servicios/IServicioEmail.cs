using _02_Portafolio.Models;

namespace _02_Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contactoViewModel);
    }
}