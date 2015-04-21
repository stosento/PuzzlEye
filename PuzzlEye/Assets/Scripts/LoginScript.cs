using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour {

	[SerializeField] private InputField _username;
	[SerializeField] private InputField _password;
	[SerializeField] public Text _failText;

	private DataService _db;
	
	public static string _curUser = "";

	// Use this for initialization
	void Start () {
		_failText.enabled = false;
		_curUser = "";
		_db = new DataService ("PuzzlEye.db");
		_db.createDB ();
	}

	public void Login() {
		Debug.Log ("Username: " + _username.text);
		Debug.Log ("Password: " + _password.text);
		Debug.Log ("curUser: " + _curUser);

		if (!_db.authorizeUser (_username.text, _password.text)) {
			Debug.Log ("Login Failed!!!!");
			_failText.enabled = true;
		} else {
			Debug.Log ("Login Success!!!" );
			_curUser = _username.text;
			Application.LoadLevel(0);
		}
	}

	public void CreateAccount() {
		_db.addUser (_username.text, _password.text);
		_curUser = _username.text;
		Application.LoadLevel (0);
	}
}
