using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRTM.Core;


namespace WebToRTM
{
    /// <summary>
    /// GUIから利用するコンポーネント
    /// 周期処理は必要ないのでEmptyExecutionContextを指定
    /// </summary>
    [Component(Category = "RtcProjectTemplate1", Name = "RtcProjectTemplate1",ExecutionContext = "EmptyExecutionContext")]
    public class WebRTC : DataFlowComponent
    {
        [InPort(PortName = "in")]
        InPort<TimedLong> inport = new InPort<TimedLong>();

        [OutPort(PortName = "out")]
        OutPort<TimedLong> outport = new OutPort<TimedLong>();

        [Configuration(Name = "param", DefaultValue = "0")]
        private int param = 0;

        //        protected override ReturnCode_t OnAborting(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnActivated(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnDeactivated(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnError(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnExecute(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnFinalize()
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        protected override ReturnCode_t OnInitialize()
        {
            // inportにデータが書き込まれたらイベントを発生させる
            inport.OnWrite += value =>
            {
                if(DataReceived != null)
                {
                    DataReceived(value);
                }
            };

            return ReturnCode_t.RTC_OK;
        }

        //        protected override ReturnCode_t OnRateChanged(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnReset(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnShutdown(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnStartup(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

        //        protected override ReturnCode_t OnStateUpdate(int exec_handle)
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }
        
        /// <summary>
        /// outportからデータを出力する
        /// </summary>
        public void SendData(TimedLong data)
        {
            outport.Write(data);
        }

        /// <summary>
        /// データを受信したときに発生するイベント
        /// </summary>
        public event Action<TimedLong> DataReceived;
    }
}

