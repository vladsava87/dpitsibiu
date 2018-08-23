using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp
{
    public sealed class MessageBus : IMessageBus
    {
        private static MessageBus instance;

        private MessageBus() { }

        public static MessageBus Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MessageBus();
                }

                return instance;
            }
        }

        private Dictionary<Type, List<Object>> _Subscribers = new Dictionary<Type, List<Object>>();

        public void Subscribe<TMessage>(Action<TMessage> handler)
        {
            if (_Subscribers.ContainsKey(typeof(TMessage)))
            {
                var handlers = _Subscribers[typeof(TMessage)];
                handlers.Add(handler);
            }
            else
            {
                var handlers = new List<Object>();
                handlers.Add(handler);
                _Subscribers[typeof(TMessage)] = handlers;
            }
        }

        public void Unsubscribe<TMessage>(Action<TMessage> handler)
        {
            if (_Subscribers.ContainsKey(typeof(TMessage)))
            {
                var handlers = _Subscribers[typeof(TMessage)];
                handlers.Remove(handler);

                if (handlers.Count == 0)
                {
                    _Subscribers.Remove(typeof(TMessage));
                }
            }
        }

        public void Clear<TMessage>()
        {
            if (_Subscribers.ContainsKey(typeof(TMessage)))
            {
                _Subscribers.Remove(typeof(TMessage));
            }
        }

        public void Publish<TMessage>(TMessage message)
        {
            if (_Subscribers.ContainsKey(typeof(TMessage)))
            {
                var handlers = _Subscribers[typeof(TMessage)];
                for (var i = 0; i < handlers.Count; i++)
                {
                    if (handlers.Count > i)
                    {
                        var handler = handlers[i] as Action<TMessage>;
                        handler.Invoke(message);
                    }
                }
            }
        }

        public void Publish(Object message)
        {
            var messageType = message.GetType();
            if (_Subscribers.ContainsKey(messageType))
            {
                var handlers = _Subscribers[messageType];
                for (var i = 0; i < handlers.Count; i++)
                {
                    if (handlers.Count > i)
                    {
                        var handler = handlers[i];
                        var actionType = handler.GetType();
                        var invoke = actionType.GetMethod("Invoke", new Type[] { messageType });
                        invoke.Invoke(handler, new Object[] { message });
                    }
                }
            }
        }
    }
}
