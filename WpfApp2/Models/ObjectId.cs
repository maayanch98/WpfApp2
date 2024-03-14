using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ObjectId
    {
        private string superapp;
        private string id;

        public ObjectId()
        {
        }

        public ObjectId(string superapp, string id)
        {
            this.superapp = superapp;
            this.id = id;
        }

        public string Superapp
        {
            get { return superapp; }
            set { superapp = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return "ObjectIdBoundary [superapp=" + superapp + ", id=" + id + "]";
        }

        internal object SetSuperapp(string v)
        {
            throw new NotImplementedException();
        }
    }
}
