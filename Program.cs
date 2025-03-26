using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FractionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вітаємо у калькуляторі дробів!");

            try
            {
                // Зчитування першого дробу
                Console.WriteLine("Введіть перший дріб (формат: чисельник/знаменник):");
                Fraction fraction1 = ParseFraction(Console.ReadLine());

                // Зчитування другого дробу
                Console.WriteLine("Введіть другий дріб (формат: чисельник/знаменник):");
                Fraction fraction2 = ParseFraction(Console.ReadLine());

                // Обрання операції
                Console.WriteLine("Оберіть операцію (+, -, *, /):");
                string op = Console.ReadLine();

                Fraction result = op switch
                {
                    "+" => fraction1.Add(fraction2),
                    "-" => fraction1.Subtract(fraction2),
                    "*" => fraction1.Multiply(fraction2),
                    "/" => fraction1.Divide(fraction2),
                    _ => throw new InvalidOperationException("Невідома операція.")
                };

                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static Fraction ParseFraction(string input)
        {
            var parts = input.Split('/');
            if (parts.Length != 2)
                throw new FormatException("Невірний формат дробу. Формат має бути 'чисельник/знаменник'.");
            int numerator = int.Parse(parts[0]);
            int denominator = int.Parse(parts[1]);
            return new Fraction(numerator, denominator);
        }
    }
}
