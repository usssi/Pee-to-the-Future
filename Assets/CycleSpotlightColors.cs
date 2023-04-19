using UnityEngine;

public class CycleSpotlightColors : MonoBehaviour
{
    public Color[] colors;
    public float transitionDuration = 1.0f;

    private int currentIndex = 0;
    private Color currentColor;
    private Color nextColor;
    private float transitionStartTime;

    private Light spotlight;

    private void Start()
    {
        spotlight = GetComponent<Light>();

        if (colors.Length > 0)
        {
            currentIndex = 0;
            currentColor = colors[currentIndex];
            nextColor = colors[(currentIndex + 1) % colors.Length];
            spotlight.color = currentColor;
        }

        transitionStartTime = Time.time;
    }

    private void Update()
    {
        if (colors.Length == 0)
            return;

        float transitionProgress = Mathf.Clamp01((Time.time - transitionStartTime) / transitionDuration);

        currentColor = Color.Lerp(currentColor, nextColor, transitionProgress);
        spotlight.color = currentColor;

        if (transitionProgress >= 1.0f)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            currentColor = nextColor;
            nextColor = colors[(currentIndex + 1) % colors.Length];
            transitionStartTime = Time.time;
        }
    }
}
