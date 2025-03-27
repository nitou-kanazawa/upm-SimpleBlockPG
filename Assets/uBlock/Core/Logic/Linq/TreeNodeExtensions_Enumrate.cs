using System;
using System.Collections.Generic;
using System.Linq;

namespace Nitou.uBlock {

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="node"></param>
    /// <returns></returns>
    public delegate IEnumerable<T?> GetNodesDelegate<T>(T node) where T : ITreeNode<T>;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">�m�[�h�̌^�D</typeparam>
    /// <param name="currentNode">���݂̃m�[�h�D</param>
    /// <param name="newNodes">�ǉ����ꂽ�m�[�h�D</param>
    /// <param name="remainingNodes">�������̃m�[�h�D</param>
    /// <returns></returns>
    public delegate IEnumerable<T?> UpdatePendingNodesDelegate<T>(
        T currentNode, IEnumerable<T?> newNodes, IEnumerable<T?> remainingNodes
    ) where T : ITreeNode<T>;


    /// <summary>
    /// <see cref="ITreeNode{TNode}"/> �^�̊g�����\�b�h��񋟂���D
    /// </summary>
    public static partial class TreeNodeExtensions {

        /// ----------------------------------------------------------------------------
        #region �v�f�̗�

        /// <summary>
		/// Expands and enumerates a tree structure starting from the current node, allowing custom logic for adding and updating nodes during the traversal.
		/// </summary>
		/// <typeparam name="T">�m�[�h�̌^�D</typeparam>
		/// <param name="startNode">�J�n�m�[�h�D</param>
		/// <param name="getNodes">
		/// A function that determines additional nodes to add based on the specified node.  
		/// Takes the current node as an argument and returns a collection of nodes related to it.
		/// </param>
		/// <param name="updatePendingNodes">
		/// A function that updates the list of unenumerated nodes during traversal. This function takes the following arguments:
		/// <list type="bullet">
		/// <item><description>���݂̃m�[�h�D The value passed as the first argument to the <paramref name="getNodes"/> function.</description></item>
		/// <item><description>�ǉ����ꂽ�m�[�h�D The return value of the <paramref name="getNodes"/> function.</description></item>
		/// <item><description>�������̃m�[�h�D
		/// <para>If the head element of this collection has not been used as an argument to <paramref name="getNodes"/>, it will be passed as the argument to <paramref name="getNodes"/>. </para>
        /// <para>If it has already been used as an argument to <paramref name="getNodes"/>, that element will be enumerated.</para>
		/// </description></item>
		/// </list>
		/// </param>
		public static IEnumerable<T> Evolve<T>(this ITreeNode<T> startNode,
            GetNodesDelegate<T> getNodes,
            UpdatePendingNodesDelegate<T> updatePendingNodes
        ) where T : ITreeNode<T> {
            ISet<T> exphistory = new HashSet<T>();  //�W�J��������
            ISet<T> rtnhistory = new HashSet<T>();  //�񋓂�������
            IEnumerable<T?> seeds = new T[1] { (T)startNode };
            while (expand(ref exphistory, out T? cur, ref seeds, getNodes, updatePendingNodes)) {
                if (cur != null && rtnhistory.Add(cur)) yield return cur;
            }
        }

        /// <summary>
        /// �c���[�̒T���𐧌䂷�郁�\�b�h�D
        /// </summary>
        private static bool expand<T>(ref ISet<T> history, out T? cur, ref IEnumerable<T?> seeds,
            GetNodesDelegate<T> getNewSeeds,
            UpdatePendingNodesDelegate<T> updateseeds
        ) where T : ITreeNode<T> {
            if (!seeds.Any()) { cur = default; return false; }
            cur = seeds.First();
            while (cur != null && history.Add(cur)) {
                var newSeeds = getNewSeeds(cur);
                seeds = updateseeds(cur, newSeeds, seeds.Skip(1));
                cur = seeds.FirstOrDefault();
            }
            seeds = seeds.Skip(1);
            return true;
        }


        #endregion

    }
}
