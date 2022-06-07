using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerHandle
{
    public static void WelcomeReceived(int _fromClient, Packet _packet)
    {
        int _clientIdCheck = _packet.ReadInt();
        string _username = "Player";// _packet.ReadString();
        Vector3 _SpawnPosition = _packet.ReadVector3();
        Quaternion _SpawnRotation = _packet.ReadQuaternion();
        Debug.Log($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
        
        if (_fromClient != _clientIdCheck)
        {
            Debug.Log($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
        }
        Server.clients[_fromClient].SendIntoGame(_username,_SpawnPosition,_SpawnRotation);
    }
  
    public static void CanonMovement(int _fromClient, Packet _packet)
    {
        Vector3 _RequiredVelocity = _packet.ReadVector3();

         Server.clients[_fromClient].player.RotateTowards(_RequiredVelocity);
    }

    public static void CanonShoot(int _fromClient, Packet _packet)
    {
        Vector3 _throwVelocity = _packet.ReadVector3();
        int _weaponIndex = _packet.ReadInt();
        Server.clients[_fromClient].player.CanonShoot(_throwVelocity,_weaponIndex);
    }

    //public static void PlayerShoot(int _fromClient, Packet _packet)
    //{
    //    Vector3 _shootDirection = _packet.ReadVector3();

    //   // Server.clients[_fromClient].player.Shoot(_shootDirection);
    //}

    
}
