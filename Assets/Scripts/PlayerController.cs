using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    public GameObject healthText;
    float speed = 5.0f;
    int health = 1;

    bool Death = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        healthText.GetComponent<Text>().text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        if(Death == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("isStrafe", true);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                playerAnim.SetBool("isStrafe", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("isStrafe", true);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                playerAnim.SetBool("isStrafe", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("isStrafe", true);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("isStrafe", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("isStrafe", true);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetBool("isStrafe", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnim.SetTrigger("trigAttack");
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                playerAnim.SetTrigger("trigAttack");
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            playerAnim.SetTrigger("trigDeath");
            Death = true;
            health --;
            healthText.GetComponent<Text>().text = "Health: " + health;
            Debug.Log("Touching RedCube");
        }
    }
}

