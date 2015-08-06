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
    public sealed partial class DesiredGrade : Page
    {
        public DesiredGrade()
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
        }

        private void goalGradeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            goalGradeTextBox.Text = "";
        }

        private void goalGradeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (goalGradeTextBox.Text != "")
            {
                ((App)Application.Current).grades.desiredGrade = Double.Parse(goalGradeTextBox.Text);
            }
        }

        private void goalGradeTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            goalGradeTextBox.Focus(FocusState.Programmatic);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ExamWeight));
        }
    }
}
