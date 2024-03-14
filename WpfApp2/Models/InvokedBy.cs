using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class InvokedBy
    {
        private UserId userId;

        public InvokedBy()
        {
            this.userId = new UserId();
        }

        public InvokedBy(UserId userId)
        {
            this.userId = userId;
        }

        public UserId GetUserId()
        {
            return new UserId(userId.GetSuperapp(), userId.GetEmail());
        }

        public void SetUserId(UserId userId)
        {
            this.userId = new UserId(userId.GetSuperapp(), userId.GetEmail());
        }
    }
}
