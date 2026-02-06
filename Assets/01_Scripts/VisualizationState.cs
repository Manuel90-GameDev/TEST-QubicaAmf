using UnityEngine;

public class VisualizationState : IState
{
    private GameObject root;

    public VisualizationState(GameObject visualizationRoot)
    {
        root = visualizationRoot;
    }

    public void Enter()
    {
        root.SetActive(true);
    }

    public void Exit()
    {
        root.SetActive(false);
    }
}
