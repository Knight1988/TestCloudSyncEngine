using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;

namespace CloudSyncEngine.SyncProvider
{
    public static class StaticClass
    {
        public static void CallBack(in CldApi.CF_CALLBACK_INFO callbackinfo, in CldApi.CF_CALLBACK_PARAMETERS callbackparameters)
        {
            throw new NotImplementedException();
        }
    }
}
