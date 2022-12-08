namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

[ApiController]
[Route("controller")]

public class TodoController
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet("GetTodos")]
    public async Task<List<GetTodoDto>> GetTodos()
    {
        return await _todoService.GetTodoDtos();
    }

    
    [HttpPost("InsertNewTodo")]
    public async Task<AddTodoDto> Add(AddTodoDto todo)
    {
        return await _todoService.Add(todo);
    }

    [HttpPut("Update")]
    public async Task<AddTodoDto> Update(AddTodoDto todo)
    {
        return await _todoService.Update(todo);
    }

    [HttpDelete("DeleteTodo")]
    public async Task<string> DeleteTodo(int id)
    {
        return await _todoService.Delete(id);
    }
}