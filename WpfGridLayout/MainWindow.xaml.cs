using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfGridLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DoctorSchedule> data;
        public MainWindow()
        {

            InitializeComponent();

            SetData();
            Grid outerGrid = new Grid();
            Content = outerGrid;

            //ColumnDefinition col;
            //col = new ColumnDefinition();
            //col.Width = new GridLength(1, GridUnitType.Star);
            //outerGrid.ColumnDefinitions.Add(col);

            CreateTable(outerGrid, 0);
            CreateTable(outerGrid, 1);
            CreateTable(outerGrid, 2);
            CreateTable(outerGrid, 3);
            CreateTable(outerGrid, 4);

        }

        private void CreateTable(Grid outerGrid, int column)
        {

            ColumnDefinition col;
            col = new ColumnDefinition();
            col.Width = new GridLength(1, GridUnitType.Star);
            outerGrid.ColumnDefinitions.Add(col);

            Border border = new Border();
            border.Background = Brushes.Blue;
            border.BorderThickness = new Thickness(10);
            outerGrid.Children.Add(border);
            Grid.SetColumn(border, column);

            //Content = border;

            Grid grid = new Grid();
            grid.Margin = new Thickness(10);

            border.Child = grid;

            col = new ColumnDefinition();
            col.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col);

            col = new ColumnDefinition();
            col.Width = new GridLength(4, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col);

            RowDefinition row;
            Label label;
            var cellMargin = 1;
            int rowSpanStartAt = 0;
            int maxNumRows = 10;

            for (var i = 0; i < maxNumRows; i++)
            {
                row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(row);

                if ((!data[i].DepartName.Equals(data[i + 1].DepartName) || (i == maxNumRows - 1)))
                {
                    label = new Label();
                    label.Background = Brushes.Beige;
                    label.Margin = new Thickness(cellMargin);
                    label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                    grid.Children.Add(label);
                    label.Content = data[i].DepartName;
                    Console.WriteLine(i + " ====Rowspan " + rowSpanStartAt + " Count : " + (i - rowSpanStartAt + 1));
                    Grid.SetRow(label, rowSpanStartAt);
                    Grid.SetColumn(label, 0);
                    Grid.SetRowSpan(label, (i - rowSpanStartAt + 1));
                    rowSpanStartAt = i + 1;
                }

                label = new Label();
                label.Background = Brushes.Beige;
                label.Margin = new Thickness(cellMargin);
                label.Content = data[i].DoctorName + " - " + i;
                label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                grid.Children.Add(label);
                Grid.SetRow(label, i);
                Grid.SetColumn(label, 1);
            }
        }

        private void SetData()
        {

            data = new List<DoctorSchedule>();
            DoctorSchedule doctorschedule;

            for (var i = 0; i < 1000; i++)
            {
                var no = Math.Floor(i / 3.0);
                doctorschedule = new DoctorSchedule();
                doctorschedule.DepartName = "Dept" + no;
                doctorschedule.DoctorName = "Doctor";
                doctorschedule.Morning = "월, 화";
                doctorschedule.Atrernoon = "월, 수, 금";
                doctorschedule.Description = "전문분야 1, 전문분야 2";

                data.Add(doctorschedule);
            }


        }
    }
    
    class DoctorSchedule
    {
        public string DepartName { get; set; }
        public string DoctorName { get; set; }
        public string Morning { get; set; }
        public string Atrernoon { get; set; }
        public string Description { get; set; }
    }
}
