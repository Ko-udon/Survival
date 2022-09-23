using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System;
using UnityEngine;

public class DataSaveLoad : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataSaveLoad _instance;
    public static DataSaveLoad Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataSaveLoad)) as DataSaveLoad;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    public string GameDataFileName = "Data.json";

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                /*LoadGameData();
                SaveGameData();*/
            }
            return _gameData;
        }
    }

    void Start()
    {
        
    }

    public void LoadGameManagerData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if (File.Exists(filePath))
        {
            Debug.Log("불러오기 성공");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);

            GameManager.gameManager.viewedTutorial = _gameData.viewedTutorial;
            GameManager.gameManager.lastStage = _gameData.stage;
            GameManager.gameManager.lastCharacter = _gameData.characterType;
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
        }
    }

    public void LoadPlayerData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
        PlayerController player = FindObjectOfType<PlayerController>();

        if (File.Exists(filePath))
        {
            Debug.Log("불러오기 성공");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);

            player.hp = _gameData.hp;
            player.Level = _gameData.level;
            player.exp = _gameData.exp;

            LoadSkill();
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        gameData.viewedTutorial = GameManager.gameManager.viewedTutorial;
        gameData.stage = GameManager.gameManager.lastStage;
        gameData.characterType = GameManager.gameManager.lastCharacter;

        gameData.hp = player.hp;
        gameData.level = player.Level;
        gameData.exp = player.exp;

        gameData.ownSkill = player.ownSkill;
        gameData.ballLV = player.ballLV;
        gameData.knockbackLV = player.knockbackLV;
        gameData.tauntLV = player.tauntLV;
        gameData.nautilusLV = player.nautilusLV;
        gameData.virusLV = player.virusLV;

        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);
    }

    private void LoadSkill()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        player.ballLV = 0;
        player.knockbackLV = 0;
        player.tauntLV = 0;
        player.nautilusLV = 0;
        player.virusLV = 0;

        player.ownSkill.Clear();
        foreach (string skill in _gameData.ownSkill)
        {
            switch (skill)
            {
                case "Ball":
                    for(int i = 0; i < _gameData.ballLV; i++)
                    {
                        player.GetSkill(skill);
                    }
                    break;

                case "KnockBack":
                    for (int i = 0; i < _gameData.knockbackLV; i++)
                    {
                        player.GetSkill(skill);
                    }
                    break;

                case "Taunt":
                    for (int i = 0; i < _gameData.tauntLV; i++)
                    {
                        player.GetSkill(skill);
                    }
                    break;

                case "Nautilus":
                    for (int i = 0; i < _gameData.nautilusLV; i++)
                    {
                        player.GetSkill(skill);
                    }
                    break;

                case "Virus":
                    for (int i = 0; i < _gameData.virusLV; i++)
                    {
                        player.GetSkill(skill);
                    }
                    break;

                default:
                    break;
            }
        }
    }

    void Update()
    {
        
    }
}
