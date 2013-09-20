using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkReportReminder.DataManagement;

namespace UnitTests
{
    [TestClass]
    public class WorkItemTest
    {
        private const long m_workItemId = 1;
        private const string m_workItemTitle = "First task";
        private const string m_thisOneHasLowPriority = "This one has low priority";
        private const string m_commentContent0 = "This one has low priority";
        private const string m_commentContent1 = "Additional comment 1";
        private const string m_commentContent2 = "Additional comment 2";

        private readonly DateTime m_workItemStartTime = new DateTime(2013, 09, 20);
        private readonly DateTime m_commentDate1 = new DateTime(2013, 09, 21);
        private readonly DateTime m_commentDate2 = new DateTime(2013, 09, 22);

        [TestMethod]
        public void ShouldInstantiateNewWorkItemWithOneComment()
        {
            // arrange
            const int EXP_COMMENTS_COUNT = 1;

            // act
            WorkItem workItem = new WorkItem(m_workItemId, m_workItemTitle, m_workItemStartTime, m_thisOneHasLowPriority);

            // assert
            Assert.IsNotNull(workItem);
            Assert.AreEqual(m_workItemId, workItem.Id);
            Assert.AreEqual(m_workItemTitle, workItem.Title);
            Assert.AreEqual(EXP_COMMENTS_COUNT, workItem.Comments.Count);
        }

        [TestMethod]
        public void ShouldAddTwoMoreComments()
        {
            // arrange
            WorkItem workItem = new WorkItem(m_workItemId, m_workItemTitle, m_workItemStartTime, m_commentContent0);

            // act
            workItem.AddComment(m_commentContent1, m_commentDate1);
            workItem.AddComment(m_commentContent2, m_commentDate2);

            // assert
            Assert.AreEqual(3, workItem.Comments.Count);
        }

        [TestMethod]
        public void ShouldReturnLastCommentAdded()
        {
            // arrange
            WorkItem workItem = new WorkItem(m_workItemId, m_workItemTitle, m_workItemStartTime, m_commentContent0);
            workItem.AddComment(m_commentContent1, m_commentDate1);
            workItem.AddComment(m_commentContent2, m_commentDate2);

            // act
            WorkItemComment workItemComment = workItem.LastComment;

            // assert
            Assert.AreEqual(m_commentContent2, workItemComment.Title);
        }

        [TestMethod]
        public void ShouldReturnFirstCommentAdded()
        {
            // arrange
            WorkItem workItem = new WorkItem(m_workItemId, m_workItemTitle, m_workItemStartTime, m_commentContent0);
            workItem.AddComment(m_commentContent1, m_commentDate1);
            workItem.AddComment(m_commentContent2, m_commentDate2);

            // act
            WorkItemComment workItemComment = workItem.FirstComment;

            // assert
            Assert.AreEqual(m_commentContent0, workItemComment.Title);
        }
    }
}
