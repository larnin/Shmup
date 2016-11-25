
using UnityEngine;
using UnityEngine.SceneManagement;

class GameStateStage1 : State
{
    private SubscriberList m_subscriber = new SubscriberList();

    public GameStateStage1(State parent) : base(parent)
    {
        m_subscriber.Add(new Event<EventPhase1Done>.Subscriber(new Event<EventPhase1Done>.Delegate(onPhase1Done)));
    }

    protected override void onStart()
    {
        m_subscriber.Subscribe();
    }

    protected override void onUpdate()
    {

    }

    void onPhase1Done(EventPhase1Done e)
    {
        G.Sys.gameManager.loadScene("Phase2", LoadSceneMode.Single, G.Sys.gameManager.toStage2);
    }
}
