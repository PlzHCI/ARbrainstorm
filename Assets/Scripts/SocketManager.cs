using System;
using System.Collections.Generic;
using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;
using UnityEngine;

public class SocketManager : MonoBehaviour
{
    public SocketIOUnity socket;

    void Start()
    {
        //TODO: check the Uri if Valid.
        var uri = new Uri("http://10.131.194.240:3000/");
        socket = new SocketIOUnity(
            uri,
            new SocketIOOptions
            {
                Query = new Dictionary<string, string> { { "token", "UNITY" } },
                EIO = 4,
                Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
            }
        );
        socket.JsonSerializer = new NewtonsoftJsonSerializer();

        ///// reserved socketio events
        socket.OnConnected += (sender, e) =>
        {
            Debug.Log("socket.OnConnected");
        };
        socket.OnPing += (sender, e) =>
        {
            Debug.Log("Ping");
        };
        socket.OnPong += (sender, e) =>
        {
            Debug.Log("Pong: " + e.TotalMilliseconds);
        };
        socket.OnDisconnected += (sender, e) =>
        {
            Debug.Log("disconnect: " + e);
        };
        socket.OnReconnectAttempt += (sender, e) =>
        {
            Debug.Log($"{DateTime.Now} Reconnecting: attempt = {e}");
        };
        ////

        Debug.Log("Connecting...");
        socket.Connect();
    }

    public void Emit(string eventName, Dictionary<string, string> data)
    {
        socket.Emit(eventName, data);
    }

    void OnDestroy()
    {
        socket.Disconnect();
    }
}