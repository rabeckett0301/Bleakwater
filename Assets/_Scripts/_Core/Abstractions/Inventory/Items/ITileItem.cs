using System.Collections.Generic;

namespace Bleakwater
{
    public interface ITileItem : IItem
    {
        public IEnumerable<TileTag> TileTags { get; }

        public bool Activate(ITile targetTile, IPawn user);
    }
}