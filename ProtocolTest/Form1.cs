using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
using System.Net;
using System.Globalization;
using DevExpress.XtraCharts;

namespace ProtocolTest
{
    public partial class Form1 : Form
    {
        public SqlConnection conn;
        public SqlCommand sqlComm;


        Series[] SeriesDATA = new Series[4];

        string RxData = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PortDetailSetting();
            btnDBOpen.Enabled = true;
            btnOpen.Enabled = false;
            btnClose.Enabled = false;
            DataTable();

            SeriesDATA[0] = new Series("Temperature", ViewType.Line);
            SeriesDATA[1] = new Series("Humidity", ViewType.Line);
            SeriesDATA[2] = new Series("CO2", ViewType.Line);
            SeriesDATA[3] = new Series("Movement", ViewType.Line);

            chartControl.Series.Add(SeriesDATA[0]);
            chartControl.Series.Add(SeriesDATA[1]);
            chartControl.Series.Add(SeriesDATA[2]);
            chartControl.Series.Add(SeriesDATA[3]);

            XYDiagram diagram = (XYDiagram)chartControl.Diagram;
            diagram.AxisX.Label.TextPattern = "{A: HH:mm:ss}";
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Manual;
            diagram.AxisX.DateTimeScaleOptions.GridSpacing = 1;
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Second;
            diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Hour;

            ((XYDiagram)chartControl.Diagram).SecondaryAxesY.Clear();
            SecondaryAxisY secondAxisY = new SecondaryAxisY();
            ((XYDiagram)chartControl.Diagram).SecondaryAxesY.Add(secondAxisY);

            LineSeriesView lineView = new LineSeriesView();
            lineView = (LineSeriesView)SeriesDATA[2].View;
            lineView.AxisY = secondAxisY;
            lineView.LineMarkerOptions.BorderVisible = false;
        }

        private void PortDetailSetting()
        {
            string[] port = SerialPort.GetPortNames();
            foreach (string portname in port)
            {
                PortList.Items.Add(portname);
            }

            string[] s2 = { "9600", "19200", "38400", "57600", "115200" };
            RateList.Items.AddRange(s2);
            RateList.SelectedIndex = 4;

            string[] s3 = { "6", "7", "8" };
            DataBitsList.Items.AddRange(s3);
            DataBitsList.SelectedIndex = 2;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ConnectPort();
            dt.Rows.Clear();
        }

        private void ConnectPort()
        {
            try
            {
                MainPort.PortName = PortList.SelectedItem.ToString();
                MainPort.BaudRate = Convert.ToInt32(RateList.SelectedItem);
                MainPort.DataBits = Convert.ToInt32(DataBitsList.SelectedItem);
                MainPort.StopBits = StopBits.One;
                MainPort.Parity = Parity.None;
                MainPort.Handshake = Handshake.None;
                MainPort.DataReceived += new SerialDataReceivedEventHandler(MainPort_DataReceived);
                MainPort.Open();

                btnOpen.Enabled = false;
                btnClose.Enabled = true;
                PortList.Enabled = false;
                RateList.Enabled = false;
                DataBitsList.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Port Connect Please!");
                Console.WriteLine(e.Message);
            }
        }

