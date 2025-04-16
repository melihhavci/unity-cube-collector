using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private Transform holdObject = null;
    private Collider detectedObject = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Taþýnabilir"))
        {
            detectedObject = other;
            Debug.Log("Taþýnabilir nesne algýlandý: " + other.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == detectedObject)
        {
            detectedObject = null;
            Debug.Log("Nesne artýk menzilde deðil.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (holdObject == null && detectedObject != null)
            {
                // Nesneyi al
                holdObject = detectedObject.transform;
                holdObject.SetParent(transform);
                holdObject.localPosition = new Vector3(0, 1, 1); // Karakterin önüne yerleþtir
                holdObject.localRotation = Quaternion.identity;

                Debug.Log("Nesne alýndý: " + holdObject.name);
            }
            else if (holdObject != null)
            {
                // Nesneyi býrak
                holdObject.SetParent(null);
                holdObject.position = transform.position + transform.forward * 1.5f;
                Debug.Log("Nesne býrakýldý: " + holdObject.name);

                holdObject = null;
                detectedObject = null;
            }
        }
    }
}
