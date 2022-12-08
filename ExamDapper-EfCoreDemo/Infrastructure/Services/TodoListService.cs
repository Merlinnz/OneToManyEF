using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TodoListService
{
    private readonly DataContext _context;

    public TodoListService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTodoList>> GetTodoLists()
    {
        var list  = await _context.TodoLists.Select(t => new GetTodoList()
        {
            Id = t.Id,
            Title = t.Title,
            Color = t.Color
        }).ToListAsync();
        return list;
    }

     public async Task<AddTodoListDto> AddTodoList(AddTodoListDto todo)
    {
        var newTodoList = new TodoList()
        {
            Title = todo.Title,
            Color = todo.Color
        };
        _context.TodoLists.Add(newTodoList);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<AddTodoListDto> Update(AddTodoListDto todo)
    {
        var find = await _context.TodoLists.FindAsync(todo.Id);
        find.Title = todo.Title;
        find.Color = todo.Color;
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<string> Delete(int id)
    {
        var find = await _context.Todos.FindAsync(id);
        _context.Todos.Remove(find);
        await _context.SaveChangesAsync();
        return "Deleted";
    }
}