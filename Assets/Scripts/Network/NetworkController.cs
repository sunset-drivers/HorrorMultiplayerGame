using SocketIOClient;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour
{    
    public async void Connect()
    {
        #region bla
        //var uri = new Uri("http://localhost:3000");
        //var socket = new SocketIO(uri, new SocketIOOptions
        //{
        //    Query = new Dictionary<string, string>
        //    {
        //        {"token","v3"}
        //    }
        //});

        //socket.OnConnected += Socket_OnConnected;
        #endregion
        var client = new SocketIO("http://localhost:3000");
        client.On("PONG", response =>
        {
            string text = response.GetValue<string>();
            Debug.Log(text);
        });

        client.OnConnected += async (sender, e) =>
        {
            await client.EmitAsync("PING", "Jurubelbo");
        };

        await client.ConnectAsync();
    }
}
