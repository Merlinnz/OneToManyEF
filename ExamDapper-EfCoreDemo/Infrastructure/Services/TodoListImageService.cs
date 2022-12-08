using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TodoListImageService
{
    private readonly DataContext _context;

    public TodoListImageService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTodoListImage>> GetTodoListImages()
    {
        var list = await _context.TodoListImages.Select(t => new GetTodoListImage()
        {
            Id = t.Id,
            ImageName = t.ImageName,
            TodoListTitle = t.TodoList.Title

        }).ToListAsync();
        return list;
    }

    public async Task<AddTodoListImage> Add(AddTodoListImage todo)
    {
        var newTodoListImage = new TodoListImage()
        {
            ImageName = todo.ImageName,
            TodoListId = todo.TodoListId
        };
        _context.TodoListImages.Add(newTodoListImage);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<AddTodoListImage> Update(AddTodoListImage todo)
    {
        var find = await _context.TodoListImages.FindAsync(todo.Id);
        find.ImageName = todo.ImageName;

        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<string> Delete(int id)
    {
        var find = await _context.TodoListImages.FindAsync(id);
        _context.TodoListImages.Remove(find);
        await _context.SaveChangesAsync();
        return "Deleted";
    }
}