using UnityEngine;

public class VisualizationViewController : BaseViewController
{
    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Visualization ENTER");
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Visualization EXIT");
    }
}
