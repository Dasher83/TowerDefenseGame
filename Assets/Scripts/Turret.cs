using UnityEngine;

public class Turret : MonoBehaviour, IDamageable
{
    // Instance of the class
    [Header("Turret Attributes")]
    [HideInInspector]
    public static Turret instance;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private GameObject bullet;

    [Header("Turret Properties")]
    //[SerializeField]
    //private int totalLives = Constants.Turret.InitialTotalLives;
    [SerializeField]
    private int currentLives = Constants.Turret.InitialTotalLives;
    [SerializeField]
    private float viewDistance;
    public float fireRate;
    [SerializeField]
    private float fireForce;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private bool isBabyTurret = false;

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
        InvokeRepeating("UpdateTarget", 0.0f, Constants.Turret.UpdateTargetRate);
    }

    // Update is called once per frame
    void Update()
    {
        #region -- Lock next target and shoot --
        if (lockedOnTarget != null)
        {
            Vector2 targetPosition = lockedOnTarget.position;
            direction = targetPosition - (Vector2)this.transform.position;
            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, viewDistance);
            if (rayInfo)
            {
                if (rayInfo.collider.gameObject.tag == Constants.Tags.Unit)
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
        Gizmos.DrawWireSphere(this.transform.position, Constants.Turret.InnerRingGizmoRadio);
        Gizmos.color = Color.cyan;
        if (this.closestEnemyPosition != null)
        {
            Gizmos.DrawLine(this.transform.position, this.closestEnemyPosition);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.Tags.Unit);
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);

            if (this.isBabyTurret && distance <= Constants.Turret.BabyMinimumSafeDistance)
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

    public void ReceiveDamage(float attack)
    {
        this.currentLives -= Mathf.FloorToInt(attack);
        if (this.currentLives < 1)
        {
            Destroy(this.gameObject);
            if (!isBabyTurret)
            {
                Time.timeScale = 0;
                CustomSceneManager.instance.ChangeToMainMenuScene();
            }
        }
    }
}
