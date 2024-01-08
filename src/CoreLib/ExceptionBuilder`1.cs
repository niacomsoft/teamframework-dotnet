// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    using System;

    /// <summary> 提供了构建 <typeparamref name="TException" /> 类型异常相关的 <see langword="abstract" /> 方法。 </summary>
    /// <typeparam name="TException"> 派生自 <see cref="Exception" /> 类型的对象实例。 </typeparam>
    /// <seealso cref="IExceptionBuilder{TException}" />
    public abstract class ExceptionBuilder<TException> : IExceptionBuilder<TException>
        where TException : Exception
    {
        /// <summary> 初始化 <see cref="ExceptionBuilder{TException}" /> 的新实例。 </summary>
        protected ExceptionBuilder()
            => Message = DefaultMessage = SR.GetString("Exception_default_message");

        /// <inheritdoc />
        public virtual string DefaultMessage
        {
            get;
        }

        /// <summary>
        /// 引发 <typeparamref name="TException" /> 类型异常的内部异常。
        /// <para> 参见 <see cref="Exception.InnerException" /> 属性。 </para>
        /// </summary>
        /// <value> 设置或获取 <see cref="Exception" /> 类型的对象实例，用于表示引发 <typeparamref name="TException" /> 类型异常的内部异常。 </value>
        /// <seealso cref="Exception" />
        protected virtual Exception Cause { get; set; }

        /// <summary> 异常信息。 </summary>
        /// <value> 设置或获取一个字符串，用于表示异常信息。 </value>
        protected virtual string Message { get; set; }

        /// <inheritdoc />
        public abstract TException Build();

        /// <inheritdoc />
        public virtual IExceptionBuilder<TException> WithCause(Exception cause)
        {
            Cause = cause;
            return this;
        }

        /// <inheritdoc />
        public virtual IExceptionBuilder<TException> WithMessage(string message)
        {
            Message = message;
            return this;
        }
    }
}