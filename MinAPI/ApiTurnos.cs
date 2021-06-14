using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System.Net;
using MinAPI.Infrastructure.Services;
using MinAPI.Core.DataObjects;

var builder = WebApplication.CreateBuilder(args);
await using var app = builder.Build();
LocalMongoDataBase db = new LocalMongoDataBase("local");
var table = "Turnos";

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() => "Hello World!"));

app.MapPost("/turnos", (Func<Turno, HttpStatusCode>)((turno) =>
{
    db.InsertRecord(table, turno);
    return HttpStatusCode.OK;
}));

app.MapGet("/turnos/{id}", (Func<int, Turno>)((id) =>
{
    return db.LoadRecordById<Turno>(table, id);
}));

app.MapGet("/turnos", (Func<List<Turno>>)(() =>
{
    return db.LoadRecords<Turno>(table);
}));

app.MapDelete("/turnos/{id}", (Func<int, HttpStatusCode>)((id) =>
{
    db.DeleteRecord<Turno>(table, id);
    return HttpStatusCode.OK;
}));

await app.RunAsync();





