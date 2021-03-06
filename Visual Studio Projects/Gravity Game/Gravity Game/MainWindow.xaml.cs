﻿using System;
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

namespace Gravity_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBlock resultsTextField;
        private TextBlock velocityTextField;

        private ComboBox planetComboBox;

        private Label planetLabel;
        private Label velocityLabel;
        private Label resultLabel;

        private Button startButton;
        private Button dropButton;
        private Button resetButton;
        private Panel drawingPanel;

        private double boxLocation;
        private double boxVelocity;
        private int boxWith; 
        


        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
