namespace DocumentEditor.Commands
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}