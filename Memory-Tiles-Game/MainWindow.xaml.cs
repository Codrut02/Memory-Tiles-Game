using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Memory_Tiles_Game
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            profilesViewList.ItemsSource = Profiles;
            imageViewList.ItemsSource = AvatarCollection;
        }

        private readonly List<string> AvatarCollection = new List<string>
        {
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\bull.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\cat.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\cow.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\elephant.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\lion.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\mouse.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\pig.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\racoon.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\thingy.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\tiger.png"
        };

        private ObservableCollection<Profile> Profiles { get; set; } = new ObservableCollection<Profile>
        {
            new Profile("Gigi", "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\bull.png"),
            new Profile("Codrut", "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\cat.png"),
            new Profile("mara", "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\cow.png"),
            new Profile("George", "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\pig.png"),
            new Profile("susu", "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\tiger.png")
        };

        private void BNewUser_Click(object sender, RoutedEventArgs e)
        {
            string avatarPathDestination;

            if (imageViewList.SelectedItem == null)
            {
                avatarPathDestination = "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Avatars\\bull.png";
            }
            else
            {
                avatarPathDestination = (string)imageViewList.SelectedItem;
            }

            Profiles.Add(new Profile(textBox1.Text, avatarPathDestination));
        }

        private void BDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Profiles.Remove(profilesViewList.SelectedItem as Profile);
        }

        private void BPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
