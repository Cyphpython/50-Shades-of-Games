using System;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    private static Queue<string> _queue = new Queue<string>(6);
    private bool _showLog = false;


    private void Awake()
    {
        if (!Application.isEditor)
        {
            enabled = false;
            return;
        }
    }

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
        const float buttonWidth = 120f;
        const float buttonHeight = 30f;

        //button to show/hide logs
        if (GUI.Button(new Rect(900f, 10f, buttonWidth, buttonHeight), _showLog ? "Hide Logs" : "Show Logs"))
        {
            _showLog = !_showLog;
        }
        if (!_showLog) return;
        GUILayout.BeginArea(new Rect(0f, (float)(Screen.height - 140), (float)Screen.width, 140));
        foreach (string text in global::Logger._queue)
        {
            GUILayout.Label(text, Array.Empty<GUILayoutOption>());
        }
        GUILayout.EndArea();
    }

    private void HandleLog(string message, string stackTrace, LogType type)
    {
        _queue.Enqueue($"{Time.time:F2}_ {message}");
        if (_queue.Count > 5) _queue.Dequeue();
    }
}
