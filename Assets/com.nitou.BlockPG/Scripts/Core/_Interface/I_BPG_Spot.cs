using UnityEngine;

namespace nitou.BlockPG.Interface{

    public interface I_BPG_Spot {

        RectTransform RectTransform { get; }

        Vector2 DropPosition { get; }

        I_BPG_Block Block { get; }
    }


    /// <summary>
    /// Extension methods for type of <see cref="I_BPG_Spot"/>.
    /// </summary>
    public static class BPG_Spot_Extensions {

        /// <summary>
        /// <see cref="I_BPG_ProgrammingEnv"/> whitch spot is belong.
        /// </summary>
        public static I_BPG_ProgrammingEnv GetRelatedProgEnv_BE2(this I_BPG_Spot self) {
            
            // parent
            var programmingEnv = self.RectTransform.GetComponentInParent<I_BPG_ProgrammingEnv>();
            
            // child
            if (programmingEnv == null && self.RectTransform.childCount > 0) {
                programmingEnv = self.RectTransform.GetChild(0).GetComponentInParent<I_BPG_ProgrammingEnv>();
            }

            return programmingEnv;
        }

    }
}
