using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoArquitetura.Infra.Entity;
using ProjetoArquitetura.Models.Models;
using ProjetoArquitetura.Negocios.Cliente;
using ProjetoArquitetura.Negocios.Fornecedor;
using ProjetoArquitetura.Negocios.Funcionario;
using System.Security.Cryptography;


namespace ProjetoArquitetura.API.Extensoes
{

    public static class ServicoExtensoes
    {
        public static void ConfigurarSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - Dev:Prática",
                    Version = "v1",
                    Description = "APIs para cadastros de clientes etc..."
                });

                c.EnableAnnotations();

                var securityscheme = new OpenApiSecurityScheme
                {
                    Name = "autenticação jwt",
                    Description = "informe o token jwt beare **_somente_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityscheme.Reference.Id, securityscheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            { securityscheme, Array.Empty<string>() }
                        });
            });
        public static void ConfigurarJWT(this IServiceCollection services)
        {
            Environment.SetEnvironmentVariable("JWT_SECRETO",
             Convert.ToBase64String(new HMACSHA256().Key), EnvironmentVariableTarget.Process);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = "EmitenteDoJWT",
                    ValidAudience = "DestinatarioDoJWT", 
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Convert.FromBase64String(Environment.GetEnvironmentVariable("JWT_SECRETO"))),

                };

            });

        }

        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "post:/api/Login",
                    Limit = 2,
                    Period = "10s",
                },
                //new RateLimitRule
                //{
                //    Endpoint = "*",
                //    Period = "10s",
                //    Limit = 2
                //}
            };

            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.EnableEndpointRateLimiting = true;
                opt.StackBlockedRequests = false;
                opt.GeneralRules = rateLimitRules;
            });

            services.AddInMemoryRateLimiting();

            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }

        public static void ConfigurarServicos(this IServiceCollection services)
        {
            string connectionString = "Data Source=bd.thor.hostazul.com.br,3533; User ID=139_fernando; Password=szxuj1tipnvhykqfwbcm;Initial Catalog=139_fernando;";

            //NUVEM
            //string connectionString = "Data Source=bd.thor.hostazul.com.br,3533;User ID=139_usuariodevpratica;Password=kfsymnvpwexhgrt8qboa;Initial Catalog=139_devpratica_exercicio;";

            services.AddDbContext<Context>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<ICliente, Cliente>();
            services.AddScoped<IFornecedor, Fornecedor>();
            services.AddScoped<IFuncionario, Funcionario>();

            //services.AddScoped<ClienteModel>();
            //services.AddScoped<FornecedorModel>();
            //services.AddScoped<FuncionarioModel>();
        }
    }
}
