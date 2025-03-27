using System;
using System.Collections.Generic;

namespace Nitou.uBlock {
    
    [Serializable]
    public abstract class TreeNodeBase<TNode> : ITreeNode<TNode>
        where TNode : TreeNodeBase<TNode>, ITreeNode<TNode> {


        public TNode Self => this as TNode;

        /// <summary>
        /// �e�m�[�h�D
        /// </summary>
        public TNode? Parent { get; private set; }

        /// <summary>
        /// �q�m�[�h�D
        /// </summary>
        public abstract IEnumerable<TNode> Children { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        public TreeNodeBase() {

        }



        /// ----------------------------------------------------------------------------
        // Protected Method

        protected virtual bool CanAddChildNode(TNode child) {
            if (child == null) return true;


            throw new NotImplementedException();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// Called by the parent node during processes like addition or removal.
        /// </summary>
        /// <param name="newParent">�V�����e�m�[�h</param>
        /// <returns>True if the parent node is successfully set; otherwise, false.</returns>
        private bool SetParent(TNode? newParent) {
            if (this.Parent == newParent) return false;
            this.Parent = newParent;
            return true;
        }
    }
}
