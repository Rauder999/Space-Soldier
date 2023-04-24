public interface ICollectableItem
{
    public CollectableItems ItemType { get;}

    public int GetCount();

    public void OnCollect();
}


public enum CollectableItems
{
    BulletPack
}