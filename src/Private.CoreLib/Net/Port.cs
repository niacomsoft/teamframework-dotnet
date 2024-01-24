// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using Niacomsoft.Utilities;

namespace Niacomsoft.Net
{
    /// <summary> 提供了网络通信端口号相关的方法。 </summary>
    public static class Port
    {
        /// <summary> 最小的网络通信端口号值。 </summary>
        public const int MinValue = 1;

        /// <summary> 最大的网络通信端口号值。 </summary>
        public const int MaxValue = 65535;

        /// <summary>
        /// 当 <paramref name="port" /> 大于等于 <see cref="MinValue" /> 且小于等于 <see cref="MaxValue" /> 时，返回 <see langword="true" />
        /// ；否则返回 <see langword="false" />。
        /// </summary>
        /// <param name="port"> 需要校验的端口号。 </param>
        /// <returns>
        /// 当 <paramref name="port" /> 大于等于 <see cref="MinValue" /> 且小于等于 <see cref="MaxValue" /> 时，返回 <see langword="true" />
        /// ；否则返回 <see langword="false" />。
        /// </returns>
        /// <seealso cref="MaxValue" />
        /// <seealso cref="MinValue" />
        public static bool IsValid(int port)
            => AssertUtilities.GreatThanOrEquals(port, MinValue) && AssertUtilities.LessThanOrEquals(port, MaxValue);

        /// <summary> HTTP 默认端口号。 </summary>
        public const int HTTP = 80;

        /// <summary> HTTPS 默认端口号。 </summary>
        public const int HTTPS = 443;

#if NETCOREAPP || NET || NETSTANDARD
        /// <summary> ASP.NET Core 应用程序默认端口号。 </summary>
        public const int AspNetCore = 5000;
#endif

        /// <summary> Microsoft SQL Server 默认端口号。 </summary>
        public const int SqlServer = 1443;

        /// <summary> MySQL 默认端口号。 </summary>
        public const int MySQL = 3306;

        /// <summary> PostgreSQL 默认端口号。 </summary>
        public const int PostgreSQL = 5432;

        /// <summary> Redis 默认端口号。 </summary>
        public const int Redis = 6379;

        /// <summary> RabbitMQ 默认端口号。 </summary>
        public const int RabbitMQ = 5672;

        /// <summary> Apache Zookeeper 默认端口号。 </summary>
        public const int ApacheZookeeper = 2181;

        /// <summary> MQTT 默认端口号。 </summary>
        public const int MQTT = 1883;
    }
}