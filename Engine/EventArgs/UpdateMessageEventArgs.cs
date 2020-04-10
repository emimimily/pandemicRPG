using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.EventArgs
{
    public class UpdateMessageEventArgs : System.EventArgs
    {
        public string Update { get; private set; }

        public UpdateMessageEventArgs(string update)
        {
            Update = update;
        }
    }
}
