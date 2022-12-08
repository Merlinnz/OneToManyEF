namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

[ApiController]
[Route("controller")]

public class TodoListController
{
    private readonly TodoListService _todoListService;

    public TodoListController(TodoListService todoListService)
    {
        _todoListService = todoListService;
    }

    [HttpGet("GetTodoLists")]
    public async Task<List<GetTodoList>> GetTodoLists()
    {
        return await _todoListService.GetTodoLists();
    }

    
    [HttpPost("InsertNewTodoList")]
    public async Task<AddTodoListDto> AddBook(AddTodoListDto todo)
    {
        return await _todoListService.AddTodoList(todo);
    }

    [HttpPut("UpdateTodoList")]
    public async Task<AddTodoListDto> UpdateTodoList(AddTodoListDto todo)
    {
        return await _todoListService.Update(todo);
    }

    [HttpDelete("DeleteTodoList")]
    public async Task<string> DeleteTodoList(int id)
    {
        return await _todoListService.Delete(id);
    }
}