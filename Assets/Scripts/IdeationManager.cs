using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IdeationManager : MonoBehaviour
{
    public SocketManager socketManager; // Reference to the SocketManager
    public TextMeshPro LogText;

    void Start()
    {
        socketManager.socket.On("result", (response) =>
        {
            // UpdateLogText("Received result signal");
            string result = response.GetValue<string>();
            Debug.Log("Received ideation result: " + result);
            UpdateLogText("Received ideation result: " + result);
            // Here you can call a method to handle the result, e.g., notify the IdeationManager
        });
    }

    public void EmitIdeationSignal()
    {
        socketManager.Emit("ideation", new Dictionary<string, string> { { "token", "From UNITY ARNote Client" } });
        UpdateLogText("Require ideation signal emitted");
    }

    void UpdateLogText(string s)
    {
        // To avoid too long text, we do not append to the text.
        LogText.text = s;
    }
}
