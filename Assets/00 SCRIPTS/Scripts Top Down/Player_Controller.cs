using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;
public class Player_Controller : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private float _maxTilt = .1f;
    [SerializeField] private float _tiltSpeed = 1;
    [SerializeField] float dashBoost = 8f;
    private float dashTime;
    [SerializeField] float DashTime;
    private bool once;

    public Vector3 moveInput;
    
    [SerializeField] GameObject damPopUp;
    [SerializeField] LosePanel losePanel;
    [Header("Turn/On GameObject")]
    [SerializeField] GameObject particle;
    [SerializeField] GameObject Skill;
    [SerializeField] GameObject Gun;
    [Header("Anim")]
    [SerializeField] SpriteRenderer Charater;
    [SerializeField] private GameObject anim;
    Animator _anim;

    private void Start()
    {
        _anim = anim.GetComponent<Animator>();
    }

    void Update()
    {
        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        
        moveInput.y = Input.GetAxisRaw("Vertical");
       
        transform.position += moveSpeed * Time.deltaTime * moveInput;
        // Flip the sprite
        // Lean while running
       
        if (moveInput.x != 0)  Charater.transform.localScale = new Vector3(moveInput.x! > 0 ? 1 : -1, 1, 1);
        var targetRotVector = new Vector3(0, 0, Mathf.Lerp(-_maxTilt, _maxTilt, Mathf.InverseLerp(-1, 1,moveInput.x)));
        _anim.transform.rotation = Quaternion.RotateTowards(_anim.transform.rotation, Quaternion.Euler(targetRotVector), _tiltSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && dashTime <= 0)
        {
            GameObject tmp = ObjectPoolingX.instant.GetObject(particle);
            tmp.SetActive(true);
            tmp.transform.position = this.transform.position;
            tmp.transform.rotation = this.transform.rotation;
            tmp.transform.SetParent(this.transform);
            Gun.SetActive(false);
            Skill.SetActive(true);
            _anim.SetInteger("state", 1);
            moveSpeed += dashBoost;
            dashTime = DashTime;
            once = true;
        }

        if (dashTime <= 0 && once)
        {
            Gun.SetActive(true);
            Skill.SetActive(false);
           _anim.SetInteger("state",0);
            moveSpeed -= dashBoost;
            once = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }

        // Rotate Face
       
    }
 

    public void TakeDamageEffect(int damage)
    {
        if (damPopUp != null)
        {
            GameObject instance = Instantiate(damPopUp, transform.position
                    + new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), 0.5f, 0), Quaternion.identity);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Animator animator = instance.GetComponentInChildren<Animator>();
            animator.Play("red");
        }
        if (GetComponent<Health>().isDead)
        {
            losePanel.Show();
        }
    }
   
}
