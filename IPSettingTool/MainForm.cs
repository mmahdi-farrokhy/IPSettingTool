using IPSettingTool.NetworkUtilities;

namespace IPSettingTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitAdapterNamesCombo();
            adapterNameCombo.SelectedItem = "Wi-Fi";
        }

        private void InitAdapterNamesCombo()
        {
            foreach (string adapterName in NetworkConfiguration.LocalNetworkAdapaterNameList())
                adapterNameCombo.Items.Add(adapterName);
        }

        private void adapterNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentIPTxt.Text = NetworkConfiguration.GetLocalIPv4Address(adapterNameCombo.SelectedItem.ToString());
            }
            catch (SystemNotConnectedToNetWorkException)
            {
                currentIPTxt.Text = "";
                MessageBox.Show("This adapter is not accessible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setNewIPBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newIPTxt.Text))
                MessageBox.Show("New IP address is empty", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                var adapterName = adapterNameCombo.SelectedItem.ToString();
                NetworkConfiguration.SetNewStaticIPAddress(adapterName, newIPTxt.Text.Trim());
                newIPTxt.Text = "";
                currentIPTxt.Text = NetworkConfiguration.GetLocalIPv4Address(adapterName);
            }
        }
    }
}
