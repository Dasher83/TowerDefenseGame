using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Unit>().health--;

        if (collision.gameObject.GetComponent<Unit>().health < 1)
        {
            switch (collision.gameObject.GetComponent<Unit>().label)
            {
                case "Unit-Level1":
                    break;
            }

            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
