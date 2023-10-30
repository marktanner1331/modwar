namespace AlphaMods.Utility.CommandDispatcher.Interfaces
{
    public interface ICommandDispatcher
    {
        void DispatchCommand(ICommand command);
        void AddCommandListener(string identifier, Action<ICommand> callback);
        void RemoveCommandListener(string identifier, Action<ICommand> callback);
        void AddCommandListener<T>(string identifier, Action<T> callback) where T : ICommand;
    }
}