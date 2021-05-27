using System.Threading.Tasks;

using Blazored.LocalStorage;

using Fluxor.Persist.Storage;

namespace Projekt.Client.Stores
{
    public class LocalStateStorage : IStringStateStorage
    {
        public LocalStateStorage(ILocalStorageService localStorage)
        {
            LocalStorage = localStorage;
        }

        public ILocalStorageService LocalStorage { get; }

        public async ValueTask<string> GetStateJsonAsync(string statename)
        {
            return await LocalStorage.GetItemAsStringAsync(statename);
        }

        public async ValueTask StoreStateJsonAsync(string statename, string json)
        {
            await LocalStorage.SetItemAsStringAsync(statename, json);
        }
    }
}