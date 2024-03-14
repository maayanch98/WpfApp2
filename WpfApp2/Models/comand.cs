using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    internal class comand
    {
        public class CommandId
        {
            private string superapp;
            private string miniapp;
            private string id;

            public CommandId()
            {
            }

            public CommandId(string superapp, string miniapp, string id)
            {
                this.SetSuperapp(superapp);
                this.SetMiniapp(miniapp);
                this.SetId(id);
            }

            public string GetSuperapp()
            {
                return superapp;
            }

            public CommandId SetSuperapp(string superapp)
            {
                this.superapp = superapp;
                return this;
            }

            public string GetMiniapp()
            {
                return miniapp;
            }

            public CommandId SetMiniapp(string miniapp)
            {
                this.miniapp = miniapp;
                return this;
            }

            public string GetId()
            {
                return id;
            }

            public CommandId SetId(string id)
            {
                this.id = id;
                return this;
            }
        }

    }
}
