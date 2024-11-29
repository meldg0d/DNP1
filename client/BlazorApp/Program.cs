using BlazorApp.Auth;
using BlazorApp.Components;
using BlazorApp.Services.CommentService;
using BlazorApp.Services.PostService;
using BlazorApp.Services.UserService;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5102")
});

builder.Services.AddScoped<ICommentService, CommentServiceImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IPostService, PostServiceImpl>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthProvider>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();