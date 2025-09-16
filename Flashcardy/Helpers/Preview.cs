using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace Flashcardy.Helpers
{
    public static class Preview
    {
        public static StackPanel PowerPointPreview(int size, int mode)
        {
            StackPanel sp = new();

            TextBlock titleA = new()
            {
                Text = "Page A",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 10
            };
            Border pageA = new Border();
            pageA.Width = 1920 / 7.5;
            pageA.Height = 1080 / 7.5;
            pageA.BorderBrush = new SolidColorBrush(Colors.Black);
            pageA.BorderThickness = new Thickness(1);

            System.Windows.Controls.Separator s = new();
            s.Height = 5;
            s.Width = 0;

            TextBlock titleB = new()
            {
                Text = "Page B",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 10
            };
            Border pageB = new Border();
            pageB.Width = 1920 / 7.5;
            pageB.Height = 1080 / 7.5;
            pageB.BorderBrush = new SolidColorBrush(Colors.Black);
            pageB.BorderThickness = new Thickness(1);

            sp.Children.Add(titleA);
            sp.Children.Add(pageA);
            sp.Children.Add(s);
            sp.Children.Add(titleB);
            sp.Children.Add(pageB);

            Grid gridA = new();
            Grid gridB = new();
            switch(size)
            {
                case 0:
                    if(mode == 0)
                    {
                        pageA.Padding = new Thickness(0, 0, 0, 45);
                        pageB.Padding = new Thickness(0, 45, 0, 0);
                    } else
                    {
                        pageA.Padding = new Thickness(0, 0, 0, 45);
                        pageB.Padding = new Thickness(0, 0, 0, 45);
                    }

                    gridA.ColumnDefinitions.Add(new());
                    gridA.ColumnDefinitions.Add(new());
                    gridA.ColumnDefinitions.Add(new());

                    gridA.RowDefinitions.Add(new());
                    gridA.RowDefinitions.Add(new());

                    gridB.ColumnDefinitions.Add(new());
                    gridB.ColumnDefinitions.Add(new());
                    gridB.ColumnDefinitions.Add(new());

                    gridB.RowDefinitions.Add(new());
                    gridB.RowDefinitions.Add(new());

                    {
                        Border topLeft = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(0, 0, 2, 2),
                            Child = new TextBlock()
                            {
                                Text = "A",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        gridA.Children.Add(topLeft);

                        Border topMiddle = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(2, 0, 2, 2),
                            Child = new TextBlock()
                            {
                                Text = "B",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetColumn(topMiddle, 1);
                        gridA.Children.Add(topMiddle);

                        Border topRight = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(2, 0, 0, 2),
                            Child = new TextBlock()
                            {
                                Text = "C",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetColumn(topRight, 2);
                        gridA.Children.Add(topRight);

                        Border bottomLeft = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(0, 2, 2, 0),
                            Child = new TextBlock()
                            {
                                Text = "D",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomLeft, 1);
                        gridA.Children.Add(bottomLeft);

                        Border bottomMiddle = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(2, 2, 2, 0),
                            Child = new TextBlock()
                            {
                                Text = "E",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomMiddle, 1);
                        Grid.SetColumn(bottomMiddle, 1);
                        gridA.Children.Add(bottomMiddle);

                        Border bottomRight = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(2, 2, 0, 0),
                            Child = new TextBlock()
                            {
                                Text = "F",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomRight, 1);
                        Grid.SetColumn(bottomRight, 2);
                        gridA.Children.Add(bottomRight);
                    }

                    {
                        Border topLeft = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(0, 0, 2, 2),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "D" : "A",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        gridB.Children.Add(topLeft);

                        Border topMiddle = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(2, 0, 2, 2),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "E" : "B",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetColumn(topMiddle, 1);
                        gridB.Children.Add(topMiddle);

                        Border topRight = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(2, 0, 0, 2),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "F" : "C",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetColumn(topRight, 2);
                        gridB.Children.Add(topRight);

                        Border bottomLeft = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(0, 2, 2, 0),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "A" : "D",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomLeft, 1);
                        gridB.Children.Add(bottomLeft);

                        Border bottomMiddle = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(2, 2, 2, 0),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "B" : "E",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomMiddle, 1);
                        Grid.SetColumn(bottomMiddle, 1);
                        gridB.Children.Add(bottomMiddle);

                        Border bottomRight = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            //Width = 640,
                            //Height = 480,
                            Margin = new Thickness(2, 2, 0, 0),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "C" : "F",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomRight, 1);
                        Grid.SetColumn(bottomRight, 2);
                        gridB.Children.Add(bottomRight);
                    }
                    break;
                case 1:
                    gridA.ColumnDefinitions.Add(new());
                    gridA.ColumnDefinitions.Add(new());

                    gridA.RowDefinitions.Add(new());
                    gridA.RowDefinitions.Add(new());

                    gridB.ColumnDefinitions.Add(new());
                    gridB.ColumnDefinitions.Add(new());

                    gridB.RowDefinitions.Add(new());
                    gridB.RowDefinitions.Add(new());

                    {
                        Border topLeft = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            Margin = new Thickness(0, 0, 2, 2),
                            Child = new TextBlock()
                            {
                                Text = "A",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        gridA.Children.Add(topLeft);

                        Border topRight = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            Margin = new Thickness(2, 0, 0, 2),
                            Child = new TextBlock()
                            {
                                Text = "B",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetColumn(topRight, 1);
                        gridA.Children.Add(topRight);

                        Border bottomLeft = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            Margin = new Thickness(0, 2, 2, 0),
                            Child = new TextBlock()
                            {
                                Text = "C",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomLeft, 1);
                        gridA.Children.Add(bottomLeft);

                        Border bottomRight = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            Margin = new Thickness(2, 2, 0, 0),
                            Child = new TextBlock()
                            {
                                Text = "D",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomRight, 1);
                        Grid.SetColumn(bottomRight, 1);
                        gridA.Children.Add(bottomRight);
                    }

                    {
                        Border topLeft = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            Margin = new Thickness(0, 0, 2, 2),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "B" : "C",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        gridB.Children.Add(topLeft);

                        Border topRight = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            Margin = new Thickness(2, 0, 0, 2),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "A" : "D",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetColumn(topRight, 1);
                        gridB.Children.Add(topRight);

                        Border bottomLeft = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            Margin = new Thickness(0, 2, 2, 0),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "D" : "A",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomLeft, 1);
                        gridB.Children.Add(bottomLeft);

                        Border bottomRight = new()
                        {
                            BorderBrush = new SolidColorBrush(Colors.Black),
                            BorderThickness = new Thickness(1),
                            Margin = new Thickness(2, 2, 0, 0),
                            Child = new TextBlock()
                            {
                                Text = mode == 0 ? "C" : "B",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 20
                            }
                        };
                        Grid.SetRow(bottomRight, 1);
                        Grid.SetColumn(bottomRight, 1);
                        gridB.Children.Add(bottomRight);
                    }
                    break;
                default:
                    break;
            }
            pageA.Child = gridA;
            pageB.Child = gridB;

            return sp;
        }
    }
}
