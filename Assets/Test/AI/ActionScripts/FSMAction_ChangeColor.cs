using UnityEngine;
using FSMAI;

[CreateAssetMenu(menuName = createPath + "Change Color")]
public class FSMAction_ChangeColor : FSMAction
{
    public Color changeIntoColor;

    public override void Execute(StateMachine machine)
    {
        machine.GetComponent<MeshRenderer>().material.color = changeIntoColor;
    }
}
