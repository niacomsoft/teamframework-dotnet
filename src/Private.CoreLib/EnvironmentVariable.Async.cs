// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP || NET

using System.Threading.Tasks;

namespace Niacomsoft
{
    public partial class EnvironmentVariable
    {
        /// <summary> (可等待的方法) 尝试搜索名称为 <paramref name="name" /> 的环境变量信息。 </summary>
        /// <param name="name"> 环境变量名称。 </param>
        /// <returns>
        /// 指定的环境变量信息。
        /// <para> <see cref="EnvironmentVariable" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="EnvironmentVariable" />
        /// <seealso cref="GetEnvironmentVariable(string)" />
        /// <seealso cref="Task{TResult}" />
        public static Task<EnvironmentVariable> GetEnvironmentVariableAsync(string name)
            => Task.Run(() => GetEnvironmentVariable(name));
    }
}

#endif