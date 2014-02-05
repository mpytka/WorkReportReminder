using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WorkReportReminder.DataManagement;
using WorkReportReminder.DataManagement.XmlData;


namespace UnitTests
{
    [TestClass]
    public class DataManagerTests
    {
        [TestMethod]
        [DeploymentItem(@"DataFiles\output1.xml")]
        public void ShouldCreateDataManager()
        {
            IDataReader reader = new XmlDataReader();
            IDataWriter writer = new XmlDataWriter(reader);
            DataManagementConfiguration config = new DataManagementConfiguration(@"DataFiles\output1.xml");
            DataManager manager = new DataManager(writer, reader,config);
        }
    }
}
