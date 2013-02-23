using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WebToRTM
{
    class HttpDaemon
    {
        private HttpListener listener = null;
        private string root;
        private string prefix; 

        public HttpDaemon()
        {
            root = @"c:\wwwroot"; // ドキュメント・ルート
            prefix = "http://*/"; // 受け付けるURL
        }

        public void startListener()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(prefix); // プレフィックスの登録

            listener.Start();

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest req = context.Request;
                HttpListenerResponse res = context.Response;

                Console.WriteLine(req.RawUrl);

                // リクエストされたURLからファイルのパスを求める
                string path = root + req.RawUrl.Replace("/", "\\");

                // ファイルが存在すればレスポンス・ストリームに書き出す
                if (File.Exists(path))
                {
                    byte[] content = File.ReadAllBytes(path);
                    res.OutputStream.Write(content, 0, content.Length);
                }
                res.Close();
            }
        }
    }
}
