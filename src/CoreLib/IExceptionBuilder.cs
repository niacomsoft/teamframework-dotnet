// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft
{
    using System;

    /// <summary> 定义了构建 <typeparamref name="TException" /> 类型异常的接口。 </summary>
    /// <typeparam name="TException"> 派生自 <see cref="Exception" /> 的类型。 </typeparam>
    public interface IExceptionBuilder<TException>
        where TException : Exception
    {
        /// <summary> 默认的 <typeparamref name="TException" /> 类型异常信息。 </summary>
        string DefaultMessage { get; }

        /// <summary> 构建 <typeparamref name="TException" /> 类型的对象实例。 </summary>
        /// <returns> <typeparamref name="TException" /> 类型的对象实例。 </returns>
        TException Build();

        /// <summary> 设置引发 <typeparamref name="TException" /> 类型异常的 <see cref="Exception.InnerException" /> 属性。 </summary>
        /// <param name="cause"> 引发 <typeparamref name="TException" /> 类型异常的 <see cref="Exception" /> 类型的对象实例。 </param>
        /// <returns> 实现了 <see cref="IExceptionBuilder{TException}" /> 类型接口的对象实例。 </returns>
        IExceptionBuilder<TException> WithCause(Exception cause);

        /// <summary> 设置异常信息。 </summary>
        /// <param name="message"> 异常信息。 </param>
        /// <returns> 实现了 <see cref="IExceptionBuilder{TException}" /> 类型接口的对象实例。 </returns>
        IExceptionBuilder<TException> WithMessage(string message);
    }
}