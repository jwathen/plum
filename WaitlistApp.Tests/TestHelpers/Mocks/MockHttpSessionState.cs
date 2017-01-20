using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaitlistApp.Tests.TestHelpers.Mocks
{
    public class MockHttpSessionState : HttpSessionStateBase
    {
        private Dictionary<string, object> _state = new Dictionary<string, object>();

        public override void Abandon()
        {
            _state.Clear();
        }

        public override void Add(string name, object value)
        {
            _state[name] = value;
        }

        public override void Clear()
        {
            _state.Clear();
        }

        public override void Remove(string name)
        {
            _state.Remove(name);
        }

        public override void RemoveAll()
        {
            _state.Clear();
        }

        public override object this[string name]
        {
            get
            {
                if (_state.ContainsKey(name))
                {
                    return _state[name];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _state[name] = value;
            }
        }
    }
}
