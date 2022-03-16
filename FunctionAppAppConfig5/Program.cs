using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(c =>    {
        
        c.AddEnvironmentVariables();        
        var config = c.Build();        
        c.AddAzureAppConfiguration(options =>
                    options.Connect(new Uri(config.GetValue<string>("AppConfigEndpoint")), new ManagedIdentityCredential()));
    })
    
    .Build();


host.Run();