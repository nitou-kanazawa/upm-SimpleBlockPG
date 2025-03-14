using UnityEngine;

namespace nitou.BlockPG{
    using nitou.BlockPG.Interface;
    using nitou.BlockPG.Blocks;

    public static class BPG_BlockUtils {

        private static readonly string folderPath = "BlockPG/Blocks";

        public static TBlock LoadBlockPrefab<TBlock>(string prefabName)
            where TBlock : BPG_BlockBase {
            var prefab = Resources.Load<GameObject>($"{folderPath}/{prefabName}") as TBlock;
            return prefab;
        }

        public static BPG_BlockBase LoadBlockPrefab(string prefabName) {
            return LoadBlockPrefab<BPG_BlockBase>(prefabName);
        }


        public static TBlock CreateBlock<TBlock>(TBlock blockPrefab, I_BPG_ProgrammingEnv programmingEnv)
            where TBlock : BPG_BlockBase {
            
            // create instance
            var block = MonoBehaviour.Instantiate<TBlock>(blockPrefab);

            // setup param
            block.name = blockPrefab.name;
            block.transform.localPosition = Vector3.zero;
            block.transform.localEulerAngles = Vector3.zero;

            programmingEnv.Append(block);
            return block;
        }

    }
}
