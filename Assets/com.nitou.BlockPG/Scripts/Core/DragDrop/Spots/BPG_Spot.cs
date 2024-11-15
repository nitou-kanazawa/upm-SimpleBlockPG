using System.Collections.Generic;
using UnityEngine;

namespace nitou.BlockPG.DragDrop{
    using nitou.BlockPG.Interface;


    public static class BPG_Spot{

        /// ----------------------------------------------------------------------------
        #region Static Method

        private static List<I_BPG_Spot> _spotsList = new();

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


        

    }

}