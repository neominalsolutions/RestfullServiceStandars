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

// useWhen => use conditional hali next olarak bir sonraki ak��a ge�ir. Ak��� devam ettirir.
// ko�ula midleware pipeline de�i�mesini sa�l�yor.
//app.UseWhen(context => context.Request.Method == HttpMethod.Post.ToString() && context.Request.Path.StartsWithSegments("/api/posts"), config =>
//{
//  config.Use(async (context, next) =>
//  {

//    //var totalFileSize = context.Request.Form.Files.Sum(x => x.Length);

//    await Console.Out.WriteLineAsync("Ara i�lem ba�lat");

//    // hi� controller action gitmeden response m�dehale et.
//    //context.Response.StatusCode = StatusCodes.Status502BadGateway;
//    //await context.Response.WriteAsync("Hata");

//    await next(); // controller actionda sonra response m�dehale et

//    context.Response.StatusCode = StatusCodes.Status502BadGateway;
//    await context.Response.WriteAsync("Hata");

//    await Console.Out.WriteLineAsync("Ara i�lem sonland�r");
//  });


//  config.UseAuthentication();

//});


// useMap => Run gibi �al��an ilgili pipeline devam ettirmeyen middleware


//app.MapWhen(context => !string.IsNullOrEmpty(context.Request.Query["searchText"]), config =>
//{
//  config.Use(async (context, next) =>
//  {
//   await  Console.Out.WriteLineAsync("searchText i�lemi yap�lacak bir durum olu�tu");

//    context.Response.StatusCode = StatusCodes.Status400BadRequest;
//    await context.Response.WriteAsync("searchText de�erini bo� ge�emezsin");

//    await next();
//  });

//});

// Not MapWhen de s�re� sonland�r�ld���ndan bu middleware �al��maz ama useWhen de �al���r
//app.Use(async (context, next) =>
//{
//  await Console.Out.WriteLineAsync("Son i�lem");
//  await next();
//}); 


app.MapControllers();
app.Run();
