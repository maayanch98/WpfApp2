using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ObjectEntity
    {
        public string ObjectId { get; set; }
        public string SuperApp { get; set; }
        public string Type { get; set; }
        public string Alias { get; set; }
        public bool Active { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public string UserIdSuperapp { get; set; }
        public string UserIdEmail { get; set; }
        public Dictionary<string, object> ObjectDetails { get; set; }
        public string Location { get; set; }
        public bool Gender { get; set; }
        public long Viewscount { get; set; }
        public long Birthdate { get; set; }
        public double Price { get; set; }
        public List<string> Views { get; set; }
        public List<string> Offers { get; set; }
        public int SupplyDays { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public ObjectEntity()
        {
        }

        public override string ToString()
        {
            return "ObjectEntity [ObjectId=" + ObjectId + ", SuperApp=" + SuperApp + ", Type=" + Type + ", Alias=" + Alias
                + ", Active=" + Active + ", CreationTimestamp=" + CreationTimestamp + ", UserIdSuperapp="
                + UserIdSuperapp + ", UserIdEmail=" + UserIdEmail + ", ObjectDetails=" + ObjectDetails + ", Location="
                + Location + ", Gender=" + Gender + ", Viewscount=" + Viewscount + ", Birthdate=" + Birthdate
                + ", Price=" + Price + ", Views=" + Views + ", Offers=" + Offers + ", SupplyDays=" + SupplyDays + "]";
        }
    }
}
