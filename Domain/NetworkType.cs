using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NetworkType : EntityBase
    {
        public const int MaxLength = 200;
        
        private string _code;
        public string Code { get => _code; }

        private string _name;
        public string Name { get => _name; }

        private string _xml;
        public string Xml { get => _xml; }

        private string _tableName;
        public string TableName { get => _tableName;  }

        public NetworkType()
        {
        }

        public NetworkType(long id, string code, string name, string xml, string tableName)
        {
            Id = id;
            _code = code;
            _name = name;
            _xml = xml;
            _tableName = tableName;
        }
    }
}
