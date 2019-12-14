using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMOvement movement;
    public Rigidbody rb;
    private bool PowerUp;
    private int SlowDown = 0;

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ( "PowerUp"))
        {
            PowerUp = true;
            other.gameObject.SetActive(false);
            SlowDown = SlowDown - 100;
            Invoke("SpeedUp", 15f);
        }
    }

    void FixedUpdate()
    {
        if(PowerUp == true)
        {
            rb.AddForce(0, 0, SlowDown * Time.deltaTime);

        }
    }

    void SpeedUp()
    {
        SlowDown = SlowDown + 100;
    }


    
    
}
