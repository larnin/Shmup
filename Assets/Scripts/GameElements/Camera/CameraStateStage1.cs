using UnityEngine;

class CameraStateStage1 : State
{
    private float height = 10;
    private float moveSpeed;

    public CameraStateStage1(State parent) : base(parent)
    {

    }

    protected override void onStart()
    {
        Vector3 playerPos = G.Sys.playerControler.transform.position;
        Vector3 bossPos = G.Sys.bossControler.transform.position;
        Vector3 targetPos = (playerPos + bossPos) / 2;
        targetPos.y += height;
        G.Sys.cameraControler.transform.position = targetPos;
    }

    protected override void onLateUpdate()
    {
        Vector3 playerPos = G.Sys.playerControler.transform.position;
        Vector3 bossPos = G.Sys.bossControler.transform.position;
        Vector3 cameraPos = G.Sys.cameraControler.transform.position;
        Vector3 targetPos = (playerPos + bossPos) / 2;
        targetPos.y += height;

        float norm = (targetPos - cameraPos).magnitude;
        float divisor = Mathf.Pow(2, 5 * Time.deltaTime);
        float dist = norm/ divisor-(Time.deltaTime/4);
        if(dist > 0)
        {
            G.Sys.cameraControler.transform.position += (norm - dist) * (targetPos - cameraPos).normalized;
        }
    }
}
