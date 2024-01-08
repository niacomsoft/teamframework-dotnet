// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    using System;

    /// <summary> 提供了构建 <see cref="Exception" /> 类型的对象实例相关的方法。 </summary>
    /// <seealso cref="IExceptionBuilder{TException}" />
    /// <seealso cref="ExceptionBuilder{TException}" />
    public class ExceptionBuilder : ExceptionBuilder<Exception>
    {
        /// <summary> 初始化 <see cref="ExceptionBuilder" /> 的新实例。 </summary>
        public ExceptionBuilder()
        {
        }

        /// <inheritdoc />
        public override Exception Build()
            => Cause is null
                ? new Exception(Message)
                : new Exception(Message, Cause);
    }
}