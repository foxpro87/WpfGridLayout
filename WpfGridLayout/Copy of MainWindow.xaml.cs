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

            Border border = new Border();
            border.Background = Brushes.Blue;
            border.BorderThickness = new Thickness(10);

            Content = border;

            Grid grid = new Grid();
            grid.Margin = new Thickness(10);

            border.Child = grid;

            ColumnDefinition col = new ColumnDefinition();
            col.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col);

            col = new ColumnDefinition();
            col.Width = new GridLength(3, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col);
            
            RowDefinition row;
            Label label;
            var cellMargin = 1;
            int groupRowIndex = 0;
            string lastGroupName = "";

            for (var i = 0; i < 30; i++)
            {
                row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(row);

                label = new Label();
                label.Background = Brushes.Beige;
                label.Margin = new Thickness(cellMargin);
                label.Content = data[i].DepartName;
                label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                grid.Children.Add(label);
                //Grid.SetRowSpan(label, 2);

                if (!data[i].DepartName.Equals(lastGroupName) && (groupRowIndex + 1 < i))
                {
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, 0);
                    Grid.SetRowSpan(label, i - groupRowIndex);
                    groupRowIndex = i;
                }
                else
                {

                }

                lastGroupName = data[i].DepartName;
                


                label = new Label();
                label.Background = Brushes.Beige;
                label.Margin = new Thickness(cellMargin);
                label.Content = data[i].DoctorName;
                label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                grid.Children.Add(label);
                Grid.SetRow(label, i);
                Grid.SetColumn(label, 1);

            }


            //row = new RowDefinition();
            ////row.Height = GridLength.Auto;
            //row.Height = new GridLength(1, GridUnitType.Star);
            //grid.RowDefinitions.Add(row);

            //



            //label = new Label();
            //label.Background = Brushes.Beige;
            //label.Margin = new Thickness(cellMargin);
            //label.Content = "문자열 : ";
            //label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            //grid.Children.Add(label);
            //Grid.SetRow(label, 0);
            //Grid.SetColumn(label, 1);


            ////label = new Label();
            ////label.Background = Brushes.Beige;
            ////label.Margin = new Thickness(cellMargin);
            ////label.Content = "문자열 : ";
            ////label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            ////grid.Children.Add(label);
            ////Grid.SetRow(label, 1);
            ////Grid.SetColumn(label, 0);

            //label = new Label();
            //label.Background = Brushes.Beige;
            //label.Margin = new Thickness(cellMargin);
            //label.Content = "문자열 : ";
            //label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            //grid.Children.Add(label);
            //Grid.SetRow(label, 1);
            //Grid.SetColumn(label, 1);






            ////Label
            //Label label = new Label();
            //label.Content = "문자열 : ";
            //grid.Children.Add(label); //일단 label을 grid에 넣어준다. 그 후에 장소지정
            //Grid.SetRow(label, 0);//0행 <Label Grid.Row="0">
            //Grid.SetColumn(label, 1);//0열 <Label Grid.Colum="1">
            ////TestBox
            //TextBox txt = new TextBox();
            //txt.BorderBrush = Brushes.Red;
            //txt.BorderThickness = new Thickness(1);
            //grid.Children.Add(txt);
            //Grid.SetRow(txt, 1);
            //Grid.SetColumn(txt, 1);
            //Button
            
            
            
            //Button btn = new Button();
            
            //btn.Content = "버튼";
            

            //////set
            ////var zIndex = ((YourCurrentControlType)sender).GetValue(Parent.ZIndexProperty);

            ////get
            ////someControl.SetValue(Parent.ZIndexProperty, zIndex++);

            
            //grid.Children.Add(btn);
            
            //Grid.SetRow(btn, 0);
            //Grid.SetColumn(btn, 0);//일단 위치 지정후 병합
            //Grid.SetRowSpan(btn, 2); //병합할대상, 병합할 셀의 수  //<Button Grid.RowSpan="2">


        }

        private void SetData()
        {

            data = new List<DoctorSchedule>();
            DoctorSchedule doctorschedule;

            for (var i = 0; i < 30; i++)
            {
                var no = Math.Floor(i / 5.0);
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
