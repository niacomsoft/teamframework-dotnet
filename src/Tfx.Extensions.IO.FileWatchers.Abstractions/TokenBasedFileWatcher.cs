// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System.Diagnostics.CodeAnalysis;
using System.IO;

using Niacomsoft.IO;
using Niacomsoft.TeamFramework.Extensions.Logging;
using Niacomsoft.Utilities;

namespace Niacomsoft.TeamFramework.Extensions.IO.FileWatchers
{
    /// <summary> 提供了基于文件令牌信息 <see cref="FileInfoToken" /> 监控文件相关的 <see langword="abstract" /> 方法。 </summary>
    /// <seealso cref="FileInfoToken" />
    /// <seealso cref="FileWatcher" />
    public abstract class TokenBasedFileWatcher : FileWatcher
    {
        /// <summary> 初始化 <see cref="TokenBasedFileWatcher" /> 类的新实例。 </summary>
        /// <param name="target"> 需要监控的目标文件信息。 </param>
        /// <param name="logWriter">
        /// 用于记录运行时文件信息 <see cref="P:Niacomsoft.TeamFramework.Extensions.IO.FileWatchers.FileWatcher.Target" /> 变更的方法。
        /// <para> 实现了 <see cref="ILogWriter" /> 类型接口的对象实例。 </para>
        /// </param>
        protected TokenBasedFileWatcher(FileInfo target, ILogWriter logWriter) : base(target, logWriter)
        {
            Token = target.GetToken();
            CurrentTokenString = string.Empty;
        }

        /// <summary> 当前的文件令牌字符串。 </summary>
        /// <value> 设置或获取一个字符串，用于表示当前的文件令牌字符串。 </value>
        protected virtual string CurrentTokenString { get; set; }

        /// <summary> 当前的文件令牌信息。 </summary>
        /// <value> 获取 <see cref="FileInfoToken" /> 类型的对象实例，用于表示当前的文件令牌信息。 </value>
        /// <seealso cref="FileInfoToken" />
        protected virtual FileInfoToken Token { get; }

        /// <summary>
        /// 当文件 <see cref="P:Niacomsoft.TeamFramework.Extensions.IO.FileWatchers.FileWatcher.Target" /> 的令牌信息发生变更时返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </summary>
        /// <returns>
        /// 当文件 <see cref="P:Niacomsoft.TeamFramework.Extensions.IO.FileWatchers.FileWatcher.Target" /> 的令牌信息发生变更时返回
        /// <see langword="true" />；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="Token" />
        /// <exception cref="PathTooLongException"> 当访问 <see cref="FileSystemInfo.FullName" /> 属性时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Security.SecurityException"> 当访问 <see cref="FileSystemInfo.FullName" /> 属性时，可能引发此类型的异常。 </exception>
        /// <exception cref="IOException"> 当调用 <see cref="FileInfoToken.Refresh()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.PlatformNotSupportedException"> 当调用 <see cref="FileInfoToken.Refresh()" /> 方法时，可能引发此类型的异常。 </exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        /// 当调用 <see cref="FileInfoToken.ToString()" /> 方法时，可能引发此类型的异常。
        /// </exception>
        [SuppressMessage("Design", "Ex0200:Member is documented as throwing exception not documented on member in base or interface type", Justification = "<挂起>")]
        protected override bool IsChanged()
        {
            LogWriter.LogInformation($"Try refreshing the token information for file \"{Target.FullName}\".", GetType());
            var tokenStr = Token.Refresh().ToString();
            LogWriter.LogTrace($"After refreshing, the token string for file \"{Target.FullName}\" is \"{tokenStr}\".", GetType());
            if (AssertUtilities.IsEmpty(CurrentTokenString, EmptyComparisonOptions.NullOrWhitespace))
            {
                CurrentTokenString = tokenStr;
                return false;
            }
            else if (LogWriter.LogWarningIf(CurrentTokenString != tokenStr, $"The token string of the file \"{Target.FullName}\" has changed.", GetType()))
            {
                CurrentTokenString = tokenStr;
                return true;
            }
            return false;
        }
    }
}