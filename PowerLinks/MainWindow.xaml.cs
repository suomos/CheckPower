using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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

            linkStations.Add(new LinkStation { posX = 0, posY = 0, reach = 10 });
            linkStations.Add(new LinkStation { posX = 20, posY = 20, reach = 5 });
            linkStations.Add(new LinkStation { posX = 10, posY = 0, reach = 12 });
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            //Loop all devices and print out results
            foreach (Device dev in devices)
            {
                //Calculate power for each link station compared to device
                foreach (LinkStation ls in linkStations)
                {
                    ls.power = frmls.CalcPower(dev, ls);
                }
                //Find Link Station with most power and print results
                lstOutputs.Items.Add(frmls.PrintResult(dev, linkStations.OrderByDescending(i => i.power).First()));
            }
        }
    }
}
