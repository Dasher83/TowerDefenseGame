using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Instance of the class
    [Header("Turret Attributes")]
    public static Turret instance;
    public Transform shootPoint;
    public GameObject bullet;

    [Header("Turret Properties")]
    public int totalLives = 5;
    public int currentLives = 5;
    public float viewDistance;
    public float fireRate;
    public float fireForce;
    public float bulletSpeed;
    public bool isChildTurret = false;

    private float nextTimeToFire = 0;
    private Transform lockedOnTarget;
    private Vector3 closestEnemyPosition;
    private Vector2 direction;
    private bool detected = false;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        #region -- Game over check --
        if (currentLives <= 0)
        {
            currentLives = 0;
            Destroy(gameObject);
            if (!isChildTurret)
            {
                Time.timeScale = 0;
                Debug.Log("GAME OVER");
                return;
            }
        }
        #endregion

        #region -- Lock next target and shoot --
        if (lockedOnTarget != null)
        {
            Vector2 targetPosition = lockedOnTarget.position;
            direction = targetPosition - (Vector2)this.transform.position;
            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, viewDistance);
            if (rayInfo)
            {
                if (rayInfo.collider.gameObject.tag == "Unit")
                {
                    if (detected == false)
                    {
                        detected = true;
                    }
                }
                else
                {
                    if (detected == true)
                    {
                        detected = false;
                    }
                }
            }
            if (detected)
            {
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
        }
        #endregion
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(direction * fireForce * bulletSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, this.viewDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, .25f);
        Gizmos.color = Color.cyan;
        if (this.closestEnemyPosition != null)
        {
            Gizmos.DrawLine(this.transform.position, this.closestEnemyPosition);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Unit");
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);

            if (this.isChildTurret && distance <= 0.35f)
            {
                Destroy(this.gameObject);
            }

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            this.closestEnemyPosition = closestEnemy.transform.position;
        }

        if (closestEnemy != null && shortestDistance <= this.viewDistance)
        {
            this.lockedOnTarget = closestEnemy.transform;
        }
        else
        {
            this.lockedOnTarget = null;
        }
    }
}
