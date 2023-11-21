using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.Serialization;

public struct NetworkPalmGrabItemData : INetworkInput
{
    public Vector3 position;
    public Vector3 rotation;
}

public class PalmGrabItem :  NetworkBehaviour, INetworkRunnerCallbacks
{
    [Networked] public Vector3 networkedPosition { get; set; }
    [Networked] public Vector3 networkedRotation { get; set; }

    public Transform model;

    private NetworkRunner runner;
    public void Init(NetworkRunner runner)
    {
        this.runner = runner;
        
        if(Object.HasInputAuthority && this.runner.IsServer) //host 
            runner.AddCallbacks(this);
    }
    

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var data = new NetworkPalmGrabItemData();
        data.position = this.model.position;
        data.rotation = this.model.rotation.eulerAngles;
        input.Set(data);
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkPalmGrabItemData data))
        {
            this.networkedPosition = data.position;
            this.networkedRotation = data.rotation;
            
            Debug.LogFormat("position: {0}, rotation: {1}", data.position, data.rotation);
        }
    }
    
    public override void Render()
    {
        this.model.position = this.networkedPosition;
        this.model.rotation = Quaternion.Euler(this.networkedRotation);
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }
}
