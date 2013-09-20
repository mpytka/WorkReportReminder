using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkReportReminder.DataManagement;

namespace UnitTests
{
    [TestClass]
    public class WorkItemCommentTest
    {
        private readonly DateTime m_commentDateTime0 = new DateTime(2013, 09, 20);
        private readonly DateTime m_commentDateTime1 = new DateTime(2013, 09, 21);
        private const string COMMENT_CONTENT0 = "Random content 0";
        private const string COMMENT_CONTENT1 = "Random content 1";

        [TestMethod]
        public void ShouldInstantiate()
        {
            // act
            WorkItemComment workItemComment = new WorkItemComment(COMMENT_CONTENT0, m_commentDateTime0);

            // assert
            Assert.AreEqual(COMMENT_CONTENT0, workItemComment.Title);
            Assert.AreEqual(m_commentDateTime0, workItemComment.StartTime);
            Assert.AreEqual(m_commentDateTime0, workItemComment.EndTime);
        }

        [TestMethod]
        public void ShouldSetEndTime()
        {
            // arrange
            DateTime endDateTime = new DateTime(2013, 09, 21);
            WorkItemComment workItemComment = new WorkItemComment(COMMENT_CONTENT0, m_commentDateTime0);

            // act
            workItemComment.SetEndTime(endDateTime);

            // assert
            Assert.AreEqual(endDateTime, workItemComment.EndTime);
        }

        [TestMethod]
        public void ShouldReturnZeroWhenComparingTwoWorkItemComments()
        {
            // arrange
            WorkItemComment workItemComment0 = new WorkItemComment(COMMENT_CONTENT0, m_commentDateTime0);
            WorkItemComment workItemComment1 = new WorkItemComment(COMMENT_CONTENT0, m_commentDateTime0);

            // act
            int result = workItemComment0.CompareTo(workItemComment1);

            // assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ShouldReturnOneWhenComparingTwoWorkItemComments()
        {
            // arrange
            WorkItemComment workItemComment0 = new WorkItemComment(COMMENT_CONTENT0, m_commentDateTime0);
            WorkItemComment workItemComment1 = new WorkItemComment(COMMENT_CONTENT1, m_commentDateTime1);

            // act
            int result = workItemComment0.CompareTo(workItemComment1);

            // assert
            Assert.AreEqual(1, result);
        }
    }
}
