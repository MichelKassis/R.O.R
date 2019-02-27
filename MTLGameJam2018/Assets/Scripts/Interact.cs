using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public Text dialogue1;
    public int levelNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showDialogue() {
        dialogue1.text = "Press Triangle/Y to talk";
    }
    void deleteDialogue()
    {
        dialogue1.text = " ";
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showDialogue();

            if (Input.GetButton("Interact"))
            {
                SceneManager.LoadScene(levelNumber);
            }

        }
        else {
            deleteDialogue();
        }

    }
}
