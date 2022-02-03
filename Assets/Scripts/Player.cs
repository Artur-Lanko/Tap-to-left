using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 


public class Player : MonoBehaviour/*, IBeginDragHandler, IDragHandler*/
{
    public GameObject player;
    public bool isGrounded;
    public Rigidbody rb;

    private bool turnLeft, turnRight,turnUp;
    private Animator anim;
    private CharacterController myCharacterController;
    private float maxSpeed = 10;

   [SerializeField] private float speed;
   [SerializeField] private float jump ;
   [SerializeField] private int coins;
   [SerializeField] private GameObject losePanel;
   
    void Start()
    {
        player = (GameObject)this.gameObject;
        myCharacterController = GetComponent<CharacterController>();
        StartCoroutine(SpeedIncrease());
        coins = PlayerPrefs.GetInt("coins");
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        turnUp = Input.GetKeyDown(KeyCode.W);


        //if (Input.touchCount > 0)
        //{
        //    Touch meTouch = Input.GetTouch(0);
        //    if (meTouch.phase == TouchPhase.Began)
        //    {
        //    }

        //}


        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (gameObject.tag == "Left")
        //    {
        //        transform.Rotate(new Vector3(0f, -90f, 0f));

        //    }

        //}


        if (turnLeft)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        if (turnRight)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }

        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);

        if (turnUp)
        {
            player.transform.position += player.transform.up * jump * Time.deltaTime;
        }


        if (transform.position.y < 1)
        {
           
            losePanel.SetActive(true);
           
        }

        if (transform.position.y > 4)
        {
            losePanel.SetActive(true);
        }
    }

    
    


    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (other.gameObject.tag == "Left")
            {
                transform.Rotate(new Vector3(0f, -90f, 0f));
            }
            else if(other.gameObject.tag == "Right")
            {
                transform.Rotate(new Vector3(0f, 90f, 0f));
            }
            else if(other.gameObject.tag == "Up")
            {
                player.transform.position += player.transform.up * jump * Time.deltaTime;
                //anim.SetTrigger("Jump");
            }
        }

        if (other.gameObject.tag == "Coin")
        {
            coins++;
            PlayerPrefs.SetInt("coins",coins);
            //coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }
    }

    private IEnumerator SpeedIncrease()
    {
        if(speed < maxSpeed)
        {
        yield return new WaitForSeconds(5);
        speed += 1;
        StartCoroutine(SpeedIncrease());
        }
    }

  
}
