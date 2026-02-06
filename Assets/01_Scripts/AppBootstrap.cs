using UnityEngine;

public class AppBootstrap : MonoBehaviour
{
    public GameObject visualizationRoot;
    public GameObject dashboardRoot;

    private DashboardState dashboardState;
    private VisualizationState visualizationState;

    void Start()
    {
        dashboardState = new DashboardState(dashboardRoot);
        visualizationState = new VisualizationState(visualizationRoot);

        GameManager.Instance.StateMachine.ChangeState(dashboardState);
    }

    public void GoToVisualization()
    {
        GameManager.Instance.StateMachine.ChangeState(visualizationState);
    }

    public void GoToDashboard()
    {
        GameManager.Instance.StateMachine.ChangeState(dashboardState);
    }
}
