using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EpicItems.Core.DataServer;

namespace EpicItems.Logic.Items
{
    public class ItemsProvider : IItemsProvider
    {
        public event Action OnDataLoaded = delegate { };

        private IDataServer _server;
        private CancellationToken _cancellationToken;

        public IList<DataItem> Items { get; private set; }
        public bool IsDataAvailable { get; private set; }

        public ItemsProvider()
        {
            _server = new DataServerMock();
            _cancellationToken = new CancellationToken();

            LoadItemsFromServer();
        }

        private async Task LoadItemsFromServer()
        {
            try
            {
                int size = await _server.DataAvailable(_cancellationToken);
                Items = await _server.RequestData(0, size, _cancellationToken);

                IsDataAvailable = true;
                OnDataLoaded.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
