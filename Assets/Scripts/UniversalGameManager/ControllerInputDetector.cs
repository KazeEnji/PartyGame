using UnityEngine;
using System.Collections;
using Rewired;

public class ControllerInputDetector : MonoBehaviour
{
    void Awake()
    {
        ReInput.ControllerConnectedEvent += OnControllerConnected;
        ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
        ReInput.ControllerPreDisconnectEvent += OnControllerPreDisconnect;
    }

    void OnControllerConnected(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is connected
        // You can get information about the controller that was connected via the args parameter
        Debug.Log("A controller was connected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);
    }

    void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is fully disconnected
        // You can get information about the controller that was disconnected via the args parameter
        Debug.Log("A controller was disconnected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);
    }

    void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
    {
        // This function will be called when a controller is about to be disconnected
        // You can get information about the controller that is being disconnected via the args parameter
        // You can use this event to save the controller's maps before it's disconnected
        Debug.Log("A controller is being disconnected! Name = " + args.name + " Id = " + args.controllerId + " Type = " + args.controllerType);
    }
}
