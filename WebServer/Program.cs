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
    // �������� ������� �� id
    AitukTask? task = Data.Tasks.FirstOrDefault(t => t.Id == id);

    // ���� �� ����������, ���������� ��������� ��� � ��������� �� ������
    if (task == null)
        return Results.NotFound(new { message = "������� �� �������" });

    // ���� ������� ������, ���������� ���
    return Results.Json(task);
});

app.MapDelete("/tasks/{id}", (int id) =>
{
    // �������� ������� �� id
    AitukTask? task = Data.Tasks.FirstOrDefault(t => t.Id == id);

    // ���� �� ����������, ���������� ��������� ��� � ��������� �� ������
    if (task == null)
        return Results.NotFound(new { message = "������� �� �������" });

    // ���� ������� ������, ������� ���
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
    // �������� ������� �� id
    AitukTask? task = Data.Tasks.FirstOrDefault(t => t.Id == taskData.Id);

    // ���� �� ����������, ���������� ��������� ��� � ��������� �� ������
    if (task == null)
        return Results.NotFound(new { message = "������� �� �������" });

    // ���� ������� ������, ��������� ��� ������
    task.Name = taskData.Name;
    task.Description = taskData.Description;
    task.StatusID = taskData.StatusID;

    return Results.Json(task);
});

app.Run();


