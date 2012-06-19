using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkReportReminder.DataManagement
{
    interface IDataManager
    {
        bool Write(string data);

        string Read();
    }
}
