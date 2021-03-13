using System;
using System.IO;
using System.Windows;

namespace Vokabeltrainer
{

    public partial class MainWindow : Window
    {

        public static string[] v2 = File.ReadAllLines(@"2.txt");
        public static string[] v1 = File.ReadAllLines(@"1.txt");
        public static Random random;
        public static int rnd;
        public static int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            ShowScore.Content = $"Score: {score}";
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            random = new Random();
            rnd = random.Next(v2.Length);
            Vocabulary.Content = v2[rnd];
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            if (InputPanel.Text == v1[rnd])
            {
                Generate.Content = "Skip";
                score += 1;
                ShowScore.Content = $"Score: {score}";
                rnd = random.Next(v2.Length);
                Vocabulary.Content = v2[rnd];
                gotWrong.Content = "";
                InputPanel.Text = "";
            }
            else
            {
                gotWrong.Content = "Try again!";
            }
        }
    }
}