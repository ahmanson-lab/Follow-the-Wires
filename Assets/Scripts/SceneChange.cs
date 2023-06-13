

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] Animator aimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            SceneManager.LoadScene(1);
            
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }



    public void ToNextScene()
    {
        StartCoroutine(LoadNextScene());

    }

    IEnumerator LoadNextScene()
    {
        if (aimator)
        {
            aimator.SetTrigger("Start");

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
