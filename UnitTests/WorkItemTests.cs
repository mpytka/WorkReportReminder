using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkReportReminder.DataManagement;

namespace UnitTests
{
    [TestClass]
    public class WorkItemTests
    {
        [TestMethod]
        public void ShouldSetEndTime()
        {
            // arrange
            DateTime wiStartTime = new DateTime(2013, 01, 01, 00, 00, 00);
            DateTime expectedEndTime = new DateTime(2013, 02, 01, 12, 30, 00);

            WorkItem workItem =
                new WorkItem(id: 0, title: "testTitle", 
                    startTime: wiStartTime, comment: "testComment");

            // act
            workItem.UpdateEndTime(expectedEndTime);

            // assert
            Assert.AreEqual(expectedEndTime, workItem.EndTime);
            Assert.AreEqual(1, workItem.Comments.Count);
            Assert.AreEqual("testComment", workItem.Comments[0].Content);
            Assert.AreEqual(wiStartTime, workItem.Comments[0].Time);
        }

        [TestMethod]
        public void ShouldAddNewCommentItem()
        {
            // arrange
            string contentComment = "example comment";
            DateTime wiStartTime = new DateTime(2013, 01, 01, 00, 00, 00);
            DateTime commentTime = new DateTime(2013, 01, 02, 00, 00, 00);

            WorkItem workItem =
                new WorkItem(id: 0, title: "testTitle",
                    startTime: wiStartTime, comment: "testComment");

            // act
            workItem.AddComment(contentComment, commentTime);

            // assert
            Assert.AreEqual(2, workItem.Comments.Count);
            Assert.AreEqual(contentComment, workItem.Comments[1].Content);
            Assert.AreEqual(commentTime, workItem.Comments[1].Time);
        }
    }
}
