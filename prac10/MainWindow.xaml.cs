using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> numbers;

        public MainWindow()
        {
            InitializeComponent();
            numbers = new List<int>();
        }
        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tb_num.Text, out int number))
            {
                // Добавляем число в список
                numbers.Add(number);
                lb_num.Items.Add($"{number} ");
                // Очищаем текстовое поле
                tb_num.Text = string.Empty;
                
            }
            else
            {
                MessageBox.Show("Некорректное число. Пожалуйста, введите целое число.");
            }
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (numbers.Count == 0)
            {
                MessageBox.Show("Список чисел пуст.");
                return;
            }

            int maxNegative = int.MinValue;
            int maxNegativeIndex = -1;

            // Проходим по списку и находим максимальное отрицательное значение и его индекс
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0 && numbers[i] > maxNegative)
                {
                    maxNegative = numbers[i];
                    maxNegativeIndex = i;
                }
            }

            // Выводим результат на элементы интерфейса
            if (maxNegativeIndex != -1)
            {
                 lb_max.Items.Add($"Максимальное отрицательное значение: {maxNegative}\r\nИндекс максимального отрицательного значения: {maxNegativeIndex}");
            }
            else
            {
                 lb_max.Items.Add("В коллекции нет отрицательных значений");
            }
                      
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил лучший разработчик: Девяткин Вадим Евгеньевич\r\nПрактическая №10");
        }

        private void btnClear_click(object sender, RoutedEventArgs e)
        {
            numbers.Clear();
            lb_num.Items.Clear();
            lb_max.Items.Clear();
        }
    }
}
