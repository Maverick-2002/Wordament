using UnityEngine;
using System.Runtime.InteropServices;

public class Firebase: MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void FetchWordsFromFirebase();

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            FetchWordsFromFirebase(); // Calls JS function in WebGL
#endif
    }

    // This function will be called when words are received
    public void OnWordsReceived(string words)
    {
        print("Received words from Firebase: " + words);
    }
}
