using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
           .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
           .AddDataAnnotationsLocalization()
.AddRazorPagesOptions(options =>
{
    options.Conventions.AddFolderRouteModelConvention("/", model =>
    {
        foreach (var selector in model.Selectors)
        {
            var attributeRouteModel = selector.AttributeRouteModel;
            attributeRouteModel.Template = AttributeRouteModel.CombineTemplates("{lang=ar}", attributeRouteModel.Template);
        }
    });
});
IList<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar"),
                };

var MyOptions = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture(culture: "ar", uiCulture: "ar"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};
MyOptions.RequestCultureProviders = new[]
{
              new RouteDataRequestCultureProvider() { RouteDataStringKey = "lang", Options = MyOptions }
};

builder.Services.AddSingleton(MyOptions);
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultures = new[]
    {
                new CultureInfo("ar"),
                new CultureInfo("en-US")
            };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});
            // ...
       
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

        
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
