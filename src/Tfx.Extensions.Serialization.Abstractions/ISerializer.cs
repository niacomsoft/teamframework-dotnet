// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.IO;
using System.Threading.Tasks;

namespace Niacomsoft.TeamFramework.Extensions.Serialization
{
    /// <summary> 定义了数据序列化的接口。 </summary>
    public interface ISerializer
    {
        /// <summary> 从流 <paramref name="inputStream" /> 中反序列化读取数据契约。 </summary>
        /// <param name="inputStream">
        /// 输入流。
        /// <para> 派生自 <see cref="Stream" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 数据契约。 </returns>
        /// <seealso cref="Stream" />
        object Deserialize(Stream inputStream);

        /// <summary> 从流 <paramref name="inputStream" /> 中反序列化读取 <typeparamref name="T" /> 类型的数据契约。 </summary>
        /// <typeparam name="T"> 数据契约类型。 </typeparam>
        /// <param name="inputStream">
        /// 输入流。
        /// <para> 派生自 <see cref="Stream" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> <typeparamref name="T" /> 类型的对象实例。 </returns>
        /// <seealso cref="Stream" />
        T Deserialize<T>(Stream inputStream) where T : class, new();

        /// <summary> 从字节数组反序列化读取 <typeparamref name="T" /> 类型的数据契约。 </summary>
        /// <typeparam name="T"> 数据契约类型。 </typeparam>
        /// <param name="bytes"> 字节数组。 </param>
        /// <param name="offset"> 读取字节数组起始索引数值。 </param>
        /// <param name="length">
        /// 读取字节数组长度。
        /// <para> 当 <paramref name="length" /> 小于等于 <c> 0 </c> 时，将使用 <c> bytes.Length </c> 代替。 </para>
        /// </param>
        /// <returns> <typeparamref name="T" /> 类型的对象实例。 </returns>
        T Deserialize<T>(byte[] bytes, int offset = 0, int length = 0) where T : class, new();

        /// <summary> 从字节数组反序列化读取数据契约。 </summary>
        /// <param name="bytes"> 字节数组。 </param>
        /// <param name="offset"> 读取字节数组起始索引数值。 </param>
        /// <param name="length">
        /// 读取字节数组长度。
        /// <para> 当 <paramref name="length" /> 小于等于 <c> 0 </c> 时，将使用 <c> bytes.Length </c> 代替。 </para>
        /// </param>
        /// <returns> 数据契约。 </returns>
        object Deserialize(byte[] bytes, int offset = 0, int length = 0);

        /// <summary> (可等待的方法) 从字节数组反序列化读取数据契约。 </summary>
        /// <param name="bytes"> 字节数组。 </param>
        /// <param name="offset"> 读取字节数组起始索引数值。 </param>
        /// <param name="length">
        /// 读取字节数组长度。
        /// <para> 当 <paramref name="length" /> 小于等于 <c> 0 </c> 时，将使用 <c> bytes.Length </c> 代替。 </para>
        /// </param>
        /// <returns> 数据契约。 </returns>
        /// <seealso cref="Task{TResult}" />
        Task<object> DeserializeAsync(byte[] bytes, int offset = 0, int length = 0);

        /// <summary> (可等待的方法) 从字节数组反序列化读取 <typeparamref name="T" /> 类型的数据契约。 </summary>
        /// <typeparam name="T"> 数据契约类型。 </typeparam>
        /// <param name="bytes"> 字节数组。 </param>
        /// <param name="offset"> 读取字节数组起始索引数值。 </param>
        /// <param name="length">
        /// 读取字节数组长度。
        /// <para> 当 <paramref name="length" /> 小于等于 <c> 0 </c> 时，将使用 <c> bytes.Length </c> 代替。 </para>
        /// </param>
        /// <returns> <typeparamref name="T" /> 类型的对象实例。 </returns>
        /// <seealso cref="Task{TResult}" />
        Task<T> DeserializeAsync<T>(byte[] bytes, int offset = 0, int length = 0) where T : class, new();

        /// <summary> (可等待的方法) 从流 <paramref name="inputStream" /> 中反序列化读取 <typeparamref name="T" /> 类型的数据契约。 </summary>
        /// <typeparam name="T"> 数据契约类型。 </typeparam>
        /// <param name="inputStream">
        /// 输入流。
        /// <para> 派生自 <see cref="Stream" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> <typeparamref name="T" /> 类型的对象实例。 </returns>
        /// <seealso cref="Stream" />
        /// <seealso cref="Task{TResult}" />
        Task<T> DeserializeAsync<T>(Stream inputStream) where T : class, new();

