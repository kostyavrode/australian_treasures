using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using Newtonsoft.Json;

public class FirebaseRemoteConfigManager : MonoBehaviour
{
    // Ключ для параметра в Remote Config
    private const string ClubsKey = "clubs";
    private const string TourKey = "tour";

    private List<string> clubsList = new List<string>();

    void Start()
    {
        // Инициализация Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                InitializeRemoteConfig();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + task.Result);
            }
        });
    }

    private void InitializeRemoteConfig()
    {
        // Получаем экземпляр RemoteConfig
        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;

        // Устанавливаем значения по умолчанию (на случай, если Remote Config недоступен)
        var defaults = new Dictionary<string, object>
        {
            { ClubsKey, "[]"}, { TourKey, "[]" }
        };

        remoteConfig.SetDefaultsAsync(defaults).ContinueWithOnMainThread(task =>
        {
            // Загружаем данные с сервера
            FetchRemoteConfig();
        });
    }

    private void FetchRemoteConfig()
    {
        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;

        // Загружаем данные с сервера
        remoteConfig.FetchAsync(TimeSpan.Zero).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                // Активируем загруженные данные
                remoteConfig.ActivateAsync().ContinueWithOnMainThread(activateTask =>
                {
                    // Получаем данные
                    GetClubsData();
                });
            }
            else
            {
                Debug.LogError("Failed to fetch Remote Config");
            }
        });
    }

    private void GetClubsData()
    {
        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;

        // Получаем значение по ключу
        string clubsJson = remoteConfig.GetValue(ClubsKey).StringValue;
        string tour=remoteConfig.GetValue(TourKey).StringValue;
        Debug.Log(clubsJson);
        Debug.Log(tour);


        try
        {
            // Парсим JSON в массив строк
            //clubsList = JsonUtility.FromJson<ClubsData>(clubsJson).clubs;
            List<string> clubList = JsonConvert.DeserializeObject<List<string>>(clubsJson);

            // Выводим данные в лог
            foreach (var club in clubsList)
            {
                Debug.Log("Club: " + club);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to parse clubs data: " + e.Message);
        }
    }

    // Класс для десериализации JSON
    [Serializable]
    private class ClubsData
    {
        public List<string> clubs;
    }
}