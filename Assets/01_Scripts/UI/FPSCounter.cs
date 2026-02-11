using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private float refreshRate = 1f;

    private float _timer;
    private int _frameCount;

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;
        _frameCount++;

        if (_timer >= refreshRate)
        {
            float fps = _frameCount / _timer;

            if (fps >= 60)
            {
                fpsText.color = Color.green;
            }
            else if (fps >= 30)
            {
                fpsText.color = Color.yellow;
            }
            else
            {
                fpsText.color = Color.red;
            }

            fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";

            _timer = 0f;
            _frameCount = 0;
        }
    }
}
