using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Test.TimADay.Configuration
{
  
    class TesterConfig
    {
        private readonly Dictionary<string, string[]> _testers = new Dictionary<string, string[]>();

        public TesterConfig()
        {
            _testers.Add("Customer", new string[] { "test@timday.co.uk", "Digitalis1" });
        }

        public string[] Get(string key)
        {
            if (_testers.TryGetValue(key, out string[] arr))
            {
                return arr;
            }

            return default;
        }

        public string[] this[string key]
        {
            get { return _testers[key]; }
            set { _testers[key] = value; }
        }
    }
}
