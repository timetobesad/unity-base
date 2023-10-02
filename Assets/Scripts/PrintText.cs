using System.Collections;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PrintText : MonoBehaviour
{
    public string pathToFile;
    public float delay;

    private string printText;

    public Rect textRect;
    public GUIStyle textStyle;

    private AudioSource audioSource;

    public AudioClip clipPrint;
    public AudioClip clipNewLine;
    public AudioClip clipEndPrint;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        if (File.Exists(pathToFile))
            StartCoroutine(printTextToDispay(File.ReadAllText(pathToFile), delay));
        else
            Debug.LogError(string.Format("Error upload text. File {0} not found", pathToFile));
    }

    private IEnumerator printTextToDispay(string text, float delay)
    {
        playClip(clipPrint, true);

        char[] letters = text.ToCharArray();

        foreach (char letter in letters)
        {
            printText = string.Format("{0}{1}", printText, letter);

            if (letter == '\r')
            {
                playClip(clipNewLine);
                yield return new WaitForSeconds(clipNewLine.length);
                playClip(clipPrint, true);
            }

            yield return new WaitForSeconds(delay);
        }

        playClip(clipEndPrint);
    }

    private void OnGUI()
    {
        GUI.Box(textRect, printText, textStyle);
    }

    private void playClip(AudioClip clip, bool isLopp = false)
    {
        audioSource.Stop();
        audioSource.loop = isLopp;

        audioSource.clip = clip;
        audioSource.Play();
    }
}
