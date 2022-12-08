using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TodoService    
{
    private readonly DataContext _context;

    public TodoService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTodoDto>> GetTodoDtos()
    {
        var list  = await _context.Todos.Select(t => new GetTodoDto()
        {
            Id = t.Id,
            Description = t.Description,
            Status = t.Status,
            Title = t.Title,
            CreatedAt = t.CreatedAt,
            TodoListTitle = t.TodoList.Title,
            TodoListColor = t.TodoList.Color
        }).ToListAsync();
        return list;
    }

    public async Task<AddTodoDto> Add(AddTodoDto todo)
    {
        var newTodo = new Todo()
        {
            Description = todo.Description,
            Status = todo.Status,
            Title = todo.Title,
            CreatedAt = DateTime.UtcNow,
            TodoListId = todo.TodoListId
        };
        _context.Todos.Add(newTodo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<AddTodoDto> Update(AddTodoDto todo)
    {
        var find = await _context.Todos.FindAsync(todo.Id);
        find.Description = todo.Description;
        find.Status = todo.Status;
        find.Title = todo.Title;
        find.CreatedAt = todo.CreatedAt;
        find.TodoListId = todo.TodoListId;

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
