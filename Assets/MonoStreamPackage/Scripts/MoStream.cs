using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Mono
{
    public class MoStream : MonoBehaviour
    {
        private static MoStream _instance;
        private static readonly List<StreamObject> Contents = new List<StreamObject>();

        private void Update()
        {
            for (var i = 0; i < Contents.Count; i++)
            {
                var target = Contents[i];
                target.Delay -= Time.deltaTime;
                
                if (target.Delay <= 0)
                {
                    target.OnSubscribed.Invoke();
                    Contents.RemoveAt(i);
                    --i;
                    continue;
                }
                
                Contents[i] = target;
            }
        }
        
        public static void Subscribe(StreamObject streamObject)
        {
            if (_instance == null)
            {
                var obj = new GameObject {name = "Mono Stream"};
                var comp = obj.AddComponent<MoStream>();
                _instance = comp;
                DontDestroyOnLoad(obj);
            }
            Contents.Add(streamObject);
        }

        public static StreamObject Subscribe(float delay, Action onSubscribed)
        {
            var o = new StreamObject(delay, onSubscribed);
            Subscribe(o);
            return o;
        }
    }
}
