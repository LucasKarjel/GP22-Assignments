using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Auth;
using Firebase;
using Firebase.Extensions;

public class SignIn : MonoBehaviour
{
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TextMeshProUGUI status;

    [SerializeField] private Button playButton;

    FirebaseAuth auth;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;
        });
    }

    public void SignInButton()
    {
        SignInFirebase(email.text, password.text);
    }

    private void SignInFirebase(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);
                status.text = newUser.Email + "is signed in";

                playButton.interactable = true;
            }
        });
    }

    public void RegisterButton()
    {
        RegisterNewUser(email.text, password.text);
    }

    private void RegisterNewUser(string email, string password)
    {
        Debug.Log("Starting Registration");
        status.text = "Starting Registration";
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User Registerd: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);

                playButton.interactable = true;
            }
        });
    }

    public void DebugLogIn(int number)
    {
        SignInFirebase("test" + number + "@test.test", "password");
    }
}