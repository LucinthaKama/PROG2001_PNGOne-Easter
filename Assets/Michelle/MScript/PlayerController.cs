using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    private Rigidbody rb;

    private float mX;
    private float mY;

    public float speed = 0;

    public TextMeshProUGUI countText;

    private float count;

    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(mX, 0.0f, mY);

        rb.AddForce(movement * speed);
    }
    void Update()
    {
        bool forward = Input.GetKey("w");

        if (forward)
        {
            animator.SetBool("isWalking", true);
        }
        if (!forward)
        {
            animator.SetBool("isWalking", false);
        }
    }
    
    public void OnMove(InputValue mV)
    {
        Vector2 vector2 = mV.Get<Vector2>();

        mX = vector2.x;
        mY = vector2.y;
    }
    
    public void OnTriggerEnter(Collider other)
    {
    
       if (other.gameObject.CompareTag("PickUp"))
       {
           other.gameObject.SetActive(false);
                count += 1;

                SetCountText();
       }
    }

    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        CheckScore();
    }
    
    public void CheckScore()
    {
        if (count >= 10)
            {
                winPanel.SetActive(true);

            }
        }
    }

        