using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private StateMachine m_machine = new StateMachine();

    GameManager()
    {
        G.Sys.gameManager = this;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        loadScene("Phase1", LoadSceneMode.Single , toStage1);
	}

    public void loadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single, Action callback = null)
    {
        var value = SceneManager.LoadSceneAsync(sceneName, mode);
        value.allowSceneActivation = true;
        StartCoroutine(waitToSceneLoaded(value, callback));
    }

    IEnumerator waitToSceneLoaded(AsyncOperation a, Action action = null)
    {
        while(!a.isDone)
        {
            yield return new WaitForFixedUpdate();
        }

        if (action != null)
            action();
    }

	void Update ()
    {
        m_machine.update();
	}

    public void toStage1()
    {
        m_machine.killAllSub();
        new GameStateStage1(m_machine);
        G.Sys.bossControler.toStage1();
        G.Sys.cameraControler.toStage1();
        G.Sys.playerControler.toStage1();
    }

    public void toStage2()
    {
        m_machine.killAllSub();
        new GameStateStage2(m_machine);
        G.Sys.bossControler.toStage2();
        G.Sys.cameraControler.toStage2();
        G.Sys.playerControler.toStage2();
    }

    public void toStage3()
    {
        m_machine.killAllSub();
        new GameStateStage3(m_machine);
        G.Sys.bossControler.toStage3();
        G.Sys.cameraControler.toStage3();
        G.Sys.playerControler.toStage3();
    }

    public void putObjectOnStartPosition(GameObject o, string posName)
    {
        var target = GameObject.FindGameObjectWithTag(posName);
        if (target != null)
            o.transform.position = target.transform.position;
    }
}
