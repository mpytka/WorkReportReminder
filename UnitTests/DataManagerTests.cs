using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WorkReportReminder.DataManagement;
using WorkReportReminder.DataManagement.XmlData;
using WorkReportReminder.Common.Logger;


namespace UnitTests
{
    [TestClass]
    public class DataManagerTests
    {
        [TestMethod]
        [DeploymentItem(@"DataFiles\output1.xml")]
        public void ShouldCreateDataManager()
        {
            //arrange
            IDataReader reader = new XmlDataReader();
            IDataWriter writer = new XmlDataWriter(reader);
            DataManagementConfiguration config = new DataManagementConfiguration(@"DataFiles\output1.xml");
            //act
            DataManager manager = new DataManager(writer, reader,config);
            //assert
            Assert.IsNotNull(manager);
        }
        [TestMethod]
        [DeploymentItem(@"DataFiles\output1.xml")]
        public void ShouldReturnLastWorkItem()
        {
            var logger = new Logger();
            logger.Configure(true);
            Log.Initialise(logger);

            //arrange
            IDataReader reader = new XmlDataReader();
            IDataWriter writer = new XmlDataWriter(reader);
            DataManagementConfiguration config = new DataManagementConfiguration(@"DataFiles\output1.xml");
            DataManager manager = new DataManager(writer, reader, config);
            //act
            WorkItem workItem = manager.ReadLastItem();
            //assert
            Assert.AreEqual("1", workItem.Id);
            Assert.AreEqual("Test1", workItem.Title);
            Assert.AreEqual("TestComment1", workItem.Comments);
            

        }
    }
}
