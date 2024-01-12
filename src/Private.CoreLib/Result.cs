// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

using System;

using Niacomsoft.Utilities;

namespace Niacomsoft
{
    /// <summary> 提供了方法结果相关的方法。 </summary>
    public class Result
    {
        /// <summary> 初始化 <see cref="Result" /> 类的新实例。 </summary>
        public Result() : this(null)
        {
        }

        /// <summary> 初始化 <see cref="Result" /> 类的新实例。 </summary>
        /// <param name="error">
        /// 方法执行过程中抛出的异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        public Result(Exception error)
        {
            Error = error;
            HasError = AssertUtilities.NotNull(error);
        }

        /// <summary> 方法执行过程中抛出的异常。 </summary>
        /// <value> 获取 <see cref="Exception" /> 类型的对象实例，用于表示方法执行过程中抛出的异常。 </value>
        /// <seealso cref="Exception" />
        public virtual Exception Error { get; }

        /// <summary> 方法执行过程中是否抛出了异常。 </summary>
        /// <value> 获取一个 <see cref="bool" /> 类型值，用于表示方法执行过程中是否抛出了异常。 </value>
        public virtual bool HasError { get; }

        /// <summary> 创建一个失败结果。 </summary>
        /// <param name="error">
        /// 方法执行过程中抛出的异常。
        /// <para> <see cref="Exception" /> 类型的对象实例。 </para>
        /// </param>
        /// <returns>
        /// 方法结果。
        /// <para> <see cref="Result" /> 类型的对象实例。 </para>
        /// </returns>
        /// <seealso cref="Exception" />
        public static Result Fail(Exception error)
            => new Result(error);

        /// <summary> 创建一个成功结果。 </summary>
        /// <returns>
        /// 方法结果。
        /// <para> <see cref="Result" /> 类型的对象实例。 </para>
        /// </returns>
        public static Result Succeed()
            => new Result();
    }
}