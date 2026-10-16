using UnityEngine;
using FSMAI;

[CreateAssetMenu(menuName = createPath + "Die")]
public class FSMAction_Die : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        Destroy(machine.gameObject);
    }
}
