using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Memory_Tiles_Game
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Profile> Profiles { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            ReadProfilesFromFile();
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

        private void ReadProfilesFromFile()
        {
            var reader = new StreamReader("C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Memory-Tiles-Game\\ProfileTxtDataBase.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(new char[] { ' ' });
                Profiles.Add(new Profile(words[0], words[1]));
            }
            reader.Close();
        }

        private async void BNewUser_Click(object sender, RoutedEventArgs e)
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

            if (Profiles.Where(p => p.Name == textBox1.Text).Any() || textBox1.Text.Any(c => char.IsWhiteSpace(c)) || string.IsNullOrEmpty(textBox1.Text))
            {
                SameNamePopup.IsOpen = true;
            }
            else
            {
            Profiles.Add(new Profile(textBox1.Text, avatarPathDestination));
            using StreamWriter file = new("C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Memory-Tiles-Game\\ProfileTxtDataBase.txt", append: true);
            await file.WriteLineAsync(textBox1.Text + " " + avatarPathDestination);
            }
        }

        private void BDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Profile profileToRemove = profilesViewList.SelectedItem as Profile;

            Profiles.Remove(profileToRemove);

            string line = null;
            string line_to_delete = profileToRemove.Name + " " + profileToRemove.AvatarDestination;
            string text = "";

            using StreamReader reader = new("C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Memory-Tiles-Game\\ProfileTxtDataBase.txt");
            while ((line = reader.ReadLine()) != null)
            {
                if (String.Compare(line, line_to_delete) == 0)
                    continue;

                text += line + '\n';
            }
            reader.Close();
            using StreamWriter writer = new("C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\Memory-Tiles-Game\\ProfileTxtDataBase.txt");
            writer.Write(text);
        }

        private void BPlay_Click(object sender, RoutedEventArgs e)
        {
            if (profilesViewList.SelectedItem == null)
            {
                StandardPopup.IsOpen = true;
            }
            else
            {
                PlayMenu playMenu = new();
                this.Visibility = Visibility.Hidden;
                playMenu.Owner = this;
                playMenu.ShowDialog();
            }
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            if (StandardPopup.IsOpen)
            {
                StandardPopup.IsOpen = false;
            }
        }

        private void SameNamePopup_Closed(object sender, EventArgs e)
        {
            if (SameNamePopup.IsOpen)
            {
                SameNamePopup.IsOpen = false;
            }
        }
    }
}
