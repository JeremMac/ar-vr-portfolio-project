using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;

public class LoginPagePlayfab : MonoBehaviour
{
    [SerializeField] Text TopText;
    [SerializeField] Text MessageText;

    [Header("Login")]
    [SerializeField] Text EmailLoginInput;
    [SerializeField] Text PasswordLoginput;
    [SerializeField] GameObject LoginPage;

    [Header("Register")]
    [SerializeField] Text UsernameRegisterInput;
    [SerializeField] Text EmailRegisterInput;
    [SerializeField] Text PasswordRegisterinput;
    [SerializeField] GameObject RegisterPage;

    [Header("Recovery")]
    [SerializeField] Text EmailRecoveryInput;
    [SerializeField] GameObject RecoveryPage;


    #region Button Functions

    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterinput.text,

            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnregisterSucces, OnError);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLoginInput.text,
            Password = PasswordLoginput.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnloginSucces, OnError);
    }

    private void OnloginSucces(LoginResult result)
    {
        MessageText.text = "Loggin in";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RecoveryUser()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailRecoveryInput.text,
            TitleId = "A5659",
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySucces, OnError);
    }

    private void OnRecoverySucces(SendAccountRecoveryEmailResult result)
    {
        OpenLoginPage();
        MessageText.text = "Recovery Mail Sent";
    }

    private void OnError(PlayFabError error)
    {
        MessageText.text = error.ErrorMessage;
    }

    private void OnregisterSucces(RegisterPlayFabUserResult result)
    {
        MessageText.text = "New account is created";
        OpenLoginPage();
    }

    public void OpenLoginPage()
    {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(false);
        TopText.text = "Login";
    }

    public void OpenRegisterPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        RecoveryPage.SetActive(false);
    }

    public void OpenRecoveryPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(true);
    }

    #endregion
}