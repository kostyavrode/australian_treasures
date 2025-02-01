using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using Newtonsoft.Json;

public class FirebaseRemoteConfigManager : MonoBehaviour
{
    // ���� ��� ��������� � Remote Config
    private const string ClubsKey = "clubs";
    private const string TourKey = "tour";

    private List<string> clubsList = new List<string>();

    void Start()
    {
        // ������������� Firebase
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
        // �������� ��������� RemoteConfig
        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;

        // ������������� �������� �� ��������� (�� ������, ���� Remote Config ����������)
        var defaults = new Dictionary<string, object>
        {
            { ClubsKey, "[]"}, { TourKey, "[]" }
        };

        remoteConfig.SetDefaultsAsync(defaults).ContinueWithOnMainThread(task =>
        {
            // ��������� ������ � �������
            FetchRemoteConfig();
        });
    }

    private void FetchRemoteConfig()
    {
        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;

        // ��������� ������ � �������
        remoteConfig.FetchAsync(TimeSpan.Zero).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                // ���������� ����������� ������
                remoteConfig.ActivateAsync().ContinueWithOnMainThread(activateTask =>
                {
                    // �������� ������
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

        // �������� �������� �� �����
        string clubsJson = remoteConfig.GetValue(ClubsKey).StringValue;
        string tour=remoteConfig.GetValue(TourKey).StringValue;
        Debug.Log(clubsJson);
        Debug.Log(tour);


        try
        {
            // ������ JSON � ������ �����
            //clubsList = JsonUtility.FromJson<ClubsData>(clubsJson).clubs;
            List<string> clubList = JsonConvert.DeserializeObject<List<string>>(clubsJson);

            // ������� ������ � ���
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

    // ����� ��� �������������� JSON
    [Serializable]
    private class ClubsData
    {
        public List<string> clubs;
    }
}