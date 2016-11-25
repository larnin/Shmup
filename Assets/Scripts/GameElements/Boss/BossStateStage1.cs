using UnityEngine;

class BossStateStage1 : State
{
    public BossStateStage1(State parent) : base(parent)
    {

    }

    protected override void onStart()
    {
        G.Sys.gameManager.putObjectOnStartPosition(G.Sys.bossControler.gameObject, "BossStart");
    }

    protected override void onFixedUpdate()
    {

    }
}
