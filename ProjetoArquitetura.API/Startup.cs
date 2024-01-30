//using Autofac;
//using Autofac.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.ResponseCompression;
//using Microsoft.Extensions.PlatformAbstractions;
//using Microsoft.OpenApi.Models;
//using ProjetoArquitetura.API.Extensoes;
//using System.ComponentModel;
//using System.IO.Compression;

//namespace ProjetoArquitetura.API
//{
//    public class Startup
//    {
//        /// <summary>
//        /// Parametros de configuraçao do sistema
//        /// </summary>
//        public IConfiguration Configuration { get; }

//        /// <summary>
//        /// Construtor das configuraçoes do sistema
//        /// </summary>
//        public IConfigurationBuilder Builder { get; }

//        /// <summary>
//        /// Construtor da classe
//        /// </summary>
//        /// <param name="env"></param>
//        public Startup(IWebHostEnvironment env)
//        {
//            Builder = new ConfigurationBuilder().SetBasePath(Path.Combine(env.ContentRootPath, "Settings"))
//                                                .AddJsonFile($"connectionstrings.{env.EnvironmentName}.json", true, true)
//                                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
//                                                .AddEnvironmentVariables();

//            Configuration = Builder.Build();
//        }

//        /// <summary>
//        /// Configura os serviços do sistema
//        /// </summary>
//        /// <param name="services"></param>
//        /// <returns></returns>
//        public IServiceProvider ConfigureServices(IServiceCollection services)
//        {
//            services.ConfigurarServicos();

//            services.ConfigurarJWT();

//            services.AddControllers();

//            ContainerBuilder container = new ContainerBuilder();

//            services.AddEndpointsApiExplorer();
//            // Configurando o serviço de documentação do Swagger
//            services.ConfigurarSwagger();


//            services.ConfigureOptions(Configuration);

//            container.Populate(services);
//            //container.RegisterModule(new MediatorModuleConfiguration());
//            //container.RegisterModule(new ApplicationModuleConfiguration(Configuration));

//            return new AutofacServiceProvider(container.Build());

//        }

//        /// <summary>
//        /// Configura o sistema
//        /// </summary>
//        /// <param name="app"></param>
//        /// <param name="env"></param>
//        /// <param name="log"></param>
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
//        {
//            app.UseCors(option => option.AllowAnyOrigin()
//                                 .AllowAnyMethod()
//                                 .AllowAnyHeader());

//            app.UseRouting();
//            //app.ConfigureEventBus();

//            app.UseHttpsRedirection();
//            app.UseAuthorization();


//            // Ativando middlewares para uso do Swagger
//            app.UseSwagger();
//            app.UseSwaggerUI(c =>
//            {
//                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
//                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Sistema de arquitetura DevPratica");
//            });

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}
