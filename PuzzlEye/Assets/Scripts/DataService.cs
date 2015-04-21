using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using SQLite4Unity3d;

public class DataService {

	private const bool DEBUG = true;

	private ISQLiteConnection _conn;

	public DataService(string dbName) {
		Factory factory = new Factory ();

#if UNITY_EDITOR
		string dbPath = string.Format ("Assets/StreamingAssets/{0}", dbName);
#else
		string filePath = string.Format ("{0}/{1}", Application.persistentDataPath, dbName);
		if (!File.Exists (filePath)) {
			Debug.Log ("Database not in persistent storage");

#if UNITY_ANDROID
			WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + dbName);
			while (!loadDB.isDone()) {}
			File.WriteAllBytes(loadDB, filePath);

#elif UNITY_IOS
			string loadDB = Application.dataPath + "/Raw/" + dbName;
			File.Copy(loadDB, filePath);

#elif UNITY_WP8
			string loadDB = Application.dataPath + "/StreamingAssets/" + dbName;
			File.Copy(loadDB, filePath);

#elif UNITY_WINRT
			string loadDB = Application.dataPath + "/StreamingAssets/" + dbName;
			File.Copy(loadDB, filePath);

#endif
			Debug.Log("Database Written");

		}

		string dbPath = filePath;
#endif

		_conn = factory.Create (dbPath);

		Debug.Log ("Final Path: " + dbPath);
	}

	public void createDB() {
		//dropTables ();
		createTables ();
	}

	private void dropTables() {
		_conn.DropTable<User> ();
		_conn.DropTable<UserScore> ();
	}

	private void createTables() {
		_conn.CreateTable<User> ();
		_conn.CreateTable<UserScore> ();

		if (DEBUG) {
			addDebugUsers();
			//addDebugUserScores();
		}
	}

	public User getUser(string userName) {
		return _conn.Table<User> ().Where (x => x._userName == userName).FirstOrDefault ();
	}

	public void addUser(string userName, string password) {
		_conn.Insert (new User { _userName = userName, _password = password });
	}

	public bool authorizeUser(string userName, string password) {
		User user = _conn.Table<User> ().Where (x => x._userName == userName).FirstOrDefault ();
		if (user == null)
			return false;

		if (user._password != password)
			return false;

		return true;
	}

	public IEnumerable<UserScore> getUserScores(string username) {
		return _conn.Table<UserScore> ().Where (x => x._userName == username);
	}

	public void addUserScore(string username, int timeTaken) {
		_conn.Insert (new UserScore {
			_userName = username,
			_completedAt = System.DateTime.Now,
			_timeTaken = timeTaken
		});
	}

	private void addDebugUsers() {
		_conn.InsertAll (new []{
			new User{
				_userName = "user1",
				_password = "123456"
			},
			new User{
				_userName = "test",
				_password = "test"
			},
			new User{
				_userName = "foo",
				_password = "bar"
			}
		});
	}

	private void addDebugUserScores() {
		_conn.InsertAll (new []{
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 190
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 6000
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 3098
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 3902
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 1039
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 8675
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 34025
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 48201
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 025802
			},
			new UserScore{
				_userName = "test",
				_completedAt = System.DateTime.Now,
				_timeTaken = 1004
			},
		});
	}
}
