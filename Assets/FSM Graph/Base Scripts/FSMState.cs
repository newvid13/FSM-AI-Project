using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateNodeMenu("State Node"), NodeWidth(350), NodeTint("#4A5423")]
public class FSMState : FSMStateBase
{
    [Input(backingValue = ShowBackingValue.Never)] public int entry;
    [Output(dynamicPortList = true)] public FSMTransition[] transitions;

    public List<FSMAction> updateActions = new List<FSMAction>();
    public List<FSMAction> enterActions = new List<FSMAction>();
    public List<FSMAction> exitActions = new List<FSMAction>();

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
        for (int i = 0; i < transitions.Length; i++)
        {
            FSMTransitionFork connectedFork = GetOutputPort("transitions " + i.ToString()).Connection.node as FSMTransitionFork;
            FSMStateBase returnedState = connectedFork.ForkResult(transitions[i].Decide(machine));

            if (returnedState is not FSMState_StayInCurrent)
            {
                machine.ChangeState(returnedState);
                break;
            }
        }
    }
}
