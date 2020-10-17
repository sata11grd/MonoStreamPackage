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
            MoStream.Subscribe(1f, () => Debug.Log("TODO"));
            MoStream.Subscribe(2f, () => Debug.Log("TODO"));
            MoStream.Subscribe(3f, () => Debug.Log("TODO"));
        }
    }
}