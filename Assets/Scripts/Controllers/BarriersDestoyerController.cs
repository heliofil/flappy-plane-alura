using UnityEngine;

public class BarriersDestoyerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.GetComponentInParent<BarriersController>().gameObject);

    }

}
