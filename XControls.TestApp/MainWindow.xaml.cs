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
using XControls.NotifierButton;

namespace XControls.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool mFlipFlop = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.DoubleUpDown.TextChanged += DoubleUpDown_TextChanged;
            this.SetZeroDouble.Click += SetZeroDouble_Click;
            this.AddInformation.Click += AddInformation_Click;
            this.AddQuestion.Click += AddQuestion_Click;
        }

        /// <summary>
        /// Handles the Click event of the AddInformation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        void AddInformation_Click(object sender, RoutedEventArgs e)
        {
            InformationViewModel lViewModel = new InformationViewModel("Not", "Information") { Title = "Pouet pouet" };
            lViewModel.Message = "Le Lorem Ipsum est simplement du faux texte employé dans la composition et la mise en page avant impression. Le Lorem Ipsum est le faux texte standard de l'imprimerie depuis les années 1500, quand un peintre anonyme assembla ensemble des morceaux de texte pour réaliser un livre spécimen de polices de texte. Il n'a pas fait que survivre cinq siècles, mais s'est aussi adapté à la bureautique informatique, sans que son contenu n'en soit modifié. Il a été popularisé dans les années 1960 grâce à la vente de feuilles Letraset contenant des passages du Lorem Ipsum, et, plus récemment, par son inclusion dans des applications de mise en page de texte, comme Aldus PageMaker.";
            this.NotifierButton.ViewModel.AddNotification(lViewModel);
        }

        /// <summary>
        /// Handles the Click event of the AddQuestion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            this.NotifierButton.ViewModel.AddNotification(new QuestionViewModel("Not", "Question") { Message = "Nouvelle notification!", CanCancel = this.mFlipFlop, ShowOnRaised = true });
            this.mFlipFlop = !this.mFlipFlop;
        }

        /// <summary>
        /// Handles the Click event of the SetZeroDouble control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        void SetZeroDouble_Click(object sender, RoutedEventArgs e)
        {
            this.DoubleUpDown.Text = "-0";
        }

        /// <summary>
        /// Handles the TextChanged event of the DoubleUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="string"/> instance containing the event data.</param>
        void DoubleUpDown_TextChanged(object sender, RoutedPropertyChangedEventArgs<string> e)
        {
            Console.WriteLine(e.NewValue);
        }
    }
}
