using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mono.Demo
{
    public class Mgr : MonoBehaviour
    {
        private void Awake()
        {
            MonoStream.Subscribe(1f, () => Debug.Log("Hi!"));
            MonoStream.Subscribe(2f, () => Debug.Log("Ya!"));
            MonoStream.Subscribe(3f, () => Debug.Log("Hooley!"));
            MonoStream.Subscribe(1f, () => { MonoStream.Subscribe(3f, () => Debug.Log("4 secs elapsed.")); });
        }
    }
}