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

namespace AzureMLNET.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IModelLoader<AzureMLONNX.Input,AzureMLONNX.Output> _modelLoader;

        public MainWindow()
        {
            InitializeComponent();
            _modelLoader = new AzureMLModelLoader();
        }

        private void PredictFareButton_Click(object sender, RoutedEventArgs e)
        {

            var model = _modelLoader.GetSavedModel("azureml-mlnet-model");
            var predictionEngine = _modelLoader.GetPredictionEngine(model);
            var input = new AzureMLONNX.Input
            {
                VendorId = (VendorId.SelectedItem as ComboBoxItem).Content as string,
                RateCode = long.Parse((RateCode.SelectedItem as ComboBoxItem).Content as string),
                PassengerCount = long.Parse((PassengerCount.SelectedItem as ComboBoxItem).Content as string),
                TripTimeInSecs = long.Parse(TripTimeSecs.Text),
                TripDistance = float.Parse(TripDistance.Text),
                PaymentType = (PaymentType.SelectedItem as ComboBoxItem).Content as string
            };

            PredictedFare.Content = predictionEngine.Predict(input).PredictedFare.First();
        }
    }
}
