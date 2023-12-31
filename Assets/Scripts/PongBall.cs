using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PongBall : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public TMP_Text scoreText;
    private float zMaxDistance = 15f;
    private int scorePlayer = 0;
    private int scoreComputer = 0;

    private void Start()
    {
        SetDirection();
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        if (transform.position.z < -zMaxDistance) {
            scoreComputer++;
            SetDirection();
        } else if (transform.position.z > zMaxDistance) {
            scorePlayer++;
            SetDirection();
        }
    }

    public void SetDirection()
    {
        scoreText.text = scorePlayer.ToString() + " - " + scoreComputer.ToString();
        transform.position = new Vector3(0, .5f, 0);
        direction = new Vector3(Random.Range(-.75f, 1.75f), 0, Random.Range(-.75f, 1.75f)).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bar") {
            bool isPlayer = collision.gameObject.GetComponent<PongBar>().isHuman;
            // if ((isPlayer && direction.z < 0) || (!isPlayer && direction.z > 0)) {
            //     direction.z *= -1;
            // }
            if (transform.position.z < 0) {
                direction = new Vector3(Random.Range(-.75f, 1.75f), 0, 1).normalized;
            } else {
                direction = new Vector3(Random.Range(-.75f, 1.75f), 0, -1).normalized;
            }
            if (!isPlayer) {
                collision.gameObject.GetComponent<PongAI>().AddBounce();
            }
        }
        if (collision.gameObject.tag == "Side") {
            direction.x *= -1;
        }
    }
}
