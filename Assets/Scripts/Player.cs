using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject player;
    public bool isGrounded;
    private bool turnLeft, turnRight;
   [SerializeField] private float speed;
   [SerializeField] private float jump ;
   [SerializeField] private int coins;
   [SerializeField] private GameObject losePanel;
    public Rigidbody rb;
    private CharacterController myCharacterController;
   
    private float maxSpeed = 10;
    void Start()
    {
        player = (GameObject)this.gameObject;
        myCharacterController = GetComponent<CharacterController>();
        StartCoroutine(SpeedIncrease());
        coins = PlayerPrefs.GetInt("coins");
    }
     
 
    void Update()
    {
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);

        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));

        myCharacterController.SimpleMove(new Vector3(0f,0f,0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
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
