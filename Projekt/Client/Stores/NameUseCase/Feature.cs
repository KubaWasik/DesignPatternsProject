using Fluxor;

namespace Projekt.Client.Stores.NameUseCase
{
    public class Feature : Feature<NameState>
    {
        public override string GetName() => "Name";

        protected override NameState GetInitialState() => new(string.Empty);
    }
}