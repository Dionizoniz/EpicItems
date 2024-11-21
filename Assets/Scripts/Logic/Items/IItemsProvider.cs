using System;
using System.Collections.Generic;
using EpicItems.Core.DataServer;

namespace EpicItems.Logic.Items
{
    public interface IItemsProvider
    {
        event Action OnDataLoaded;

        IList<DataItem> Items { get; }
        bool IsDataAvailable { get; }
    }
}
