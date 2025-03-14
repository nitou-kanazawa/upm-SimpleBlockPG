using System.Collections.Generic;
using UnityEngine;

namespace nitou.BlockPG.DragDrop{
    using nitou.BlockPG.Interface;

    /// <summary>
    /// Base component of spot.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class BPG_Spot : BPG_ComponentBase, I_BPG_Spot {
        
        public abstract Vector2 DropPosition { get; }

        public virtual I_BPG_Block Block { get; protected set; }


        /// ----------------------------------------------------------------------------
        #region Static Method

        private readonly static List<I_BPG_Spot> _spotsList = new();

        public static IReadOnlyList<I_BPG_Spot> ActiveSpots => _spotsList;

        /// <summary>
        /// 指定スポットを登録する．
        /// </summary>
        public static void Register(I_BPG_Spot spot)
        {
            if (spot == null)
                return;

            if (!_spotsList.Contains(spot))
            {
                _spotsList.Add(spot);
            }
        }

        /// <summary>
        /// 指定スポットを登録解除する．
        /// </summary>
        public static void Unregister(I_BPG_Spot spot)
        {
            if (spot == null)
                return;

            _spotsList.Remove(spot);
        }
        #endregion       


        /// ----------------------------------------------------------------------------
        // Lifecycle Events

        private void OnEnable() => BPG_Spot.Register(this);

        private void OnDisable() => BPG_Spot.Unregister(this);

    }

}