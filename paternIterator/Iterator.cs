using System.Collections;

public interface IIterator
{
    bool hasMore();
    object getNext();
}

public class ConcreteIterator : IIterator
{
    private readonly ConcreteCollection collection;
    private int position = 0;
    public ConcreteIterator(ConcreteCollection collection)
    {
        this.collection = collection;
    }
    public bool hasMore()
    {
        return position < collection.Count;
    }
    public object getNext()
    {
        if (hasMore())
        {
            object item = collection[position];
            position++;
            return item;
        }
        throw new IndexOutOfRangeException("No more elements");
    }
}

public interface ICollection
{
    IIterator CreateIterator();
}

public class ConcreteCollection : ICollection
{
    private readonly ArrayList items = new ArrayList();
    public object this[int index]
    {
        get { return items[index]; }
        set { items.Insert(index, value); }
    }
    public int Count
    {
        get { return items.Count; }
    }
    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConcreteCollection collection = new ConcreteCollection();
        collection[0] = "Item 1";
        collection[1] = "Item 2";
        collection[2] = "Item 3";
        collection[3] = "Item 4";
        collection[4] = "Item 5";

        IIterator iterator = collection.CreateIterator();
        while (iterator.hasMore())
        {
            object item = iterator.getNext();
            Console.WriteLine(item);
        }
    }
}
