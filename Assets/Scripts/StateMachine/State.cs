using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class State
{ 
    protected State m_parent;
    private List<State> m_substates = new List<State>();

    private bool m_started = false;

    public State(State parent)
    {
        m_parent = parent;
        if (m_parent != null)
            m_parent.addSubstate(this);
    }

    ~State()
    {
        if (m_parent != null)
            m_parent.delSubstate(this);

    }

    public List<State> substates
    {
        get { return m_substates; }
    }

    public void killSub(State s)
    {
        delSubstate(s);
    }

    public void killAllSub()
    {
        m_substates.Clear();
    }

    private void addSubstate(State s)
    {
        if (m_substates.Contains(s))
            return;
        m_substates.Add(s);
    }

    private void delSubstate(State s)
    {
        m_substates.Remove(s);
    }

    public void update()
    {
        if(!m_started)
        {
            onStart();
            m_started = true;
        }

        onUpdate();

        foreach (var state in m_substates)
            state.update();
    }

    public void fixedUpdate()
    {
        if (!m_started)
        {
            onStart();
            m_started = true;
        }

        onFixedUpdate();

        foreach (var state in m_substates)
            state.fixedUpdate();
    }

    public void lateUpdate()
    {
        if (!m_started)
        {
            onStart();
            m_started = true;
        }

        onLateUpdate();

        foreach (var state in m_substates)
            state.lateUpdate();
    }

    protected virtual void onStart()
    {

    }

    protected virtual void onUpdate()
    {

    }

    protected virtual void onFixedUpdate()
    {

    }

    protected virtual void onLateUpdate()
    {

    }
}