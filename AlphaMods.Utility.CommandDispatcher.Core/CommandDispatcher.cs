using AlphaMods.Utility.CommandDispatcher.Interfaces;

namespace AlphaMods.Utility.CommandDispatcher.Core
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private Dictionary<string, EventWrapper<ICommand>> Commands;
        private Dictionary<string, IEventWrapper> Commands2;

        public CommandDispatcher()
        {
            Commands = new Dictionary<string, EventWrapper<ICommand>>();
            Commands2 = new Dictionary<string, IEventWrapper>();
        }

        public void AddCommandListener(string identifier, Action<ICommand> callback)
        {
            if (Commands.ContainsKey(identifier) == false)
            {
                Commands[identifier] = new EventWrapper<ICommand>();
            }

            Commands[identifier].AddListener(callback);
        }

        public void AddCommandListener<T>(string identifier, Action<T> callback) where T : ICommand
        {
            if (Commands2.ContainsKey(identifier) == false)
            {
                EventWrapper<T> wrapper = new EventWrapper<T>();
                Commands2[identifier] = wrapper;

                wrapper.AddListener(callback);
            }
        }

        public void DispatchCommand(ICommand command)
        {
            if(Commands.ContainsKey (command.Identifier))
            {
                Commands[command.Identifier].Invoke(command);
            }

            if (Commands2.ContainsKey(command.Identifier))
            {
                Commands2[command.Identifier].Invoke(command);
            }
        }

        public void RemoveCommandListener(string identifier, Action<ICommand> callback)
        {
            if (Commands.ContainsKey(identifier))
            {
                Commands[identifier].RemoveListener(callback);
            }
        }

        public void RemoveCommandListener<T>(string identifier, Action<T> callback) where T : ICommand
        {
            if (Commands2.ContainsKey(identifier))
            {
                (Commands2[identifier] as EventWrapper<T>)!.RemoveListener(callback);
            }
        }

        private interface IEventWrapper
        {
            void Invoke(ICommand command);
        }

        private class EventWrapper<T>: IEventWrapper where T : ICommand
        {
            private event Action<T>? OnCommand;

            public void AddListener(Action<T> action)
            {
                OnCommand += action;
            }

            public void RemoveListener(Action<T> action)
            {
                OnCommand -= action;
            }

            public void Invoke(ICommand command)
            {
                OnCommand?.Invoke((T)command);
            }
        }
    }
}