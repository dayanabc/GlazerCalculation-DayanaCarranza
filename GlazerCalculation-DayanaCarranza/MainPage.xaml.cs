using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalculation_DayanaCarranza
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string txtWidth = "";
        private string txtHeight = "";
        private string CtxtWidth = "";
        private string CtxtHeight = "";

       

        GlazerCalc1 glazer = new GlazerCalc1();

    
        public MainPage()
        {
            this.InitializeComponent();
        }
       
        public string getColor()
        {
            ComboBoxItem item = (ComboBoxItem)this.TintColor.SelectedItem;
            string value = item.Content.ToString();
            return value;
        }

        public bool tryParse( String C)
        {
            try
            {
                 Int32.Parse(C);
            }
            catch 
            {
                return false;
            }
            return true;
        }


        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

            String.Format("Quantaty: {0}", e.NewValue);
            glazer.Quantity = (int)e.NewValue;
            txtQuantity.Text = e.NewValue.ToString();
            var woodLength = txtWoodLength.Text;
            var glassArea = txtAreaGlass.Text;


        }



        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            double width, height, woodLength, glassArea; string WidthSize, HeightSize;

 
            //Read input and store variables 
            WidthSize = txtWidth;

             width = double.Parse(txtWidthSize.Text);

            HeightSize = txtHeight;

             height = double.Parse(txtHeightSize.Text);

            //calculation
             woodLength = 2 * (width + height) * 3.25;

              glassArea = 2 * (width * height);

            //Display result
            txtAreaGlass.Text = glassArea.ToString();

            txtWoodLength.Text = woodLength.ToString();
            glazer.Color = this.getColor();
            
            
        }

        private void WidthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Answer = txtWidthSize.Text;

            if (!(tryParse(Answer)) && txtWidthSize.Text != "")
            {
                txtWidthSize.Text = CtxtWidth;

                int Lenght = txtWidthSize.Text.Length;
                txtWidthSize.Select(Lenght, Lenght);
            }
        }

        private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Answer = txtHeightSize.Text;

            if (!(tryParse(Answer)) && txtHeightSize.Text != "")
            {
                txtHeightSize.Text = CtxtHeight;

                int Lenght = txtHeightSize.Text.Length;
                txtHeightSize.Select(Lenght, Lenght);
            }

        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            glazer.Color = TintColor.ToString();

        }
    }
}
