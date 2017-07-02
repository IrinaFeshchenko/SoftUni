using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Family_Tree
{
    public enum RecordVersion
    {
        v1, v2, v3, v4, v5, na
    }
    public class Record
    {
        public Record()
        {
        }

        public Record(string left, string right, RecordVersion version)
        {
            this.left = left;
            this.right = right;
            this.version = version;
        }

        public string left { get; set; }
        public string right { get; set; }
        public RecordVersion version { get; set; }

        public bool Equals(Record compared)
        {
            if (this.left==compared.left && this.right == compared.right)
            {
                return true;
            }

            return false;
        }
    }
}
