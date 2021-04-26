using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab_3
{
    interface VerificationHandler
    {
        VerificationHandler SetNext(VerificationHandler handler);
        object VerifyOrderData(ClientData order);
    }
}
