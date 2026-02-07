using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using XNode;

public class StateMachine : MonoBehaviour
{
    [SerializeField] FSMGraph AIGraph;
    [SerializeField] bool isActive;
    [SerializeField] float updateFrequency;

    FSMStateBase currentState;
    Dictionary<Type, Component> components = new Dictionary<Type, Component>();

    //Debug
    [SerializeField] TMP_Text stateText;

    private void Awake()
    {
        FindStartingNode();
        InvokeRepeating(nameof(RunMachine), updateFrequency, updateFrequency);
    }

    private void FindStartingNode()
    {
        foreach (FSMStateBase startNode in AIGraph.nodes)
        {
            if (startNode is FSMState_Initial)
            {
                NodePort outPort = startNode.GetOutputPort("exit").Connection;
                if (outPort != null)
                {
                    ChangeState(outPort.node as FSMStateBase);
                    return;
                }
            }
        }

        throw new Exception("No Starting Node Found");
    }

    private void RunMachine()
    {
        if (!isActive)
            return;

        (currentState as FSMState).OnUpdate(this);
    }

    public void ChangeState(FSMStateBase newState)
    {
        if (newState == currentState)
            throw new Exception("Tried to change into current state");

        (currentState as FSMState)?.OnExit(this);
        currentState = newState;
        (currentState as FSMState)?.OnEnter(this);

        //Debug
        stateText.text = newState.ToString();
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
        }

    }
}
