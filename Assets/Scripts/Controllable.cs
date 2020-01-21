using System;
using UnityEditor;
using UnityEngine;
using UnityOSC;

public abstract class Controllable : MonoBehaviour
{
    private OSCServer _server;
    private OSCHandler OscHandler => OSCHandler.Instance;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        EditorApplication.quitting += Quit;
        OscHandler.Init();
        _server = OscHandler.CreateServer("Unity", 9000);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        Receive();
    }
      
    /// <summary>
    /// 
    /// </summary>
    private void Quit()
    {
        _server.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Receive()
    {
        OscHandler.UpdateLogs();
        for (var i = 0; i< OSCHandler.Instance.packets.Count; i++) {
            // Process OSC
            OnReceive(OSCHandler.Instance.packets[i]);
            // Remove them once they have been read.
            OSCHandler.Instance.packets.Remove(OSCHandler.Instance.packets[i]);
            i--;
        }
        
        

    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packet"></param>
    /// <exception cref="NotImplementedException"></exception>
    protected virtual void OnReceive(OSCPacket packet)
    {
        throw new NotImplementedException("OnReceive should not be called from the base class.");
    }
}