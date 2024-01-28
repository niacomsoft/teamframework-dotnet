// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft.Web.Http
{
    /// <summary> 提供了 HTTP ASP.NET WebApi 相关的 <see langword="abstract" /> 方法。 </summary>
    public abstract class HttpResult
    {
        /// <summary> 初始化 <see cref="HttpResult" /> 类的新实例。 </summary>
        protected HttpResult()
        {
        }

        /// <summary> 初始化 <see cref="HttpResult" /> 类的新实例。 </summary>
        /// <param name="exception">
        /// HTTP ASP.NET WebApi 运行过程中抛出的异常。
        /// <para> 派生自 <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        protected HttpResult(Exception exception) : this()
        {
            Exception = exception;
        }

        /// <summary> HTTP ASP.NET WebApi 运行过程中抛出的异常。 </summary>
        /// <value> 获取 <see cref="Exception" /> 类型的对象实例，用于表示 HTTP ASP.NET WebApi 运行过程中抛出的异常。 </value>
        public virtual Exception Exception { get; }
    }

    /// <summary> 提供了包含 <typeparamref name="TData" /> 类型数据结果相关的 HTTP ASP.NET WebApi <see langword="abstract" /> 方法。 </summary>
    /// <typeparam name="TData"> 数据结果类型。 </typeparam>
    /// <seealso cref="HttpResult" />
    public abstract class HttpResult<TData> : HttpResult
    {
        /// <summary> 初始化 <see cref="HttpResult{TData}" /> 类的新实例。 </summary>
        protected HttpResult()
        {
            Data = default;
        }

        /// <summary> 初始化 <see cref="HttpResult{TData}" /> 类的新实例。 </summary>
        /// <param name="exception">
        /// HTTP ASP.NET WebApi 运行过程中抛出的异常。
        /// <para> 派生自 <see cref="P:Niacomsoft.Web.Http.HttpResult.Exception" /> 类型的对象实例。 </para>
        /// </param>
        protected HttpResult(Exception exception) : base(exception)
        {
            Data = default;
        }

        /// <summary> 初始化 <see cref="HttpResult{TData}" /> 类的新实例。 </summary>
        /// <param name="data"> 数据结果。 </param>
        protected HttpResult(TData data)
        {
            Data = data;
        }

        /// <summary> <typeparamref name="TData" /> 类型的数据结果。 </summary>
        /// <value> 设置或获取 <typeparamref name="TData" /> 类型的对象实例或值，用于表示数据结果。 </value>
        public virtual TData Data { get; set; }
    }
}