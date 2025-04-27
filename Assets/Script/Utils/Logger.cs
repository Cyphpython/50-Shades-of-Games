using System;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    private static Queue<string> _queue = new Queue<string>(6);

    private void OnEnable()
    {
        Application.logMessageReceived += this.HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= this.HandleLog;
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0f, (float)(Screen.height - 140), (float)Screen.width, 140));
        foreach (string text in global::Logger._queue)
        {
            GUILayout.Label(text, Array.Empty<GUILayoutOption>());
        }
        GUILayout.EndArea();
    }

    private void HandleLog(string message, string stackTrace, LogType type)
    {
        global::Logger._queue.Enqueue(Time.time.ToString() + " _ " + message);
        if (global::Logger._queue.Count > 5 ) global::Logger._queue.Dequeue();
    }
}
