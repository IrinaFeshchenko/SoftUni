using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class LinkedList : IEnumerable<int>
{
    private Node<int> _node;
    public LinkedList()
    {
        this._node = new Node<int>(0);
    }

    public int Count => GetCount();

    public int GetCount()
    {
        int count = 0;
        var currentNode = this._node;
        while (currentNode.HasNext())
        {
            count++;
            currentNode = currentNode.Next;
        }

        return count;
    }

    public void Add(int value)
    {
        var node = new Node<int>(value);
        var currentNode = this._node;
        while (currentNode.HasNext())
        {
            currentNode = currentNode.Next;
        }
        currentNode.Next = node;
    }

    public void Remove(int value)
    {
        var currentNode = this._node;
        var lastNode = this._node;
        while (currentNode.HasNext())
        {
            lastNode = currentNode;
            currentNode = currentNode.Next;
            if (currentNode.Value == value)
            {
                if (currentNode.HasNext())
                {
                    lastNode.Next = currentNode.Next;
                    currentNode = lastNode;
                    break;
                }
                else
                {
                    lastNode.Next = null;
                    break;
                }
            }
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        var currentNode = this._node;
        while (currentNode.HasNext())
        {
            currentNode = currentNode.Next;
            yield return currentNode.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
