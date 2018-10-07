using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PowerLinks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Device> devices = new ObservableCollection<Device>();
        ObservableCollection<LinkStation> linkStations = new ObservableCollection<LinkStation>();
        Formulas frmls = new Formulas();

        public MainWindow()
        {
            InitializeComponent();
            GetDefaults();
        }

        private void GetDefaults()
        {
            devices.Add(new Device { posX = 0, posY = 0 });
            devices.Add(new Device { posX = 100, posY = 100 });
            devices.Add(new Device { posX = 15, posY = 10 });
            devices.Add(new Device { posX = 18, posY = 18 });

            linkStations.Add(new LinkStation { posX = 0, posY = 0, powerReach = 10 });
            linkStations.Add(new LinkStation { posX = 20, posY = 20, powerReach = 5 });
            linkStations.Add(new LinkStation { posX = 10, posY = 0, powerReach = 12 });
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            foreach (Device dev in devices)
            {
                foreach (LinkStation ls in linkStations)
                {
                    ls.power = frmls.CalcPower(ls, frmls.CalcDistance(dev, ls));
                }
                lstOutputs.Items.Add(frmls.PrintResult(dev, linkStations.OrderByDescending(i => i.power).First()));
            }
        }
    }
}
