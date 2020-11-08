namespace DocumentEditor.Commands
{
    public interface IHistory
    {
        void AddAndExecuteCommand(ICommand command);
    }
}