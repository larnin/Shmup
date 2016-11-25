using System;
using UnityEngine;

class EventPlayerEnterOnZone : EventArgs
{
    public GameObject collider;

    public EventPlayerEnterOnZone(GameObject _collider)
    {
        collider = _collider;
    }
}
