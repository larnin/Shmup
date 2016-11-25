
class BossStateStage3 : State
{
    public BossStateStage3(State parent) : base(parent)
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
