using System;
using System.Windows;

namespace MarkForTests
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = int.Parse(Task1TextBox.Text);
                int b = int.Parse(Task2TextBox.Text);
                int c = int.Parse(Task3TextBox.Text);
                int d = int.Parse(Task4TextBox.Text);

                if (!IsValid(a, 10) || !IsValid(b, 50) || !IsValid(c, 30) || !IsValid(d, 10))
                {
                    MessageBox.Show("Некорректные значения. Проверьте баллы.");
                    return;
                }

                var result = GradeCalculator.CalculateGrade(a, b, c, d);
                ResultTextBlock.Text = $"Сумма баллов: {result.TotalScore}\nОценка: {result.Grade}";
            }
            catch
            {
                MessageBox.Show("Введите числовые значения.");
            }
        }

        private bool IsValid(int value, int max) => value >= 0 && value <= max;
    }

    public class GradeCalculator
    {
        public static (int TotalScore, string Grade) CalculateGrade(int a, int b, int c, int d)
        {
            int total = a + b + c + d;
            string mark = total >= 70 ? "5 (Отлично)"
                        : total >= 40 ? "4 (Хорошо)"
                        : total >= 20 ? "3 (Удовлетворительно)"
                        : "2 (Неудовлетворительно)";

            return (total, mark);
        }
    }
}
