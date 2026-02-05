using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "FSM/New State")]
public class FSMState : ScriptableObject
{
    public List<FSMAction> updateActions = new List<FSMAction>();
    public List<FSMAction> enterActions = new List<FSMAction>();
    public List<FSMAction> exitActions = new List<FSMAction>();
    public List<FSMTransition> transitions = new List<FSMTransition>();

    public virtual void OnEnter(StateMachine machine)
    {
        //Execute enter actions
        foreach (FSMAction action in enterActions)
            action.Execute(machine);
    }

    public virtual void OnExit(StateMachine machine)
    {
        //Execute exit actions
        foreach (FSMAction action in exitActions)
            action.Execute(machine);
    }

    public virtual void OnUpdate(StateMachine machine)
    {
        //Execute update actions
        foreach (FSMAction action in updateActions)
            action?.Execute(machine);

        //Execute transitions
        foreach (FSMTransition transition in transitions)
        {
            transition?.Execute(machine);
        }
    }
}
