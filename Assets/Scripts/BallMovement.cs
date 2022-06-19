using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BallMovement : MonoBehaviour
{
    ///private GameplayUIManager _gamePlayUIManager;
    ///public GameObject gamePlayUIManager_GO;
    
    private Rigidbody _rb;

    [Header("Player Movement")]
    [SerializeField] private int _score;
    [SerializeField] private int _speed;

    [Header("Timer")]
    [SerializeField] private float _timeLeft;
    [SerializeField] private bool _timerOn = false;
    [SerializeField] private Text _timertext;

    [Header("Instantiate")]
    [SerializeField] private GameObject _gameObjToInstantiate;

    private void Start()
    {
        //Both are attached on same gameobject
        _rb = GetComponent<Rigidbody>();
        ///_gamePlayUIManager = gamePlayUIManager_GO.GetComponent<GameplayUIManager>();
        

    }
    private void Update()
    {
        //Get the input and store it in var
        float  horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Add the force to the ball
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        _rb.AddForce(movement * _speed * Time.deltaTime, ForceMode.Impulse);

        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimer(_timeLeft);
            }
            else
            {
                Debug.Log("Timer is 0");
                _timeLeft = 0;
                _timerOn = false;
            }
        }

        if (horizontal > 0 || vertical > 0)
        {
            _timerOn = true;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate the purple cube
            Instantiate(_gameObjToInstantiate, GenerateRandomPos(), Quaternion.identity);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BT_A2");
        if(collision.gameObject.tag == "Wall")
        {
            Debug.Log("BT_A3");

            CameraManager.instance.CameraShake();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if tag is Pickable, then make the pickable disappear
        if (other.gameObject.tag == "PickableBlue")
        {
            other.gameObject.SetActive(false);
            AddScore(10);
            PickableProperties();
        }

        else if(other.gameObject.tag == "PickableYellow")
        {
            other.gameObject.SetActive(false);
            AddScore(20);
            PickableProperties();
        }

        else if(other.gameObject.tag == "PickableGreen")
        {
            other.gameObject.SetActive(false);
            AddScore(30);
            PickableProperties();
        }
    }

    public void PickableProperties()
    {
        GameplayUIManager.instance._scoreText.text = "Score : " + _score;

    }

    public void AddScore(int points)
    {
        _score += points;
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timertext.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private Vector3 GenerateRandomPos()
    {
        int x, y, z;

        x = Random.Range(-5, 5);
        y = 1;
        z = Random.Range(-5, 5);

        return new Vector3(x, y, z);
    }
}
