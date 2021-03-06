﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VisualMathQuiz
{
    /// <summary>
    /// Interaction logic for SubTest.xaml
    /// </summary>
    public partial class SubTest : Window
    {
        public int subNumber1;
        public int subNumber2;
        int check = 0;
        public double subNewRand1;
        public double subNewRand2;
        public double subNewRand3;
        public double subNewAns;
        public string subNewRand1String;
        public string subNewRand2String;

        Random subRandom = new Random();

        public SubTest()
        {
            InitializeComponent();
            MainWindow.i = 1;
            SubNew();

        }

        public void SubCheck()
        {
                if (Convert.ToInt32(txtbSubAnswer.Text) == subNewRand3 - subNewRand2){
                    MainWindow.correct++;
                    MessageBox.Show("Correct!");
                } else if (Convert.ToInt32(txtbSubAnswer.Text) != subNewRand3 - subNewRand2){
                    MainWindow.incorrect++;
                    MessageBox.Show("Sorry, That's Incorrect!");
                } // end if loop
                MainWindow.i++;
                if (MainWindow.i == (MainWindow.numberQuestions)+1){
                    btnSubFinish.IsEnabled = true;
                    btnSubNext.IsEnabled = false;
                    lblSubNum1 = null;
                    lblSubNum2 = null;
            }
        }

        public void SubNew()
        {
            lblSubQuesNum.Content = MainWindow.i;
            subNewRand1 = (int)(subRandom.NextDouble() * Subtraction.subFactor) + 1;
            subNewRand2 = (int)(subRandom.NextDouble() * Subtraction.subFactor) + 1;
            subNewRand3 = (int)subNewRand1 + (int)subNewRand2;
            lblSubNum1.Content = subNewRand3;
            lblSubNum2.Content = subNewRand2;
            
        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Another C# programming project by\nKevin Lockemy, July 2013\nCopyright 2013, KLockemy Computers");
        }

        private void menuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                check = Convert.ToInt32(txtbSubAnswer.Text);
                SubCheck();
                if (MainWindow.i != (MainWindow.numberQuestions) + 1)
                {
                    SubNew();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please use only numbers.");
            } // end catch
        }

        private void txtbAddAnswer_MouseEnter(object sender, MouseEventArgs e)
        {
            txtbSubAnswer.Text = null;
        }

        private void btnAddFinish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Score frmScore = new Score();
            frmScore.Show();
        }
    }
}
