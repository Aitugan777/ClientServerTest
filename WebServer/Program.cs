using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WebServer;
using WebServer.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/tasks", () => Data.Tasks);

app.MapGet("/tasks/{id}", (int id) =>
{
    // получаем задание по id
    AitukTask? task = Data.Tasks.FirstOrDefault(t => t.Id == id);

    // если не существует, возвращаем статусный код и сообщение об ошибке
    if (task == null)
        return Results.NotFound(new { message = "Задание не найдена" });

    // если задание найден, отправляем его
    return Results.Json(task);
});

app.MapDelete("/tasks/{id}", (int id) =>
{
    // получаем задание по id
    AitukTask? task = Data.Tasks.FirstOrDefault(t => t.Id == id);

    // если не существует, возвращаем статусный код и сообщение об ошибке
    if (task == null)
        return Results.NotFound(new { message = "Задание не найдена" });

    // если задание найден, удаляем его
    Data.Tasks.Remove(task);
    return Results.Json(task);
});


app.MapPost("/tasks", (AitukTask task) =>
{
    task.Id = 1;
    Data.Tasks.Add(task);

    return Results.Json(task);
});


app.MapPut("/tasks", (AitukTask taskData) =>
{
    // получаем задание по id
    AitukTask? task = Data.Tasks.FirstOrDefault(t => t.Id == taskData.Id);

    // если не существует, возвращаем статусный код и сообщение об ошибке
    if (task == null)
        return Results.NotFound(new { message = "Задание не найдена" });

    // если задание найден, обновляем его данные
    task.Name = taskData.Name;
    task.Description = taskData.Description;
    task.StatusID = taskData.StatusID;

    return Results.Json(task);
});

app.Run();


