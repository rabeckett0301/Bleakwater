namespace Bleakwater
{
    public interface IUseableItem : IItem
    {
        public bool Activate(IPawn user);
    }
}