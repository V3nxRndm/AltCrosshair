using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System.Collections.Generic;

namespace AltCrosshair
{
    public partial class MainWindow : Window
    {
        private List<Layer> layers = new();
        private Layer? selectedLayer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddLayer_Click(object sender, RoutedEventArgs e)
        {
            var newLayer = new Layer
            {
                Width = 5,
                Size = 50,
                Roundness = 5,
                Color = new SolidColorBrush(Microsoft.UI.Colors.Black)
            };
            layers.Add(newLayer);
            LayerList.Items.Add($"Layer {layers.Count}");
            LayerList.SelectedIndex = layers.Count - 1;
        }

        private void RemoveLayer_Click(object sender, RoutedEventArgs e)
        {
            if (LayerList.SelectedIndex >= 0)
            {
                int index = LayerList.SelectedIndex;
                layers.RemoveAt(index);
                LayerList.Items.RemoveAt(index);
                UpdatePreview();
            }
        }

        private void LayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LayerList.SelectedIndex >= 0)
            {
                selectedLayer = layers[LayerList.SelectedIndex];
                WidthSlider.Value = selectedLayer.Width;
                SizeSlider.Value = selectedLayer.Size;
                RoundnessSlider.Value = selectedLayer.Roundness;
                ColorPreview.Fill = selectedLayer.Color;
            }
        }

        private void WidthSlider_ValueChanged(object sender, Microsoft.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (selectedLayer != null)
            {
                selectedLayer.Width = e.NewValue;
                UpdatePreview();
            }
        }

        private void SizeSlider_ValueChanged(object sender, Microsoft.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)

        {
            if (selectedLayer != null)
            {
                selectedLayer.Size = e.NewValue;
                UpdatePreview();
            }
        }

        private void RoundnessSlider_ValueChanged(object sender, Microsoft.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            if (selectedLayer != null)
            {
                selectedLayer.Roundness = e.NewValue;
                UpdatePreview();
            }
        }

        private void ColorPickerButton_Click(object sender, RoutedEventArgs e)
        {
            // For simplicity, let's pick random colors for now.
            var random = new System.Random();
            var color = new SolidColorBrush(
                Microsoft.UI.Colors.DarkViolet);

            if (selectedLayer != null)
            {
                selectedLayer.Color = color;
                ColorPreview.Fill = color;
                UpdatePreview();
            }
        }

        private void UpdatePreview()
        {
            CrosshairCanvas.Children.Clear();
            foreach (var layer in layers)
            {
                var ellipse = new Ellipse
                {
                    Width = layer.Size,
                    Height = layer.Size,
                    Stroke = layer.Color,
                    StrokeThickness = layer.Width
                };

                Canvas.SetLeft(ellipse, (CrosshairCanvas.ActualWidth - layer.Size) / 2);
                Canvas.SetTop(ellipse, (CrosshairCanvas.ActualHeight - layer.Size) / 2);
                CrosshairCanvas.Children.Add(ellipse);
            }
        }
    }

    public class Layer
    {
        public double Width { get; set; }
        public double Size { get; set; }
        public double Roundness { get; set; }
        public SolidColorBrush Color { get; set; }
    }
}
