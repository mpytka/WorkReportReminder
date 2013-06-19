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
            var m_temporaryCollection = new List<WorkItem>(m_collection.Count);
            foreach (var wi in m_collection)
            {
                if (wi.FirstComment.StartTime >= startTime && wi.LastComment.EndTime <= endTime)
                    m_temporaryCollection.Add(wi);
            }

            m_collection = m_temporaryCollection;
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
            get {
                if (m_collection.Count == 0 || index < 0)
                {
                    return WorkItem.Empty;
                }
                else
                {
                    return m_collection[index];
                }
            }
            set { m_collection[index] = value; }
        }

        public int Count
        {
            get { return m_collection.Count; }
        }

        /// <summary>
        /// Gets last work item from the collection.
        /// If collection contains zero elements it returns empty work item.
        /// </summary>
        public WorkItem LastItem
        {
            get
            {
                if (m_collection.Count > 0)
                {
                    return m_collection[m_collection.Count - 1];
                }

                else return WorkItem.Empty;
            }
        }
    }
}
