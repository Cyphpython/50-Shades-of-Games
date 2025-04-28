using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
    private void Update()
    {
        if (FindFirstObjectByType<EventSystem>() == null)
        {
            Debug.LogWarning("No EventSystem found! Creating one automatically.");
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

}
