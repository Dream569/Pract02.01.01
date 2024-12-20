using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Controls;
using static Pract02._01.ClassPipi;

namespace Pract02._01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PlotButton_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox.Text;
            List<int> values = ClassPipi.GetNumericValues(input);

            if (values.Count == 0)
            {
                MessageBox.Show("Только русские ЗАГЛАВНЫЕ буквы!");
                return;
            }

            DrawGraph(values);
        }

        private void DrawGraph(List<int> values)
        {
            graphCanvas.Children.Clear();
            double canvasWidth = graphCanvas.ActualWidth;
            double canvasHeight = graphCanvas.ActualHeight;

            double max = double.MinValue;
            double min = double.MaxValue;

            foreach (int value in values)
            {
                if (value > max) max = value;
                if (value < min) min = value;
            }

            double range = max - min;
            if (range == 0) range = 1;

            double xIncrement = canvasWidth / values.Count;

            for (int i = 0; i < values.Count; i++)
            {
                double x = i * xIncrement;
                double y = canvasHeight - ((values[i] - min) / range * canvasHeight);

                if (i > 0)
                {
                    Line line = new Line
                    {
                        X1 = (i - 1) * xIncrement,
                        Y1 = canvasHeight - ((values[i - 1] - min) / range * canvasHeight),
                        X2 = x,
                        Y2 = y,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2
                    };
                    graphCanvas.Children.Add(line);
                }
            }
        }
        private void InfoClick(object sender, EventArgs e)
        {
            MessageBox.Show("Это практическая работа заданная на практику: Пользователь вводит строку. Каждый символ преобразовать в \r\nцифровой показатель: А = -16, Б= -15 ... Я = 13 (через классы). Построить график \r\nна основании полученного «слова».");
        }
        private void ExitClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}