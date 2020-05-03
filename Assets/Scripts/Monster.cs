using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Character charTarget;
    public float rotationSpeed = 180f;

    private Animator monsterAnimator;

    private void Start()
    {
        monsterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector2.SignedAngle( transform.position, charTarget.transform.position);

        if (Mathf.Abs(angle) <= 1.5)
        {
            angle = 0;
        }
        else if (angle > 0)
        {
            angle = 1;
            monsterAnimator.SetFloat("Angle", 0);
        }
        else
        {
            angle = -1;
            monsterAnimator.SetFloat("Angle", 1);
        }

        transform.RotateAround(Vector3.zero, Vector3.forward, angle * rotationSpeed * Time.deltaTime);
    }
}
