using System;
using System.Windows;

namespace MarkForTests
{
    /// <summary>
    /// Главное окно программы, предназначенной для расчета оценки по баллам за 4 задания.
    /// Ввод осуществляется пользователем вручную через текстовые поля.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор. Здесь вызывается метод InitializeComponent, который строит интерфейс.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка события нажатия кнопки "Вычислить".
        /// Здесь происходит считывание введённых пользователем баллов,
        /// проверка на допустимость значений и расчёт оценки.
        /// </summary>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Считываем значения из текстовых полей. Используем Parse, так как ожидаем числа.
                int a = int.Parse(Task1TextBox.Text);
                int b = int.Parse(Task2TextBox.Text);
                int c = int.Parse(Task3TextBox.Text);
                int d = int.Parse(Task4TextBox.Text);

                // Проверка, чтобы все баллы находились в допустимом диапазоне.
                if (!IsValid(a, 10) || !IsValid(b, 50) || !IsValid(c, 30) || !IsValid(d, 10))
                {
                    MessageBox.Show("Некорректные значения. Проверьте баллы.");
                    return;
                }

                // Вызываем метод вычисления оценки
                var result = GradeCalculator.CalculateGrade(a, b, c, d);

                // Выводим результат в виде строки
                ResultTextBlock.Text = $"Сумма баллов: {result.TotalScore}\nОценка: {result.Grade}";
            }
            catch
            {
                // Если введено что-то кроме чисел — выводим сообщение
                MessageBox.Show("Введите числовые значения.");
            }
        }

        /// <summary>
        /// Метод проверки, что значение от 0 до максимума.
        /// Используется, чтобы избежать ввода некорректных баллов.
        /// </summary>
        private bool IsValid(int value, int max) => value >= 0 && value <= max;
    }

    /// <summary>
    /// Статический класс, содержащий метод для расчета оценки.
    /// Принимает баллы за каждое задание и возвращает итог и соответствующую отметку.
    /// </summary>
    public class GradeCalculator
    {
        /// <summary>
        /// Метод вычисляет сумму баллов и присваивает оценку в зависимости от результата.
        /// Оценка ставится по следующим правилам:
        /// - от 70 до 100 баллов — "5 (Отлично)"
        /// - от 40 до 69 баллов — "4 (Хорошо)"
        /// - от 20 до 39 баллов — "3 (Удовлетворительно)"
        /// - ниже 20 баллов — "2 (Неудовлетворительно)"
        /// </summary>
        public static (int TotalScore, string Grade) CalculateGrade(int a, int b, int c, int d)
        {
            int total = a + b + c + d;

            // В зависимости от количества баллов присваиваем оценку
            string mark = total >= 70 ? "5 (Отлично)"
                        : total >= 40 ? "4 (Хорошо)"
                        : total >= 20 ? "3 (Удовлетворительно)"
                        : "2 (Неудовлетворительно)";

            return (total, mark);
        }
    }
}
