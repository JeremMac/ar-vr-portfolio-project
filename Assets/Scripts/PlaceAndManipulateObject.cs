using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceAndManipulateObject : MonoBehaviour
{
    public GameObject objectToPlace; // L'objet à placer
    private GameObject spawnedObject;
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

            if (spawnedObject != null)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    MoveObject(touch);
                }
            }
        }

        // Pour la rotation, nous allons utiliser la rotation de l'objet avec un geste de mouvement
        if (spawnedObject != null && Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                RotateObject(touch1, touch2);
            }
        }
    }

    void PlaceObject()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
            }
        }
    }

    void MoveObject(Touch touch)
    {
        // Déplacement horizontal de l'objet
        Vector3 newPosition = spawnedObject.transform.position;
        newPosition.x += touch.deltaPosition.x * 0.01f; // Ajustez la valeur pour modifier la vitesse
        spawnedObject.transform.position = newPosition;
    }

    void RotateObject(Touch touch1, Touch touch2)
    {
        // Calculer la rotation basée sur les mouvements des deux doigts
        Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
        Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

        float angle = Vector2.SignedAngle(touch1PrevPos - touch2PrevPos, touch1.position - touch2.position);
        spawnedObject.transform.Rotate(Vector3.up, angle); // Ajustez l'axe de rotation si nécessaire
    }
}
