using UnityEngine;

namespace nitou.BlockPG.Interface{

    public interface I_BPG_Spot {

        RectTransform RectTransform { get; }

        Vector2 DropPosition { get; }

    }

    /// <summary>
    /// <see cref="I_BPG_Spot"/>型の基本的な拡張メソッド集．
    /// </summary>
    public static class BPG_Spot_Extensions {


    }
}
