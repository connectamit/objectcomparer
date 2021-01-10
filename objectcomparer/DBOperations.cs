using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public abstract class DBOperations
    {
        public void TemplateMethod()
        {
            this.SaveObject();
            this.UpdateObject();
            this.Status();
            
        }

        // These operations already have implementations.
        protected void SaveObject()
        {
            Console.WriteLine("AbstractClass says: I am doing the bulk of the work");
        }

        protected void UpdateObject()
        {
            Console.WriteLine("AbstractClass says: But I let subclasses override some operations");
        }

        // These operations have to be implemented in subclasses.
        protected abstract void Status();

    }
}
