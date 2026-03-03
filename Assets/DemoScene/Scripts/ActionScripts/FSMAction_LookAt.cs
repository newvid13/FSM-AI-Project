using UnityEngine;
using FSMAI;

[CreateAssetMenu(menuName = "FSM/Action/LookAt")]
public class FSMAction_LookAt : FSMAction
{
    public override void Execute(StateMachine machine)
    {
        EnemySight sight = machine.GetComponent<EnemySight>();

        if (sight.seenPlayer != null)
        {
            Vector3 tempPos = sight.seenPlayer.position;
            tempPos.y = machine.transform.position.y;
            Vector3 direction = tempPos - machine.transform.position;

            if (direction != Vector3.zero)
                machine.transform.rotation = Quaternion.LookRotation(direction.normalized);
        }
    }
}
