using Fluxor.Persist.Storage;

namespace Projekt.Client.Stores.NameUseCase
{
    [PersistState]
    public record NameState(string Name);
}