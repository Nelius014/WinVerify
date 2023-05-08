using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinVerify
{
    public partial class frmRegister : Form
    {
        string baseurl = "https://eldirfacerec-apim.azure-api.net/EldirFaceRec/";
        string accesstoken = "aaabe2cd39f94b729f93e4a7e818dddb";

        //Development URL and access token
        //string baseurl = "https://eldirfacerecdevelopment2-apim.azure-api.net/EldirFaceRecDevelopment/";
        //string baseurl = "http://localhost:7071/api/";
        // string accesstoken = "53a57fa36f9a4675b07a9550dbd6691b";

        private long siteid = 0;

        private string deviceid = "";

        private string companyid = "";

        private string siteinfo = "";

        public frmRegister()
        {
            InitializeComponent();
            var appSettings = ConfigurationManager.AppSettings;

            try
            {
                deviceid = appSettings["ID"];
                siteinfo = appSettings["SiteID"];
                if (siteinfo != "")
                {
                    string[] value = siteinfo.Split('-');
                    siteid = Convert.ToInt64(value[0]);
                }
                companyid = appSettings["Company"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private async void frmRegister_Load(object sender, EventArgs e)
        {
            try
            {
                if (deviceid == "")
                {
                    label1.Text = "This device has not been registered. Please select your site and register the device";
                }
                else
                {
                    label1.Text = "Please select your site";
                }
                await CallRegisterAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private async Task CallRegisterAsync()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                var register = new RegisterRequest()
                {
                    CompanyID = appSettings["Company"],
                    DeviceSpecs = Environment.MachineName,
                    ApplicationGUID = "7520E0D5-485D-4F71-B43F-3AD135431B75"

                };

                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", accesstoken);
                    string address = baseurl + @"Register";

                    var content = JsonSerializer.Serialize(register);

                    var requestContent = new StringContent(content, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(new Uri(address), requestContent);
                    response.EnsureSuccessStatusCode();

                    content = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;
                    options.Converters.Add(new JsonStringEnumConverter());

                    var result = JsonSerializer.Deserialize<RegisterResponse>(content, options);
                    drpSites.DataSource = result.Sites;
                    drpSites.ValueMember = "Key";
                    drpSites.DisplayMember = "Value";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private async Task RegisterDeviceAsync()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                //  KeyValuePair<long, string> item = (KeyValuePair<long, string>)drpSites.SelectedValue;

                var register = new RegisterRequest()
                {
                    CompanyID = appSettings["Company"],
                    DeviceSpecs = Environment.MachineName,
                    ApplicationGUID = "7520E0D5-485D-4F71-B43F-3AD135431B75",
                    SiteID = System.Convert.ToInt64(drpSites.SelectedValue),
                    DeviceGUID = deviceid,
                };

                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", accesstoken);
                    string address = baseurl + @"Register";

                    var content = JsonSerializer.Serialize(register);

                    var requestContent = new StringContent(content, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(new Uri(address), requestContent);

                    response.EnsureSuccessStatusCode();

                    content = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;
                    options.Converters.Add(new JsonStringEnumConverter());

                    var result = JsonSerializer.Deserialize<RegisterResponse>(content, options);

                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["ID"].Value = result.DeviceGUID;
                    config.Save(ConfigurationSaveMode.Modified);

                    siteinfo = drpSites.SelectedValue.ToString() + "-" + drpSites.Text;

                    try
                    {
                        var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                        var settings = configFile.AppSettings.Settings;

                        if (settings["ID"] == null)
                        {
                            settings.Add("ID", result.DeviceGUID);
                        }
                        else
                        {

                            settings["ID"].Value = result.DeviceGUID;
                        }

                        if (settings["SiteID"] == null)
                        {
                            settings.Add("SiteID", siteinfo);
                        }
                        else
                        {

                            settings["SiteID"].Value = siteinfo;
                        }

                        configFile.Save(ConfigurationSaveMode.Modified);

                        ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                        MessageBox.Show("Registration Successful");
                        this.Close();
                    }
                    catch (ConfigurationErrorsException)
                    {
                        Console.WriteLine("Error writing app settings");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            await RegisterDeviceAsync();
        }
    }
}
