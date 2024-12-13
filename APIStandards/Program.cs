using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//JsonSerializerOptions opts = new JsonSerializerOptions
//{
//  PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

//};

//JsonSerializer.Serialize(new { }, opts);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// useWhen => use conditional hali next olarak bir sonraki akýþa geçir. Akýþý devam ettirir.
// koþula midleware pipeline deðiþmesini saðlýyor.
//app.UseWhen(context => context.Request.Method == HttpMethod.Post.ToString() && context.Request.Path.StartsWithSegments("/api/posts"), config =>
//{
//  config.Use(async (context, next) =>
//  {

//    //var totalFileSize = context.Request.Form.Files.Sum(x => x.Length);

//    await Console.Out.WriteLineAsync("Ara iþlem baþlat");

//    // hiç controller action gitmeden response müdehale et.
//    //context.Response.StatusCode = StatusCodes.Status502BadGateway;
//    //await context.Response.WriteAsync("Hata");

//    await next(); // controller actionda sonra response müdehale et

//    context.Response.StatusCode = StatusCodes.Status502BadGateway;
//    await context.Response.WriteAsync("Hata");

//    await Console.Out.WriteLineAsync("Ara iþlem sonlandýr");
//  });


//  config.UseAuthentication();

//});


// useMap => Run gibi çalýþan ilgili pipeline devam ettirmeyen middleware


//app.MapWhen(context => !string.IsNullOrEmpty(context.Request.Query["searchText"]), config =>
//{
//  config.Use(async (context, next) =>
//  {
//   await  Console.Out.WriteLineAsync("searchText iþlemi yapýlacak bir durum oluþtu");

//    context.Response.StatusCode = StatusCodes.Status400BadRequest;
//    await context.Response.WriteAsync("searchText deðerini boþ geçemezsin");

//    await next();
//  });

//});

// Not MapWhen de süreç sonlandýrýldýðýndan bu middleware çalýþmaz ama useWhen de çalýþýr
//app.Use(async (context, next) =>
//{
//  await Console.Out.WriteLineAsync("Son iþlem");
//  await next();
//}); 


app.MapControllers();
app.Run();
