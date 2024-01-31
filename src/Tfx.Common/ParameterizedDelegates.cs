// © 2024 WANG YUCAI. LICENSED UNDER THE MIT LICENSE. SEE LICENSE FILE IN THE PROJECT ROOT FOR FULL LICENSE INFORMATION.

namespace Niacomsoft.TeamFramework
{
    /// <summary> 定义了无返回值的方法委托。 </summary>
    /// <param name="args"> 可变的参数数组。 </param>
    public delegate void ParameterizedAction(params object[] args);

    /// <summary> 定义了 <typeparamref name="TReturn" /> 类型返回值的方法委托。 </summary>
    /// <typeparam name="TReturn"> 返回值类型。 </typeparam>
    /// <param name="args"> 可变的参数数组。 </param>
    /// <returns> <typeparamref name="TReturn" /> 类型的返回值。 </returns>
    public delegate TReturn ParameterizedFunc<TReturn>(params object[] args);
}