// Assets/Scripts/ScreenshotHandler.cs
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    public SocketManager socketManager; // Reference to the SocketManager
    public TextMeshPro LogText;

    public void EmitScreenshotSignal()
    {
        socketManager.Emit("screenshot", new Dictionary<string, string> { { "token", "From UNITY ARNote Client" } });
        UpdateLogText("Screenshot signal emitted");
    }

    void UpdateLogText(string s)
    {
        //The Debug statements keep the same.
        LogText.text += "\n" + s;
    }
}
