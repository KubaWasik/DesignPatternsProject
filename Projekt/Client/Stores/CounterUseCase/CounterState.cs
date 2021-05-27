using Fluxor.Persist.Storage;

namespace Projekt.Client.Stores.CounterUseCase
{
    [PersistState]
    public record CounterState(int ClickCount);
}