namespace MyZhiHuWeb.Models;

public class Result
{
    public class Base<T>
    {
        public StatusCode Status { get; set; }
        public bool Success { get; set; }
        public string? Msg { get; set; }
        public T? Data { get; set; }
    }


    public enum StatusCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 200,

        /// <summary>
        /// 直接返回登录页
        /// </summary>
        Redirect = 400,

        /// <summary>
        /// 跳出已登出提示
        /// </summary>
        Logout = 401,

        /// <summary>
        /// 失败
        /// </summary>
        Fail = 500
    }

}
