﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Samples.Currencies.Store
{
    public class Prompts
    {
        public class State
        {
            public string Answer { get; private set; }

            public State()
            {
            }

            public State(string answer)
            {
                Answer = answer;
            }
        }

        public class Actions
        {
            public class PromptUser : IAction { }

            public class UserAnswered : IAction<string>
            {
                public string Payload { get; }

                public UserAnswered(string payload)
                {
                    Payload = payload;
                }
            }
        }

        public class Reducer : Reducer<State>
        {
            public override State Reduce(State state, IAction action)
            {
                switch (action)
                {
                    case Actions.UserAnswered answered:
                        return new State(answered.Payload);

                    default:
                        return state;
                }
            }
        }

        public class Epics
        {
            public class PromptUser : Epic
            {
                public override IEnumerable<IAction> Execute(IAction input)
                {
                    switch (input)
                    {
                        case Actions.PromptUser action:
                            yield return new App.Actions.DisplayText("Hi, how can I help you?");
                            Console.Write("> ");
                            var answer = Console.ReadLine();
                            yield return new Actions.UserAnswered(answer);
                            yield break;

                        case Actions.UserAnswered action:
                            yield return new CurrencyRates.Actions.Fetch.Request();
                            yield break;
                    }
                }
            }
        }
    }
}
