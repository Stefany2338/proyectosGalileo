
public class Startup
{

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Acceso}/{action=Index}/{id?}");
        });
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

        services.AddControllersWithViews();
    }

}

