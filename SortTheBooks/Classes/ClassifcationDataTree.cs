using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTheBooks.Classes
{
    internal class ClassifcationDataTree
    {
        public class TreeNode<T> : IEnumerable<TreeNode<T>>
        {
            IEnumerator<TreeNode<T>> IEnumerable<TreeNode<T>>.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

    }
}
