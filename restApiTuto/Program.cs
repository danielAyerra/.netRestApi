using Microsoft.OpenApi.Models;
using restApiTuto.DB;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
if(builder.Environment.IsDevelopment()){
   builder.Services.AddSwaggerGen(c =>
     {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
     });
}
var app = builder.Build();
if (app.Environment.IsDevelopment())
{

  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
  });
  app.MapGet("/", () =>{
    return Results.Redirect("/swagger/index.html", true);
  });
}

app.MapGet("/task2/{id}", (int id)=> RecordDb.GetRecord(id));
app.MapGet("/task2",() => RecordDb.GetRecords());
app.MapPost("/task2", (Record rec)=>RecordDb.CreateRecord(rec));
app.MapPut("/task2", (Record rec)=>RecordDb.UpdateRecord(rec));
app.MapDelete("/task2/{id}", (int id)=>RecordDb.RemoveRecord(id));

app.Run();
