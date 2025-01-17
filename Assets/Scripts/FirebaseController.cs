using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class FirebaseController : MonoBehaviour
{
    public GameObject loginPanel, signupPanel, profilePanel, forgetPasswordPanel , notificationPanel;
    public InputField loginEmail, loginPassword, signupEmail, signupPassword , signupCPassword, signupUserName, forgetPassEmail;
    public Text notif_Title_Text, notif_Message_Text, profilUserName_Text, profileUserEmail_Text;
    public Toggle rememberMe;

    // A method that will activate the login interface.
    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
    }

    // A method that will activate the register interface.
    public void OpenSignUpPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(false);
    }

    // A method that will activate the profile interface.
    public void OpenProfilePanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(true);
        forgetPasswordPanel.SetActive(false);
    }

    public void OpenForgetPassPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        profilePanel.SetActive(false);
        forgetPasswordPanel.SetActive(true);
    }

    // A method that sets the login conditions
    public void LoginUser()
    {
        if (string.IsNullOrEmpty(loginEmail.text) && string.IsNullOrEmpty(loginPassword.text))
        {
            ShowNotificationMessage("ERROR", "Fields empty! please fill all informations");
            return;
        }
        // do login
    }

    public void SignupUser()
    {
        if (string.IsNullOrEmpty(signupEmail.text) && string.IsNullOrEmpty (signupPassword.text) && string.IsNullOrEmpty(signupCPassword.text) && string.IsNullOrEmpty(signupUserName.text))    
        {
            ShowNotificationMessage("ERROR", "Fields empty! please fill all informations");
            return;
        }
    }

    public void ForgetPass()
    {
        if (string.IsNullOrEmpty(forgetPassEmail.text))
        {
            ShowNotificationMessage("ERROR", "Forget Email empty");
            return;
        }
    }

    private void ShowNotificationMessage(string title, string message)
    {
        notif_Title_Text.text = "" + title;
        notif_Message_Text.text = "" + message;

        notificationPanel.SetActive(true);
    }

    public void CloseNotif_Panel()
    {
        notif_Title_Text.text = "";
        notif_Message_Text.text = "";
        notificationPanel.SetActive(false);
    }

    public void LogOut()
    {
        profileUserEmail_Text.text = "";
        profilUserName_Text.text = "";
        OpenLoginPanel();
    }
}
