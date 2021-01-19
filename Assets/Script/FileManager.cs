using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
#if UNITY_STANDALONE_WIN
using AnotherFileBrowser.Windows;
#endif
using UnityEngine.Networking;

public class FileManager : MonoBehaviour
{
    string musicFilePath;

    public void MusicFileLoad()
    {
#if UNITY_STANDALONE_WIN
        var bp = new BrowserProperties();
        bp.filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
        bp.filterIndex = 0;

        new FileBrowser().OpenMultiSelectFileBrowser(bp, result =>
        {
            string s = "";
            for (int i = 0; i < result.Length; i++)
            {
                s += result[i] + "\n";
            }
            musicFilePath = s;

            StartCoroutine(MusicFileLoader());
            
        });
#endif
    }

    IEnumerator MusicFileLoader()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file:///" + musicFilePath, AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                MusicController.Instance.audioSource.clip = DownloadHandlerAudioClip.GetContent(www);
                EditManager.Instance.CreateRail();
            }
        }
    }
}
