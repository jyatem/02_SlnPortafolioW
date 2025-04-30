namespace _02_Portafolio.Servicios
{
    public class ServicioEmailGmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailGmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


    }
}
