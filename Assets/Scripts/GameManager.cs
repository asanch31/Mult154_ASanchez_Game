using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject ammoBoxPrefab;
   


    
    public bool gamePause = false;
    private PlayerHealth gameOver;

    public AudioSource AudioPlayer;

    //supply drop timer
    public Image supplyDropTimer;
    public GameObject collectTimer;
    
    //how long to call for ammo
    float time = 0;
    private float maxTime = 3;
    //was drop called
    public bool supplyDropped = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver= GameObject.Find("Player").GetComponent<PlayerHealth>();
        AudioPlayer = GetComponent<AudioSource>();

        pauseMenu.SetActive(false);
        
        collectTimer.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        Health();
        Pause();
        //display pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            gamePause = true;
            Pause();
        }

        //call for supply drop (ammo and grenade)
        if (Input.GetKey(KeyCode.R) && gameOver.gameOver == false)
        {
            SupplyDropCall();
            

        }
        else
        {
            resetTimer();
        }
    }

    void Health()
    {
        //if player dies display end scene
        if(gameOver.gameOver==true)
        {
            SceneManager.LoadScene(2);

        }
       
    }
    //bring up menu, pausing game
    void Pause()
    {   //if quit game is click load end scene
        if (gameOver.gameOver==true)
        {
            SceneManager.LoadScene(2);
        }
        //display pause menu
        if (gamePause == true)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            
        }
    }
  //deactivate pause menu
    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);

        gamePause = false;

    }

   
    //supply drop method
    void SupplyDropCall()
    {
        
        collectTimer.SetActive(true);

        InvokeRepeating("DropSupply", 1, 1);

        if (supplyDropped == true)
        {

            
            resetTimer();
            Instantiate(ammoBoxPrefab, new Vector3(0,5,0), transform.rotation);
        }
    }
    //call Drop Supply
    public void DropSupply()
    {
        
        //keep track of time while interacting with object(rock sample)
        if (time < maxTime)
        {
            time++;
            //fill timer wheel
            supplyDropTimer.fillAmount = time / maxTime;
        }
        if (time == maxTime)
        {

            // was sample collected 
            supplyDropped = true;

        }
        else
        {
            // Stops all repeating invokes
            //if player moves away from object cancel repeating function, stopping timer

            CancelInvoke();
        }

    }

    //reset timer for supply drop
    private void resetTimer()
    {
        time = 0;
        supplyDropped = false;
        collectTimer.SetActive(false);
    }
}
