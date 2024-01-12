// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

namespace Niacomsoft
{
    /// <summary> 提供了方法结果相关的方法。 </summary>
    /// <typeparam name="TResult"> 方法结果类型。 </typeparam>
    /// <seealso cref="Result" />
    public class Result<TResult> : Result
    {
        /// <summary> 初始化 <see cref="Result{TResult}" /> 类的新实例。 </summary>
        public Result() : this(default, null)
        {
        }

        /// <summary> 初始化 <see cref="Result{TResult}" /> 类的新实例。 </summary>
        /// <param name="error">
        /// 方法执行过程中抛出的异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        public Result(Exception error) : this(default, error)
        {
        }

        /// <summary> 初始化 <see cref="Result{TResult}" /> 类的新实例。 </summary>
        /// <param name="value"> <typeparamref name="TResult" /> 类型的方法结果。 </param>
        public Result(TResult value) : this(value, null)
        {
        }

        /// <summary> 初始化 <see cref="Result{TResult}" /> 类的新实例。 </summary>
        /// <param name="value"> <typeparamref name="TResult" /> 类型的方法结果。 </param>
        /// <param name="error">
        /// 方法执行过程中抛出的异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        public Result(TResult value, Exception error) : base(error)
        {
            Value = value;
        }

        /// <summary> 方法结果。 </summary>
        /// <value> 设置或获取 <typeparamref name="TResult" /> 类型的对象实例或值，用于表示方法结果。 </value>
        public virtual TResult Value { get; set; }

        /// <summary> 创建一个失败结果。 </summary>
        /// <param name="error">
        /// 方法执行过程中抛出的异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns>
        /// 方法结果。
        /// <para> <see cref="Result{TResult}" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="Exception" />
        public new static Result<TResult> Fail(Exception error)
            => new Result<TResult>(error);

        /// <summary> 创建一个成功的结果。 </summary>
        /// <param name="value"> <typeparamref name="TResult" /> 类型的结果值。 </param>
        /// <returns>
        /// 方法结果。
        /// <para> <see cref="Result{TResult}" /> 类型的对象实例。 </para>
        /// </returns>
        public static Result<TResult> Succeed(TResult value)
            => new Result<TResult>(value);

        /// <summary> 创建一个成功的结果。 </summary>
        /// <returns>
        /// 方法结果。
        /// <para> <see cref="Result{TResult}" /> 类型的对象实例。 </para>
        /// </returns>
        public new static Result<TResult> Succeed()
            => new Result<TResult>();
    }
}