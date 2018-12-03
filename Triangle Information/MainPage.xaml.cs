using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace Triangle_Information
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void ValidateIsNumber(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(a => !char.IsDigit(a));
            //Initially I was going to use decimal, but since UWP is so annoying with binding decimals with the XAML, we are going to the code above
            //If we wanted to use decimal, we could use the code below, but we would have to create a converter to properly bind
                //Regex r = new Regex(@"^\d*$");
                //Match match = Regex.Match(args.NewText, r.ToString());
                //if (!match.Success)
                //{ 
                //    //If it doesn't match the regex, we cancel it.
                //    args.Cancel = args.NewText.Any();
                //}
        }
    }
}
