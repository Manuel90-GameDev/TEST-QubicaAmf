using UnityEngine;

public class VisualizationState : IState
{
    private VisualizationViewController view;

    public VisualizationState(VisualizationViewController view)
    {
        this.view = view;
    }

    public void Enter()
    {
        view.OnEnter();
    }

    public void Exit()
    {
        view.OnExit();
    }
}
