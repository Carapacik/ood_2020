using System.IO;
using MultiGumBallMachine.StateGumBallMachine;

namespace MultiGumBallMachine
{
    public class GumBallMachineController
    {
        private readonly IGumBallMachineStd _gumBallMachine;
        private readonly Menu _menu;
        private readonly TextWriter _textWriter;

        public GumBallMachineController(TextWriter textWriter, TextReader textReader, IGumBallMachineStd gumBallMachine)
        {
            _textWriter = textWriter;
            _menu = new Menu(_textWriter, textReader);
            _gumBallMachine = gumBallMachine;
            _menu.AddItem("help", "Show help", ShowInstructions);
            _menu.AddItem("insert", "Insert quarter", InsertQuarter);
            _menu.AddItem("eject", "Ejects all quarters", EjectQuarter);
            _menu.AddItem("turn", "Turn crank and give you a gumball if you inserted a coin before", TurnCrank);
            _menu.AddItem("refill", "Refill <balls count>", Refill);
            _menu.AddItem("state", "Display GumBall machine state", DisplaySate);
            _menu.AddItem("exit", "Exit program", Exit);
        }

        public void Start()
        {
            _menu.Run();
        }

        private void InsertQuarter(string[] args)
        {
            if (args.Length != 1)
                _textWriter.WriteLine("Wrong arguments! Usage: insertQuarter");
            else
                _gumBallMachine.InsertQuarter();
        }

        private void EjectQuarter(string[] args)
        {
            if (args.Length != 1)
                _textWriter.WriteLine("Wrong arguments! Usage: ejectQuarter");
            else
                _gumBallMachine.EjectQuarter();
        }

        private void TurnCrank(string[] args)
        {
            if (args.Length != 1)
                _textWriter.WriteLine("Wrong arguments! Usage: ejectQuarter");
            else
                _gumBallMachine.TurnCrank();
        }

        private void Refill(string[] args)
        {
            if (args.Length != 2)
            {
                _textWriter.WriteLine("Wrong arguments! Usage: refill <balls number>");
            }
            else
            {
                var numBalls = uint.Parse(args[1]);
                _gumBallMachine.Refill(numBalls);
            }
        }

        private void DisplaySate(string[] args)
        {
            if (args.Length != 1)
                _textWriter.WriteLine("Wrong arguments! Usage: toString");
            else
                _textWriter.Write(_gumBallMachine.ToString());
        }

        private void Exit(string[] args)
        {
            _menu.Exit();
        }

        private void ShowInstructions(string[] args)
        {
            _menu.ShowInstructions();
        }
    }
}