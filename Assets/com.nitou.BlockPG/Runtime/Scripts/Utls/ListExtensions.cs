using System.Collections.Generic;

namespace nitou.AssetLoader {

    /// <summary>
    /// Extension methods for type of <see cref="IList{T}"/>.
    /// </summary>
    public static class ListExtensions {

        /// <summary>
        /// 指定したインデックスがリスト範囲内か確認する
        /// </summary>
        public static bool IsInRange<T>(this int index, IReadOnlyList<T> list) {
            return 0 <= index && index < list.Count;
        }

        /// <summary>
        /// 指定したインデックスがリスト範囲外か確認する
        /// </summary>
        public static bool IsOutOfRange<T>(this int index, IReadOnlyList<T> list) {
            return !index.IsInRange(list);
        }
    }
}
