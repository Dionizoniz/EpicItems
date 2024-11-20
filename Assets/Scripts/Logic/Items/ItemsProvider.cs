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

        private readonly IDataServer _server;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public IList<DataItem> Items { get; private set; }
        public bool IsDataAvailable { get; private set; }

        public ItemsProvider()
        {
            _server = new DataServerMock();
            _cancellationTokenSource = new CancellationTokenSource();

            LoadItemsFromServer();
        }

        private async Task LoadItemsFromServer()
        {
            try
            {
                int size = await _server.DataAvailable(_cancellationTokenSource.Token);
                Items = await _server.RequestData(0, size, _cancellationTokenSource.Token);

                IsDataAvailable = true;
                OnDataLoaded.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        ~ItemsProvider()
        {
            ClearCancellationTokenSource();
        }

        private void ClearCancellationTokenSource()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}
