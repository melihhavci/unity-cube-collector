using UnityEngine;

public class CubeSkor : MonoBehaviour
{
    private bool hasScored = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SkorAlani") && !hasScored)
        {
            GameManager.Instance.AddScore(1);
            hasScored = true; // Ayný küp birden fazla kez puan vermesin

            Debug.Log("Skor alanýna býrakýldý: " + gameObject.name);
        }
    }
}
