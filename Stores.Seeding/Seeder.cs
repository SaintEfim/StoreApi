using Stores.Domain.Entity;
using Stores.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Stores.Seeding
{
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
                // Путь к вашему JSON-файлу с данными
                string jsonFilePath = "C:\\Users\\user\\source\\Store_Api\\Stores.Seeding\\Data\\Stores.json";
                Console.WriteLine(jsonFilePath);
                // Проверяем, существует ли файл
                if (File.Exists(jsonFilePath))
                {
                    // Считываем данные из JSON-файла
                    string jsonData = await File.ReadAllTextAsync(jsonFilePath);

                    // Десериализуем JSON в список объектов Store
                    var stores = JsonSerializer.Deserialize<Store[]>(jsonData);

                    // Добавляем данные в контекст базы данных и сохраняем их
                    _context.Stores.AddRange(stores);
                    await _context.SaveChangesAsync();
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
}
