using BoreholeVolume;
using BoreholeVolume.Data;
using BoreholeVolume.Engine;
using System.Windows.Forms;

namespace WellboreVolume
{

    public partial class WellboreForm : Form
    {
        public DataAtDepth[] _data = DataLoader.LoadInput();

        public WellboreForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            BoreholeVolumeCalculation vc = new BoreholeVolumeCalculation(
                new List<ICompensation> {
                    new MissingTemperatureCompensation(),
                    new MissingRadiusCompensation(),
                    new RadiusCompensation(),
                }
            );

            double volume = vc.Calculate(_data);
            resultLabel.Text = $"Volume(m3): {volume}";
        }
    }
}