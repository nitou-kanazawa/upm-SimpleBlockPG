using UnityEngine;

namespace nitou.BlockPG.Interface {

    public interface I_BPG_ProgrammingEnv {

        RectTransform RectTransform { get; }
    }


    /// <summary>
    /// Extension methods for type of <see cref="I_BPG_Spot"/>.
    /// </summary>
    public static class BPG_ProgrammingEnv_Extensions {

        public static void Append(this I_BPG_ProgrammingEnv self, I_BPG_Draggable draggabble) {
            Debug.Log("Append to programming env.");

            draggabble.RectTransform.SetParent(self.RectTransform);
        }

    }

}
