using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkReportReminder.DataManagement;

namespace UnitTests
{
    [TestClass]
    public class WorkItemTest
    {
        private const long WORK_ITEM_ID = 1;
        private const string WORK_ITEM_TITLE = "First task";
        private const string THIS_ONE_HAS_LOW_PRIORITY = "This one has low priority";
        private const string COMMENT_CONTENT0 = "Random content 0";
        private const string COMMENT_CONTENT1 = "Random content 1";
        private const string COMMENT_CONTENT2 = "Random content 2";

        private readonly DateTime m_workItemStartTime = new DateTime(2013, 09, 20);
        private readonly DateTime m_commentDate1 = new DateTime(2013, 09, 21);
        private readonly DateTime m_commentDate2 = new DateTime(2013, 09, 22);

        [TestMethod]
        public void ShouldInstantiateNewWorkItemWithOneComment()
        {
            // arrange
            const int EXP_COMMENTS_COUNT = 1;

            // act
            WorkItem workItem = 
                new WorkItem(WORK_ITEM_ID, WORK_ITEM_TITLE, m_workItemStartTime, THIS_ONE_HAS_LOW_PRIORITY);

            // assert
            Assert.IsNotNull(workItem);
            Assert.AreEqual(WORK_ITEM_ID, workItem.Id);
            Assert.AreEqual(WORK_ITEM_TITLE, workItem.Title);
            Assert.AreEqual(EXP_COMMENTS_COUNT, workItem.Comments.Count);
        }

        [TestMethod]
        public void ShouldAddTwoMoreComments()
        {
            // arrange
            WorkItem workItem = 
                new WorkItem(WORK_ITEM_ID, WORK_ITEM_TITLE, m_workItemStartTime, COMMENT_CONTENT0);

            // act
            workItem.AddComment(COMMENT_CONTENT1, m_commentDate1);
            workItem.AddComment(COMMENT_CONTENT2, m_commentDate2);

            // assert
            Assert.AreEqual(3, workItem.Comments.Count);
        }

        [TestMethod]
        public void ShouldReturnLastCommentAdded()
        {
            // arrange
            WorkItem workItem = 
                new WorkItem(WORK_ITEM_ID, WORK_ITEM_TITLE, m_workItemStartTime, COMMENT_CONTENT0);
            workItem.AddComment(COMMENT_CONTENT1, m_commentDate1);
            workItem.AddComment(COMMENT_CONTENT2, m_commentDate2);

            // act
            WorkItemComment workItemComment = workItem.LastComment;

            // assert
            Assert.AreEqual(COMMENT_CONTENT2, workItemComment.Title);
        }

        [TestMethod]
        public void ShouldReturnFirstCommentAdded()
        {
            // arrange
            WorkItem workItem = 
                new WorkItem(WORK_ITEM_ID, WORK_ITEM_TITLE, m_workItemStartTime, COMMENT_CONTENT0);
            workItem.AddComment(COMMENT_CONTENT1, m_commentDate1);
            workItem.AddComment(COMMENT_CONTENT2, m_commentDate2);

            // act
            WorkItemComment workItemComment = workItem.FirstComment;

            // assert
            Assert.AreEqual(COMMENT_CONTENT0, workItemComment.Title);
        }
    }
}
