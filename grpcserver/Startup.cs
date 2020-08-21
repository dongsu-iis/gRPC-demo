using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace grpcserver {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            services.AddGrpc ();

            services.AddCors (o => {
                o.AddPolicy ("MyPolicy", builder => {
                    builder.WithOrigins ("http://localhost:4200");
                    builder.AllowAnyMethod ();
                    builder.AllowAnyHeader ();
                    builder.WithExposedHeaders ("Grpc-Status", "Grpc-Message");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseRouting ();

            app.UseGrpcWeb ();

            app.UseCors ("MyPolicy");

            app.UseEndpoints (endpoints => {
                endpoints.MapGrpcService<GreeterService> ().EnableGrpcWeb ();

                endpoints.MapGet ("/", async context => {
                    await context.Response.WriteAsync ("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
