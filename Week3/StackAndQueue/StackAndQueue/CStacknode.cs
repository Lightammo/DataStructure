using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class CStacknode
    {
        private Type data;
        private CStacknode<Type> next;
        //--------------------------------------------------------------------------------
        public CStacknode()
        {
            next = null;
        }
        public CStacknode(Type data)
        {
            this.data = data;
            next = null;
        }
        public CStacknode(Type data, CStacknode<Type> next)
        {
        }
        public Type Data
        {
            get { return data; }
            set { data = value; }
        }
        public CStacknode<Type> Next
        {
        }
    }
}
