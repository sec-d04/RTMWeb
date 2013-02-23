using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenRTM.Core;
using OpenRTM.Extension;
using OpenRTM.IIOP;


namespace WebToRTM
{
    public partial class MainForm : Form
    {
        private Manager manager;
        private WebRTC component;

        //TBD
        public WebRTC GetComponent()
        {
            return component;
        }


        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期化処理。コンポーネントの作成
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            manager = new Manager();
            manager.AddTypes(typeof(CorbaProtocolManager));
            manager.Activate();
            component = manager.CreateComponent<WebRTC>();

            if (component == null)
            {
                throw new ApplicationException("コンポーネントの作成に失敗しました。");
            }

            component.DataReceived += ReceiveData;

            //HTTP daemon開始
            HttpDaemon httpd = new HttpDaemon(component);
            httpd.startListener();
        }

        /// <summary>
        /// コンポーネントからデータを受信する処理
        /// </summary>
        private void ReceiveData(TimedLong data)
        {
            // コンポーネントとFormで実行スレッドが異なるので、UI Threadから実行させる
            if (InvokeRequired)
            {
                Invoke(new Action<TimedLong>(ReceiveData), new object[] { data });
                return;
            }

           // textBoxReceive.Text = data.Data.ToString();
        }

        /// <summary>
        /// 送信ボタンが押されたときの処理
        /// </summary>
        private void buttonSend_Click(object sender, EventArgs e)
        {
           // int input = int.Parse(textBoxSend.Text);

            var data = new TimedLong();
            data.Time.SetDateTime(DateTime.Now);
          //  data.Data = input;
            data.Data = 1;

            // コンポーネントからデータを出力
            component.SendData(data);
        }

        /// <summary>
        /// 入力値のチェック
        /// </summary>
        private void textBoxSend_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int input;
            //errorProvider.Clear();


          //  if (!int.TryParse(textBoxSend.Text, out input))
          //  {
                // 数値以外のものは入力させない
         //       e.Cancel = true;
             //   errorProvider.SetError(textBoxSend, "数値を入力してください。");
          //  }
          //  else
          //  {
         //       e.Cancel = false;
         //   }

        }
    }
}
