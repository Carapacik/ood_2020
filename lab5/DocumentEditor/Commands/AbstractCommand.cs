namespace DocumentEditor.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        protected bool IsExecuted { get; private set; }

        public void Execute()
        {
            if (!IsExecuted)
                DoExecute();
            IsExecuted = true;
        }

        public void UnExecute()
        {
            if (IsExecuted)
                DoUnExecute();
            IsExecuted = false;
        }

        protected abstract void DoExecute();
        protected abstract void DoUnExecute();
    }
}