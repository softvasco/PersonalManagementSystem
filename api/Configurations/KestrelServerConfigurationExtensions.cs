using static api.Constants.ApplicationConstants;

namespace api.Configurations
{
    /// <summary>
    /// Provides extension methods for configuring the Kestrel web server.
    /// </summary>
    public static class KestrelServerConfigurationExtensions
    {
        /// <summary>
        /// Configures the Kestrel server to listen on HTTP and HTTPS ports specified in appSettings.json.
        /// </summary>
        /// <param name="builder">The web application builder used to configure the app's hosting and startup.</param>
        /// <remarks>
        /// This configuration sets up the web server to listen on configurable ports for HTTP and HTTPS.
        /// Ports are read from the KestrelSettings section of the appSettings.json file.
        /// </remarks>
        ///     /// <returns>The WebApplicationBuilder for chaining.</returns>
        public static WebApplicationBuilder ConfigureKestrelServer(this WebApplicationBuilder builder)
        {
            // Only use this Kestrel config for Docker env
            if (!builder.Environment.IsEnvironment(Docker)) return builder;

            var configuration = builder.Configuration;
            var httpPort = configuration.GetValue<int>(KestrelHttpPort);
            var httpsPort = configuration.GetValue<int>(KestrelHttpsPort);

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                // Listen on a configurable port for HTTP requests.
                serverOptions.ListenAnyIP(httpPort);

                // Listen on a configurable port for HTTPS requests.
                serverOptions.ListenAnyIP(httpsPort, listenOptions =>
                {
                    listenOptions.UseHttps();
                });
            });

            return builder;
        }
    }
}
