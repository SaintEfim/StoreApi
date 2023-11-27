using Stores.Domain.Entity;
using Stores.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Reflection;

namespace Stores.Seeding;

public class Seeder
{
    private readonly ApplicationDbContext _context;

    public Seeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedData()
    {
        try
        {
            var appDir = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                @"..\..\..\..\"));
            var fullPath = Path.Combine(Path.Combine(appDir, @"Stores.Seeding\Data\Stores.json"));
            // Проверяем, существует ли файл
            if (File.Exists(fullPath))
            {
                // Проверяем, существуют ли уже данные в базе данных
                if (!_context.Stores.Any())
                {
                    // Считываем данные из JSON-файла
                    string jsonData = await File.ReadAllTextAsync(fullPath);

                    // Десериализуем JSON в список объектов Store
                    var stores = JsonSerializer.Deserialize<List<Store>>(jsonData);

                    // Добавляем данные в контекст базы данных и сохраняем их, только если база данных пуста
                    if (stores != null) await _context.Stores.AddRangeAsync(stores);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("База данных уже содержит данные. Записи не добавлены.");
                }
            }
            else
            {
                Console.WriteLine("Файл с данными не найден.");
            }
        }
        catch (DbUpdateException ex)
        {
            // Печать внутреннего исключения для получения подробностей
            Console.WriteLine($"Ошибка сохранения данных: {ex.InnerException}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при импорте данных: {ex.Message}");
        }
    }
}