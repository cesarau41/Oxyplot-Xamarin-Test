using OxyPlot;
using OxyPlot.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OxyplotTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel = new MainPageViewModel();
        public MainPage()
        {
            InitializeComponent();
            oxyScatterPlotView.BindingContext = viewModel;
            oxyScatterPlotView.SetBinding(PlotView.ModelProperty, "ScatterPlotModel");

            oxyLinePlotView.BindingContext = viewModel;
            oxyLinePlotView.SetBinding(PlotView.ModelProperty, "LinePlotModel");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            viewModel.isPLaying = !viewModel.isPLaying;
            await viewModel.generateData();
        }
    }
}
