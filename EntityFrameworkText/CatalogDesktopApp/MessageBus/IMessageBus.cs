using System;

namespace CatalogDesktopApp
{
    public interface IMessageBus
    {
        void Subscribe<TMessage>(Action<TMessage> handler);
        void Unsubscribe<TMessage>(Action<TMessage> handler);
        void Clear<TMessage>();
        void Publish<TMessage>(TMessage message);
        void Publish(Object message);
    }
}