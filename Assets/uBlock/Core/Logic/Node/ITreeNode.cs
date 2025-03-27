using System;
using System.Collections.Generic;

namespace Nitou.uBlock {

    public interface ITreeNode<TNode> 
        where TNode: ITreeNode<TNode> {

        /// <summary>
        /// �e�m�[�h�D
        /// </summary>
        TNode? Parent { get;}

        /// <summary>
        /// �q�m�[�h�D
        /// </summary>
        IEnumerable<TNode> Children { get; }
    }


    public interface IMutableTreenNode<TNode> : ITreeNode<TNode> 
        where TNode: IMutableTreenNode<TNode> {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        TNode AddChild(TNode child);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        TNode InsertChild(int index, TNode child);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        TNode RemoveChild(TNode child);

        /// <summary>
        /// �S�Ă̎q�v�f����菜���D
        /// </summary>
        /// <returns>��菜���ꂽ�q�v�f</returns>
        IReadOnlyList<TNode> ClearChildren();
    }    
}
