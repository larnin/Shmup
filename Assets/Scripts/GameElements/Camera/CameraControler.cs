using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour
{

    private StateMachine m_machine = new StateMachine();

    CameraControler()
    {
        G.Sys.cameraControler = this;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {

    }
	
	void LateUpdate ()
    {
        m_machine.lateUpdate();
	}

    public void toStage1()
    {
        m_machine.killAllSub();
        new CameraStateStage1(m_machine);
    }

    public void toStage2()
    {
        m_machine.killAllSub();
        new CameraStateStage2(m_machine);
    }

    public void toStage3()
    {
        m_machine.killAllSub();
        new CameraStateStage3(m_machine);
    }
}
