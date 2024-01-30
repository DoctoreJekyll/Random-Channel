using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralPlatformTouch : MonoBehaviour
{
    [SerializeField] bool isHead;
    [SerializeField] Vector2 impacForce;

    [SerializeField] Transform playerTransform;
    [SerializeField] Collider2D colliderBase2D;
    [SerializeField] Collider2D collider1, collider2;
    [SerializeField] float desactiveTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer== 6 || collision.gameObject.layer == 9)
        {
            if (isHead)
            {
                PlayerInputController.playerInputControllerInstance.rb2D.velocity = Vector2.zero;
                PlayerInputController.playerInputControllerInstance.rb2D.AddForce(-impacForce);
            }
            else
            {
                playerTransform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
                PlayerInputController.playerInputControllerInstance.rb2D.velocity = Vector2.zero;
                PlayerInputController.playerInputControllerInstance.rb2D.AddForce(impacForce);
            }
            StartCoroutine(DesactiveColliderCoroutine());
        }
    }

    IEnumerator DesactiveColliderCoroutine()
    {
        colliderBase2D.enabled = false;
        collider1.enabled = false;
        collider2.enabled = false;
        yield return new WaitForSeconds(desactiveTime);
        colliderBase2D.enabled = true;
        collider1.enabled = true;
        collider2.enabled = true;
    }
}
