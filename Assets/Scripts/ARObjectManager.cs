using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic; // N'oubliez pas d'importer ce namespace

public class ARObjectManager : MonoBehaviour
{
    public GameObject objectToPlace; // L'objet à placer
    private GameObject spawnedObject; // L'objet déjà placé
    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                PlaceObject();
            }
            else if (touch.phase == TouchPhase.Moved && spawnedObject != null)
            {
                MoveObject();
            }
            else if (touch.phase == TouchPhase.Moved && spawnedObject != null && touch.tapCount == 2)
            {
                RotateObject();
            }
        }
    }

    void PlaceObject()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>(); // Créez une liste pour stocker les résultats

        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }

    void MoveObject()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>(); // Créez une liste pour stocker les résultats

        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            spawnedObject.transform.position = hitPose.position;
        }
    }

    void RotateObject()
    {
        spawnedObject.transform.Rotate(Vector3.up, 45f); // Rotation de 45 degrés autour de l'axe Y
    }
}
