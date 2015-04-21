using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

// Data Object for users
public class User {

	[PrimaryKey, AutoIncrement]
	public int _id { get; set; }

	public string _userName { get; set; }

	public string _password { get; set; }

	// For debug only
	public override string ToString ()
	{
		return string.Format (
			"[User: _id={0}, _userName={1}, _password={2}]", 
			_id, _userName, _password
		);
	}
}
