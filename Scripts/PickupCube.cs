using UnityEngine;

public class PickupCube : MonoBehaviour
{
    public int puanDegeri = 1; // Inspector’dan ayarlanabilir
    private bool skorAlindi = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SkorAlani") && !skorAlindi)
        {
            GameManager.Instance.AddScore(puanDegeri);
            skorAlindi = true;
            Debug.Log(gameObject.name + " puan verdi: " + puanDegeri);
        }
    }
}
