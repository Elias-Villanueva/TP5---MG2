using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject QuitPanel;
    // Start is called before the first frame update
    void Start()
    {
        QuitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            AudioManager.instance.StopBgm();
            QuitPanel.SetActive(true);

        }
    }

    public void Return()
    {
        Time.timeScale = 1;
        AudioManager.instance.PlayBgm();
        QuitPanel.SetActive(false);
    }
}
