using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "title screen")
        {
            Destroy(gameObject);
        }
    }

}
