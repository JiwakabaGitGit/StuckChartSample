using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StuckChartSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializProductBar();

            InitializeGraph();
        }

        private void InitializProductBar()
        {
            chart1.Series.Clear();

            chart1.Series.Add( "ProductBar" );    //グラフ追加

            // 凡例自体の幅と高さを設定します
            chart1.Legends[ 0 ].Position.Width = 100.0f;
            chart1.Legends[ 0 ].Position.Height = 15.0f;

            // 位置をfloatで設定します(0～100)
            chart1.Legends[ 0 ].Position.X = 0.0f;
            chart1.Legends[ 0 ].Position.Y = 10.0f;

            // ElementPositionオブジェクトを生成して代入しても設定できます。
            // ElementPosition posi = new ElementPosition(70.0f, 80.0f, 20.0f, 20.0f);
            // chart1.Legends[0].Position = posi;

            // 凡例の位置などの自動設定を無効化します
            chart1.Legends[ 0 ].Position.Auto = false;

            //chart1.Legends[ 0 ].LegendStyle = LegendStyle.Row;

            //var legend1 = new Legend
            //{
            //    //Alignment = StringAlignment.Far,
            //    Docking = Docking.Top,
            //    LegendStyle = LegendStyle.Row,
            //};
            //chart1.Legends.Add( legend1 );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            #region
            KindLog kind1 = new KindLog()
            {
                KindName = "A00000000000001",
                StartTime = DateTime.Parse( "2022-01-01 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-01 23:59:59" )
            };
            KindLog kind2 = new KindLog()
            {
                KindName = "A00000000000002",
                StartTime = DateTime.Parse( "2022-01-02 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-02 23:59:59" )
            };
            KindLog kind3 = new KindLog()
            {
                KindName = "A00000000000003",
                StartTime = DateTime.Parse( "2022-01-03 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-03 23:59:59" )
            };
            KindLog kind4 = new KindLog()
            {
                KindName = "A00000000000004",
                StartTime = DateTime.Parse( "2022-01-04 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-04 23:59:59" )
            };
            KindLog kind5 = new KindLog()
            {
                KindName = "A00000000000005",
                StartTime = DateTime.Parse( "2022-01-05 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-05 23:59:59" )
            };
            KindLog kind6 = new KindLog()
            {
                KindName = "A00000000000006",
                StartTime = DateTime.Parse( "2022-01-06 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-06 23:59:59" )
            };
            KindLog kind7 = new KindLog()
            {
                KindName = "A00000000000007",
                StartTime = DateTime.Parse( "2022-01-07 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-07 23:59:59" )
            };
            KindLog kind8 = new KindLog()
            {
                KindName = "A00000000000008",
                StartTime = DateTime.Parse( "2022-01-08 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-08 23:59:59" )
            };
            KindLog kind9 = new KindLog()
            {
                KindName = "A00000000000009",
                StartTime = DateTime.Parse( "2022-01-09 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-09 23:59:59" )
            };
            KindLog kind10 = new KindLog()
            {
                KindName = "A00000000000010",
                StartTime = DateTime.Parse( "2022-01-10 00:00:00" ),
                EndTime = DateTime.Parse( "2022-01-10 23:59:59" )
            };

            List<KindLog> kindLogs = new List<KindLog>()
            { kind1, kind2 };
            //{ kind1, kind2, kind3, kind4 };
            //{ kind1, kind2, kind3, kind4, kind5, kind6, kind7, kind8, kind9, kind10 };
            //{ kind1, kind2, kind3, kind4, kind5, kind6, kind7 };
            #endregion]

            this.chart1.Series.Clear();

            foreach ( var kindLog in kindLogs )
            {
                chart1.Series.Add( kindLog.KindName );    //グラフ追加
                                              //グラフの種類を指定（Columnは積み上げ縦棒グラフ）
                chart1.Series[ kindLog.KindName ].ChartType = SeriesChartType.StackedBar100;
                chart1.Series[ kindLog.KindName ].LegendText = kindLog.KindName;  //凡例に表示するテキストを指定
            }

            foreach ( var kindLog in kindLogs )
            {
                DataPoint dp = new DataPoint();
                TimeSpan time = kindLog.EndTime - kindLog.StartTime;
                dp.SetValueXY( "ProductBar", time.TotalSeconds );  //XとYの値を設定
                dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
                chart1.Series[ kindLog.KindName ].Points.Add( dp );   //グラフにデータ追加
            }
        }

        private void InitializeGraph()
        {
            // 初期化
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();

            // chart設定
            string Name1 = "Bar1";
            string AreaName1 = "chartArea1";
            chart2.Series.Add( Name1 );// Series追加
            chart2.ChartAreas.Add( AreaName1 );
            chart2.Series[ Name1 ].ChartType = SeriesChartType.Column;

            chart2.ChartAreas[ 0 ].AxisX.IntervalOffset = 0;
            chart2.ChartAreas[ 0 ].AxisX.Interval = 1;
            chart2.ChartAreas[ 0 ].AxisX.IntervalOffsetType = DateTimeIntervalType.Days;
            //max, min 目盛設定
            //chart2.ChartAreas[ AreaName1 ].AxisY.Maximum = 100;
            //chart2.ChartAreas[ AreaName1 ].AxisY.Minimum = 0;
            //chart2.ChartAreas[ AreaName1 ].AxisY.Interval = 20;

            // 凡例自体の幅と高さを設定します
            chart2.Legends[ 0 ].Position.Width = 100.0f;
            chart2.Legends[ 0 ].Position.Height = 15.0f;

            // 位置をfloatで設定します(0～100)
            chart2.Legends[ 0 ].Position.X = 0.0f;
            chart2.Legends[ 0 ].Position.Y = 95.0f;

            // 凡例の位置などの自動設定を無効化します
            chart2.Legends[ 0 ].Position.Auto = false;

            // 目盛線ちょっと出てるところがなくなる
            //chart2.ChartAreas[ AreaName1 ].AxisX.MajorTickMark.Enabled = false;

            // X軸のフォーマットを設定します
            chart2.ChartAreas[ 0 ].AxisX.LabelStyle.Format = "yyyy/MM/dd";
            chart2.ChartAreas[ 0 ].AxisX.LabelStyle.Angle = 90;
            

            DateTime baseDt = DateTime.Today;
            baseDt.AddHours( 12 );
            chart2.Series[ Name1 ].XValueType = ChartValueType.Date;

            // データ設定
            for ( int i = 0; i < 1; i++ )
            {
                DateTime tempDt = baseDt.AddDays( i );
                chart2.Series[ Name1 ].Points.AddXY( tempDt.ToOADate(), (i+1) * 1 );
            }
        }
    }
}
