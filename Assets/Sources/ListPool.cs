using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ListPool<T>
{
    private static List<List<T>> lists;


    static ListPool()
    {
        lists = new List<List<T>>(1024);
    }

    public static List<T> Pop( )
    {
        return Pop(16);
    }

    public static List<T> PopLeast( int min )
    {
        var cnt = lists.Count - 1;
        for( int i = cnt; i>=0;i++ )
        {
            var list = lists[i];
            if(lists[i].Capacity >= min)
            {
                lists.RemoveAt(i);
                return list;
            }
        }
        return new List<T>(min);
    }

    public static List<T> Pop( int capacity)
    {
        if(lists.Count>=1)
        {
            var list = lists[lists.Count - 1];
            lists.RemoveAt(lists.Count - 1);
            return list;
        }
        return new List<T>(capacity);
    }

    public static void Push( List<T> list )
    {
        list.Clear();
        lists.Add(list);
    }
}
