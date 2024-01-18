using OpcLabs.EasyOpc.UA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HMI_Eray
{
    public partial class Form2 : Form
    {
        private UAEndpointDescriptor server = "opc.tcp://localhost:4841";
        private const string prefix = "nsu=http://meg.mee.com/UA/Instances;ns=4;s=Address Space.FX5U-32M.";

        private UANodeDescriptor actualX = prefix + "anlık_deger_x";
        private UANodeDescriptor targetX = prefix + "hedef_deger_X";
        private UANodeDescriptor goX = prefix + "X_AXISGO";
        private UANodeDescriptor goneX = prefix + "X_Gitti";

        private UANodeDescriptor actualY = prefix + "anlık_Deger_y";
        private UANodeDescriptor targetY = prefix + "Hedef_deger_Y";
        private UANodeDescriptor goY = prefix + "Y_AXISGO";
        private UANodeDescriptor goneY = prefix + "Y_Gitti";

        private UANodeDescriptor actualZ = prefix + "anlık_deger_z";
        private UANodeDescriptor targetZ = prefix + "hedef_deger_Z";
        private UANodeDescriptor goZ = prefix + "Z_AXİSGO";
        private UANodeDescriptor goneZ = prefix + "Z_Gitti";

        private UANodeDescriptor start = prefix + "Tag000";
        private UANodeDescriptor stop = prefix + "Tag001";
        private UANodeDescriptor motorRunNode = prefix + "MotorRun";

        //Hızlar
        private UANodeDescriptor xaxisYavasHizButtonNode = prefix + "Xaxis_yavashızbuton";
        private UANodeDescriptor xaxishizlibuttonnode = prefix + "Xaxis_2xhızbuton";

        private UANodeDescriptor yaxisyavashizbuttonnode = prefix + "Yaxis_yavashizbuton";
        private UANodeDescriptor yaxishizlibuttonnode = prefix + "Yaxis_2xhızbuton";

        private UANodeDescriptor zaxisyavashizbuttonnode = prefix + "Zaxis_yavashizbuton";
        private UANodeDescriptor zaxishizlibuttonnode = prefix + "Zaxis_2xhızbuton";

        private readonly EasyUAClient easyUAClient1;
        private readonly BindingList<AxisCommand> commands;

        public Form2()
        {
            InitializeComponent();

            easyUAClient1 = new EasyUAClient();
            easyUAClient1.MonitoredItemChanged += Client_MonitoredItemChanged;

            commands = new BindingList<AxisCommand>();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = commands;
        }


        private void Form2_Shown(object sender, EventArgs e)
        {
            var tagList = new[]
            {
                new EasyUAMonitoredItemArguments(null, server, actualX, 100),
                new EasyUAMonitoredItemArguments(null, server, actualY, 100),
                new EasyUAMonitoredItemArguments(null, server, actualZ, 100),

                new EasyUAMonitoredItemArguments(null, server, motorRunNode, 100),



            };
            easyUAClient1.SubscribeMultipleMonitoredItems(tagList);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            easyUAClient1.UnsubscribeAllMonitoredItems();
        }

        private void Client_MonitoredItemChanged(object sender, EasyUAMonitoredItemChangedEventArgs e)
        {
            if (!e.Succeeded)
                return;

            if (e.Arguments.NodeDescriptor == actualX)
            {
                int value = Convert.ToInt32(e.AttributeData.Value);
                lblAxisX.Text = (value * 0.1).ToString("0.0");
            }
            if (e.Arguments.NodeDescriptor == actualY)
            {
                int value = Convert.ToInt32(e.AttributeData.Value);
                lblAxisY.Text = (value * 0.1).ToString("0.0");
            }
            if (e.Arguments.NodeDescriptor == actualZ)
            {
                int value = Convert.ToInt32(e.AttributeData.Value);
                lblAxisZ.Text = (value * 0.1).ToString("0.0");
            }

            if (e.Arguments.NodeDescriptor == motorRunNode)
            {
                bool isRunning = Convert.ToBoolean(e.AttributeData.Value);
                if (isRunning)
                {
                    pnlMotorStatus.BackColor = Color.Green;
                }
                else
                {
                    pnlMotorStatus.BackColor = Color.Red;
                }
            }
        }

        private async void btnGoX_Click(object sender, EventArgs e)
        {
            int target = Convert.ToInt32(spnTargetX.Value * 10);
            pctMotorX.Visible = true;
            radXspeed.PerformClick();
            btnGoX.Enabled = false;
            btnZeroAll.Enabled = false;
            btnRun.Enabled = false;
            try
            {
                await Task.Run(() =>
                {
                    easyUAClient1.WriteValue(server, goneX, false);
                    easyUAClient1.WriteValue(server, targetX, target);
                    easyUAClient1.WriteValue(server, goX, true);

                    WaitAxisProcess(goneX);
                });
            }
            catch (MotorStoppedException)
            {
                MessageBox.Show("Motor Durdu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGoX.Enabled = true;
                pctMotorX.Visible = false;
                if (btnGoY.Enabled && btnGoZ.Enabled)
                {
                    btnZeroAll.Enabled = true;
                    btnRun.Enabled = true;
                }
            }
        }

        private async void btnGoY_Click(object sender, EventArgs e)
        {
            int target = Convert.ToInt32(spnTargetY.Value * 10);
            pctMotorY.Visible = true;
            radYspeed.PerformClick();
            btnGoY.Enabled = false;
            btnZeroAll.Enabled = false;
            btnRun.Enabled = false;
            try
            {
                await Task.Run(() =>
                {
                    easyUAClient1.WriteValue(server, goneY, false);
                    easyUAClient1.WriteValue(server, targetY, target);
                    easyUAClient1.WriteValue(server, goY, true);

                    WaitAxisProcess(goneY);
                });
            }
            catch (MotorStoppedException)
            {
                MessageBox.Show("Motor durdu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pctMotorY.Visible = false;
                btnGoY.Enabled = true;
                if (btnGoX.Enabled && btnGoZ.Enabled)
                {
                    btnZeroAll.Enabled = true;
                    btnRun.Enabled = true;
                }
            }
        }

        private async void btnGoZ_Click(object sender, EventArgs e)
        {
            int target = Convert.ToInt32(spnTargetZ.Value * 10);
            pctMotorZ.Visible = true;
            radZspeed.PerformClick();
            btnGoZ.Enabled = false;
            btnZeroAll.Enabled = false;
            btnRun.Enabled = false;
            try
            {
                await Task.Run(() =>
                {
                    easyUAClient1.WriteValue(server, goneZ, false);
                    easyUAClient1.WriteValue(server, targetZ, target);
                    easyUAClient1.WriteValue(server, goZ, true);

                    WaitAxisProcess(goneZ);
                });
            }
            catch (MotorStoppedException)
            {
                MessageBox.Show("Motor durdu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGoZ.Enabled = true;
                pctMotorZ.Visible = false;
                if (btnGoX.Enabled && btnGoY.Enabled)
                {
                    btnZeroAll.Enabled = true;
                    btnRun.Enabled = true;
                }
            }
        }

        private async void btnZeroAll_Click(object sender, EventArgs e)
        {
            btnGoX.Enabled = false;
            btnGoY.Enabled = false;
            btnGoZ.Enabled = false;
            btnZeroAll.Enabled = false;
            btnRun.Enabled = false;
            pctMotorX.Visible = true;
            pctMotorY.Visible = true;
            pctMotorZ.Visible = true;

            try
            {
                await Task.Run(() =>
                {
                    easyUAClient1.WriteValue(server, targetX, 0);
                    easyUAClient1.WriteValue(server, targetY, 0);
                    easyUAClient1.WriteValue(server, targetZ, 0);

                    easyUAClient1.WriteValue(server, goneX, false);
                    easyUAClient1.WriteValue(server, goneY, false);
                    easyUAClient1.WriteValue(server, goneZ, false);

                    easyUAClient1.WriteValue(server, goX, true);
                    easyUAClient1.WriteValue(server, goY, true);
                    easyUAClient1.WriteValue(server, goZ, true);

                    WaitAxisProcess(goneX);
                    WaitAxisProcess(goneY);
                    WaitAxisProcess(goneZ);
                });
            }
            catch (MotorStoppedException)
            {
                MessageBox.Show("Motor durdu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGoX.Enabled = true;
                btnGoY.Enabled = true;
                btnGoZ.Enabled = true;
                btnZeroAll.Enabled = true;
                btnRun.Enabled = true;
                pctMotorX.Visible = false;
                pctMotorY.Visible = false;
                pctMotorZ.Visible = false;

            }
        }

        private void WaitAxisProcess(UANodeDescriptor tag)
        {
            while (true)
            {
                object motorRun = easyUAClient1.ReadValue(server, motorRunNode);
                if (!Convert.ToBoolean(motorRun))
                    throw new MotorStoppedException();

                Thread.Sleep(100);

                object value = easyUAClient1.ReadValue(server, tag);
                if (Convert.ToBoolean(value))
                {

                    return;
                }
            }
        }


        //OTO LİSTE KODLARI 

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            AxisCommand command = null;

            if (radX.Checked)
            {
                command = new AxisCommand(AxisName.X);
            }
            if (radY.Checked)
            {
                command = new AxisCommand(AxisName.Y);
            }
            if (radZ.Checked)
            {
                command = new AxisCommand(AxisName.Z);
            }

            if (command == null)
                return;

            command.Value = Convert.ToInt32(spnAxisValue.Value * 10);          /////////////////////////Değişti/////////////////////////////////////

            commands.Add(command);
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            commands.Clear();
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            IProgress<RunningAxisData> progress = new Progress<RunningAxisData>(data =>
            {
                if (data == null)
                    return;

                data.Command.Status = data.Status;

                switch (data.Command.Name)
                {
                    case AxisName.X:
                        pctMotorX.Visible = data.Running;
                        radYspeed.Enabled = !data.Running;
                        radZspeed.Enabled = !data.Running;
                        radXspeed.PerformClick();
                        break;
                    case AxisName.Y:
                        pctMotorY.Visible = data.Running;
                        radXspeed.Enabled = !data.Running;
                        radZspeed.Enabled = !data.Running;
                        radYspeed.PerformClick();
                        break;
                    case AxisName.Z:
                        pctMotorZ.Visible = data.Running;
                        radXspeed.Enabled = !data.Running;
                        radYspeed.Enabled = !data.Running;
                        radZspeed.PerformClick();
                        break;
                }
            });

            btnGoX.Enabled = false;
            btnGoY.Enabled = false;
            btnGoZ.Enabled = false;
            btnZeroAll.Enabled = false;
            btnRun.Enabled = false;
            btnAddToList.Enabled = false;
            btnClearList.Enabled = false;
            button1.Enabled = false;

            foreach (var command in commands)       // Idle ye sıfırlama 
            {
                command.Status = AxisStatus.Idle;
            }

            try
            {
                await Task.Run(() =>
                {
                    foreach (var command in commands)
                    {
                        try
                        {
                            progress.Report(new RunningAxisData(command, AxisStatus.Working));

                            switch (command.Name)
                            {
                                case AxisName.X:
                                    GoAxisX(command.Value);               /////////////////////////Değişti/////////////////////////////////////
                                    break;
                                case AxisName.Y:
                                    GoAxisY(command.Value);               /////////////////////////Değişti/////////////////////////////////////
                                    break;
                                case AxisName.Z:
                                    GoAxisZ(command.Value);               /////////////////////////Değişti/////////////////////////////////////
                                    break;
                            }
                            progress.Report(new RunningAxisData(command, AxisStatus.Finished));
                        }
                        catch (MotorStoppedException)
                        {
                            progress.Report(new RunningAxisData(command, AxisStatus.Error));
                            return;
                        }
                    }
                });
            }
            finally
            {
                btnGoX.Enabled = true;
                btnGoY.Enabled = true;
                btnGoZ.Enabled = true;
                btnZeroAll.Enabled = true;
                btnRun.Enabled = true;
                btnAddToList.Enabled = true;
                btnClearList.Enabled = true;
                button1.Enabled = true;

            }

        }
        public void GoAxisX(double target)                                  /////////////////////////Değişti/////////////////////////////////////
        {
            easyUAClient1.WriteValue(server, goneX, false);
            easyUAClient1.WriteValue(server, goX, true);
            easyUAClient1.WriteValue(server, targetX, Convert.ToInt32(target));

            WaitAxisProcess(goneX);
        }

        public void GoAxisY(double target)                                  /////////////////////////Değişti/////////////////////////////////////
        {
            easyUAClient1.WriteValue(server, goneY, false);
            easyUAClient1.WriteValue(server, goY, true);
            easyUAClient1.WriteValue(server, targetY, target);

            WaitAxisProcess(goneY);
        }

        public void GoAxisZ(double target)                                  /////////////////////////Değişti/////////////////////////////////////
        {
            easyUAClient1.WriteValue(server, goneZ, false);
            easyUAClient1.WriteValue(server, goZ, true);
            easyUAClient1.WriteValue(server, targetZ, target);

            WaitAxisProcess(goneZ);
        }

        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            easyUAClient1.WriteValue(server, start, true);
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            easyUAClient1.WriteValue(server, start, false);
        }

        private void btnStop_MouseDown(object sender, MouseEventArgs e)
        {
            easyUAClient1.WriteValue(server, stop, true);
        }

        private void btnStop_MouseUp(object sender, MouseEventArgs e)
        {
            easyUAClient1.WriteValue(server, stop, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var command = dataGridView1.CurrentRow.DataBoundItem as AxisCommand;
            if (command != null)
            {
                commands.Remove(command);
            }
        }

        //Hız kodları
        private void Form2_Load(object sender, EventArgs e)
        {
            btn2x.PerformClick();
            easyUAClient1.WriteValue(server, xaxisYavasHizButtonNode, false); //X YAVAS
            easyUAClient1.WriteValue(server, xaxishizlibuttonnode, true);    //X HIZLI

            easyUAClient1.WriteValue(server, yaxisyavashizbuttonnode, false); //Y YAVAS
            easyUAClient1.WriteValue(server, yaxishizlibuttonnode, true);    //Y HIZLI 

            easyUAClient1.WriteValue(server, zaxishizlibuttonnode, true);    //Z HIZLI
            easyUAClient1.WriteValue(server, zaxisyavashizbuttonnode, false); //Z YAVAS
        }

        private void btn2x_Click(object sender, EventArgs e)
        {
            bool hızlı = true;
            if (radXspeed.Checked)
            {
                easyUAClient1.WriteValue(server, xaxishizlibuttonnode, hızlı);
                easyUAClient1.WriteValue(server, xaxisYavasHizButtonNode, false);
            }
            if (radYspeed.Checked)
            {
                easyUAClient1.WriteValue(server, yaxishizlibuttonnode, hızlı);
                easyUAClient1.WriteValue(server, yaxisyavashizbuttonnode, false);
            }
            if (radZspeed.Checked)
            {
                easyUAClient1.WriteValue(server, zaxishizlibuttonnode, hızlı);
                easyUAClient1.WriteValue(server, zaxisyavashizbuttonnode, false);
            }
        }

        private void btn05x_Click(object sender, EventArgs e)
        {
            bool enhızlı = true;
            if (radXspeed.Checked)
            {
                easyUAClient1.WriteValue(server, xaxisYavasHizButtonNode, enhızlı);
                easyUAClient1.WriteValue(server, xaxishizlibuttonnode, false);
            }
            if (radYspeed.Checked)
            {
                easyUAClient1.WriteValue(server, yaxisyavashizbuttonnode, enhızlı);
                easyUAClient1.WriteValue(server, yaxishizlibuttonnode, false);
            }
            if (radZspeed.Checked)
            {
                easyUAClient1.WriteValue(server, zaxisyavashizbuttonnode, enhızlı);
                easyUAClient1.WriteValue(server, zaxishizlibuttonnode, false);
            }
        }

        private void btn1x_Click(object sender, EventArgs e)
        {
            if (radXspeed.Checked)
            {
                easyUAClient1.WriteValue(server, xaxisYavasHizButtonNode, false);
                easyUAClient1.WriteValue(server, xaxishizlibuttonnode, false);
            }
            if (radYspeed.Checked)
            {
                easyUAClient1.WriteValue(server, yaxisyavashizbuttonnode, false);
                easyUAClient1.WriteValue(server, yaxishizlibuttonnode, false);
            }
            if (radZspeed.Checked)
            {
                easyUAClient1.WriteValue(server, zaxishizlibuttonnode, false);
                easyUAClient1.WriteValue(server, zaxisyavashizbuttonnode, false);
            }
        }
      
    }
}

