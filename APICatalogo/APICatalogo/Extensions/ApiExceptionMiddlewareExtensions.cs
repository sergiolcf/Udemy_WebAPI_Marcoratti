using APICatalogo.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

namespace APICatalogo.Extensions
{
    public static class ApiExceptionMiddlewareExtensions
    {
        //UseExceptionHandler, o delegate esperado é uma função que aceita um objeto HttpContext como parâmetro e retorna uma Task. Essa função será chamada para lidar com a exceção não tratada.
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            //Configurando Middleware de Tratamento de Excções
            app.UseExceptionHandler(appError =>
            {
                //Recebendo um Delegate que será executado quando uma exceção não tratada ocorrer durante o processamento
                appError.Run(async context =>
                {
                    //Dentro do delegate especifica o que fazer quando receber uma exceção não tratada
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //Definimos o status HTTP
                    context.Response.ContentType = "application/json"; //Definismo o tipo de conteúdo da resposta, em formato JSON

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); //Obtemos o Feature (objeto) do manipulador do contexto para acessar informações da exceção que ocorreu

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            //escrevemos o detalhe da exceção no formato JSON
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        }.ToString());
                    }

                });
            });
        }
    }
}
