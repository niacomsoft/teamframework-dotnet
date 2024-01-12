// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Niacomsoft.Utilities;

namespace Niacomsoft.IO
{
    /// <summary> 提供了字节 <see cref="byte" /> 数组配置选项相关的方法。 密闭的，不可以从此类型派生。 </summary>
    /// <remarks> 密闭的，不可以从此类型派生。 </remarks>
    public sealed class ByteArrayOptions
    {
        /// <summary> 初始化 <see cref="ByteArrayOptions" /> 类的新实例。 </summary>
        /// <param name="index"> 字节数据读取、写入的索引数值。 </param>
        /// <param name="count"> 字节数据读取、写入的字节个数。 </param>
        public ByteArrayOptions(int index, int count)
        {
            Index = index;
            Count = count;
        }

        /// <summary> 字节数据读取、写入的字节个数。 </summary>
        /// <value> 获取一个 <see cref="int" /> 类型值，用于表示字节数据读取、写入的字节个数。 </value>
        public int Count { get; }

        /// <summary> 字节数据读取、写入的索引数值。 </summary>
        /// <value> 获取一个 <see cref="int" /> 类型值，用于表示字节数据读取、写入的索引数值。 </value>
        public int Index { get; }

        /// <summary> 从一个字节数组创建一个 <see cref="ByteArrayOptions" /> 类型的对象实例。 </summary>
        /// <param name="bytes"> 字节数组。 </param>
        /// <returns> <see cref="ByteArrayOptions" /> 类型的对象实例。 </returns>
        /// <exception cref="ArgumentNullException"> 当 <paramref name="bytes" /> 等于 <see langword="null" /> 时，将引发此类型的异常。 </exception>
        /// <exception cref="OverflowException"> 当访问 <c> bytes.Length </c> 属性时，可能引发此类型的异常。 </exception>
        public static ByteArrayOptions FromByteArray(byte[] bytes)
        {
            if (AssertUtilities.IsNull(bytes))
            {
                throw new ArgumentNullException(SR.GetString("ArgumentNullException_default_message"));
            }
            return new ByteArrayOptions(0, bytes.Length);
        }
    }
}