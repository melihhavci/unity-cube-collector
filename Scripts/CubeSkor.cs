using UnityEngine;

public class CubeSkor : MonoBehaviour
{
    private bool hasScored = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SkorAlani") && !hasScored)
        {
            GameManager.Instance.AddScore(1);
            hasScored = true; // Ayn� k�p birden fazla kez puan vermesin

            Debug.Log("Skor alan�na b�rak�ld�: " + gameObject.name);
        }
    }
}
