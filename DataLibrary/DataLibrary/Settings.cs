using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary
{
    /// <summary>
    /// Добавление статического класса в котором будут содержаться некоторые методы
    /// общие для всех классов
    /// </summary>
    static class Settings
    {
        /// <summary>
        /// Генерация случайного ID
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomId()
        {
            Random rnd = new Random();
            string Id = "";
            for (int i = 0; i < 9; i++)
                Id += (char)rnd.Next(65, 90);
            return Id;
        }
    }
}
