using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Mono
{
    public static class MonoStream
    {
        private static readonly CancellationTokenSource Cts = new CancellationTokenSource();

        static MonoStream()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#else
            Application.onBeforeRender += () =>
            {
                if (!Application.isPlaying) Cts.Cancel();
            };
#endif
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            if (!Application.isPlaying) Cts.Cancel();
        }
        
        private static async Task SubscribeStreamObjectAsync(StreamObject streamObject)
        {
            await Task.Delay(TimeSpan.FromSeconds(streamObject.Delay));
            if (Cts.Token.IsCancellationRequested) return;
            streamObject.OnSubscribed?.Invoke();
        }
        
        public static void Subscribe(StreamObject streamObject)
        {
            var t = SubscribeStreamObjectAsync(streamObject);
        }

        public static void Subscribe(float delay, Action onSubscribed)
        {
            Subscribe(new StreamObject(delay, onSubscribed));
        }
    }
}