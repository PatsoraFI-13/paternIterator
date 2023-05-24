using NUnit.Framework;

[TestFixture]
public class IteratorTests
{
    [Test]
    public void ConcreteIterator_HasNext_ReturnsTrueWhenItemsAvailable()
    {
        ConcreteCollection collection = new ConcreteCollection();
        collection[0] = "Item 1";

        ConcreteIterator iterator = new ConcreteIterator(collection);
        bool hasNext = iterator.hasMore();
        Assert.IsTrue(hasNext);
    }

    [Test]
    public void ConcreteIterator_HasNext_ReturnsFalseWhenNoItemsAvailable()
    {
        ConcreteCollection collection = new ConcreteCollection();
        ConcreteIterator iterator = new ConcreteIterator(collection);
        bool hasNext = iterator.hasMore();
        Assert.IsFalse(hasNext);
    }

    [Test]
    public void ConcreteIterator_Next_ReturnsNextItem()
    {
        ConcreteCollection collection = new ConcreteCollection();
        collection[0] = "Item 1";
        collection[1] = "Item 2";

        ConcreteIterator iterator = new ConcreteIterator(collection);
        object nextItem = iterator.getNext();
        Assert.AreEqual("Item 1", nextItem);
    }

    [Test]
    public void ConcreteIterator_Next_ThrowsExceptionWhenNoMoreElements()
    {
        ConcreteCollection collection = new ConcreteCollection();
        ConcreteIterator iterator = new ConcreteIterator(collection);
        Assert.Throws<IndexOutOfRangeException>(() => iterator.getNext());
    }
}
