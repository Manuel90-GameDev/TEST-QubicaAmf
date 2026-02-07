using UnityEngine;

public class DashboardState : IState
{
    private DashboardViewController view;

    public DashboardState(DashboardViewController view)
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
