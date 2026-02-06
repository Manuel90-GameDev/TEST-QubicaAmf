using UnityEngine;

public class DashboardState : IState
{
    private GameObject root;

    public DashboardState(GameObject dashboardRoot)
    {
        root = dashboardRoot;
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
