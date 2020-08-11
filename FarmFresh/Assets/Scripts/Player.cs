using System;
using UnityEngine;

//using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public float moveSpeed = 6.5f;
    public GameObject tombstone;

    // State
    bool isAlive = true;
    
    // Cached component references
    Rigidbody2D myRigidBody;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        GameEvents.playerDeath.AddListener(Dying);
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            Run();
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }        
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // value is betweeen -1 to +1

        // convert user input into world movement
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        //assign movement to a single vector3
        Vector3 directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);

        animator.SetFloat("HorizontalSpeed", horizontalMovement * 100);
        animator.SetFloat("VerticalSpeed", verticalMovement * 100);

        //myAnimator.SetBool("IsIdle", Convert.ToBoolean(horizontalMovement + verticalMovement));

        if (horizontalMovement == 0 && verticalMovement == 0)
        {
            animator.SetBool("IsIdle", true);
        }
        else
        {
            animator.SetBool("IsIdle", false);
        }

        // apply movement to player's transform
        gameObject.transform.Translate(directionOfMovement);
        GameEvents.playerLocation?.Invoke(gameObject.transform.position);
    }


    private void Dying()
    {
        isAlive = false;
        // We want to display a tombstone where we die.
        tombstone = Instantiate(tombstone, gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }



}
