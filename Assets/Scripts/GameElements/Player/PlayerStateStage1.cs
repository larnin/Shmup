
using UnityEngine;

class PlayerStateStage1 : State
{
    public const float speed = 5;

    public PlayerStateStage1(State parent) : base(parent)
    {

    }

    protected override void onStart()
    {
        G.Sys.gameManager.putObjectOnStartPosition(G.Sys.playerControler.gameObject, "PlayerStart");
    }

    protected override void onFixedUpdate()
    {
        bool moveLeft = Input.GetAxisRaw("Horizontal") < -Constants.axisTrigger;
        bool moveRight = Input.GetAxisRaw("Horizontal") > Constants.axisTrigger;
        bool moveUp = Input.GetAxisRaw("Vertical") < -Constants.axisTrigger;
        bool moveDown = Input.GetAxisRaw("Vertical") > Constants.axisTrigger;

        Vector2 dir = new Vector2(moveLeft ? -1 : moveRight ? 1 : 0, moveUp ? -1 : moveDown ? 1 : 0);
        dir.Normalize();
        dir *= speed * Time.deltaTime;
        var rigibody = G.Sys.playerControler.GetComponent<Rigidbody>();
        rigibody.transform.position += new Vector3(dir.x, 0, dir.y);
    }
}
