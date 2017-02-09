using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Routing;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(IntegracaoNFSe.Startup))]

namespace IntegracaoNFSe
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();            

//            var cors = new EnableCorsAttribute("http://127.0.0.1:52922", "*", "*");
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            ManipularRequisicaoHttp(config);

            app.UseWebApi(config);
        }

        private void ManipularRequisicaoHttp(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }        
    }
}
