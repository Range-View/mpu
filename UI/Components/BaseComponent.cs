using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Components
{
    public abstract class BaseComponent
    {
        public abstract void Update();
        public abstract void Render();
    }
}
