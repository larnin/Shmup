using System;
using UnityEngine;

public class EventPlayerStayOnZone : EventArgs
{
    public GameObject collider;

    public EventPlayerStayOnZone(GameObject _collider)
    {
        collider = _collider;
    }
}
