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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GoalGrade
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

        //STEP 1:

        private void currentGradeTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            currentGradeTextBox.Focus(FocusState.Programmatic);
        }

        private void currentGradeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            currentGradeTextBox.Text = "";
        }

        private void currentGradeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currentGradeTextBox.Text != "")
            {
                ((App)Application.Current).grades.currentGrade = Double.Parse(currentGradeTextBox.Text);
            }
        }

        private void currentGradeTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                DesiredGradeTextBlock.Visibility = Visibility.Visible;
                goalGradeTextBox.Visibility = Visibility.Visible;
                goalGradeTextBox.Focus(FocusState.Programmatic);
                Continue2.Visibility = Visibility.Visible;
                Continue1.Visibility = Visibility.Collapsed;
                e.Handled = true;
            }
        }

        private void Continue1_Click(object sender, RoutedEventArgs e)
        {
            DesiredGradeTextBlock.Visibility = Visibility.Visible;
            goalGradeTextBox.Visibility = Visibility.Visible;
            goalGradeTextBox.Focus(FocusState.Programmatic);
            Continue2.Visibility = Visibility.Visible;
            Continue1.Visibility = Visibility.Collapsed;
        }

        //STEP 2:

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

        private void goalGradeTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                examWeightTextBlock.Visibility = Visibility.Visible;
                examWeightTextBox.Visibility = Visibility.Visible;
                examWeightTextBox.Focus(FocusState.Programmatic);
                Calculate.Visibility = Visibility.Visible;
                Continue2.Visibility = Visibility.Collapsed;
                e.Handled = true;
            }
        }

        private void Continue2_Click(object sender, RoutedEventArgs e)
        {
            examWeightTextBlock.Visibility = Visibility.Visible;
            examWeightTextBox.Visibility = Visibility.Visible;
            examWeightTextBox.Focus(FocusState.Programmatic);
            Calculate.Visibility = Visibility.Visible;
            Continue2.Visibility = Visibility.Collapsed;
        }

        //STEP 3:

        private void examWeightTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            examWeightTextBox.Text = "";
        }

        private void examWeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (examWeightTextBox.Text != "")
            {
                ((App)Application.Current).grades.examWeight = (Double.Parse(examWeightTextBox.Text)) / 100;
            }
        }

        private void examWeightTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                youWillNeedTextBlock.Visibility = Visibility.Visible;
                ((App)Application.Current).grades.calculateGoalGrade();
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
                startOverButton.Visibility = Visibility.Visible;
                resultTextBlock.Visibility = Visibility.Visible;
                messageTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            youWillNeedTextBlock.Visibility = Visibility.Visible;
            ((App)Application.Current).grades.calculateGoalGrade();
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
            startOverButton.Visibility = Visibility.Visible;
            resultTextBlock.Visibility = Visibility.Visible;
            messageTextBlock.Visibility = Visibility.Visible;
        }

        private void startOverButton_Click(object sender, RoutedEventArgs e)
        {
            currentGradeTextBox.Focus(FocusState.Programmatic);
            goalGradeTextBox.Visibility = Visibility.Collapsed;
            DesiredGradeTextBlock.Visibility = Visibility.Collapsed;
            examWeightTextBlock.Visibility = Visibility.Collapsed;
            examWeightTextBox.Visibility = Visibility.Collapsed;
            Calculate.Visibility = Visibility.Collapsed;
            startOverButton.Visibility = Visibility.Collapsed;
            messageTextBlock.Visibility = Visibility.Collapsed;
            resultTextBlock.Visibility = Visibility.Collapsed;
            youWillNeedTextBlock.Visibility = Visibility.Collapsed;
            Continue1.Visibility = Visibility.Visible;
        }
    }
}
