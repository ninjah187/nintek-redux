using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Store
{
    public class App
    {
        public class State
        {
            public string Text { get; private set; }
            public Prompts.State Prompts { get; private set; }
            public CurrencyRates.State CurrencyRates { get; private set; }

            public State()
            {
                Text = "Text displayed by app.";
                Prompts = new Prompts.State();
                CurrencyRates = new CurrencyRates.State();
            }

            public State(
                string text,
                Prompts.State prompts,
                CurrencyRates.State currencyRates)
            {
                Text = text;
                Prompts = prompts;
                CurrencyRates = currencyRates;
            }
        }

        public class Actions
        {
            public class DisplayText : Action<string>
            {
                public DisplayText(string payload) : base(payload)
                {
                }
            }

            public class TextDisplayed : Action
            {
            }
        }

        public class Reducer : Reducer<State>
        {
            public override State Reduce(State state, Action action)
            {
                switch (action)
                {
                    case Actions.DisplayText a:
                        return new State(a.Payload, state.Prompts, state.CurrencyRates);

                    default:
                        return state;
                }
            }
        }

        public class Epics
        {
            public class DisplayText : Epic
            {
                public override IEnumerable<Action> Execute(Action input)
                {
                    switch (input)
                    {
                        case Actions.DisplayText action:
                            Console.Clear();
                            Console.WriteLine($"{action.Payload}");
                            yield break;
                    }
                }
            }
        }
    }
}
