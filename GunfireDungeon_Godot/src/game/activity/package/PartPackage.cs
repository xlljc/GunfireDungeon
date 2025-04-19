
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PartPackage : Component<Role>, IEnumerable
{
    private PartProp[] _partPropPack = new PartProp[0];
    
    public int Count => _partPropPack.Length;
    
    public void SetCapacity(int size)
    {
        var prev = _partPropPack;
        _partPropPack = new PartProp[size];
        
        //多余的扔掉
        if (prev.Length > size)
        {
            for (var i = size; i < prev.Length; i++)
            {
                if (prev[i] != null)
                {
                    prev[i].OnOverflowItem();
                    prev[i].Master = null;
                }
            }
        }
        
        for (var i = 0; i < size; i++)
        {
            if (i < prev.Length)
            {
                _partPropPack[i] = prev[i];
            }
        }
    }

    public int FindEmptyIndex()
    {
        for (var i = 0; i < _partPropPack.Length; i++)
        {
            if (_partPropPack[i] == null)
            {
                return i;
            }
        }
        
        return -1;
    }
    
    public bool Add(PartProp partProp)
    {
        var index = FindEmptyIndex();
        if (index < 0)
        {
            return false;
        }

        return Set(index, partProp);
    }

    public PartProp Get(int index)
    {
        if (index < 0 || index >= _partPropPack.Length)
        {
            return null;
        }
        return _partPropPack[index];
    }

    public bool Set(int index, PartProp partProp)
    {
        if (index < 0 || index >= _partPropPack.Length)
        {
            return false;
        }

        var prev = _partPropPack[index];
        if (prev != null)
        {
            prev.OnPickUpItem();
            prev.Master = null;
        }

        _partPropPack[index] = partProp;
        partProp.Master = Master;
        partProp.OnPickUpItem();
        return true;
    }
    
    public bool Remove(PartProp partProp)
    {
        for (var i = 0; i < _partPropPack.Length; i++)
        {
            if (_partPropPack[i] == partProp)
            {
                _partPropPack[i] = null;
                partProp.OnRemoveItem();
                partProp.Master = null;
                return true;
            }
        }
        return true;
    }
    
    public bool Remove(int index)
    {
        var partProp = Get(index);
        if (partProp == null)
        {
            return false;
        }
        partProp.OnRemoveItem();
        partProp.Master = null;
        return true;
    }
    
    public int IndexOf(PartProp partProp)
    {
        for (var i = 0; i < _partPropPack.Length; i++)
        {
            if (_partPropPack[i] == partProp)
            {
                return i;
            }
        }
        return -1;
    }
    
    public bool Contains(PartProp partProp)
    {
        return IndexOf(partProp) >= 0;
    }
    
    public void Clear()
    {
        for (var i = 0; i < _partPropPack.Length; i++)
        {
            var partProp = _partPropPack[i];
            if (partProp != null)
            {
                partProp.OnPickUpItem();
                partProp.Master = null;
            }
        }
        _partPropPack = new PartProp[0];
    }

    public IEnumerator GetEnumerator()
    {
        return _partPropPack.GetEnumerator();
    }

    public List<PartProp> ToList()
    {
        return _partPropPack.ToList();
    }
}