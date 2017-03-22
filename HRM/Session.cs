using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM
{
    public class Session
    {
        private Dictionary<string, object> _listObject = new Dictionary<string, object>();
        private string v;

        public Session(string v)
        {
            this.v = v;
        }

        public Session()
        {
        }

        private void Add(string key, object value)
        {
            if (_listObject.ContainsKey(key))
                _listObject[key] = value;
            else
                _listObject.Add(key, value);
        }
        public object Get(string key)
        {
            if (_listObject.ContainsKey(key))
                return _listObject[key];
            else
                return null;
        }

        public object this[string key] { set { Add(key, value); } get { return Get(key); } }

        public void Clear()
        {
            _listObject.Clear();
        }
    }
}
