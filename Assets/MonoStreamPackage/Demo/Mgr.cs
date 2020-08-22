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
            MonoStream.Subscribe(0.5f, () => Debug.Log("HI"));
            MonoStream.Subscribe(0.5f, () => Debug.Log("HI"));
            MonoStream.Subscribe(0.5f, () => Debug.Log("HI"));
            MonoStream.Subscribe(1f, () => Debug.Log("HI"));
            MonoStream.Subscribe(2f, () => Debug.Log("HI"));
        }
    }
}