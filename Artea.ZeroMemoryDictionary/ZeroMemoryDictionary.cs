using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Artea.ZeroMemoryDictionary
{
    public class ZeroMemoryDictionary : IDictionary<string, string>
    {
        private readonly string _fileName;

        public ZeroMemoryDictionary(string fileName)
        {
            _fileName = fileName;
        }

        public ZeroMemoryDictionary() : this($"{Guid.NewGuid()}.json")
        {
        }

        public string this[string key]
        {
            get
            {
                var data = Read();
                return data[key];
            }

            set
            {
                var data = Read();
                data[key] = value;
                Write(data);
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                var data = Read();
                return data.Keys;
            }
        }

        public ICollection<string> Values
        {
            get
            {
                var data = Read();
                return data.Values;
            }
        }

        public int Count
        {
            get
            {
                var data = Read();
                return data.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                var data = Read();
                return data.IsReadOnly;
            }
        }

        public void Add(string key, string value)
        {
            var data = Read();

            data.Add(key, value);

            Write(data);
        }

        public void Add(KeyValuePair<string, string> item) => Add(item.Key, item.Value);

        public void Clear() => Write(new Dictionary<string, string>());

        public bool Contains(KeyValuePair<string, string> item)
        {
            var data = Read();

            return data.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            var data = Read();

            return data.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            var data = Read();

            data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            var data = Read();
            return data.GetEnumerator();
        }

        public bool Remove(string key)
        {
            var data = Read();

            bool result = data.Remove(key);

            if (result)
            {
                Write(data);
            }

            return result;
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            var data = Read();

            bool result = data.Remove(item);

            if (result)
            {
                Write(data);
            }

            return result;
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            var data = Read();

            return data.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var data = Read();

            return ((IEnumerable)data).GetEnumerator();
        }

        private IDictionary<string, string> Read()
        {
            if (!File.Exists(_fileName))
            {
                return new Dictionary<string, string>();
            }

            string jsonString = File.ReadAllText(_fileName);
            return JsonSerializer.Deserialize<IDictionary<string, string>>(jsonString);
        }

        private void Write(IDictionary<string, string> data)
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(_fileName, jsonString);
        }
    }
}
