using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject FireEffect;
    //public GameObject muzzle;
    public Transform FirePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    private float timeBtwFire;
    Rigidbody rb;

    void Start()
    {
        if (FirePos == null)
        {
            Debug.LogError("FirePos is not assigned");
        }
    }
    void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeBtwFire <0)
        {
            FireBullet();
        }
    }
    void RotateGun()
    {
        Vector3 mousesPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousesPos - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg;

        quaternion rotation = Quaternion.Euler(0, 0, angle);
        this.transform.rotation = rotation;


        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        GameObject tmpBullet = ObjectPoolingX.instant.GetObject(Bullet);
        tmpBullet.gameObject.SetActive(true);
        tmpBullet.transform.position = FirePos.transform.position;
        tmpBullet.transform.rotation = FirePos.transform.rotation;
        Rigidbody2D rb = tmpBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        GameObject tmpFire = ObjectPoolingX.instant.GetObject(FireEffect);
        tmpFire.gameObject.SetActive(true);
        tmpFire.transform.position = FirePos.transform.position;
        tmpFire.transform.rotation = FirePos.transform.rotation;
        //Instantiate(muzzle, FirePos.position, transform.rotation, transform);
        AudioController.Instant.playSound("Gun");
        

    }
}
