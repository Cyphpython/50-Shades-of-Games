using UnityEngine;

public class Initializer
{
    private const string PERSISTANTOBJECTNAME = "PERSISTOBJECTS";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Load()
    {
        GameObject existingPersistantObject = GameObject.Find(PERSISTANTOBJECTNAME);
        if (existingPersistantObject != null)
        {
            Debug.Log($"[Initializer] {PERSISTANTOBJECTNAME} already exist in scene. Skipping instantiation");
            return;
        }

        //load from Ressources
        GameObject prefab = Resources.Load<GameObject>(PERSISTANTOBJECTNAME);
        if (prefab == null)
        {
            Debug.LogError($"[Initializer] Could not load prefab '{PERSISTANTOBJECTNAME}' from Resources!");
            return;
        }

        GameObject instance = Object.Instantiate(prefab);
        instance.name = PERSISTANTOBJECTNAME; //no cloning

        Object.DontDestroyOnLoad(instance);
        Debug.Log($"[Initializer] Succesfully loaded and kept alive: {PERSISTANTOBJECTNAME}");
    }
}
