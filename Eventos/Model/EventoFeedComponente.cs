using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Model
{
    public partial class EventoFeedComponente : Component
    {
        public EventoFeedComponente()
        {
            InitializeComponent();
        }

        public EventoFeedComponente(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
