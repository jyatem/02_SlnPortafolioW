using _02_Portafolio.Models;

namespace _02_Portafolio.Servicios
{
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            #region Agregando elementos a una lista con el método Add
            //var listadoProyecto = new List<Proyecto>();

            //listadoProyecto.Add(new Proyecto()
            //{
            //    Titulo = "Amazon",
            //    Descripcion = "E-Commerce realizado en ASP.NET Core",
            //    Link = "https://amazon.com",
            //    ImageURL = ""
            //}); 
            #endregion

            var listadoProyecto = new List<Proyecto>()
            {
                new Proyecto()
                {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.NET Core",
                    Link = "https://amazon.com",
                    ImageURL = "/imagenes/amazon.png"
                },
                new Proyecto()
                {
                    Titulo = "New York Times",
                    Descripcion = "Página de noticias en React",
                    Link = "https://nytimes.com",
                    ImageURL = "/imagenes/nyt.png"
                },
                new Proyecto()
                {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    Link = "https://reddit.com",
                    ImageURL = "/imagenes/reddit.png"
                },
                new Proyecto()
                {
                    Titulo = "Steam",
                    Descripcion = "Tienda en línea para comprar videojuegos",
                    Link = "https://store.steampowered.com",
                    ImageURL = "/imagenes/steam.png"
                },
            };

            return listadoProyecto;
        }
    }
}
