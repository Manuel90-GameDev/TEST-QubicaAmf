using UnityEngine;

public class AppBootstrap : MonoBehaviour
{
    public DashboardViewController dashboardView;
    public VisualizationViewController visualizationView;

    private DashboardState dashboardState;
    private VisualizationState visualizationState;

    void Start()
    {
        dashboardState = new DashboardState(dashboardView);
        visualizationState = new VisualizationState(visualizationView);

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
