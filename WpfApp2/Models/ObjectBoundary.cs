using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ObjectBoundary
    {
        private ObjectId objectId;
        private string type;
        private string alias;
        private bool active;
        private DateTime creationTimestamp;
        private Dictionary<string, object> objectDetails;

        public ObjectBoundary()
        {
        }

        public ObjectBoundary(ObjectEntity entity)
        {
            string[] splittedObjectId = entity.ObjectId.Split(':');

            objectId = new ObjectId();
            objectId.Superapp = splittedObjectId[0];
            objectId.Id = splittedObjectId[1];
            
            type = entity.Type;
            alias = entity.Alias;
            active = entity.Active;
            creationTimestamp = entity.CreationTimestamp;
            CreatedBy c = new CreatedBy(entity.UserIdSuperapp, entity.UserIdEmail);
            objectDetails = entity.ObjectDetails;
            PutValuesAtObjectDetails(entity, type);
        }

        private void PutValuesAtObjectDetails(ObjectEntity entity, string type)
        {
            if (type == "dreamer" || type == "counselor")
            {
                objectDetails["gender"] = entity.Gender;
                objectDetails["birthdate"] = entity.Birthdate;
                objectDetails["username"] = entity.userName;
                objectDetails["password"] = entity.password;
                if (type == "dreamer")
                {
                    objectDetails["viewscount"] = entity.Viewscount;
                    objectDetails["offers"] = entity.Offers;
                }
                else if (type == "product")
                {
                    objectDetails["price"] = entity.Price;
                    objectDetails["supplyDays"] = entity.SupplyDays;
                    objectDetails["gender"] = entity.Gender;
                }
            }
        }

        public ObjectBoundary(string type, string alias, bool active, DateTime createdTimestamp, Dictionary<string, object> objectDetails)
        {
            this.type = type;
            this.alias = alias;
            this.active = active;
            this.creationTimestamp = createdTimestamp;
            this.objectDetails = objectDetails;
            this.objectDetails = objectDetails;
            this.objectDetails = objectDetails;
        }

        public ObjectId ObjectId
        {
            get { return objectId; }
            set { objectId = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Alias
        {
            get { return alias; }
            set { alias = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public DateTime CreationTimestamp
        {
            get { return creationTimestamp; }
            set { creationTimestamp = value; }
        }

        public Dictionary<string, object> ObjectDetails
        {
            get { return objectDetails; }
            set { objectDetails = value; }
        }

        public ObjectEntity ToEntity()
        {
            ObjectEntity entity = new ObjectEntity();

            entity.ObjectId = objectId.Superapp + ":" + objectId.Id;
            entity.SuperApp = objectId.Superapp;
            entity.CreationTimestamp = creationTimestamp;
            entity.Type = type;
            entity.Active = active;
            entity.Alias = alias;
            entity.ObjectDetails = objectDetails;
            

            return entity;
        }

        public override string ToString()
        {
            return "SuperAppObjectBoundary [objectId=" + objectId + ", type=" + type + ", alias=" + alias + ", active="
                + active + ", createdTimestamp=" + creationTimestamp  + ", objectDetails="
                + objectDetails + "]";
        }
    }
}
