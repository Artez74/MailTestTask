using Data;
using System.Collections.Generic;

namespace Client
{
    interface IModelClient
    {
        void Save(ClientMessage[] clientMessage);
        IEnumerable<string> GetData();
        void Update();

    }
}
