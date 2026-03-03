using TMPro;
using UnityEngine;
using FSMAI;

public class Debug_ShowState : MonoBehaviour
{
    [SerializeField] TMP_Text stateText;
    StateMachine agentMachine;

    private void Start()
    {
        agentMachine = GetComponent<StateMachine>();
    }

    private void Update()
    {
        if(agentMachine.currentState != null)
            stateText.text = agentMachine.currentState.ToString();
    }
}
