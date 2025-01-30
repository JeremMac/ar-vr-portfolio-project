using UnityEngine;

public class ObjectSelectionManager : MonoBehaviour
{
    public static ObjectSelectionManager Instance { get; private set; }
    public GameObject selectedObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste à travers les scènes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
