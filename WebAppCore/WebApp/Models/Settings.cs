using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Models
{
    /// <summary>
    /// Статический класс в котором собраны методы, необходимые для всех сущностей
    /// </summary>
    static class Settings
    {
        /// <summary>
        /// Генерация случайного ID
        /// </summary>
        /// <returns>ID</returns>
        public static string GenerateId()
        {
            Random rnd = new Random();
            string Id = "";
            for (int i = 0; i < 10; i++)
                Id += (char)rnd.Next(65, 90);
            return Id;
        }
    }
}
