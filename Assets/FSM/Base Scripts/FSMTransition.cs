using UnityEngine;

[CreateAssetMenu(menuName = "FSM/New Transition")]
public sealed class FSMTransition : ScriptableObject
{
    public FSMDecision decision;
    public FSMState trueState;
    public FSMState falseState;

    public void Execute(StateMachine machine)
    {
        if(decision.Decide(machine) == true && trueState is not FSMState_StayInCurrent)
        {
            machine.ChangeState(trueState);
        }
        else if(decision.Decide(machine) == false && falseState is not FSMState_StayInCurrent)
        {
            machine.ChangeState(falseState);
        }
    }
}
