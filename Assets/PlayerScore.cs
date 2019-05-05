
using UnityEngine;
 
//using UnityEditor;

using Models;
using UnityEngine.UI;
using Proyecto26;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PlayerScore : MonoBehaviour
{
  private readonly string dataBaseUrl = "https://securityappapi.herokuapp.com";
  //inputs
    
    public InputField emailText;
    public InputField passwordText;
    public InputField firstNameText;
    public InputField lastNameText;
    Users user = new Users();
   // Preguntas pregunta= new Preguntas();
  void Start()
  {
    
    //emailText.text=user.email;
    //email=emailText;
    //password=password;
    //passwordText.text=user.password;

   
  }
  private void ObtenerPreguntas(){

  }

   private void RetrieveFromDatabase()
    {
        RestClient.Get<Preguntas>(dataBaseUrl + "/preguntas").Then(response =>
            {
                //pregunta = response;
                
            });
    }
  public void loginUser()
  {
    string userData ="{\"email\":\"" + emailText.text + "\",\"password\":\"" + passwordText.text + "\"}";

    RestClient.Post<Users>(dataBaseUrl+"/users/login",userData).Then(
      response=>{

         user=response;
         //if(response.status.cod==1){
           
          //EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(user, true), "Ok"); 
		 
           //SceneManager.LoadScene ("ModuloScene");
         /*}else{
           EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(user, true), "Ok"); 
         }*/  
         
    }).Catch(error =>
        {
            Debug.Log(error);
        });

       if(user.cod==1){
         SceneManager.LoadScene ("ModuloScene");
       } 
  }

  public void registro()
  {
    string userData ="{\"email\":\"" + emailText.text + "\",\"password\":\"" + passwordText.text 
    + "\",\"firstName\":\"" + firstNameText.text
    + "\",\"lastName\":\"" + lastNameText.text+ "\"}";

    RestClient.Post<Users>(dataBaseUrl+"/users",userData).Then(
      response=>{
	      
		//EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(response, true), "Ok");
       
    }).Catch(error =>
        {
            Debug.Log(error);
        });
  }

  public void getUsers()
  {
   // string userData ="{\"email\":\"" + emailText + "\",\"password\":\"" + passwordText + "\"}";

    RestClient.GetArray<Users>(dataBaseUrl+"/users").Then(
      response=>{
         //playerName = response.firstName;
         // Debug.Log(playerName);
         
         //EditorUtility.DisplayDialog("Password: ",JsonHelper.ArrayToJsonString<Users>(response, true), "Ok");
         	
          
    }).Catch(error =>
        {
          //System.Diagnostics.Debug.WriteLine(error);
            Debug.Log(error);
        });
  }
//load Scenes
public void RegistroInfo()
	{
		SceneManager.LoadScene ("RegistroScene");
	}
public void LoginInfo()
	{
		SceneManager.LoadScene ("SampleScene");
	}


public void PassWordGame()
	{
		SceneManager.LoadScene ("PersonajeScene");
	}
  public void PassWordGameNivel01()
	{
		SceneManager.LoadScene ("Persistent");
	}

  public void PhisingGame()
	{
		SceneManager.LoadScene ("PersonajeScene");
	}
  public void Leonsito()
	{
		SceneManager.LoadScene ("PasswordScene");
	}
  public void Buho()
	{
		SceneManager.LoadScene ("PasswordScene");
	}
  public void Tigre()
	{
		SceneManager.LoadScene ("PasswordScene");
	}
}

