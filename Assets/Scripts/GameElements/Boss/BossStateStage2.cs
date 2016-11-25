
using UnityEngine;

class BossStateStage2 : State
{
    public BossStateStage2(State parent) : base(parent)
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
