using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkReportReminder.DataManagement;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class WorkItemsListTests
    {
        private const long WORK_ITEM_ID1 = 1;
        private const long WORK_ITEM_ID2 = 2;
        private const long WORK_ITEM_ID3 = 3;
        private const string WORK_ITEM_TITLE1 = "First task";
        private const string WORK_ITEM_TITLE2 = "Second task";
        private const string WORK_ITEM_TITLE3 = "Third task";
        private const string COMMENT_CONTENT0 = null;

        [TestMethod]
        public void ShouldCollectionBeEmpty()
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
        [TestMethod]
        public void ShouldReturnTwoCountedElements() // count method
        {
            //arrange
            const int EXP_COUNT = 2;
            WorkItem firstItem = new WorkItem(1, "title", null);
            WorkItem secondItem = new WorkItem(2, "title", null);
            WorkItemsList itemsList = new WorkItemsList();

            //act
            itemsList.Add(firstItem);
            itemsList.Add(secondItem);

            //assert
            Assert.AreEqual(EXP_COUNT, itemsList.Count);
        }
        [TestMethod]
        public void ShouldReturnLastElement() 
        {
            //arrange
            WorkItem item = new WorkItem(1, "title", null);
            WorkItem secondItem = new WorkItem(2, "newWI", null);
            WorkItemsList itemsList = new WorkItemsList();
            itemsList.Add(item);
            itemsList.Add(secondItem);

            //act
            WorkItem result = itemsList.LastItem;
           
            //assert
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("newWI", result.Title);
            Assert.AreEqual(null, result.Comments);
        }
        [TestMethod]
        public void ShouldReturnEmptyWorkItemWhenNoItemsAdded() 
        {
            //arrange
            WorkItemsList itemsList = new WorkItemsList();
            
            //act
            WorkItem result = itemsList.LastItem;

            //assert
            Assert.AreEqual(0, result.Id);
            Assert.AreEqual(string.Empty, result.Title);
            Assert.AreEqual(1, result.Comments.Count);
        }
    }
}
