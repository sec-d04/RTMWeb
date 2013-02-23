using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRTM.Core;


namespace WebToRTM
{
    [Component(Category = "RtcProjectTemplate1", Name = "RtcProjectTemplate1")]
    public class WebToRTM : DataFlowComponent
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

        //        protected override ReturnCode_t OnInitialize()
        //        {
        //            return ReturnCode_t.RTC_OK;
        //        }

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
    }
}

