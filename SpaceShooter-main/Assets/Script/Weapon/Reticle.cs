using UnityEngine;

public class Reticle : MonoBehaviour
{
    public TargetLock targetLock;
    public RectTransform reticleUI;

    void Update()
    {
        if (targetLock.currentTarget != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetLock.currentTarget.position);
            reticleUI.position = screenPos;
        }
        else
        {
            reticleUI.position = new Vector3(-1000, -1000, 0); // Move off-screen if no target
        }
    }
}
