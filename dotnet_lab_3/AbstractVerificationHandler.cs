using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lab_3
{
    abstract class AbstractVerificationHandler : VerificationHandler
    {
        protected VerificationHandler _nextHandler;

        public VerificationHandler SetNext(VerificationHandler handler)
        {
            this._nextHandler = handler;

            // Возврат обработчика отсюда позволит связать обработчики простым
            // способом, вот так:
            // monkey.SetNext(squirrel).SetNext(dog);
            return handler;
        }

        public virtual object VerifyOrderData(ClientData order)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.VerifyOrderData(order);
            }
            else
            {
                return null;
            }
        }
    }
}
