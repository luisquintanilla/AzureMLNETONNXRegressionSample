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
using AzureMLNET.Shared;
using AzureMLNET.Shared.Schemas;
using Microsoft.ML;

namespace AzureMLNET.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PredictionEngine<AzureMLONNX.Input, AzureMLONNX.Output> _predictionEngine;

        public MainWindow()
        {
            InitializeComponent();
            
            // Initialize Model Loader
            var modelLoader = new AzureMLModelLoader();

            // Get saved ML.NET Pipeline
            var model = modelLoader.GetSavedModel("azureml-mlnet-model");

            // Create PredictionEngine
            _predictionEngine = modelLoader.GetPredictionEngine(model);
        }

        private void PredictFareButton_Click(object sender, RoutedEventArgs e)
        {
            var input = new AzureMLONNX.Input
            {
                VendorId = (VendorId.SelectedItem as ComboBoxItem).Content as string,
                RateCode = long.Parse((RateCode.SelectedItem as ComboBoxItem).Content as string),
                PassengerCount = long.Parse((PassengerCount.SelectedItem as ComboBoxItem).Content as string),
                TripTimeInSecs = long.Parse(TripTimeSecs.Text),
                TripDistance = float.Parse(TripDistance.Text),
                PaymentType = (PaymentType.SelectedItem as ComboBoxItem).Content as string
            };

            PredictedFare.Content = _predictionEngine.Predict(input).PredictedFare.First();
        }
    }
}
