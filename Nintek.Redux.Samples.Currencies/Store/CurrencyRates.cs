using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Nintek.Redux.Samples.Currencies.Store
{
    public class CurrencyRates
    {
        public class State
        {
            public class RequestState
            {
                public bool IsFetching { get; private set; }

                public RequestState() { }
                public RequestState(bool isFetching)
                {
                    IsFetching = isFetching;
                }
            }

            public class DataState
            {
                public string Value { get; private set; }

                public DataState() { }
                public DataState(string value)
                {
                    Value = value;
                }
            }

            public RequestState Request { get; private set; }
            public DataState Data { get; private set; }

            public State()
            {
            }

            public State(RequestState request, DataState data)
            {
                Request = request;
                Data = data;
            }
        }

        public class Actions
        {
            public class Fetch
            {
                public class Request : Action
                {
                }

                public class Success : Action<string>
                {
                    public Success(string payload) : base(payload)
                    {
                    }
                }
            }
        }

        public class Reducer : Reducer<State>
        {
            public override State Reduce(State state, Action action)
            {
                switch (action)
                {
                    case Actions.Fetch.Request a:
                        return new State(new State.RequestState(true), state.Data);

                    case Actions.Fetch.Success a:
                        return new State(
                            new State.RequestState(false),
                            new State.DataState(a.Payload));

                    default:
                        return state;
                }
            }
        }

        public class Epics
        {
            public class Request : Epic
            {
                public override IEnumerable<Action> Execute(Action input)
                {
                    switch (input)
                    {
                        case Actions.Fetch.Request a:
                            using (var webClient = new WebClient())
                            {
                                var result = webClient.DownloadString("http://api.fixer.io/latest");
                                yield return new Actions.Fetch.Success(result);
                            }
                            yield break;

                        case Actions.Fetch.Success a:
                            yield return
                                new App.Actions.DisplayText(AppRedux.State.CurrencyRates.Data.Value);
                            yield break;
                    }
                }
            }
        }
    }
}
