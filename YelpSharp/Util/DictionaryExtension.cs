using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharp.Util
{
    public static class DictionaryExtension
    {
       
           /// <summary>
           /// 
           /// </summary>
           /// <typeparam name="T"></typeparam>
           /// <typeparam name="K"></typeparam>
           /// <typeparam name="V"></typeparam>
           /// <param name="me"></param>
           /// <param name="others"></param>
           /// <returns></returns>
            public static T MergeLeft<T, K, V>(this T me, params IDictionary<K, V>[] others)
                where T : IDictionary<K, V>, new()
            {
                T newMap = new T();
                foreach (IDictionary<K, V> src in
                    (new List<IDictionary<K, V>> { me }).Concat(others))
                {
                    foreach (KeyValuePair<K, V> p in src)
                    {
                        newMap[p.Key] = p.Value;
                    }
                }
                return newMap;
            }

        
    }
}
