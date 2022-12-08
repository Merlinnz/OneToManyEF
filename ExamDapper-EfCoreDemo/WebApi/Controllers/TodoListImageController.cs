namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

[ApiController]
[Route("controller")]

public class TodoListImageController 
{
    private readonly TodoListImageService _todoListImageService;

    public TodoListImageController(TodoListImageService todoListImageService)
    {
        _todoListImageService = todoListImageService;
    }

    [HttpGet("GetTodoListImages")]
    public async Task<List<GetTodoListImage>> GetTodoListImages()
    {
        return await _todoListImageService.GetTodoListImages();
    }

    [HttpPost("InsertNewTodoListImage")]
    public async Task<AddTodoListImage> Add(AddTodoListImage todo)
    {
        return await _todoListImageService.Add(todo);
    }

    [HttpPut("UpdateTodoListImages")]
    public async Task<AddTodoListImage> Update(AddTodoListImage todo)
    {
        return await _todoListImageService.Update(todo);
    }

    [HttpDelete("DeleteTodoListImage")]
    public async Task<string> DeleteTodo(int id)
    {
        return await _todoListImageService.Delete(id);
    }
}