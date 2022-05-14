using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //var

    public int playerCharacterType;
    public Dictionary<string, bool> characterDic = new Dictionary<string, bool>() { {"Earth",false },{"Fire",true }, { "Water", false }
    ,{"Light",false },{"Dark",false }};

    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;

        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
