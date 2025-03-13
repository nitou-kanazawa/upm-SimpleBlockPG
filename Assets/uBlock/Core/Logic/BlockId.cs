using System;

namespace Nitou.BlockPG {

    [Serializable]
    public record BlockId {

        public Guid Value { get; }

        public BlockId(Guid value) {
            Value = value;
        }
    }
}
