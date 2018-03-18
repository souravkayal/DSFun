using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    //It's key value representation to store Object
    public class Pair
    {
        Dictionary<string, string> _store;
        public Pair()
        {
           this._store = new Dictionary<string, string>();
        }

        public void AddPair(string Key, string Value)
        {
            if(!_store.ContainsKey(Key))
                this._store.Add(Key, Value);
        }

        public string GetKey(string Value)
        {
            return this._store.FirstOrDefault(f => f.Value == Value).Key;
        }
        
        public KeyValuePair<string,string> GetKeyValuePair(string Key)
        {
            return this._store.Where(f=>f.Key == Key).FirstOrDefault();
        }

        public bool IsEqual(KeyValuePair<string,string> Pair1, KeyValuePair<string,string> Pair2)
        {
            return Pair1.Key == Pair2.Key && Pair1.Value == Pair2.Value;
        }

        public List<KeyValuePair<string,string>> GetWhere(Func<KeyValuePair<string,string>,bool> where)
        {
            return this._store.Where(where).ToList();
        }
    }

    //Generic key value  pair

    public class Pair<TKey, TValue>
    {
        Dictionary<TKey, TValue> _store;
        public Pair()
        {
            this._store = new Dictionary<TKey, TValue>();
        }

        public void AddPair(TKey Key, TValue Value)
        {
            if(!this._store.ContainsKey(Key))
                this._store.Add(Key, Value);
        }

        public KeyValuePair<TKey, TValue> GetKeyValuePair(TKey Key)
        {
            return this._store.Where(f => f.Key.Equals(Key)).FirstOrDefault();
        }

        public bool IsEqual(KeyValuePair<TKey, TValue> Pair1, KeyValuePair<TKey, TValue> Pair2)
        {
            return Pair1.Key.Equals(Pair2.Key) && Pair1.Value.Equals(Pair2.Value);
        }

        public List<KeyValuePair<TKey, TValue>> GetWhere(Func<KeyValuePair<TKey, TValue>, bool> where)
        {
            return this._store.Where(where).ToList();
        }
    }
}
