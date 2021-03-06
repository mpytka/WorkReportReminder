﻿using WorkReportReminder.Common;
using WorkReportReminder.UI.Layout;

namespace WorkReportReminder.Core
{
    internal interface IApplicationBuilder
    {
        /// <summary>
        /// Creates ui core service.
        /// </summary>
        UICore CreateUICore();

        /// <summary>
        /// Creates data manager service.
        /// </summary>
        IDataManager CreateDataManager();

        /// <summary>
        /// Creates time guard service.
        /// </summary>
        ITimeGuard CreateTimeGuard();

        /// <summary>
        /// Creates core mediator user to mediate between UI and other parts of application.
        /// </summary>
        /// <returns></returns>
        CoreMediator CreateMediator();
    }
}
