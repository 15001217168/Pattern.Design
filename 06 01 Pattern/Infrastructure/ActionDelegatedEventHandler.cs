namespace _06_01_Pattern.Infrastructure
{
    using System;


    public delegate void ActionDelegatedEvent<T>(T evt);
    public class ActionDelegatedEventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IEvent
    {
        public ActionDelegatedEventHandler()
        {

        }
        private Action<TEvent> _actionDelegatedEvent;
        public ActionDelegatedEventHandler(Action<TEvent> eventFunc)
        {
            _actionDelegatedEvent += eventFunc;
        }
        private ActionDelegatedEvent<TEvent> __actionDelegatedEvent;

        public event ActionDelegatedEvent<TEvent> AddActionDelegatedEvent
        {
            add
            {
                this.__actionDelegatedEvent += value;
            }
            remove
            {
                if (this.__actionDelegatedEvent != null)
                {
                    this.__actionDelegatedEvent -= value;
                }
            }
        }
        public void Handle(TEvent evt)
        {
            if (_actionDelegatedEvent != null)
            {
                _actionDelegatedEvent(evt);
            }
            if (__actionDelegatedEvent != null)
            {
                __actionDelegatedEvent(evt);
            }
        }
    }
}
