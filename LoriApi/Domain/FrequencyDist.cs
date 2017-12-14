using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain
{
    /// <summary>
    /// Manages Frequency Distributions for items of type T
    /// </summary>
    /// <typeparam name="T">Type for item</typeparam>
    public class FrequencyDist<T>
    {
        /// <summary>
        /// Construct Frequency Distribution for the given list of items
        /// </summary>
        /// <param name="li">List of items to calculate for</param>
        public FrequencyDist(IEnumerable<T> li)
        {
            CalcFreqDist(li);
        }

        /// <summary>
        /// Construct Frequency Distribution for the given list of items, across all keys in itemValues
        /// </summary>
        /// <param name="li">List of items to calculate for</param>
        /// <param name="itemValues">Entire list of itemValues to include in the frequency distribution</param>
        public FrequencyDist(IReadOnlyCollection<T> li, ICollection<T> itemValues)
        {
            CalcFreqDist(li);
            // add items to frequency distribution that are in itemValues but missing from the frequency distribution
            foreach (var v in itemValues)
            {
                if (!ItemFreq.Keys.Contains(v))
                {
                    ItemFreq.Add(v, new Item { Value = v, Count = 0 });
                }
            }
            // check that all values in li are in the itemValues list
            foreach (var v in li)
            {
                if (!itemValues.Contains(v))
                    throw new Exception(string.Format("FrequencyDist: Value in list for frequency distribution not in supplied list of values: '{0}'.", v));
            }
        }

        /// <summary>
        /// Calculate the frequency distribution for the values in list
        /// </summary>
        /// <param name="li">List of items to calculate for</param>
        private void CalcFreqDist(IEnumerable<T> li)
        {
            ItemFreq = new SortedList<T, Item>((from item in li
                group item by item into theGroup
                select new Item { Value = theGroup.FirstOrDefault(), Count = theGroup.Count() }).ToDictionary(q => q.Value, q => q));
        }

        

        /// <summary>
        /// Getter for the Item Frequency list
        /// </summary>
        public SortedList<T, Item> ItemFreq { get; private set; } = new SortedList<T, Item>();

        public int Freq(T value)
        {
            return ItemFreq.Keys.Contains(value) ? ItemFreq[value].Count : 0;
        }

        /// <summary>
        /// Returns the list of distinct values between two lists
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static List<T> GetDistinctValues(List<T> l1, List<T> l2)
        {
            return l1.Concat(l2).ToList().Distinct().ToList();
        }

        /// <summary>
        /// Manages a count of items (int, string etc) for frequency counts
        /// </summary>
        /// <typeparam name="T">The type for item</typeparam>
        public class Item
        {
            /// <summary>
            /// The value of the item, e.g. int or string
            /// </summary>
            public T Value { get; set; }
            /// <summary>
            /// The count of the item
            /// </summary>
            public int Count { get; set; }
        }
    }
}
