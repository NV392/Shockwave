using UnityEngine;
using System.Collections.Generic;

public class DontDestroy : MonoBehaviour
{
    private static HashSet<string> existingObjectIds = new HashSet<string>();

    [Tooltip("A unique identifier for this object across scenes.")]
    public string uniqueID;

    void Awake()
    {
        if (string.IsNullOrEmpty(uniqueID))
        {
            Debug.LogWarning($"GameObject '{gameObject.name}' is missing a uniqueID in DontDestroy. Destroying to avoid duplicate.");
            Destroy(gameObject);
            return;
        }

        if (existingObjectIds.Contains(uniqueID))
        {
            Destroy(gameObject);
        }
        else
        {
            existingObjectIds.Add(uniqueID);
            DontDestroyOnLoad(gameObject);
        }
    }
}
