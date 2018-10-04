using System.Collections;
using System.Collections.Generic;

namespace XCalculateLib
{
    public class PhaseCollection : IPhaseCollection
    {
        private readonly List<IPhase> phaseList = new List<IPhase>();

        public IPhase this[int index]
        {
            get { return this.phaseList[index]; }
            set { this.phaseList[index] = value; }
        }

        public int Count
        {
            get { return this.phaseList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public PhaseCollection()
        {
        }

        public PhaseCollection(IPhaseCollection collection)
        {
            foreach (var phase in collection)
            {
                this.Add(phase);
            }
        }

        public void Add(IPhase phase)
        {
            this.phaseList.Add(phase);
        }

        public void Clear()
        {
            this.phaseList.Clear();
        }

        public bool Contains(IPhase phase)
        {
            return this.phaseList.Contains(phase);
        }

        public void CopyTo(IPhase[] array, int arrayIndex)
        {
            this.phaseList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IPhase> GetEnumerator()
        {
            return this.phaseList.GetEnumerator();
        }

        public int IndexOf(IPhase phase)
        {
            return this.phaseList.IndexOf(phase);
        }

        public void Insert(int index, IPhase phase)
        {
            this.phaseList.Insert(index, phase);
        }

        public bool Remove(IPhase phase)
        {
            return this.phaseList.Remove(phase);
        }

        public void RemoveAt(int index)
        {
            this.phaseList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IPhaseCollection AddPhase(IPhase phase)
        {
            this.Add(phase);

            return this;
        }
    }
}
