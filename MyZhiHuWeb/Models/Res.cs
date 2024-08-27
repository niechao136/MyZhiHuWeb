using Newtonsoft.Json;

namespace MyZhiHuWeb.Models;

public class Res
{
    [Serializable]
    public class Base
    {
        public StatusCode status { get; set; }
        public bool success { get; set; }
        public string? msg { get; set; }
    }

    public class MsgModel<T> : Base
    {
        public T? Data { get; set; }
    }

    public class PageModel<T> : Base
    {
        public T[]? data { get; set; }
        public int pageSize { set; get; }
        public int totalCount { get; set; }
        public int page { get; set; }
    }

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

public class StatusConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return serializer.Deserialize(reader, typeof(Res.Base));
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Res.Base);
    }
}
