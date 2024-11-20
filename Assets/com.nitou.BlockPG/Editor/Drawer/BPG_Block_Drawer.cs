using UnityEngine;
using UnityEditor;
using nitou.BlockPG.Blocks;

namespace nitou.BlockPGEditor.Drawer{

    [CustomEditor(typeof(BPG_EntryBlock))]
    public class BPG_Block_Drawer : Editor{

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
        }
    }
}
