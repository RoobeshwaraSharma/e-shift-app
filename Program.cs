using System;
using System.IO;
using System.Windows.Forms;
using e_shift_app.db;
using e_shift_app.views.admin;
using e_shift_app.views.customer;
using e_shift_app.views.job;
using e_shift_app.views.login;
using e_shift_app.views.transportManagement.Assistant;
using e_shift_app.views.transportManagement.container;
using e_shift_app.views.transportManagement.driver;
using e_shift_app.views.transportManagement.lorry;
using e_shift_app.views.transportManagement.transportUnit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace e_shift_app
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 1. Build configuration (for ConnectionStrings, etc.)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Set up DI container
            var services = new ServiceCollection()
                // Make IConfiguration injectable (optional, but often useful)
                .AddSingleton<IConfiguration>(configuration)
                // Register your EF Core DbContext
                .AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                // Register your forms (and any other services)
                .AddTransient<CustomerForm>()
                .AddTransient<AppLoginForm>()
                .AddTransient<CustomerGridView>()
                .AddTransient<AdminForm>()
                .AddTransient<AdminLogin>()
                .AddTransient<AdminGrid>()
                .AddTransient<AdminDashboard>()
                .AddTransient<CustomerDashboard>()
                .AddTransient<JobForm>()
                .AddTransient<LorryForm>()
                .AddTransient<LorryGrid>()
                .AddTransient<ContainerGrid>()
                .AddTransient<DriverGrid>()
                .AddTransient<AssistantGrid>()
                .AddTransient<TransportUnitGrid>();


            var serviceProvider = services.BuildServiceProvider();

            // 3. Apply any pending EF migrations at startup
            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }

            // 4. Initialize WinForms and run the form resolved from the container
            ApplicationConfiguration.Initialize();

            // Resolve the form so its constructor gets the AppDbContext automatically
            var loginForm = serviceProvider.GetRequiredService<AppLoginForm>();
            Application.Run(loginForm);
        }
    }
}
