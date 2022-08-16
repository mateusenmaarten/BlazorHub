using BlazorHub;
using Radzen;
using FluentValidation;
using BlazorHub.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Radzen
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();

builder.Services.AddScoped<ContextMenuService>();

builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<UserContext>();
builder.Services.AddScoped<CAHGameService>();


//State
builder.Services.AddSingleton<State>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapHub<ChatHub>(ChatHub.HubUrl);

app.Run();
