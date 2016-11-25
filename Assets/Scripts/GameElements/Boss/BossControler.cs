using UnityEngine;
using System.Collections;

public class BossControler : MonoBehaviour
{
    private StateMachine m_machine = new StateMachine();
    
    BossControler()
    {
        G.Sys.bossControler = this;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {

    }
	
	void FixedUpdate ()
    {
        m_machine.fixedUpdate();
	}

    public void toStage1()
    {
        m_machine.killAllSub();
        new BossStateStage1(m_machine);
    }

    public void toStage2()
    {
        m_machine.killAllSub();
        new BossStateStage2(m_machine);
    }

    public void toStage3()
    {
        m_machine.killAllSub();
        new BossStateStage3(m_machine);
    }
}
