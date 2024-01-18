using OpcLabs.EasyOpc.UA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HMI_Eray
{
    public partial class Form1 : Form
    {
        private bool isRunningz = true;
        private bool isRunningy = true;
        private bool isRunning = true;
        private string previousLabelText = "";
        private System.Windows.Forms.Timer motorRunCheckTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeTimer();
            InitializeComponent();

        }


        private readonly EasyUAClient easyUAClient1 = new EasyUAClient();

        private UAEndpointDescriptor server = "opc.tcp://localhost:4841";
        private UANodeDescriptor motorRunNode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.MotorRun";
        private UANodeDescriptor tag1 = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.anlık_deger_x";  //X ANLIK NODE ID
        private UANodeDescriptor hedefDegerNode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.hedef_deger_X";
        private UANodeDescriptor x_axisgoNode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.X_AXISGO";
        private UANodeDescriptor start = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Tag000";
        private UANodeDescriptor stop = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Tag001";
        private UANodeDescriptor tag2 = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.anlık_Deger_y"; //Y ANLIK NODE ID
        private UANodeDescriptor hedefdegernodey = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Hedef_deger_Y";
        private UANodeDescriptor y_axisgonode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Y_AXISGO";
        private UANodeDescriptor tag3 = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.anlık_deger_z";
        private UANodeDescriptor hedefdegernodez = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.hedef_deger_Z";
        private UANodeDescriptor z_axisgonode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Z_AXİSGO";
        private UANodeDescriptor xaxisYavasHizButtonNode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Xaxis_yavashızbuton";
        private UANodeDescriptor xaxishizlibuttonnode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Xaxis_2xhızbuton";
        private UANodeDescriptor yaxisyavashizbuttonnode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Yaxis_yavashizbuton";
        private UANodeDescriptor yaxishizlibuttonnode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Yaxis_2xhızbuton";
        private UANodeDescriptor zaxisyavashizbuttonnode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Zaxis_yavashizbuton";
        private UANodeDescriptor zaxishizlibuttonnode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Zaxis_2xhızbuton";
        private UANodeDescriptor hedeflebutonopcnode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.hedeflebutonuopc";
        private UANodeDescriptor yhedeflebutonopcnode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Y_hedeflebutonuopc";
        private UANodeDescriptor zhedeflebutonopcnode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Z_hedeflebutonuopc";
        private UANodeDescriptor xhedefegittinode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.X_Gitti";
        private UANodeDescriptor yhedefegittinode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Y_Gitti";
        private UANodeDescriptor zhedefegittinode = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.Z_Gitti";
        private bool continuousReading = true;
        private bool isValueTrue = true;
        private bool isValueFalse = false;
        private string previousKonumYText = "";
        private string previousKonumZText = "";
        private bool isValueTruehedef = true;
        private bool isValueFalsehedef = false;
        private bool isValueTruehedefY = true;
        private bool isValueFalsehedefY = false;
        private bool isValueTruehedefZ = true;
        private bool isvaluefalsehedefZ = false;


        private void InitializeTimer()
        {
            motorRunCheckTimer.Interval = 100; // Her 1000 milisaniyede bir kontrol et (örneğin 1 saniyede bir)
            motorRunCheckTimer.Tick += MotorRunCheckTimer_Tick;
            motorRunCheckTimer.Start();
        }
        private void MotorRunCheckTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu oku
                object motorRunValue = easyUAClient1.ReadValue(server, motorRunNode);

                // Okunan değeri bool türüne çevir
                if (motorRunValue is bool motorRunBool)
                {
                    // motordurum değişkenini kullanarak labelmotordurum kontrolünün metnini ve rengini ayarla
                    if (motorRunBool)
                    {
                        labelmotordurum.Text = "MOTOR AÇIK";
                        labelmotordurum.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelmotordurum.Text = "MOTOR KAPALI";
                        labelmotordurum.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    MessageBox.Show("Düğüm değeri bool türünde değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {


            Thread checkLabelThread = new Thread(CheckLabelStatus);
            checkLabelThread.Start();
            Thread checkLabelThready = new Thread(CheckLabelStatusY);
            checkLabelThready.Start();
            Thread checkLabelThreadz = new Thread(CheckLabelStatusZ);
            checkLabelThreadz.Start();


            {

            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // MonitoredItemChanged olayına abone olunur
            easyUAClient1.MonitoredItemChanged += easyUAClient1_MonitoredItemChanged;

            
            ///////    Z EKSENİ İÇİN ANLIK DEĞER KODLARI ////////
            easyUAClient1.SubscribeMultipleMonitoredItems(new[]
            {
        new EasyUAMonitoredItemArguments(null, server, tag3, 100),
    });
            Task.Run(() =>
            {
                while (continuousReading)
                {
                    object value_z = easyUAClient1.ReadValue(server, tag3);
                    UpdateTextBoxValueZ(value_z);

                    Thread.Sleep(100);
                }

            });
            ///////    Y EKSENİ İÇİN ANLIK DEĞER KODLARI ////////
            easyUAClient1.SubscribeMultipleMonitoredItems(new[]
            {
        new EasyUAMonitoredItemArguments(null, server, tag2, 100),
    });
            Task.Run(() =>
            {
                while (continuousReading)
                {
                    object value_y = easyUAClient1.ReadValue(server, tag2);
                    UpdateTextBoxValueY(value_y);

                    Thread.Sleep(100);
                }

            });
            //////////////////////Xhedefgittinode////////////////
            easyUAClient1.SubscribeMultipleMonitoredItems(new[]
           {
        new EasyUAMonitoredItemArguments(null, server, xhedefegittinode, 100),
    });
            Task.Run(() =>
            {
                while (continuousReading)
                {
                    object valuexgitti = easyUAClient1.ReadValue(server, tag2);
                    //readxhedefgittinodevalue(valuexgitti);

                    Thread.Sleep(100);
                }

            });



            ///////    X EKSENİ İÇİN ANLIK DEĞER KODLARI ////////

            // Belirli bir OPC UA etiketine 100 milisaniyelik bir örnekleme aralığıyla abone olunur
            easyUAClient1.SubscribeMultipleMonitoredItems(new[]
            {
        new EasyUAMonitoredItemArguments(null, server, tag1, 100),
    });

            // Otomatik olarak başlatmak için bir thread kullanılır
            Task.Run(() =>
            {

                while (continuousReading)
                {
                    // OPC UA etiketinin mevcut değerini okuyun
                    object value = easyUAClient1.ReadValue(server, tag1);

                    // Metin kutusunu dönüştürülmüş değerle güncelleyin
                    UpdateTextBoxValueX(value);

                    // 100 ms bekleyin
                    Thread.Sleep(100);
                }
            });
        }
        private void CheckLabelStatusZ()
        {
            while (isRunningz)
            {
                if (anlıkkonumZ.InvokeRequired)
                {
                    anlıkkonumZ.Invoke(new Action(() => { CheckAndSetVisibilityZ(); }));
                }
                else
                {
                    CheckAndSetVisibilityZ();
                }
                Thread.Sleep(450);
            }
        }
        private void CheckAndSetVisibilityZ()
        {
            if (anlıkkonumZ.Text == previousKonumZText)
            {
                if (pictureBox3.InvokeRequired)
                {
                    pictureBox3.Invoke(new Action(() => pictureBox3.Visible = false));
                }
                else { pictureBox3.Visible = false; }

            }
            else
            {
                if (pictureBox3.InvokeRequired)
                {
                    pictureBox3.Invoke(new Action(() => pictureBox3.Visible = true));
                }
                else
                {
                    pictureBox3.Visible = true;
                }
                previousKonumZText = anlıkkonumZ.Text;
            }
        }




        // Y EKSENİ LAMBA ÖTME
        private void CheckLabelStatusY()
        {
            while (isRunningy)
            {
                if (anlıkkonumy.InvokeRequired)
                {
                    anlıkkonumy.Invoke(new Action(() => { CheckAndSetVisibilityY(); }));
                }
                else
                {
                    CheckAndSetVisibilityY();

                }
                Thread.Sleep(450);
            }
        }

        private void CheckAndSetVisibilityY()
        {
            if (anlıkkonumy.Text == previousKonumYText)
            {
                if (pictureBox2.InvokeRequired)
                {
                    pictureBox2.Invoke(new Action(() => pictureBox2.Visible = false));
                }
                else { pictureBox2.Visible = false; }

            }
            else
            {
                if (pictureBox2.InvokeRequired)
                {
                    pictureBox2.Invoke(new Action(() => pictureBox2.Visible = true));
                }
                else
                {
                    pictureBox2.Visible = true;
                }
                previousKonumYText = anlıkkonumy.Text;
            }
        }
        //X EKSENİ LAMBA ÖTME
        private void CheckLabelStatus()
        {
            while (isRunning)
            {
                if (anlıklable.InvokeRequired)
                {
                    anlıklable.Invoke(new Action(() => CheckAndSetVisibility()));
                }
                else
                {
                    CheckAndSetVisibility();
                }

                Thread.Sleep(450); //350ms bekleme

            }
        }
        private void CheckAndSetVisibility()
        {
            if (anlıklable.Text == previousLabelText)
            {
                if (pictureBox1.InvokeRequired)
                {
                    pictureBox1.Invoke(new Action(() => pictureBox1.Visible = false));
                }
                else { pictureBox1.Visible = false; }

            }
            else
            {
                if (pictureBox1.InvokeRequired)
                {
                    pictureBox1.Invoke(new Action(() => pictureBox1.Visible = true));
                }
                else
                {
                    pictureBox1.Visible = true;
                }
                previousLabelText = anlıklable.Text;
            }



        }





        private void easyUAClient1_MonitoredItemChanged(object sender, EasyUAMonitoredItemChangedEventArgs e)
        {
            // İşlemin başarılı olup olmadığını kontrol edin
            if (!e.Succeeded)
                return;

            if (e.Arguments.NodeDescriptor == tag3)
            {
                object value_z = easyUAClient1.ReadValue(server, tag3);
                UpdateTextBoxValueZ(value_z);
            }

            if (e.Arguments.NodeDescriptor == tag2)
            {
                object value_y = easyUAClient1.ReadValue(server, tag2);
                UpdateTextBoxValueY(value_y);
            }

            // Değişen öğenin ilgi çeken öğe (tag1) olup olmadığını kontrol edin
            if (e.Arguments.NodeDescriptor == tag1)
            {
                // OPC UA etiketinin mevcut değerini okuyun
                object value = easyUAClient1.ReadValue(server, tag1);

                // Metin kutusunu dönüştürülmüş değerle güncelleyin
                UpdateTextBoxValueX(value);
            }
            if (e.Arguments.NodeDescriptor == xhedefegittinode)
            {
                object valuexgitti = easyUAClient1.ReadValue(server, xhedefegittinode);
                //readxhedefgittinodevalue(valuexgitti);

            }
        }

        private void UpdateTextBoxValueZ(object value_z)
        {
            if (anlıkkonumZ.InvokeRequired)
            {
                anlıkkonumZ.Invoke(new Action(() => anlıkkonumZ.Text = Convert.ToDouble(value_z).ToString("f1")));
            }
            else
            {
                anlıkkonumZ.Text = Convert.ToDouble(value_z).ToString("f1");
            }
        }

        private void UpdateTextBoxValueY(object value_y)
        {
            if (anlıkkonumy.InvokeRequired)
            {
                anlıkkonumy.Invoke(new Action(() => anlıkkonumy.Text = Convert.ToDouble(value_y).ToString("f1")));
            }
            else
            {
                anlıkkonumy.Text = Convert.ToDouble(value_y).ToString("f1");
            }
        }

        // Metin kutusunu güncelleyen yardımcı bir metod
        private void UpdateTextBoxValueX(object value)
        {
            if (anlıklable.InvokeRequired)
            {
                // Eğer metin kutusu başka bir thread tarafından erişiliyorsa Invoke kullanılır
                anlıklable.Invoke(new Action(() => anlıklable.Text = Convert.ToDouble(value).ToString("f1")));
            }
            else
            {
                // Eğer metin kutusu aynı thread tarafından erişiliyorsa doğrudan güncelleme yapılır
                anlıklable.Text = Convert.ToDouble(value).ToString("f1");
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form kapanırken sürekli okuma işlemi durdurulur
            continuousReading = false;

            // Tüm izlenen öğelerden aboneliği kaldırın
            easyUAClient1.UnsubscribeAllMonitoredItems();
            isRunning = false; // Uygulama kapatıldığında thread'i durdur

        }
        private void UpdateKalanLabelX()
        {
            if (double.TryParse(anlıklable.Text, out double anlikKonumx) && double.TryParse(label1.Text, out double gidilecekYerX))
            {
                // "kalanlabely" label'ına kalan değeri yaz
                if (InvokeRequired)
                {
                    Invoke(new Action(() => kalanlabelx.Text = (gidilecekYerX - anlikKonumx).ToString("f1")));
                }
                else
                {
                    kalanlabelx.Text = (gidilecekYerX - anlikKonumx).ToString("f1");
                }
            }
            else
            {
                // Değerler çevrilemiyorsa bir hata işlemi yapabilirsiniz.
                //MessageBox.Show("Hata");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (continuousReading)
                {
                    UpdateKalanLabelX();

                    // 100 ms bekleyin
                    Thread.Sleep(100);
                }
            });

            try
            {
                // TextBox1'deki değeri alın
                if (int.TryParse(textBox1.Text, out int valueToWrite))
                {
                    // Değerin 0-100 aralığında olup olmadığını kontrol edin
                    if (valueToWrite >= 0 && valueToWrite <= 100)
                    {
                        // Hedef Deger X düğümüne değeri yazın
                        easyUAClient1.WriteValue(server, hedefDegerNode, valueToWrite);
                        label1.Text = valueToWrite.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Değer 0 ile 100 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz değer. Lütfen bir sayı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void button5_MouseClick(object sender, MouseEventArgs e)
        {

            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, start, isValueFalse);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, start, isValueTrue);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, stop, isValueFalse);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, stop, isValueTrue);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (continuousReading)
                {
                    UpdateKalanLabelY();

                    // 100 ms bekleyin
                    Thread.Sleep(100);
                }
            });
            //////////////////////////
            try
            {
                // TextBoxy'deki değeri alın
                if (int.TryParse(textBoxy.Text, out int valueToWritey))
                {
                    // Değerin 0-100 aralığında olup olmadığını kontrol edin
                    if (valueToWritey >= 0 && valueToWritey <= 100)
                    {
                        // Hedef Deger Y düğümüne değeri yazın
                        easyUAClient1.WriteValue(server, hedefdegernodey, valueToWritey);
                        gidilecekyerlabely.Text = valueToWritey.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Değer 0 ile 100 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz değer. Lütfen bir sayı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateKalanLabelZ()
        {
            if (double.TryParse(anlıkkonumZ.Text, out double anlikKonumuZ) && double.TryParse(gidilecekyerZ.Text, out double gidilecekYereZ))
            {
                // "kalanlabely" label'ına kalan değeri yaz
                if (InvokeRequired)
                {
                    Invoke(new Action(() => kalanmesafeZ.Text = (gidilecekYereZ - anlikKonumuZ).ToString("f1")));
                }
                else
                {
                    kalanmesafeZ.Text = (gidilecekYereZ - anlikKonumuZ).ToString("f1");
                }
            }
            else
            {
                // Değerler çevrilemiyorsa bir hata işlemi yapabilirsiniz.
                //MessageBox.Show("Hata");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (continuousReading)
                {
                    UpdateKalanLabelZ();

                    // 100 ms bekleyin
                    Thread.Sleep(100);
                }
            });
            try
            {
                // TextBoxy'deki değeri alın
                if (int.TryParse(textBoxZ.Text, out int valueToWriteyz))
                {
                    // Değerin 0-100 aralığında olup olmadığını kontrol edin
                    if (valueToWriteyz >= 0 && valueToWriteyz <= 100)
                    {
                        // Hedef Deger Y düğümüne değeri yazın
                        easyUAClient1.WriteValue(server, hedefdegernodez, valueToWriteyz);
                        gidilecekyerZ.Text = valueToWriteyz.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Değer 0 ile 100 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz değer. Lütfen bir sayı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        



        private async void button10_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "0";
            textBoxy.Text = "0";
            textBoxZ.Text = "0";

            button1.PerformClick();
            button2.PerformClick();
            button3.PerformClick();
            await Task.Delay(100);
            easyUAClient1.WriteValue(server, x_axisgoNode, isValueTrue);
            easyUAClient1.WriteValue(server, y_axisgonode, isValueTrue);
            easyUAClient1.WriteValue(server, z_axisgonode, isValueTrue);
        }

        private void button10_MouseClick(object sender, MouseEventArgs e)
        {
            easyUAClient1.WriteValue(server, x_axisgoNode, isValueFalse);
            easyUAClient1.WriteValue(server, y_axisgonode, isValueFalse);
            easyUAClient1.WriteValue(server, z_axisgonode, isValueFalse);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = !checkBox1.Checked;
            bool xaxisyavas = checkBox1.Checked;

            try
            {
                easyUAClient1.WriteValue(server, xaxisYavasHizButtonNode, xaxisyavas);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
                // Hata durumunda gerekli işlemleri gerçekleştirin
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = !checkBox2.Checked;
            bool xaxishızlı = checkBox2.Checked;
            try
            {
                easyUAClient1.WriteValue(server, xaxishizlibuttonnode, xaxishızlı);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
                // Hata durumunda gerekli işlemleri gerçekleştirin
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Enabled = !checkBox3.Checked;
            bool yaxisyavas = checkBox3.Checked;

            try
            {
                easyUAClient1.WriteValue(server, yaxisyavashizbuttonnode, yaxisyavas);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
                // Hata durumunda gerekli işlemleri gerçekleştirin
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Enabled = !checkBox4.Checked;
            bool yaxishızlı = checkBox4.Checked;
            try
            {
                easyUAClient1.WriteValue(server, yaxishizlibuttonnode, yaxishızlı);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
                // Hata durumunda gerekli işlemleri gerçekleştirin
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox6.Enabled = !checkBox5.Checked;
            bool zaxisyavas = checkBox5.Checked;
            try
            {
                easyUAClient1.WriteValue(server, zaxisyavashizbuttonnode, zaxisyavas);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
                // Hata durumunda gerekli işlemleri gerçekleştirin
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Enabled = !checkBox6.Checked;
            bool zaxishızlı = checkBox6.Checked;
            try
            {
                easyUAClient1.WriteValue(server, zaxishizlibuttonnode, zaxishızlı);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
                // Hata durumunda gerekli işlemleri gerçekleştirin
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, hedeflebutonopcnode, isValueTruehedef);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, hedeflebutonopcnode, isValueFalsehedef);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, yhedeflebutonopcnode, isValueTruehedefY);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, yhedeflebutonopcnode, isValueFalsehedefY);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, zhedeflebutonopcnode, isValueTruehedefZ);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, zhedeflebutonopcnode, isvaluefalsehedefZ);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void UpdateKalanLabelY()
        {
            if (double.TryParse(anlıkkonumy.Text, out double anlikKonum) && double.TryParse(gidilecekyerlabely.Text, out double gidilecekYer))
            {
                // "kalanlabely" label'ına kalan değeri yaz
                if (InvokeRequired)
                {
                    Invoke(new Action(() => kalanlabely.Text = (gidilecekYer - anlikKonum).ToString("f1")));
                }
                else
                {
                    kalanlabely.Text = (gidilecekYer - anlikKonum).ToString("f1");
                }
            }
            else
            {
                // Değerler çevrilemiyorsa bir hata işlemi yapabilirsiniz.
                //MessageBox.Show("Hata");
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox1.CheckOnClick = true;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            transfervaluetolistview();
        }

        private void transfervaluetolistview()
        {
            string sırakod = textBox2.Text;

            if (checkedListBox1.GetItemChecked(0))
            {

                listBox1.Items.Add("X" + sırakod);

            }

            if (checkedListBox1.GetItemChecked(1))
            {

                listBox1.Items.Add("Y" + sırakod);
            }

            if (checkedListBox1.GetItemChecked(2))
            {

                listBox1.Items.Add("Z" + sırakod);


            }



        }
        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, x_axisgoNode, isValueTrue);

              
                
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, y_axisgonode, isValueTrue);

                // 1 saniye bekleyerek x_axisgoNode'u tekrar isValueFalse yap
                Thread.Sleep(1000);

                easyUAClient1.WriteValue(server, y_axisgonode, isValueFalse);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                // Belirtilen NODE ID'ye ait value'yu isValueTrue değişkenine göre ayarla
                easyUAClient1.WriteValue(server, z_axisgonode, isValueTrue);

                // 1 saniye bekleyerek x_axisgoNode'u tekrar isValueFalse yap
                Thread.Sleep(1000);

                easyUAClient1.WriteValue(server, z_axisgonode, isValueFalse);
            }
            catch (UAException uaException)
            {
                Console.WriteLine($"*** Failure: {uaException.GetBaseException().Message}");
            }
        }


        private async Task<bool> readxhedefgittinodevalue()
        {
            const int interval = 350;
            const int maxAttempts = 100;

            int attempts = 0;

            while (attempts < maxAttempts)
            {

                try
                {
                    object value = easyUAClient1.ReadValue(server, xhedefegittinode);
                    if(Convert.ToBoolean(value) == true)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
                await Task.Delay(interval);
                attempts++;
            }
            return false;
        }

        private bool readyhedefgittinodevalue()
        {
            try
            {
                easyUAClient1.ReadValue(server, yhedefegittinode);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                return false;
            }
        }
        private bool readzhedefgittinodevalue()
        {
            try
            {
                easyUAClient1.ReadValue(server, zhedefegittinode);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                return false;
            }
        }


        private async void ProcessXItem(string item)
        {
            //X ile başlıyorsa
            if (item.StartsWith("X"))
            {
                string numberPart = item.Substring(1);
                textBox1.Text = numberPart;
                button1.PerformClick();
                Thread.Sleep(500);
                button6.PerformClick();
                
                

            }
        }

        private async void ProcessYItem(string item)
        {
            // Y ile başlıyorsa
            if (item.StartsWith("Y"))
            {
                // Y'den sonraki kısmı al
                string numberPart = item.Substring(1);

                // TextBoxy'e yaz
                textBoxy.Text = numberPart;
                button2.PerformClick();
                Thread.Sleep(500);
                button8.PerformClick();
                
                
            }
        }

        private void ProcessZItem(string item)
        {
            // Z ile başlıyorsa
            if (item.StartsWith("Z"))
            {
                // Z'den sonraki kısmı al
                string numberPart = item.Substring(1);

                // TextBoxZ'ye yaz
                textBoxZ.Text = numberPart;
                button3.PerformClick();
                Thread.Sleep(500);
                button9.PerformClick();

                
               
            }
        }



        private async void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string currentItem = listBox1.Items[i].ToString();
                if (currentItem.StartsWith("X")) 
                {
                ProcessXItem(currentItem);
                    while (true)
                    {
                        await Task.Delay(500);
                        // xhedefegittinode durumu true ise döngüden çık
                        //if (readxhedefgittinodevalue() == true)
                        //{
                        //    break;
                        //}

                    }

                }
                else if (currentItem.StartsWith("Y"))
                {
                ProcessYItem(currentItem);
                    while (true)
                    {
                        await Task.Delay(500);
                        // xhedefegittinode durumu true ise döngüden çık
                        if (readyhedefgittinodevalue() == true)
                        {
                            break;
                        }

                    }
                }
                else if (currentItem.StartsWith("Z"))
                {
                ProcessZItem(currentItem);
                    while (true)
                    {
                        await Task.Delay(500);
                        // xhedefegittinode durumu true ise döngüden çık
                        if (readzhedefgittinodevalue() == true)
                        {
                            break;
                        }

                    }
                }
            }
        }

       
    }
}















