using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private Transform holdObject = null;
    private Collider detectedObject = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ta��nabilir"))
        {
            detectedObject = other;
            Debug.Log("Ta��nabilir nesne alg�land�: " + other.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == detectedObject)
        {
            detectedObject = null;
            Debug.Log("Nesne art�k menzilde de�il.");
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
                holdObject.localPosition = new Vector3(0, 1, 1); // Karakterin �n�ne yerle�tir
                holdObject.localRotation = Quaternion.identity;

                Debug.Log("Nesne al�nd�: " + holdObject.name);
            }
            else if (holdObject != null)
            {
                // Nesneyi b�rak
                holdObject.SetParent(null);
                holdObject.position = transform.position + transform.forward * 1.5f;
                Debug.Log("Nesne b�rak�ld�: " + holdObject.name);

                holdObject = null;
                detectedObject = null;
            }
        }
    }
}
