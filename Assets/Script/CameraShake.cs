using UnityEngine;
using System.Collections;
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    public float duration = 0f;
    public float magnitude = 0f;

    private void Awake() {
        Instance = this;
    }
    public IEnumerator ScreenShake()
    {
        Vector3 originalPos = new Vector3(0, 0, -1);
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float Xoffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float Yoffset = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.localPosition = new Vector3(Xoffset, Yoffset, -1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
