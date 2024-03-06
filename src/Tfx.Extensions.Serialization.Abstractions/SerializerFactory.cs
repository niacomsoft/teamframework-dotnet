// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.TeamFramework.Extensions.Logging;

namespace Niacomsoft.TeamFramework.Extensions.Serialization
{
    /// <summary> 提供了创建数据契约序列化程序相关的 <see langword="abstract" /> 工厂方法。 </summary>
    /// <seealso cref="ISerializerFactory" />
    public abstract class SerializerFactory : ISerializerFactory
    {
        /// <summary> 初始化 <see cref="SerializerFactory" /> 类的新实例。 </summary>
        /// <param name="logFactory">
        /// 创建运行时日志的工厂方法。
        /// <para> 实现了 <see cref="ILogWriterFactory" /> 类型接口的对象实例。 </para>
        /// </param>
        protected SerializerFactory(ILogWriterFactory logFactory)
        {
            LogFactory = logFactory;
        }

        /// <summary> 创建运行时日志的工厂方法。 </summary>
        /// <value> 获取 <see cref="ILogWriterFactory" /> 类型的对象实例，用于表示创建运行时日志的工厂方法。 </value>
        /// <seealso cref="ILogWriter" />
        protected virtual ILogWriterFactory LogFactory { get; }

        /// <inheritdoc />
        public virtual ISerializer CreateSerializer()
        {
            return InternalCreateSerializer(LogFactory.CreateWriter());
        }

        /// <summary> 创建数据契约序列化程序。 </summary>
        /// <param name="logWriter">
        /// 记录运行时日志的方法。
        /// <para> 实现了 <see cref="ISerializer" /> 类型接口的对象实例。 </para>
        /// </param>
        /// <returns> 实现了 <see cref="ISerializer" /> 类型接口的对象实例。 </returns>
        /// <seealso cref="ILogWriter" />
        /// <seealso cref="ISerializer" />
        protected abstract ISerializer InternalCreateSerializer(ILogWriter logWriter);
    }
}