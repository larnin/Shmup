
class PlayerStateStage2 : State
{
    public PlayerStateStage2(State parent) : base(parent)
    {

    }

    protected override void onStart()
    {
        G.Sys.gameManager.putObjectOnStartPosition(G.Sys.playerControler.gameObject, "PlayerStart");
    }

    protected override void onFixedUpdate()
    {

    }
}
