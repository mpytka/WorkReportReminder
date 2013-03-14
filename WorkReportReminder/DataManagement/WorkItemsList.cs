using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WorkReportReminder.DataManagement
{
    public class WorkItemsList : IEnumerable<WorkItem>
    {
        private List<WorkItem> m_collection;

        public WorkItemsList()
        {
            m_collection = new List<WorkItem>();
        }

        public WorkItemsList(IEnumerable<WorkItem> collection)
        {
            m_collection = collection.ToList<WorkItem>();
        }

        public void Add(WorkItem newItem)
        {
            m_collection.Add(newItem);
        }

        public void ResetFilters()
        {
            //m_modifiedCollection = (WorkItemsList)m_collection;
        }

        public WorkItemsList Filter(DateTime startTime, DateTime endTime)
        {
            m_collection = m_collection.Where(item => item.StartTime >= startTime && item.EndTime <= endTime).ToList();
            return this;
        }

        public WorkItemsList Filter(int minId, int maxId)
        {
            m_collection = m_collection.Where(item => item.Id >= minId && item.Id <= maxId).ToList();
            return this;
        }

        public WorkItem Find(Predicate<WorkItem> match)
        {
            return m_collection.Find(match);
        }


        #region IEnumerable<WorkItem> Members

        public IEnumerator<WorkItem> GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }

        #endregion

        public WorkItem this[int index]
        {
            get { return m_collection[index]; }
            set { m_collection[index] = value; }
        }

        public int Count
        {
            get { return m_collection.Count; }
        }
    }
}
