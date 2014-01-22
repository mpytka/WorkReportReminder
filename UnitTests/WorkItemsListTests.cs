using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkReportReminder.DataManagement;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class WorkItemsListTests
    {
        [TestMethod]
        public void ShouldCollectionIsEmpty()
        {
            //arrange
            const int EXP_COUNT = 0;

            //act
            WorkItemsList itemsList = new WorkItemsList();

            //assert
            Assert.AreEqual(EXP_COUNT, itemsList.Count);
        }

        [TestMethod]
        public void ShouldSetCountToThreeWhenPassingThreeElements()
        {
            //arrange
            const int EXP_COUNT = 3;
            List<WorkItem> elements = new List<WorkItem>();
            elements.Add(new WorkItem(1, "title1", null));
            elements.Add(new WorkItem(2, "title1", null));
            elements.Add(new WorkItem(3, "title1", null));

            //act
            WorkItemsList itemsList = new WorkItemsList(elements);

            //assert
            Assert.AreEqual(EXP_COUNT, itemsList.Count);
        }

        [TestMethod]
        public void ShouldReturnCountIncremented()
        {
            //arrange
            const int EXP_COUNT = 1;
            WorkItem item = new WorkItem(1, "title", null);
            WorkItemsList itemsList = new WorkItemsList();
            
            //act
            itemsList.Add(item);

            //assert
            Assert.AreEqual(EXP_COUNT, itemsList.Count);
        }

        [TestMethod]
        public void ShouldCheckIfWorkItemEmptyWhenIndexBelowZero()
        {
            //arrange
            WorkItem item = new WorkItem(1, "title", null);
            WorkItemsList itemsList = new WorkItemsList();
            itemsList.Add(item);
            int INDEX = -1;

            //act
            WorkItem result = itemsList[INDEX];

            //assert
            Assert.AreEqual(0, result.Id);
            Assert.AreEqual(string.Empty, result.Title);
            Assert.AreEqual(string.Empty, result.Comments[0].Title);
        }

        [TestMethod]
        public void ShouldCheckIfWorkItemEmptyWhenCountEqualsZeroAndIndexBiggerThanZero()
        {
            //arrange
            WorkItemsList itemsList = new WorkItemsList();
            int INDEX = 0;

            //act
            WorkItem result = itemsList[INDEX];

            //assert
            Assert.AreEqual(0, result.Id);
            Assert.AreEqual(string.Empty, result.Title);
            Assert.AreEqual(string.Empty, result.Comments[0].Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowException()
        {
            //arrange
            WorkItem item = new WorkItem(1, "title", null);
            WorkItemsList itemsList = new WorkItemsList();
            int INDEX = 1;
            itemsList.Add(item);

            //act
            WorkItem result = itemsList[INDEX];
        }

        [TestMethod]
        public void ShouldReturnFirstElement()
        {
            //arrange
            WorkItem item = new WorkItem(1, "title", null);
            WorkItemsList itemsList = new WorkItemsList();
            int INDEX = 0;
            itemsList.Add(item);
           
            //act
            WorkItem result = itemsList[INDEX];

            //assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("title" , result.Title);
            Assert.AreEqual(null, result.Comments);
        }
    }
}
