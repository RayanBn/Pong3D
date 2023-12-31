using UnityEngine;

public class PongBar : MonoBehaviour
{
    public bool isHuman = false;
    public float speed = 15f;

    private float xMaxDistance = 9.5f;

    void Update() {
        float move;

        if (isHuman) {
            move = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        } else {
            move = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        }

        transform.Translate(move, 0, 0);
        if (transform.position.x < -xMaxDistance) {
            transform.position = new Vector3(-xMaxDistance, transform.position.y, transform.position.z);
        } else if (transform.position.x > xMaxDistance) {
            transform.position = new Vector3(xMaxDistance, transform.position.y, transform.position.z);
        }
    }
}
