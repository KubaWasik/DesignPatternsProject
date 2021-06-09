using Fluxor;

namespace Projekt.Client.Stores.NameUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static NameState ReduceChangeNameAction(NameState state, ChangeNameAction action) => new(action.Name);
    }
}