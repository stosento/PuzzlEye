using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[System.Serializable]
public class Item {
	public string username;
	public string date;
	public string score;
}

public class CreateScrollList : MonoBehaviour {

	public GameObject sampleButton;
	public List<Item> items;

	public Transform contentPanel;

	private DataService _db;

	void Start () {
		_db = new DataService ("PuzzlEye.db");
		PopulateList ();
	}

	void PopulateList () {
		IEnumerable<UserScore> scores = _db.getUserScores (LoginScript._curUser);
		foreach (UserScore score in scores) {
			GameObject newButton = Instantiate (sampleButton) as GameObject;
			ScoreListItem listItem = newButton.GetComponent<ScoreListItem> ();
			listItem.usernameLabel.text = score._userName;
			listItem.dateLabel.text = score._completedAt.ToString();

			int minutes = score._timeTaken / 60;
			int seconds = score._timeTaken % 60;
			listItem.scoreLabel.text = minutes + ":" + ((seconds < 10) ? ("0" + seconds) : (seconds + ""));
			newButton.transform.SetParent (contentPanel);
		}
	}
}
