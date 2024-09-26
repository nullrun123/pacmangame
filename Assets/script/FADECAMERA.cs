using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FADECAMERA : MonoBehaviour
{
    public Button fadeButton; // Reference to the UI Button
    public float speedScale = 1f;
    public Color fadeColor = Color.black;
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;
    public string nextSceneName = "NextScene"; // Scene name to load

    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    private void Start()
    {
        // Initialize the button onClick listener
        fadeButton.onClick.AddListener(OnFadeButtonPressed);

        if (startFadedOut) alpha = 1f; else alpha = 0f;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    private void Update()
    {
        // Update fade progress based on time and curve
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0f || alpha >= 1f) direction = 0;
        }
    }

    public void OnGUI()
    {
        if (alpha > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
    }

    public void OnFadeButtonPressed()
    {
        if (alpha >= 1f) // Fully faded out
        {
            alpha = 1f;
            time = 0f;
            direction = 1;
        }
        else // Fully faded in
        {
            alpha = 0f;
            time = 1f;
            direction = -1;
        }

        // Start coroutine to wait for 3 seconds before changing the scene
        StartCoroutine(WaitAndChangeScene());
    }

    private IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }
}
