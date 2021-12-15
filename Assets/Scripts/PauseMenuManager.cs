using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{

    //control volume menu
    public GameObject pausePanel;
    private bool activePanel = false;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);

        float value = PlayerPrefs.GetFloat(AudioManager.VOLUME_LEVEL_KEY, AudioManager.DEFAULT_VOLUME);        
        pausePanel.GetComponentInChildren<Slider>().value = value;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //press "v" to (de)activate volume menu
        if(Input.GetKeyDown(KeyCode.V) && activePanel==false)
        {
            activePanel = true;
            pausePanel.SetActive(true);
            
        }
        else if (Input.GetKeyDown(KeyCode.V) && activePanel == true)
        {
            activePanel = false;
            pausePanel.SetActive(false);

        }

    }



    


}
