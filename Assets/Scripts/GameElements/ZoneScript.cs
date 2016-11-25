using UnityEngine;
using System.Collections;

public class ZoneScript : MonoBehaviour
{
    public float maxTime = 5;
    private float currentTime = 0;
    public Material finishedMaterial;
    private bool full = false;

    public bool isFull { get { return full; } }

    private SubscriberList subscriber = new SubscriberList();

	public ZoneScript()
    {
        subscriber.Add(new Event<EventPlayerStayOnZone>.Subscriber(new Event<EventPlayerStayOnZone>.Delegate(playerStayOnZoneEvent)));
    }

    private void OnEnable()
    {
        subscriber.Subscribe();
    }

    private void OnDisable()
    {
        subscriber.Unsubscribe();
    }

    private void playerStayOnZoneEvent(EventPlayerStayOnZone e)
    {
        if (e.collider != gameObject)
            return;
        currentTime += Time.deltaTime;

        if (currentTime >= maxTime)
        {
            GetComponent<Renderer>().material = finishedMaterial;
            if (!full)
            {
                full = true;
                Event<EventZoneFull>.Broadcast(new EventZoneFull());
            }
        }
    }
}
