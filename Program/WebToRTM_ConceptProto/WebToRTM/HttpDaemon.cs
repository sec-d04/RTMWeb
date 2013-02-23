using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using OpenRTM.Core;
using OpenRTM.Extension;
using System.Windows.Forms;

namespace WebToRTM
{
    class HttpDaemon
    {
        private readonly ILogger logger = LoggerFactory.GetLogger();

        enum State
        {
            ready,   // 計算開始前
            running, // 計算中
            wait,    // 計算一時停止中
        }

        private HttpListener listener = null;
        private string root;
        private string prefix;
        private State sThreadState;
        private Thread thread = null;
        private WebRTC component;//TBD

        public HttpDaemon(WebRTC component)
        {
            root = @"c:\wwwroot"; // ドキュメント・ルート
            prefix = "http://*/"; // 受け付けるURL
            this.component = component; 
        }

        public void startListener()
        {


            listener = new HttpListener();
            listener.Prefixes.Add(prefix); // プレフィックスの登録

            listener.Start();

            sThreadState = State.running;
            thread = new Thread(new ThreadStart(ListenerThread));
            thread.Start();
        }

        private void ListenerThread()
        {
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest req = context.Request;
                HttpListenerResponse res = context.Response;

                logger.DebugFormat("HttpMethod {0}", req.HttpMethod);
                logger.DebugFormat(req.RawUrl);

                // リクエストされたURLからファイルのパスを求める
                string path = root + req.RawUrl.Replace("/", "\\");

                // ファイルが存在すればレスポンス・ストリームに書き出す
                if (File.Exists(path))
                {
                    byte[] content = File.ReadAllBytes(path);
                    res.OutputStream.Write(content, 0, content.Length);
                }
                if (req.HttpMethod == "POST")
                {
                    if (req.HasEntityBody)
                    {
                        System.IO.Stream body = req.InputStream;
                        System.Text.Encoding encoding = req.ContentEncoding;
                        System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                        if (req.ContentType != null)
                        {
                            logger.DebugFormat("Client data content type {0}", req.ContentType);
                        }
                        logger.DebugFormat("Client data content length {0}", req.ContentLength64);
                        
                        logger.DebugFormat("Start of client data:");

                        string s = reader.ReadToEnd();

                        logger.DebugFormat(s);
                        logger.DebugFormat("End of client data:");
                        body.Close();
                        reader.Close();

                        logger.DebugFormat("s={0}", s);

                        //スクロール指定
                        if (s.IndexOf("scroll=") > 0)
                        {
                            s = s.Replace("scroll=", "");
                            logger.DebugFormat("Replaceed s={0}", s);

                            var data = new TimedLong();
                            data.Time.SetDateTime(DateTime.Now);
                            //  data.Data = input;
                            data.Data = int.Parse(s);

                            // コンポーネントからデータを出力
                            component.SendData(data);
                        }
                        else if (s.IndexOf("locate=") > 0)
                        {
                            s = s.Replace("locate=", "");
                            logger.DebugFormat("Replaceed s={0}", s);

                            var data = new TimedLong();
                            data.Time.SetDateTime(DateTime.Now);
                            //  data.Data = input;
                            data.Data = int.Parse(s);
                            MessageBox.Show(null,"s = {0}",s);

                            // コンポーネントからデータを出力
                           // component.SendData(data);
                        }
                    }
                }
                res.Close();
            }
        }

    }
}
