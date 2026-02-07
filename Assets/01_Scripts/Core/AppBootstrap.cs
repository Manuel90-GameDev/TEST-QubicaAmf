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
        Debug.Log("Exit Dashboard");
    }

    public void GoToDashboard()
    {
        GameManager.Instance.StateMachine.ChangeState(dashboardState);
        Debug.Log("Enter Dashboard");
    }
}
