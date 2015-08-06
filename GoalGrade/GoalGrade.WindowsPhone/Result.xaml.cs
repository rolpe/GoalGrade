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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace GoalGrade
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Result : Page
    {
        public Result()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            resultTextBlock.Text = Math.Round(((App)Application.Current).grades.goalGrade, 0).ToString();
            var goal = ((App)Application.Current).grades.goalGrade;
            if (goal > 100)
            {
                messageTextBlock.Text = "Only extra credit can save you now.";
            }
            else if (goal >= 95)
            {
                messageTextBlock.Text = "Good luck. You'll need it.";
            }
            else if (goal >= 80)
            {
                messageTextBlock.Text = "Study hard!";
            }
            else if (goal <= 79)
            {
                messageTextBlock.Text = "You got this.";
            }
        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