        /// <summary> (可等待的方法) 从流 <paramref name="inputStream" /> 中反序列化读取数据契约。 </summary>
        /// <param name="inputStream">
        /// 输入流。
        /// <para> 派生自 <see cref="Stream" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 数据契约。 </returns>
        /// <seealso cref="Stream" />
        /// <seealso cref="Task{TResult}" />
        Task<object> DeserializeAsync(Stream inputStream);

        /// <summary> 序列化 <paramref name="graph" /> 并返回字节数组。 </summary>
        /// <param name="graph"> 需要序列化的数据契约副本。 </param>
        /// <returns> 字节数组。 </returns>
        byte[] Serialize(object graph);

        /// <summary> 序列化 <typeparamref name="T" /> 类型的对象实例，并返回字节数组。 </summary>
        /// <typeparam name="T"> 引用类型。 </typeparam>
        /// <param name="graph"> <typeparamref name="T" /> 类型的对象实例。 </param>
        /// <returns> 字节数组。 </returns>
        byte[] Serialize<T>(T graph) where T : class, new();

        /// <summary> 序列化 <typeparamref name="T" /> 类型的对象实例，并写入到流 <paramref name="destinationStream" /> 中。 </summary>
        /// <typeparam name="T"> 引用类型。 </typeparam>
        /// <param name="graph"> <typeparamref name="T" /> 类型的对象实例。 </param>
        /// <param name="destinationStream">
        /// 目标输出流。
        /// <para> 派生自 <see cref="Stream" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 字节数组。 </returns>
        /// <seealso cref="Stream" />
        void Serialize<T>(T graph, Stream destinationStream) where T : class, new();

        /// <summary> 序列化 <paramref name="graph" />，并写入到流 <paramref name="destinationStream" /> 中。 </summary>
        /// <param name="graph"> 需要序列化的数据契约副本。 </param>
        /// <param name="destinationStream">
        /// 目标输出流。
        /// <para> 派生自 <see cref="Stream" /> 类型的对象实例。 </para>
        /// </param>
        /// <seealso cref="Stream" />
        void Serialize(object graph, Stream destinationStream);

        /// <summary> 序列化 <typeparamref name="T" /> 类型的对象实例，并写入到流 <paramref name="destinationStream" /> 中。 </summary>
        /// <typeparam name="T"> 引用类型。 </typeparam>
        /// <param name="graph"> <typeparamref name="T" /> 类型的对象实例。 </param>
        /// <param name="destinationStream">
        /// 目标输出流。
        /// <para> 派生自 <see cref="Stream" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns> 字节数组。 </returns>
        /// <seealso cref="Stream" />
        /// <seealso cref="Task" />
        Task SerializeAsync<T>(T graph, Stream destinationStream) where T : class, new();

        /// <summary> (可等待的方法) 序列化 <paramref name="graph" />，并写入到流 <paramref name="destinationStream" /> 中。 </summary>
        /// <param name="graph"> 需要序列化的数据契约副本。 </param>
        /// <param name="destinationStream">
        /// 目标输出流。
        /// <para> 派生自 <see cref="Stream" /> 类型的对象实例。 </para>
        /// </param>
        /// <seealso cref="Stream" />
        /// <seealso cref="Task" />
        Task SerializeAsync(object graph, Stream destinationStream);

        /// <summary> (可等待的方法) 序列化 <paramref name="graph" /> 并返回字节数组。 </summary>
        /// <param name="graph"> 需要序列化的数据契约副本。 </param>
        /// <returns> 字节数组。 </returns>
        /// <seealso cref="Task{TResult}" />
        Task<byte[]> SerializeAsync(object graph);

        /// <summary> (可等待的方法) 序列化 <typeparamref name="T" /> 类型的对象实例，并返回字节数组。 </summary>
        /// <typeparam name="T"> 引用类型。 </typeparam>
        /// <param name="graph"> <typeparamref name="T" /> 类型的对象实例。 </param>
        /// <returns> 字节数组。 </returns>
        /// <seealso cref="Task{TResult}" />
        Task<byte[]> SerializeAsync<T>(T graph) where T : class, new();
    }
}