using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
    class NotifyByEmail : Inotifier

    {
        public string Notify()
        {
            return "notification will be sent by email";
        }
    }
}
