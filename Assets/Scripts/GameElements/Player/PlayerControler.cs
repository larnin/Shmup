using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerControler : MonoBehaviour
{
    private StateMachine m_machine = new StateMachine();

    PlayerControler()
    {
        G.Sys.playerControler = this;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        m_machine.fixedUpdate();
    }

    void onTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Zone")
        {
            Event<EventPlayerEnterOnZone>.Broadcast(new EventPlayerEnterOnZone(collider.gameObject));
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Zone")
        {
            Event<EventPlayerStayOnZone>.Broadcast(new EventPlayerStayOnZone(collider.gameObject));
        }
    }

    public void toStage1()
    {
        m_machine.killAllSub();
        new PlayerStateStage1(m_machine);
    }

    public void toStage2()
    {
        m_machine.killAllSub();
        new PlayerStateStage2(m_machine);
    }

    public void toStage3()
    {
        m_machine.killAllSub();
        new PlayerStateStage3(m_machine);
    }
}
