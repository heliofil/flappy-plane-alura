using UnityEngine;

public class BarriersDestoyerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        BarriersController barriesController = collision.GetComponentInParent<BarriersController>();

        barriesController.SelfDestroy();

    }

}
