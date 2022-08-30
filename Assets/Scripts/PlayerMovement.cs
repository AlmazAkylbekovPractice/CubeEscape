using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody _playerBody;
    [SerializeField] private float speed = 1500f;
    [SerializeField] private float sideSpeed = 1000f;

    [SerializeField] private Vector3 _impulseForce = new Vector3(0,200f,0);
    [SerializeField] private Vector3 _obstacleImpulse = new Vector3(0,0,-1500f);

    [SerializeField] private ParticleSystem _collisionParticle;

    private bool isGrounded;
    private bool doubleJump;

    private bool justJumped;

    void Start()
    {
        _playerBody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetJumpCommand();
    }

    void FixedUpdate()
    {
        MoveCube();
        CubeJump();
    }

    private void MoveCube()
    {

        _playerBody.AddForce(0, 0, speed * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            _playerBody.AddForce(sideSpeed*Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            _playerBody.AddForce(-sideSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void GetJumpCommand()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            justJumped = true;
        }
    }

    private void CubeJump()
    {
        if (justJumped)
        {
            if (isGrounded)
            {
                _playerBody.AddForce(_impulseForce * Time.deltaTime, ForceMode.Impulse);
                isGrounded = false;
                doubleJump = true;
            }
            else if (doubleJump && !isGrounded)
            {
                _playerBody.AddForce(_impulseForce * Time.deltaTime, ForceMode.Impulse);
                doubleJump = false;
            }

            justJumped = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            var collisionExplosion = Instantiate(_collisionParticle, transform.position,Quaternion.identity);
            collisionExplosion.Play();

            _playerBody.AddForce(_obstacleImpulse*Time.deltaTime, ForceMode.Impulse);

        }

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
