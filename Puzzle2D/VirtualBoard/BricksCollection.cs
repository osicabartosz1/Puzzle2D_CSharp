using Puzzle2D.Extentions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Puzzle2D.VirtualBoard
{
    public class BricksCollection
    {
        public List<Brick> Collection = new List<Brick>();

        public static BricksCollection load()
        { 
            var text = File.ReadAllText(@"VirtualBoard\BricksCollection\BricksCollection.txt");
            return text.DeserializeObject<BricksCollection>();
        }

        internal void ChangeAccordingTo(string history)
        {
            for (int i = 0; i < (history.Length / 4); i++)
            {
                Collection.Single(x => x.number == i).MoveBrickToRequirePosition(history.Substring(i * 4, 4));
            }
        }
    }
}
