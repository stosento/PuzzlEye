using UnityEngine;
using System.Collections;
//using System.DateTime;
using SQLite4Unity3d;

// Data Object for user scores
public class UserScore {

	[PrimaryKey, AutoIncrement]
	public int _id { get; set; }

	public string _userName { get; set; }

	// the date the puzzle was completed
	public System.DateTime _completedAt { get; set; }

	// time taken to complete the puzzle
	public int _timeTaken { get; set; }

	public override string ToString ()
	{
		return string.Format (
			"[UserScore: _id={0}, _userName={1}, _completedAt{2}, _timeTaken={3}]",
			_id, _userName, _completedAt, _timeTaken
		);
	}
}
