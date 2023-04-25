using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers.Generation
{
    public interface ITowerSegmentCreationCallback
     
    {
        event Action SegmentCreated;
    }
}
