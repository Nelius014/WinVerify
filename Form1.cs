using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Configuration;
using AForge.Video;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
using AForge.Imaging.Filters;

namespace WinVerify
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection CameraList;
        private IVideoSource videoSource;
        private string deviceid;
        private string siteid;
        private string siteinfo;

        string baseurl = "https://eldirfacerec-apim.azure-api.net/EldirFaceRec/";
        string accesstoken = "aaabe2cd39f94b729f93e4a7e818dddb";

        //string baseurl = "https://eldirfacerecdevelopment2-apim.azure-api.net/EldirFaceRecDevelopment/";
        //string baseurl = "http://localhost:7071/api/";
        //string accesstoken = "53a57fa36f9a4675b07a9550dbd6691b";

        bool CameraOn = false;

        string ImageString = string.Empty;
        public Form1()
        {
            InitializeComponent();
            GetCameras();
          
          
            this.Width = 800;
            this.Height = 600;
           
        }

        private void btnStartCam_Click(object sender, EventArgs e)
        {
            try
            {
                if (CameraOn == false)
                {
                    videoSource = new VideoCaptureDevice(CameraList[drpCameras.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    videoSource.Start();
                    SetCameraButton();
                }
                else
                {
                    videoSource.SignalToStop();
                    if (videoSource != null && videoSource.IsRunning && pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    SetCameraButton();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
            finally
            {

            }
        }

        public void GetCameras()
        {
            try
            {
                CameraList = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                foreach (FilterInfo videoDevice in CameraList)
                {
                    drpCameras.Items.Add(videoDevice.Name);
                }
                if (drpCameras.Items.Count > 0)
                {
                    drpCameras.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No video sources found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private void SetCameraButton()
        {
            try
            {
                if (CameraOn == false)
                {
                    btnStartCam.Text = "Stop Camera";
                    CameraOn = true;

                }
                else
                {
                    btnStartCam.Text = "Start Camera";
                    CameraOn = false;
                }

                btnCapture.Enabled = CameraOn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                // create filter
                Mirror filter = new Mirror(false, true);
                // apply the filter
                filter.ApplyInPlace(bitmap);
                pictureBox1.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                radPictureBox1.Image = pictureBox1.Image;

                var bitmap = new Bitmap(radPictureBox1.Width, radPictureBox1.Height);

                radPictureBox1.DrawToBitmap(bitmap, radPictureBox1.ClientRectangle);
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Jpeg);

                ms.Position = 0;

                byte[] bytes = ms.ToArray();

                ImageString = Convert.ToBase64String(bytes, 0, bytes.Length);

                btnCheckIn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }

        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                deviceid = appSettings["ID"];

                siteinfo = appSettings["SiteID"];
                if (siteinfo != "")
                {
                    string[] value = siteinfo.Split('-');
                    siteid = value[0];
                }

                if (txtEmployeeNumber.Text != "")
                {
                    lblFullName.Text = "Fullname :";
                    lblMessage.Text = "Message :";
                    lblSuccess.Text = "Success :";
                    lstAddInfo.Items.Clear();
                    lblDevice.Visible = false;
                    await CheckInAsync();
                }
                else
                {
                    MessageBox.Show("Please provide an Employee Number");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
                throw;
            }
            
        }

        private async Task CheckInAsync()
        {
            try
            {
                var detectSource = new Attendance()
                {
                    Image = ImageString,
                    DateTime = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"),
                    //"28/11/2021 14:54:17",
                    ClockStatus = 1,
                    DeviceID = deviceid,

                    EmployeeID = txtEmployeeNumber.Text,
                    Latitude = "",
                    Longitude = "",
                    ApplicationGUID = "F79528CF-768A-4001-9632-0226A3B700A9"
                };


                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", accesstoken);
                    string address = baseurl + @"Verification";

                    var content = JsonSerializer.Serialize(detectSource);

                    var requestContent = new StringContent(content, Encoding.UTF8, "application/json");



                    var response = await httpClient.PostAsync(new Uri(address), requestContent);
                    response.EnsureSuccessStatusCode();

                    content = await response.Content.ReadAsStringAsync();


                    var options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;
                    options.Converters.Add(new JsonStringEnumConverter());

                    var attendanceResponse = JsonSerializer.Deserialize<VerifyResponse>(content, options);

                    lblFullName.Text = "Fullname : " + attendanceResponse.FullName;
                    lblSuccess.Text = "Success : " + attendanceResponse.Success.ToString();
                    if (attendanceResponse.Message != null)
                    {
                        lblMessage.Text = "Message : " + attendanceResponse.Message.ToString();
                    }
                    //lblStatus.Text = "Status : " + attendanceResponse.UserStatus.ToString();

                    if (attendanceResponse.Success == false)
                    {
                        lblDevice.Text = "Device ID " + deviceid;
                        lblDevice.Visible = true;
                    }

                    lstAddInfo.Items.Clear();

                    if (attendanceResponse.AdditionalData != null)
                    {

                        foreach (var item in attendanceResponse.AdditionalData)
                        {
                            if (item.Value != "")
                            {
                                lstAddInfo.Items.Add(item.Key + " : " + item.Value);
                            }

                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private void btnSite_Click(object sender, EventArgs e)
        {
            try
            {
                var F = new frmRegister();

                F.ShowDialog();

                var appSettings = ConfigurationManager.AppSettings;
                deviceid = appSettings["ID"];
                siteid = appSettings["SiteID"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                deviceid = appSettings["ID"];
                siteid = appSettings["SiteID"];

                siteinfo = appSettings["SiteID"];
                if (siteinfo != "")
                {
                    string[] value = siteinfo.Split('-');
                    siteid = value[0];
                    lblSite.Text = "Current site : " + value[1];
                }

                if (deviceid == "")
                {
                    var F = new frmRegister();

                    F.ShowDialog();
                }
                else
                {
                    deviceid = appSettings["ID"];
                    siteinfo = appSettings["SiteID"];
                    if (siteinfo != "")
                    {
                        string[] value = siteinfo.Split('-');
                        siteid = value[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured {0}", ex.Message);
            }
        }
    }
}
