using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkReportReminder.Common;

namespace UnitTests
{
    [TestClass]
    public class WorkItemDtoTests
    {
        private const string COMMENT_CONTENT0 = "The first comment";
        private const long WORK_ITEM_ID = 1;
        private const string WORK_ITEM_TITLE = "Random Work Item Title";
        private readonly DateTime m_commentDateTime0 = new DateTime(2013, 10, 20);
        private readonly DateTime m_commentDateTime1 = new DateTime(2013, 10, 21);

        [TestMethod]
        public void ShouldInstantiateNewWorkItemDto()
        {
            // act
            WorkItemDto workItemDto = new WorkItemDto(WORK_ITEM_ID, WORK_ITEM_TITLE, COMMENT_CONTENT0, m_commentDateTime0);

            // assert
            Assert.AreEqual(WORK_ITEM_ID, workItemDto.Id);
            Assert.AreEqual(WORK_ITEM_TITLE, workItemDto.Title);
            Assert.AreEqual(COMMENT_CONTENT0, workItemDto.Comment);
            Assert.AreEqual(m_commentDateTime0, workItemDto.Time);
           

        }
    }
}
