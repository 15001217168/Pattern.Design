namespace _06_01_Pattern.Infrastructure
{
    /// <summary>
    /// /// <summary>
    /// 事件处理接口
    /// </summary>
    /// <typeparam name="TEvent">继承IEvent对象的事件源对象</typeparam>
    /// </summary>
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        void Handle(TEvent evt);
    }
}
