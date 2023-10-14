﻿
using CRUD_2;
using System;
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

namespace CRUD_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> DatabaseUsers { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Create()
        {

            using (DataContext context = new DataContext())
            {
                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                if (name != null && address != null)
                {
                    context.Users.Add(new User() { Name = name, LastName = address });
                    context.SaveChanges();
                }

            }
        }

        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseUsers = context.Users.ToList();
                ItemList.ItemsSource = DatabaseUsers;
            }

        }

        public void Update()
        {


            using (DataContext context = new DataContext())
            {

                User selectedUser = ItemList.SelectedItem as User;

                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                if (name != null && address != null)
                {

                    User user = context.Users.Find(selectedUser.UserId);
                    user.Name = name;
                    user.LastName = address;

                    context.SaveChanges();
                }

            }



        }

        public void Delete()
        {


            using (DataContext context = new DataContext())
            {

                User selectedUser = ItemList.SelectedItem as User;

                if (selectedUser != null)
                {
                    User user = context.Users.Single(x => x.UserId == selectedUser.UserId);

                    context.Remove(user);
                    context.SaveChanges();

                }



            }



        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            ItemList.Items.Clear();

        }
    }
}
