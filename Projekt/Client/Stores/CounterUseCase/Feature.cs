using Fluxor;

namespace Projekt.Client.Stores.CounterUseCase
{
    public class Feature : Feature<CounterState>
    {
        public override string GetName() => "Counter";

        protected override CounterState GetInitialState() => new(0);
    }
}