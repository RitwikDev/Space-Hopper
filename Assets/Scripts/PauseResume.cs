using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResume : MonoBehaviour
{
    private int state;
    public Button button;
    public Sprite resume, pause;
    // Start is called before the first frame update
    void Start()
    {
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseOrResumeGame()
    {
        if(state == 1)
        {
            Time.timeScale = 0;
            state = 0;
            button.GetComponent<Image>().sprite = resume;
        }

        else
        {
            Time.timeScale = 1;
            state = 1;
            button.GetComponent<Image>().sprite = pause;
        }
    }
}
