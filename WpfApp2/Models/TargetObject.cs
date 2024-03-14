using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TargetObject
    {
        private ObjectId objectId;

        public TargetObject()
        {
        }

        public TargetObject(ObjectId objectId)
        {
            this.objectId = objectId;
        }

        public ObjectId GetObjectId()
        {
            return new ObjectId(objectId.Superapp, objectId.Id);
        }

        public void SetObjectId(ObjectId objectId)
        {
            this.objectId = new ObjectId(objectId.Superapp, objectId.Id);
        }
    }
}
