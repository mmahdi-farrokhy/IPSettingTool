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
                var adapterName = adapterNameCombo.SelectedItem.ToString() ?? "";
                currentIPTxt.Text = NetworkConfiguration.GetLocalIPv4Address(adapterName);
                currentGatewayTxt.Text = NetworkConfiguration.GetGatewayAddress(adapterName);
            }
            catch (SystemNotConnectedToNetWorkException)
            {
                currentIPTxt.Text = "";
                MessageBox.Show("This adapter is not accessible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setNewIPBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newIPTxt.Text) || string.IsNullOrEmpty(newGatewayTxt.Text))
            {
                MessageBox.Show("Enter both new IP and gateway", "Invalid Configuration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var adapterName = adapterNameCombo.SelectedItem.ToString() ?? "";
                var newGateway = newGatewayTxt.Text.Trim();
                var newIP = newIPTxt.Text.Trim();
                //NetworkConfiguration.SetNewGatewayAddress(adapterName, newGateway);
                //NetworkConfiguration.SetNewStaticIPAddress(adapterName, newIP);
                //newIPTxt.Text = "";
                //newGatewayTxt.Text = "";
                //currentIPTxt.Text = NetworkConfiguration.GetLocalIPv4Address(adapterName);
                //currentGatewayTxt.Text = NetworkConfiguration.GetGatewayAddress(adapterName);
                NetworkConfiguration.SetIP(adapterName,newIP,newGateway);
            }
        }
    }
}
