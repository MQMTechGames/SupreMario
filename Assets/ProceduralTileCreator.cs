using UnityEngine;
using System.Collections.Generic;

public class ProceduralTileCreator : MonoBehaviour
{
	[SerializeField]
	List<GameObject> _tilePrefabs;

	[SerializeField]
	float _tileXSize = 1.0f;

	[SerializeField]
	float _minYOffset = 0f;

	[SerializeField]
	float _maxYOffset = 10f;

	[SerializeField]
	float _requiredDistanceToCreateTileMin = 2f;

	[SerializeField]
	float _requiredDistanceToCreateTileMax = 5f;

	[SerializeField]
	int _minTileSize = 5;

	[SerializeField]
	int _maxTileSize = 10;

	Vector3 _lastCreatedPosition;

	Vector3 _referencePosition;

	void Awake()
	{
		_referencePosition = transform.position;
		_lastCreatedPosition = transform.position;
	}

	void Update()	
	{
		float distanceToLastCreatedPos = transform.position.x - _lastCreatedPosition.x;
		float requiredDistanceToCreateTile = Random.Range (_requiredDistanceToCreateTileMin, _requiredDistanceToCreateTileMax);

		if (distanceToLastCreatedPos > requiredDistanceToCreateTile)
		{
			int tileIdx = Random.Range(0, _tilePrefabs.Count);
			Vector3 position = CalculatePosition();
			int tileSize = CalculateTileSize();

			InstantiateTiles(_tilePrefabs[tileIdx], position, tileSize);
		}
	}

	void InstantiateTiles(GameObject prefab, Vector3 position, int tileSize)
	{
		_lastCreatedPosition = position;

		for (int i = 0; i < tileSize; i++)
		{
			Instantiate(prefab, _lastCreatedPosition, Quaternion.identity);
			_lastCreatedPosition += new Vector3(_tileXSize, 0f, 0f);
		}
	}

	Vector3 CalculatePosition()
	{
		return new Vector3 (transform.position.x, _referencePosition.y + Random.Range (_minYOffset, _maxYOffset), _referencePosition.z);
	}

	int CalculateTileSize()
	{
		return Random.Range (_minTileSize, _maxTileSize);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (transform.position + new Vector3(0, _minYOffset, 0), 0.25f);
		Gizmos.DrawSphere (transform.position + new Vector3(0, _maxYOffset, 0), 0.25f);
	}
}