        private void GetDBDate_History()
        {
            chartControl.Series.Clear();
            SeriesDATA[0].Points.Clear();
            SeriesDATA[1].Points.Clear();
            SeriesDATA[2].Points.Clear();
            SeriesDATA[3].Points.Clear();

            sqlComm.CommandText = "SELECT NODE_ID, GROUP_ID, TEMPERATURE, HUMIDITY, CO2, MOVE, CREATED_DATE FROM TEST_PARSING";
            SqlDataReader reader = sqlComm.ExecuteReader();

            try
            {
                while (reader.Read() == true)
                {
                    if (NodeIDBox.SelectedItem.ToString().Equals(reader["NODE_ID"].ToString()))
                    {
                        if (StartDataTime.Text.Length == 13 && EndDataTime.Text.Length == 13)
                        {
                            int s_year = Convert.ToInt32(StartDataTime.Text.Substring(0, 4));
                            int e_year = Convert.ToInt32(EndDataTime.Text.Substring(0, 4));
                            int s_month = Convert.ToInt32(StartDataTime.Text.Substring(5, 2));
                            int e_month = Convert.ToInt32(EndDataTime.Text.Substring(5, 2));
                            int s_day = Convert.ToInt32(StartDataTime.Text.Substring(8, 2));
                            int e_day = Convert.ToInt32(EndDataTime.Text.Substring(8, 2));
                            int s_hour = Convert.ToInt32(StartDataTime.Text.Substring(11, 2));
                            int e_hour = Convert.ToInt32(EndDataTime.Text.Substring(11, 2));

                            int compare = Convert.ToInt32(reader["CREATED_DATE"].ToString().Substring(0, 4));

                            if (s_year <= compare && e_year >= compare) // year 비교
                            {
                                compare = Convert.ToInt32(reader["CREATED_DATE"].ToString().Substring(5, 2));

                                if (s_month <= compare && e_month >= compare)  // month 비교
                                {
                                    compare = Convert.ToInt32(reader["CREATED_DATE"].ToString().Substring(8, 2));

                                    if (s_day <= compare && e_day >= compare)  // day 비교
                                    {
                                        // 비교 가능한 int형으로 변경하기 위한 작업
                                        string minute;
                                        string second;
                                        string temp = reader["CREATED_DATE"].ToString().Substring(14, 2);
                                        if (temp.Contains(":"))
                                        {
                                            compare = Convert.ToInt32(reader["CREATED_DATE"].ToString().Substring(14, 1));
                                            minute = reader["CREATED_DATE"].ToString().Substring(16, 2);
                                            second = reader["CREATED_DATE"].ToString().Substring(19, 2);
                                        }
                                        else
                                        {
                                            compare = Convert.ToInt32(reader["CREATED_DATE"].ToString().Substring(14, 2));
                                            minute = reader["CREATED_DATE"].ToString().Substring(17, 2);
                                            second = reader["CREATED_DATE"].ToString().Substring(20, 2);
                                        }

                                        temp = reader["CREATED_DATE"].ToString().Substring(11, 2);
                                        if (temp.Equals("오후"))
                                        {
                                            compare += 12;
                                        }

                                        if (s_hour <= compare && e_hour >= compare)  // hour 비교
                                        {
                                            if (compare.ToString().Length == 1)
                                            {
                                                temp = "0" + Convert.ToString(compare);
                                            }
                                            else
                                            {
                                                temp = Convert.ToString(compare);
                                            }
                                            string time = temp + minute + second;
                                            GridView_History(time, reader["TEMPERATURE"].ToString(), reader["HUMIDITY"].ToString(), reader["CO2"].ToString(), reader["MOVE"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("데이터를 잘못 입력하셨습니다.");
                            break;
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GridView_History(string time, string temperature, string humidity, string co2, string movement)
        {
            try
            {
                DateTime t = DateTime.ParseExact(time, "HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                SeriesDATA[0].Points.Add(new SeriesPoint(t, temperature));
                SeriesDATA[1].Points.Add(new SeriesPoint(t, humidity));
                SeriesDATA[2].Points.Add(new SeriesPoint(t, co2));
                SeriesDATA[3].Points.Add(new SeriesPoint(t, movement));

                chartControl.Series.Add(SeriesDATA[0]);
                chartControl.Series.Add(SeriesDATA[1]);
                chartControl.Series.Add(SeriesDATA[2]);
                chartControl.Series.Add(SeriesDATA[3]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            conn.Close();
            MainPort.Close();
            btnOpen.Enabled = true;
            btnClose.Enabled = false;

            PortList.Enabled = true;
            RateList.Enabled = true;
            DataBitsList.Enabled = true;
        }

        DataTable dt = new DataTable();

        private void DataTable()
        {
            dt.Columns.Add("Time");
            dt.Columns.Add("Node ID");
            dt.Columns.Add("Group ID");
            dt.Columns.Add("Temperature");
            dt.Columns.Add("Humidity");
            dt.Columns.Add("CO2");
            dt.Columns.Add("Movement");

            DataList.DataSource = dt;

            DataView.Columns[0].Width = 170;
        }

        private void ParsingData(string rxData)
        {
            int Temp1, Temp2;
            string nodeID = "";
            string groupID = "";
            string command = "";
            string temperature = "";
            string humidity = "";
            string co2 = "";
            string movement = "";
            string datalength = "";
            string device = "";

            DateTime t = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";

            try { 
                nodeID = rxData.Substring(5, 4);
                groupID = rxData.Substring(10, 4);
                datalength = rxData.Substring(15, 2);
                device = rxData.Substring(17, 2);
                command = rxData.Substring(19, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (device == "11") // Device Check
            {
                if (command == "10" || command == "11")
                {
                    // 설정 정보 요청/변경 || 설정 정보 응답
                    if (datalength == "07") // Length Check
                    {

                    }
                    else
                    {
                        Console.WriteLine("Setting Info Data ERROR!!");
                    }
                }

                else if (command == "21")
                {
                    // 센서 정보 응답
                    if (datalength == "0A") // Length Check
                    {
                        // Temperature
                        Temp1 = Convert.ToInt32(rxData.Substring(21, 2), 16);
                        Temp2 = Convert.ToInt32(rxData.Substring(23, 2), 16);
                        temperature = Temp1.ToString() + "." + Temp2.ToString();

                        // Humidity Setting
                        Temp1 = Convert.ToInt32(rxData.Substring(25, 2), 16);
                        Temp2 = Convert.ToInt32(rxData.Substring(27, 2), 16);
                        humidity = Temp1.ToString() + "." + Temp2.ToString();

                        // CO2 Setting
                        Temp1 = Convert.ToInt32(rxData.Substring(29, 4), 16);
                        co2 = Temp1.ToString();

                        // Movement Setting
                        movement = rxData.Substring(33, 2);
                        /*
                        if (rxData.Substring(33, 2) == "01")
                        {
                            movement = "Motion Detected";
                        }
                        else
                        {
                            movement = "No Motion Detected";
                        }*/

                        // DataBase Insert
                        insertData(t.ToString(format), nodeID, groupID, temperature, humidity, co2, movement);
                    }

                    else
                    {
                        Console.WriteLine("Sensor Info Data ERROR!!");
                    }
                }

                else if (command == "31")
                {
                    // 움직임 정보 푸시
                    if (datalength == "04") // Length Check
                    {
                        if (rxData.Substring(21, 2) == "00")
                        {
                            Console.WriteLine("No Motion Detected");
                        }
                        else
                        {
                            Console.WriteLine("Motion Detected");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Movement Info Data ERROR!!");
                    }
                }

                else if (command == "E0")
                {
                    // 리포트 설정
                    if (datalength == "08") // Length Check
                    {

                    }
                    else
                    {
                        Console.WriteLine("Report Info Data ERROR!!");
                    }
                }
            }
        }

        private void insertData(string format, string nodeID, string groupID, string temperature, string humidity, string co2, string move)
        {
            string historySql = "";
            string latestSql = "";
            //sql = "INSERT INTO TEST_PARSING(NODE_ID, GROUP_ID, TEMPERATURE, HUMIDITY, CO2, MOVE) VALUES (@NODE_ID, @GROUP_ID, @TEMPERATURE, @HUMIDITY, @CO2, @MOVE)";
            //sql = "INSERT INTO TEST_PARSING(NODE_ID, GROUP_ID, TEMPERATURE, HUMIDITY, CO2, MOVE, CREATED_DATE) VALUES (" + nodeID + ", " + groupID + ", " + temperature + ", " + humidity + ", " + co2 + ", " + move + ", GETDATE())";

            historySql = "MERGE TEST_PARSING AS A USING (SELECT " + nodeID + " NODE_ID, '" + format + "' CREATED_DATE) AS B " +
                "ON (A.CREATED_DATE = B.CREATED_DATE AND A.NODE_ID = B.NODE_ID) WHEN MATCHED THEN " +
                "UPDATE SET A.NODE_ID = " +
                nodeID + ", A.GROUP_ID = " + groupID + ", A.TEMPERATURE = " + temperature + ", A.HUMIDITY = " + humidity + ", A.CO2 = " + co2 + ", A.MOVE = " + move + ", A.CREATED_DATE = '" + format + "' " +
                " WHEN NOT MATCHED THEN " +
                "INSERT (NODE_ID, GROUP_ID, TEMPERATURE, HUMIDITY, CO2, MOVE, CREATED_DATE) VALUES (" + nodeID + ", " + groupID + ", " + temperature + ", " + humidity + ", " + co2 + ", " + move + ", '" + format + "');";

            latestSql = "MERGE TEST_PARSING_LAST AS A USING (SELECT " + nodeID + " NODE_ID, '" + format + "' CREATED_DATE) AS B " +
                "ON (A.NODE_ID = B.NODE_ID) WHEN MATCHED THEN " +
                "UPDATE SET A.NODE_ID = " +
                nodeID + ", A.GROUP_ID = " + groupID + ", A.TEMPERATURE = " + temperature + ", A.HUMIDITY = " + humidity + ", A.CO2 = " + co2 + ", A.MOVE = " + move + ", A.CREATED_DATE = '" + format + "' " +
                " WHEN NOT MATCHED THEN " +
                "INSERT (NODE_ID, GROUP_ID, TEMPERATURE, HUMIDITY, CO2, MOVE, CREATED_DATE) VALUES (" + nodeID + ", " + groupID + ", " + temperature + ", " + humidity + ", " + co2 + ", " + move + ", '" + format + "');";

            try
            {
                sqlComm.CommandText = historySql;
                sqlComm.ExecuteNonQuery();
                sqlComm.CommandText = latestSql;
                sqlComm.ExecuteNonQuery();
                Console.WriteLine("insert 완료");
                /*
                sqlComm.Parameters.AddWithValue("@NODE_ID", nodeID);
                sqlComm.Parameters.AddWithValue("@GROUP_ID", groupID);
                sqlComm.Parameters.AddWithValue("@TEMPERATURE", temperature);
                sqlComm.Parameters.AddWithValue("@HUMIDITY", humidity);
                sqlComm.Parameters.AddWithValue("@CO2", co2);
                sqlComm.Parameters.AddWithValue("@MOVE", move);
                */

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
                Console.WriteLine("비정상 연결종료");
                return;
            }


            /*
            sql = "{\"NODE_ID\":" + nodeID + "," +
                      "\"GROUP_ID\":" + groupID + "," +
                      "\"TEMPERATURE\":" + temperature + "," +
                      "\"HUMIDITY\":" + humidity + "," +
                      "\"CO2\":" + co2 + "," +
                      "\"MOVE\":" + move + "}";
             */
            //JPOST(json);
        }

        private void MainPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte TempBuff = 0x00;
            int nCount = MainPort.BytesToRead;

            try
            {
                for (int i = 0; i < nCount; i++)
                {
                    TempBuff = Convert.ToByte(MainPort.ReadByte());

                    if (TempBuff == 0x0A)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            if (RxData.Length > 4)
                            {
                                if (RxData.Substring(0, 4) == "+RCV")
                                {
                                    ParsingData(RxData);
                                    GetDBData_Last();
                                }
                            }
                            DataView.MoveLast();
                        }));
                        RxData = ""; // RxDate init
                    }

                    else
                    {
                        RxData += Convert.ToChar(TempBuff);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetDBData_Last()
        {
            sqlComm.CommandText = "SELECT NODE_ID, GROUP_ID, TEMPERATURE, HUMIDITY, CO2, MOVE, CREATED_DATE FROM TEST_PARSING_LAST";

            try
            {
                SqlDataReader reader = sqlComm.ExecuteReader();

                while (reader.Read() == true)
                {
                    string nodeID = reader["NODE_ID"].ToString();
                    string groupID = reader["GROUP_ID"].ToString();
                    string temperature = reader["TEMPERATURE"].ToString();
                    string humidity = reader["HUMIDITY"].ToString();
                    string co2 = reader["CO2"].ToString();
                    string movement = reader["MOVE"].ToString();
                    string format = reader["CREATED_DATE"].ToString();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Node ID"].Equals(nodeID))
                        {
                            dt.Rows[i]["Time"] = format;
                            dt.Rows[i]["Temperature"] = temperature;
                            dt.Rows[i]["Humidity"] = humidity + "%";
                            dt.Rows[i]["CO2"] = co2 + "ppm";
                            dt.Rows[i]["Movement"] = movement;
                            break;
                        }

                        if (i == dt.Rows.Count - 1)
                        {
                            dt.Rows.Add(format, nodeID, groupID, temperature, humidity + "%", co2 + "ppm", movement);
                        }
                    }

                    if (dt.Rows.Count == 0)
                    {
                        dt.Rows.Add(format, nodeID, groupID, temperature, humidity + "%", co2 + "ppm", movement);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GridClear_Click(object sender, EventArgs e)
        {
            dt.Clear();
        }

        private void portUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PortList.Items.Clear();
            PortList.Text = "";
            string[] port = SerialPort.GetPortNames();
            foreach (string portname in port)
            {
                PortList.Items.Add(portname);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            GetDBDate_History();
        }

        private void btnDBOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            string connectionInfo = "Server=Your sever;" + "database=~~~;" + "uid=Your ID;" + "pwd=Your Password;";

            try
            {
                conn = new SqlConnection(connectionInfo);
                sqlComm = new SqlCommand();
                sqlComm.Connection = conn;
                conn.Open();
                Console.WriteLine("정상 연결");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                conn.Close();
            }

            SearchNodeID();
        }

        private void SearchNodeID()
        {
            sqlComm.CommandText = "SELECT NODE_ID, GROUP_ID, TEMPERATURE, HUMIDITY, CO2, MOVE, CREATED_DATE FROM TEST_PARSING";

            try
            {
                SqlDataReader reader = sqlComm.ExecuteReader();

                while (reader.Read() == true)
                {
                    string nodeID = reader["NODE_ID"].ToString();

                    if (!NodeIDBox.Items.Contains(nodeID))
                    {
                        NodeIDBox.Items.Add(nodeID);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
