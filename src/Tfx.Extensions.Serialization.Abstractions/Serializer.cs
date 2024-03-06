// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

using Niacomsoft.TeamFramework.Extensions.Logging;

namespace Niacomsoft.TeamFramework.Extensions.Serialization
{
    /// <summary> 提供了数据契约序列化相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="ISerializer" />
    public abstract class Serializer : ISerializer
    {
        /// <summary> 初始化 <see cref="Serializer" /> 类的新实例。 </summary>
        /// <param name="logWriter">
        /// 记录运行时日志的方法。
        /// <para> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </para>
        /// </param>
        protected Serializer(ILogWriter logWriter)
        {
            LogWriter = logWriter;
        }

        /// <summary> 记录运行时日志的方法。 </summary>
        /// <value> 获取 <see cref="ILogWriter" /> 类型的对象实例，用于表示记录运行时日志的方法。 </value>
        /// <seealso cref="ILogWriter" />
        protected virtual ILogWriter LogWriter { get; }

        /// <inheritdoc />
        public abstract object Deserialize(Stream inputStream);

        /// <inheritdoc />
        public virtual T Deserialize<T>(Stream inputStream) where T : class, new()
        {
            return Deserialize(inputStream) as T;
        }

        /// <inheritdoc />
        [SuppressMessage("Design", "Ex0100:Member may throw undocumented exception", Justification = "<挂起>")]
        public virtual T Deserialize<T>(byte[] bytes, int offset = 0, int length = 0) where T : class, new()
        {
            return Deserialize(bytes, offset, length) as T;
        }

        /// <inheritdoc />
        /// <exception cref="System.NotSupportedException"> 当调用 <see cref="Stream.WriteAsync(byte[], int, int)" /> 等方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="IOException"> 当调用 <see cref="Stream.WriteAsync(byte[], int, int)" /> 等方法时，可能引发此类型的异常。 </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        public virtual object Deserialize(byte[] bytes, int offset = 0, int length = 0)
        {
            using (var deserializationStream = new MemoryStream())
            {
                deserializationStream.Write(bytes, offset, length);
                deserializationStream.Seek(0, SeekOrigin.Begin);
                return Deserialize(deserializationStream);
            }
        }

        /// <inheritdoc />
        public virtual Task<object> DeserializeAsync(byte[] bytes, int offset = 0, int length = 0)
        {
            return Task.Run(() =>
            {
                try
                {
                    return Deserialize(bytes, offset, length);
                }
                catch (Exception error)
                {
                    LogWriter.LogFatal(error, "try to deserialize a data contract of type 'System.Object'");
                    throw;
                }
            });
        }

        /// <inheritdoc />
        public virtual Task<T> DeserializeAsync<T>(byte[] bytes, int offset = 0, int length = 0) where T : class, new()
        {
            return Task.Run(() =>
            {
                try
                {
                    return Deserialize<T>(bytes, offset, length);
                }
                catch (Exception error)
                {
                    LogWriter.LogFatal(error, $"try to deserialize a data contract of type '{typeof(T).FullName}'");
                    throw;
                }
            });
        }

        /// <inheritdoc />
        public virtual Task<T> DeserializeAsync<T>(Stream inputStream) where T : class, new()
        {
            return Task.Run(() =>
            {
                try
                {
                    return Deserialize<T>(inputStream);
                }
                catch (Exception error)
                {
                    LogWriter.LogFatal(error, $"try to deserialize a data contract of type '{typeof(T).FullName}'");
                    throw;
                }
            });
        }

        /// <inheritdoc />
        public virtual Task<object> DeserializeAsync(Stream inputStream)
        {
            return Task.Run(() =>
            {
                try
                {
                    return Deserialize(inputStream);
                }
                catch (Exception error)
                {
                    LogWriter.LogFatal(error, "try to deserialize a data contract of type 'System.Object'");
                    throw;
                }
            });
        }

        /// <inheritdoc />
        public virtual byte[] Serialize(object graph)
        {
            using (var serializationStream = new MemoryStream())
            {
                Serialize(graph, serializationStream);
                return serializationStream.ToArray();
            }
        }

        /// <inheritdoc />
        public virtual byte[] Serialize<T>(T graph) where T : class, new()
        {
            return Serialize((object)graph);
        }

        /// <inheritdoc />
        public virtual void Serialize<T>(T graph, Stream destinationStream) where T : class, new()
        {
            Serialize((object)graph, destinationStream);
        }

        /// <inheritdoc />
        public abstract void Serialize(object graph, Stream destinationStream);

        /// <inheritdoc />
        public virtual Task SerializeAsync<T>(T graph, Stream destinationStream) where T : class, new()
        {
            return Task.Run(() =>
            {
                try
                {
                    Serialize(graph, destinationStream);
                }
                catch (Exception error)
                {
                    LogWriter.LogFatal(error, $"try to serialize a data contract of type '{typeof(T).FullName}'");
                    throw;
                }
            });
        }

        /// <inheritdoc />
        public virtual Task SerializeAsync(object graph, Stream destinationStream)
        {
            return Task.Run(() =>
            {
                try
                {
                    Serialize(graph, destinationStream);
                }
                catch (Exception error)
                {
                    LogWriter.LogFatal(error, "try to serialize a data contract of type 'System.Object'");
                    throw;
                }
            });
        }

        /// <inheritdoc />
        public virtual Task<byte[]> SerializeAsync(object graph)
        {
            return Task.Run(() =>
            {
                try
                {
                    return Serialize(graph);
                }
                catch (Exception error)
                {
                    LogWriter.LogFatal(error, "try to serialize a data contract of type 'System.Object'");
                    throw;
                }
            });
        }

        /// <inheritdoc />
        public virtual Task<byte[]> SerializeAsync<T>(T graph) where T : class, new()
        {
            return Task.Run(() =>
            {
                try
                {
                    return Serialize(graph);
                }
                catch (Exception error)
                {
                    LogWriter.LogFatal(error, $"try to serialize a data contract of type '{typeof(T).FullName}'");
                    throw;
                }
            });
        }
    }
}