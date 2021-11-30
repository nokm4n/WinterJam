using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;

public class RoomPlacer : MonoBehaviour
{
	public Room[] RoomPrefabs;
	public Room StartRoom;
	public float sizeRoom = 0f;
	private Room[,] spawnedRooms;
	private string path = "./"; // путь к файлу
	public string nameFile = "count.txt"; // название файла 

	void Start()
	{
		StreamWriter sw = new StreamWriter(path + "/" + nameFile); // создаём файл
		sw.WriteLine(0); // записываем в файл строку
		sw.Close(); // закрываем файл

		sizeRoom = StartRoom.gameObject.transform.localScale.x;
		spawnedRooms = new Room[20, 20];
		spawnedRooms[0, 0] = StartRoom;

		for (int i = 0; i < 20; i++)
		{
			PlaceRoom();
		}
/*
		for(int i=0; i<spawnedRooms.Length; i++)
		{
			/*if(spawnedRooms[i, 0].transform.childCount>0)
			{

			}*
		}*/
	}

	void PlaceRoom()
	{
		HashSet<Vector2Int> vacantPlaced = new HashSet<Vector2Int>();
		for (int x = 0; x < spawnedRooms.GetLength(0); x++)
		{
			for (int y = 0; y < spawnedRooms.GetLength(1); y++)
			{
				if (spawnedRooms[x, y] == null) continue;

				int maxX = spawnedRooms.GetLength(0) - 1;
				int maxY = spawnedRooms.GetLength(1) - 1;

				if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaced.Add(new Vector2Int(x - 1, y));
				if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaced.Add(new Vector2Int(x, y - 1));
				if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaced.Add(new Vector2Int(x + 1, y));
				if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaced.Add(new Vector2Int(x, y + 1));
			}
		}
		int limit = 500;

		Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);

		while (limit-- > 0)
		{
			Vector2Int position = vacantPlaced.ElementAt(Random.Range(0, vacantPlaced.Count));
			if (ConnectToSmth(newRoom, position))
			{
				newRoom.transform.position = new Vector3(position.x, 0, position.y) * 10*sizeRoom;
				spawnedRooms[position.x, position.y] = newRoom;
				return;
			}
		}

		Destroy(newRoom.gameObject);

	}

	bool ConnectToSmth(Room room, Vector2Int place)
	{
		int maxX = spawnedRooms.GetLength(0) - 1;
		int maxY = spawnedRooms.GetLength(1) - 1;

		List<Vector2Int> neighbours = new List<Vector2Int>();

		if (room.DoorU != null && place.y < maxY && spawnedRooms[place.x, place.y + 1]?.DoorD != null) neighbours.Add(Vector2Int.up);
		if (room.DoorD != null && place.y > 0 && spawnedRooms[place.x, place.y - 1]?.DoorU != null) neighbours.Add(Vector2Int.down);
		if (room.DoorR != null && place.x < maxX && spawnedRooms[place.x + 1, place.y]?.DoorL != null) neighbours.Add(Vector2Int.right);
		if (room.DoorL != null && place.x > 0 && spawnedRooms[place.x - 1, place.y]?.DoorR != null) neighbours.Add(Vector2Int.left);

		if (neighbours.Count == 0) return false;

		Vector2Int selectedDir = neighbours[Random.Range(0, neighbours.Count)];
		Room selectedRoom = spawnedRooms[place.x + selectedDir.x, place.y + selectedDir.y];

		//if (room.enemy == null)
		{
			if (selectedDir == Vector2Int.up)
			{
				Destroy(room.DoorU);
				Destroy(selectedRoom.DoorD);
			//	selectedRoom.DoorD.SetActive(false);
			}
			else if (selectedDir == Vector2Int.down)
			{
				Destroy(room.DoorD);
				Destroy(selectedRoom.DoorU);
				//room.DoorD.SetActive(false);
				//selectedRoom.DoorU.SetActive(false);
			}
			else if (selectedDir == Vector2Int.right)
			{
				Destroy(room.DoorR);
				Destroy(selectedRoom.DoorL);
				//room.DoorR.SetActive(false);
				//selectedRoom.DoorL.SetActive(false);
			}
			else if (selectedDir == Vector2Int.left)
			{
				Destroy(room.DoorL);
				Destroy(selectedRoom.DoorR);
				//room.DoorL.SetActive(false);
				//selectedRoom.DoorR.SetActive(false);
			}
		}

		return true;
	}

}
// Update is called once per frame

