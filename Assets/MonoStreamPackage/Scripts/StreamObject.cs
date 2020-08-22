using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Mono
{
    public struct StreamObject
    {
        public readonly float Delay;
        public readonly Action OnSubscribed;

        public StreamObject(float delay, Action onSubscribed)
        {
            Delay = delay;
            OnSubscribed = onSubscribed;
        }
    }
}