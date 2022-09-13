using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     // A reference to the Rigidbody component 
    public Transform player;
    private Rigidbody rb;
    
    [Tooltip("How fast the ball moves left/right")]
    [Range(0, 10)]
    public float dodgeSpeed = 1.5f;
    
    [Tooltip("How fast the ball moves forwards automatically")]
    [Range(0, 30)]
    public float rollSpeed = 5;
    private float _leftSide = -1.5f;
    private float _rightSide = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Get access to our Rigidbody component 
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// FixedUpdate is called at a fixed framerate and is a prime place to put
    /// Anything based on time.
    /// </summary>
    private void FixedUpdate()
    {
        // Check if we're moving to the side 
        transform.Translate(Vector3.forward * Time.deltaTime * rollSpeed, Space.World);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(this.gameObject.transform.position.x < _rightSide)
            {
                transform.position = transform.position + new Vector3(1.5f, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (this.gameObject.transform.position.x > _leftSide)
            {
                transform.position = transform.position + new Vector3(-1.5f, 0, 0);
            }
        }
    }
}