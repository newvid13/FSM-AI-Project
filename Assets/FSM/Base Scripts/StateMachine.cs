using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateMachine : MonoBehaviour
{
    public bool isActive;
    public float updateFrequency;

    public FSMState initialState;
    public FSMState currentState;

    private Dictionary<Type, Component> components = new Dictionary<Type, Component>();
    [SerializeField] TMP_Text stateText;

    private void Awake()
    {
        ChangeState(initialState);
        InvokeRepeating(nameof(RunMachine), updateFrequency, updateFrequency);
    }

    public void RunMachine()
    {
        if (!isActive)
            return;

        currentState.OnUpdate(this);
    }

    public void ChangeState(FSMState newState)
    {
        if (newState == currentState)
            return;

        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);

        //Debug State
        stateText.text = currentState.ToString();
    }

    public new T GetComponent<T>() where T : Component
    {
        if (components.ContainsKey(typeof(T)))
            return components[typeof(T)] as T;

        Component component = base.GetComponent<T>();
        if (component != null)
        {
            components.Add(typeof(T), component);
            return component as T;
        }
        else
        {
            throw new Exception("No Such Component");
            //return null;
        }

    }
}
