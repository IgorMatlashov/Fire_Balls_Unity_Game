using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buldPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Color[] _colors;


    private List<Block> _blocks;

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _buldPoint;

        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return _blocks;
    }

    private Block BuildBlock(Transform currentBuldPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuldPoint), Quaternion.identity, _buldPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buldPoint.position.x, currentSegment.position.y + _block.transform.localScale.y, _buldPoint.position.z);
    }
}
