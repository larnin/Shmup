using UnityEngine;
using System.Collections;

public class Phase1Checker : MonoBehaviour
{
    private SubscriberList subscriber = new SubscriberList();

    public Phase1Checker()
    {
        subscriber.Add(new Event<EventZoneFull>.Subscriber(new Event<EventZoneFull>.Delegate(onZoneFilled)));
    }

    private void OnEnable()
    {
        subscriber.Subscribe();
    }

    private void OnDisable()
    {
        subscriber.Unsubscribe();
    }

    private void onZoneFilled(EventZoneFull e)
    {
        bool allDone = true;
        var objecs = GameObject.FindGameObjectsWithTag("Zone");
        foreach(var o in objecs)
        {
            var script = o.GetComponent<ZoneScript>();
            if (script == null)
                return;
            if(!script.isFull)
            {
                allDone = false;
                break;
            }
        }

        if (allDone)
        {
            Event<EventPhase1Done>.Broadcast(new EventPhase1Done());
            Debug.Log("All zones done !");
        }
    }
}
