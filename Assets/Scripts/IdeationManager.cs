using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IdeationManager : MonoBehaviour
{
    public SocketManager socketManager; // Reference to the SocketManager
    public TextMeshPro LogText;

    void Start()
    {
        // socketManager.socket.On("ideation result", (response) =>
        // {
        //     string result = response.GetValue<string>(0);
        //     Debug.Log("Received ideation result: " + result);
        //     UpdateLogText("Received ideation result: " + result);
        //     // Here you can call a method to handle the result, e.g., notify the IdeationManager
        // });
    }

    public void EmitIdeationSignal()
    {
        socketManager.Emit("Ideation", new Dictionary<string, string> { { "token", "From UNITY ARNote Client" } });
        UpdateLogText("Ideation signal emitted");
    }

    void UpdateLogText(string s)
    {
        LogText.text += "\n" + s;
    }
}
