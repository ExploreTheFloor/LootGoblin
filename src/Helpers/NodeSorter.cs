using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGoblin.Helpers
{
    // Create a node sorter that implements the IComparer interface.
    public class BidSorter : IComparer
    {
        // Compare the length of the strings, or the strings
        // themselves, if they are the same length.
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            try
            {
                var firstCompare = Convert.ToInt32(tx.Text.Split("|")[0].Trim());
                var secondCompare = Convert.ToInt32(ty.Text.Split("|")[0].Trim());
                if (firstCompare > secondCompare)
                    return 0;
                // Compare the length of the strings, returning the difference.
                //if (tx.Text.Length != ty.Text.Length)
                //    return tx.Text.Length - ty.Text.Length;

                // If they are the same length, call Compare.
                return 1;
            }
            catch (Exception e)
            {
            }
            return 1;
        }
    }
}
