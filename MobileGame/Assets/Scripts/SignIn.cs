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
    private static SignIn _instance;
    public static SignIn Instance { get { return _instance;  } }

    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TextMeshProUGUI status;

    [SerializeField] private Button playButton;

    FirebaseAuth auth;
    public string GetuserID { get { return auth.CurrentUser.UserId; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;
        });
    }
    // Start is called before the first frame update
    void Start()
    {

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

    public void PlayerDataLoaded()
    {
        //TODO: In final version we will load next scene directly

        //Activate the play button once we have logged in
        playButton.interactable = true;
    }
    public void DebugLogIn(int number)
    {
        SignInFirebase("test" + number + "@test.test", "password");
    }
}