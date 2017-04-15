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
using EzPzRPG.classes;

namespace EzPzRPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<Character> CharactersLoaded = new List<Character>();

        public MainWindow()
        {
            InitializeComponent();
            DummyMain.Dummy();
        }
        private void startSlowpoke() {
            System.Timers.Timer Slowpoke = new System.Timers.Timer { Interval = 1000 };
            Slowpoke.Elapsed += (sender, e) => {
                foreach (Character c in CharactersLoaded) { 
                    c.Update();
                    if (c.Dead)
                        Slowpoke.Stop();
                }
            };
            Slowpoke.AutoReset = true;
            Slowpoke.Enabled = true;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Dummy Character Init
            Character Chosimba = new Character("Chosimba", 1000, 500);
            CharactersLoaded.Add(Chosimba);

            Boon Speedy = new classes.Boon("Speedy", "GO FAST MAN", Boon.Target.Speed, 10.0, true,false, DateTime.Now.AddMinutes(10));
            Boon Cozy = new Boon("Cozy Lava", "Feelin' comfy in a warm, molten blanket.", Boon.Target.Health, 15.0, false, false, DateTime.Now.AddSeconds(5));
            Boon Ants = new Boon("FIRE ANTS!", "Itchy as all hell...", Boon.Target.Health, 30.0, false, true, DateTime.Now.AddSeconds(10));
            Chosimba.ApplyBoon(Speedy);
            Chosimba.ApplyBoon(Cozy);
            Chosimba.ApplyBoon(Ants);

            // Start Server Tick
            startSlowpoke();

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClientView clv = new ClientView();
            clv.Show();
        }
    }
}
