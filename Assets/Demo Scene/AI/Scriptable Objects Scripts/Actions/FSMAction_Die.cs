using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Action/Die")]
public class FSMAction_Die : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        machine.ToggleActive(false);
    }
}
