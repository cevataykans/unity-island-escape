using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5f;

    Transform trfm;
    Camera mainCamera;
    Vector2 target = new Vector2();
    Animator charAnimator;

    Vector2 difference;
    bool caught = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        trfm = transform;

        charAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        target = mainCamera.ScreenToWorldPoint( Input.mousePosition);
        difference = (target - (Vector2)trfm.position);

        if ( target.x <= trfm.position.x && difference.sqrMagnitude >= 0.01)
        {
            charAnimator.SetBool("MovingRight", false);
        }
        else
        {
            charAnimator.SetBool("MovingRight", true);
        }

        transform.Translate( difference.normalized * Time.deltaTime * moveSpeed, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Enemy")
        {
            print("Oh nooo");
            caught = true;

            trfm.position = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( !caught)
        {
            print("You won");
            Time.timeScale = 0;

            // Display confetti, update best score, save best score, display play again or main menu
        }
        else
        {
            caught = false;
        }
    }
}
