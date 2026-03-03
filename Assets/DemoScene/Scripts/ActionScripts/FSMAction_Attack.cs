using UnityEngine;
using FSMAI;

[CreateAssetMenu(menuName = "FSM/Action/Attack")]
public class FSMAction_Attack : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        EnemyWeapon weapon = machine.GetComponent<EnemyWeapon>();
        weapon.Fire();
    }
}
