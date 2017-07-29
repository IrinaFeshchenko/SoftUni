using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Lake : IEnumerable<int>
{
    private readonly IList<int> stones;

    public Lake(IEnumerable<int> stones)
    {
        this.stones = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < stones.Count; i += 2)
        {
            yield return stones[i];
        }

        int offset = this.stones.Count % 2 != 0 ? 2 : 1;
        for (int i = this.stones.Count - offset; i > 0; i -= 2)
        {
            yield return stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
