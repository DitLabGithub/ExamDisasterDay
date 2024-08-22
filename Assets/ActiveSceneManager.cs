using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UserInterface;

public class ActiveSceneManager : MonoBehaviour
{

    private GameObject uiParent;
    private Transform environmentParent;

    public Sprite background;
    public GameObject backgroundPrefab;

    public GameObject uiBackground;
    public GameObject currentScene;
    public GameObject nextScene;

    private void Start() {
        uiParent = GameObject.FindGameObjectWithTag("UI").transform.parent.gameObject;
        environmentParent = uiParent.transform.GetChild(0);
    }

    public void NextScene(GameObject newScene) {
        //uiBackground.GetComponent<Image>().sprite = background;
        currentScene.SetActive(false);
        currentScene = Instantiate(newScene, environmentParent);
        nextScene = null;
    }


}
